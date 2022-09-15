using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ztp.Configuration;

namespace UlcWin.ui
{
  public partial class ScheduleForm : Form
  {
    public ZtpConfig __ztpConfig;
    public ScheduleForm(ref ZtpConfig ztpConfig)
    {
      InitializeComponent();
      this.Shown += ScheduleForm_Shown;
      this.__ztpConfig = ztpConfig;
      this.__ztpConfig.TimeZone = 3;
      this.__planEditor.Value = this.__ztpConfig.Light;
    }

    private void ScheduleForm_Shown(object sender, EventArgs e)
    {
      Application.Idle += Application_Idle;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      if (this.__planEditor.SeasonAddEnabled)
        this.btnAddSeason.Enabled = true;
      else
        this.btnAddSeason.Enabled = false;
      if (this.__planEditor.SeasonEditEnabled)
        this.btnChangeSeason.Enabled = true;
      else
        this.btnChangeSeason.Enabled = false;
      if (this.__planEditor.SeasonDeleteEnabled)
        this.btnReamoveSeason.Enabled = true;
      else
        this.btnReamoveSeason.Enabled = false;
      if (this.__planEditor.ScheduleAddEnabled)
        this.btnScheduleAdd.Enabled = true;
      else
        this.btnScheduleAdd.Enabled = false;
      if (this.__planEditor.ScheduleEditEnabled)
        this.btnScheduleEdit.Enabled = true;
      else
        this.btnScheduleEdit.Enabled = false;
      if (this.__planEditor.ScheduleDeleteEnabled)
        this.btnScheduleDelete.Enabled = true;
      else
        this.btnScheduleDelete.Enabled = false;
     
    }

    private void btnAddSeason_Click(object sender, EventArgs e)
    {
      __planEditor.DoSeasonAdd();
    }

    private void btnReamoveSeason_Click(object sender, EventArgs e)
    {
      __planEditor.DoSeasonDelete();
    }

    private void btnChangeSeason_Click(object sender, EventArgs e)
    {
      __planEditor.DoSeasonEdit();
    }

    private void btnScheduleAdd_Click(object sender, EventArgs e)
    {
      __planEditor.DoScheduleAdd();
    }

    private void btnScheduleEdit_Click(object sender, EventArgs e)
    {
      __planEditor.DoScheduleEdit();
    }

    private void btnScheduleDelete_Click(object sender, EventArgs e)
    {
      __planEditor.DoScheduleDelete();

    }
    public string __html = string.Empty;
    private void btnChancel_Click(object sender, EventArgs e)
    {
      ZtpScheduler sched = __planEditor.Value.Scheduler;
      Exception ex = ZtpScheduler.CheckOverlap(sched, this.__ztpConfig.TimeZone,
        this.__ztpConfig.Latitude, this.__ztpConfig.Longitude);
      if (ex != null)
      {
        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      else {
        __ztpConfig.Light.Scheduler = sched;

        __html =sched.ToHtml();
        this.DialogResult = DialogResult.OK;
      }
    }
  }
}
