using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
  [ServiceStack.DataAnnotations.Alias("main_ctrlevent")]
  public class MainEvents
  {
    [ServiceStack.DataAnnotations.AutoIncrement]
    public int id { get; set; }

    [ServiceStack.DataAnnotations.Required]
    public DateTime current_time { get; set; }

    [ServiceStack.DataAnnotations.Required]
    public int event_type { get; set; }

    [ServiceStack.DataAnnotations.Required]
    public int event_level { get; set; }

    public int event_value { get; set; }

    [ServiceStack.DataAnnotations.Required]
    [ServiceStack.DataAnnotations.ForeignKey(typeof(MainInfo),OnDelete = "CASCADE")]
    [ServiceStack.DataAnnotations.Index]
    public int ctrl_id { get; set; }

    public string event_msg { get; set; }


  }
}
