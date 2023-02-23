using InterUlc.CurCfg;
using InterUlc.Logs;
using InterUlc.UlcCfg;
using Npgsql;
using NpgsqlTypes;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using ServiceStack.Script;
using SmartUlcService.NLogs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using WorkerService1;
using WorkerService1.Db;

namespace InterUlc.Db
{
  public delegate void ItemRunComplite(Task tsk);
  public class DbReqestNotTrue {

    public int id { get; set; }
    public string ip_address{ get; set; }
    public string message { get; set; }
    public int unit_type_id { get; set; }
    public object tag { get; set; }
    [Ignore]
    public List<Log> logs { get; set; }
    [Ignore]
    public ItemRunComplite EvtItemRunComplite { get; set; }
    [Ignore]
    public Task OwnerTask { get; set; }
    [Ignore]
    public UlcCfg.UlcCfg UlcCnfg { get; set; }
    
  }

  public class Node
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Node> Nodes;
    public string IP { get; set; }
    public string Phone { get; set; }
    public CurrentCfg Cfg { get; set; }
    public List<Log> Logs { get; set; }
    public string Message  { get; set; }
    public int Type { get; set; }
    public override string ToString()
    {
      return string.Format("id:{0} name:{1} count:{2}", Id, Name, Nodes.Count);
    }
  }

  public class DbReader
  {
    string dBIpAddress { get; set; }
    string DbUserName { get; set; }
    string DbPassword { get; set; }
    public List<Node> Nodes
    {
      get
      {
        return __nodes;
      }
    }
    public string __connection = string.Empty;
    List<Node> __nodes = null;
    NpgsqlConnection __dbConnection = null;

    public DbReader(string dBIpAddress, string DbUserName, string DbPassword)
    {
      this.dBIpAddress = dBIpAddress;
      this.DbUserName = DbUserName;
      this.DbPassword = DbPassword;
      __nodes = new List<Node>();
      this.__connection = string.Format("Host={0};Username={1};Password={2};Database=ctrl_mon_dev",
        this.dBIpAddress, this.DbUserName, this.DbPassword);
      this.__dbConnection = new NpgsqlConnection(this.__connection);
    }

    public void CheckRvpForStatistics()
    {
      //string sql = "select * from main_ctrlinfo mc where mc.unit_type_id =0";
      var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
                  __connection, PostgreSqlDialect.Provider);
      using (var db = dbFactory.Open())
      {
        List<MainInfo> mainInfos= db.Select<MainInfo>(x=>x.unit_type_id==0 && x.rs_stat==1);
        List<MainInfo> lstUpdate = new List<MainInfo>();
        foreach (var item in mainInfos)
        {
          if (item.rs_stat == 0) { 
            item.rs_stat = 1;
            lstUpdate.Add(item);
          }
        }
        if (lstUpdate.Count > 0) {
          db.Update<MainInfo>(lstUpdate.ToArray());
        }
        
      }
    }

    // очистка базы
    // удаление событий. храним 3 месяца
    internal void ServiceDbData()
    {
      DateTime dtn = DateTime.Now;
      DateTime dtEvent = dtn.AddDays(-30);
      DateTime dtCurrent = dtn.AddMonths(-6);
      try
      {
      var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
                  __connection, PostgreSqlDialect.Provider);
      using (var db = dbFactory.Open())
      {
        IDbCommand dbCommand = db.CreateCommand();
        string sql= string.Format("delete from main_ctrlevent me where me.event_time <'{0}'", dtEvent.ToString("yyyy-MM-dd"));
        dbCommand.CommandText = sql;
        int count=dbCommand.ExecuteNonQuery();
        UlcSrvLog.Logger.Info("Очистка базы событий. Удалено: {0}", count);
        sql = string.Format("delete from main_ctrlcurrent mc where mc.current_time <'{0}'", dtCurrent.ToString("yyyy-MM-dd"));
        dbCommand.CommandText = sql;
        count = dbCommand.ExecuteNonQuery();
        //UlcSrvLog.Logger.Info("Очистка базы данных. Удалено: {0}", count);
        sql = string.Format("delete from main_ctrldata mc where mc.current_time <'{0}'", dtCurrent.ToString("yyyy-MM-dd"));
        dbCommand.CommandText = sql;
        count = dbCommand.ExecuteNonQuery();
        UlcSrvLog.Logger.Info("Очистка базы данных о состоянии. Удалено: {0}", count);
      }
      }
      catch (Exception exp)
      {
        UlcSrvLog.Logger.Info("Ошибка очистки БД : {0}", exp.Message);
      }
    }

      public void ReadStatistic(string connString)
    {
      try
      {
        var dbFactory = new OrmLiteConnectionFactory(connString, PostgreSqlDialect.Provider);
        //string.Format(/*"Host={0};Username={1};Password={2};Database=ctrl_mon_dev",
        //   "10.32.18.38", "postgres", "pgp@ssdb"),*/connString, PostgreSqlDialect.Provider);

        using (var db = dbFactory.Open())
        {
          using (var cmd = db.OpenCommand())
          {

            var dat = cmd.ExecLongScalar("select count(*) from main_ctrlinfo");
            dat = cmd.ExecLongScalar("select count(*) from main_ctrlinfo mi where mi.unit_type_id=1");
            dat = cmd.ExecLongScalar("select count(*) from main_ctrlinfo mi where mi.unit_type_id=0");
            //не работает ком порт
            dat = cmd.ExecLongScalar(string.Format("select * from main_ctrldata where device_type =1 and((cdin >> 7) = 0) and \"current_time\" >'{0}'",
              DateTime.Now.ToString("yyyy-MM-dd")));

            List<MainInfo> lst = db.Select<MainInfo>("select count(*) from main_ctrlinfo mc where mc.unit_type_id =0");

          }
        }
      }
      catch (Exception e)
      {
        int x = 0;
      }
    }

    public void InsertMsgConfig(string message, int ctrlID)
    {
      try
      {
        this.__dbConnection.Open();
        var sql = "INSERT INTO main_ctrlcurrent(\"current_time\", body, ctrl_id) " +
            "VALUES(@time, @body, @ctrl_id)";
        var cmd = new NpgsqlCommand(sql, this.__dbConnection);
        cmd.Parameters.AddWithValue("time", DateTime.Now);
        cmd.Parameters.AddWithValue("body", message);
        cmd.Parameters.AddWithValue("ctrl_id", ctrlID);
        cmd.ExecuteNonQuery();
        this.__dbConnection.Close();
      }
      catch
      {
      }

      finally
      {
        if (this.__dbConnection.State == System.Data.ConnectionState.Open)
        {
          this.__dbConnection.Close();
        }
      }
    }


    void InsertDataTable(DbReqestNotTrue item, System.Data.IDbConnection conn) {
      try
      {
        UlcCfg.UlcCfg ulcCfg = new UlcCfg.UlcCfg();
        bool res = ulcCfg.GetExtarctRvpConfig(item.message);
        if (res)
        {
          ulcCfg.ctrl_id = item.id;
          ulcCfg.current_time = DateTime.Now;
          ulcCfg.DeviceType = item.unit_type_id;
          conn.Insert<UlcCfg.UlcCfg>(ulcCfg);
        }
      }
      catch (Exception e) {
        int x = 0;
      }
    }

    public bool CheckForRecordInDb(int ctrId, out int idCurrent, out int idData)
    {
      idCurrent = -1;
      idData = -1;
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
          __connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          string sql = string.Format("select * from main_ctrlcurrent mc where mc.ctrl_id ={0} and mc.\"current_time\" >'{1}'",
            ctrId, DateTime.Now.ToString("yyyy-MM-dd"));
          List<MainCurrent> lstCurrnet = db.Select<MainCurrent>(sql);
          if (lstCurrnet.Count > 0)
          {
            idCurrent = lstCurrnet[0].id;
          }
          sql = string.Format("select * from main_ctrldata md where md.ctrl_id ={0} and md.\"current_time\" >'{1}'",
          ctrId, DateTime.Now.ToString("yyyy-MM-dd"));
          List<MainInfo> lstData = db.Select<MainInfo>(sql);
          if (lstCurrnet.Count > 0)
          {
            idData = lstData[0].id;
          }

          return true;
        }
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public static JsonSerializerOptions GetSerializeOption()
    {
      JsonSerializerOptions options = new JsonSerializerOptions
      {
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin,
         UnicodeRanges.Cyrillic),
        WriteIndented = true
      };
      return options;
    }



    public DbLogs GetDbObjectPath(int id, IDbConnection connection) {
      string msg = string.Empty;
      string sql = string.Format("select mn.id, mn.\"name\" as tp ,mn2.\"name\" as res,mn3.\"name\" as fes, mc.ip_address as ip from main_nodes mn " +
      "right join main_nodes mn2 on mn.parent_id = mn2.id " +
      "right join main_nodes mn3 on mn2.parent_id = mn3.id " +
      "right join main_ctrlinfo mc on mn.id =mc.id " +
      "where mn.id = {0}", id);
      DbLogs lst = connection.Single<DbLogs>(sql);
      if (lst != null)
      {
        return lst;
        //msg = System.Text.Json.JsonSerializer.Serialize(lst[0], typeof(DbLogs), GetSerializeOption());
        //msg = string.Format("{0}/{1}/{2}",lst[0].Fes,lst[0].Res,lst[0].Tp);
      }
      else return null;

    }

    public OrmDbConfig GetLastRecordById(IDbConnection connection, int id) {
      string sql = String.Format("SELECT * FROM main_ctrldata mc " +
                  "WHERE ID = (SELECT MAX(ID) FROM main_ctrldata mc1 where mc1.ctrl_id = {0})", id);
      List<OrmDbConfig> lstMax = connection.Select<OrmDbConfig>(sql);
      if (lstMax.Count > 0)
      {
        return lstMax[0];
      }
      else {
        return null;
      }

    }

    string GetShortImei(string imei)
    {
      if (imei.Length < 15)
        return string.Empty;
      else
      return imei.Substring(imei.Length - 7, imei.Length - 8);
    }

    public void CheckDeviceIMEI(List<UlcCfg.UlcCfg> ulcCfgLst)
    {
      List<MainLogs> lstLog = new List<MainLogs>();
      var dbFactory = new OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
      using (var connection = dbFactory.Open())
      {
        foreach (var ulcCfg in ulcCfgLst)
        {
          try
          {
            string sql = string.Format("SELECT * FROM main_ctrldata mc " +
                  "WHERE id = (" +
                  "SELECT max(id) FROM main_ctrldata mc2 where mc2.ctrl_id = {0})", ulcCfg.ctrl_id);
            List<UlcCfg.UlcCfg> lstMax = connection.Select<UlcCfg.UlcCfg>(sql);
            if (lstMax.Count > 0)
            {
              DbLogs dbLogs = GetDbObjectPath(lstMax[0].ctrl_id, connection);

              string msg = string.Empty;
              if (lstMax[0].IMEI != ulcCfg.IMEI)
              {
                try
                {
                  string oImei = GetShortImei(lstMax[0].IMEI.ToString());
                  string nImei = GetShortImei(ulcCfg.IMEI.ToString());

                  if (!string.IsNullOrEmpty(oImei) || !string.IsNullOrEmpty(nImei))
                  {
                    dbLogs.feature = new ImeiStatAndRs()
                    {
                      old_imei = oImei,// GetShortImei(lstMax[0].IMEI.ToString()),
                      new_imei = nImei,//GetShortImei(ulcCfg.IMEI.ToString()),
                      rs_status = (lstMax[0].CDIN >> 7).ToString(),
                      rs_last_request = lstMax[0].current_time.ToString("dd.MM,yyyy hh:mm")
                    };
                    msg = System.Text.Json.JsonSerializer.Serialize(dbLogs, typeof(DbLogs), GetSerializeOption());
                    int en = (int)EnLogEvent.ChangeIMEI;
                    OrmDbConfig ormDbConfig = GetLastRecordById(connection, ulcCfg.ctrl_id);
                    MainLogs mainLogs = new MainLogs()
                    {
                      current_time = DateTime.Now,
                      id_user = 0,
                      usr_name = "служба опроса",
                      message = msg, //string.Format("{0}(dt:{1} imei:{2}=>{3} rs:{4})", msg, lstMax[0].current_time.ToString("dd.MM.yyyy HH:mm"),
                                     //GetShortImei(lstMax[0].IMEI.ToString()), GetShortImei(ulcCfg.IMEI.ToString()), (lstMax[0].CDIN >> 7).ToString()),
                      log_event = en,
                      host_from = Dns.GetHostEntry(Dns.GetHostName()).HostName,
                      ctrl_id= ulcCfg.ctrl_id,
                    };
                    connection.Insert<MainLogs>(mainLogs);
                  }
                }
                catch (Exception exp)
                {
                  throw;
                }
              }
              else if ((DateTime.Now - lstMax[0].current_time).TotalDays > 2)
              {
                try
                {
                  msg = System.Text.Json.JsonSerializer.Serialize(dbLogs, typeof(DbLogs), GetSerializeOption());
                  int en = (int)EnLogEvent.CHANGE_NET_STATE;
                  MainLogs mainLogs = new MainLogs()
                  {
                    current_time = DateTime.Now,
                    id_user = 0,
                    usr_name = "служба опроса",
                    message = msg,//string.Format("dt:{0}-{1}", ulcCfg.current_time.ToString("dd.MM.yyyy HH:mm"), msg),
                    log_event = en,
                    host_from = Dns.GetHostEntry(Dns.GetHostName()).HostName,
                    ctrl_id = ulcCfg.ctrl_id
                  };
                  long result=connection.Insert<MainLogs>(mainLogs);
                }
                catch (Exception exp)
                {
                  throw;
                }
              }
            }
          }
          catch (Exception exp)
          {
            int x = 0;
          }
        }
      }
    }

    public void UpdateMetersValue(List<MeterValue> meterValues)
    {
      List<MeterValue> mValues = new List<MeterValue>();
      var dbFactory = new OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
      using (var db = dbFactory.Open())
      {
        foreach (var item in meterValues)
        {
          if (item.is_true)
          {
            using (IDbTransaction dbTrans = db.OpenTransaction(IsolationLevel.ReadCommitted))
            {
              try
              {
                DateTime dtc = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                MeterValue mv = db.Single<MeterValue>(x => x.date_time > dtc && x.ctrl_id == item.ctrl_id);
                if (mv != null)
                {
                  item.id = mv.id;
                }
                db.Save<MeterValue>(item);

                dbTrans.Commit();
              }
              catch
              {
                dbTrans.Rollback();
              }
            }
          }
        }
      }
    }

    public void UpdateMsgRs(List<RsNotTrue> lstDevice)
    {
      var dbFactory = new OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
      using (var db = dbFactory.Open())
      {
        foreach (var item in lstDevice)
        {
          try
          {
            if (item.UlcCnfg != null)//!string.IsNullOrEmpty(item.Message))
            {
              if (item.is_true)
              {
                int xx = db.Update<MainCurrent>(new MainCurrent[] {new MainCurrent()
                      { id= item.cur_id,
                          ctrl_id= item.id,
                          body= item.Message,
                          current_time=DateTime.Now
                        }
                      });
                item.UlcCnfg.id = item.data_id;
                item.UlcCnfg.ctrl_id = item.id;
                item.UlcCnfg.current_time = DateTime.Now;
                item.UlcCnfg.DeviceType = item.device_type;
                xx = db.Update<UlcCfg.UlcCfg>(new UlcCfg.UlcCfg[] { item.UlcCnfg });
              }
            }
          }
          catch (Exception ex)
          {
          }
        }
      }
    }

    public void InsertCfgMsg(List<DbReqestNotTrue> lstDbReqestNotTrue)
    {
      List<MainCurrent> mainCurrents = new List<MainCurrent>();
      List<UlcCfg.UlcCfg> ulcCfgs = new List<UlcCfg.UlcCfg>();
      try
      {
        foreach (var item in lstDbReqestNotTrue)
        {
          if (item.UlcCnfg != null)
          {
            UlcCfg.UlcCfg ulcCfg = item.UlcCnfg;
            mainCurrents.Add(new MainCurrent()
            { ctrl_id = item.id, body = item.message, current_time = DateTime.Now });
            ulcCfg.ctrl_id = item.id;
            ulcCfg.current_time = DateTime.Now;
            ulcCfg.DeviceType = item.unit_type_id;
            ulcCfgs.Add(ulcCfg);
          }
        }
        if (ulcCfgs.Count == 0)
          return;
        CheckDeviceIMEI(ulcCfgs);
      }
      catch (Exception exp)
      {
        throw;
      }
      var dbFactory = new OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
      using (var db = dbFactory.Open())
      {
        
        DateTime dtc = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        if (mainCurrents.Count > 0)
        {
          using (IDbTransaction dbTrans = db.OpenTransaction(IsolationLevel.ReadCommitted))
          {
            try
            {
              foreach (var item in mainCurrents)
              {
                MainCurrent mainCurrent = db.Single<MainCurrent>(x => x.ctrl_id == item.ctrl_id && x.current_time > item.current_time);
                if (mainCurrent != null)
                  item.id = mainCurrent.id;
                db.Save<MainCurrent>(item);
              }
              dbTrans.Commit();
            }
            catch (Exception exp)
            {
              dbTrans.Rollback();
            }
          }
          if (ulcCfgs.Count > 0)
          {
            
            using (IDbTransaction dbTrans = db.OpenTransaction(IsolationLevel.ReadCommitted))
            {
              try
              {
                foreach (var item in ulcCfgs)
                {
                  UlcCfg.UlcCfg cfg = db.Single<UlcCfg.UlcCfg>(x => x.ctrl_id == item.ctrl_id && x.current_time > item.current_time);
                  if (cfg != null)
                    item.id = cfg.id;
                  db.Save<UlcCfg.UlcCfg>(item);
                }
                //db.Insert<MainCurrent>(mainCurrents.ToArray());
                //db.Insert<UlcCfg.UlcCfg>(ulcCfgs.ToArray());
                dbTrans.Commit();
              }
              catch (Exception exp)
              {
                dbTrans.Rollback();
              }
            }
          }
        }
      }
    }


    public void InsertCfgMsg(Node node)
    {
      try
      {
        this.__dbConnection.Open();
        var sql = "INSERT INTO main_ctrlcurrent(\"current_time\", body, ctrl_id) " +
            "VALUES(@time, @body, @ctrl_id)";
        var cmd = new NpgsqlCommand(sql, this.__dbConnection);
        cmd.Parameters.AddWithValue("time", DateTime.Now);
        cmd.Parameters.AddWithValue("body", node.Message);
        cmd.Parameters.AddWithValue("ctrl_id", node.Id);
        cmd.ExecuteNonQuery();
        this.__dbConnection.Close();
      }
      catch {
      }

      finally
      {
        if (this.__dbConnection.State == System.Data.ConnectionState.Open)
        {
          this.__dbConnection.Close();
        }
      }
    }

    public List<DbReqestNotTrue> ReadNotTrueItems(DateTime dt)
    {
      List<DbReqestNotTrue> reqestNotTrues;
      string s = string.Format("select mc.id, mc.ip_address ,mc.unit_type_id, mn.\"name\" as tag FROM main_ctrlinfo mc left join main_nodes mn on mc.id=mn.id left join main_ctrlcurrent ci on ci.ctrl_id = mc.id and ci.\"current_time\" > '{0}' where  mn.active =1 and ci.body isnull or ci.body = '' order by mc.unit_type_id", dt.ToString("yyyy-MM-dd"));
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
          __connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          reqestNotTrues = db.Select<DbReqestNotTrue>(s);
        }

      }
      catch (Exception ex)
      {
        return null;
      }
      return reqestNotTrues;
    }

    internal void InsertLogMsg(Node node)
    {
      int xx = 0; ;
      try
      {
        if (node.Logs != null)
        {
          //var con = new NpgsqlConnection(this.__connection);
          this.__dbConnection.Open();
          foreach (var item in node.Logs)
          {
            string evt = Log.ConvertToString(item);
            var sql = "Select * from main_ctrlevent where event_time=@etime and event_type=@etype and event_level=@elevel and ctrl_id=@ctrlid";
            var cmd = new NpgsqlCommand(sql, this.__dbConnection);
            cmd.Parameters.AddWithValue("etime", item.event_time);
            cmd.Parameters.AddWithValue("etype", item.event_type);
            cmd.Parameters.AddWithValue("elevel", (int)item.event_level);
            cmd.Parameters.AddWithValue("ctrlid", node.Id);
            //cmd.Parameters.AddWithValue("evalue", item.Log_Data);
            var dr_fes = cmd.ExecuteReader();
            bool res = dr_fes.Read();
            dr_fes.Close();
            //this.__dbConnection.Close();
            if (!res)
            {

              sql = "INSERT INTO main_ctrlevent(event_time, event_type, event_level, ctrl_id, event_msg) " +
                "VALUES(@event_time, @event_type, @event_level, @ctrl_id, @event_msg)";
              cmd = new NpgsqlCommand(sql, this.__dbConnection);
              cmd.Parameters.AddWithValue("event_time", item.event_time);
              cmd.Parameters.AddWithValue("event_type", item.event_type);
              //cmd.Parameters.AddWithValue("event_value", item.Log_Data);
              cmd.Parameters.AddWithValue("event_level", (int)item.event_level);
              cmd.Parameters.AddWithValue("ctrl_id", node.Id);
              cmd.Parameters.AddWithValue("event_msg", evt);
              cmd.ExecuteNonQuery();
              xx++;
            }

          }
          this.__dbConnection.Close();

        }

      }
      catch (Exception exp)
      {
        int x = 0;
      }
      finally
      {
        if (this.__dbConnection.State == System.Data.ConnectionState.Open)
        {
          this.__dbConnection.Close();
        }
      }

    }


    public void WriteBinaryData(List<DbReqestNotTrue> lstItems) {

      try
      {
        this.__dbConnection.Open();

        List<Log> listToUpdate = new List<Log>();
        NpgsqlCommand cmd_sel = null;
        string sql_sel = "SELECT \"event_time\" FROM main_ctrlevent mc where mc.ctrl_id=@id ORDER BY mc.\"event_time\" DESC LIMIT 1";
        //"Select * from main_ctrlevent where event_time=@etime and event_type=@etype and event_level=@elevel and ctrl_id=@ctrlid";
        string sql_ins = "INSERT INTO main_ctrlevent(event_time, event_type, event_level, ctrl_id, event_msg) VALUES";

        int ii = 0;
        foreach (var item in lstItems)
        {
          if (item.unit_type_id == 0)
            continue;
          else
          {
            if (item.logs == null)
              continue;
          }

          try
          {
            cmd_sel = new NpgsqlCommand(sql_sel, this.__dbConnection);
            cmd_sel.Parameters.AddWithValue("@id", item.id);
            //sql = string.Format("SELECT \"event_time\" FROM main_ctrlevent mc where mc.ctrl_id = {0} " +
            //"ORDER BY mc.\"event_time\" DESC LIMIT 1", item.ID);

            //cmd.CommandText = sql;// = new NpgsqlCommand(sql, this.__dbConnection);
            var dr = cmd_sel.ExecuteReader();
            if (dr.HasRows)
            {
              dr.Read();
              dr.Close();
              DateTime dtevt = (DateTime)dr[0];

              foreach (var lItem in item.logs)
              {
                if (lItem.event_time > dtevt)
                {
                  listToUpdate.Add(lItem);
                }
              }
            }

            //Console.WriteLine("Обраб {0}", ii++);

            if (listToUpdate.Count > 0)
            {
              //sql = "INSERT INTO main_ctrlevent(event_time, event_type, event_level, ctrl_id, event_msg) VALUES";
              //StringBuilder sb = new StringBuilder();
              //sb.Append(sql);
              //foreach (var itUpdate in listToUpdate)
              //{
              //  string val = string.Format("('{0}', {1}, {2}, {3}, '{4}'),",
              //      itUpdate.dt, itUpdate.Log_type, (int)itUpdate.Log_level, item.ID, itUpdate.EventMessage);
              //  sb.Append(val);
              //}
              //string vlue = sb.ToString();
              //if (!string.IsNullOrEmpty(vlue))
              //{
              //  cmd.CommandText = sql;
              //  vlue = vlue.TrimEnd(',');
              //  //cmd = new NpgsqlCommand(vlue, this.__dbConnection);
              //  cmd.ExecuteNonQuery();
              //}
            }
            else
            {

              //sql = "INSERT INTO main_ctrlevent(event_time, event_type, event_level, ctrl_id, event_msg) VALUES";
              //StringBuilder sb = new StringBuilder();
              //sb.Append(sql);
              //cmd.Parameters.Add(new NpgsqlParameter("aaa", NpgsqlTypes.NpgsqlDbType.Array))
              //foreach (var lItem in item.Logs)
              //{
              //  string val = string.Format("('{0}', {1}, {2}, {3}, '{4}'),",
              //    lItem.dt, lItem.Log_type, (int)lItem.Log_level, item.ID, lItem.EventMessage);
              //  sb.Append(val);
              //}
              //string vlue = sb.ToString();
              //if (!string.IsNullOrEmpty(vlue))
              //{
              //  vlue = vlue.TrimEnd(',');
              //  cmd.CommandText = vlue;

              //  //cmd = new NpgsqlCommand(vlue, this.__dbConnection);
              //  cmd.ExecuteNonQuery();
              //}
            }

          }
          catch (Exception exp)
          {
            int x = 0;
          }
        }
      }
      catch (Exception exp)
      {

      }
      finally
      {
        this.__dbConnection.Close();
      }
    }


    public bool CleanDbEvent() {

      try
      {
        string sql = string.Format("delete from main_ctrlevent mc where mc.event_time < '{0}'",
          DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd"));
        var connString = new NpgsqlConnectionStringBuilder(this.__connection)
        { CommandTimeout = 0 };
        using (var conn = new NpgsqlConnection(connString.ConnectionString))
        {
          conn.Open();
          using (var cmd = new NpgsqlCommand(sql, conn))
            cmd.ExecuteNonQuery();
        }
        return true;
      }
      catch (Exception exp)
      {

        return false;
      }
      finally {
        this.__dbConnection.Close();
      }
    }

    public void SeptStatictics()
    {
      DateTime dt = DateTime.Now;
      UlcSmalllStatistic ulcSmalllStatistic = GetStatistic(dt);
      ulcSmalllStatistic.current_time = DateTime.Now;
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
          __connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          //List<UlcSmalllStatistic> lst = db.Select<UlcSmalllStatistic>(o => o.current_time > DateTime.Now.Date);
          long id = db.Insert<UlcSmalllStatistic>(ulcSmalllStatistic, selectIdentity: true);
        }
      }
      catch (Exception ex)
      {
        int x = 0;
      }
    }

    public List<MeterValue> GetNotTrueMeters() {
      List<MeterInfo> rsMeters;
      List<MeterValue> rsNotTrue=new List<MeterValue>();
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
          __connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          
          string sql = string.Format("select mi.* from meter_info mi left join meter_value mv on mv.ctrl_id =mi.id and  mv.date_time >'{0}' where mv isnull and mi.active =1 and mi.meter_factory <>''", DateTime.Now.ToString("yyyy-MM-dd"));
          //string sql = string.Format("select mi.id as ctrl_id,mi.ip,mi.meter_type,mi.meter_factory,mv.date_time,mv.value,mv.is_true " +
          //                           "from meter_info mi " +
          //                           "left join meter_value mv on mi.id = mv.ctrl_id and mv.date_time > '{0}' " +
          //                           "left join main_nodes mn on mn.id = mi.ctrl_id " +
          //                           "left join main_ctrlinfo mc on mc.id = mi.ctrl_id and mn.active = 1 " +
          //                           "where mc.rs_stat =1 and mv.value isnull and mc.id notnull", DateTime.Now.ToString("yyyy-MM-dd"));


          rsMeters = db.Select<MeterInfo>(sql);
          
          foreach (var item in rsMeters)
          {
            rsNotTrue.Add(new MeterValue()
            {
              ctrl_id = item.id,
              ip = item.ip,
              meter_factory = item.meter_factory,
              meter_type = item.meter_type
            });
          }

        }
        return rsNotTrue;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public List<RsNotTrue> GetNotTruerRS485()
    {
      List<RsNotTrue> rsNotTruesReturn = new List<RsNotTrue>();
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
          __connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          string sql = string.Format("select mn.id ,mn.ip_address,mi.meter_factory,mi.meter_type, mc.id as data_id,mc2.id as cur_id,mc.device_type from main_ctrlinfo mn " +
                                  "left join main_ctrlcurrent mc2 on mn.id = mc2.ctrl_id and mc2.\"current_time\" > '{0}' " +
                                  "left join meter_info mi on mi.ctrl_id = mn.id " +
                                  "left join main_ctrldata mc on mc.ctrl_id = mn.id and(mc.cdin >> 7) = 0 " +
                                  "where mn.unit_type_id = 1 and mc.\"current_time\" > '{0}' and mn.rs_stat =1", DateTime.Now.ToString("yyyy-MM-dd"));
          List<RsNotTrue> rsNotTrues = db.Select<RsNotTrue>(sql);
          foreach (var item in rsNotTrues)
          {

            if (!rsNotTruesReturn.Contains(item))//<RsNotTrue>(item, new RsNotTrueComparer()))
            {
              rsNotTruesReturn.Add(item);
            }
          }
        }
        return rsNotTruesReturn;
      }
      catch (Exception ex)
      {
        return null;
      }
    }


    //public List<RsNotTrueData> GetNotTruerS485()
    //{
    //  try
    //  {
    //    var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
    //      __connection, PostgreSqlDialect.Provider);
    //    using (var db = dbFactory.Open())
    //    {
    //      string sql = string.Format("select mn.id, mc.id as id_data, mn.ip_address, mn.meters from main_ctrlinfo mn , main_ctrldata mc where mn.id = mc.ctrl_id and mn.unit_type_id = 1 and(mc.cdin >> 7) = 0 and mc.\"current_time\" > '{0}'",
    //        DateTime.Now.ToString("yyyy-MM-dd"));
    //      return db.Select<RsNotTrueData>(sql);

    //    }
    //  }
    //  catch (Exception ex)
    //  {
    //    return null;
    //  }
    //}

    public UlcSmalllStatistic GetStatistic(DateTime dt)
    {

      var consql = new NpgsqlConnection(this.__connection);
      UlcSmalllStatistic ulcStatistic = null;
      try
      {
        consql.Open();
        ulcStatistic = new UlcSmalllStatistic();

        //Выбор всех объектов
        var sql = "select count(*) from main_nodes mn where mn.node_kind_id =3 and active =1";
        var cmd = new NpgsqlCommand(sql, consql);
        ulcStatistic.all = (long)cmd.ExecuteScalar();

        //Всего РВП
        sql = "select count(*) from main_nodes mn2, main_ctrlinfo mc where mn2.node_kind_id =3 and active =1 and mn2.id =mc.id and mc.unit_type_id =0";
        cmd.CommandText = sql;
        ulcStatistic.allrvp = (long)cmd.ExecuteScalar();
        //Всего ULC
        sql = "select count(*) from main_nodes mn2, main_ctrlinfo mc where mn2.node_kind_id =3 and active =1 and mn2.id =mc.id and mc.unit_type_id =1";
        cmd.CommandText = sql;
        ulcStatistic.allulc = (long)cmd.ExecuteScalar();
        //Всего не на связи
        sql = string.Format("select count(mi.id) from main_nodes mi " +
                           "left join main_ctrlinfo mc on mc.id = mi.id " +
                           "left join main_ctrldata mc2 on mc2.ctrl_id = mc.id and mc2.\"current_time\" > '{0}' " +
                           "where(mc.unit_type_id = 1 or mc.unit_type_id = 0)  and mc2.id isnull and mi.active = 1", DateTime.Now.ToString("yyyy-MM-dd"));
        //sql = string.Format("select count(*) from main_ctrlinfo mn ,main_ctrldata mc where mn.id =mc.ctrl_id and mc.\"current_time\" >'{0}'", dt.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        long nn = (long)cmd.ExecuteScalar();
        ulcStatistic.neterrorall = nn;// ulcStatistic.all - nn;
        //Всего нет связи по RS
        sql = string.Format("WITH temporaryTable(id) as " +
           "(SELECT * from main_ctrlinfo mc where mc.unit_type_id=1 and mc.rs_stat=1) " +
            "select count(md.id) FROM temporaryTable, main_ctrldata md where temporaryTable.id=md.ctrl_id and md.\"current_time\" > '{0}' and (md.cdin >>7)=0", DateTime.Now.ToString("yyyy-MM-dd"));
        // sql = string.Format("select count(*) from main_ctrlinfo mn ,main_ctrldata mc where mn.id = mc.ctrl_id and mn.unit_type_id =1 and (mc.cdin >>7)=0 and mc.\"current_time\" >'{0}'", dt.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        ulcStatistic.all_rs_errorrs = (long)cmd.ExecuteScalar();
        //Всего слабый сигнал GSM
        sql = string.Format("select count(*) from main_ctrlinfo mn ,main_ctrldata mc where mn.id = mc.ctrl_id and  ((-113 + (mc.signal) * 2))<-100 and mc.\"current_time\" >'{0}'", dt.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        ulcStatistic.allerrorgsm = (long)cmd.ExecuteScalar();
        // Всего контроллеров ULC не на связи
        //sql = string.Format("select count(*) from main_ctrlinfo mn ,main_ctrldata mc where mn.id =mc.ctrl_id and mn.unit_type_id =1 and mc.\"current_time\" >'{0}'", dt.ToString("yyyy-MM-dd"));
        sql = string.Format("select count(mi.id) from main_nodes mi " +
                            "left join main_ctrlinfo mc on mc.id = mi.id " +
                            "left join main_ctrldata mc2 on mc2.ctrl_id = mc.id and mc2.\"current_time\" > '{0}' " +
                            "where mc.unit_type_id = 1 and mc2.id isnull and mi.active = 1", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        nn = (long)cmd.ExecuteScalar();
        ulcStatistic.neterrorulc = nn;// ulcStatistic.allulc - nn;
        // всего ulc ошибка RS 
        ulcStatistic.ulc_rs_errorrs = ulcStatistic.all_rs_errorrs;
        //всего ulc GSM  
        sql = string.Format("select count(*) from main_ctrlinfo mn ,main_ctrldata mc where mn.id = mc.ctrl_id and mn.unit_type_id =1 and  ((-113 + (mc.signal) * 2))<-100 and mc.\"current_time\" >'{0}'", dt.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        ulcStatistic.ulcerrorgsm = (long)cmd.ExecuteScalar();
        // Всего контроллеров RVP не на связи
        //sql = string.Format("select count(*) from main_ctrlinfo mn ,main_ctrldata mc where mn.id =mc.ctrl_id and mn.unit_type_id =0 and mc.\"current_time\" >'{0}'", dt.ToString("yyyy-MM-dd"));
        sql = string.Format("select count(mi.id) from main_nodes mi " +
                          "left join main_ctrlinfo mc on mc.id = mi.id " +
                          "left join main_ctrldata mc2 on mc2.ctrl_id = mc.id and mc2.\"current_time\" > '{0}' " +
                          "where mc.unit_type_id = 0 and mc2.id isnull and mi.active = 1", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        nn = (long)cmd.ExecuteScalar();
        ulcStatistic.neterrorrvp = nn;// ulcStatistic.allrvp - nn;
        //всего рвп неисправность rs
        ulcStatistic.rvp_rs_errorrs = 0;
        //всего rvp GSM
        sql = string.Format("select count(*) from main_ctrlinfo mn ,main_ctrldata mc where mn.id = mc.ctrl_id and mn.unit_type_id =0 and  ((-113 + (mc.signal) * 2))<-100 and mc.\"current_time\" >'{0}'", dt.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        ulcStatistic.rvperrorgsm = (long)cmd.ExecuteScalar();


        consql.Close();
      }
      catch (Exception exp)
      {
        return null;
      }
      finally
      {

        consql.Close();
      }
      return ulcStatistic;

    }

    public void WriteEventMessage_1(List<DbReqestNotTrue> lstItems)
    {
     // string sql = "SELECT * FROM main_ctrlevent me where me.ctrl_id = {0} order by me.id desc limit 1";
      var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
            __connection, PostgreSqlDialect.Provider);
      uint dt_val = ParceLog.rtc_calendar_datetime_to_register_value(DateTime.Now.AddDays(-30));
      using (var db = dbFactory.Open())
      {
        foreach (var item in lstItems)
        {
          if (item.unit_type_id == 0)
            continue;
          try
          {
            if (item.logs == null)
              continue;
            List<Log> list = new List<Log>();
            string sqlItem = string.Format("SELECT * FROM main_ctrlevent me where me.ctrl_id = {0} order by me.msg_all desc limit 1", item.id);
            Log log = db.Single<Log>(sqlItem);
            if (log != null)
              dt_val = (uint)log.msg_all;
            if (log != null)
            {
              for (int i = item.logs.Count - 1; i >= 0; i--)
              {
                if (item.logs[i].msg_all > dt_val)
                {
                  list.Add(item.logs[i]);
                }
                else
                  break;
              }
              if (list.Count > 0)
              {
                db.Insert<Log>(list.ToArray());
              }
            }
            //else
            //{
            //  for (int i = item.logs.Count - 1; i >= 0; i--)
            //  {
            //    if (item.logs[i].msg_all > dt_val)
            //    {
            //      list.Add(item.logs[i]);
            //    }
            //    else
            //      break;
            //  }
            //  if (list.Count > 0)
            //  {

            //    db.Insert<Log>(list.ToArray());
            //  }
            //}
          }
          catch (Exception exc)
          {
            int x = 0;
          }
        }
      }
    }

    public void WriteEventMessage(List<DbReqestNotTrue> lstItems)
    {
      try
      {
        this.__dbConnection.Open();
        List<Log> listToUpdate = null;
        NpgsqlCommand cmd_sel = null;
        NpgsqlCommand cmd_ins = null;
        string sql_sel = "SELECT \"event_time\" FROM main_ctrlevent mc where mc.ctrl_id=@id ORDER BY mc.\"event_time\" DESC LIMIT 1";
        //"Select * from main_ctrlevent where event_time=@etime and event_type=@etype and event_level=@elevel and ctrl_id=@ctrlid";
        string sql_ins = "INSERT INTO main_ctrlevent(\"event_time\", event_type, event_level, ctrl_id,event_msg) " +
          "VALUES(@event_time, @event_type, @event_level, @ctrl_id,@event_msg)";
        cmd_ins = new NpgsqlCommand(sql_ins, this.__dbConnection);
        cmd_ins.Parameters.Add(new NpgsqlParameter("@event_time", NpgsqlTypes.NpgsqlDbType.TimestampTz));
        //cmd_ins.Parameters[0].Value = lstColumns.__event_time.ToArray();
        cmd_ins.Parameters.Add(new NpgsqlParameter("@event_type", NpgsqlDbType.Integer));
        //cmd_ins.Parameters[1].Value = lstColumns.__event_type.ToArray();
        cmd_ins.Parameters.Add(new NpgsqlParameter("@event_level", NpgsqlDbType.Integer));
        //cmd_ins.Parameters[2].Value = lstColumns.__event_level.ToArray();
        cmd_ins.Parameters.Add(new NpgsqlParameter("@ctrl_id", NpgsqlDbType.Integer));
        //cmd_ins.Parameters[3].Value = lstColumns.__ctrl_id.ToArray();
        cmd_ins.Parameters.Add(new NpgsqlParameter("@event_msg", NpgsqlDbType.Varchar));
        cmd_ins.Prepare();
        //string sql = string.Empty;
        //NpgsqlCommand cmd = new NpgsqlCommand(sql, this.__dbConnection);
        //LstColumns lstColumns = new LstColumns();
        int ii = 0;
        foreach (var item in lstItems)
        {
          if (item.unit_type_id == 0)
            continue;
          else {
            if (item.logs == null)
              continue;
          }
          try
          {
            listToUpdate = new List<Log>();
            DateTime dts = DateTime.Now.AddDays(-3);
            //sql = string.Format("SELECT \"event_time\" FROM main_ctrlevent mc where mc.ctrl_id = {0} " +
            //"ORDER BY mc.\"event_time\" DESC LIMIT 1", item.ID);

            //cmd.CommandText = sql;// = new NpgsqlCommand(sql, this.__dbConnection);
            cmd_sel = new NpgsqlCommand(sql_sel, this.__dbConnection);
            cmd_sel.Parameters.AddWithValue("@id", item.id);
            var dr = cmd_sel.ExecuteReader();
            if (dr.HasRows)
            {
              dr.Read();
              DateTime dtevt = (DateTime)dr[0];
              //DateTime dts = DateTime.Now.AddDays(-30);
              foreach (var lItem in item.logs)
              {
                if (lItem.event_time>dts)
                {
                  if (lItem.event_time > dtevt)
                    //lstColumns.AddRecord(lItem.dt, lItem.Log_type, (int)lItem.Log_level, item.ID, lItem.EventMessage);
                  listToUpdate.Add(lItem);
                  //{ 
                    
                  //}
                }
              }
            }
            
            dr.Close();
            //Console.WriteLine("Обраб {0}", ii++);
            
            //cmd_ins.Parameters[4].Value = lstColumns.__event_msg.ToArray();
            
            //cmd_ins.CommandText = "INSERT INTO main_ctrlevent(event_time, event_type, event_level, ctrl_id) VALUES (@event_time, @event_type, @event_level, @ctrl_id, @event_msg, @event_msg)";

            if (listToUpdate.Count > 0)
            {
              NpgsqlTransaction tran = this.__dbConnection.BeginTransaction();
              try
              {
                foreach (var itLog in listToUpdate)
                {
                  cmd_ins.Parameters[0].Value = itLog.event_time;// lstColumns.__event_msg.ToArray();
                  cmd_ins.Parameters[1].Value = itLog.event_type;
                  cmd_ins.Parameters[2].Value = (int)itLog.event_level;
                  cmd_ins.Parameters[3].Value = item.id;
                  cmd_ins.Parameters[4].Value = itLog.event_msg;
                  cmd_ins.ExecuteNonQuery();
                }
                tran.Commit();
              }
              catch (Exception e)
              {
                tran.Rollback();
                throw;
              }

              //sql = "INSERT INTO main_ctrlevent(event_time, event_type, event_level, ctrl_id) VALUES";
              //StringBuilder sb = new StringBuilder();
              //sb.Append(sql);
              //foreach (var itUpdate in listToUpdate)
              //{
              //  string val = string.Format("('{0}', {1}, {2}, {3}),",
              //      itUpdate.dt, itUpdate.Log_type, (int)itUpdate.Log_level, item.ID/*, itUpdate.EventMessage*/);
              //  sb.Append(val);
              //}
              //string vlue = sb.ToString();
              //if (!string.IsNullOrEmpty(vlue))
              //{

              //  vlue = vlue.TrimEnd(',');
              //  cmd.CommandText = vlue;
              //  //cmd = new NpgsqlCommand(vlue, this.__dbConnection);
              //  cmd.ExecuteNonQuery();
              //}
            }
            else
            {
              //lstColumns.AddRange(item, item.ID);
              
              NpgsqlTransaction tran = this.__dbConnection.BeginTransaction();
              try
              {
                int iCom = 0;
                foreach (var itLog in item.logs)
                {
                  if (itLog.event_time >dts)
                  {
                    cmd_ins.Parameters[0].Value = itLog.event_time;// lstColumns.__event_msg.ToArray();
                    cmd_ins.Parameters[1].Value = itLog.event_type;
                    cmd_ins.Parameters[2].Value = (int)itLog.event_level;
                    cmd_ins.Parameters[3].Value = item.id;
                    cmd_ins.Parameters[4].Value = itLog.event_msg;
                    cmd_ins.ExecuteNonQuery();
                    iCom++;
                  }
                }
                //if(iCom>0)
                tran.Commit();
              }
              catch (Exception e)
              {
                tran.Rollback();
                throw;
              }


              //cmd_ins.Parameters.Add("@event_time",NpgsqlTypes.NpgsqlDbType.Array)
             // dr = cmd_ins.ExecuteReader();
              //sql = "INSERT INTO main_ctrlevent(event_time, event_type, event_level, ctrl_id) VALUES";
              //StringBuilder sb = new StringBuilder();
              //sb.Append(sql);

              //foreach (var lItem in item.Logs)
              //{
              //  string val = string.Format("('{0}', {1}, {2}, {3}),",
              //    lItem.dt, lItem.Log_type, (int)lItem.Log_level, item.ID/*, lItem.EventMessage*/);
              //  sb.Append(val);
              //}
              //string vlue = sb.ToString();
              //if (!string.IsNullOrEmpty(vlue))
              //{
              //  vlue = vlue.TrimEnd(',');
              //  cmd.CommandText = vlue;
              //  //cmd = new NpgsqlCommand(vlue, this.__dbConnection);
              //  cmd.ExecuteNonQuery();
              //}
            }

          }
          catch (Exception exp)
          {
            int x = 0;
          }
        }
      }
      catch (Exception exp)
      {
        
      }
      finally
      {
        this.__dbConnection.Close();
      }
    }


    internal void InsertLogMsg(List<DbReqestNotTrue> lstItems)
    {
      foreach (var node in lstItems)
      {
        try
        {
          if (node.logs != null)
          {
            //var con = new NpgsqlConnection(this.__connection);
            this.__dbConnection.Open();
            foreach (var item in node.logs)
            {
              string evt = Log.ConvertToString(item);
              var sql = "Select * from main_ctrlevent where event_time=@etime and event_type=@etype and event_level=@elevel and ctrl_id=@ctrlid";
              var cmd = new NpgsqlCommand(sql, this.__dbConnection);
              cmd.Parameters.AddWithValue("etime", item.event_time);
              cmd.Parameters.AddWithValue("etype", item.event_type);
              cmd.Parameters.AddWithValue("elevel", (int)item.event_level);
              cmd.Parameters.AddWithValue("ctrlid", node.id);
              //cmd.Parameters.AddWithValue("evalue", item.Log_Data);
              var dr_fes = cmd.ExecuteReader();
              bool res = dr_fes.Read();
              dr_fes.Close();
              //this.__dbConnection.Close();
              if (!res)
              {
                sql = "INSERT INTO main_ctrlevent(event_time, event_type, event_level, ctrl_id, event_msg) " +
                  "VALUES(@event_time, @event_type, @event_level, @ctrl_id, @event_msg)";
                cmd = new NpgsqlCommand(sql, this.__dbConnection);
                cmd.Parameters.AddWithValue("event_time", item.event_time);
                cmd.Parameters.AddWithValue("event_type", item.event_type);
                //cmd.Parameters.AddWithValue("event_value", item.Log_Data);
                cmd.Parameters.AddWithValue("event_level", (int)item.event_level);
                cmd.Parameters.AddWithValue("ctrl_id", node.id);
                cmd.Parameters.AddWithValue("event_msg", evt);
                cmd.ExecuteNonQuery();
              }
            }
            this.__dbConnection.Close();
          }
        }
        catch (Exception exp)
        {
          int x = 0;
        }
        finally
        {
          if (this.__dbConnection.State == System.Data.ConnectionState.Open)
          {
            this.__dbConnection.Close();
          }
        }
      }
    }

    public bool getDTREC(Node node)
    {
      try
      {
        this.__dbConnection.Open();
        var sql = string.Format("select \"current_time\",body from public.main_ctrlcurrent where " +
                  "\"current_time\" = (SELECT MAX(\"current_time\") FROM public.main_ctrlcurrent) and ctrl_id = {0}", node.Id);
        var cmd = new NpgsqlCommand(sql, this.__dbConnection);
        //cmd.Parameters.AddWithValue("ids", rec);
        var dr_fes = cmd.ExecuteReader();
        if (!dr_fes.Read())
          return false;
        DateTime dtn = DateTime.Now;
        DateTime dtl = new DateTime(dtn.Year, dtn.Month, dtn.Day, 0, 0, 0);
        DateTime curt = (DateTime)dr_fes[0];
        string msg= (string)dr_fes[1];
        dr_fes.Close();
        this.__dbConnection.Close();
        if (dtl == curt)
        {
          node.Message = msg;
          return true;
        }
        else
          return false;
      }

      catch (Exception exp)
      {
        return false;
      }
      finally {
        if (this.__dbConnection.State == System.Data.ConnectionState.Open)
        {
          this.__dbConnection.Close();
        }
      }
    } 

    public void ReadDataBase()
    {
      //ipaddress=10.32.18.38
      //username=postgres
      //password=pgp@ssdb
      //var cs = string.Format("Host={0};Username={1};Password={2};Database=ctrl_mon_dev",this.dBIpAddress,this.DbUserName,this.DbPassword);
      NpgsqlConnection con_fes=null;
      NpgsqlConnection con_res=null;
      NpgsqlConnection con_tp=null;
      try
      {
        con_fes = new NpgsqlConnection(this.__connection);
        con_fes.Open();
        var sql_fes = "SELECT * FROM main_nodes where(parent_id is NULL)";
        var cmd_fes = new NpgsqlCommand(sql_fes, con_fes);
        var dr_fes = cmd_fes.ExecuteReader();

        while (dr_fes.Read())
        {
          List<Node> lst_res = new List<Node>();
          con_res = new NpgsqlConnection(this.__connection);
          con_res.Open();
          var sql_res = string.Format("SELECT * FROM main_nodes where(parent_id={0})", (int)dr_fes[0]);
          var cmd_res = new NpgsqlCommand(sql_res, con_res);
          var dr_res = cmd_res.ExecuteReader();
          while (dr_res.Read())
          {
            List<Node> lst_tp = new List<Node>();
            con_tp = new NpgsqlConnection(this.__connection);
            con_tp.Open();
            var sql_tp = string.Format("SELECT * FROM main_nodes where(parent_id={0})", (int)dr_res[0]);
            var cmd_tp = new NpgsqlCommand(sql_tp, con_tp);
            var dr_tp = cmd_tp.ExecuteReader();
            while (dr_tp.Read())
            {
              var sql_ip = string.Format("SELECT * FROM main_ctrlinfo where(id={0})", (int)dr_tp[0]);
              var con_ip = new NpgsqlConnection(this.__connection);
              var cmd_ip = new NpgsqlCommand(sql_ip, con_ip);
              con_ip.Open();
              var dr_ip = cmd_ip.ExecuteReader();
              while (dr_ip.Read())
              {
                lst_tp.Add(new Node() { Id = (int)dr_tp[0], Name = (string)dr_tp[1], IP = (string)dr_ip[1], Phone = (string)dr_ip[2], Type = (int)dr_ip[4], Nodes = null });
              }
              dr_ip.Close();
              con_ip.Close();
            }
            dr_tp.Close();
            con_tp.Close();
            lst_res.Add(new Node() { Id = (int)dr_res[0], Name = (string)dr_res[1], Nodes = lst_tp });
          }
          dr_res.Close();
          con_res.Close();
          __nodes.Add(new Node() { Id = (int)dr_fes[0], Name = (string)dr_fes[1], Nodes = lst_res });
        }
        dr_fes.Close();
        con_fes.Close();
      }
      catch(Exception exp)
      {
        //Console.WriteLine(exp.Message);
      }
      finally {
        if (con_fes != null)
        {
          if (con_fes.State == System.Data.ConnectionState.Open)
          {
            con_fes.Close();
          }
        }
        if (con_res != null)
        {
          if (con_res.State == System.Data.ConnectionState.Open)
          {
            con_res.Close();
          }
        }
        if (con_tp != null)
        {
          if (con_tp.State == System.Data.ConnectionState.Open)
          {
            con_tp.Close();
          }
        }
      }
     
    }
  }
}
