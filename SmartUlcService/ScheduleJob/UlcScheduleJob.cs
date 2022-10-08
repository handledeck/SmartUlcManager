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
   
    public UlcScheduleJob(string schedule)
    {
     __schedulerFactory = new StdSchedulerFactory();
      __scheduler = __schedulerFactory.GetScheduler();
      IJobDetail jobDetail = JobBuilder.Create<UlcScedilerJob>()
      .WithIdentity("UlcJob")
      .Build();

      ITrigger trigger = TriggerBuilder.Create()
          .ForJob(jobDetail)
          .WithCronSchedule(schedule)//"* * * * * ?"
          .WithIdentity("UlcTrigger")
          .StartNow()
          .Build();
      __scheduler.ScheduleJob(jobDetail, trigger);
      


    }

    public void Stop()
    {
      Program.__service_run = false;
      UlcSrvLog.Logger.Info("Start service");
      __scheduler.Shutdown(false);
    }

    public void Start()
    {
      Program.__service_run = true;
      UlcSrvLog.Logger.Info("Start service");
      __scheduler.Start();
    }

    internal class UlcScedilerJob : IJob
    {
     
      public void Execute(IJobExecutionContext context)
      {
        
        if (Program.__intWait > 0) {
          UlcSrvLog.Logger.Info("wait");
          return;
        }
        Program.__cout_request = 0;
        UlcSrvLog.Logger.Info("run");
        Interlocked.Increment(ref Program.__intWait);
        //for (int i = 0; i < 10; i++)
        //{
        //Console.WriteLine("wait...");
        //Thread.Sleep(1);
        //}
        InterviewService interviewService = new InterviewService(Program.__configIni);
        UlcSrvLog.Logger.Info("stop");
        Interlocked.Decrement(ref Program.__intWait);
      }

    }
  }

 
}


