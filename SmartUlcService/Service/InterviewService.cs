using InterUlc.CurCfg;
using InterUlc.Db;
using InterUlc.Drivers;
using InterUlc.Logs;
using InterUlc.UlcCfg;
using ServiceStack.OrmLite;
using SmartUlcService.ini;
using SmartUlcService.NLogs;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Sockets;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsService1;
using WorkerService1;
using WorkerService1.Db;

namespace SmartUlcService.Service
{
  public class InterviewService
  {
    ConfigIni __configIni;
    public InterviewService(ConfigIni configIni)
    {
      __configIni = configIni;
      
    }

   

    public void RunService(CancellationToken stoppingToken) {
      try
      {

        DbReader db = new DbReader(__configIni.IpDb, __configIni.UserDb, __configIni.UserPwdDb);// uset.DbIp, uset.DbUser, uset.Db
        UlcSrvLog.Logger.Info("Начало опроса {0}", DateTime.Now);
        db.ServiceDbData();
        //db.CheckRvpForStatistics();
        //List<DbReqestNotTrue> lltest = ReadEvent();
        //GetNotTrueItems(lltest, db);


        List<DbReqestNotTrue> ll = db.ReadNotTrueItems(DateTime.Now);
        if (ll != null)
        {
          UlcSrvLog.Logger.Info("Недоставерных данных по устройствам: {0}", ll.Count);
          GetNotTrueItems(ll, db);
          UlcSrvLog.Logger.Info("Успешно опрошено по устройствам: {0}", Program.__cout_ulc_request);
        }
        List<MeterValue> meterValues = db.GetNotTrueMeters();
        if (meterValues != null)
        {
          UlcSrvLog.Logger.Info("Недоставерных данных по счетчикам: {0}", meterValues.Count);
          GetNotTrueItemsMeters(meterValues, db);
          UlcSrvLog.Logger.Info("Успешно опрошено по счетчикам: {0}", Program.__cout_ulc_meters);
        }
        List<RsNotTrue> lst_rs = db.GetNotTruerRS485();
        if (lst_rs != null)
        {
          UlcSrvLog.Logger.Info("Недоставерных данных по RS-485: {0}", lst_rs.Count);
          GetNotTrueItemsRs(lst_rs, db);
          UlcSrvLog.Logger.Info("Успешно опрошено по RS-485: {0}", Program.__cout_ulc_rs485);
        }

        ////UlcSrvLog.Logger.Info(string.Format("Опрошено:{0}", Worker.__cout_request.ToString()));

        ////GetNotTrueItemsRs(rsNotTrueDatas, db);
        ////GetNotTrueItems(ll, db, uset, cowr);
        UlcSrvLog.Logger.Info("Окончание опроса:{0}", DateTime.Now);
      }
      catch (Exception exp)
      {
        UlcSrvLog.Logger.Error(exp.Message);
      }
    }

    static List<DbReqestNotTrue> ReadEvent()
    {
      ///select* from main_ctrlevent mc where mc.ctrl_id = 15456 and mc.event_time > '2023-01-06' order by mc.event_time
      //TcpClient client = GetConnection("172.22.130.143", 10251);
      //    Exception exp;
      DbReqestNotTrue dbReqestNotTrue = new DbReqestNotTrue();
      dbReqestNotTrue.ip_address = "172.22.133.136"; //15482
      dbReqestNotTrue.id = 15327;
      dbReqestNotTrue.unit_type_id = 1;
      List<DbReqestNotTrue> lstDevice = new List<DbReqestNotTrue>();
      lstDevice.Add(dbReqestNotTrue);
      //dbReqestNotTrue = new DbReqestNotTrue();
      //dbReqestNotTrue.ip_address = "172.22.133.8"; //15482
      //dbReqestNotTrue.id = 15456;
      //dbReqestNotTrue.unit_type_id = 1;
      //lstDevice.Add(dbReqestNotTrue);
      return lstDevice;
      //List<Log> log = ParceLog.GetLogIP(client.GetStream(), out exp);

      //if (log != null)
      //{
      //lstDevice.Add(new DbReqestNotTrue() { ID = 14667,Logs=log });
      //db.WriteEventMessage(lstDevice);
      //item.Logs = log;

      //}
    }

    static List<Task> LstUncomp = null;
    static void RemoveTask(Task tsk)
    {
      lock (__lstTaskUpdate)
      {
        try
        {
          if (!__lstTaskUpdate.Remove(tsk))
          {
            if (LstUncomp == null)
              LstUncomp = new List<Task>();
            LstUncomp.Add(tsk);
          }
        }
        catch (Exception exp)
        {

        }
      }
    }

    public static TcpClient GetConnection(string host, int port)
    {
      TcpClient client = new TcpClient();
      IAsyncResult result = client.BeginConnect(host, port, (i) =>
      {
        if (!client.Connected)
        {
          client = null;
        }
      }, null);
      bool state = result.AsyncWaitHandle.WaitOne(10000);
      if (!state)
        return null;
      else return client;
    }

    static List<Task> __lstTaskUpdate = null;
    static List<Task> __lstTaskRunner = null;
    void GetNotTrueItems(List<DbReqestNotTrue> lstDevice, DbReader db)
    {
      try
      {
        Program.__cout_ulc_request = 0;
        LstUncomp = null;
        int all = lstDevice.Count;
        __lstTaskUpdate = new List<Task>();
        __lstTaskRunner = new List<Task>();
        var iner = Task.Factory.StartNew(() =>
        {
          foreach (var item in lstDevice)
          {
            item.EvtItemRunComplite = RemoveTask;
            Task tsk = new Task(() =>
            {
              TcpClient client = null;
              try
              {
                client = GetConnection(item.ip_address, 10251);
                if (client == null)
                  throw new Exception(string.Format("Error connect to:{0}", item.ip_address));
                CurrentCfg cfg = null;
                cfg = new CurrentCfg();
                string msg = string.Empty;
                bool result = false;
                result = cfg.GetConfigIP(client, item.ip_address, out msg);
                if (result)
                {
                  item.message = msg;
                  item.UlcCnfg = UlcCfg.TryExtarctFromMsg(msg);
                  Interlocked.Increment(ref Program.__cout_ulc_request);
                }
                if (item.unit_type_id == 1 && item.UlcCnfg != null)
                {
                  if (item.UlcCnfg.LOGSLVL != EnumLogs.LOG_LVL.logNONE)
                  {
                    NetworkStream stream = client.GetStream();
                    stream.ReadTimeout = 10000;
                    Exception exp;
                    List<Log> log = ParceLog.GetLogIP(stream, item.id, out exp);
                    if (log != null)
                    {
                      item.logs = log;
                    }
                  }
                }
                //Interlocked.Increment(ref Worker.__cout_request);
              }
              catch (Exception exp)
              {
              }
              finally
              {
                if (client != null)
                {
                  client.Close();
                }
                item.EvtItemRunComplite(item.OwnerTask);
              }
            });
            item.OwnerTask = tsk;
            __lstTaskRunner.Add(tsk);
          }
          for (int i = 0; i < __lstTaskRunner.Count; i++)
          {
            if (!Program.__service_run)
              return;
            if (__lstTaskUpdate.Count < 200)
            {
              lock (__lstTaskUpdate)
              {
                __lstTaskUpdate.Add(__lstTaskRunner[i]);
                __lstTaskRunner[i].Start();

              }
            }
            while (__lstTaskUpdate.Count == 200)
            {
              Thread.Sleep(1);
            }
          }
          while (__lstTaskUpdate.Count != 0)
          {
            Thread.Sleep(100);
          }
        });
        iner.Wait();
        UlcSrvLog.Logger.Info("Обновление базы данных контроллеров");
        db.InsertCfgMsg(lstDevice);
        UlcSrvLog.Logger.Info("Обновление базы данных событий");
        db.WriteEventMessage_1(lstDevice);
        UlcSrvLog.Logger.Info("Обновление базы данных статистики");
       db.SeptStatictics();
      }
      catch (Exception exp)
      {
        UlcSrvLog.Logger.Error(exp);
      }
    }

    void GetNotTrueItemsRs(List<RsNotTrue> lstDevice, DbReader db)
    {
      Program.__cout_ulc_rs485 = 0;
      try
      {
        LstUncomp = null;
        int all = lstDevice.Count;
        __lstTaskUpdate = new List<Task>();
        __lstTaskRunner = new List<Task>();
        var iner = Task.Factory.StartNew(() =>
        {
          foreach (var item in lstDevice)
          {
            item.EvtItemRunComplite = RemoveTask;
            Task tsk = new Task(() =>
            {
              TcpClient client = null;
              try
              {
                client = GetConnection(item.ip_address, 10251);
                if (client == null)
                  throw new Exception(string.Format("Error connect to:{0}", item.ip_address));
                CurrentCfg cfg = null;
                cfg = new CurrentCfg();
                string msg = string.Empty;
                bool result = false;
                result = cfg.GetConfigIP(client, item.ip_address, out msg);
                if (result)
                {
                  item.Message = msg;
                  item.UlcCnfg = UlcCfg.TryExtarctFromMsg(msg);
                  if (item.UlcCnfg!=null) {
                    if ((item.UlcCnfg.CDIN >> 7) == 1)
                    {
                      item.is_true = true;
                      Interlocked.Increment(ref Program.__cout_ulc_rs485);
                    }
                  }
                }
                //Interlocked.Increment(ref Worker.__cout_request);
              }
              catch (Exception exp)
              {
              }
              finally
              {
                if (client != null)
                {
                  client.Close();
                }
                item.EvtItemRunComplite(item.OwnerTask);
              }
            });
            item.OwnerTask = tsk;
            __lstTaskRunner.Add(tsk);
          }
          for (int i = 0; i < __lstTaskRunner.Count; i++)
          {
            if (!Program.__service_run)
              return;
            if (__lstTaskUpdate.Count < 100)
            {
              lock (__lstTaskUpdate)
              {
                __lstTaskUpdate.Add(__lstTaskRunner[i]);
                __lstTaskRunner[i].Start();

              }
            }
            while (__lstTaskUpdate.Count == 100)
            {
              Thread.Sleep(1);
            }
          }
          while (__lstTaskUpdate.Count != 0)
          {
            Thread.Sleep(100);
          }
        });
        iner.Wait();
        UlcSrvLog.Logger.Info("Обновление базы данных по RS-485");
        db.UpdateMsgRs(lstDevice);
      }

      catch (Exception exp)
      {
        UlcSrvLog.Logger.Error(exp);
      }
    }

    void GetNotTrueItemsMeters(List<MeterValue> lstDevice, DbReader db)
    {
      Program.__cout_ulc_meters = 0;
      try
      {
        LstUncomp = null;
        int all = lstDevice.Count;
        __lstTaskUpdate = new List<Task>();
        __lstTaskRunner = new List<Task>();
        var iner = Task.Factory.StartNew(() =>
        {
          foreach (var item in lstDevice)
          {
            item.EvtItemRunComplite = RemoveTask;
            Task tsk = new Task(() =>
            {
              TcpClient client = null;
              try
              {
                client = GetConnection(item.ip, 10250);
                if (client == null)
                  throw new Exception(string.Format("Error connect to:{0}", item.ip));
                if (item.meter_type.Contains("СЕ102") || item.meter_type.Contains("CE102"))
                {
                  //Exception ex;
                  //float? value = EnMera102.GetSumDayValue(item.meter_factory, client, out ex);
                  MeterAllValues meterAllValues = EnMera102.GetSumAllValue(item.meter_factory, client);
                  if (meterAllValues != null)
                  {
                    item.value = meterAllValues.EnergySumDay.Value;
                    item.value_month = meterAllValues.EnergySumMonth.Value;
                    item.is_true = true;
                    item.date_time = DateTime.Now;
                  }
                  else
                  {
                    throw new Exception("ошибка получения данных");
                  }
                }
                else if (item.meter_type.Contains("СС") || item.meter_type.Contains("СС"))
                {
                  MeterAllValues meterAllValues = Granelectro.GetSumAllValue(item.meter_factory, client);
                  if (meterAllValues != null)
                  {
                    item.value = Math.Round(meterAllValues.EnergySumDay.Value, 2);
                    item.value_month = Math.Round(meterAllValues.EnergySumMonth.Value, 2);
                    item.is_true = true;
                    item.date_time = DateTime.Now;
                  }
                  else
                  {
                    throw new Exception("ошибка получения данных");
                  }
                }
                else if (item.meter_type.Contains("СЕ318") || item.meter_type.Contains("CE318"))
                {
                  MeterAllValues meterAllValues = EnMera318BY.GetSumAllValue(item.meter_factory, client);
                  //float value = 0;
                  //if (!EnMera318BY.GetValue(EnMera318Fun.EnergyStartDay, item.meter_factory, client, 10000, out value))
                  //throw new Exception("ошибка получения данных");
                  if (meterAllValues != null)
                  {
                    item.value = Math.Round(meterAllValues.EnergySumDay.Value, 2);
                    item.value_month = Math.Round(meterAllValues.EnergySumMonth.Value, 2);
                    item.is_true = true;
                    item.date_time = DateTime.Now;
                  }
                  else
                  {
                    throw new Exception("ошибка получения данных");
                  }
                }
                Interlocked.Increment(ref Program.__cout_request);
              }
              catch (Exception exp)
              {
                int x = 0;
              }
              finally
              {
                if (client != null)
                {
                  client.Close();
                }
                item.EvtItemRunComplite(item.OwnerTask);
              }
            });
            item.OwnerTask = tsk;
            __lstTaskRunner.Add(tsk);
          }
          for (int i = 0; i < __lstTaskRunner.Count; i++)
          {
            if (!Program.__service_run)
              return;
            if (__lstTaskUpdate.Count < 100)
            {
              lock (__lstTaskUpdate)
              {
                __lstTaskUpdate.Add(__lstTaskRunner[i]);
                __lstTaskRunner[i].Start();

              }
            }
            while (__lstTaskUpdate.Count == 100)
            {
              Thread.Sleep(1);
            }
          }
          while (__lstTaskUpdate.Count != 0)
          {
            Thread.Sleep(100);
          }
        });
        iner.Wait();
        UlcSrvLog.Logger.Info("Обновление базы данных по счетчикам");
        db.UpdateMetersValue(lstDevice);
      }

      catch (Exception exp)
      {
        UlcSrvLog.Logger.Error(exp);
      }
    }
  }
}
