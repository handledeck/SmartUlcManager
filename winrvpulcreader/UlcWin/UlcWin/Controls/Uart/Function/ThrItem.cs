using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UlcWin.Devices;
using Ztp.Protocol;

namespace UlcWin.Controls.Uart.Function
{
  public class ThrItem
  {
    public static Exception WriteUartSettings(TcpClient client, string password, byte pollPeriod, EnumTypeController enumTypeController)
    {
      Exception exception = null;
      try
      {

        byte[] info = { 0, 5, 0, 0, 13 };
        NetworkStream nstream = client.GetStream();
        exception= DevicePackage.WriteDevicePackage(nstream, password, info, enumTypeController);
        //byte[] pack = ZtpProtocol.ModbusSetConfig(password, info, (ushort)info.Length);
        //NetworkStream stream = client.GetStream();
        //byte[] rngRead = new byte[512];
        //stream.Write(pack, 0, pack.Length);
        //int len = stream.Read(rngRead, 0, rngRead.Length);
      }
      catch (Exception exp)
      {
        exception= exp;
      }
      return exception;      
    }
  }
}
