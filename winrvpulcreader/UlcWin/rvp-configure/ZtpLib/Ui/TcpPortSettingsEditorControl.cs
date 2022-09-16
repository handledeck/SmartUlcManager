using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Port.TcpPort;

namespace Ztp.Ui
{
  public partial class TcpPortSettingsEditorControl : UserControl
  {
    public TcpPortSettingsEditorControl()
    {
      InitializeComponent();
    }

    TcpPortSettings _value = new TcpPortSettings();

    public TcpPortSettings Value
    {
      get
      {
        _value = CollectTcpPortSettings();
        return _value;
      }
      set
      {
        if (value == null)
          return; 
        _value = value;
        Assign();
      }
    }

    TcpPortSettings CollectTcpPortSettings()
    {
      if(_value == null)
      _value = new TcpPortSettings();
      _value.IpAddress = tbAddress.Text;
      _value.Port = Convert.ToUInt32(tbPort.Value);
      _value.Timeout = Convert.ToInt32(tbTimeout.Value);
      return _value;
    }
    void Assign()
    {
      tbAddress.Text = _value.IpAddress;
      tbPort.Value = _value.Port;
      tbTimeout.Value = _value.Timeout;
    }
  }
}
