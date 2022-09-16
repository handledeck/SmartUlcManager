using System;
using System.Xml.Serialization;

namespace Ztp.Configuration
{
  public class ZtpTime: CheckingChangesObject
  {
    byte _hour = 0;
    public byte Hour
    {
      get
      {
        return _hour;
      }
      set
      {
        if (_hour != value)
        {
          Set();
          _hour = value;
          _span = null;
        }
      }
    }

    byte _minute = 0;
    public byte Minute
    {
      get
      {
        return _minute;
      }
      set
      {
        if(_minute != value)
        {
          Set();
          _minute = value;
          _span = null;
        }
      }
    }

    TimeSpan? _span = null;
    [XmlIgnore()]
    public TimeSpan Span
    {
      get
      {
        if(!_span.HasValue)
          _span = new TimeSpan(Hour, Minute, 0);
        return _span.Value;
      }
    }

    public ZtpTime()
    {
    }

    public ZtpTime(byte hour, byte minute)
    {
      _hour = hour;
      _minute = minute;
    }
    public override string ToString()
    {
      return $"{Hour:00}:{Minute:00}";
    }

    public override bool Equals(object obj)
    {
      ZtpTime t = obj as ZtpTime;
      if(t == null)
        return false;
      return Span.Equals(t.Span);
    }

    public override int GetHashCode()
    {
      return Span.GetHashCode();
    }

    public ZtpTime Clone()
    {
      return new ZtpTime(Hour, Minute);
    }

    public override bool IsValid()
    {
      return _hour <= 23 && _minute <= 59;
    }


    public static bool operator ==(ZtpTime a, ZtpTime b)
    {
      if (Equals(a, null) && Equals(b, null)) return true;
      if (!Equals(a, null) && Equals(b, null)) return false;
      if (Equals(a, null)) return false;
      return a.Span == b.Span;
    }

    public static bool operator !=(ZtpTime a, ZtpTime b)
    {
      if (Equals(a, null) && Equals(b, null)) return false;
      if (!Equals(a, null) && Equals(b, null)) return true;
      if (Equals(a, null)) return true;
      return a.Span != b.Span;
    }

  }
}
