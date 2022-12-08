using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlcInstallDB.DB
{
  [ServiceStack.DataAnnotations.Alias("meter_value")]
  public class MeterValue
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
  }
}
