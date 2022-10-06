using IniParser.Parser;
using NLog;
using Quartz;
using Quartz.Impl;
using SmartUlcService.ini;
using SmartUlcService.NLogs;
using SmartUlcService.ScheduleJob;
using SmartUlcService.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartUlcService
{
  static class Program
  {

    // private static Logger logger = LogManager.GetCurrentClassLogger();
    public static ConfigIni __configIni;
    public static int __intWait = 0;
    public static int __cout_request = 0;

    static void Main()
    {
      __configIni = new ConfigIni();
      ServiceBase[] ServicesToRun;
      ServicesToRun = new ServiceBase[]
      {
         new SmartUlcSrv()
      };
      ServiceBase.Run(ServicesToRun);

      //InterviewService interviewService = new InterviewService(Program.__configIni);

    }

  }

 

}
