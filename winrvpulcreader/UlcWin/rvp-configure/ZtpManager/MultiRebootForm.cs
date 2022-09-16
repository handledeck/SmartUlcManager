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
  public partial class MultiRebootForm : Form
  {
    public MultiRebootForm()
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
      btnOk.Enabled = selectDevice.SelectedDevices.Count > 0;
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      UpdateStatusText();
    }

    void UpdateStatusText()
    {
      int count = selectDevice.SelectedDevices.Count;
      label1.Text = $"Выбрано для перезагрузки {count} устройств";
    }

    public List<NodeEx> SelectedDevices
    {
      get { return selectDevice.SelectedDevices; }
    }

    private void selectDevice_SelectionChanged(object sender, EventArgs e)
    {
      UpdateStatusText();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      int count = selectDevice.SelectedDevices.Count;
      if (count == 0)
        return;
      string msg = $"Вы уверены что хотите перезагрузить указанные устройства (устройств: {count})?";
      if (!Box.Confirm(this, msg))
        return;
      DialogResult = DialogResult.OK;
    }
  }
}
