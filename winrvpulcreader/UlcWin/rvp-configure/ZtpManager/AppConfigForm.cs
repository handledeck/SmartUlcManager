using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Ui;
using Ztp.Utils;

namespace ZtpManager
{
  public partial class AppConfigForm : Form
  {
    public AppConfigForm()
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
      Application.Idle -= Application_Idle;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      itEstIpAddress.Enabled = pswEst.Enabled = idEstPort.Enabled = itEstUser.Enabled = cbEstEnabled.Checked;
      if (!cbEstEnabled.Checked)
        btnOk.Enabled = true;
      else
      {
        btnOk.Enabled = itEstIpAddress.Value.Trim().Length > 0 && itEstUser.Value.Trim().Length > 0;
      }
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      SetControlsValue();
    }

    void SetControlsValue()
    {
      cbEstEnabled.Checked = AppConfig.Default.EstEnabled;
      itEstIpAddress.Value = AppConfig.Default.EstIpAddress;
      idEstPort.Value = AppConfig.Default.EstPort;
      itEstUser.Value = AppConfig.Default.EstUser;
      pswEst.Value = StringUtils.FromBase64String(AppConfig.Default.EstPassword);
      idTcpPort.Value = AppConfig.Default.TcpPort;
      idTcpTimeout.Value = AppConfig.Default.TcpTimeout;
      cbAutoOpenConfigRibbon.Checked = AppConfig.Default.AutoOpenConfigRibbon;
    }

    void SetConfigValues()
    {
      AppConfig.Default.EstEnabled = cbEstEnabled.Checked;
      AppConfig.Default.EstIpAddress = itEstIpAddress.Value;
      AppConfig.Default.EstPort = (int)idEstPort.Value;
      AppConfig.Default.EstUser = itEstUser.Value;
      AppConfig.Default.EstPassword = StringUtils.ToBase64String(pswEst.Value);
      AppConfig.Default.TcpPort = (uint)idTcpPort.Value;
      AppConfig.Default.TcpTimeout = (int)idTcpTimeout.Value;
      AppConfig.Default.AutoOpenConfigRibbon = cbAutoOpenConfigRibbon.Checked;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      Exception ex = IpAddressValidator.Validate(itEstIpAddress.Value);
      if (ex != null)
      {
        Box.Error(this, $"Не корректно указан IP-адрес. {ex.Message}");
        return;
      }
      ex = PortValidator.Validate(((int)idEstPort.Value).ToString());
      if (ex != null)
      {
        Box.Error(this, $"Не корректно указан номер порта. {ex.Message}");
        return;
      }
      SetConfigValues();
      DialogResult = DialogResult.OK;
    }
  }
}
