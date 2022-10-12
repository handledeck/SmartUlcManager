﻿using InterUlc.CurCfg;
using InterUlc.Db;
using InterUlc.Logs;
using SmartUlcService.ini;
using SmartUlcService.NLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartUlcService.Service
{
  public class InterviewService
  {
    ConfigIni __configIni;
    public InterviewService(ConfigIni configIni)
    {
      try
      {
        __configIni = configIni;
        DbReader db = new DbReader(__configIni.IpDb, configIni.UserDb, __configIni.UserPwdDb);// uset.DbIp, uset.DbUser, uset.Db
         List<DbReqestNotTrue> ll = db.ReadNotTrueItems(DateTime.Now);
        //List<DbReqestNotTrue> ll = ReadEvent();
        UlcSrvLog.Logger.Info("Начало опроса {0}", DateTime.Now);
        UlcSrvLog.Logger.Info("Недоставерных данных по устройствам: {0}", ll.Count);
        //UlcSrvLog.Logger.Info("Недоставерн {0}", ll.Count);
        GetNotTrueItems(ll, db);
        UlcSrvLog.Logger.Info(string.Format("Опрошено:{0}", Program.__cout_request.ToString()));
        // List<RsNotTrueData> rsNotTrueDatas = db.GetNotTruerS485();
        //GetNotTrueItemsRs(rsNotTrueDatas, db, uset, cowr);
        //GetNotTrueItems(ll, db, uset, cowr);
        UlcSrvLog.Logger.Info("Окончание опроса:{0}", DateTime.Now);
      }
      catch (Exception exp)
      {
        UlcSrvLog.Logger.Error(exp.Message);
      }
    }

    static List<DbReqestNotTrue> ReadEvent()
    {
      //TcpClient client = GetConnection("172.22.130.143", 10251);
      //    Exception exp;
      DbReqestNotTrue dbReqestNotTrue = new DbReqestNotTrue();
      dbReqestNotTrue.IPAddres = "172.22.128.125"; //15482
      dbReqestNotTrue.ID = 13677;
      dbReqestNotTrue.TypeDevice = 1;
      List<DbReqestNotTrue> lstDevice = new List<DbReqestNotTrue>();
      lstDevice.Add(dbReqestNotTrue);
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
                client = GetConnection(item.IPAddres, 10251);// item.TypeDevice);
                if (client == null)
                  throw new Exception(string.Format("Error connect to:{0}", item.IPAddres));
                CurrentCfg cfg = null;
                cfg = new CurrentCfg();
                string msg = string.Empty;
                bool result = false;
                result = cfg.GetConfigIP(client, item.IPAddres, out msg);
                if (result)
                {
                  item.Message = msg;

                }
                if (item.TypeDevice == 1)
                {
                  NetworkStream stream = client.GetStream();
                  stream.ReadTimeout = 10000;
                  Exception exp;
                  List<Log> log = ParceLog.GetLogIP(stream, out exp);
                  if (log != null)
                  {
                    item.Logs = log;
                  }
                }
                Interlocked.Increment(ref Program.__cout_request);
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
        UlcSrvLog.Logger.Info("Обновление базы данных");
        db.InsertCfgMsg(lstDevice);
        db.WriteEventMessage(lstDevice);
        db.SeptStatictics();
      }

      catch (Exception exp)
      {
        UlcSrvLog.Logger.Error(exp);
      }
    }
  }
}
