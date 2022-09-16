using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Ztp.Configuration;

namespace Ztp.Ui
{
  public partial class CurrentStateViewControl : UserControl
  {
    public CurrentStateViewControl()
    {
      InitializeComponent();
    }

    public string Caption
    {
      get { return groupBox.Text; }
      set { groupBox.Text = value; }
    }

    private ZtpConfig _value;
    public ZtpConfig Value
    {
      get { return _value; }
      set
      {
        if(value == null)
          return;
        _value = value;
        ZtpVersion version = new ZtpVersion(value.Version);
        VisibleCountAin = version.Ain;
        VisibleCountDin = version.Din;
        VisibleCountDout = version.Dout;
        Assign();
      }
    }

    private int VisibleCountDin
    {
      get { return bitViewDin.VisibleCount; }
      set
      {
        bitViewDin.VisibleCount = value;
        Assign();
      }
    }

    private int VisibleCountDout
    {
      get { return bitViewDout.VisibleCount; }
      set
      {
        bitViewDout.VisibleCount = value;
        Assign();
      }
    }

    public void SetDin(int index, bool value)
    {
      if (index < bitViewDin.Value.Length)
      {
        bitViewDin.Value[index] = value;
        Assign();
      }
    }

    public bool[] DinValue
    {
      get { return bitViewDin.Value; }
      set
      {
        bitViewDin.Value = value;
        Assign();
      }
    }

    public void SetDout(int index, bool value)
    {
      if (index < bitViewDout.Value.Length)
      {
        bitViewDout.Value[index] = value;
        Assign();
      }
    }

    public bool[] DoutValue
    {
      get { return bitViewDout.Value; }
      set
      {
        bitViewDout.Value = value;
        Assign();
      }
    }

    public void SetAin(int index, ushort value)
    {
      if (index < ainView.Value.Length)
      {
        ainView.Value[index] = value;
        Assign();
      }
    }

    public ushort[] AinValue
    {
      get { return ainView.Value; }
      set
      {
        ainView.Value = value;
        Assign();
      }
    }

    private int VisibleCountAin
    {
      get { return ainView.VisibleCount; }
      set
      {
        ainView.VisibleCount = value;
        Assign();
      }
    }

    void Assign()
    {
      richTextBox.Text = "";
      if (_value == null) return;
      StringBuilder sb = new StringBuilder();
      if (!string.IsNullOrEmpty(_value.IpOwn))
        sb.AppendLine($"Адрес     : {_value.IpOwn}");
      bitViewDin.Value = _value.Cdin;
      bitViewDout.Value = _value.Cdout;
      ainView.Value = _value.Cain;
      sb.AppendLine($"Версия    : {_value.Version}");
      sb.AppendLine($"Время     : {_value.dateTime.ToString("dd.MM.yyyy HH:mm:ss")}");
      sb.AppendLine($"Восход    : {_value.Sunrise.ToString("HH:mm:sss")}");
      sb.AppendLine($"Заход     : {_value.Sunset.ToString("HH:mm:sss")}");
      sb.AppendLine($"SIM       : {_value.Sim}");
      sb.AppendLine($"GSM       : {_value.Gsm}");
      sb.AppendLine($"GPRS      : {_value.Gprs}");

      if(_value.SoftVersion.CompareTo("1.7.7") >= 0)
      {
        string res = (_value.Cdin[7] == true)?"в норме":"нет ответа";
        sb.AppendLine($"RS-485    : {res}");
      }
      if (!string.IsNullOrEmpty(_value.NetTechnology))
        sb.AppendLine($"Сеть      : {_value.NetTechnology}");
      sb.AppendLine($"Сигнал    : {_value.Signal} dBm");
      if (!string.IsNullOrEmpty(_value.SoftVersion))
        sb.AppendLine($"Версия ПО : {_value.SoftVersion}");
      if (_value.DateTimeFirmware != DateTime.MinValue)
        sb.AppendLine($"Дата ПО   : {_value.DateTimeFirmware.ToString("dd.MM.yyyy HH:mm:ss")}");
      if (!string.IsNullOrEmpty(_value.Imei))
        sb.AppendLine($"IMEI      : {_value.Imei}");
      if (!string.IsNullOrEmpty(_value.CoreVersion))
      {
        string val = (_value.CoreVersion.Contains("12.01.830-B006")) ? "OK" : "НУЖЕН ПАТЧ";
        sb.AppendLine($"CORE      : {val}");  
      }

      if(_value.SoftVersion.CompareTo("1.7.9") >= 0)
      {
        sb.AppendLine($"TRAFIC    : {_value.CurTrafic} байт");
      }

      richTextBox.Text = sb.ToString();
    }

    public void ChangeTrafic(UInt32 value)
    {
      string val = richTextBox.Text.TrimEnd(new char[] { '\r', '\n' });
      int end = val.LastIndexOf("\n");
        int size = val.Length - end;
      StringBuilder sb = new StringBuilder(val);
      sb.Remove(end, size);
      sb.AppendLine($"\nTRAFIC    : {value} байт");
      richTextBox.Text = sb.ToString();
    }
  }
}
