using Quartz.Impl;
using Quartz;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Spi;
using System.Data;
using SmartUlcService.ScheduleJob;
using SmartUlcService.NLogs;
using SmartUlcService.ini;

namespace WorkerService1
{
  public class Worker : BackgroundService
  {
    public static ConfigIni __configIni;
    public static int __intWait = 0;
    public static int __cout_request = 0;
    public static int __cout_ulc_request = 0;
    public static int __cout_ulc_meters = 0;
    public static int __cout_ulc_rs485 = 0;
    public static bool __service_run = false;
    private readonly ILogger<Worker> _logger;
    UlcScheduleJob __ulcScheduleJob;

    public Worker(ILogger<Worker> logger)
    {
      _logger = logger;
      __configIni = new ConfigIni();
      UlcSrvLog.InitUlcSrvLog();
      UlcSrvLog.Logger.Info("Инициализация службы");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      UlcSrvLog.Logger.Info("Старт службы");
      __ulcScheduleJob = new UlcScheduleJob(Worker.__configIni.Scheduler, stoppingToken);
      await __ulcScheduleJob.Start();

      //while (!stoppingToken.IsCancellationRequested)
      //{
      //  _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
      //  await Task.Delay(1000, stoppingToken);
      //}
    }
  }
}