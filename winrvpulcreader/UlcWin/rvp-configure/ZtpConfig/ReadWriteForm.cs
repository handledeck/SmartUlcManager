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

namespace Zpt
{
  public partial class ReadWriteForm : Form
  {

    private readonly SelectPortKindWithSettingsControl _selectPortKindWithSettingsControl;

    public ReadWriteForm()
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
      Mode = ActionMode.Write;
    }

    void ShowCaption()
    {
      if (Mode == ActionMode.Write)
      {
        Text = "Запись конфигурации в устройство";
        btnAction.Text = "Записать";
      }
      else
      {
        Text = "Чтение конфигурации с устройства";
        btnAction.Text = "Прочитать";
      }
    }

    private ActionMode _mode;

    public ActionMode Mode
    {
      get { return _mode; }
      set
      {
        _mode = value;
        ShowCaption();
      }
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

    private ZtpConfig _valueZtpConfig;
    public ZtpConfig ValueZtpConfig
    {
      get { return _valueZtpConfig; }
      set { _valueZtpConfig = value; }
    }

    class BwArg
    {
      public TcpPortSettings Tcp;
      public ComPortSettings Com;
      public PortKind Kind;
      public ActionMode Action;
    }

    private void btnAction_Click(object sender, EventArgs e)
    {
      btnAction.Enabled = btnClose.Enabled = false;
      BwArg arg = new BwArg()
      {
        Tcp = _selectPortKindWithSettingsControl.ValueTcpPortSettings,
        Com = _selectPortKindWithSettingsControl.ValueComPortSettings,
        Kind = ValuePortKind,
        Action = Mode
      };
      bw.RunWorkerAsync(arg);
    }

    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      btnAction.Enabled = btnClose.Enabled = true;
      if (e.Result != null)
      {
        if (Mode == ActionMode.Read)
          ValueZtpConfig = (ZtpConfig)e.Result;
        DialogResult = DialogResult.OK;
      }
    }

    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        BwArg arg = (BwArg)e.Argument;
        IODriverClient port = PortManager.GetPort(uiLogConsole, arg.Kind, () => arg.Com, () => arg.Tcp);

        byte[] buff;
        string command;
        if (arg.Action == ActionMode.Read)
        {
          uiLogConsole.Info("Чтение конфигурации");
          command = ZtpProtocol.GetConfigCommand();
        }
        else
        {
          uiLogConsole.Info("Запись конфигурации");
          command = ZtpProtocol.SetConfigCommand(_valueZtpConfig);
        }
        string answer;
        uiLogConsole.Info($"Команда: {command}");
        buff = ZtpProtocol.ToBytes(command);
        try
        {
          port.Open();
          port.Write(buff, 0, buff.Length);
          if (Mode == ActionMode.Read)
          {
            buff = new byte[1024];
            System.Threading.Thread.Sleep(100);
            using (System.IO.MemoryStream st = new System.IO.MemoryStream())
            {
              int read = port.Read(buff, 0, buff.Length);
              st.Write(buff, 0, read);
              answer = ZtpProtocol.FromBytes(st.ToArray());
            }
            uiLogConsole.Info($"Ответ: {answer}");
            e.Result = ZtpProtocol.DeserializeZtpConfig(answer);
          }
          else
          {
            e.Result = new object();
          }
          uiLogConsole.Info("Операция успешно завершена");
        }
        finally
        {
          port.Close();
        }
      }
      catch (Exception ex)
      {
        e.Result = null;
        uiLogConsole.Error(ex);
        ShowError(ex.Message);
      }
    }

    void ShowError(string message)
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new Action<string>(ShowError), new object[] { message });
        return;
      }
      Box.Error(this, message);
    }
  }
}
