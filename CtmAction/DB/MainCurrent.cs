using DB;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
  [ServiceStack.DataAnnotations.Alias("main_ctrlcurrent")]
  public class MainCurrent
  {
    [ServiceStack.DataAnnotations.AutoIncrement]
    [PrimaryKey]
    public int id { get; set; }

    [ServiceStack.DataAnnotations.Required]
    public DateTime current_time { get; set; }

    [ServiceStack.DataAnnotations.Required]
    public string body { get; set; }

    [ServiceStack.DataAnnotations.Required]
    [ForeignKey(typeof(MainInfo), OnDelete = "CASCADE")]
   
    [Index]
    public int ctrl_id { get; set; }

  }
}
