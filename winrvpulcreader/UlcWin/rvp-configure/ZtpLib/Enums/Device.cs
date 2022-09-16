using System;
using System.Linq;
using System.Reflection;
using Ztp.Attributes;

namespace Ztp.Enums
{
  public enum Device : byte
  {
    [Dev(0, "Неизвестно")]
    Unknown = 0,

    [Dev(1,"РВП-18")]
    RVP = 1,

    [Dev(2, "ULC02")]
    ULC2 = 2,

    [Dev(3, "ULC02 (ver.2)")]
    ULC2_2 = 3
  }

  public static class DevExt
  {
    static Type _type = typeof(Device);
    public static DevAttribute GetFieldAttribute(this Device device)
    {
      FieldInfo fi = _type.GetField(device.ToString());
      return fi.GetCustomAttributes(typeof(DevAttribute), false).AsEnumerable().Select((a) => (DevAttribute)a).First();
    }
  }
}
