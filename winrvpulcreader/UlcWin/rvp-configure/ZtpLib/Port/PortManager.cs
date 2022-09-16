using System;
using Ztp.IO.Logger;
using Ztp.Port.ComPort;
using Ztp.Port.TcpPort;

namespace Ztp.Port
{
  public static class PortManager
  {
    public static IPort GetPort(ILog log, PortKind kind, Func<ComPortSettings> comPortSettings, Func<TcpPortSettings> tcpPortSettings)
    {
      switch (kind)
      {
          case PortKind.Com:
            if(comPortSettings == null)
              throw new ArgumentNullException(nameof(comPortSettings));
            ComPortSettings cps = comPortSettings();
            return new ComPort.ComPort(cps, log);
        case PortKind.Tcp:
          if (tcpPortSettings == null)
            throw new ArgumentNullException(nameof(tcpPortSettings));
          TcpPortSettings tps = tcpPortSettings();
          
          return new TcpPort.TcpPort(tps, log);
        default:
          throw new ArgumentException(nameof(kind));
      }
    }
  }
}
