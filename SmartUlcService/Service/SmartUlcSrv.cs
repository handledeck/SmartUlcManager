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
using System.Threading;
using System.Threading.Tasks;
using WindowsService1;
using WorkerService1;

namespace SmartUlcService
{
  public partial class SmartUlcSrv:ServiceBase
  {
    UlcScheduleJob __ulcScheduleJob=null;
    public SmartUlcSrv()
    {
      //InitializeComponent();
      UlcSrvLog.InitUlcSrvLog();
      //UlcSrvLog.Logger.Info("Инициализация службы");
    }

    //public void Execute(IJobExecutionContext context)
    //{
    //  UlcSrvLog.Logger.Info("work;");
    //}

    protected override void OnStart(string[] args)
    {

      //InterviewService interviewService = new InterviewService(Program.__configIni);
      UlcSrvLog.Logger.Info("...........Старт службы...........");
      CancellationToken stoppingToken = new CancellationToken();
      __ulcScheduleJob = new UlcScheduleJob(Program.__configIni.Scheduler, stoppingToken);
       __ulcScheduleJob.Start();
    }

    protected override  void OnStop()
    {
      __ulcScheduleJob.Stop();
      UlcSrvLog.Logger.Info("Служба остановлена");
    }
  }
}
