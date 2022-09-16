using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ztp.Enums;
using Ztp.Utils;

namespace Ztp.Configuration
{
  public class ZtpScheduler : CheckingChangesObject
  {
    public const int MaxSeasonCount = 8;
    public const int MaxSheduleCount = 4;

    readonly ItemCollection<ZtpSeason> _season = new ItemCollection<ZtpSeason>();
    public ItemCollection<ZtpSeason> Seasons
    {
      get
      {
        return _season;
      }
    }

    public ZtpScheduler()
    {
      _season.CollectionChanged += _season_CollectionChanged;
    }

    private void _season_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
      Set();
    }


    public override bool HasChanges()
    {
      return base.HasChanges() || _season.Count((o) => o.HasChanges()) > 0;
    }
    public override void Reset()
    {
      base.Reset();
      _season.Count((o) =>
      {
        o.Reset();
        return false;
      });
    }

    public override bool IsValid()
    {
      return _season.Count((s) => s.IsValid()) == _season.Count;
    }

    public string ToBase64String()
    {
      byte[] ba = Serialize(this);
      return Convert.ToBase64String(ba);
    }

    public static ZtpScheduler GetDefault()
    {
      ZtpScheduler retVal = new ZtpScheduler();
      return retVal;
    }
#if !MOBILE
    public static void SaveToFile(string path, ZtpScheduler document)
    {
      if (document == null) throw new ArgumentNullException(nameof(document));
      if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
      System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ZtpScheduler));
      using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write))
      {
        serializer.Serialize(fs, document);
        document.Reset();
      }
    }

    public static ZtpScheduler LoadFromFile(string path)
    {
      ZtpScheduler document = null;
      System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ZtpScheduler));
      using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
      {
        document = serializer.Deserialize(fs) as ZtpScheduler;
        document.Reset();
      }
      return document;
    }
#endif
    #region Serialize
    public static byte[] Serialize(ZtpScheduler zs)
    {
      using (MemoryStream ms = new MemoryStream())
      {
        List<byte> retVal = new List<byte>();
        ms.WriteByte(PackSeasonCountAndVersion(zs));
        byte[] buff = PackSeasonInfo(zs);
        ms.Write(buff, 0, buff.Length);
        buff = PackSchedules(zs);
        ms.Write(buff, 0, buff.Length);
        byte[] body = ms.ToArray();
        retVal.AddRange(body);
        return retVal.ToArray();
      }
    }

    private const byte _currentVersion = 1;
    static byte PackSeasonCountAndVersion(ZtpScheduler zs)
    {
      byte count = (byte)zs.Seasons.Count;
      bool[] arrCount = Bit.ToBitArray(count);
      bool[] arrVersion = Bit.ToBitArray(_currentVersion);

      for (int i = 4; i < 8; i++)
        arrCount[i] = arrVersion[i - 4];
      return Bit.ToByte(arrCount);
    }

    static byte[] PackSeasonInfo(ZtpScheduler zs)
    {
      List<byte> list = new List<byte>();
      foreach (ZtpSeason season in zs.Seasons)
      {
        list.Add((byte)season.Bound.Begin.Month);
        list.Add(season.Bound.Begin.Day);
        list.Add((byte)season.Bound.End.Month);
        list.Add(season.Bound.End.Day);
        list.Add((byte)(season.Intervals.Count));
      }
      return list.ToArray();
    }


    static byte[] PackSchedules(ZtpScheduler zs)
    {
      List<byte> list = new List<byte>();
      foreach (ZtpSeason season in zs.Seasons)
      {
        foreach (ZtpTimeRange interval in season.Intervals)
        {
          list.AddRange(PackTimeInterval(interval));
        }
      }
      return list.ToArray();
    }

    static byte[] PackTimeInterval(ZtpTimeRange interval)
    {
      byte[] retVal = new byte[5];
      retVal[0] = PackTimeIntervalInfo(interval);
      retVal[1] = interval.Begin.Time.Hour;
      retVal[2] = interval.Begin.Time.Minute;
      retVal[3] = interval.End.Time.Hour;
      retVal[4] = interval.End.Time.Minute;
      return retVal;
    }

    static byte PackTimeIntervalInfo(ZtpTimeRange interval)
    {
      bool[] buff = new bool[8];
      //if (interval.Kind == TimeRangeKind.Relative)
      //{
        //buff[0] = true;
        byte beginKind = GetRelativeKind(interval.Begin.Kind);
        bool[] beginKindBuff = Bit.ToBitArray(beginKind);

        byte endKind = GetRelativeKind(interval.End.Kind);
        bool[] endKindBuff = Bit.ToBitArray(endKind);

        buff[0] = beginKindBuff[0];
        buff[1] = beginKindBuff[1];
        buff[2] = beginKindBuff[2];

        buff[3] = endKindBuff[0];
        buff[4] = endKindBuff[1];
        buff[5] = endKindBuff[2];
      //}
      return Bit.ToByte(buff);
    }

    static byte GetRelativeKind(TimeKind kind)
    {
      switch (kind)
      {
        case TimeKind.BeforeSunrise:
          return 0;
        case TimeKind.AfterSunrise:
          return 1;
        case TimeKind.BeforeSunset:
          return 2;
        case TimeKind.AfterSunset:
          return 3;
        case TimeKind.None:
          return 4;
        default:
          throw new ArgumentException();
      }
    }
    #endregion Serialize

    #region Deserialize

    struct Result
    {
      public bool Ok;
      public byte Value;
    }

    static byte GetSeasonCount(byte b)
    {
      bool[] bitArray = Bit.ToBitArray(b);
      bool[] buff = new bool[8];
      for (int i = 0; i < 4; i++)
      {
        buff[i] = bitArray[i];
      }
      return Bit.ToByte(buff);
    }

    static byte GetVersion(byte b)
    {
      bool[] bitArray = Bit.ToBitArray(b);
      bool[] buff = new bool[8];
      for (int i = 4; i < 8; i++)
      {
        buff[i - 4] = bitArray[i];
      }
      return Bit.ToByte(buff);

    }
    static Result ReadByte(MemoryStream ms)
    {
      int res = ms.ReadByte();
      Result retVal = new Result();
      if (res > -1)
      {
        retVal.Ok = true;
        retVal.Value = (byte)res;
      }
      return retVal;
    }

    static void Trash()
    {
      throw new Exception("Входной поток поврежден");
    }


    public static ZtpScheduler Deserialize(byte[] buff)
    {
      ZtpScheduler doc = new ZtpScheduler();

      using (MemoryStream ms = new MemoryStream(buff))
      {
        Result seasonCountResult = ReadByte(ms);
        if (!seasonCountResult.Ok)
        {
          Trash();
          return null;
        }

        byte seasonCount = GetSeasonCount(seasonCountResult.Value);
        byte version = GetVersion(seasonCountResult.Value);
        //версия 0 является устаревшей и не поддерживается
        if (version == 0)
          return doc;

        int[] scheduleInSeason = new int[seasonCount];

        for (int i = 0; i < seasonCount; i++)
        {
          ZtpSeason season = new ZtpSeason();

          Result month = ReadByte(ms);
          if (month.Ok)
            season.Bound.Begin.Month = (Month)month.Value;
          else
          {
            Trash(); return null;
          }
          Result day = ReadByte(ms);
          if (day.Ok)
            season.Bound.Begin.Day = day.Value;
          else
          {
            Trash(); return null;
          }

          month = ReadByte(ms);
          if (month.Ok)
            season.Bound.End.Month = (Month)month.Value;
          else
          {
            Trash(); return null;
          }
          day = ReadByte(ms);
          if (day.Ok)
            season.Bound.End.Day = day.Value;
          else
          {
            Trash(); return null;
          }

          Result scheduleCount = ReadByte(ms);
          if (!scheduleCount.Ok)
          {
            Trash(); return null;
          }
          scheduleInSeason[i] = scheduleCount.Value;

          doc.Seasons.Add(season);
        }

        for (int i = 0; i < scheduleInSeason.Length; i++)
        {
          int countInSeason = scheduleInSeason[i];
          for (int j = 0; j < countInSeason; j++)
          {
            byte[] bytes = new byte[5];
            if (ms.Read(bytes, 0, 5) == 5)
            {
              doc.Seasons[i].Intervals.Add(UnpackSchedule(bytes));
            }
            else
            {
              Trash(); return null;
            }
          }
        }
      }
      return doc;
    }


    static ZtpTimeRange UnpackSchedule(byte[] bytes)
    {
      bool[] bits = Bit.ToBitArray(bytes[0]);
      ZtpTimeRange retVal = new ZtpTimeRange();
      //retVal.Kind = !bits[0] ? TimeRangeKind.Absolute : TimeRangeKind.Relative;
      retVal.Begin = new ZtpTimeItem();
      retVal.End = new ZtpTimeItem();

      bool[] markOn = Bit.ForByte(b0: bits[0], b1: bits[1], b2: bits[2]);
      retVal.Begin.Kind = GetRelativeKind(Bit.ToByte(markOn));

      bool[] markOff = Bit.ForByte(b0: bits[3], b1: bits[4], b2: bits[5]);
      retVal.End.Kind = GetRelativeKind(Bit.ToByte(markOff));

      retVal.Begin.Time = new ZtpTime(bytes[1], bytes[2]);
      retVal.End.Time = new ZtpTime(bytes[3], bytes[4]);
      return retVal;
    }

    static TimeKind GetRelativeKind(byte kind)
    {
      switch (kind)
      {
        case 0:
          return TimeKind.BeforeSunrise;
        case 1:
          return TimeKind.AfterSunrise;
        case 2:
          return TimeKind.BeforeSunset;
        case 3:
          return TimeKind.AfterSunset;
        case 4:
          return TimeKind.None;
        default:
          throw new ArgumentException();
      }
    }

    #endregion Deserialize

    #region Calc Ticks
    static List<DateTimePair> CalcAbsoluteTicks(ZtpSeason season, ZtpTimeRange range)
    {
      List<DateTimePair> list = new List<DateTimePair>();
      DateTime start, end;
      ZtpSeason.SeasonDate(DateTime.Now.Year, season, out start, out end);
      end = end.AddDays(1);

      DateTime current = start;
      while (true)
      {
        DateTime? on, off;
        if (range.Begin.Time.Span > range.End.Time.Span)
        {
          on = current.AddDays(-1).Add(range.Begin.Time.Span);
          off = current.Add(range.End.Time.Span);
        }
        else
        {
          on = current.Add(range.Begin.Time.Span);
          off = current.Add(range.End.Time.Span);
        }
        if ((range.Begin.Time.Span > range.End.Time.Span) && (on < start))
          on = null;
        if (off > end)
          off = null;

        list.Add(new DateTimePair(on, off));
        current = current.AddDays(1);
        if (current == end)
        {
          if (range.Begin.Time.Span > range.End.Time.Span)
          {
            on = current.AddDays(-1).Add(range.Begin.Time.Span);
            off = null;
            list.Add(new DateTimePair(on, off));
          }
          break;
        }
      }
      return list;
    }

    public static List<DateTimePair> CalcTicks(ZtpSeason season, ZtpTimeRange range, sbyte tz, float latitude, float longitude)
    {
      //if (range.Kind != TimeRangeKind.Relative)
      //  throw new ArgumentException(nameof(range));
      List<DateTimePair> list = new List<DateTimePair>();

      DateTime start, end;
      ZtpSeason.SeasonDate(DateTime.Now.Year, season, out start, out end);
      end = end.AddDays(1);

      DateTime current = start;
      while (true)
      {
        DateTime sunRise, sunSet;
        DateTimeUtils.SunRiseSet(current, tz, latitude, longitude, out sunRise, out sunSet);
        DateTime rangeBegin = GetRelativeTime(sunRise, sunSet, range.Begin);
        DateTime rangeEnd = GetRelativeTime(sunRise, sunSet, range.End);
        if (rangeEnd < rangeBegin)
          rangeEnd = rangeEnd.AddDays(1);

        DateTime? on = rangeBegin;
        DateTime? off = rangeEnd;

        if (on < start)
          on = null;
        if (off > end)
          off = null;

        list.Add(new DateTimePair(on, off));
        current = current.AddDays(1);

        if (current == end)
        {
          break;
        }
      }
      return list;
    }

    static DateTime GetRelativeTime(DateTime sunRise, DateTime sunSet, ZtpTimeItem item)
    {
      switch (item.Kind)
      {
        case TimeKind.BeforeSunrise:
          return sunRise.AddHours(item.Time.Hour * -1).AddMinutes(item.Time.Minute * -1);
        case TimeKind.AfterSunrise:
          return sunRise.Add(item.Time.Span);
        case TimeKind.BeforeSunset:
          return sunSet.AddHours(item.Time.Hour * -1).AddMinutes(item.Time.Minute * -1);
        case TimeKind.AfterSunset:
          return sunSet.Add(item.Time.Span);
          case TimeKind.None:
            return sunRise.Date.Add(item.Time.Span);
        default:
          throw new ArgumentException(nameof(item.Kind));
      }
    }

    #endregion Calc Ticks

    #region Overlap

    public static Exception CheckOverlap(ZtpScheduler scheduler, sbyte tz, float latitude, float longitude)
    {
      try
      {
        foreach (ZtpSeason season in scheduler.Seasons)
        {
          foreach (ZtpTimeRange range in season.Intervals)
          {
            CalcTicks(season, range, tz, latitude, longitude);
          }
        }
      }
      catch (Exception e)
      {
        return e;
      }
      Exception retVal = CheckSeasonOverlap(scheduler.Seasons);
      if (retVal != null)
        return retVal;
      return CheckTimeRangeOverlap(scheduler.Seasons, tz, latitude, longitude);
    }

    static Exception CheckSeasonOverlap(ItemCollection<ZtpSeason> seasons)
    {
      Exception retVal = null;
      IOrderedEnumerable<ZtpSeason> orderedEnumerable = seasons.AsEnumerable().OrderBy((s) => s.Bound.Begin);
      int year = DateTime.Now.Year;

      List<Tuple<DateTime, DateTime>> list = new List<Tuple<DateTime, DateTime>>();
      foreach (ZtpSeason season in orderedEnumerable)
      {
        DateTime start, end;
        ZtpSeason.SeasonDate(year, season, out start, out end);
        list.Add(new Tuple<DateTime, DateTime>(start, end));
      }

      foreach (Tuple<DateTime, DateTime> tuple in list)
      {
        Tuple<DateTime, DateTime> singleOrDefault = list.FirstOrDefault((t) =>
        {
          if (t != tuple)
          {
            return tuple.Item1 >= t.Item1 && tuple.Item1 <= t.Item2 ||
                   tuple.Item2 >= t.Item1 && tuple.Item2 <= t.Item2;
          }
          return false;
        });
        if (singleOrDefault != null)
        {
          retVal = new Exception("Пересечение сезонов");
          break;
        }
      }
      return retVal;
    }

    static Exception CheckTimeRangeOverlap(ItemCollection<ZtpSeason> seasons, sbyte tz,
      float latitude, float longitude)
    {
      Exception retVal = null;
      foreach (ZtpSeason season in seasons)
      {
        retVal = CheckTimeRangeOverlap(season, tz, latitude, longitude);
        if (retVal != null)
          break;
      }
      return retVal;
    }

    static Exception CheckTimeRangeOverlap(ZtpSeason season, sbyte tz, float latitude, float longitude)
    {
      Exception retVal = null;

      List<List<DateTimePair>> tuples = new List<List<DateTimePair>>();
      foreach (ZtpTimeRange range in season.Intervals)
      {
        tuples.Add(/*range.Kind == TimeRangeKind.Absolute
          ? CalcAbsoluteTicks(season, range)
          :*/ CalcTicks(season, range, tz, latitude, longitude));
      }

      for (int i = 0; i < tuples.Count; i++)
      {
        ZtpTimeRange currentRange = season.Intervals[i];
        List<DateTimePair> list = tuples[i];
        for (int j = 0; j < tuples.Count; j++)
        {
          if (j == i) continue;

          List<DateTimePair> other = tuples[j];
          ZtpTimeRange checkedRange = season.Intervals[j];

          DateTimePair pair = list.FirstOrDefault((p) =>
          {
            DateTimePair otherPair = other.FirstOrDefault((op) =>
            {
              bool res = NullableDateTimeComparer.FirstGreatOrEqual(op.Item1, p.Item1) &&
                         NullableDateTimeComparer.FirstLessOrEqual(op.Item1, p.Item2) ||
                         NullableDateTimeComparer.FirstGreatOrEqual(op.Item2, p.Item1) &&
                         NullableDateTimeComparer.FirstLessOrEqual(op.Item2, p.Item2);
              if (res)
              {
                string msg =
                  $@"Расписание '{currentRange}'
(время срабатывания {p.ToDisplay()})

пересекается с расписанием '{checkedRange}'
(время срабатывания {op.ToDisplay()})
";
                retVal = new Exception(msg);
              }
              return res;
            });
            return otherPair != null;
          });
          if (pair != null)
          {
            break;
          }
        }
        if (retVal != null)
          break;
      }
      return retVal;
    }
    #endregion Overlap

    #region ToHtml

    public string ToHtml()
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine("<html>");
      sb.AppendLine("<body>");

      for (int i = 0; i < this.Seasons.Count; i++)
      {
        //sb.AppendLine("<p font size=\"2\" face=\"Microsoft Sans Serif\" color=\"Red\">");
        sb.AppendLine("<p><font size=\"2\" face=\"Microsoft Sans Serif\">");

        sb.AppendLine($"<b>Сезон {i + 1} ({Seasons[i].Bound})</b><br>");
        sb.AppendLine("<lo>");
        for (int j = 0; j < Seasons[i].Intervals.Count; j++)
        {
          sb.AppendLine($"<li>{Seasons[i].Intervals[j]}</li>");
        }
        sb.AppendLine("</lo>");
        sb.AppendLine("</font></p>");
      }
      sb.AppendLine("</body>");
      sb.AppendLine("</html>");
      return sb.ToString();
    }

    public string ToText()
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < this.Seasons.Count; i++)
      {
        sb.Append($"Сезон {i + 1}: ");
        for (int j = 0; j < Seasons[i].Intervals.Count; j++)
        {
          sb.AppendLine($"{Seasons[i].Intervals[j]}; ");
        }
        sb.Append(". ");
      }
      return sb.ToString();
    }

    #endregion
  }

  public class DateTimePair
  {
    public DateTime? Item1 { get; set; }
    public DateTime? Item2 { get; }

    public DateTimePair(DateTime? item1, DateTime? item2)
    {
      Item1 = item1;
      Item2 = item2;
    }

    public override int GetHashCode()
    {
      return ToString().GetHashCode();
    }

    public string ToDisplay()
    {
      string i1 = Item1?.ToString("dd-MMM-dd HH:mm") ?? " null";
      string i2 = Item2?.ToString("dd-MMM-dd HH:mm") ?? " null";
      return $"{i1} - {i2}";
    }
    public override string ToString()
    {
      string i1 = Item1?.ToString("yyyyddMMHHmm") ?? " null";
      string i2 = Item2?.ToString("yyyyddMMHHmm") ?? " null";
      return $"{i1} - {i2}";
    }

    public override bool Equals(object obj)
    {
      DateTimePair p = obj as DateTimePair;
      if (p == null) return false;
      string s = p.ToString();
      return string.Equals(ToString(), s);
    }
  }

  public static class NullableDateTimeComparer
  {
    public static bool FirstLessOrEqual(DateTime? x, DateTime? y)
    {
      if (x == null && y == null) return true;
      if (x == null || y == null) return false;
      return x <= y;
    }

    public static bool FirstGreatOrEqual(DateTime? x, DateTime? y)
    {
      if (x == null && y == null) return true;
      if (x == null || y == null) return false;
      return x >= y;
    }
  }
}
