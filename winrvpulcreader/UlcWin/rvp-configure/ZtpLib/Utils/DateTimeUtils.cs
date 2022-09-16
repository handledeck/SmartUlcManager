using System;

namespace Ztp.Utils
{
  public static class DateTimeUtils
  {
    const double Rads = Pi / 180.0;
    const double Degs = 180.0 / Pi;
    const double Pi = 3.14159;
    const double SunDia = 0.53;
    static readonly double AirRefr = 34.0 / 60.0;

    static readonly int RTC_MODE2_CLOCK_SECOND_Pos = 0;
    static readonly int RTC_MODE2_CLOCK_SECOND_Msk = 0x3F << RTC_MODE2_CLOCK_SECOND_Pos;

    static readonly int RTC_MODE2_CLOCK_MINUTE_Pos = 6;
    static readonly int RTC_MODE2_CLOCK_MINUTE_Msk = 0x3F << RTC_MODE2_CLOCK_MINUTE_Pos;

    static readonly int RTC_MODE2_CLOCK_HOUR_Pos = 12;
    static readonly int RTC_MODE2_CLOCK_HOUR_Msk = 0x1F << RTC_MODE2_CLOCK_HOUR_Pos;

    static readonly int RTC_MODE2_CLOCK_DAY_Pos = 17;
    static readonly int RTC_MODE2_CLOCK_DAY_Msk = 0x1F << RTC_MODE2_CLOCK_DAY_Pos;

    static readonly int RTC_MODE2_CLOCK_MONTH_Pos = 22;
    static readonly int RTC_MODE2_CLOCK_MONTH_Msk = 0xF << RTC_MODE2_CLOCK_MONTH_Pos;

    static readonly int RTC_MODE2_CLOCK_YEAR_Pos = 26;
    static readonly int RTC_MODE2_CLOCK_YEAR_Msk = 0x3F << RTC_MODE2_CLOCK_YEAR_Pos;

    public static uint ToUInt32(DateTime time)
    {
      uint retVal = Convert.ToUInt32(time.Year - 2000) << RTC_MODE2_CLOCK_YEAR_Pos;
      retVal |= (Convert.ToUInt32(time.Month) << RTC_MODE2_CLOCK_MONTH_Pos);
      retVal |= (Convert.ToUInt32(time.Day) << RTC_MODE2_CLOCK_DAY_Pos);
      retVal |= (Convert.ToUInt32(time.Hour) << RTC_MODE2_CLOCK_HOUR_Pos);
      retVal |= (Convert.ToUInt32(time.Minute) << RTC_MODE2_CLOCK_MINUTE_Pos);
      retVal |= (Convert.ToUInt32(time.Second) << RTC_MODE2_CLOCK_SECOND_Pos);
      return retVal;
    }

    public static DateTime ToDateTime(uint value)
    {
      int year = (int)((value & RTC_MODE2_CLOCK_YEAR_Msk) >> RTC_MODE2_CLOCK_YEAR_Pos) + 2000;
      int month = (int)((value & RTC_MODE2_CLOCK_MONTH_Msk) >> RTC_MODE2_CLOCK_MONTH_Pos);
      int day = (int)((value & RTC_MODE2_CLOCK_DAY_Msk) >> RTC_MODE2_CLOCK_DAY_Pos);
      int hour = (int)((value & RTC_MODE2_CLOCK_HOUR_Msk) >> RTC_MODE2_CLOCK_HOUR_Pos);
      int minute = (int)((value & RTC_MODE2_CLOCK_MINUTE_Msk) >> RTC_MODE2_CLOCK_MINUTE_Pos);
      int second = (int)((value & RTC_MODE2_CLOCK_SECOND_Msk) >> RTC_MODE2_CLOCK_SECOND_Pos);
      return new DateTime(year, month, day, hour, minute, second);
    }

    private static double FNday(int y, int m, int d, float h)
    {
      long luku = -7 * (y + (m + 9) / 12) / 4 + 275 * m / 9 + d;
      luku += (long)y * 367;
      return (double)luku - 730531.5 + h / 24.0;
    }

    private static double FNrange(double x)
    {
      double b = 0.5 * x / Pi;
      double a = 2.0 * Pi * (b - (long)(b));
      if (a < 0) a = 2.0 * Pi + a;
      return a;
    }

    private static double F0(double lat, double declin)
    {
      double dfo = Rads * (0.5 * SunDia + AirRefr); if (lat < 0.0) dfo = -dfo;
      double fo = Math.Tan(declin + dfo) * Math.Tan(lat * Rads);
      if (fo > 0.99999) fo = 1.0;
      fo = Math.Asin(fo) + Pi / 2.0;
      return fo;
    }

    private static double FNsun(double d, out double l, out double g)
    {
      l = FNrange(280.461 * Rads + .9856474 * Rads * d);
      g = FNrange(357.528 * Rads + .9856003 * Rads * d);
      return FNrange(l + 1.915 * Rads * Math.Sin(g) + .02 * Rads * Math.Sin(2 * g));
    }

    public static void SunRiseSet(DateTime time, sbyte timezone, float latIt, float longIt, 
      out DateTime osunrise, out DateTime osunset)
    {
      try
      {
        double l, g;
        int y = time.Year;
        int m = time.Month;
        int day = time.Day;
        int h = 12;
        double latit = latIt;
        double longit = longIt;
        double tzone = timezone;
        double d = FNday(y, m, day, h);
        double lambda = FNsun(d, out l, out g);
        double obliq = 23.439 * Rads - .0000004 * Rads * d;
        double alpha = Math.Atan2(Math.Cos(obliq) * Math.Sin(lambda), Math.Cos(lambda));
        double delta = Math.Asin(Math.Sin(obliq) * Math.Sin(lambda));
        double ll = l - alpha;
        if (l < Pi) ll += 2.0 * Pi;
        double equation = 1440.0 * (1.0 - ll / Pi / 2.0);
        double ha = F0(latit, delta);
        double riset = 12.0 - (12.0 * ha / Pi) + tzone - (longit / 15.0) + (equation / 60.0);
        double settm = 12.0 + 12.0 * ha / Pi + tzone - longit / 15.0 + equation / 60.0;
        double altmax = 90.0 + delta * Degs - latit;
        if (riset > 24.0) riset -= 24.0;
        if (settm > 24.0) settm -= 24.0;
        double hr = settm;
        double mn = (settm - (int)hr) * 60;
        osunset = new DateTime(time.Year, time.Month, time.Day, (int)hr, (int)mn, 0);
        hr = riset;
        mn = (riset - (int)hr) * 60;
        osunrise = new DateTime(time.Year, time.Month, time.Day, (int)hr, (int)mn, 0);
      }
      catch
      {
        throw new Exception("Ќесоответствие между параметрами географических координат и часовым по€сом.");
      }
    }

  }
}