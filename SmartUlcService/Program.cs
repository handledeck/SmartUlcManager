using SmartUlcService;
using SmartUlcService.ini;
using SmartUlcService.NLogs;
using SmartUlcService.ScheduleJob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WorkerService1;

namespace WindowsService1
{
  static class Program
  {
    public static ConfigIni __configIni;
    public static int __intWait = 0;
    public static int __cout_request = 0;
    public static int __cout_ulc_request = 0;
    public static int __cout_ulc_meters = 0;
    public static int __cout_ulc_rs485 = 0;
    public static bool __service_run = false;
    
    static void Main()
    {
      __configIni = new ConfigIni();
      UlcSrvLog.InitUlcSrvLog();
      UlcSrvLog.Logger.Info("Инициализация службы");
      //SmartUlcSrv smartUlcSrv = new SmartUlcSrv();
      //UlcScheduleJob __ulcScheduleJob = new UlcScheduleJob(__configIni.Scheduler,new System.Threading.CancellationToken());

      //Thread tr = new Thread(() => {
      //  __ulcScheduleJob.Start();
      //});
      //tr.Start();
      //while (true)
      //{
      //  Thread.Sleep(10000000);
      //}
      ServiceBase[] ServicesToRun;
      ServicesToRun = new ServiceBase[]
      {
                new SmartUlcService.SmartUlcSrv()

      };
      ServiceBase.Run(ServicesToRun);
    }
  }
}
