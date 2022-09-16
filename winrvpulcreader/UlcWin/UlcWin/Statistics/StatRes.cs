using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin.Statistics
{
  public class StatisticRes
  {
    public string ResName { get; set; }
    public long All { get; set; }
    public long AllUlc { get; set; }
    public long AllRvp { get; set; }
    public long AllRvpNet { get; set; }
    public long AllUlcNet { get; set; }
    public long AllUlcRs { get; set; }
    public long AllRvpBadSignal { get; set; }
    public long AllUlcBadSignal { get; set; }
  }
}
