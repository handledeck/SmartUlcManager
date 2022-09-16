using System;
using Ztp.Attributes;
using Ztp.Enums;

namespace Ztp.Configuration
{
  public class ZtpDate : CheckingChangesObject, IComparable<ZtpDate>
  {
    Month _month = Month.Jan;
    byte _day = 1;

    public ZtpDate()
    {
    }
    public ZtpDate(Month month, byte day)
    {
      _month = month;
      _day = day;
    }

    public Month Month
    {
      get
      {
        return _month;
      }
      set
      {
        if (_month != value)
        {
          Set();
          _month = value;
        }
      }
    }
    public byte Day
    {
      get
      {
        return _day;
      }
      set
      {
        if (_day != value)
        {
          Set();
          _day = value;
        }
      }
    }

    public static bool operator >(ZtpDate a, ZtpDate b)
    {
      if (a.Month > b.Month) return true;
      if (b.Month > a.Month) return false;
      return a.Day > b.Day;
    }

    public static bool operator <(ZtpDate a, ZtpDate b)
    {
      if (b.Month > a.Month) return true;
      if (a.Month > b.Month) return false;
      return b.Day > a.Day;
    }

    public static bool operator ==(ZtpDate a, ZtpDate b)
    {
      if (Equals(a, null) && Equals(b, null)) return true;
      if (!Equals(a, null) && Equals(b, null)) return false;
      if (Equals(a, null)) return false;
      return a.Month == b.Month && a.Day == b.Day;
    }

    public static bool operator !=(ZtpDate a, ZtpDate b)
    {
      if (Equals(a, null) && Equals(b, null)) return false;
      if (!Equals(a, null) && Equals(b, null)) return true;
      if (Equals(a, null)) return true;
      return a.Month != b.Month || a.Day != b.Day;
    }

    public int CompareTo(ZtpDate other)
    {
      if (this < other) return -1;
      if (this > other) return 1;
      return 0;
    }


    public override string ToString()
    {
      return $"{Day:00}.{(byte)Month:00}";
    }

    public override bool Equals(object obj)
    {
      ZtpDate date = obj as ZtpDate;
      if (date == null) return false;
      return Month == date.Month && Day == date.Day;
    }

    public override int GetHashCode()
    {
      return ToString().GetHashCode();
    }

    public ZtpDate Clone()
    {
      return new ZtpDate(Month, Day);
    }

    public override bool IsValid()
    {
      MonthAttribute ma = _month.GetFieldAttribute();
      return _day >= 1 && _day <= ma.CountOfDay;
    }
  }
}
