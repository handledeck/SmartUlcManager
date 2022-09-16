using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace Ztp.Port.ComPort
{
  public class ComPortSettings
#if !MOBILE
    : IPortSetting
#endif
  {
    private int _timeout = 1000;
    public int Timeout
    {
      get { return _timeout; }
      set
      {
        _timeout = value;
      }
    }

#if !MOBILE
    public PortKind Kind
    {
      get { return PortKind.Com; }
      // ReSharper disable once ValueParameterNotUsed
      set { }
    }
#endif
    [XmlIgnore()]
    public static int[] Baudrates = new int[] { 110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 56000, 115200, 128000, 256000 };

    public static byte[] Databits = new byte[] { 5, 6, 7, 8 };
    /// <summary>
    /// Поле для свойства Номер порта от 1
    /// </summary>
    private string _portname = "COM1";

    /// <summary>
    /// Поле для свойства Скорость порта
    /// </summary>
    private int _baudrate = 115200;

    /// <summary>
    /// Поле для свойства Задает бит четности 
    /// </summary>
    private Parity _parity = Parity.None;

    /// <summary>
    /// Поле для свойства Число битов данных. Допустимый диапазон значений этого свойства — от 5 до 8. По умолчанию принимается 8.
    /// </summary>
    private byte _databits = 8;

    /// <summary>
    /// Поле для свойства Задает число стоповых битов в байте
    /// </summary>
    private StopBits _stopbits = StopBits.One;

    /// <summary>
    /// Поле для свойства Задает управление потоком
    /// </summary>
    private Handshake _handshake = Handshake.None;

    /// <summary>
    /// Интернал конструктор
    /// </summary>
    internal ComPortSettings(string portName, int baudRate, Parity parity, byte dataBits, StopBits stopBits, Handshake handshake)
    {
      this.PortName = portName;
      this.BaudRate = baudRate;
      this.Parity = parity;
      this.DataBits = dataBits;
      this.StopBits = stopBits;
      this.Handshake = handshake;

    }

    /// <summary>
    /// Публичный конструктор
    /// </summary>
    public ComPortSettings()
    {
    }

    /// <summary>
    /// Свойство Номер порта от 1
    /// </summary>
    // ReSharper disable once ConvertToAutoProperty
    public string PortName
    {
      get
      {
        return _portname;
      }
      set
      {
        this._portname = value;
      }
    }

    /// <summary>
    /// Свойство Скорость порта
    /// </summary>
    // ReSharper disable once ConvertToAutoProperty
    public int BaudRate
    {
      get
      {
        return _baudrate;
      }
      set
      {
        this._baudrate = value;
      }
    }

    /// <summary>
    /// Свойство Задает бит четности 
    /// </summary>
    // ReSharper disable once ConvertToAutoProperty
    public Parity Parity
    {
      get
      {
        return _parity;
      }
      set
      {
        this._parity = value;
      }
    }

    /// <summary>
    /// Свойство Число битов данных. Допустимый диапазон значений этого свойства — от 5 до 8. По умолчанию принимается 8.
    /// </summary>
    // ReSharper disable once ConvertToAutoProperty
    public byte DataBits
    {
      get
      {
        return _databits;
      }
      set
      {
        this._databits = value;
      }
    }

    /// <summary>
    /// Свойство Задает число стоповых битов в байте
    /// </summary>
    // ReSharper disable once ConvertToAutoProperty
    public StopBits StopBits
    {
      get
      {
        return _stopbits;
      }
      set
      {
        this._stopbits = value;
      }
    }

    /// <summary>
    /// Свойство Задает управление потоком
    /// </summary>
    // ReSharper disable once ConvertToAutoProperty
    public Handshake Handshake
    {
      get
      {
        return _handshake;
      }
      set
      {
        this._handshake = value;
      }
    }

    public ComPortSettings Clone()
    {
      return new ComPortSettings(PortName, BaudRate, Parity, DataBits, StopBits, Handshake);
    }

    public string ToDisplay()
    {
      return PortName;
    }

    public string ToText()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append($"Скорость: {BaudRate}, ");
      sb.Append($"Стоповых бит: {StopBits.GetDescription()}, ");
      sb.Append($"Битность: {DataBits}, ");
      sb.Append($"Четность: {Parity.GetDescription()} ");
      return sb.ToString();
    }
  }
}