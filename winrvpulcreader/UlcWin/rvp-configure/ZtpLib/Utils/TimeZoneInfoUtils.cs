using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ztp.Utils
{
  public static class TimeZoneInfoUtils
  {
    public static IEnumerable<TimeZoneInfo> GetSystemTimeZones()
    {
      IEnumerable<TimeZoneInfo> retVal = TimeZoneInfo.GetSystemTimeZones().Where((tzi) => tzi.BaseUtcOffset.Minutes == 0);
      return retVal;
    }

    public static TimeZoneInfo FindSystemTimeZoneById(string timeZoneId)
    {
      TimeZoneInfo retVal = null;
      IEnumerable<TimeZoneInfo> zones = GetSystemTimeZones();
      retVal = zones.FirstOrDefault(tzi => tzi.Id == timeZoneId);
      return retVal;
    }
  }
}
