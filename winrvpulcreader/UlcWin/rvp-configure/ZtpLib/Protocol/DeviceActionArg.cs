using System;
using Ztp.Configuration;
using Ztp.IO.Logger;
using Ztp.Port.TcpPort;

namespace Ztp.Protocol
{
  public class DeviceActionArg
  {
    public ILog Log { get; set; } = NullLog.Null;
    public Func<int, TcpPortSettings> ReadTcpSetingFunc { get; set; }
    public Func<int, ZtpConfig> GetNewZtpConfigFunc { get; set; }
    public Func<int, string> GetNewPasswordFunc { get; set; }
    public Func<int, bool> GetNewSwitchOnFunc { get; set; }
    public Func<int, string> GetCoreVersion { get; set; }
    public Func<int, string> GetVersionPO { get; set; }
    public Action<int> ReportProgress { get; set; }
    public int[] DeviceIds { get; set; }

    public DeviceActionMode Mode { get; }
    public DeviceActionArg(DeviceActionMode mode)
    {
      Mode = mode;
    }
  }
}