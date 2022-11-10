using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin.Controls.UlcMeterComponet
{
  public class TreeListNodeModel
  {
    public int id { get; set; }
    public string name { get; set; }
    public DateTime? date_time { get; set; }
    public string ip { get; set; }
    public string meter_type { get; set; }
    public string meter_factory { get; set; }
    public double? value { get; set; }
    public bool is_true { get; set; }
    public int? unit_type_id { get; set; }

    public List<TreeListNodeModel> Nodes { get; set; }

    public void Validated() {
      if (this.Nodes != null) {
        foreach (var item in Nodes)
        {
          if (!item.is_true)
          {
            this.is_true = false;
            return;
          }
        }
      }
      this.is_true = true;
    }
  }
}

