using System;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
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

    [Dev(3, "ULC02Lite")]
    ULC2Lite = 3,
    [Dev(4, "ULC03")]
    ULC3 = 4
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

  

  public class CtrlType
  {
    public static Device GetControllerType(string version)
    {
      if (version == "I16O2A2-LDC-3-FOTA")
      {
        return Device.RVP;
      }
      else if (version == "I4O1A1-LDC-3-FOTA-DM" || version== "I4O1A1-LDC-3-FOTA")
      {
        return Device.ULC2;
      }
      else if (version == "I3O2A1-LEM-4-FOTA-prIM" || version=="I1O1A1-LEM-4-FOTA")
      {
        return Device.ULC2Lite;
      }
      else return Device.ULC3;
    }
  }
}
