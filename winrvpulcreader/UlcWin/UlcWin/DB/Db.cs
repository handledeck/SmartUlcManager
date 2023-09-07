//using InterUlc.CurCfg;
//using InterUlc.Logs;
//using InterUlc.UlcCfg;
using InterUlc.Logs;
using Npgsql;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows.Forms;
using UlcWin;
using UlcWin.Controls.UlcMeterComponet;
using UlcWin.DB;
using UlcWin.Edit;
using UlcWin.Fota;
using UlcWin.Statistics;
using UlcWin.ui;
using static InterUlc.Logs.EnumLogs;

namespace InterUlc.Db
{
 

  public enum EnumViewDevType {
    RVP = 0,
    ULC2 = 1,
    ALL = 2
  }

  public class UNode : TreeNode
  {
    public int Id { get; set; }
    //public string Name { get; set; }
    //public List<Node> Nodes;
    public string IP { get; set; }
    public string Phone { get; set; }
    // public CurrentCfg Cfg { get; set; }
    //public List<Log> Logs { get; set; }
    public string Message { get; set; }
    public int Type { get; set; }
    public bool IsView { get; set; }
    public int AllItem { get; set; }
    public int NetItem { get; set; }
    public int NotNetItem { get; set; }
  }

  public class UlcStatistic {
    /// <summary>
    /// Общее колличество
    /// </summary>
    public long All { get; set; }
    public long AllRvp { get; set; }
    public long AllUlc { get; set; }
    public long NetErrorAll { get; set; }
    public long AllErrorRs { get; set; }
    public long AllErrorGsm { get; set; }

    public long NetErrorUlc { get; set; }
    public long UlcErrorRs { get; set; }
    public long UlcErrorGsm { get; set; }

    public long NetErrorRvp { get; set; }
    public long RvpErrorRs { get; set; }
    public long RvpErrorGsm { get; set; }

    public long AllUlcFirstOrTwo { get; set; }
    public long AllUlcFirstOrTwoOnNet { get; set; }
    public long AllUlcFirstOrTwoRsNotTrue { get; set; }
    public long AllUlcFirstOrTwoGsm { get; set; }
    public long AllUlcFirstOrTwoVersion { get; set; }

    public long AllUlcThreeOrFour { get; set; }
    public long AllUlcThreeOrFourOnNet { get; set; }
    public long AllUlcThreeOrFourRsNotTrue { get; set; }
    public long AllUlcThreeOrFourGsm { get; set; }
    public long AllUlcThreeOrFourVersion { get; set; }
    public long AllUlcFive { get; set; }
    public long AllUlcFiveOnNet { get; set; }
    public long AllUlcFiveRsNotTrue { get; set; }
    public long AllUlcFiveGsm { get; set; }
    public long AllUlcFiveVersion { get; set; }
    public long AllCRvp { get; set; }
    public long AllUusi { get; set; }
    public long AllCRvpNet { get; set; }
    public long AllUusiNet { get; set; }
  }
  public delegate void UpdateListObject();
  public class DbReader
  {
    public string __dBIpAddress { get; set; }
    public string __DbUserName { get; set; }
    public string __DbPassword { get; set; }
    public string __connection = string.Empty;
    public UNode __nodes = null;
    NpgsqlConnection __dbConnection = null;
    public UlcUser __ulcUser;
    public int __num = 0;
    public int __isTrue = 0;
    public int __notTrue = 0;
    //string __user_db = "postgres";
    //string __user_db_pwd = "pgp@ssdb";
    public bool __super_user = false;
    IPHostEntry __host = null;
    public event UpdateListObject UpdateListViewItems;
    public List<OrmDbLogs> GetAllLogsByEvent(int intLogEvet) {
      List<OrmDbLogs> lstOrmDbLogs = null;
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(this.__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          lstOrmDbLogs= db.Select<OrmDbLogs>(x=>x.log_event==intLogEvet);
          return lstOrmDbLogs;
        }
      }
      catch (Exception e)
      {
        return null;
      }

    }

   public void SetItemParent(List<ItemIp> itemIps, int new_parent) {
      var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(this.__connection, PostgreSqlDialect.Provider);
      using (var db = dbFactory.Open())
      {
        foreach (var itemIp in itemIps)
        {
          OrmDbNodes ormDbNodes = db.Single<OrmDbNodes>(x => x.id == itemIp.Id);
          List<MeterInfo> meterInfos = db.Select<MeterInfo>(x => x.parent_id == ormDbNodes.parent_id && x.ctrl_id == ormDbNodes.id);
          ormDbNodes.parent_id = new_parent;
          foreach (var item in meterInfos)
          {
            item.parent_id = new_parent;
          }
          int result = db.Update<OrmDbNodes>(ormDbNodes);
          int res = db.Update<MeterInfo>(meterInfos.ToArray());
        }
       
      }
      //int x = 0;
    }

    void GetNodeInfo() { 
    
    }

    public bool DbTestConnection()
    {
      using (SimpleWaitForm sfrm = new SimpleWaitForm())
      {
        sfrm.Text = "Соединение";
        sfrm.RunAction(new Action(() =>
        {
          try
          {
            sfrm.SetLabelText("Проверка соединения");
            if (CheckForUserConnection())
              sfrm.DialogResult = DialogResult.OK;
            else
              throw new Exception();
          }
          catch
          {
            sfrm.DialogResult = DialogResult.No;
          }
        }));
        DialogResult result = sfrm.ShowDialog();
        if (result == DialogResult.OK)
          return true;
        else return false;
      }
    }

    public UlcStatistic GetStatistic() {

      var consql = new NpgsqlConnection(this.__connection);
      UlcStatistic ulcStatistic = null;
      try
      {
        consql.Open();
        ulcStatistic = new UlcStatistic();

        //Выбор всех объектов
        var sql = "select count(*) from main_nodes mn where mn.node_kind_id =3 and active =1";
        var cmd = new NpgsqlCommand(sql, consql);
        ulcStatistic.All = (long)cmd.ExecuteScalar();

        //Всего РВП
        sql = "select count(*) from main_nodes mn2, main_ctrlinfo mc where mn2.node_kind_id =3 and active =1 and mn2.id =mc.id and mc.unit_type_id =0";
        cmd.CommandText = sql;
        ulcStatistic.AllRvp = (long)cmd.ExecuteScalar();
        //Всего ULC
        sql = "select count(*) from main_nodes mn2, main_ctrlinfo mc where mn2.node_kind_id =3 and active =1 and mn2.id =mc.id and mc.unit_type_id =1";
        cmd.CommandText = sql;
        ulcStatistic.AllUlc = (long)cmd.ExecuteScalar();
        //Всего не на связи
        sql = string.Format("select count(mi.id) from main_nodes mi "+
                            "left join main_ctrlinfo mc on mc.id = mi.id "+
                            "left join main_ctrldata mc2 on mc2.ctrl_id = mc.id and mc2.\"current_time\" > '{0}' "+
                            "where(mc.unit_type_id = 1 or mc.unit_type_id = 0)  and mc2.id isnull and mi.active = 1", DateTime.Now.ToString("yyyy-MM-dd"));
        //sql = string.Format("select count(*) from main_ctrlinfo mn ,main_ctrldata mc where mn.id =mc.ctrl_id and mc.\"current_time\" >'{0}'", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        long nn = (long)cmd.ExecuteScalar();
        ulcStatistic.NetErrorAll = nn;// ulcStatistic.All - nn;
        //Всего нет связи по RS
        /* Учитывая активность по RS*/
         sql=string.Format("WITH temporaryTable(id) as "+
          "(SELECT * from main_ctrlinfo mc where mc.unit_type_id=1 and mc.rs_stat=1) "+
           "select count(md.id) FROM temporaryTable, main_ctrldata md where temporaryTable.id=md.ctrl_id and md.\"current_time\" > '{0}' and (md.cdin >>7)=0",  DateTime.Now.ToString("yyyy-MM-dd"));


        //sql = string.Format("select count(*) from main_ctrlinfo mn ,main_ctrldata mc where mn.id = mc.ctrl_id and mn.unit_type_id =1 and (mc.cdin >>7)=0 and mc.\"current_time\" >'{0}'", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        ulcStatistic.AllErrorRs = (long)cmd.ExecuteScalar();
        //Всего слабый сигнал GSM
        sql = string.Format("select count(*) from main_ctrlinfo mn ,main_ctrldata mc where mn.id = mc.ctrl_id and  ((-113 + (mc.signal) * 2))<-100 and mc.\"current_time\" >'{0}'", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        ulcStatistic.AllErrorGsm = (long)cmd.ExecuteScalar();
        // Всего контроллеров ULC не на связи
        sql = string.Format("select count(mi.id) from main_nodes mi " +
                            "left join main_ctrlinfo mc on mc.id = mi.id " +
                            "left join main_ctrldata mc2 on mc2.ctrl_id = mc.id and mc2.\"current_time\" > '{0}' " +
                            "where mc.unit_type_id = 1 and mc2.id isnull and mi.active = 1", DateTime.Now.ToString("yyyy-MM-dd"));

        //sql = string.Format("select count(*) from main_ctrlinfo mn ,main_ctrldata mc where mn.id =mc.ctrl_id and mn.unit_type_id =1 and mc.\"current_time\" >'{0}'", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        nn = (long)cmd.ExecuteScalar();
        ulcStatistic.NetErrorUlc = nn;//ulcStatistic.AllUlc -nn;
        // всего ulc ошибка RS 
        ulcStatistic.UlcErrorRs = ulcStatistic.AllErrorRs;
        //всего ulc GSM  
        sql = string.Format("select count(*) from main_ctrlinfo mn ,main_ctrldata mc where mn.id = mc.ctrl_id and mn.unit_type_id =1 and  ((-113 + (mc.signal) * 2))<-100 and mc.\"current_time\" >'{0}'", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        ulcStatistic.UlcErrorGsm = (long)cmd.ExecuteScalar();


        // Всего контроллеров RVP не на связи
        //sql = string.Format("select count(*) from main_ctrlinfo mn ,main_ctrldata mc where mn.id =mc.ctrl_id and mn.unit_type_id =0 and mc.\"current_time\" >'{0}'", DateTime.Now.ToString("yyyy-MM-dd"));
        sql = string.Format("select count(mi.id) from main_nodes mi " +
                           "left join main_ctrlinfo mc on mc.id = mi.id " +
                           "left join main_ctrldata mc2 on mc2.ctrl_id = mc.id and mc2.\"current_time\" > '{0}' " +
                           "where mc.unit_type_id = 0 and mc2.id isnull and mi.active = 1", DateTime.Now.ToString("yyyy-MM-dd"));

        cmd.CommandText = sql;
        nn = (long)cmd.ExecuteScalar();
        ulcStatistic.NetErrorRvp = nn;// ulcStatistic.AllRvp - nn;
        //всего рвп неисправность rs
        ulcStatistic.RvpErrorRs = 0;
        //всего rvp GSM
        sql = string.Format("select count(*) from main_ctrlinfo mn ,main_ctrldata mc where mn.id = mc.ctrl_id and mn.unit_type_id =0 and  ((-113 + (mc.signal) * 2))<-100 and mc.\"current_time\" >'{0}'", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        ulcStatistic.RvpErrorGsm = (long)cmd.ExecuteScalar();

        #region FirstOrTwo
        sql = "select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* FROM main_ctrlinfo mi " +
             "inner join main_nodes mn on mi.id = mn.id " +
             "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (" +
             "SELECT MAX(id) FROM main_ctrldata " +
             "GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
             "where mi.unit_type_id = 1 and mn.active=1 and " +
             "((V.imei - 353465070000000) < 1290000))foo";
        cmd.CommandText = sql;
        ulcStatistic.AllUlcFirstOrTwo = (long)cmd.ExecuteScalar();
        sql = string.Format("select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* FROM main_ctrlinfo mi " +
              "inner join main_nodes mn on mi.id = mn.id " +
              "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (" +
              "SELECT MAX(id) FROM main_ctrldata " +
              "GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
              "where mi.unit_type_id = 1  and mn.active=1 and V.current_time >'{0}' and  " +
              "((V.imei - 353465070000000) < 1290000))foo", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        long firstNet = (long)cmd.ExecuteScalar();
        ulcStatistic.AllUlcFirstOrTwoOnNet = ulcStatistic.AllUlcFirstOrTwo - firstNet;
        sql = string.Format("select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* FROM main_ctrlinfo mi " +
              "inner join main_nodes mn on mi.id = mn.id " +
              "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (" +
              "SELECT MAX(id) FROM main_ctrldata " +
              "GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
              "where mi.unit_type_id = 1 and mn.active=1 and V.current_time>'{0}' and  " +
              "((V.imei - 353465070000000) < 1290000) and  (V.cdin>>7=0))foo", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        ulcStatistic.AllUlcFirstOrTwoRsNotTrue = (long)cmd.ExecuteScalar();
        sql = "select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* FROM main_ctrlinfo mi " +
             "inner join main_nodes mn on mi.id = mn.id " +
             "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (" +
             "SELECT MAX(id) FROM main_ctrldata " +
             "GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
             "where mi.unit_type_id = 1 and mn.active=1 and " +
             "((V.imei - 353465070000000) < 1290000) and ((-113 + (V.signal) * 2))<-100)foo";
        cmd.CommandText = sql;
        ulcStatistic.AllUlcFirstOrTwoGsm = (long)cmd.ExecuteScalar();
        sql = "select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* FROM main_ctrlinfo mi " +
             "inner join main_nodes mn on mi.id = mn.id " +
             "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (" +
             "SELECT MAX(id) FROM main_ctrldata " +
             "GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
             "where mi.unit_type_id = 1 and mn.active=1 and " +
             "((V.imei - 353465070000000) < 1290000) and  V.svers='1.7.9')foo";
        cmd.CommandText = sql;
        ulcStatistic.AllUlcFirstOrTwoVersion = (long)cmd.ExecuteScalar();
        #endregion

        #region ThreeOrFour 

        sql = sql = "select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* FROM main_ctrlinfo mi " +
             "inner join main_nodes mn on mi.id = mn.id " +
             "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (" +
             "SELECT MAX(id) FROM main_ctrldata " +
             "GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
             "where mi.unit_type_id = 1 and mn.active=1 and " +
             "((V.imei-353465070000000) > 1290000 and  (V.imei-353465070000000) < 2000000))foo";
        cmd.CommandText = sql;
        ulcStatistic.AllUlcThreeOrFour = (long)cmd.ExecuteScalar();
        sql = string.Format("select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* FROM main_ctrlinfo mi " +
             "inner join main_nodes mn on mi.id = mn.id " +
             "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (" +
             "SELECT MAX(id) FROM main_ctrldata " +
             "GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
             "where mi.unit_type_id = 1 and V.current_time>'{0}' and  mn.active=1 and " +
             "((V.imei-353465070000000) > 1290000 and  (V.imei-353465070000000) < 2000000))foo", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        long threeNet = ulcStatistic.AllUlcThreeOrFour - (long)cmd.ExecuteScalar();
        ulcStatistic.AllUlcThreeOrFourOnNet = threeNet;
        sql = string.Format("select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* FROM main_ctrlinfo mi " +
             "inner join main_nodes mn on mi.id = mn.id " +
             "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (" +
             "SELECT MAX(id) FROM main_ctrldata " +
             "GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
             "where mi.unit_type_id = 1 and V.current_time>'{0}' and  mn.active=1 and " +
             "((V.imei-353465070000000) > 1290000 and  (V.imei-353465070000000) < 2000000) and  (V.cdin>>7=0))foo", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        ulcStatistic.AllUlcThreeOrFourRsNotTrue = (long)cmd.ExecuteScalar();
        sql = sql = "select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* FROM main_ctrlinfo mi " +
            "inner join main_nodes mn on mi.id = mn.id " +
            "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (" +
            "SELECT MAX(id) FROM main_ctrldata " +
            "GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
            "where mi.unit_type_id = 1 and mn.active=1 and " +
            "((V.imei-353465070000000) > 1290000 and  (V.imei-353465070000000) < 2000000) and ((-113 + (V.signal) * 2))<-100)foo";
        cmd.CommandText = sql;
        ulcStatistic.AllUlcThreeOrFourGsm = (long)cmd.ExecuteScalar();
        sql = sql = "select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* FROM main_ctrlinfo mi " +
            "inner join main_nodes mn on mi.id = mn.id " +
            "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (" +
            "SELECT MAX(id) FROM main_ctrldata " +
            "GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
            "where mi.unit_type_id = 1 and mn.active=1 and " +
            "((V.imei-353465070000000) > 1290000 and  (V.imei-353465070000000) < 2000000) and V.svers='1.7.9')foo";
        cmd.CommandText = sql;
        ulcStatistic.AllUlcThreeOrFourVersion = (long)cmd.ExecuteScalar();

        #endregion
        #region FiveVersion
        sql = sql = "select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* FROM main_ctrlinfo mi " +
            "inner join main_nodes mn on mi.id = mn.id " +
            "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (" +
            "SELECT MAX(id) FROM main_ctrldata " +
            "GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
            "where mi.unit_type_id = 1 and mn.active=1 and " +
            "((V.imei-353465070000000) > 2000000))foo";
        cmd.CommandText = sql;
        ulcStatistic.AllUlcFive = (long)cmd.ExecuteScalar();
        sql = string.Format("select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* FROM main_ctrlinfo mi " +
             "inner join main_nodes mn on mi.id = mn.id " +
             "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (" +
             "SELECT MAX(id) FROM main_ctrldata " +
             "GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
             "where mi.unit_type_id = 1 and V.current_time>'{0}' and  mn.active=1 and " +
             "((V.imei-353465070000000) > 2000000))foo", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        long fiveNet = ulcStatistic.AllUlcFive - (long)cmd.ExecuteScalar();
        ulcStatistic.AllUlcFiveOnNet = fiveNet;
        sql = string.Format("select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* FROM main_ctrlinfo mi " +
             "inner join main_nodes mn on mi.id = mn.id " +
             "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (" +
             "SELECT MAX(id) FROM main_ctrldata " +
             "GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
             "where mi.unit_type_id = 1 and V.current_time>'{0}' and  mn.active=1 and" +
             "((V.imei-353465070000000) > 2000000) and  (V.cdin>>7=0))foo", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        ulcStatistic.AllUlcFiveRsNotTrue = (long)cmd.ExecuteScalar();
        sql = string.Format("select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* FROM main_ctrlinfo mi " +
            "inner join main_nodes mn on mi.id = mn.id " +
            "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (" +
            "SELECT MAX(id) FROM main_ctrldata " +
            "GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
            "where mi.unit_type_id = 1 and V.current_time>'{0}' and  mn.active=1 and" +
            "((V.imei-353465070000000) > 2000000) and  ((-113 + (V.signal) * 2))<-100)foo", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        ulcStatistic.AllUlcFiveGsm = (long)cmd.ExecuteScalar();

        sql = string.Format("select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* FROM main_ctrlinfo mi " +
            "inner join main_nodes mn on mi.id = mn.id " +
            "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (" +
            "SELECT MAX(id) FROM main_ctrldata " +
            "GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
            "where mi.unit_type_id = 1 and V.current_time>'{0}' and  mn.active=1 and" +
            "((V.imei-353465070000000) > 2000000) and   V.svers='1.7.9')foo", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        ulcStatistic.AllUlcFiveVersion = (long)cmd.ExecuteScalar();
        #endregion

        #region RVP
        sql = "select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* " +
              "FROM main_ctrlinfo mi " +
              "inner join main_nodes mn on mi.id = mn.id " +
              "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (SELECT MAX(id) FROM main_ctrldata GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
              "where mi.unit_type_id = 0 and mn.active = 1 and V.svers is not null)foo";
        cmd.CommandText = sql;
        ulcStatistic.AllCRvp = (long)cmd.ExecuteScalar();
        sql = "select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* " +
              "FROM main_ctrlinfo mi " +
              "inner join main_nodes mn on mi.id = mn.id " +
              "INNER JOIN(SELECT* FROM main_ctrldata WHERE id IN (SELECT MAX(id) FROM main_ctrldata GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
              "where mi.unit_type_id = 0 and mn.active = 1 and V.svers is null)foo";
        cmd.CommandText = sql;
        ulcStatistic.AllUusi = (long)cmd.ExecuteScalar();

        sql = string.Format("select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* " +
                          "FROM main_ctrlinfo mi " +
                          "inner join main_nodes mn on mi.id = mn.id " +
                          "INNER JOIN(SELECT * FROM main_ctrldata WHERE id IN(SELECT MAX(id) FROM main_ctrldata GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
                          "where mi.unit_type_id = 0 and mn.active = 1 and V.svers is not null and V.current_time > '{0}')foo", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        ulcStatistic.AllCRvpNet = (long)cmd.ExecuteScalar();
        sql = string.Format("select count(*) from(select mn.id,mn.\"name\",mi.ip_address, mi.phone_num ,mi.unit_type_id ,mi.meters , V.* " +
                          "FROM main_ctrlinfo mi " +
                          "inner join main_nodes mn on mi.id = mn.id " +
                          "INNER JOIN(SELECT * FROM main_ctrldata WHERE id IN(SELECT MAX(id) FROM main_ctrldata GROUP BY ctrl_id)) AS V ON mi.id = V.ctrl_id " +
                          "where mi.unit_type_id = 0 and mn.active = 1 and V.svers is null and V.current_time > '{0}')foo", DateTime.Now.ToString("yyyy-MM-dd"));
        cmd.CommandText = sql;
        ulcStatistic.AllUusiNet = (long)cmd.ExecuteScalar();
        #endregion
        consql.Close();
      }
      catch (Exception exp)
      {
        return null;
      }
      finally {

        consql.Close();
      }
      return ulcStatistic;

    }

    public void SetStringConnection() {
      //this.__connection = string.Format("Host={0};Port={3};Username={1};Password={2};Database=ctrl_mon_dev",
      //this.__dBIpAddress, this.__user_db, this.__user_db_pwd, 5432);
      this.__connection = string.Format("Host={0};Port={3};Username={1};Password={2};Database=ctrl_mon_dev",
        this.__dBIpAddress, this.__DbUserName, this.__DbPassword, 5432);
    }

    public DbReader(string dBIpAddress, string DbUserName, string DbPassword)
    {

      this.__dBIpAddress = dBIpAddress;
      this.__DbUserName = DbUserName;
      this.__DbPassword = DbPassword;
      SetStringConnection();
      this.__dbConnection = new NpgsqlConnection(this.__connection);

    }

    Exception CheckForSuperUser(IDbCommand cmd) {
      Exception exc = null;
      string sql = string.Format("SELECT *FROM pg_catalog.pg_user where usename='{0}'", this.__DbUserName);
      try
      {
        cmd.CommandText=sql;
        NpgsqlDataReader rd=(NpgsqlDataReader)cmd.ExecuteReader();
        if (rd.HasRows)
        {
          if (rd.Read()) {
            bool supUsr = (bool)rd["usesuper"];
            if (supUsr == false)
              exc = new Exception();
          }
        }
        rd.Close();
      }
      catch (Exception e)
      {
        exc = e;
      }
      return exc;
    }



    public bool CheckForUserConnection()
    {
      NpgsqlConnection consql = null;
      try
      {
        
        this.__connection = string.Format("Host={0};Port={3};Username={1};Password={2};Database=ctrl_mon_dev",
       this.__dBIpAddress, this.__DbUserName, this.__DbPassword, 5432);
        var sql = string.Format("select * from main_user where usr='{0}'", this.__DbUserName);
        consql = new NpgsqlConnection(this.__connection);
        consql.Open();
        __host = Dns.GetHostEntry(Dns.GetHostName());
        var cmd = new NpgsqlCommand(sql, consql);
        __ulcUser = new UlcUser();
        if (CheckForSuperUser(cmd) == null)
        {
          __ulcUser.Id = -1;
          __ulcUser.User = this.__DbUserName;
          __ulcUser.Pwd = "";
          __ulcUser.NodesString = "";
          __ulcUser.Comment = "";
          __ulcUser.AccsessLavel = EnumAccsesLevel.Full;
          this.__super_user = true;
          return true;
        }
        else
        {
          cmd.CommandText = sql;
          var dr = cmd.ExecuteReader();

          if (dr.HasRows)
          {
            while (dr.Read())
            {
              __ulcUser.Id = (int)dr[0];
              __ulcUser.User = (string)dr[1];
              __ulcUser.Pwd = (string)dr[2];
              __ulcUser.NodesString = (string)dr[3];
              __ulcUser.Comment = (string)dr[4];
              __ulcUser.AccsessLavel = (EnumAccsesLevel)((int)dr[5]);
            }
            string al = DBAuthUtils.Decrypt(__ulcUser.Pwd, __ulcUser.User);
            int iAc;
            bool tPar = int.TryParse(al, out iAc);
            if (!tPar)
              return false;
            __ulcUser.AccsessLavel = (EnumAccsesLevel)iAc;
            if (__ulcUser.AccsessLavel == EnumAccsesLevel.SupUsr)
            {

              this.__super_user = true;
            }
            return true;
          }
          else
          {
            return false;
          }
        }
      }
      catch (Exception exp) 
      {
        return false;
      }
      finally {
        if (consql.State == System.Data.ConnectionState.Open)
          consql.Close();
      }
    }
    public List<UlcUser> GetAllUsers() {
      //Dictionary<int, string> utype = null;
      var sql = "select * from main_user";
      var consql = new NpgsqlConnection(this.__connection);
      var cmd = new NpgsqlCommand(sql, consql);
      consql.Open();
      var dr = cmd.ExecuteReader();
      List<UlcUser> ulcUserList = new List<UlcUser>();
      if (dr.HasRows)
      {
        while (dr.Read())
        {
          if (ulcUserList == null)
          {
            ulcUserList = new List<UlcUser>();
          }// new List<UlcUser>();)
          UlcUser ulcUser = new UlcUser();
          ulcUser.Id = (int)dr[0];
          ulcUser.User = (string)dr[1];
          ulcUser.Pwd = (string)dr[2];
          ulcUser.NodesString = (string)dr[3];
          ulcUser.Comment = (string)dr[4];
          int lvl = (int)dr[5];
          ulcUser.AccsessLavel = (EnumAccsesLevel)lvl;
          ulcUserList.Add(ulcUser);
        }
      }
      return ulcUserList;
    }

    void GetNodeItemInfo() { 
      
    }

    public bool CheckForUserRecord(string userName)//*int id, string user, string pwd, string comment, string items*/)
    {
      bool isRecord = false;
      try
      {
        var consql = new NpgsqlConnection(this.__connection);
        consql.Open();
        var sql = string.Format("select usr from main_user where usr='{0}'", userName);
        var cmd = new NpgsqlCommand(sql, consql);
        var dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
          isRecord = true;
        }
        else
        {
          isRecord = false;
        }
        consql.Close();
      }
      catch
      {
        isRecord = false;
      }
      return isRecord;

    }

    void UpdateUserRecordDB(IDbCommand cmd, string user_name)
    {
      //DeleteUserDb(cmd)
      //IDbCommand cmd = dbConnection.CreateCommand();
      //string sql = string.Format("ALTER USER {0} PASSWORD \"{1}\";", ulcUser.User, ulcUser.Pwd);
      //cmd.CommandText = sql;
      //object xx = cmd.ExecuteNonQuery();
      //sql = string.Format(
      //      "REVOKE ALL PRIVILEGES ON ALL TABLES IN SCHEMA public FROM {0}", ulcUser.User);

      //cmd.CommandText = sql;
      //cmd.ExecuteNonQuery();
      //sql = GetSqlStringForUser(ulcUser);
      //cmd.CommandText = sql;
      //cmd.ExecuteNonQuery();
    }

    public List<MeterInfo> GetMetrsById(int id)
    {
      List<MeterInfo> meterInfos = null;
      var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(this.__connection, PostgreSqlDialect.Provider);
      using (var db = dbFactory.Open())
      {
        meterInfos = db.Select<MeterInfo>(x => x.ctrl_id == id);
      }
      return meterInfos;
    }

    public int UpdateUserRecord(UlcUser ulcUser,string old_name_user)//*int id, string user, string pwd, string comment, string items*/)
    {
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(this.__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          IDbCommand cmd = db.CreateCommand();
          DeleteUserDb(cmd, old_name_user);
          SetGrandUser(ulcUser,cmd);
          string lvl = DBAuthUtils.Encrypt(((int)ulcUser.AccsessLavel).ToString(), ulcUser.User);
          var sql = string.Format("update public.main_user SET usr='{0}',pwd='{5}', items='{1}', \"comment\"='{2}', level={4} WHERE id = {3};"
                  , ulcUser.User, ulcUser.NodesString, ulcUser.Comment, ulcUser.Id, (int)ulcUser.AccsessLavel,lvl);
          
          cmd.CommandText = sql;
          int rowf = cmd.ExecuteNonQuery();
          return rowf;
        }
      }
      catch (Exception e)
      {
        return -1;
      }
    }

    void DeleteUserDb(IDbCommand cmd, string name)
    {
      try
      {
        string sql = string.Format("REVOKE ulc_read_write from {0}", name);
        cmd.CommandText = sql;
        int x = cmd.ExecuteNonQuery();
        sql = string.Format("DROP USER \"{0}\";", name);
        cmd.CommandText = sql;
        x = cmd.ExecuteNonQuery();
      }
      catch(Exception exp) {
        int x = 0;
      }
    }

    public int DeleteUserItem(int idRecord, string name) {
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(this.__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          string sql = string.Empty;
          IDbCommand dbc = db.CreateCommand();
          DeleteUserDb(dbc, name);
          sql = string.Format("DELETE FROM public.main_user WHERE id={0}", idRecord);
          dbc.CommandText = sql;
          int rowf = dbc.ExecuteNonQuery();
          return rowf;
        }
      }
      catch
      {
        return -1;
      }
    }


    string GetSqlStringForUser(UlcUser ulcUser) {
      string sql = string.Empty;
      switch (ulcUser.AccsessLavel)
      {
        case EnumAccsesLevel.SupUsr:
          break;
        case EnumAccsesLevel.Full:
          sql = string.Format("GRANT all ON ALL TABLES IN SCHEMA public TO {0};", ulcUser.User);
          break;
        case EnumAccsesLevel.ReadWrite:
          sql = string.Format("GRANT select,insert,update,delete ON ALL TABLES IN SCHEMA public TO {0};", ulcUser.User);
          break;
        case EnumAccsesLevel.Read:
          sql = string.Format("GRANT select,update ON ALL TABLES IN SCHEMA public TO {0};", ulcUser.User);
          break;
        default:
          break;
      }
      return sql;
    }


    void SetGrandUser(UlcUser ulcUser, IDbCommand cmd) {
      try
      {
        //IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = string.Format("CREATE USER \"{0}\" WITH PASSWORD '{1}'" +
            " NOSUPERUSER NOCREATEDB NOCREATEROLE INHERIT LOGIN NOREPLICATION NOBYPASSRLS CONNECTION LIMIT -1",
            ulcUser.User, ulcUser.Pwd);
        int result=cmd.ExecuteNonQuery();
        //if (ulcUser.AccsessLavel == EnumAccsesLevel.Read)
        //{
        //  cmd.CommandText = string.Format("GRANT ulc_read TO \"{0}\";", ulcUser.User);
        //  result=cmd.ExecuteNonQuery();
        //}
        //else if (ulcUser.AccsessLavel == EnumAccsesLevel.ReadWrite)
        //{
          cmd.CommandText = string.Format("GRANT ulc_read_write TO \"{0}\";", ulcUser.User);
          result=cmd.ExecuteNonQuery();
       // }
        cmd.CommandText = string.Format("ALTER ROLE {0} with password '{1}'", ulcUser.User, ulcUser.Pwd);
        result=cmd.ExecuteNonQuery();

      }
      catch (Exception e){
        int x = 0;
      }
    }

    public int InsertUser(UlcUser ulcUser)
    {
      try
      {
        string nItems = ulcUser.PackUlcItems();
        string sql = string.Empty;
        NpgsqlConnection consql = new NpgsqlConnection(this.__connection);
        consql.Open();
        var cmd = new NpgsqlCommand(sql, consql);
        SetGrandUser(ulcUser, cmd);
        //string usr = System.Text.Json.JsonSerializer.Serialize(ulcUser, 
          //typeof(UlcUser), DbLogMsg.GetSerializeOption());
        //string lvl=AesOperation.CreateEncrypt(ulcUser.User, ulcUser.AccsessLavel.ToString());
        string lvl = DBAuthUtils.Encrypt(((int)ulcUser.AccsessLavel).ToString(), ulcUser.User);
        sql = "INSERT INTO main_user(usr,pwd, items,comment,level) " +
            "VALUES(@usr, @pwd, @items,@comment,@level) RETURNING id";
       
        //cmd = new NpgsqlCommand(sql, consql);
        cmd.Parameters.AddWithValue("usr", ulcUser.User);
        cmd.Parameters.AddWithValue("pwd", lvl);
        cmd.Parameters.AddWithValue("items", ulcUser.NodesString);
        cmd.Parameters.AddWithValue("comment", ulcUser.Comment);
        cmd.Parameters.AddWithValue("level", (short)ulcUser.AccsessLavel);
        cmd.CommandText = sql;
        int rowf = (int)cmd.ExecuteScalar();
        
        consql.Close();
        return rowf;
      }
      catch (Exception exp)
      {
        return 0;
      }
    }

    public int UpdateTreeItem(string name, int idRecord, string node_full_path, SqlTreeNodes sqlTreeNodes)
    {
      string sql = string.Empty;
      try
      {
        var consql = new NpgsqlConnection(this.__connection);
        consql.Open();
        
        sql = string.Format("UPDATE public.main_nodes SET \"name\"=\'{0}\' WHERE id={1}", name, idRecord);
        var cmd = new NpgsqlCommand(sql, consql);
        int rowf = cmd.ExecuteNonQuery();
        DbLogMsg dbLogMsg = GetDbObjectPath(idRecord, consql, sqlTreeNodes);
        consql.Close();
        
        string msg = System.Text.Json.JsonSerializer.Serialize(dbLogMsg, typeof(DbLogMsg), DbLogMsg.GetSerializeOption());
        LogsInsertEvent(EnLogEvt.EDIT_NODE, msg,idRecord);
        return rowf;
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message,"Ошибка редактирования",MessageBoxButtons.OK,MessageBoxIcon.Error);
        return -1;
      }
    }

    public long? AddTreeItem(int? parentID, string name, string node_full_path, SqlTreeNodes sqlTreeNodes) {
      string sql = string.Empty;
      IDbTransaction iTrz = null;
      long? idR;
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
        this.__connection, PostgreSqlDialect.Provider);

        using (var db = dbFactory.Open())
        {
          using (iTrz = db.BeginTransaction())
          {
            OrmDbNodes ormDbNodes = new OrmDbNodes()
            {
              name = name,
              parent_id = parentID,
              node_kind_id = parentID == null ? 1 : 2,
            };
            idR = db.Insert<OrmDbNodes>(ormDbNodes, selectIdentity: true);
            DbLogMsg dbLogMsg = GetDbObjectPath((int)idR.Value, db, sqlTreeNodes);
            string msg = System.Text.Json.JsonSerializer.Serialize(dbLogMsg, typeof(DbLogMsg), DbLogMsg.GetSerializeOption());
            LogsInsertEvent(EnLogEvt.ADD_NODE, msg,(int)idR);
            iTrz.Commit();
          }

        }
        return idR;
      }
      catch
      {
        if (iTrz != null)
          iTrz.Rollback();
        return null;
      }
   


      //  var consql = new NpgsqlConnection(this.__connection);
      //consql.Open();

      //sql = "INSERT INTO main_nodes(name,node_kind_id , parent_id) " +
      //    "VALUES(@name, @node_kind_id, @parent_id) RETURNING id";
      //var cmd = new NpgsqlCommand(sql, consql);
      ////cmd = new NpgsqlCommand(sql, consql);
      //cmd.Parameters.AddWithValue("name", name);
      //cmd.Parameters.AddWithValue("node_kind_id", parentID == null ? 1 : 2);
      //cmd.Parameters.AddWithValue("parent_id", parentID == null ? (object)DBNull.Value : parentID.Value);
      //int rowf = (int)cmd.ExecuteScalar();
      //consql.Close();
      //DbLogMsg dbLogMsg = new DbLogMsg()
      //{
      //  Id = rowf
      //  //Item = name

      //};
      //if (parentID == null)
      //  dbLogMsg.Fes = node_full_path;
      //else {
      //  DbLogMsg.ParseNodePath(node_full_path, ref dbLogMsg);
      //}
      //string msg = System.Text.Json.JsonSerializer.Serialize(dbLogMsg, typeof(DbLogMsg), DbLogMsg.GetSerializeOption());
      //LogsInsertEvent(EnLogEvt.ADD_NODE, msg);
      //return rowf;
    }

    public List<int> GetListItemRoot(int idRoot, EnumViewDevType enmDevType) {
      List<int> lstRoot = null;
      string sql_ip = string.Empty;
      //switch (enmDevType)
      //{
      //  case EnumViewDevType.RVP:
      //  case EnumViewDevType.ULC2:
      //    sql_ip = string.Format("SELECT* FROM main_nodes mn full join main_ctrlinfo ci on ci.id = mn.id " +
      //        "where mn.parent_id = {0} and ci.unit_type_id={1} order by mn.name", idRoot, (int)enmDevType);
      //    break;
      //  case EnumViewDevType.ALL:
      //    sql_ip = string.Format("SELECT* FROM main_nodes mn full join main_ctrlinfo ci on ci.id = mn.id " +
      //        "where mn.parent_id = {0} order by mn.name", idRoot);
      //    break;
      //  default:
      //    break;
      //}
      sql_ip = string.Format(string.Format("select id from main_nodes where parent_id ={0}", idRoot));
      var con_ip = new NpgsqlConnection(this.__connection);
      var cmd_ip = new NpgsqlCommand(sql_ip, con_ip);
      con_ip.Open();
      var dr_ip = cmd_ip.ExecuteReader();

      while (dr_ip.Read())
      {
        if (lstRoot == null)
          lstRoot = new List<int>();
        int id = (int)dr_ip[0];
        //string name = (string)dr_ip[1];
        //string ip = (string)dr_ip[6];
        //string phone = (string)dr_ip[7];
        //int uType = (int)dr_ip[9];
        //ItemIp itemIp = new ItemIp()
        //{
        //  Id = id,
        //  Ip = ip,
        //  Name = name,
        //  IsTrue = false,
        //  Phone = phone,
        //  UType = (byte)uType,
        //  IdMessage = -1,
        //  IsMsgTrue = false,
        //  Date = dt
        //};

        lstRoot.Add(id);

      }
      dr_ip.Close();

      return lstRoot;
    }

    public Dictionary<int, string> GetTypeController() {

      /*Dictionary<int, string> utype = null;
      var sql = "select * from main_unittypes order by id";
      var consql = new NpgsqlConnection(this.__connection);
      var cmd = new NpgsqlCommand(sql, consql);
      
      consql.Open();
      var dr = cmd.ExecuteReader();
      while (dr.Read())
      {
        if (utype == null) {
          utype = new Dictionary<int, string>();
        }
        utype.Add((int)dr[0], (string)dr[1]);

      }
      return utype;
      */
      Dictionary<int, string> utype = new Dictionary<int, string>();
      utype.Add(0, "РВП-18");
      utype.Add(1, "ULC 2");
      return utype;
    }


    public void GetResObjects(int parent_id, int device_type)
    {
      var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
        __connection, PostgreSqlDialect.Provider);
      using (var db = dbFactory.Open())
      {
        var sql = string.Format("select mn.id,mn.name,mn.active ,mn.light ," +
          "mn.\"comments\",mc.ip_address, mc.phone_num,mc.unit_type_id " +
          "from main_nodes mn, main_ctrlinfo mc " +
          "where mn.parent_id = {0} and mc.id = mn.id and mc.unit_type_id={1}", parent_id, device_type);
        List<OrmResObjects> lstRes = db.Select<OrmResObjects>(sql);
        sql = string.Format("select mn.id , md.\"current_time\" ,md.body from main_nodes mn " +
             "right join main_ctrlinfo mc on mc.id = mn.id " +
             "right join main_ctrlcurrent md on mc.id = md.ctrl_id " +
             "where mn.parent_id = {0} and mc.unit_type_id = {1} and md.\"current_time\" > '{2}' " +
             "order by md.\"current_time\"", parent_id, device_type, DateTime.Now.ToString("yyyy-MM-dd"));
        List<OrmResBody> lstResBody = db.Select<OrmResBody>(sql);
        foreach (var item in lstResBody)
        {
          OrmResObjects result = lstRes.Find(res => res.id == item.id);
          if (result != null) {
            result.date = item.date;
            result.body = item.body;
          }

        }
      }
    }

    public int __net_isTrue = 0;
    public void _ViewRes(ListView list, int res, DateTime dt, EnumViewDevType enmDevType)
    {
      //GetResObjects(res, (int)enmDevType);

      __num = 0;
      __notTrue = 0;
      __isTrue = 0;
      __net_isTrue = 0;
      string sql_ip = string.Empty;
      switch (enmDevType)
      {
        case EnumViewDevType.RVP:
        case EnumViewDevType.ULC2:

          /*
           select mn.id , mn.name, mn.active ,mn.light ,mn."comments",mc.ip_address, mc.phone_num,mc.unit_type_id 
           from main_nodes mn, main_ctrlinfo mc
           where mn.parent_id =13 and mc.id =mn.id 
           */
          sql_ip = string.Format("SELECT * FROM main_nodes mn full join main_ctrlinfo ci on ci.id = mn.id " +
              "where mn.parent_id = {0} and ci.unit_type_id={1} order by mn.name", res, (int)enmDevType);
          break;
        case EnumViewDevType.ALL:
          sql_ip = string.Format("SELECT* FROM main_nodes mn full join main_ctrlinfo ci on ci.id = mn.id " +
              "where mn.parent_id = {0} order by mn.name", res);
          break;
        default:
          break;
      }

      var con_ip = new NpgsqlConnection(this.__connection);
      var cmd_ip = new NpgsqlCommand(sql_ip, con_ip);
      con_ip.Open();
      var dr_ip = cmd_ip.ExecuteReader();
      Dictionary<int, ItemIp> dlst = new Dictionary<int, ItemIp>();

      while (dr_ip.Read())
      {
        int id = (int)dr_ip["id"];
        string name = (string)dr_ip["name"];
        string ip;
        string phone;
        int uType;
        int active;
        int isLight;
        string comment;
        string meters;
        int rs_stat;
        float longit = -1;
        float letit = -1;
        if (dr_ip["ip_address"].GetType() == typeof(DBNull))
          ip = "---";
        else
        ip = (string)dr_ip["ip_address"];
        if (dr_ip["phone_num"].GetType() == typeof(DBNull))
          phone = "---";
        else
        phone = (string)dr_ip["phone_num"];
        if (dr_ip["unit_type_id"].GetType() == typeof(DBNull))
          uType = 0;
        else
          uType = (int)dr_ip["unit_type_id"];

        if (dr_ip["active"].GetType() == typeof(DBNull))
          active = 0;
        else
          active = (int)dr_ip["active"];
        if (dr_ip["light"].GetType() == typeof(DBNull))
          isLight = 0;
        else
          isLight = (int)dr_ip["light"];
        if (dr_ip["comments"].GetType() == typeof(DBNull))
          comment = "";
        else
          comment = (string)dr_ip["comments"];
        meters = "Н/Д";
        if (dr_ip["rs_stat"].GetType() == typeof(DBNull))
          rs_stat = 0;
        else
          rs_stat = (int)dr_ip["rs_stat"];
       
        //string meter_factory = "Н/Д";
        if (dr_ip["meters"] != null)
        {
          if (dr_ip["meters"].GetType() != typeof(DBNull))
          {
            meters = (string)dr_ip["meters"];
          }
        }
        if (dr_ip["longit"].GetType() != typeof(DBNull))
          longit = (float)dr_ip["longit"];
        if (dr_ip["letit"].GetType() != typeof(DBNull))
          letit = (float)dr_ip["letit"];
        //if (dr_ip["meter_type"].GetType() != typeof(DBNull))
        //{
        //  meter_factory = (string)dr_ip["meter_factory"];
        //}
        ItemIp itemIp = new ItemIp()
        {
          Id = id,
          Ip = ip,
          Name = name,
          IsTrue = false,
          Phone = phone,
          UType = (byte)uType,
          IdMessage = -1,
          IsMsgTrue = false,
          Date = dt,
          Active = active,
          IsLight = isLight,
          Comments = comment,
          Meters = meters,
          Rs_Stat = rs_stat,
          longit=longit,
          letit=letit
          //MeterFactory=meter_factory

        };
        dlst.Add(id, itemIp);
      }
      dr_ip.Close();
      if (list != null)
      {
        IAsyncResult result = list.BeginInvoke(new Action(() =>
         {
           list.Items.Clear();
         }));
        result.AsyncWaitHandle.WaitOne();
      }

      List<ListViewItem> lstRes = new List<ListViewItem>();
      foreach (var item in dlst)
      {
        sql_ip = string.Format("SELECT* FROM main_ctrlcurrent mc where mc.ctrl_id ={0} and mc.body <> '' order by mc.\"current_time\" desc limit 1",
        //sql_ip = string.Format("SELECT* FROM main_ctrlcurrent mc where mc.ctrl_id ={0} and mc.\"current_time\" >'{1}' ORDER BY mc.\"current_time\" DESC",
          item.Key);//, dt.ToString("yyyy-MM-dd"));
                    //sql_ip = string.Format("SELECT* FROM main_ctrlcurrent mc where mc.ctrl_id ={0} order by mc.\"current_time\" desc",
                    //sql_ip = string.Format("SELECT* FROM main_ctrlcurrent mc where mc.ctrl_id ={0} and mc.\"current_time\" >'{1}' ORDER BY mc.\"current_time\" DESC",
                    //item.Key);//, dt.ToString("yyyy-MM-dd"));
        cmd_ip = new NpgsqlCommand(sql_ip, con_ip);
        dr_ip = cmd_ip.ExecuteReader();

        ListViewItem it = new ListViewItem(DateTime.MinValue.ToString("dd.MM.yy HH:mm:ss"));
        //it.SubItems.Add(item.Value.Name);
        string[] aTp = item.Value.Name.Split(',');
        string tp = aTp.Length == 3 ? aTp[2].Trim() : "---";
        it.SubItems.Add(string.Format("{0}({1})", aTp[0], aTp[1].Trim()));
        it.SubItems.Add(tp);
        it.SubItems.Add(item.Value.Ip);
        if (item.Value.Phone.StartsWith("---"))
          item.Value.Phone = "нет информ...";
        it.SubItems.Add(item.Value.Phone);
        it.SubItems.Add(item.Value.UType == 0 ? "РВП-18" : "ULC 02");
        
        if (dr_ip.Read())
        {
          DateTime dtRecord = (DateTime)dr_ip[1];
          it.SubItems[0].Text = dtRecord.ToString("dd.MM.yy HH:mm:ss");
          item.Value.IdMessage = (int)dr_ip[0];
          item.Value.Date = dtRecord;//(DateTime)dr_ip[1];
          item.Value.MsgConfig = new DataMsg() { Message = (string)dr_ip[2], Date = item.Value.Date };
          if (dt.Year == dtRecord.Year && dt.Month == dtRecord.Month && dt.Day == dtRecord.Day)
          {
            item.Value.IsTrue = true;
            item.Value.IsMsgTrue = true;
            it.ImageIndex = 0;
            ++this.__isTrue;
          }
          else
          {
            item.Value.IsTrue = false;
            item.Value.IsMsgTrue = false;
            it.ImageIndex = 21;
            it.UseItemStyleForSubItems = false;
            it.SubItems[0].ForeColor = Color.Brown;
            ++this.__notTrue;
          }

          UlcCfg uc = new UlcCfg();
          if (uc.GetExtarctRvpConfig(item.Value.MsgConfig.Message))
          {
            item.Value.UlcConfig = uc;
          }
          else
          {
            int zz = 0;
          }
          it.Tag = item.Value;

          ListViewItem.ListViewSubItem sver = it.SubItems.Add(uc.SVERS);
          if (!string.IsNullOrEmpty(uc.SVERS))
          {
            if (item.Value.UType == 1)
            {
              if (!uc.SVERS.StartsWith("1.7.9") && !uc.SVERS.StartsWith("1.7.10"))
              {
                it.UseItemStyleForSubItems = false;
                sver.ForeColor = Color.Red;
              }
            }
          }
          int signal = 0;
          signal = ((-113 + (uc.SIGNAL) * 2));
          ListViewItem.ListViewSubItem sit = it.SubItems.Add(string.Format("{0} dBm", signal));
          if (signal < -100)
          {
            if (item.Value.IsTrue)
              it.ImageIndex = 10;
            it.UseItemStyleForSubItems = false;
            __net_isTrue++;
            sit.ForeColor = Color.Red;
          }
          DateTime? ss = ParceLog.rtc_calendar_time_to_register_value(uc.FMW);

          it.SubItems.Add(ss != null ? ((DateTime)ss).ToString("dd-MM-yyyy HH:mm:ss") : "----");

          string lvl = Log.ParceLevel(uc.LOGSLVL);
          if (item.Value.UType == 1)
          {
            it.SubItems.Add(lvl);
          }
          else
          {
            it.SubItems.Add("---");
          }
          string it_core = "----";
          if (!string.IsNullOrEmpty(uc.CORV))
          {
            string core = uc.CORV.Replace("\r\n", string.Empty);

            if (!core.Contains("12.01.830-B006"))
            {
              it_core = "патч";
            }
            else
            {
              it_core = "ok";
            }
          }
          it.SubItems.Add(it_core);
          //it.SubItems.Add("----");
          if (!string.IsNullOrEmpty(uc.IMEI))
          {
            long emai;
            bool bp = long.TryParse(uc.IMEI, out emai);
            //GetIMAIChanged(item.Key, emai);
            try
            {
              it.SubItems.Add(uc.IMEI.Substring(uc.IMEI.Length - 7, uc.IMEI.Length - 8));
            }
            catch {
              it.SubItems.Add("---");
            }
          }
          else
            it.SubItems.Add("----");
          it.SubItems.Add(uc.RAS.ToString());
          if (item.Value.UType == 1)
          {
            if (item.Value.Rs_Stat == 0)
            {
              ListViewItem.ListViewSubItem sbItem= it.SubItems.Add("X");
              //it.UseItemStyleForSubItems = false;
              //sbItem.BackColor = Color.LightGray;
              //sbItem.ForeColor = Color.Gray;
            }
            else {
              it.SubItems.Add((uc.CDIN >> 7).ToString());
            }
          }
          else
          {
            it.SubItems.Add("X");
          }
          if (item.Value.UlcConfig != null)
            it.SubItems.Add(((double)(item.Value.UlcConfig.TRAFC / 1024)).ToString() + " KB");
          it.SubItems.Add(item.Value.Active.ToString());
          it.SubItems.Add(item.Value.IsLight.ToString());
          it.SubItems.Add(item.Value.Comments);
          if (item.Value.Active == 0)
          {
            SetColorRow(it, Color.LightGray);
          }
          /*it.SubItems.Add("---");
          it.SubItems.Add("---");
          it.SubItems.Add(item.Value.Meters);*/

        }
        else
        {
          item.Value.IsTrue = false;
          item.Value.IsMsgTrue = false;
          it.ImageIndex = 15;
          it.Tag = item.Value;
          //it.SubItems.Add("----");
          it.SubItems.Add("----");
          it.SubItems.Add("----");
          it.SubItems.Add("----");
          it.SubItems.Add("----");
          it.SubItems.Add("----");
          it.SubItems.Add("----");
          it.SubItems.Add("----");
          it.SubItems.Add(item.Value.Rs_Stat.ToString());
          it.SubItems.Add("----");
          it.SubItems.Add(item.Value.Active.ToString());
          it.SubItems.Add(item.Value.IsLight.ToString());
          it.SubItems.Add(item.Value.Comments);
          if (item.Value.Active == 0)
          {
            SetColorRow(it, Color.LightGray);
          }
          else
          {
            SetColorRow(it, Color.Red);
          }
          //it.SubItems.Add("---");
          //it.SubItems.Add("---");
          //it.SubItems.Add(item.Value.Meters);

          /*foreach (ListViewItem.ListViewSubItem itNotTrue in it.SubItems)
          {
            it.UseItemStyleForSubItems = false;
            itNotTrue.ForeColor = Color.Red;
          }*/
          ++this.__notTrue;
        }
        ++__num;
        dr_ip.Close();
       
        lstRes.Add(it);
        /*if (list != null)
        {
          
          list.BeginInvoke(new Action(() =>
          {
            list.Items.Add(it);
          }));//
        }*/
      }
      con_ip.Close();
      if (list != null)
      {
        IAsyncResult result = list.BeginInvoke(new Action(() =>
         {
           foreach (var item in lstRes)
           {
             list.Items.Add(item);
           }
           //list.Items.Add(it);
           list.Visible = true;
         }));
        result.AsyncWaitHandle.WaitOne();
      }
    }

    //void GetIMAIChanged(int id, long imei)
    //{
    //  var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
    //      __connection, PostgreSqlDialect.Provider);
    //  using (var db = dbFactory.Open())
    //  {
    //    List< OrmDbConfig> lst= db.Select<OrmDbConfig>(
    //      string.Format("select * from main_ctrldata mc where mc.ctrl_id ={0} order by \"current_time\" desc", id));
    //    //foreach (var item in lst)
    //    //{
    //    if (lst.Count > 0) {
    //      if (lst[0].IMEI != imei)
    //      {
    //        int x = 0;
    //      }
    //      //}
    //    }
    //  }
    //}


    void SetColorRow(ListViewItem it, Color color) {
      foreach (ListViewItem.ListViewSubItem itNotTrue in it.SubItems)
      {
        it.UseItemStyleForSubItems = false;
        itNotTrue.ForeColor = color;
      }
    }
    
    public void ViewRes(ListView list, int res, DateTime dt, EnumViewDevType enmDevType, string nameRes)
    {

      SimpleWaitForm siform = new SimpleWaitForm();
      siform.RunAction(new Action(() =>
      {
        //list.BeginInvoke(new Action(()=> {
        //  list.Visible = false;        }));
        siform.SetLabelText(string.Format("Запрашиваю данные: {0}", nameRes));
        _ViewRes(list, res, dt, enmDevType);
        siform.DialogResult = DialogResult.OK;
        //list.BeginInvoke(new Action(() => {
        //  list.Visible = true;

        //}));
      }));
      siform.ShowDialog();
      if (this.UpdateListViewItems != null)
        this.UpdateListViewItems();
    }


    bool InsertRecordInDb(List<OrmDbCurrent> lstOrmCurrent, int deviceType) {
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
          __connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          foreach (var item in lstOrmCurrent)
          {
            if (!string.IsNullOrEmpty(item.body))
            {
              
              OrmDbConfig ormDataConfig = new OrmDbConfig();
              bool res = ormDataConfig.GetExtarctRvpConfig(item.body);
              if (res)
              {
                if (res)
                {
                  db.Insert<OrmDbCurrent>(new OrmDbCurrent()
                  { ctrl_id = item.ctrl_id, current_time = DateTime.Now, body = item.body });

                  ormDataConfig.ctrl_id = item.ctrl_id;
                  ormDataConfig.current_time = DateTime.Now;
                  ormDataConfig.DeviceType = deviceType;
                  db.Insert<OrmDbConfig>(ormDataConfig);
                }

              }
            }
          }
        }
      }
      catch (Exception exp)
      {
        return false;
      }

      finally
      {
        if (this.__dbConnection.State == System.Data.ConnectionState.Open)
        {
          this.__dbConnection.Close();
        }
      }
      return true;
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
          List<OrmDbCurrent> lstCurrnet = db.Select<OrmDbCurrent>(sql);
          if (lstCurrnet.Count > 0)
          {
            idCurrent = lstCurrnet[0].id;
          }
          sql = string.Format("select * from main_ctrldata md where md.ctrl_id ={0} and md.\"current_time\" >'{1}'",
          ctrId, DateTime.Now.ToString("yyyy-MM-dd"));
          List<OrmDbConfig> lstData = db.Select<OrmDbConfig>(sql);
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


    public void InsertArrayRecordInDb(List<ItemCallBack> lstItemCB,string full_path)
    {
      int idCurrent = -1;
      int idData = -1;
      var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
          __connection, PostgreSqlDialect.Provider);
      using (var db = dbFactory.Open())
      {
        foreach (var item in lstItemCB)
        {

          ItemIp itip = item.ItmIp;
          if (itip.IsTrue)
          {
            OrmDbConfig ormDataConfig = new OrmDbConfig();
            bool res = ormDataConfig.GetExtarctRvpConfig(itip.MsgConfig.Message);
            if (res)
            {
              try
              {
                CheckForRecordInDb(itip.Id, out idCurrent, out idData);
                if (idCurrent > -1)
                {

                  int xx = db.Update<OrmDbCurrent>(new OrmDbCurrent[] { new OrmDbCurrent()
                { id= idCurrent,  ctrl_id= itip.Id, body= itip.MsgConfig.Message, current_time=DateTime.Now } });
                  ormDataConfig.id = idData;
                  ormDataConfig.ctrl_id = itip.Id;
                  ormDataConfig.current_time = DateTime.Now;
                  ormDataConfig.DeviceType = itip.UType;
                  if (ormDataConfig.DeviceType == 1)
                  {
                    CheckDeviceIMEI(db, new List<OrmDbConfig>(){ ormDataConfig });//,full_path, itip.Name);
                  }
                  xx = db.Update<OrmDbConfig>(new OrmDbConfig[] { ormDataConfig });
                }
                else
                {
                  db.Insert<OrmDbCurrent>(new OrmDbCurrent[] { new OrmDbCurrent()
                { ctrl_id=itip.Id, body= itip.MsgConfig.Message, current_time=DateTime.Now } });
                  ormDataConfig.ctrl_id = itip.Id;
                  ormDataConfig.current_time = DateTime.Now;
                  ormDataConfig.DeviceType = itip.UType;
                  if (ormDataConfig.DeviceType == 1)
                  {
                    CheckDeviceIMEI(db, new List<OrmDbConfig>() { ormDataConfig });//,full_path, itip.Name);
                  }
                  db.Insert<OrmDbConfig>(new OrmDbConfig[] { ormDataConfig });
                }
              }
              catch
              {
              }
            }
          }
        }
      }
    }

    //public string GetDbObjectPath(int id, IDbConnection connection)
    //{
    //  string msg = string.Empty;
    //  string sql = string.Format("select mn.\"name\" as tp ,mn2.\"name\" as res,mn3.\"name\" as fes from main_nodes mn " +
    //  "right join main_nodes mn2 on mn.parent_id = mn2.id " +
    //  "right join main_nodes mn3 on mn2.parent_id = mn3.id " +
    //  "where mn.id = {0}");
    //  List<DbLogMsg> lst = connection.Select<DbLogMsg>(sql);
    //  if (lst.Count > 0)
    //  {
    //    msg = System.Text.Json.JsonSerializer.Serialize(lst[0], typeof(DbLogMsg));
    //  }
    //  return msg;
    //}

    string GetShortImei(string imei)
    {
      return imei.Substring(imei.Length - 7, imei.Length - 8);
    }

    /*public void CheckDeviceIMEI(IDbConnection connection, OrmDbConfig ulcCfg, string node_full_path,string item_name)
    {
      string sql = string.Format("SELECT * FROM main_ctrldata mc " +
            "WHERE id = (" +
            "SELECT max(id) FROM main_ctrldata mc2 where mc2.ctrl_id = {0})", ulcCfg.ctrl_id);
      List<OrmDbConfig> lstMax = connection.Select<OrmDbConfig>(sql);
      if (lstMax.Count > 0)
      {
        if (lstMax[0].IMEI != ulcCfg.IMEI)
        {
          int en = (int)EnLogEvt.CHANGE_IMEI;
          DbLogMsg dbLogMsg = new DbLogMsg()
          {
            Id = ulcCfg.ctrl_id,
            Tp = item_name
          };
          DbLogMsg.ParseNodePath(node_full_path, ref dbLogMsg);

          OrmMainLogs mainLogs = new OrmMainLogs()
          {
            current_time = DateTime.Now,
            id_user = this.__ulcUser.Id,
            usr_name = this.__ulcUser.User,
            message = string.Format("{0} (dt:{1} imei:{2}=>{3} rs:{4})",node_full_path+"/"+item_name, lstMax[0].current_time.ToString("dd.MM.yyyy HH:mm"),
            GetShortImei(lstMax[0].IMEI.ToString()), GetShortImei(ulcCfg.IMEI.ToString()), (lstMax[0].CDIN >> 7).ToString()),
            //string.Format("{0}=>(дата:{2} rs:{1})",
            //System.Text.Json.JsonSerializer.Serialize(dbLogMsg, typeof(DbLogMsg), DbLogMsg.GetSerializeOption()), (lstMax[0].CDIN >> 7).ToString(),
            //lstMax[0].current_time.ToString("dd.MM.yyyy HH:mm")),
            log_event = en,
            host_from = Dns.GetHostEntry(Dns.GetHostName()).HostName
          };
          connection.Insert<OrmMainLogs>(mainLogs);
        }
        else if ((DateTime.Now - lstMax[0].current_time).TotalDays > 2) {
          int en = (int)EnLogEvt.CHANGE_NET_STATE;
          OrmMainLogs mainLogs = new OrmMainLogs()
          {
            current_time = DateTime.Now,
            id_user = this.__ulcUser.Id,
            usr_name = this.__ulcUser.User,
            message = string.Format("{0}:{1},", node_full_path + "/" + item_name, "Выход на связь(более суток отключен)"),//string.Format("{0}=>(дата:{2} rs:{1})",
            //System.Text.Json.JsonSerializer.Serialize(dbLogMsg, typeof(DbLogMsg), DbLogMsg.GetSerializeOption()), (lstMax[0].CDIN >> 7).ToString(),
            //lstMax[0].current_time.ToString("dd.MM.yyyy HH:mm")),

            log_event = en,
            host_from = Dns.GetHostEntry(Dns.GetHostName()).HostName
          };
          connection.Insert<OrmMainLogs>(mainLogs);
        }
        
      }
      //ulcCfg.IMEI
    }*/

    public enum SqlTreeNodes
    {
      FullTree,
      SubTree,
      TopTree,
      None
    }

    public DbLogMsg GetDbObjectPath(int id, IDbConnection connection, SqlTreeNodes sqlTreeNodes)
    {
      string msg = string.Empty;
      string sql = string.Empty;
      switch (sqlTreeNodes)
      {
        case SqlTreeNodes.FullTree:
          sql = string.Format("select mn.id, mn.\"name\" as tp ,mn2.\"name\" as res,mn3.\"name\" as fes, mc.ip_address as ip from main_nodes mn " +
        "right join main_nodes mn2 on mn.parent_id = mn2.id " +
        "right join main_nodes mn3 on mn2.parent_id = mn3.id " +
        "right join main_ctrlinfo mc on mn.id =mc.id " +
        "where mn.id = {0}", id);
          break;
        case SqlTreeNodes.SubTree:
          sql = string.Format("select mn.id, mn.\"name\" as res ,mn2.\"name\" as fes from main_nodes mn " +
        "right join main_nodes mn2 on mn.parent_id = mn2.id " +
        "where mn.id = {0}", id);
          break;
        case SqlTreeNodes.TopTree:
          sql = string.Format("select mn.id, mn.\"name\" as fes from main_nodes mn " +
       "where mn.id = {0}", id);
          break;
        default:
          break;
      }
      DbLogMsg lst = connection.Single<DbLogMsg>(sql);
      if (lst != null)
      {
        return lst;
        //msg = System.Text.Json.JsonSerializer.Serialize(lst[0], typeof(DbLogs), GetSerializeOption());
        //msg = string.Format("{0}/{1}/{2}",lst[0].Fes,lst[0].Res,lst[0].Tp);
      }
      else return null;

    }

    public OrmDbConfig GetLastRecordById(IDbConnection connection, int id)
    {
      string sql = String.Format("SELECT * FROM main_ctrldata mc " +
                  "WHERE ID = (SELECT MAX(ID) FROM main_ctrldata mc1 where mc1.ctrl_id = {0})", id);
      List<OrmDbConfig> lstMax = connection.Select<OrmDbConfig>(sql);
      if (lstMax.Count > 0)
      {
        return lstMax[0];
      }
      else
      {
        return null;
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

    public void CheckDeviceIMEI(IDbConnection connection, List<OrmDbConfig> ulcCfgLst)
    {
      List<OrmDbLogs> lstLog = new List<OrmDbLogs>();
      try
      {


        foreach (var ulcCfg in ulcCfgLst)
        {
          string sql = string.Format("SELECT * FROM main_ctrldata mc " +
                "WHERE id = (" +
                "SELECT max(id) FROM main_ctrldata mc2 where mc2.ctrl_id = {0})", ulcCfg.ctrl_id);
          List<OrmDbConfig> lstMax = connection.Select<OrmDbConfig>(sql);
          if (lstMax.Count > 0)
          {
            DbLogMsg dbLogs = GetDbObjectPath(lstMax[0].ctrl_id, connection, SqlTreeNodes.FullTree);

            string msg = string.Empty;


            if (lstMax[0].IMEI != ulcCfg.IMEI)
            {
              dbLogs.feature = new ImeiStatAndRs()
              {
                old_imei = GetShortImei(lstMax[0].IMEI.ToString()),
                new_imei = GetShortImei(ulcCfg.IMEI.ToString()),
                rs_status = (lstMax[0].CDIN >> 7).ToString()
              };
              msg = System.Text.Json.JsonSerializer.Serialize(dbLogs, typeof(DbLogMsg), GetSerializeOption());
              int en = (int)EnLogEvt.CHANGE_IMEI;
              OrmDbConfig ormDbConfig = GetLastRecordById(connection, ulcCfg.ctrl_id);
              OrmDbLogs mainLogs = new OrmDbLogs()
              {
                current_time = DateTime.Now,
                id_user = 0,
                usr_name = "служба опроса",
                message = msg, //string.Format("{0}(dt:{1} imei:{2}=>{3} rs:{4})", msg, lstMax[0].current_time.ToString("dd.MM.yyyy HH:mm"),
                               //GetShortImei(lstMax[0].IMEI.ToString()), GetShortImei(ulcCfg.IMEI.ToString()), (lstMax[0].CDIN >> 7).ToString()),
                log_event = en,
                host_from = Dns.GetHostEntry(Dns.GetHostName()).HostName
              };

              connection.Insert<OrmDbLogs>(mainLogs);
            }
            else if ((DateTime.Now - lstMax[0].current_time).TotalDays > 2)
            {
              msg = System.Text.Json.JsonSerializer.Serialize(dbLogs, typeof(DbLogMsg), GetSerializeOption());
              int en = (int)EnLogEvt.CHANGE_NET_STATE;
              OrmDbLogs mainLogs = new OrmDbLogs()
              {
                current_time = DateTime.Now,
                id_user = 0,
                usr_name = "служба опроса",
                message = msg,//string.Format("dt:{0}-{1}", ulcCfg.current_time.ToString("dd.MM.yyyy HH:mm"), msg),
                log_event = en,
                host_from = Dns.GetHostEntry(Dns.GetHostName()).HostName
              };
              connection.Insert<OrmDbLogs>(mainLogs);
            }
          }
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public bool InsertCurrentRecord(int ctrl_id, DateTime dt, string message, int deviceType, string node_full_path, string item_name)
    {

      int idCurrent = -1;
      int idData = -1;
      var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
         __connection, PostgreSqlDialect.Provider);
      using (var db = dbFactory.Open())
      {
        try
        {
          OrmDbConfig ormDataConfig = new OrmDbConfig();
          bool res = ormDataConfig.GetExtarctRvpConfig(message);
          if (res)
          {
            CheckForRecordInDb(ctrl_id, out idCurrent, out idData);

            if (idCurrent > -1)
            {
              int xx = db.Update<OrmDbCurrent>(new OrmDbCurrent[] { new OrmDbCurrent()
                { id= idCurrent,  ctrl_id= ctrl_id, body= message, current_time=DateTime.Now } });
              ormDataConfig.id = idData;
              ormDataConfig.ctrl_id = ctrl_id;
              ormDataConfig.current_time = DateTime.Now;
              ormDataConfig.DeviceType = deviceType;
              if (ormDataConfig.DeviceType == 1)
              {
                CheckDeviceIMEI(db, new List<OrmDbConfig>() { ormDataConfig });//,full_path, itip.Name);//CheckDeviceIMEI(db, ormDataConfig, node_full_path, item_name);
              }
              xx = db.Update<OrmDbConfig>(new OrmDbConfig[] { ormDataConfig });
              return true;
            }
            else
            {
              db.Insert<OrmDbCurrent>(new OrmDbCurrent[] { new OrmDbCurrent()
                { ctrl_id= ctrl_id, body= message, current_time=DateTime.Now } });
              ormDataConfig.ctrl_id = ctrl_id;
              ormDataConfig.current_time = DateTime.Now;
              ormDataConfig.DeviceType = deviceType;
              if (ormDataConfig.DeviceType == 1)
              {
                CheckDeviceIMEI(db, new List<OrmDbConfig>() { ormDataConfig });//,full_path, itip.Name);
              }
              db.Insert<OrmDbConfig>(new OrmDbConfig[] { ormDataConfig });
              return true;
            }
          }
          else
          {
            return false;
          }

        }
        catch
        {
          return false;
        }
      }
    }

    public Dictionary<DateTime, List<UlcEvent>> DbReadEvent(int id, DateTime from, DateTime to)
    {
      
        //select * from main_ctrlevent mc where mc.ctrl_id =13593 and date(mc.event_time) = '2021-11-19'
        //between '2021-12-13' and '2021-12-14'
        string sql_ip = string.Format("select * from main_ctrlevent mc where mc.ctrl_id ={0} and mc.event_time > '{1}' and mc.event_time < '{2}' order by mc.id ",
        id, from.ToString("yyyy-MM-dd"),to.ToString("yyyy-MM-dd"));
      var con_ip = new NpgsqlConnection(this.__connection);
      var cmd_ip = new NpgsqlCommand(sql_ip, con_ip);
      Dictionary<DateTime, List<UlcEvent>> devt = null;
      try
      {
        con_ip.Open();
        var dr_ip = cmd_ip.ExecuteReader();

        // new Dictionary<DateTime, string>();
        if (dr_ip.HasRows)
        {
          while (dr_ip.Read())
          {
            if (devt == null)
              devt = new Dictionary<DateTime, List<UlcEvent>>();
            int ide = (int)dr_ip["id"];
            DateTime dt = (DateTime)dr_ip["event_time"];
            DateTime dtl = new DateTime(dt.Year, dt.Month, dt.Day);
            int event_level = (int)dr_ip["event_level"];
            LOG_LVL lOG_LVL = (LOG_LVL)event_level;
            int event_type=(int)dr_ip["event_type"];
            int event_value = (int)dr_ip["event_value"];
            string evt=Log.ConvertToString(new Log() { event_type = (byte)event_type, event_value = (ushort)event_value, event_level= lOG_LVL });
            //string evt = (string)dr_ip[6];
            if (!devt.ContainsKey(dtl))
            {
              UlcEvent ev = new UlcEvent() { Date = dt, Msg = evt, EventLevel = (LOG_LVL)event_level };
              List<UlcEvent> ls = new List<UlcEvent>();
              ls.Add(ev);
              devt.Add(dtl, ls);
            }
            else
            {
              devt[dtl].Add(new UlcEvent() { Date = dt, Msg = evt, EventLevel = (LOG_LVL)event_level });
            }

          }
        }
        dr_ip.Close();
      }
      catch(Exception exp) {
        int x = 0;
      }
      finally {
        if (con_ip.State == System.Data.ConnectionState.Open)
          con_ip.Close();

      }
      return devt;
    }

    Dictionary<int, List<int>> TTTT() {
      Dictionary<int, List<int>> iNode = new Dictionary<int, List<int>>();
      string[] sRnode = this.__ulcUser.NodesString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      foreach (var si in sRnode)
      {
        string[] sPNode = si.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
        int id = int.Parse(sPNode[0]);
        if (!iNode.ContainsKey(id))
        {
          List<int> lstInt = new List<int>();
          iNode.Add(id, lstInt);
          string[] sSNode = sPNode[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
          foreach (var itNodeParent in sSNode)
          {
            int idPNode = int.Parse(itNodeParent);
            lstInt.Add(idPNode);
          }
        }
      }
      return iNode;
    }

    public void FillTreeByUser(TreeView tree) {
      if (this.__super_user)
      {
        ReadDataBaseFull(tree);
      }
      else {
        ReadDataBaseUser(tree);
      }
    }

    void ReadDataBaseUser(TreeView tree)
    {
      NpgsqlConnection con_fes = null;
      NpgsqlConnection con_res = null;
      NpgsqlConnection con_tp = null;
      try
      {
        con_fes = new NpgsqlConnection(this.__connection);
        con_fes.Open();
        var sql_fes = "SELECT * FROM main_nodes where(parent_id is NULL)";
        var cmd_fes = new NpgsqlCommand(sql_fes, con_fes);
        var dr_fes = cmd_fes.ExecuteReader();
        Dictionary<int, List<int>> tree_nodes = TTTT();
        while (dr_fes.Read())
        {
          if (tree_nodes.ContainsKey((int)dr_fes[0]))
          {
            con_res = new NpgsqlConnection(this.__connection);
            con_res.Open();
            var sql_res = string.Format("SELECT * FROM main_nodes where(parent_id={0})", (int)dr_fes[0]);
            var cmd_res = new NpgsqlCommand(sql_res, con_res);
            var dr_res = cmd_res.ExecuteReader();


            int zz = tree.Nodes.Add(new UNode()
            {
              IsView = false,
              Id = (int)dr_fes[0],
              Name = (string)dr_fes[1],
              Text = (string)dr_fes[1]
            });
            while (dr_res.Read())
            {
              if (tree_nodes[(int)dr_fes[0]].Contains((int)dr_res[0]))
              {
                tree.Nodes[zz].Nodes.Add(new UNode()
                {
                  IsView = true,
                  Id = (int)dr_res[0],
                  Name = (string)dr_res[1],
                  Text = (string)dr_res[1]
                });
              }
            }
          }

        }
        dr_fes.Close();
        con_fes.Close();
      }
      catch (Exception exp)
      {
        int x = 0;
      }
      finally
      {
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
    void ReadDataBaseFull(TreeView tree)
    {
      NpgsqlConnection con_fes = null;
      NpgsqlConnection con_res = null;
      NpgsqlConnection con_tp = null;
      try
      {
        con_fes = new NpgsqlConnection(this.__connection);
        con_fes.Open();
        var sql_fes = "SELECT * FROM main_nodes where(parent_id is NULL)";
        var cmd_fes = new NpgsqlCommand(sql_fes, con_fes);
        var dr_fes = cmd_fes.ExecuteReader();

        while (dr_fes.Read())
        {

          con_res = new NpgsqlConnection(this.__connection);
          con_res.Open();
          var sql_res = string.Format("SELECT * FROM main_nodes where(parent_id={0})", (int)dr_fes[0]);
          var cmd_res = new NpgsqlCommand(sql_res, con_res);
          var dr_res = cmd_res.ExecuteReader();

          int zz = tree.Nodes.Add(new UNode() { IsView = false, Id = (int)dr_fes[0], Name = (string)dr_fes[1],
            Text = (string)dr_fes[1] });
          while (dr_res.Read())
          {
            tree.Nodes[zz].Nodes.Add(new UNode() { IsView = true, Id = (int)dr_res[0],
              Name = (string)dr_res[1], Text = (string)dr_res[1] });
          }
        }
        dr_fes.Close();
        con_fes.Close();
      }
      catch
      {

      }
      finally
      {
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

    public long AddNewResRecord(string name, string ipsddress, string phone,
      int node_kind__id, int parent_id, UTypeController type_controller, int active, int light, string comment, string full_path,
      string meterMsg,float longit,float letit)
    {
      var dbFactory = new OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
      using (var db = dbFactory.Open())
      {
        try
        {
          long iId = db.Insert<OrmDbNodes>(new OrmDbNodes()
          {
            name = name,
            active = active,
            comments = comment,
            light = light,
            node_kind_id = node_kind__id,
            parent_id = parent_id,
             longit=longit,
             letit=letit
          }, selectIdentity: true);
          db.Insert<OrmDbInfo>(new OrmDbInfo()
          {
            id = (int)iId,
            arm_id = 1,
            ip_address = ipsddress,
            meters = meterMsg,
            phone_num = phone,
            unit_type_id = (int)type_controller,
          });
          //DbLogMsg dbLogMsg = new DbLogMsg()
          //{
          //  Id = (int)iId,
          //  Tp = name
          //};
          DbLogMsg dbLogMsg= GetDbObjectPath((int)iId, db, SqlTreeNodes.FullTree);
          //DbLogMsg.ParseNodePath(full_path, ref dbLogMsg);
          string msg = System.Text.Json.JsonSerializer.Serialize(dbLogMsg, typeof(DbLogMsg), DbLogMsg.GetSerializeOption());
          LogsInsertEvent(EnLogEvt.ADD_ITEM, msg,(int)iId);
          return iId;
        }
        catch (Exception exp)
        {
          return -1;
        }
      }

      //try
      //{
      //  var consql = new NpgsqlConnection(this.__connection);
      //  consql.Open();
      //  var sql = "INSERT INTO public.main_nodes(\"name\", node_kind_id, parent_id,active,light,comments) " +
      //      "VALUES(@name, @node_kind_id, @parent_id,@active,@light,@comments) RETURNING id";
      //  var cmd = new NpgsqlCommand(sql, consql);
      //  cmd.Parameters.AddWithValue("name", name);
      //  cmd.Parameters.AddWithValue("node_kind_id", node_kind__id);
      //  cmd.Parameters.AddWithValue("parent_id", parent_id);
      //  cmd.Parameters.AddWithValue("active", active);
      //  cmd.Parameters.AddWithValue("light", light);
      //  cmd.Parameters.AddWithValue("comments", comment);
      //  int id = (int)cmd.ExecuteScalar();



      //  sql = "INSERT INTO public.main_ctrlinfo(id,ip_address, phone_num, arm_id,unit_type_id) " +
      //      "VALUES(@id,@ip_address, @phone_num, @arm_id,@unit_type_id)";
      //  cmd = new NpgsqlCommand(sql, consql);
      //  cmd.Parameters.AddWithValue("id", id);
      //  cmd.Parameters.AddWithValue("ip_address", ipsddress);
      //  cmd.Parameters.AddWithValue("phone_num", phone);
      //  cmd.Parameters.AddWithValue("arm_id", 1);
      //  cmd.Parameters.AddWithValue("unit_type_id", (int)type_controller);
      //  int result = cmd.ExecuteNonQuery();
      //  consql.Close();
      //  string nName = "{"+string.Format("name:{0},ip:{1},phone:{2},node_kind__id:{3},parent_id:{4},uType:{5},active:{6},light:{7},comment:{8}",
      //    name, ipsddress, phone, node_kind__id, parent_id, type_controller, active, light, comment)+"}";

      //}
      //catch (Exception exp)
      //{

      //  throw;
      //}
    }

    public void DeleteTreeItem(int id, string message, EnLogEvt? enLogEvt, SqlTreeNodes sqlTreeNodes)
    {
      string sql = string.Empty;
      DbLogMsg dbLogMsg=null;
      var consql = new NpgsqlConnection(this.__connection);
      consql.Open();
      if (enLogEvt != null) {
        dbLogMsg = GetDbObjectPath(id, consql, sqlTreeNodes);
      }
      
      sql = string.Format("DELETE FROM public.main_nodes WHERE id={0}", id);
      var cmd = new NpgsqlCommand(sql, consql);
      int rowf = cmd.ExecuteNonQuery();
      consql.Close();
     
      if (enLogEvt != null)
      {
        //DbLogMsg dbLogMsg = new DbLogMsg()
        //{
        //  Id = rowf,
        //};

        //DbLogMsg.ParseNodePath(message, ref dbLogMsg);
        string msg = System.Text.Json.JsonSerializer.Serialize(dbLogMsg, typeof(DbLogMsg), DbLogMsg.GetSerializeOption());
        LogsInsertEvent(enLogEvt.Value, msg,(int)id);
      }
    }

    public JsonSerializerOptions GetJsonOption() {
      var options = new JsonSerializerOptions
      {
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
        WriteIndented = true
      };
      return options;
    }

    public int DeleteResRecord(int id, string name, EnLogEvt? enLogEvt, string node_full_path)
    {
      try
      {
        var consql = new NpgsqlConnection(this.__connection);
        consql.Open();
        DbLogMsg dbLogMsg = GetDbObjectPath(id, consql, SqlTreeNodes.FullTree);
        var sql = string.Format("delete from main_ctrlevent where ctrl_id={0};", id);
        var cmd = new NpgsqlCommand(sql, consql);
        int result = cmd.ExecuteNonQuery();

        sql = string.Format("delete from main_ctrlcurrent where ctrl_id={0};", id);
        cmd.CommandText = sql;
        //cmd = new NpgsqlCommand(sql, consql);
        result = cmd.ExecuteNonQuery();
        sql = string.Format("delete from main_ctrlinfo where id={0};", id);
        //cmd = new NpgsqlCommand(sql, consql);
        cmd.CommandText = sql;
        result = cmd.ExecuteNonQuery();
        sql = string.Format("delete from main_nodes where id={0};", id);
        cmd.CommandText = sql;
        //cmd = new NpgsqlCommand(sql, consql);
        int result_node = cmd.ExecuteNonQuery();
        sql = string.Format("delete from meter_info where ctrl_id={0};", id);
        cmd.CommandText = sql;
        //cmd = new NpgsqlCommand(sql, consql);
        result = cmd.ExecuteNonQuery();
        consql.Close();
        if (enLogEvt != null)
        {
          //DbLogMsg dbLogMsg = new DbLogMsg()
          //{
          //  Id = id,
          //  Tp = name
          //};
          //DbLogMsg.ParseNodePath(node_full_path, ref dbLogMsg);
          string msg = System.Text.Json.JsonSerializer.Serialize(dbLogMsg, typeof(DbLogMsg), DbLogMsg.GetSerializeOption());
          LogsInsertEvent(enLogEvt.Value, msg, (int)id);

        }
        return result_node;
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message, "Ошибка удаления записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return -1;
      }

    }

    internal bool InsertLogMsg(List<Log> logs, int idCtrl)
    {
      int xx = 0; ;
      try
      {
        if (logs != null)
        {
          //var con = new NpgsqlConnection(this.__connection);
          this.__dbConnection.Open();
          foreach (var item in logs)
          {
            string evt = Log.ConvertToString(item);
            var sql = "Select * from main_ctrlevent where event_time=@etime and event_type=@etype and event_level=@elevel and ctrl_id=@ctrlid";
            var cmd = new NpgsqlCommand(sql, this.__dbConnection);
            cmd.Parameters.AddWithValue("etime", item.event_time);
            cmd.Parameters.AddWithValue("etype", item.event_type);
            cmd.Parameters.AddWithValue("elevel", (int)item.event_level);
            cmd.Parameters.AddWithValue("ctrlid", idCtrl);
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
              cmd.Parameters.AddWithValue("ctrl_id", idCtrl);
              cmd.Parameters.AddWithValue("event_msg", evt);
              cmd.ExecuteNonQuery();
              xx++;
            }
          }
          this.__dbConnection.Close();
          return true;
        }
        return false;
      }
      catch (Exception exp)
      {
        return false;
      }
      finally
      {
        if (this.__dbConnection.State == System.Data.ConnectionState.Open)
        {
          this.__dbConnection.Close();
        }
      }

    }

    public void LogsInsertEvent(EnLogEvt enLogEvt, string message,int ctrl_id) {
      try
      {
        var dbFactory = new OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          if (__host != null)
          {
            int en = (int)enLogEvt;
            OrmMainLogs mainLogs = new OrmMainLogs()
            {
              current_time = DateTime.Now,
              id_user = __super_user ? 0 : __ulcUser.Id,
              usr_name = __super_user ? __DbUserName : __ulcUser.User,
              message = message,
              log_event = en,
              host_from = __host.HostName,//Dns.GetHostEntry(Dns.GetHostName()).HostName,
              ctrl_id=ctrl_id
            };
            db.Insert<OrmMainLogs>(mainLogs);
          }
        }
      }
      catch(Exception e)
      {
        
      }
    }
  

    public bool EditResRecord(DbItemEditor dbItemEditor,string node_full_path,string msgMeter,int parent_id
      )//int id, string name, string ip, string phone, int utype,
      //int active, int light, string comments)
    {
      var dbFactory = new OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
      using (var db = dbFactory.Open())
      {
        //using (var bdb = db.BeginTransaction())
        //{
          try
          {
            int result = db.Update<OrmDbNodes>(new OrmDbNodes()
            {
              id = dbItemEditor.Id,
              name = dbItemEditor.Name,
              active = dbItemEditor.IsActive,
              light = dbItemEditor.IsLight,
              comments = dbItemEditor.Comment,
              parent_id=parent_id,
               node_kind_id=3,
                letit=dbItemEditor.letit,
                longit=dbItemEditor.longit
            });
            
            result = db.Update<OrmDbInfo>(new OrmDbInfo()
            {
              id = dbItemEditor.Id,
               arm_id=1,
              meters = msgMeter,
              ip_address = dbItemEditor.Ip,
              phone_num = dbItemEditor.Phone,
              unit_type_id = dbItemEditor.UType,
              rs_stat= dbItemEditor.rs_stat==1 ? 1:0
            });
          //DbLogMsg dbLogMsg = new DbLogMsg()
          //{
          //  Id = dbItemEditor.Id,
          //  Tp = dbItemEditor.Name
          //};
          //DbLogMsg.ParseNodePath(node_full_path, ref dbLogMsg);
          DbLogMsg dbLogMsg = GetDbObjectPath(dbItemEditor.Id, db, SqlTreeNodes.FullTree);
          string msg = System.Text.Json.JsonSerializer.Serialize(dbLogMsg, typeof(DbLogMsg), DbLogMsg.GetSerializeOption());
          LogsInsertEvent(EnLogEvt.SETTING_CHANGE, msg, dbItemEditor.Id);
        //}
          //bdb.Commit();
          return true;
          }
          catch (Exception exp)
          {
            //bdb.Rollback();
            return false;
          }
        //}
         
      }

      //  NpgsqlConnection consql = null;
      //try
      //{
      //  consql = new NpgsqlConnection(this.__connection);
      //  consql.Open();

      //  var sql = string.Format("UPDATE public.main_nodes " +
      //           "SET \"name\"='{0}',active={1},light={2},\"comments\"='{3}' WHERE id = {4}",
      //           dbItemEditor.Name, dbItemEditor.IsActive, dbItemEditor.IsLight,
      //           dbItemEditor.Comment, dbItemEditor.Id);
      //  var cmd = new NpgsqlCommand(sql, consql);
      //  int rexc = cmd.ExecuteNonQuery();
      //  sql = string.Format("UPDATE public.main_ctrlinfo " +
      //         "SET ip_address='{0}',phone_num={1}, unit_type_id={2}, meters={4} WHERE id = {3}",
      //         dbItemEditor.Ip, dbItemEditor.Phone, dbItemEditor.UType, dbItemEditor.Id, msgMeter);
      //  cmd.CommandText = sql;
      //  rexc = cmd.ExecuteNonQuery();

      //  consql.Close();

      //  DbLogMsg dbLogMsg = new DbLogMsg()
      //  {
      //    Id = dbItemEditor.Id,
      //    Item = dbItemEditor.Name
      //  };
      //  DbLogMsg.ParseNodePath(node_full_path, ref dbLogMsg);
      //  string msg = System.Text.Json.JsonSerializer.Serialize(dbLogMsg, typeof(DbLogMsg), DbLogMsg.GetSerializeOption());
      //  LogsInsertEvent(EnLogEvt.EDIT_ITEM, msg);
      //}
      //catch (Exception e)
      //{
      //  int x = 0;
      //}
      //finally
      //{


      //  if (consql.State == System.Data.ConnectionState.Open)
      //  {
      //    consql.Close();
      //  }

      //}

    }


    public List<StatisticRes> GetStatisticFes(UNode unode) {
      List<StatisticRes> statisticRes = null;
      try
      {
        statisticRes = new List<StatisticRes>();
        string query_all = "SELECT count(*) FROM main_nodes mn right join main_ctrlinfo mc on mn.id = mc.id where mn.parent_id = {0} and mn.active=1";
        string query_dev = "SELECT count(*) FROM main_nodes mn right join main_ctrlinfo mc on mn.id = mc.id where mn.parent_id = {0} and mn.active=1 and mc.unit_type_id ={1} ";
        string query_net = "SELECT count(*) FROM main_nodes mn "+
          "right JOIN main_ctrldata mc ON mn.id = mc.ctrl_id "+
          "right join main_ctrlinfo mc2 on mc.ctrl_id = mc2.id where mc.\"current_time\" > '{0}' "+
          "and mn.parent_id = {1} "+
          "and mn.active = 1 "+
          "and mc2.unit_type_id = {2}";
        string query_rs = "SELECT count(*) FROM main_nodes mn " +
          "right JOIN main_ctrldata mc ON mn.id = mc.ctrl_id " +
          "right join main_ctrlinfo mc2 on mc.ctrl_id = mc2.id and mc2.rs_stat =1 where mc.\"current_time\" > '{0}' " +
          "and mn.parent_id = {1} " +
          "and mn.active = 1 " +
          "and mc2.unit_type_id = 1 "+
          "and (mc.cdin >>7)=0";
        string query_bad_signal = "SELECT count(*) FROM main_nodes mn " +
          "right JOIN main_ctrldata mc ON mn.id = mc.ctrl_id " +
          "right join main_ctrlinfo mc2 on mc.ctrl_id = mc2.id where mc.\"current_time\" > '{0}' " +
          "and mn.parent_id = {1} " +
          "and mn.active = 1 " +
          "and mc2.unit_type_id = {2} " +
          "and(((-113 + (mc.signal) * 2)) < -100)";

        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
         
          foreach (UNode item in unode.Nodes)
          {
            StatisticRes statRes = new StatisticRes();
            statRes.ResName = item.Text;
            string qury = string.Format(query_all, item.Id);
            long count=db.Scalar<long>(qury);
            statRes.All = count;
            qury = string.Format(query_dev, item.Id,0);
            count = db.Scalar<long>(qury);
            statRes.AllRvp = count;
            qury = string.Format(query_dev, item.Id, 1);
            count = db.Scalar<long>(qury);
            statRes.AllUlc = count;
            qury = string.Format(query_net,DateTime.Now.ToString("yyyy-MM-dd"), item.Id, 0);
            count = db.Scalar<long>(qury);
            statRes.AllRvpNet = count;
            qury = string.Format(query_net, DateTime.Now.ToString("yyyy-MM-dd"), item.Id, 1);
            count = db.Scalar<long>(qury);
            statRes.AllUlcNet = count;
            qury = string.Format(query_rs, DateTime.Now.ToString("yyyy-MM-dd"), item.Id);
            count = db.Scalar<long>(qury);
            statRes.AllUlcRs = count;
            qury = string.Format(query_bad_signal, DateTime.Now.ToString("yyyy-MM-dd"), item.Id,0);
            count = db.Scalar<long>(qury);
            statRes.AllRvpBadSignal = count;
            qury = string.Format(query_bad_signal, DateTime.Now.ToString("yyyy-MM-dd"), item.Id, 1);
            count = db.Scalar<long>(qury);
            statRes.AllUlcBadSignal = count;
            statisticRes.Add(statRes);
          }
        }
      }
      catch (Exception ex)
      {
        return null;
      }
      return statisticRes;
    }

    public void DbWriteLog(string message)
    {

      var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
       __connection, PostgreSqlDialect.Provider);
      using (var db = dbFactory.Open())
      {
        try
        {
          OrmDbLogs dbLogs = new OrmDbLogs()
          {
            current_time = DateTime.Now,
            id_user = this.__ulcUser.Id,
            usr_name = this.__ulcUser.User,
            message = message

          };
          db.Insert<OrmDbLogs>(new OrmDbLogs[] { dbLogs });
        }
        catch
        {

        }
      }
    }

    public List<MeterInfo> GetUlcMeters(int ctrl_id) {
      try
      {
        List<MeterInfo> lstI;
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
       __connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          lstI = db.Select<MeterInfo>(x => x.ctrl_id == ctrl_id);
        }
        return lstI;
      }
      catch
      {

        return null;
      }
    }

    public void SetCrudMeterInfo(List<MeterInfo> meterInfos) {
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
       __connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          using (IDbTransaction dbTrans = db.OpenTransaction(IsolationLevel.ReadCommitted))
          {
            foreach (var item in meterInfos)
            {
              switch (item.crud_record)
              {
                case CrudRecord.None:
                  break;
                case CrudRecord.Add:
                    db.Insert<MeterInfo>(item);
                  break;
                case CrudRecord.Edit:
                  db.Update<MeterInfo>(item);
                  break;
                case CrudRecord.Delete:
                 int x=db.Delete<MeterInfo>(item);
                  break;
                default:
                  break;
              }
            }
            dbTrans.Commit();
          }
        }
      }
      catch
      {

      }
    }

  }
}
