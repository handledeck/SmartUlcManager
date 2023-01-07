using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin.DB
{
  //public enum EnLogEvent
  //{
  //  ChangeIMEI = 0
  //}

  [ServiceStack.DataAnnotations.Alias("main_logs")]
  public class OrmMainLogs
  {
    [ServiceStack.DataAnnotations.AutoIncrement]
    [ServiceStack.DataAnnotations.PrimaryKey]
    public int id { get; set; }

    [ServiceStack.DataAnnotations.Required]
    public DateTime current_time { get; set; }

    [ServiceStack.DataAnnotations.Required]
    public int id_user { get; set; }

    [ServiceStack.DataAnnotations.Required]
    public string usr_name { get; set; }

    public string message { get; set; }
    public int log_event { get; set; }
    public string host_from { get; set; }

    
    public int ctrl_id { get; set; }

  }
}
