using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin.DB
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
    public int active { get; set; }
  }
}
