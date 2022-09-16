using System;
#if MOBILE
using Ztp.Port.ComPort;
#endif

namespace Ztp.Enums
{
  public enum TimeKind: byte
  {
#if MOBILE
    [Description("в")]
#endif
    None = 0,

#if MOBILE
    [Description("перед восходом солнца за")]
#endif
    BeforeSunrise = 1,

#if MOBILE
    [Description("после восхода солнца через")]
#endif
    AfterSunrise = 2,

#if MOBILE
    [Description("перед заходом солнца за")]
#endif
    BeforeSunset = 3,

#if MOBILE
    [Description("после захода солнца через")]
#endif
    AfterSunset = 4
  }

  public static class TimeKindExt
  {
    public static string ToText(this TimeKind value)
    {
      switch (value)
      {
        case TimeKind.None:
          return "в";
        case TimeKind.AfterSunrise:
          return "после восхода солнца через";
        case TimeKind.BeforeSunrise:
          return "перед восходом солнца за";
        case TimeKind.AfterSunset:
          return "после захода солнца через";
        case TimeKind.BeforeSunset:
          return "перед заходом солнца за";
        default:
          throw new ArgumentException();
      }
    }
  }
}
