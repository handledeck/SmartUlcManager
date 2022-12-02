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
    public string original_name { get; set; }
    public string name { get; set; }
    public DateTime? date_time { get; set; }
    public string ip { get; set; }
    public string meter_type { get; set; }
    public string meter_factory { get; set; }
    public double? value { get; set; }
    public bool is_true { get; set; }
    public int? unit_type_id { get; set; }
    public bool updated { get; set; }
    public int parent_id { get; set; }
    public int ctrl_id { get; set; }
    public List<TreeListNodeModel> Nodes { get; set; }
    public bool is_part_true { get; set; }
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

    public static MeterValue ConvertToMeterValue(TreeListNodeModel treeListNodeModel) {
      MeterValue meterValue;
      if (treeListNodeModel == null)
        return null;
      meterValue = new MeterValue()
      {
        ctrl_id = treeListNodeModel.ctrl_id,
        date_time = treeListNodeModel.date_time.Value,
        id = treeListNodeModel.id,
        ip = treeListNodeModel.ip,
        is_true = treeListNodeModel.is_true,
        meter_factory = treeListNodeModel.meter_factory,
        meter_type = treeListNodeModel.meter_type,
        value = treeListNodeModel.value.Value
      };
      return meterValue;
    }
  }

  
}

