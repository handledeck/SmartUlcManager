using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Port.ComPort;

namespace Ztp.Ui
{
  public partial class ComPortSettingsEditorControl : UserControl
  {
    public ComPortSettingsEditorControl()
    {
      InitializeComponent();

      FillPortNames();
      FillBaudrates();
      FillDataBits();
      FillParity();
      FillHandshake();
      FillStopBits();
    }

    public bool EnabledBaudrates
    {
      get { return cbBaudrates.Enabled; }
      set { cbBaudrates.Enabled = value; }
    }

    public bool EnabledDataBits
    {
      get { return cbDataBits.Enabled; }
      set { cbDataBits.Enabled = value; }
    }

    public bool EnabledParity
    {
      get { return cbParity.Enabled; }
      set { cbParity.Enabled = value; }
    }

    public bool EnabledHandshake
    {
      get { return cbHandshake.Enabled; }
      set { cbHandshake.Enabled = value; }
    }

    public bool EnabledStopBits
    {
      get { return cbStopBits.Enabled; }
      set { cbStopBits.Enabled = value; }
    }

    public bool EnabledPortName
    {
      get { return cbPortName.Enabled; }
      set { cbPortName.Enabled = value; }
    }

    private ComPortSettings _value = new ComPortSettings();

    public ComPortSettings Value
    {
      get
      {
        _value = CollectComPortSettings();
        return _value;
      }
      set
      {
        if(value == null)
          return;
        _value = value;
        Assign();
      }
    }

    ComPortSettings CollectComPortSettings()
    {
      ComPortSettings retVal = _value;
      if(retVal == null)
        retVal = new ComPortSettings();
      retVal.StopBits =  ((ComboboxItem<StopBits>) cbStopBits.SelectedItem)?.Value ?? StopBits.One;
      retVal.Handshake = ((ComboboxItem<Handshake>)cbHandshake.SelectedItem)?.Value ?? Handshake.None;
      retVal.Parity = ((ComboboxItem<Parity>)cbParity.SelectedItem)?.Value ?? Parity.None;
      retVal.PortName = (string) cbPortName.SelectedItem;
      retVal.BaudRate = cbBaudrates.SelectedItem != null ? Convert.ToInt32(cbBaudrates.SelectedItem) : 9600;
      retVal.DataBits = cbDataBits.SelectedItem != null ? Convert.ToByte(cbDataBits.SelectedItem): (byte)8;
      retVal.Timeout = Convert.ToInt32(nudTimeout.Value);
      return retVal;
    }

    void Assign()
    {
      if(_value == null)
        return;
      try
      {
        nudTimeout.Value = _value.Timeout;
        if (cbStopBits.Items.Count > 0)
        {
          ComboboxItem<StopBits> itemSb = new ComboboxItem<StopBits>(_value.StopBits);
          if (cbStopBits.Items.Contains(itemSb))
            cbStopBits.SelectedItem = itemSb;
          else
            cbStopBits.SelectedIndex = 0;
        }
        if (cbHandshake.Items.Count > 0)
        {
          ComboboxItem<Handshake> itemH = new ComboboxItem<Handshake>(_value.Handshake);
          if (cbHandshake.Items.Contains(itemH))
            cbHandshake.SelectedItem = itemH;
          else
            cbHandshake.SelectedIndex = 0;
        }
        if (cbParity.Items.Count > 0)
        {
          ComboboxItem<Parity> itemP = new ComboboxItem<Parity>(_value.Parity);
          if (cbParity.Items.Contains(itemP))
            cbParity.SelectedItem = itemP;
          else
            cbParity.SelectedIndex = 0;
        }
        if (cbDataBits.Items.Count > 0)
        {
          if (ComPortSettings.Databits.Contains(_value.DataBits))
            cbDataBits.SelectedItem = _value.DataBits.ToString();
          else
            cbBaudrates.SelectedIndex = 0;
        }
        string[] names = ComPortUtils.GetPortNames();
        if (cbPortName.Items.Count > 0)
        {
          if (names?.FirstOrDefault((s) => s == _value.PortName) != null)
            cbPortName.SelectedItem = _value.PortName;
          else
            cbPortName.SelectedIndex = 0;
        }
        if (cbBaudrates.Items.Count > 0)
        {
          if (ComPortSettings.Baudrates.Contains(_value.BaudRate))
            cbBaudrates.SelectedItem = _value.BaudRate.ToString();
          else
            cbBaudrates.SelectedIndex = 0;
        }
      }
      catch (Exception)
      {
        
      }
    }

    public void SetCom(string com)
    {
      if(cbPortName.Items.IndexOf(com) >= 0)
        cbPortName.SelectedIndex = cbPortName.Items.IndexOf(com);
    }

    const int RowHeight = 26;
    public bool ShowPortName
    {
      get { return tableLayoutPanel1.RowStyles[0].Height > 0; }
      set {
        tableLayoutPanel1.RowStyles[0].Height = value ? RowHeight : 0;
        label7.Visible = cbPortName.Visible = value;
      }
    }

    public bool ShowHandshake
    {
      get { return tableLayoutPanel1.RowStyles[4].Height > 0; }
      set
      {
        tableLayoutPanel1.RowStyles[4].Height = value ? RowHeight : 0;
        label5.Visible = cbHandshake.Visible = value;
      }
    }

    public bool ShowTimeout
    {
      get { return tableLayoutPanel1.RowStyles[6].Height > 0; }
      set
      {
        tableLayoutPanel1.RowStyles[6].Height = value ? RowHeight : 0;
        label1.Visible = nudTimeout.Visible = value;
      }
    }

    void FillStopBits()
    {
      ComboboxItem<StopBits>[] items = new List<StopBits>((StopBits[])Enum.GetValues(typeof(StopBits))).Select((p) => new ComboboxItem<StopBits>(p)).ToArray();
      // ReSharper disable once CoVariantArrayConversion
      cbStopBits.Items.AddRange(items);
    }

    void FillHandshake()
    {
      ComboboxItem<Handshake>[] items = new List<Handshake>((Handshake[])Enum.GetValues(typeof(Handshake))).Select((p) => new ComboboxItem<Handshake>(p)).ToArray();
      // ReSharper disable once CoVariantArrayConversion
      cbHandshake.Items.AddRange(items);
    }

    void FillParity()
    {
      ComboboxItem<Parity>[] items = new List<Parity>((Parity[])Enum.GetValues(typeof(Parity))).Select((p) => new ComboboxItem<Parity>(p)).ToArray();
      // ReSharper disable once CoVariantArrayConversion
      cbParity.Items.AddRange(items);
    }

    void FillDataBits()
    {
      string[] items = ComPortSettings.Databits.Select((i) => i.ToString()).ToArray();
      // ReSharper disable once CoVariantArrayConversion
      cbDataBits.Items.AddRange(items);
    }

    void FillPortNames()
    {
      string[] names = ComPortUtils.GetPortNames();
      // ReSharper disable once CoVariantArrayConversion
      cbPortName.Items.AddRange(names);
    }

    void FillBaudrates()
    {
      string[] items = ComPortSettings.Baudrates.Select((i) => i.ToString()).ToArray();
      // ReSharper disable once CoVariantArrayConversion
      cbBaudrates.Items.AddRange(items);
    }

  }
}
