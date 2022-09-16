using System;

namespace Ztp.Protocol
{
  public enum DeviceActionMode
  {
    Read,
    Write,
    Reboot,
    Switch,
    SetPwd,
    Fota,
    Write_ModBus,
    Read_ModBus,
    Write_MB_lbl,
    Read_MB_lbl,
    TestPing,
    BrightToggle,
    TestCore,
    GetCurTraf,
    Patch,
    TestVersion
  }

  public static class DeviceActionModeEx
  {
    public static OpHistoryCode ToOpHistoryCode(this DeviceActionMode value)
    {
      switch (value)
      {
        case DeviceActionMode.Fota:
          return OpHistoryCode.F;
        case DeviceActionMode.Reboot:
          return OpHistoryCode.R;
        case DeviceActionMode.SetPwd:
          return OpHistoryCode.P;
        case DeviceActionMode.Switch:
          return OpHistoryCode.L;
        case DeviceActionMode.Write:
          return OpHistoryCode.W;
        case DeviceActionMode.TestCore:
          return OpHistoryCode.V;
        case DeviceActionMode.Patch:
          return OpHistoryCode.PA;
        case DeviceActionMode.TestVersion:
          return OpHistoryCode.VPO;
        default:
          throw new ArgumentException(nameof(value));
      }
    }
  }

}
