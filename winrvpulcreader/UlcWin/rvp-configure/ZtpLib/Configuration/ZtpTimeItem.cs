using System;
using Ztp.Enums;

namespace Ztp.Configuration
{
  public class ZtpTimeItem : CheckingChangesObject
  {
    ZtpTime _time;
    public ZtpTime Time
    {
      get
      {
        return _time;
      }
      set
      {
        if(_time != value)
        {
          Set();
          _time = value;
        }
      }
    }

    TimeKind _kind;
    public TimeKind Kind
    {
      get
      {
        return _kind;
      }
      set
      {
        if (_kind != value)
        {
          Set();
          _kind = value;
        }
      }
    }

    public ZtpTimeItem()
    {
    }

    public override bool HasChanges()
    {
      return base.HasChanges() || _time.HasChanges();
    }

    public override void Reset()
    {
      base.Reset();
      _time.Reset();
    }

    public override bool IsValid()
    {
      if (Kind == TimeKind.None)
        return Time.IsValid();
      return Time.Span <= new TimeSpan(12, 0, 0);
    }

    public override string ToString()
    {
      return $"{_kind.ToText()} {Time}";
    }

    public override bool Equals(object obj)
    {
      ZtpTimeItem item = obj as ZtpTimeItem;
      if (item == null) return false;
      return Kind == item.Kind && Time.Equals(item.Time);
    }

    public override int GetHashCode()
    {
      return ToString().GetHashCode();
    }

    public ZtpTimeItem Clone()
    {
      return new ZtpTimeItem()
      {
        Kind = this.Kind,
        Time = this.Time.Clone()
      };
    }

    public static bool operator ==(ZtpTimeItem a, ZtpTimeItem b)
    {
      if (Equals(a, null) && Equals(b, null)) return true;
      if (!Equals(a, null) && Equals(b, null)) return false;
      if (Equals(a, null)) return false;
      return a.Time == b.Time && a.Kind == b.Kind;
    }

    public static bool operator !=(ZtpTimeItem a, ZtpTimeItem b)
    {
      if (Equals(a, null) && Equals(b, null)) return false;
      if (!Equals(a, null) && Equals(b, null)) return true;
      if (Equals(a, null)) return true;
      return a.Time != b.Time || a.Kind != b.Kind;
    }

  }
}
