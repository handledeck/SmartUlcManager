using System;
using System.Linq;

namespace Ztp.Configuration
{
  public class ZtpSeason: CheckingChangesObject
  {
    public ZtpSeason()
    {
      _bound = new ZtpDateItem();
      _bound.Begin = new ZtpDate()
      {
        Day = 1,
        Month = Enums.Month.Jan
      };
      _bound.End = new ZtpDate()
      {
        Day = 31,
        Month = Enums.Month.Dec
      };
      _intervals.CollectionChanged += _intervals_CollectionChanged;
    }

    private void _intervals_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
      Set();
    }

    ZtpDateItem _bound;
    public ZtpDateItem Bound
    {
      get
      {
        return _bound;
      }
      set
      {
        if(_bound != value)
        {
          _bound = value;
          Set();
        }
      }
    }

    readonly ItemCollection<ZtpTimeRange> _intervals = new ItemCollection<ZtpTimeRange>();
    public ItemCollection<ZtpTimeRange> Intervals
    {
      get
      {
        return _intervals;
      }
    }

    public override bool HasChanges()
    {
      return base.HasChanges() || _intervals.Count((o) => o.HasChanges()) > 0;
    }

    public override void Reset()
    {
      base.Reset();
      _intervals.Count((o) =>
      {
        o.Reset();
        return false;
      });
    }

    public override bool IsValid()
    {
      return Bound.IsValid();
    }

    public static string GetDisplayName(int index)
    {
      return $"Сезон {index + 1}";
    }

    public static void SeasonDate(int startYear, ZtpSeason season, out DateTime start, out DateTime end)
    {
      int year = startYear;
      start = new DateTime(year, (int)season.Bound.Begin.Month, season.Bound.Begin.Day);
      end = new DateTime(year, (int)season.Bound.End.Month, season.Bound.End.Day);
      if (season.Bound.Begin > season.Bound.End)
      {
        end = end.AddYears(1);
      }
    }

  }
}
