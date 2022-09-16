using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Ztp.Configuration;
using Ztp.Port.ComPort;
using Ztp.Utils;

namespace Ztp.Protocol
{
  public static class ZtpProtocol
  {
    private const char Return = '\r';
    private const char WhiteSpace = ' ';
    internal const char Sep = ':';
    public const int MaxStringLength = 30;

    internal const string EventDi = "DI";
    internal const string EventDo = "DO";
    internal const string EventDa = "DA";
    internal const string Event = "EVT";

    public const string Config = "CONFIG";
    internal const string Upgrade = "UPGRADE";
    internal const string Light = "LIGHTS";
    internal const string SetPassword = "SPASS";
    internal const string Password = "PWD";
    public const string Ok = "OK";
    public const string Error = "ERROR";
    public const string MBConfig = "MBCFG";
    public const string MBStartPack = "MBP";
    public const string MBLbl = "MBLBL";
    public const string MBstartLbl = "MBL";
    public const string TestPingIp = "PINGTEST";
    public const string DropLogs = "DROPLOGS";
    public const string StartUpServ = "RUNUPF";
    public const string SendFilename = "UPFILE";
    public const string ToggleBrightCmd = "TOGGLEBRIGHT";
    public const string GetTraf = "TRAF";
    private static Encoding _encoding = null;

    private static Encoding DefaultEncoding
    {
      get
      {
        if (_encoding == null)
        {
#if MOBILE
          _encoding = System.Text.Encoding.GetEncoding("US-ASCII");
#else
          _encoding = Encoding.ASCII;
#endif
        }
        return _encoding;
      }
    }
    public static byte[] ToBytes(string str)
    {
      return DefaultEncoding.GetBytes(str);
    } 

    public static string FromBytes(byte[] buff)
    {
#if MOBILE
      return DefaultEncoding.GetString(buff, 0, buff.Length);
#else
      return DefaultEncoding.GetString(buff);
#endif
    }

    public static string NormalizeDebugString(string text)
    {
      return text?.Replace(" \b", "");
    }

    public static WritePwdAnswer DeserializePwdAnswer(string str)
    {
      WritePwdAnswer retVal = new WritePwdAnswer();
      str = str.Trim().Trim(Return);
      string[] keyValue = str.Split(new[] { Sep }, StringSplitOptions.RemoveEmptyEntries);
      if (keyValue.Length == 2)
      {
        if (keyValue[0] == Password)
          retVal.PwdResult = keyValue[1];
      }
      else
      {
        throw new FormatException("Строка имеет не верный формат");
      }
      return retVal;
    }

    public static WritePwdAnswer DeserializeVersionAnswer(string str)
    {
      WritePwdAnswer retVal = new WritePwdAnswer();
      str = str.Trim().Trim(Return);
      str = str.Remove(0, 8);
      string[] keyValue = str.Split(new[] { Sep }, StringSplitOptions.RemoveEmptyEntries);
      if (keyValue.Length == 2)
      {
        if (keyValue[0] == "VERSION")
          retVal.PwdResult = keyValue[1].Trim();
      }
      else
      {
        throw new FormatException("Строка имеет неверный формат");
      }
      return retVal;
    }

    //public static SwitchOnOffAnswer DeserializeSwitchOnOffAnswer(string str)
    //{
    //  SwitchOnOffAnswer retVal = new SwitchOnOffAnswer();
    //  str = str.Trim().Trim(Return);
    //  string[] parts = str.Split(new[] { WhiteSpace }, StringSplitOptions.RemoveEmptyEntries);
    //  foreach (string part in parts)
    //  {
    //    string[] keyValue = part.Split(new[] { Sep }, StringSplitOptions.RemoveEmptyEntries);
    //    if (keyValue.Length != 2)
    //      continue;
    //    string key = keyValue[0];
    //    string value = keyValue[1];
    //    switch (key)
    //    {
    //      case Password:
    //        retVal.PwdResult = value;
    //        break;
    //      case Light:
    //        retVal.SwitchOn = Convert.ToBoolean(Convert.ToInt32(value));
    //        break;
    //    }
    //  }
    //  return retVal;
    //}

    public static ZtpConfig DeserializeZtpConfig(string str)
    {
      ZtpConfig zc = new ZtpConfig();
      //могут быть не указаны в строке
      zc.EstPort = 10000;
      zc.EstTsend = 50;
      //=====================
      str = str.Trim().Trim(Return);
      string prefix = $"{Config}:";
      if (!str.StartsWith(prefix))
        throw new FormatException("Строка имеет не верный формат");
      str = str.Remove(0, prefix.Length);
      string[] parts = str.Split(new[] { WhiteSpace }, StringSplitOptions.RemoveEmptyEntries);
      foreach (string part in parts)
      {
        string[] keyValue = part.Split(new[] { Sep }, StringSplitOptions.RemoveEmptyEntries);
        if (keyValue.Length != 2)
        {
          if(keyValue[0].CompareTo("TMSET") == 0)
          {
            if (keyValue.Length != 1)
            {
              keyValue[1] += ":" + keyValue[2];
            }
          }
          else
            continue;
        }
          

        string key = keyValue[0];
        string value = (keyValue.Length == 1)?"": keyValue[1];
        try
        {
          switch (key)
          {
            case "VER":
              zc.Version = value;
              break;
            case "APN":
              zc.Apn = value;
              break;
            case "USER":
              zc.ApnUser = value;
              break;
            case "PASS":
              zc.ApnPassword = value;
              break;
            case "DT":
              zc.DateTime = Utils.DateTimeUtils.ToDateTime(Convert.ToUInt32(value));
              break;
            case "DEBOUNCE":
              zc.Debounce = Convert.ToUInt32(value);
              break;
            case "DEBUG":
              zc.Debug = Convert.ToBoolean(Convert.ToInt32(value));
              break;
            case "EST":
              zc.EstActive = Convert.ToBoolean(Convert.ToInt32(value));
              break;
            case "IP":
              zc.EstAddress = value;
              break;
            case "TCP":
              zc.EstPort = Convert.ToUInt16(value);
              break;
            case "TSEND":
              zc.EstTsend = Convert.ToUInt32(value);
              break;
            case "DBZ":
              zc.DbzPercent = Convert.ToByte(value);
              break;
            case "AIN":
              zc.Ain = Bit.ReDim(Bit.ToBitArray(Convert.ToByte(value)), 4);
              break;
            case "DIN":
              zc.Din = Bit.ToBitArray(Convert.ToUInt16(value));
              break;
            case "DOUT":
              zc.Dout = Bit.ToBitArray(Convert.ToByte(value));
              break;
            case "DOOR":
              zc.Door = Bit.ToBitArray(Convert.ToUInt16(value));
              break;
            case "LATIT":
              zc.Latitude = float.Parse(value, CultureInfo.InvariantCulture);
              break;
            case "LONGIT":
              zc.Longitude = float.Parse(value, CultureInfo.InvariantCulture);
              break;
            case "TZ":
              zc.TimeZone = Convert.ToSByte(value);
              break;
            case "CDIN":
              zc.Cdin = Bit.ToBitArray(Convert.ToUInt16(value));
              break;
            case "CDOUT":
              zc.Cdout = Bit.ToBitArray(Convert.ToByte(value));
              break;
            case "CAIN":
              string[] values = value.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
              if (values.Length != 4)
                throw new FormatException("Строка имеет не верный формат");
              ushort[] a = new ushort[4];
              for (int i = 0; i < a.Length; i++)
                a[i] = ushort.Parse(values[i]);
              zc.Cain = a;
              break;
            case "SRISE":
              zc.Sunrise = Utils.DateTimeUtils.ToDateTime(Convert.ToUInt32(value));
              break;
            case "SSET":
              zc.Sunset = Utils.DateTimeUtils.ToDateTime(Convert.ToUInt32(value));
              break;
            case "SIM":
              zc.Sim = UInt32.Parse(value);
              break;
            case "GSM":
              zc.Gsm = UInt32.Parse(value);
              break;
            case "GPRS":
              zc.Gprs = UInt32.Parse(value);
              break;
            case "SIGNAL":
              int s = Int32.Parse(value);
              int sign = s < 0 ? s : -113 + s*2;
              zc.Signal = sign;//Int32.Parse(value);
              break;
            case "IPOWN":
              zc.IpOwn = value;
              break;
            case "RAS":
              zc.Light.UseScheduler = Convert.ToBoolean(Convert.ToInt32(value));
              break;
            case "SCHED":
              try
              {
                byte[] ba = Convert.FromBase64String(value);
                zc.Light.Scheduler = ZtpScheduler.Deserialize(ba);
              }
              catch (Exception e)
              {
                throw new FormatException($"Ошибка десериализации плана освещения. {e.Message}");
              }
              break;
            case "SERIAL":
              zc.ComPortSetting = DeserializeComPortSetting(value);
              break;
            case "NUM":
              zc.Number = int.Parse(value);
              break;
            case "SVERS":
              zc.SoftVersion = value;
              break;
            case "TECHN":
              zc.NetTechnology = value;
              break;
            case "FMW":
              zc.DateTimeFirmware = Utils.DateTimeUtils.ToDateTime(Convert.ToUInt32(value));
              break;
            case "TMSET":
              if (!string.IsNullOrEmpty(value) && value[2] != ':')
                value = "00:00";
              zc.rebootTime = value;
              break;
            case "IPP":
              //if (!string.IsNullOrEmpty(value))
                zc.IpPing = value;
              break;
            case "PERP":
              zc.PingPeriod = byte.Parse(value);
              break;
            case "IMEI":
              zc.Imei = value;
              break;
            case "LOGSLVL":
              zc.logLevel = byte.Parse(value);
              break;
            case "BRG":
              zc.IsHalfBright = byte.Parse(value) == 1;
              break;
            case "CORV":
              zc.CoreVersion = value;
              break;
            case "TRAFC":
              zc.CurTrafic = UInt32.Parse(value);
              break;
          }
        }
        catch (Exception ex)
        {
          throw new Exception($"Ошибка разбора значения по ключу '{key}'. {ex.Message}");
        }
      }
      return zc;
    }

    
    public static string SerializeZtpConfig(ZtpConfig zc)
    {
      StringBuilder sb = new StringBuilder();
      if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.All))
      {
        sb.Append($"APN{Sep}{StringUtils.TrimStringLength(zc.Apn, MaxStringLength)}{WhiteSpace}");
        sb.Append($"USER{Sep}{StringUtils.TrimStringLength(zc.ApnUser, MaxStringLength)}{WhiteSpace}");
        sb.Append($"PASS{Sep}{StringUtils.TrimStringLength(zc.ApnPassword, MaxStringLength)}{WhiteSpace}");
        sb.Append($"DT{Sep}{Utils.DateTimeUtils.ToUInt32(DateTime.Now)}{WhiteSpace}");
      }
      if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.Debounce))
        sb.Append($"DEBOUNCE{Sep}{zc.Debounce}{WhiteSpace}");
      if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.Debug))
        sb.Append($"DEBUG{Sep}{Convert.ToInt32(zc.Debug)}{WhiteSpace}");
      if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.EstActive))
        sb.Append($"EST{Sep}{Convert.ToInt32(zc.EstActive)}{WhiteSpace}");
      if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.All))
      {
        if (zc.EstActive)
        {
          sb.Append($"IP{Sep}{zc.EstAddress}{WhiteSpace}");
          sb.Append($"TCP{Sep}{zc.EstPort}{WhiteSpace}");
          sb.Append($"TSEND{Sep}{zc.EstTsend}{WhiteSpace}");
        }
      } else if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.EstParams) || zc.Flags.HasFlag(ZtpConfig.ConfigFlag.UseIec))
      {
        sb.Append($"IP{Sep}{zc.EstAddress}{WhiteSpace}");
        sb.Append($"TCP{Sep}{zc.EstPort}{WhiteSpace}");
        sb.Append($"TSEND{Sep}{zc.EstTsend}{WhiteSpace}");
      }
      if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.DbzPercent))
        sb.Append($"DBZ{Sep}{zc.DbzPercent}{WhiteSpace}");
      if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.Ain))
        sb.Append($"AIN{Sep}{Bit.ToByte(Bit.ReDim(zc.Ain, 8))}{WhiteSpace}");
      if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.Din))
        sb.Append($"DIN{Sep}{Bit.ToUshort(zc.Din)}{WhiteSpace}");
      if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.Dout))
        sb.Append($"DOUT{Sep}{Bit.ToByte(zc.Dout)}{WhiteSpace}");
      if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.Door))
        sb.Append($"DOOR{Sep}{Bit.ToUshort(zc.Door)}{WhiteSpace}");
      //if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.Logs))
      //  sb.Append($"LOGS{Sep}{zc.logLevel}{WhiteSpace}");
      if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.Location))
      {
        sb.Append($"LATIT{Sep}{zc.Latitude.ToString(CultureInfo.InvariantCulture)}{WhiteSpace}");
        sb.Append($"LONGIT{Sep}{zc.Longitude.ToString(CultureInfo.InvariantCulture)}{WhiteSpace}");
        sb.Append($"TZ{Sep}{zc.TimeZone}{WhiteSpace}");
      }
      if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.All))
        sb.Append($"NUM{Sep}{zc.Number}{WhiteSpace}");
      if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.Rs485))
        sb.Append($"SERIAL{Sep}{SerializeComPortSetting(zc.ComPortSetting)}{WhiteSpace}");
      

      bool needTMSET = false;
      bool needPing = false;
      bool needLogs = true;
      //это для ztpManager (он не считывает инфу перед отправкой, поэтому надо где-то ее еще хранить или добавлять в объект) 
      if (zc.Version.Equals("I1O1A1-LDC-3"))
        needTMSET = true;

      if(zc.Version.Equals("I16O2A2-LDC-3-FOTA") || zc.Version.Equals("I16O2A2-LDC-3-FOTA-BT"))
      {
        if (zc.SoftVersion.CompareTo("1.1.18") >= 0)
          needTMSET = true;
      }
      else if(zc.Version.Equals("I4O1A1-LDC-3-FOTA") || zc.Version.Equals("I4O1A1-LDC-3-FOTA-DM"))
      {
        if (zc.SoftVersion.CompareTo("1.0.3") >= 0)
          needTMSET = true;

        if (zc.SoftVersion.CompareTo("1.7.0") >= 0)
          needPing = true;

        if (zc.SoftVersion.CompareTo("1.7.7") >= 0)
          needLogs = true;
      }
      else if(zc.Version.Equals("I8O2A2-LEM-4-FOTA-prIM"))
      {
        needTMSET = true;
        needPing = true;
        needLogs = true;
      }
      if(needTMSET && zc.Flags.HasFlag(ZtpConfig.ConfigFlag.PlanReboot))
        sb.Append($"TMSET{Sep}{zc.rebootTime}{WhiteSpace}");

      if(needPing && zc.Flags.HasFlag(ZtpConfig.ConfigFlag.Ping))
      {
        sb.Append($"IPP{Sep}{zc.IpPing}{WhiteSpace}");
        sb.Append($"PERP{Sep}{zc.PingPeriod}{WhiteSpace}");
      }
      if(needLogs && zc.Flags.HasFlag(ZtpConfig.ConfigFlag.Logs))
      {
        sb.Append($"LOGSLVL{Sep}{zc.logLevel}{WhiteSpace}");
      }

      if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.UseScheduler))
        sb.Append($"RAS{Sep}{Convert.ToInt32(zc.Light.UseScheduler)}{WhiteSpace}");
      if (zc.Flags.HasFlag(ZtpConfig.ConfigFlag.Scheduler) && zc.Light.Scheduler != null)
        sb.Append($"SCHED{Sep}{zc.Light.Scheduler.ToBase64String()}{WhiteSpace}");

      sb.Append($"{Return}");
      return sb.ToString();
    }

    static string SerializeComPortSetting(ComPortSettings com)
    {
      const char s = ',';
      StringBuilder sb = new StringBuilder();
      sb.Append($"{com.BaudRate}{s}");
      sb.Append($"{(int)com.DataBits}{s}");
      sb.Append($"{(int)com.Parity}{s}");
      sb.Append($"{(int)com.StopBits}");
      return sb.ToString();
    }

    static ComPortSettings DeserializeComPortSetting(string value)
    {
      ComPortSettings retVal = new ComPortSettings();
      string[] parts = value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
      if (parts.Length != 4)
        throw new FormatException("Строка имеет не верный формат");
      retVal.BaudRate = int.Parse(parts[0]);
      retVal.DataBits = byte.Parse(parts[1]);
      retVal.Parity = (Parity)int.Parse(parts[2]);
      retVal.StopBits = (StopBits)int.Parse(parts[3]);
      return retVal;
    }

    public static string SetLightPlanCommand(string sessionPwd, ZtpScheduler scheduler)
    {
      if (scheduler == null) throw new ArgumentNullException(nameof(scheduler));
      StringBuilder sb = new StringBuilder($"{Config}:");
      sb.Append($"PWD{Sep}{StringUtils.ToBase64String(sessionPwd)}{WhiteSpace}");
      sb.Append($"SCHED{Sep}{scheduler.ToBase64String()}");
      sb.Append($"{Return}");
      return sb.ToString();
    }

    public static string SetUpgradeCommand(string sessionPwd)
    {
      StringBuilder sb = new StringBuilder($"{Upgrade}:");
      sb.Append($"PWD{Sep}{StringUtils.ToBase64String(sessionPwd)}{Return}");
      return sb.ToString();
    }

    public static string DropLogsCommand()
    {
      StringBuilder sb = new StringBuilder($"{DropLogs}");
      sb.Append($"{Return}");
      return sb.ToString();
    }

    public static string StartUpServCommand(string sessionPwd)
    {
      StringBuilder sb = new StringBuilder($"{StartUpServ}:");
      sb.Append($"PWD{Sep}{StringUtils.ToBase64String(sessionPwd)}{Return}");
      return sb.ToString();
    }

    public static string GetCoreVerCmd()
    {
      return $"GETFWVER?{Return}";
    }

    public static string GetVersionCmd()
    {
      return $"VERSION?{Return}";
    }

    public static string SendFilenameCommand(string filename)
    {
      StringBuilder sb = new StringBuilder($"{SendFilename}: ");
      sb.Append($"{filename}{Return}");
      return sb.ToString();
    }

    public static string SetConfigCommand(string sessionPwd, ZtpConfig zc)
    {
      StringBuilder sb = new StringBuilder($"{Config}:");
      sb.Append($"PWD{Sep}{StringUtils.ToBase64String(sessionPwd)}{WhiteSpace}");
      sb.Append(SerializeZtpConfig(zc));
      return sb.ToString();
    }

    public static string SetPasswordCommand(string oldPwd, string newPwd)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append($"{SetPassword}{Sep}{Password}{Sep}{StringUtils.ToBase64String(oldPwd)}{WhiteSpace}");
      sb.Append($"NEW{Sep}{StringUtils.ToBase64String(newPwd)}{Return}");
      return sb.ToString();
    }

    public static string GetConfigCommand()
    {
      return $"{Config}?" + Return;
    }

    public static string RebootCommand(string sessionPwd)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append($"PWD{Sep}{StringUtils.ToBase64String(sessionPwd)}{WhiteSpace}");
      sb.Append($"REBOOT{Return}");
      return sb.ToString();
    }

    public static string LightSwitchOnOffCommand(string sessionPwd, bool switchOn)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append($"PWD{Sep}{StringUtils.ToBase64String(sessionPwd)}{WhiteSpace}");
      sb.Append($"{Light}{Sep}{Convert.ToInt32(switchOn)}{Return}");
      return sb.ToString();
    }

    public static string CheckPingIp(string ip)
    {
      return $"{TestPingIp}{Sep}{ip}{Return}";
    }

    public static string GetCurTrafic()
    {
      return $"{GetTraf}0{Return}";
    }
    /// <summary>
    /// Упаковка пакета настройки модбас заголовком с паролем
    /// </summary>
    /// <param name="sessionPwd">Сессионый пароль</param>
    /// <param name="dat">Пакет модбас</param>
    /// <param name="size">Длина пакета модбас</param>
    /// <returns>укомплектованный пакет</returns>
    public static byte[] ModbusSetConfig(string sessionPwd, byte[] dat, ushort size)
    {
      /*byte[] a = new byte[size];
      Array.Copy(dat, a, size-1);
      string b = Convert.ToBase64String(a);*/
      StringBuilder sb = new StringBuilder($"{MBConfig}:");
      sb.Append($"PWD{Sep}{StringUtils.ToBase64String(sessionPwd)}{WhiteSpace}");
      sb.Append($"{MBStartPack}{Sep}");
      //sb.Append($"{b}{Return}");
      byte[] val = ToBytes(sb.ToString());
      int prev_size = val.Length;
      Array.Resize(ref val, prev_size + size);
      Array.Copy(dat,0, val,prev_size, size);
      return  val;
    }

    /// <summary>
    /// Формирование запроса конфига модбас
    /// </summary>
    /// <returns>строка запроса</returns>
    public static string GetModbusConfig()
    {
      return $"{MBConfig}?" + Return;
    }

    /// <summary>
    /// Формирование пакета с метками для тегов модбас
    /// </summary>
    /// <param name="sessionPwd">сессионный пароль</param>
    /// <param name="input">строка в base64 заархивированная Gzip</param>
    /// <returns>готовая команда на отправку</returns>
    public static string ModbusSetLBL(string sessionPwd, string input)
    {
      StringBuilder sb = new StringBuilder($"{MBLbl}:");
      sb.Append($"PWD{Sep}{StringUtils.ToBase64String(sessionPwd)}{WhiteSpace}");
      sb.Append($"{MBstartLbl}{Sep}{input}{Return}");
      return sb.ToString();
    }

    public static string ModbusGetLBL()
    {
      return $"{MBLbl}?" + Return;
    }

    public static string BrightToggle()
    {
      return $"{ToggleBrightCmd}!" + Return;
    }

  }
}
