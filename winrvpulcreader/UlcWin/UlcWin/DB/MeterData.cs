using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin.DB
{
  public class MeterData
  {
    public string date_utc { get; set; }
    public double data { get; set; }
    public byte quality { get; set; }
  }
}
