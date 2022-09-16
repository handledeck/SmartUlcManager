using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QueryBuilder.Data.AnyDb;
using Ztp.Configuration;
using Ztp.Model;
using Ztp.Ui;
using ZtpManager.DataAccessLayer;

namespace ZtpManager
{
  public partial class CatLightPlanForm : Form
  {
    public CatLightPlanForm()
    {
      InitializeComponent();
      lightPlanEditor.NeedEnableUpdate += LightPlanEditor_NeedEnableUpdate;
    }

    
    private void LightPlanEditor_NeedEnableUpdate(object sender, EventArgs e)
    {
      SetControlsEnabled();
    }

    #region SetControlsEnabled
    void SetControlsEnabled()
    {
      rbAddPlan.Enabled = Dal.Default.IsConnected;
      rbDeletePlan.Enabled = rbEditPlan.Enabled = Dal.Default.IsConnected && lvPlan.SelectedItems.Count > 0;

      rbAddSeason.Enabled = Dal.Default.IsConnected && lightPlanEditor.SeasonAddEnabled;
      rbDeleteSeason.Enabled = Dal.Default.IsConnected && lightPlanEditor.SeasonDeleteEnabled;
      rbEditSeason.Enabled = Dal.Default.IsConnected && lightPlanEditor.SeasonEditEnabled;

      rbAddSchedule.Enabled = Dal.Default.IsConnected && lightPlanEditor.ScheduleAddEnabled;
      rbDeleteSchedule.Enabled = Dal.Default.IsConnected && lightPlanEditor.ScheduleDeleteEnabled;
      rbEditSchedule.Enabled = Dal.Default.IsConnected && lightPlanEditor.ScheduleEditEnabled;

      rbViewScheduler.Enabled = Dal.Default.IsConnected && lightPlanEditor.ScheduleShowEnabled;
    }
    #endregion

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      lightPlanEditor.ZtpLocation = null;
      FillPlanListView();
      SetControlsEnabled();
    }

    void FillPlanListView()
    {
      lvPlan.BeginUpdate();
      try
      {
        IEnumerable<LightPlan> plans = Dal.Default.ReadLightPlans();
        lvPlan.Items.Clear();
        foreach (LightPlan plan in plans)
        {
          LightPlanItem item = new LightPlanItem(plan);
          lvPlan.Items.Add(item);
        }
        if (lvPlan.Items.Count > 0)
          lvPlan.Items[0].Selected = true;
      }
      catch (Exception e)
      {
        Box.Error(this, e);

      }
      finally
      {
        lvPlan.EndUpdate();
      }
    }

    class LightPlanItem : ListViewItem
    {
      public LightPlan Plan { get; set; }

      public LightPlanItem(LightPlan plan)
        : base(plan.DisplayName)
      {
        Plan = plan;
        ImageIndex = 0;
      }
    }

    LightPlanItem GetCurrentPlanItem()
    {
      if (lvPlan.SelectedItems.Count == 0)
        return null;
      return (LightPlanItem)lvPlan.SelectedItems[0];
    }

    private void rbAddPlan_Click(object sender, EventArgs e)
    {
      using (EditLightPlanForm frm = new EditLightPlanForm())
      {
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          try
          {
            ZtpScheduler sched = ZtpScheduler.GetDefault();
            LightPlan plan = new LightPlan()
            {
              DisplayName = frm.ValueName,
              Description = frm.ValueDescription,
              Body = sched.ToBase64String()
            };
            Dal.Default.AddLightPlan(plan);
            LightPlanItem item = new LightPlanItem(plan);
            lvPlan.Items.Add(item);
            item.Selected = true;
            SetControlsEnabled();
          }
          catch (Exception exception)
          {
            Box.Error(this, exception);
          }
        }
      }
    }

    private void rbDeletePlan_Click(object sender, EventArgs e)
    {
      LightPlanItem item = GetCurrentPlanItem();
      if (item == null)
        return;
      if (!Box.Confirm(this, $"Удалить план освещения '{item.Plan.DisplayName}'?"))
        return;
      try
      {
        if (Dal.Default.DeleteLightPlan(item.Plan))
        {
          lvPlan.Items.Remove(item);
          if (lvPlan.Items.Count > 0)
          {
            lvPlan.Items[0].Selected = true;
          }
          else
          {
            lightPlanEditor.Value.Scheduler  = null;
          }
        }
        SetControlsEnabled();
      }
      catch (Exception exception)
      {
        Box.Error(this, exception);
      }
    }

    private void rbEditPlan_Click(object sender, EventArgs e)
    {
      LightPlanItem item = GetCurrentPlanItem();
      if (item == null)
        return;
      try
      {
        using (EditLightPlanForm frm = new EditLightPlanForm())
        {
          frm.ValueName = item.Plan.DisplayName;
          frm.ValueDescription = item.Plan.Description;
          if (frm.ShowDialog(this) == DialogResult.OK)
          {
            item.Plan.DisplayName = frm.ValueName;
            item.Plan.Description = frm.ValueDescription;
            if (Dal.Default.EditLightPlan(item.Plan))
              item.Text = frm.ValueName;
          }
          SetControlsEnabled();
        }
      }
      catch (Exception exception)
      {
        Box.Error(this, exception);
      }
    }

    private void lvPlan_SelectedIndexChanged(object sender, EventArgs e)
    {
      LightPlanItem current = GetCurrentPlanItem();
      ZtpScheduler sched = null;
      if (current != null)
      {
        byte[] ba = Convert.FromBase64String(current.Plan.Body);
        sched = ZtpScheduler.Deserialize(ba);
      }
      lightPlanEditor.Value.Scheduler = sched;
      SetControlsEnabled();
    }

    private void rbAddSeason_Click(object sender, EventArgs e)
    {
      SchedulerAction(lightPlanEditor.DoSeasonAdd);
    }

    private void rbDeleteSeason_Click(object sender, EventArgs e)
    {
      SchedulerAction(lightPlanEditor.DoSeasonDelete);
    }

    private void rbEditSeason_Click(object sender, EventArgs e)
    {
      SchedulerAction(lightPlanEditor.DoSeasonEdit);
    }

    void SchedulerAction(Func<bool> func)
    {
      if (!Dal.Default.IsConnected) return;
      LightPlanItem current = GetCurrentPlanItem();
      if (current == null)
        return;
      if (func())
      {
        try
        {
          current.Plan.Body = lightPlanEditor.Value.Scheduler.ToBase64String();
          Dal.Default.EditLightPlan(current.Plan);
        }
        catch (Exception exception)
        {
          Box.Error(this, exception);
        }
      }
    }

    private void rbAddSchedule_Click(object sender, EventArgs e)
    {
      SchedulerAction(lightPlanEditor.DoScheduleAdd);
    }

    private void rbDeleteSchedule_Click(object sender, EventArgs e)
    {
      SchedulerAction(lightPlanEditor.DoScheduleDelete);
    }

    private void rbEditSchedule_Click(object sender, EventArgs e)
    {
      SchedulerAction(lightPlanEditor.DoScheduleEdit);
    }

    private void rbViewScheduler_Click(object sender, EventArgs e)
    {
      lightPlanEditor.DoScheduleShow();
    }

  }
}

