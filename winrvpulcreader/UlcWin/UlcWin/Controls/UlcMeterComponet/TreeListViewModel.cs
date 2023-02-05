﻿using System;
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
    public double? value_month { get; set; }
    public bool is_true { get; set; }
    public int? unit_type_id { get; set; }
    public bool updated { get; set; }
    public int parent_id { get; set; }
    public int ctrl_id { get; set; }
    public List<TreeListNodeModel> Nodes { get; set; }
    public TreeListNodeModel ParentNode { get; set; }
    public int controller_active { get; set; }
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

    public bool rs_active { get; set; }
    public int meter_active { get; set; }

    public static MeterValue ConvertToMeterValue(TreeListNodeModel treeListNodeModel) {
      MeterValue meterValue;
      if (treeListNodeModel == null)
        return null;
      meterValue = new MeterValue()
      {
        ctrl_id = treeListNodeModel.id,
        date_time = treeListNodeModel.date_time.Value,
        //id = treeListNodeModel.id,
        ip = treeListNodeModel.ip,
        is_true = treeListNodeModel.is_true,
        meter_factory = treeListNodeModel.meter_factory,
        meter_type = treeListNodeModel.meter_type,
        value = treeListNodeModel.value.Value,
        value_month = treeListNodeModel.value_month.Value
      };
      return meterValue;
    }
  }

  public class UlcObjectParce {
    public string location { get; set; }
    public string country { get; set; }
    public string tp { get; set; }

    public static UlcObjectParce GetUlcObject(string message) {

      string[] ulc_parce = message.Split(',');
      if (ulc_parce.Length < 3)
        return null;
      else {
        return new UlcObjectParce()
        {
          location = ulc_parce[0],
          country = ulc_parce[1],
          tp = ulc_parce[2]
        };
      } 
       
    }
  }
  
}

