using InterUlc.Db;
using InterUlc.UlcCfg;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Db
{
  public class RsNotTrue:IEqualityComparer<RsNotTrue>
  {
    public int id { get; set; }
    public string ip_address { get; set; }
    public string meter_factory { get; set; }
    public string meter_type { get; set; }
    public int data_id { get; set; }
    public int cur_id { get; set; }
    public int device_type { get; set; }
    public string Message { get; set; }
    public ItemRunComplite EvtItemRunComplite { get; set; }
    public UlcCfg UlcCnfg { get; set; }
    public Task OwnerTask { get; set; }
    public bool is_true { get; set; }
    public bool Equals(RsNotTrue x, RsNotTrue y)
    {
      if (x.data_id == y.data_id)
        return true;
      else return false;
    }

    public int GetHashCode(RsNotTrue obj)
    {
      throw new NotImplementedException();
    }
  }
  public class RsNotTrueComparer : IEqualityComparer<RsNotTrue>
  {
    public bool Equals(RsNotTrue x, RsNotTrue y)
    {
      if (x.data_id == y.data_id)
        return true;
      else return false;
    }

    public int GetHashCode(RsNotTrue obj)
    {
      throw new NotImplementedException();
    }
  }

}
