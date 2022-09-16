using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Configuration;
using Ztp.Model;
using Ztp.Protocol;
using Ztp.Ui;

namespace ZtpManager
{
  public partial class MultiConfigForm : Form
  {
    DeviceKind _kind = DeviceKind.Unknown;
    public MultiConfigForm()
    {
      InitializeComponent();
      selectDevTypeControl.SelectedItemChanged += DeviceTypeChange;
      Application.Idle += Application_Idle;
      _kind = (DeviceKind)(selectDevTypeControl.Value);
      this.selectDeviceControl.SetActiveDevice(_kind);
      this.selectDeviceControl._kind = _kind;
      this.selectDeviceControl.RefreshObj();
      partitionConfigEditor.ViewConfigByDevType((Ztp.Enums.DevType)_kind);
    }

    private void DeviceTypeChange(object sender, EventArgs e)
    {
      DeviceKind kind = (DeviceKind)(((ComboBox)sender).SelectedIndex + 1); //((ComboBox)sender).SelectedIndex == 0 ? DeviceKind.RVP18 : DeviceKind.ULC02;
      this.selectDeviceControl.SetActiveDevice(kind);
      this.selectDeviceControl._kind = kind;
      this.selectDeviceControl.RefreshObj();
      partitionConfigEditor.ViewConfigByDevType((Ztp.Enums.DevType)kind);
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      btnOk.Enabled = partitionConfigEditor.CheckedFlags.Count > 0 && selectDeviceControl.SelectedDevices.Count > 0;
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      UpdateStatusText();
    }

    public List<NodeEx> SelectedDevices
    {
      get { return selectDeviceControl.SelectedDevices; }
    }
    public ZtpConfig Value
    {
      get { return partitionConfigEditor.Value; }
    }
    private void btnOk_Click(object sender, EventArgs e)
    {
      int count = selectDeviceControl.SelectedDevices.Count;
      if (count == 0)
        return;

      List<Tuple<ZtpConfig.ConfigFlag, string>> tuples = partitionConfigEditor.CheckedFlags;
      StringBuilder sb = new StringBuilder();
      sb.AppendLine();
      foreach (Tuple<ZtpConfig.ConfigFlag, string> tuple in tuples)
      {
        sb.AppendLine($"- {tuple.Item2}");
      }
      string msg = $"Вы уверены что хотите записать следующие параметры: {sb.ToString()} в указанные устройства (устройств: {count})?";
      if (!Box.Confirm(this, msg))
        return;
      DialogResult = DialogResult.OK;
    }

    private void selectDeviceControl_SelectionChanged(object sender, EventArgs e)
    {
      UpdateStatusText();
    }

    void UpdateStatusText()
    {
      int count = selectDeviceControl.SelectedDevices.Count;
      label2.Text = $"Выбрано для записи {count} устройств";
    }

  }
}
