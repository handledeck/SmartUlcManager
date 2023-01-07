using BrightIdeasSoftware;
using ServiceStack.OrmLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.Controls.UlcMeterComponet
{
  public class MeterValue: IVirtualListDataSource
  {
    [ServiceStack.DataAnnotations.AutoIncrement]
    public int id { get; set; }
    public int ctrl_id { get; set; }
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

    public void AddObjects(ICollection modelObjects)
    {
      throw new NotImplementedException();
    }

    public object GetNthObject(int n)
    {
      throw new NotImplementedException();
    }

    public int GetObjectCount()
    {
      throw new NotImplementedException();
    }

    public int GetObjectIndex(object model)
    {
      throw new NotImplementedException();
    }

    public void PrepareCache(int first, int last)
    {
      throw new NotImplementedException();
    }

    public void RemoveObjects(ICollection modelObjects)
    {
      throw new NotImplementedException();
    }

    public int SearchText(string value, int first, int last, OLVColumn column)
    {
      throw new NotImplementedException();
    }

    public void SetObjects(IEnumerable collection)
    {
      throw new NotImplementedException();
    }

    public void Sort(OLVColumn column, SortOrder order)
    {
      throw new NotImplementedException();
    }

    public void UpdateObject(int index, object modelObject)
    {
      throw new NotImplementedException();
    }
  }
}

