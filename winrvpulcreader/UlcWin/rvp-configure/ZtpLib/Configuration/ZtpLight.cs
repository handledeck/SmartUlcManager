using System;

namespace Ztp.Configuration
{
  public class ZtpLight
  {
    public bool UseScheduler { get; set; }
    private ZtpScheduler _scheduler = ZtpScheduler.GetDefault();
    public ZtpScheduler Scheduler {
      get { return _scheduler; }
      set
      {
        _scheduler = value; 
        OnSchedulerChanged();
      }
    }

    public event EventHandler SchedulerChanged;

    protected virtual void OnSchedulerChanged()
    {
      SchedulerChanged?.Invoke(this, EventArgs.Empty);
    }
  }
}