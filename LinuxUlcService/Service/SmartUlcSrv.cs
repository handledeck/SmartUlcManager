using Quartz;
using SmartUlcService.ini;
using SmartUlcService.NLogs;
using SmartUlcService.ScheduleJob;
using SmartUlcService.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WorkerService1;

namespace SmartUlcService
{
  public partial class SmartUlcSrv 
  {
    UlcScheduleJob __ulcScheduleJob=null;
    public SmartUlcSrv()
    {
      //InitializeComponent();
      UlcSrvLog.InitUlcSrvLog();
      UlcSrvLog.Logger.Info("Инициализация службы");
    }

    //public void Execute(IJobExecutionContext context)
    //{
    //  UlcSrvLog.Logger.Info("work;");
    //}

    protected async void OnStart(string[] args)
    {

      //InterviewService interviewService = new InterviewService(Program.__configIni);
      UlcSrvLog.Logger.Info("Старт службы");
      __ulcScheduleJob = new UlcScheduleJob(Worker.__configIni.Scheduler,null);
      await __ulcScheduleJob.Start();
    }

    protected  void OnStop()
    {
      __ulcScheduleJob.Stop();
      UlcSrvLog.Logger.Info("Служба остановлена");
    }
  }
}
