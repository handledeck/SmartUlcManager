using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin.DB
{
  [ServiceStack.DataAnnotations.Alias("main_user")]
  public class OrmDbUsers
  {
    [ServiceStack.DataAnnotations.AutoIncrement]
    [ServiceStack.DataAnnotations.PrimaryKey]
    [ServiceStack.DataAnnotations.Required]
    public int id { get; set; }
    [ServiceStack.DataAnnotations.Required]
    public string usr { get; set; }
    public string pwd { get; set; }
    [ServiceStack.DataAnnotations.Required]
    public string items { get; set; }
    public string comment { get; set; }
    [ServiceStack.DataAnnotations.Required]
    public int level { get; set; }

    public override string ToString()
    {
      return usr + ":" + comment;
    }
  }
}
