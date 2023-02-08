using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
  [ServiceStack.DataAnnotations.Alias("main_ctrlinfo")]
  public class MainInfo
  {
    
    [PrimaryKey]
    [ForeignKey(typeof(MainNodes), OnDelete = "CASCADE")]
    [Index]
    public int id { get; set; }
    public string ip_address { get; set; }
    public string phone_num { get; set; }
    [Index]
    public int arm_id { get; set; }
    [Index]
    public int unit_type_id { get; set; }
    public string meters { get; set; }
    public int rs_stat { get; set; }

  }
}
