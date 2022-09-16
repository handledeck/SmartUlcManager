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
using Ztp.Enums;
using ZtpManager.Nodes;

namespace ZtpManager
{
  public partial class EditDeviceForm : Form
  {
    private FolderNode _node;
    public EditDeviceForm()
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
    }

    public EditDeviceForm(FolderNode node)
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
      _node = node;
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
      btnOk.Enabled = itName.Value.Trim().Length > 0 && itIpAddress.Value.Trim().Length > 0 && pswEdit.Value.Length > 0;
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      bool _isAddMode = itName.Value.Trim().Length == 0;
      if (_isAddMode)
        itIpAddress.Value = AppConfig.Default.EstIpAddress;
    }

    public string ValueName
    {
      get { return itName.Value; }
      set { itName.Value = value; }
    }

    public string ValueDescription
    {
      get { return itDescription.Value; }
      set { itDescription.Value = value; }
    }

    public string ValueIpAddress
    {
      get { return itIpAddress.Value; }
      set { itIpAddress.Value = value; }
    }

    public string ValuePasswordDecrypt
    {
      get { return pswEdit.Value; }
      set { pswEdit.Value = value; }
    }

    public DevType ValueDevType
    {
      get { return DevTypeCtrl.Value; }
      set { DevTypeCtrl.Value = value; }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      Exception ex = IpAddressValidator.Validate(itIpAddress.Value);
      if (ex != null)
      {
        Box.Error(this, "IP-адрес: " + ex.Message);
        return;
      }
      AppConfig.Default.LastIpAddress = itIpAddress.Value;
      AppConfig.Default.Save();
      DialogResult = DialogResult.OK;
    }
  }
}
