using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Ztp.Port.ComPort;
using Ztp.Protocol;
using Ztp.Utils;

namespace Ztp.Configuration
{
  public class ZtpConfig
  {
    /// <summary>
    /// Флаги для порционирования информации при записи с ZtpManager
    /// </summary>
    [Flags]
    public enum ConfigFlag
    {
      None = 0,
      Din = 1,
      Dout = 2,
      Ain = 4,
      UseScheduler = 8,
      EstActive = 16,
      EstParams = 32,
      DbzPercent = 64,
      Debug = 128,
      Debounce = 256,
      Location = 512,
      Scheduler = 1024,
      Rs485 = 2048,
      Door = 4096,
      PlanReboot = 8192,
      UseIec = 16384,
      ComType = 32768,
      Ping = 65536,
      Logs = 131072,
      All = Din | Dout | Ain | UseScheduler | EstActive | EstParams | DbzPercent | Debug | Debounce | Door | Location | Scheduler | Rs485 | PlanReboot | UseIec | ComType | Ping | Logs
    }

    static readonly DateTime _minDateTime = new DateTime(1753, 1, 1);
    private DateTime _dateTime;

    public ZtpConfig()
    {
      _dateTime = DateTime.Now;
    }

    public const string ZtpConfigFileExtantion = ".ztpcfg";

    public string Apn { get; set; }
    public string ApnUser { get; set; }
    public string ApnPassword { get; set; }
    public bool EstActive { get; set; }
    public string EstAddress { get; set; }
    public ushort EstPort { get; set; }
    public uint EstTsend { get; set; }
    public bool Debug { get; set; }
    public sbyte TimeZone { get; set; }
    private byte _dbzPercent = 1;
    public byte DbzPercent
    {
      get { return _dbzPercent; }
      set
      {
        if (value < 1 || value > 5)
          return;
        _dbzPercent = value;
      }
    }
    public int Number { get; set; }

    [XmlIgnore()]
    public string Imei { get; set; } = string.Empty;

    [XmlIgnore]
    public bool IsHalfBright { get; set; } = false;

    /// <summary>
    /// Время для планового перезапуска устройства
    /// </summary>
    public string rebootTime { get; set; } = "";

    /// <summary>
    /// Версия конфигурации периферии устройства
    /// </summary>
    private string _version = "I1O1A1-LDC-3";

    [XmlIgnore()]
    public ConfigFlag Flags { get; set; } = ConfigFlag.All;
    
    
    [XmlIgnore()]
    public string Version
    {
      get { return _version; }
      set
      {
        if (!string.IsNullOrEmpty(value))
          _version = value;
      }
    }

    /// <summary>
    /// Версия прошивки устройства
    /// </summary>
    private string _soft_version = "";
    [XmlIgnore()]
    public string SoftVersion
    {
      get { return _soft_version; }
      set
      {
        if (!string.IsNullOrEmpty(value))
          _soft_version = value;
      }
    }

    /// <summary>
    /// Вывод поколения технологии связи (2G/3G)
    /// </summary>
    private string _netTechnology = "";
    [XmlIgnore()]
    public string NetTechnology
    {
      get { return _netTechnology; }
      set
      {
        if (!string.IsNullOrEmpty(value))
          _netTechnology = value;
      }
    }

    public string IpPing { get; set; } = "";

    public byte PingPeriod { get; set; } = 1;

    public byte logLevel { get; set; }
   
    [XmlIgnore()]
    public string CoreVersion { get; set; } = "";

    [XmlIgnore()]
    public UInt32 CurTrafic { get; set; } = 0;

    /// <summary>
    /// Время компиляции прошивки устройства
    /// </summary>
    private DateTime _dateTimeFirmware = DateTime.MinValue;
    [XmlIgnore()]
    public DateTime DateTimeFirmware
    {
      get { return _dateTimeFirmware; }
      set
      {
        if (value > DateTime.MinValue)
          _dateTimeFirmware = value;
      }
    }

    public DateTime dateTime
    {
      get
      {
        return _dateTime;
      }
      set
      {
        if (value < _minDateTime)
          value = _minDateTime;
        _dateTime = value;
      }
    }

    public void SetSwitchOnOff(bool switchOn)
    {
      Cdout[0] = switchOn;
      Cdout[1] = false;
    }

    [XmlIgnore()]
    public bool IsSwitchOn
    {
      get { return Cdout[0] || Cdout[1]; }
    }

    [XmlIgnore()]
    public bool IsReadedFromDevice { get; set; }

    [XmlIgnore()]
    public DateTime DateTime
    {
      get
      {
        return _dateTime;
      }
      set
      {
        if (value < _minDateTime)
          value = _minDateTime;
        _dateTime = value;
      }
    }

    /// <summary>
    /// Дребезг контактов (длительность)
    /// </summary>
    public uint Debounce { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }

    private bool[] _din;
    public bool[] Din
    {
      get
      {
        if (_din == null)
          _din = new bool[16];
        return _din;
      }
      set { _din = value; }
    }

    private bool[] _dout;

    public bool[] Dout
    {
      get
      {
        if (_dout == null)
          _dout = new bool[8];
        return _dout;
      }
      set { _dout = value; }

    }

    private bool[] _ain;

    public bool[] Ain
    {
      get
      {
        if (_ain == null)
          _ain = new bool[4];
        return _ain;
      }
      set { _ain = value; }
    }

    private bool[] _door;
    private ushort[] _cain;
    private bool[] _cdout;
    private bool[] _cdin;

    public bool[] Door
    {
      get
      {
        if (_door == null)
          _door = new bool[16];
        return _door;
      }
      set { _door = value; }
    }

    [XmlIgnore()]
    public ushort[] Cain
    {
      get
      {
        if (_cain == null)
          _cain = new ushort[4];
        return _cain;
      }
      set { _cain = value; }
    }

    [XmlIgnore()]
    public bool[] Cdout
    {
      get
      {
        if (_cdout == null)
          _cdout = new bool[8];
        return _cdout;
      }
      set { _cdout = value; }
    }

    [XmlIgnore()]
    public bool[] Cdin
    {
      get
      {
        if (_cdin == null)
          _cdin = new bool[16];
        return _cdin;
      }
      set { _cdin = value; }
    }

#if !MOBILE
    public ComPortSettings ComPortSetting { get; set; } = new ComPortSettings("COM1", 9600, Parity.None, 8, StopBits.One, Handshake.None);
#else
    public ComPortSettings ComPortSetting { get; set; } = new ComPortSettings();
#endif

    public ZtpLight Light { get; set; } = new ZtpLight(){Scheduler = ZtpScheduler.GetDefault() };
    //public bool UseScheduler { get; set; }

    //public ZtpScheduler Scheduler { get; set; } = ZtpScheduler.GetDefault();

    [XmlIgnore()]
    public DateTime Sunrise { get; set; }
    [XmlIgnore()]
    public DateTime Sunset { get; set; }
    public uint Sim { get; set; }
    [XmlIgnore()]
    public uint Gsm { get; set; }
    [XmlIgnore()]
    public uint Gprs { get; set; }
    [XmlIgnore()]
    public int Signal { get; set; }
    [XmlIgnore()]
    public string IpOwn { get; set; }

    public static ZtpConfig GetDefault()
    {
      ZtpConfig zc = new ZtpConfig()
      {
        DateTime = DateTime.Now,
        Apn = "vpn2.mts.by",
        ApnPassword = "",
        ApnUser = "vpn",
        Debounce = 500,
        Debug = false,
        Ain = CreateBoolArray(4, true),
        Din = CreateBoolArray(16, true),
        Dout = CreateBoolArray(8, true),
        Door = CreateBoolArray(16, true),
        Cain = new ushort[4],
        Cdin = CreateBoolArray(16, false),
        Cdout = CreateBoolArray(8, false),
        DbzPercent = 1,
        EstActive = false,
        EstAddress = "127.0.0.1",
        EstPort = 10000,
        EstTsend = 50,
        Gprs = 0,
        Gsm = 0,
        Latitude = 55.191F,
        Longitude = 30.125F,
        Signal = 0,
        Sim = 0,
        Sunrise = new DateTime(1, 1, 1, 0, 0, 0),
        Sunset = new DateTime(1, 1, 1, 0, 0, 0),
        TimeZone = 3,
        IpOwn = "",
        Number = 1,
        rebootTime = "",
        logLevel = 5
       
      };
      return zc;
    }

    static bool[] CreateBoolArray(int length, bool value)
    {
      bool[] retVal = new bool[length];
      for (int i = 0; i < length; i++)
      {
        retVal[i] = value;
      }
      return retVal;
    }

#if !MOBILE
    public static void SaveToFile(string path, ZtpConfig zc)
    {
      if (zc == null) throw new ArgumentNullException(nameof(zc));
      if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
      XmlSerializer serializer = new XmlSerializer(typeof(ZtpConfig));
      using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      {
        serializer.Serialize(fs, zc);
      }
    }

    public static ZtpConfig LoadFromFile(string path)
    {
      if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));
      XmlSerializer serializer = new XmlSerializer(typeof(ZtpConfig));
      using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
      {
        return (ZtpConfig)serializer.Deserialize(fs);
      }
    }
#endif

    public override string ToString()
    {
      return ZtpProtocol.SerializeZtpConfig(this);
    }

    //XXX подправить бы и под ULC02
    public string ToText()
    {
      StringBuilder sb = new StringBuilder();
      if (Flags.HasFlag(ConfigFlag.All))
      {
        sb.Append($"APN адрес: {Apn}, ");
        sb.Append($"APN пользователь: {ApnUser}, ");
        sb.Append($"APN пароль: {ApnPassword}, ");
        sb.Append($"Номер прибора: {Number}, ");
      }
      if (Flags.HasFlag(ConfigFlag.Din))
        sb.Append($"Активность дискретных входов: [{StringUtils.BoolArrayToString(Din)}], ");
      if (Flags.HasFlag(ConfigFlag.Dout))
        sb.Append($"Активность дискретных выходов: [{StringUtils.BoolArrayToString(Dout)}], ");
      if (Flags.HasFlag(ConfigFlag.Ain))
        sb.Append($"Активность аналоговых входов: [{StringUtils.BoolArrayToString(Ain)}], ");
      if (Flags.HasFlag(ConfigFlag.Door))
        sb.Append($"Активность контроля дверей: [{StringUtils.BoolArrayToString(Door)}], ");
      if (Flags.HasFlag(ConfigFlag.UseScheduler))
        sb.Append($"Активность планов освещения: {Convert.ToByte(Light.UseScheduler)}, ");
      if (Flags.HasFlag(ConfigFlag.EstActive))
        sb.Append($"Использовать EST Tools: {EstActive}, ");
      if (Flags.HasFlag(ConfigFlag.EstParams))
      {
        sb.Append($"Адрес EST Tools: {EstAddress}, ");
        sb.Append($"Порт EST Tools: {EstPort}, ");
        sb.Append($"Интервал отправки пакета в EST Tools (сек): {EstTsend}, ");
      }
      if (Flags.HasFlag(ConfigFlag.DbzPercent))
        sb.Append($"Зона нечувствительности аналоговых входов (%): {DbzPercent}, ");
      if (Flags.HasFlag(ConfigFlag.Debounce))
        sb.Append($"Интервал дребезга (мсек): {Debounce}, ");
      if (Flags.HasFlag(ConfigFlag.Debug))
        sb.Append($"Отладка: {Debug}, ");
      if (Flags.HasFlag(ConfigFlag.Location))
      {
        sb.Append($"Широта: {Latitude}, ");
        sb.Append($"Долгота: {Longitude}, ");
        sb.Append($"Часовой пояс: {TimeZone}, ");
      }
      if (Flags.HasFlag(ConfigFlag.Scheduler))
        sb.Append($"План освещения: [{(Light.Scheduler == null ? "нет" : Light.Scheduler.ToText())}], ");
      if (Flags.HasFlag(ConfigFlag.Rs485))
        sb.Append($"RS485: [{(ComPortSetting == null ? "нет" : ComPortSetting.ToText())}] ");
      if (Flags.HasFlag(ConfigFlag.Logs))
        sb.Append($"LOG: [{(ComPortSetting == null ? "нет" : ComPortSetting.ToText())}] ");
      return sb.ToString();
    }


  }
}
