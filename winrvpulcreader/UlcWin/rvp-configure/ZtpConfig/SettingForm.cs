using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Ztp;
using Ztp.Port;
using Ztp.Port.ComPort;
using Ztp.Port.TcpPort;
using Ztp.Protocol;
using Ztp.Ui;
using System.IO.Ports;
using System.Threading;

namespace Ztp
{
  public partial class SettingForm : Form
  {
    private readonly SelectPortKindWithSettingsControl _selectPortKindWithSettingsControl;

    
    public SettingForm()
    {
      InitializeComponent();

      _selectPortKindWithSettingsControl = new SelectPortKindWithSettingsControl();
      pnlEditor.Controls.Add(_selectPortKindWithSettingsControl);
      _selectPortKindWithSettingsControl.Dock = DockStyle.Fill;
      _selectPortKindWithSettingsControl.ValueComPortSettings = new ComPortSettings();
      _selectPortKindWithSettingsControl.ValueTcpPortSettings = new TcpPortSettings();
      _selectPortKindWithSettingsControl.ValuePortKind = PortKind.Com;

      _selectPortKindWithSettingsControl.EnabledComBaudrates = false;
      _selectPortKindWithSettingsControl.EnabledComDataBits = false;
      _selectPortKindWithSettingsControl.EnabledComHandshake = false;
      _selectPortKindWithSettingsControl.EnabledComParity = false;
      _selectPortKindWithSettingsControl.EnabledComStopBits = false;

      
    }

    public PortKind ValuePortKind
    {
      get { return _selectPortKindWithSettingsControl.ValuePortKind; }
      set { _selectPortKindWithSettingsControl.ValuePortKind = value; }
    }

    public TcpPortSettings ValueTcpPortSettings
    {
      get { return _selectPortKindWithSettingsControl.ValueTcpPortSettings; }
      set { _selectPortKindWithSettingsControl.ValueTcpPortSettings = value; }
    }

    public ComPortSettings ValueComPortSettings
    {
      get { return _selectPortKindWithSettingsControl.ValueComPortSettings; }
      set { _selectPortKindWithSettingsControl.ValueComPortSettings = value; }
    }

    private void btnAction_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }

    //private string ReadResp()
    //{
    //  string output = "";
    //  Thread.Sleep(50);
    //  while (sp.BytesToRead != 0)
    //  {
    //    output += sp.ReadLine();
    //  }
    //  Console.WriteLine(output);
    //  return output;
    //}

    private void btnSearchByCom_Click(object sender, EventArgs e)
    {
      string COM = "";
      string[] names = SerialPort.GetPortNames();
      SerialPort sp = new SerialPort();
      sp.BaudRate = 115200;
      sp.DtrEnable = true;
      sp.RtsEnable = true;
      sp.ReadTimeout = 3000;
      sp.WriteTimeout = 3000;
      sp.Parity = System.IO.Ports.Parity.None;
      sp.StopBits = System.IO.Ports.StopBits.One;
      sp.DataBits = 8;
      foreach (string v in names)
      {

        sp.PortName = v;
        string res = "";
        try
        {
          sp.Open();
          sp.WriteLine("VERSION?\r");
          Thread.Sleep(50);
          while (sp.BytesToRead != 0)
          {
            res += sp.ReadLine();
          }
          sp.Close();
          if (!String.IsNullOrEmpty(res))
          {
            COM = v;//portName = obj["AttachedTo"].ToString();
            //this.Text = "Тест уровня сигналов: " + Com;
            break;
          }
        }
        catch { }
      }
      _selectPortKindWithSettingsControl.SetCom(COM);
    }

    private void ViewSearchBtn(object sender, EventArgs e)
    {
      btnSearchByCom.Visible = (bool)sender;
    }

    private void SettingForm_Load(object sender, EventArgs e)
    {
      btnSearchByCom.Visible = _selectPortKindWithSettingsControl.ValuePortKind == PortKind.Com;
      _selectPortKindWithSettingsControl.ViewSearchButton += ViewSearchBtn;
    }
  }
}
