using System;
using Ztp.Enums;

namespace Ztp.Configuration
{
  public class ZtpTimeRange: CheckingChangesObject
  {
    ZtpTimeItem _begin;
    ZtpTimeItem _end;
    public ZtpTimeItem Begin
    {
      get
      {
        return _begin;
      }
      set
      {
        if(_begin != value)
        {
          Set();
          _begin = value;
        }
      }
    }
    public ZtpTimeItem End
    {
      get
      {
        return _end;
      }
      set
      {
        if (_end != value)
        {
          Set();
          _end = value;
        }
      }
    }

    //TimeRangeKind _kind;
    //public TimeRangeKind Kind
    //{
    //  get
    //  {
    //    return _kind;
    //  }
    //  set
    //  {
    //    if (_kind != value)
    //    {
    //      Set();
    //      _kind = value;
    //    }
    //  }
    //}

    public ZtpTimeRange()
    {
    }

    public ZtpTimeRange(ZtpTimeItem item1, ZtpTimeItem item2)
    {
      Begin = item1;
      End = item2;
    }

    public override bool HasChanges()
    {
      return Begin.HasChanges() || End.HasChanges();
    }
    public override void Reset()
    {
      Begin.Reset();
      End.Reset();
    }
    public override string ToString()
    {
      return $"Включить {Begin}, выключить {End}";
    }

    public ZtpTimeRange Clone()
    {
      return new ZtpTimeRange()
      {
        //Kind = this.Kind,
        Begin = this.Begin.Clone(),
        End = this.End.Clone()
      };
    }

    public override int GetHashCode()
    {
      return ToString().GetHashCode();
    }

    public override bool Equals(object obj)
    {
      ZtpTimeRange ti = obj as ZtpTimeRange;
      if (ti == null) return false;
      return /*Kind.Equals(ti.Kind) &&*/ Begin.Equals(ti.Begin) && End.Equals(ti.End);
    }

    public override bool IsValid()
    {
      return Begin.IsValid() && End.IsValid();
    }

  }
}
