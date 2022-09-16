using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZtpManager
{
  public partial class EditLightPlanForm : Form
  {
    public EditLightPlanForm()
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
    }

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
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
      btnOk.Enabled = itName.Value.Trim().Length > 0;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
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

  }
}
