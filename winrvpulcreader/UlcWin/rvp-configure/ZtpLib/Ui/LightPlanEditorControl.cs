using System;
using System.Security.Policy;
using System.Windows.Forms;
using Ztp.Configuration;

namespace Ztp.Ui
{
  public partial class LightPlanEditorControl : UserControl
  {
    private ZtpLight _value = new ZtpLight();

    public ZtpLight Value
    {
      get
      {
        _value.UseScheduler = useSchedulerControl.UseScheduler;
        return _value;
      }
      set
      {
        _value = value;
        Assign();
        if (_value != null)
        {
          _value.Scheduler.Reset();
          _value.SchedulerChanged += _value_SchedulerChanged;
        }
      }
    }

    private void _value_SchedulerChanged(object sender, EventArgs e)
    {
      Assign();
    }

    void Assign()
    {
      scheduleListEditor.Clear();
      ZtpScheduler sched = _value?.Scheduler;
      seasonEditor.Value = sched;
      useSchedulerControl.UseScheduler = _value?.UseScheduler ?? false;
    }
    public LightPlanEditorControl()
    {
      InitializeComponent();
      _value.SchedulerChanged += _value_SchedulerChanged;
      seasonEditor.SeasonSelected += SeasonEditor_SeasonSelected;
    }

    public bool UseSchedulerVisible
    {
      get { return useSchedulerControl.Visible; }
      set { useSchedulerControl.Visible = value; }
    }

    public bool UseSchedulerEnable
    {
      get { return useSchedulerControl.UseScheduler; }
      set { useSchedulerControl.UseScheduler = value; }
    }

    public LocationEditorControl.ZtpLocation ZtpLocation
    {

      get { return scheduleListEditor.ZtpLocation; }
      set { scheduleListEditor.ZtpLocation = value; }
    }

    protected override void OnLoad(EventArgs e)
    {
      scheduleListEditor.SelectedIndexChanged += ScheduleListEditor_SelectedIndexChanged;
    }

    private void ScheduleListEditor_SelectedIndexChanged(object sender, EventArgs e)
    {
      OnNeedEnableUpdate();
    }

    private void SeasonEditor_SeasonSelected(SeasonEditorControl.SeasonSelectedEventArgs e)
    {
      ZtpSeason season = e.Season;
      scheduleListEditor.Value = season?.Intervals;
      scheduleListEditor.Season = season;
      OnNeedEnableUpdate();
    }

    public event EventHandler NeedEnableUpdate;
    public bool ScheduleAddEnabled
    {
      get
      {
        return scheduleListEditor.ScheduleAddEnabled;
      }
    }

    public bool ScheduleDeleteEnabled
    {
      get
      {
        return scheduleListEditor.ScheduleDeleteEnabled;
      }
    }

    public bool ScheduleEditEnabled
    {
      get
      {
        return scheduleListEditor.ScheduleEditEnabled;
      }
    }

    public bool ScheduleShowEnabled
    {
      get
      {
        return scheduleListEditor.ScheduleShowEnabled;
      }
    }

    public bool SeasonAddEnabled
    {
      get
      {
        return seasonEditor.SeasonAddEnabled;
      }
    }

    public bool SeasonDeleteEnabled
    {
      get
      {
        return seasonEditor.SeasonDeleteEnabled;
      }
    }

    public bool SeasonEditEnabled
    {
      get
      {
        return seasonEditor.SeasonEditEnabled;
      }
    }

    public bool DoSeasonEdit()
    {
      return seasonEditor.DoSeasonEdit();
    }

    public bool DoSeasonAdd()
    {
      return seasonEditor.DoSeasonAdd();
    }

    public bool DoSeasonDelete()
    {
      return seasonEditor.DoSeasonDelete();
    }

    public bool DoScheduleAdd()
    {
      return scheduleListEditor.DoScheduleAdd();
    }

    public bool DoScheduleDelete()
    {
      return scheduleListEditor.DoScheduleDelete();
    }

    public bool DoScheduleEdit()
    {
      return scheduleListEditor.DoScheduleEdit();
    }

    public void DoScheduleShow()
    {
      scheduleListEditor.DoScheduleShow();
    }

    protected virtual void OnNeedEnableUpdate()
    {
      NeedEnableUpdate?.Invoke(this, EventArgs.Empty);
    }
  }
}
