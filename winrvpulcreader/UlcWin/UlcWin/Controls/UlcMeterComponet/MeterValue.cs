using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin.Controls.UlcMeterComponet
{


  public class MeterValue
  {
    [ServiceStack.DataAnnotations.AutoIncrement]
    public int id { get; set; }
    public int ctrl_id { get; set; }
    public int parent_id { get; set; }
    public DateTime date_time { get; set; }
    public string ip { get; set; }
    public string meter_type { get; set; }
    public string meter_factory { get; set; }
    public double value { get; set; }
    public bool is_true { get; set; }

    public static bool CheckTableDb(string connection)
    {

      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          return db.CreateTableIfNotExists(typeof(MeterValue));
        }
      }
      catch
      {
        return false;
      }
    }
  }
}

