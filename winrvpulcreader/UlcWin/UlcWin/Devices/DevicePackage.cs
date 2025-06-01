using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Ztp.Protocol;
using Ztp.Utils;

namespace UlcWin.Devices
{
  internal class DevicePackage
  {

    internal const char Sep = ':';
    private const char WhiteSpace = ' ';
    public const string MBStartPack = "MBP";
    public const string MBLbl = "MBLBL";
    public const string MBstartLbl = "MBL";
    public const string EthernetRul = "ETHPORTS";
    private const char Return = '\r';
    public static byte[] ToBytes(string str)
    {
      return System.Text.ASCIIEncoding.ASCII.GetBytes(str);
    }

    public static byte[] ModbusWriteConfigByPort(string sessionPwd, int index, byte[] dat, ushort size)
    {
      StringBuilder sb = new StringBuilder($"ADDFCFG_{index}:");
      sb.Append($"PWD{Sep}{Ztp.Utils.StringUtils.ToBase64String(sessionPwd)}{WhiteSpace}");
      sb.Append($"{MBStartPack}{Sep}");
      byte[] val = ToBytes(sb.ToString());
      int prev_size = val.Length;
      Array.Resize(ref val, prev_size + size);
      Array.Copy(dat, 0, val, prev_size, size);
      return val;
    }

    public static Exception EthernetSetRules(NetworkStream stream, string sessionPwd, byte[] dat)
    {
      Exception exception = null;
      try
      {
        StringBuilder sb = new StringBuilder($"{EthernetRul}:");
        sb.Append($"PWD{Sep}{Ztp.Utils.StringUtils.ToBase64String(sessionPwd)}{WhiteSpace}");
        sb.Append($"LIST{Sep}{Convert.ToBase64String(dat)}");
        sb.Append($"{Return}");
        byte[] pack = ToBytes(sb.ToString());
        byte[] rngRead = new byte[128];
        stream.Write(pack, 0, pack.Length);
        int len = stream.Read(rngRead, 0, rngRead.Length);
        string sOk = System.Text.ASCIIEncoding.ASCII.GetString(rngRead, 0, len);
        if (!sOk.Contains("PWD:OK"))
          throw new Exception("Неверный пароль");
      }
      catch (Exception exp)
      {
        exception = exp;
      }
      return exception;
    }


    public static Exception WriteDevicePackage(NetworkStream stream, string sessionPwd, byte[] dat, EnumTypeController enumTypeController)
    {
      Exception exception = null;
      try
      {
        byte[] pack = null;
        if (enumTypeController == EnumTypeController.ULC2)
          pack = ZtpProtocol.ModbusSetConfig(sessionPwd, dat, (ushort)dat.Length);
        else if (enumTypeController == EnumTypeController.ULC2Lite)
          pack = DevicePackage.ModbusWriteConfigByPort(sessionPwd, 1, dat, (ushort)dat.Length);
        byte[] rngRead = new byte[128];
        stream.Write(pack, 0, pack.Length);
        int len = stream.Read(rngRead, 0, rngRead.Length);
        string sOk = System.Text.ASCIIEncoding.ASCII.GetString(rngRead, 0, len);
        if (!sOk.Contains("PWD:OK"))
          throw new Exception("Неверный пароль");
      }
      catch (Exception exp)
      {

        exception = exp;
      }
      return exception;
    }

    public static string ModbusSetLBL(int index, string sessionPwd, string input)
    {
      StringBuilder sb = null;
      if (index == 0)
        sb = new StringBuilder($"{MBLbl}:");
      else
        sb = new StringBuilder($"{MBLbl}_{index}:");
      sb.Append($"PWD{Sep}{Ztp.Utils.StringUtils.ToBase64String(sessionPwd)}{WhiteSpace}");
      sb.Append($"{MBstartLbl}{Sep}{input}{Return}");
      return sb.ToString();
    }
  }
}
