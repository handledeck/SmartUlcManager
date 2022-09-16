using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin.DB
{
  public class OrmResObjects
  {
    public int id { get; set; }
    public string name { get; set; }
    public string ip { get; set; }
    public string phone { get; set; }
    public int active { get; set; }
    public int light { get; set; }
    public string comment { get; set; }

    public int device_type { get; set; }
    public DateTime? date { get; set; }
    public string body { get; set; }

  }
}
