using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Port;
using Ztp.Port.ComPort;
using Ztp.Port.TcpPort;

namespace Ztp.Ui
{
  public partial class SelectPortKindWithSettingsControl : UserControl
  {
    public SelectPortKindWithSettingsControl()
    {
      InitializeComponent();
    }
    public event EventHandler ViewSearchButton;
    [Browsable(false)]
    public ComPortSettings ValueComPortSettings
    {
      get
      {
        if (comPortSettingsEditorControl != null)
          return comPortSettingsEditorControl.Value;
        return new ComPortSettings();
      }
      set
      {
        if (comPortSettingsEditorControl != null)
          comPortSettingsEditorControl.Value = value;
      }
    }

    [Browsable(false)]
    public TcpPortSettings ValueTcpPortSettings
    {
      get { return tcpPortSettingsEditorControl.Value; }
      set { tcpPortSettingsEditorControl.Value = value; }
    }

    public PortKind ValuePortKind
    {
      get { return selectPortKindControl.Value; }
      set
      {
        selectPortKindControl.Value = value;
      }
    }
    private void selectPortKindControl_PortKingChanged(object sender, EventArgs e)
    {
      PortKind kind = selectPortKindControl.Value;
      if (kind == PortKind.Com)
      {
        if (tabControl.TabPages.Contains(tpTcp))
          tabControl.TabPages.Remove(tpTcp);
        if (!tabControl.TabPages.Contains(tpCom))
          tabControl.TabPages.Add(tpCom);
      }
      else
      {
        if (tabControl.TabPages.Contains(tpCom))
          tabControl.TabPages.Remove(tpCom);
        if (!tabControl.TabPages.Contains(tpTcp))
          tabControl.TabPages.Add(tpTcp);
      }
      ViewSearchButton?.Invoke((bool)(kind == PortKind.Com), EventArgs.Empty);
    }

    public void SetCom(string com)
    {
      comPortSettingsEditorControl.SetCom(com);
    }

    public bool EnabledComBaudrates
    {
      get { return comPortSettingsEditorControl.EnabledBaudrates; }
      set { comPortSettingsEditorControl.EnabledBaudrates = value; }
    }

    public bool EnabledComDataBits
    {
      get { return comPortSettingsEditorControl.EnabledDataBits; }
      set { comPortSettingsEditorControl.EnabledDataBits = value; }
    }

    public bool EnabledComParity
    {
      get { return comPortSettingsEditorControl.EnabledParity; }
      set { comPortSettingsEditorControl.EnabledParity = value; }
    }

    public bool EnabledComHandshake
    {
      get { return comPortSettingsEditorControl.EnabledHandshake; }
      set { comPortSettingsEditorControl.EnabledHandshake = value; }
    }

    public bool EnabledComStopBits
    {
      get { return comPortSettingsEditorControl.EnabledStopBits; }
      set { comPortSettingsEditorControl.EnabledStopBits = value; }
    }

    public bool EnabledComPortName
    {
      get { return comPortSettingsEditorControl.EnabledPortName; }
      set { comPortSettingsEditorControl.EnabledPortName = value; }
    }
  }
}
