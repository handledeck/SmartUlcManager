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

namespace ZtpManager
{
  public partial class MultiSwitchOnOffForm : Form
  {
    public MultiSwitchOnOffForm()
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      btnOk.Enabled = selectDeviceControl.SelectedDevices.Count > 0;
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

    public bool SwitchOn
    {
      get { return rbOn.Checked; }
    }

    public List<NodeEx> SelectedDevices
    {
      get { return selectDeviceControl.SelectedDevices; }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string action = rbOff.Checked ? "Отключить" : "Включить";

      int count = selectDeviceControl.SelectedDevices.Count;
      if (count == 0)
        return;
      string msg = $"Вы уверены что хотите {action} освещение на указанных устройствах (устройств: {count})?";
      if (!Box.Confirm(this, msg))
        return;
      DialogResult = DialogResult.OK;
    }

  }
}
