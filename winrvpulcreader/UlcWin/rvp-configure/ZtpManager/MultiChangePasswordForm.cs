using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Model;
using Ztp.Ui;
using Ztp.Utils;

namespace ZtpManager
{
  public partial class MultiChangePasswordForm : Form
  {
    public MultiChangePasswordForm()
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
    }

    public string ValuePassword { get; set; }

    public List<NodeEx> SelectedDevices
    {
      get { return selectDeviceControl.SelectedDevices; }
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      btnOk.Enabled = selectDeviceControl.SelectedDevices.Count > 0 && pswEditor.Value.Length > 0;
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      UpdateStatusText();
    }

    void UpdateStatusText()
    {
      int count = selectDeviceControl.SelectedDevices.Count;
      label1.Text = $"Выбрано для записи {count} устройств";
    }

    private void selectDeviceControl_SelectionChanged(object sender, EventArgs e)
    {
      UpdateStatusText();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      Exception ex = pswEditor.ValidatePassword();
      if (ex != null)
      {
        Box.Error(this, ex);
        return;
      }
      ValuePassword = pswEditor.Value;

      int count = selectDeviceControl.SelectedDevices.Count;
      if (count == 0)
        return;
      string msg = $"Вы уверены что хотите изменить пароль в указанных устройствах (устройств: {count})?";
      if (!Box.Confirm(this, msg))
        return;
      DialogResult = DialogResult.OK;
    }
  }
}
