using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin.Controls.UlcMeterComponet
{
  public class MeterInfo
  {
    [ServiceStack.DataAnnotations.AutoIncrement]
    public int id { get; set; }
    public int ctrl_id { get; set; }
    public int parent_id { get; set; }
    public string ip { get; set; }
    public string meter_type { get; set; }
    public string meter_factory { get; set; }
    [Default(1,IntValue =1)]
    public int active { get; set; }
    [Ignore]
    public CrudRecord crud_record { get; set; }



    public static bool CheckTableDb(string connection)
    {
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          CreateDbMeterInfo(connection);
        }
        return true;
      }
      catch
      {
        return false;
      }
    }

    static bool CreateDbMeterInfo(string connection)
    {
      //string connection = string.Format("Host={0};Port={3};Username={1};Password={2};Database=ctrl_mon_dev",
      //host, user, pwd, port);
      List<MeterInfo> dic = new List<MeterInfo>();
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          db.CreateTableIfNotExists(typeof(MeterInfo));
          string sql = "select mn.parent_id, mn.id, mn.\"name\",mc.ip_address,mc.meters from main_nodes mn left join main_ctrlinfo mc on mc.id = mn.id where mn.node_kind_id > 2";
          IDbCommand cmd = db.CreateCommand();
          cmd.CommandText = sql;
          var reader = cmd.ExecuteReader();
          while (reader.Read())
          {
            int parent_id = (int)reader[0];
            int id = (int)reader[1];
            string name = (string)reader[2];
            string ip = (string)reader[3];
            string meters = string.Empty;
            if (reader[4].GetType() != typeof(DBNull))
            {
              meters = (string)reader[4];
            }

            List<MeterType> lst_mtr = Meters.ResolveMeters(meters);
            if (lst_mtr != null)
            {
              for (int i = 0; i < lst_mtr.Count; i++)
              {
                var mtr = new MeterInfo()
                {
                  //id = id,
                  parent_id = parent_id,
                  ctrl_id = id,
                  ip = ip,
                  meter_factory = lst_mtr[i].meter_factory,
                  meter_type = lst_mtr[i].meter_type
                };
                dic.Add(mtr);
              }
            }
          }
          reader.Close();
          db.Insert<MeterInfo>(dic.ToArray());
        }

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }

    }
  }
}
