using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class PlanResetControl : UserControl
  {
    private string RebootTime = "00:00";

    public PlanResetControl()
    {
      InitializeComponent();
      RebootTime = "00:00";
    }

    public string Value
    {
      get
      {
        if (cbActivePlanReboot.Checked)
          return RebootTime;
        else
          return "";
      }
      set
      {
        if (string.IsNullOrEmpty(value))
          value = "00:00";      
        dtpRebootTime.Value = getTimeFromString((RebootTime = value));
      }
    }

    public bool Active
    {
      get { return cbActivePlanReboot.Checked; }
      set { cbActivePlanReboot.Checked = value; }
    }


    private DateTime getTimeFromString(string val)
    {
      DateTime time = DateTime.Now.Date;
      string[] t = val.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
      time = time.AddHours(int.Parse(t[0])).AddMinutes(int.Parse(t[1]));
      return time;
    }

    private void cbActivePlanReboot_CheckedChanged(object sender, EventArgs e)
    {
      dtpRebootTime.Enabled = cbActivePlanReboot.Checked;
    }

    private void dtpRebootTime_ValueChanged(object sender, EventArgs e)
    {
      this.Value = dtpRebootTime.Value.Hour.ToString("D2") + ":" + dtpRebootTime.Value.Minute.ToString("D2");
    }
  }
}
