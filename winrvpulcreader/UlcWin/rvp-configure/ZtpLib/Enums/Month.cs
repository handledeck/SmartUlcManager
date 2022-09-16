using System;
using System.Linq;
using System.Reflection;
using Ztp.Attributes;

namespace Ztp.Enums
{
  public enum Month : byte
  {
    [Month(31, "Январь", "Января")]
    Jan = 1,
    [Month(29, "Февраль", "Февраля")]
    Feb = 2,
    [Month(31, "Март", "Марта")]
    Mar = 3,
    [Month(30, "Апрель", "Апреля")]
    Apr = 4,
    [Month(31, "Май", "Мая")]
    May = 5,
    [Month(30, "Июнь", "Июня")]
    Jun = 6,
    [Month(31, "Июль", "Июля")]
    Jul = 7,
    [Month(31, "Август", "Августа")]
    Aug = 8,
    [Month(30, "Сентябрь", "Сентября")]
    Sep = 9,
    [Month(31, "Октябрь", "Октября")]
    Oct = 10,
    [Month(30, "Ноябрь", "Ноября")]
    Nov = 11,
    [Month(31, "Декабрь", "Декабря")]
    Dec = 12
  }

  public static class MonthExt
  {
    static Type _type = typeof(Month);
    public static MonthAttribute GetFieldAttribute(this Month month)
    {
#if MOBILE
      FieldInfo fi = _type.GetRuntimeField(month.ToString());
#else
      FieldInfo fi = _type.GetField(month.ToString());
#endif
      return fi.GetCustomAttributes(typeof(MonthAttribute), false).AsEnumerable().Select((a) => (MonthAttribute)a).First();
    }
  }
}
