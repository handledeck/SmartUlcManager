using System;

namespace Ztp.Configuration
{
  public class ZtpDateItem: CheckingChangesObject
  {
    ZtpDate _begin;
    ZtpDate _end;

    public ZtpDate Begin
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

    public ZtpDate End
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

    public ZtpDateItem()
    {
    }

    public ZtpDateItem(ZtpDate begin, ZtpDate end)
    {
      _begin = begin;
      _end = end;
    }

    public override bool HasChanges()
    {
      return _begin.HasChanges() || _end.HasChanges();
    }

    public override void Reset()
    {
      _begin.Reset();
      _end.Reset();
    }

    public override bool IsValid()
    {
      return _begin.IsValid() && _end.IsValid();
    }

    public override string ToString()
    {
      return $"{Begin}-{End}";
    }

    public override bool Equals(object obj)
    {
      ZtpDateItem item = obj as ZtpDateItem;
      if (item == null) return false;
      return this.Begin.Equals(item.Begin) && this.End.Equals(item.End);
    }

    public override int GetHashCode()
    {
      return ToString().GetHashCode();
    }

    public static bool operator ==(ZtpDateItem a, ZtpDateItem b)
    {
      if (Equals(a, null) && Equals(b, null)) return true;
      if (!Equals(a, null) && Equals(b, null)) return false;
      if (Equals(a, null)) return false;
      return a.Begin == b.Begin && a.End == b.End;
    }

    public static bool operator !=(ZtpDateItem a, ZtpDateItem b)
    {
      if (Equals(a, null) && Equals(b, null)) return false;
      if (!Equals(a, null) && Equals(b, null)) return true;
      if (Equals(a, null)) return true;
      return a.Begin != b.Begin || a.End != b.End;
    }

  }
}
