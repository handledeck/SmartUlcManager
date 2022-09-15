using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin.DB
{
  [ServiceStack.DataAnnotations.Alias("main_nodes")]
  public class OrmDbNodes
  {
    [ServiceStack.DataAnnotations.AutoIncrement]
    [ServiceStack.DataAnnotations.PrimaryKey]
    [ServiceStack.DataAnnotations.Required]
    public int id { get; set; }

    [ServiceStack.DataAnnotations.Required]
    public string name { get; set; }

    public string code { get; set; }

    [ServiceStack.DataAnnotations.Required]
    public int node_kind_id { get; set; }

    public int? parent_id { get; set; }
    public int? active { get; set; }
    public int? light { get; set; }
    public string  comments { get; set; }
  }
}
