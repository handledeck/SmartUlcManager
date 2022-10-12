using Quartz;
using Quartz.Impl;
using SmartUlcService.ini;
using SmartUlcService.NLogs;
using SmartUlcService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartUlcService.ScheduleJob
{
  public class UlcScheduleJob
  {
    ISchedulerFactory __schedulerFactory = null;
    IScheduler __scheduler = null;
    public IJobDetail __jDtCron = null;
    public ITrigger __tgrCron = null;
    public UlcScheduleJob(string schedule)
    {
      __schedulerFactory = new StdSchedulerFactory();
      __scheduler = __schedulerFactory.GetScheduler();
      Dictionary<string, object> dic = new Dictionary<string, object>();
      dic.Add("scheduler", this);
      JobDataMap jobDataMap = new JobDataMap((IDictionary<string, object>)dic);
      IJobDetail jDtIm = JobBuilder.Create<UlcScedilerJob>()
            .WithIdentity("jDtIm")
            .SetJobData(jobDataMap)
            .Build();
      ITrigger tgrIm = TriggerBuilder.Create()
                .WithIdentity("tgrIm")
               .Build();
      __scheduler.ScheduleJob(jDtIm, tgrIm);
      

      __jDtCron = JobBuilder.Create<UlcScedilerJob>()
      .WithIdentity("jDtCron")
      .Build();

      __tgrCron = TriggerBuilder.Create()
          .ForJob(__jDtCron)
          .WithCronSchedule(schedule)//"* * * * * ?"
          .WithIdentity("UlcTrigger")
          .StartNow()
          .Build();
    }

    public void Stop()
    {
      Program.__service_run = false;
      //UlcSrvLog.Logger.Info("Service shutdown");
      __scheduler.Shutdown(false);
  }

    public void Start()
    {
      Program.__service_run = true;
      //UlcSrvLog.Logger.Info("Service start");
      __scheduler.StartDelayed(TimeSpan.FromSeconds(10));
      //__scheduler.Start();
    }

    internal class UlcScedilerJob : IJob
    {
      public void Execute(IJobExecutionContext context)
      {
        if (Program.__intWait > 0)
        {
          UlcSrvLog.Logger.Info("Ожидание окончания опроса");
          return;
        }
        if (context.MergedJobDataMap.Values.Count > 0)
        {
          UlcScheduleJob c = (UlcScheduleJob)context.MergedJobDataMap["scheduler"];
          context.Scheduler.Clear();
          context.Scheduler.ScheduleJob(c.__jDtCron, c.__tgrCron);
          UlcSrvLog.Logger.Info("Первичный опрос устройств");
        }
        else {
          UlcSrvLog.Logger.Info("Опрос устройств по расписанию");
        }
        
        Program.__cout_request = 0;
        Interlocked.Increment(ref Program.__intWait);
        InterviewService interviewService = new InterviewService(Program.__configIni);
        Interlocked.Decrement(ref Program.__intWait);
      }
    }
  }

 
}


