using InterUlc.Db;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Db
{
  [ServiceStack.DataAnnotations.Alias("meter_info")]
  public class MeterInfo
  {
    [ServiceStack.DataAnnotations.AutoIncrement]
    public int id { get; set; }
    public int ctrl_id { get; set; }
    public int parent_id { get; set; }
    public string ip { get; set; }
    public string meter_type { get; set; }
    public string meter_factory { get; set; }
    [ServiceStack.DataAnnotations.Default(1)]
    public int active { get; set; }
    [Ignore]
    public ItemRunComplite EvtItemRunComplite { get; set; }
    [Ignore]
    public Task OwnerTask { get; set; }
  }
}
