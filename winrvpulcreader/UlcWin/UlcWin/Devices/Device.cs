using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin.Devices
{
  public enum EnumTypeController
  {
    RVP,
    ULC2,
    ULC2Lite,
    ULC3
  }

  public class ControllerType
  {
    public static EnumTypeController GetControllerType(string version)
    {
      if (version == "I16O2A2-LDC-3-FOTA" || version== "I16O2A2-LDC-3-FOTA-BT")
      {
        return EnumTypeController.RVP;
      }
      else if (version == "I4O1A1-LDC-3-FOTA-DM" || version== "I4O1A1-LDC-3-FOTA")
      {
        return EnumTypeController.ULC2;
      }
      else if (version == "I3O2A1-LEM-4-FOTA-prIM" || version == "I1O1A1-LEM-4-FOTA")
      {
        return EnumTypeController.ULC2Lite;
      }
      else return EnumTypeController.ULC3;
    }
  }
}
