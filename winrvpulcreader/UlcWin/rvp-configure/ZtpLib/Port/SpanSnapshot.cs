using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Ztp.Port
{
  /// <summary>Для замера отрезков времени вне зависимости от перевода часов. Потоко безопастный</summary>
  public struct SpanSnapshot
  {
#if !SILVERLIGHT
    private static long frequencyMsec;
    private static bool isHighResolution;
#endif
    internal System.Int64 snapshot;

    /// <summary>Объект пустой</summary>
    public bool IsEmpty
    {
      get
      {
        return (snapshot == 0);
      }
    }

    /// <summary>Минимальное значение</summary>
    public static readonly SpanSnapshot MinValue;

    /// <summary>Максимальное значение</summary>
    public static readonly SpanSnapshot MaxValue;

    static SpanSnapshot()
    {
      isHighResolution = Stopwatch.IsHighResolution;
      frequencyMsec = Stopwatch.Frequency / 1000;
      MinValue = new SpanSnapshot { snapshot = 0 };
      MaxValue = new SpanSnapshot { snapshot = System.Int64.MaxValue };
    }

    #region operations
    /// <summary>Операция вычитания</summary>
    public static SpanSnapshot operator -(SpanSnapshot d, SpanSnapshot t)
    {
      return new SpanSnapshot()
      {
        snapshot = d.snapshot - t.snapshot
      };
    }

    /// <summary>Операция сложения</summary>
    public static SpanSnapshot operator +(SpanSnapshot d, SpanSnapshot t)
    {
      return new SpanSnapshot()
      {
        snapshot = d.snapshot + t.snapshot
      };
    }

    /// <summary>Операция сравнения</summary>
    public static bool operator ==(SpanSnapshot d, SpanSnapshot t)
    {
      return d.snapshot == t.snapshot;
    }

    /// <summary>Операция сравнения</summary>
    public static bool operator !=(SpanSnapshot d, SpanSnapshot t)
    {
      return d.snapshot != t.snapshot;
    }

    /// <summary>Операция сравнения</summary>
    public static bool operator >(SpanSnapshot d, SpanSnapshot t)
    {
      return d.snapshot > t.snapshot;
    }

    /// <summary>Операция сравнения</summary>
    public static bool operator >=(SpanSnapshot d, SpanSnapshot t)
    {
      return d.snapshot >= t.snapshot;
    }

    /// <summary>Операция сравнения</summary>
    public static bool operator <(SpanSnapshot d, SpanSnapshot t)
    {
      return d.snapshot < t.snapshot;
    }

    /// <summary>Операция сравнения</summary>
    public static bool operator <=(SpanSnapshot d, SpanSnapshot t) 
    {
      return d.snapshot <= t.snapshot;
    }
    #endregion


    private SpanSnapshot(Int64 val)
    {
      if (!isHighResolution)
        throw new Exception("В BSP Win Api не реализованы Stopwatch.IsHighResolution");
      this.snapshot = val;
    }


    /// <summary>Сделать снимок</summary>
    public void Snapshot()
    {
      if (!isHighResolution)
        throw new Exception("В BSP Win Api не реализованы Stopwatch.IsHighResolution");
      snapshot = Stopwatch.GetTimestamp();
    }

    /// <summary>Получить текущий Snapshot</summary>
    public static SpanSnapshot Now
    {
      get
      {
        return new SpanSnapshot(Stopwatch.GetTimestamp());
      }
    }

    private const long TicksPerMillisecond = TimeSpan.TicksPerMillisecond;

    /// <summary>Отнять текущий снимок от уже сделанного с помощью Snapshot</summary>
    /// <remarks>Равносильно Diff(SpanSnapshot.Now) в миллесекундах</remarks>
    public Int64 DiffNowMsec()
    {
      return (Stopwatch.GetTimestamp() - snapshot) / frequencyMsec;
    }

    /// <summary>Отнять снимок watch от уже сделанного с помощью Snapshot</summary>
    public Int64 DiffMsec(SpanSnapshot watch)
    {
      return (snapshot - watch.snapshot) / frequencyMsec;
    }

    /// <summary>Добовление миллисекунд</summary>
    public SpanSnapshot AddMilliseconds(int value)
    {
      return new SpanSnapshot() { snapshot = snapshot + value * frequencyMsec };
    }


    /// <summary>Добовление секунд</summary>
    public SpanSnapshot AddSeconds(int value)
    {
      return new SpanSnapshot() { snapshot = snapshot + value * 1000 * frequencyMsec };
    }


    /// <summary/>
    public override int GetHashCode()
    {
      return snapshot.GetHashCode();
    }

    /// <summary/>
    public override bool Equals(object obj)
    {
      if (obj is SpanSnapshot)
      {
        return ((SpanSnapshot)obj).snapshot == snapshot;
      }
      return false;
    }
  }
}
