using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin
{
  public class DataMsg {
    public DateTime Date { get; set; }
    public string Message { get; set; }
  }
  public class ItemIp
  {
    public string NodeFullPath { get; set; }
    public string Name { get; set; }
    public string Ip { get; set; }
    public string Phone { get; set; }
    public DateTime Date { get; set; }
    public int Id { get; set; }
    public bool IsTrue { get; set; }
    public bool IsMsgTrue { get; set; }
    public int IdMessage { get; set; }
    public byte UType { get; set; }
    public bool  Ping { get; set; }
    public DataMsg MsgConfig { get; set; }
    public UlcCfg UlcConfig { get; set; }
    public bool IsUpdateInable { get; set; }
    public string PmVesion { get; set; }
    public int Active { get; set; }
    public int IsLight { get; set; }
    public string Comments { get; set; }
    public string  Meters { get; set; }
    public int Rs_Stat { get; set; }
   
  }
}
