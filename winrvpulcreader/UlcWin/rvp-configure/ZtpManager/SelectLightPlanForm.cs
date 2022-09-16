using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Model;

namespace ZtpManager
{
  public partial class SelectLightPlanForm : Form
  {
    public SelectLightPlanForm()
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      btnOk.Enabled = selectLightPlanControl.SelectedLightPlan != null;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }

    public LightPlan SelectedLightPlan
    {
      get { return selectLightPlanControl.SelectedLightPlan; }
    }
  }
}
