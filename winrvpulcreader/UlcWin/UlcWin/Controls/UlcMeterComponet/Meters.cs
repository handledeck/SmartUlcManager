using ServiceStack.OrmLite;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin.Controls.UlcMeterComponet
{
  public class Meters
  {
    public int id { get; set; }
    public int parent_id { get; set; }
    public string name { get; set; }
    public string ip_address { get; set; }
    public string meters { get; set; }

    public List<MeterType> ListMeterType { get; set; }

    public static List<MeterType> ResolveMeters(string meters)
    {
      if (!string.IsNullOrEmpty(meters))
      {
        List<MeterType> lst = JsonSerializer.DeserializeFromString<List<MeterType>>(meters);
        foreach (var item in lst)
        {
          if (item.meter_factory == "Н/Д")
            item.meter_factory = string.Empty;
        }
        return lst;
      }
      else
        return null;
    }

    
  }
}
