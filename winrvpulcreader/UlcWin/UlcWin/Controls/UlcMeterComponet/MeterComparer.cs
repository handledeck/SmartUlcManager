using BrightIdeasSoftware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.Controls.UlcMeterComponet
{

  public class MeterComparer : IComparer
  {
    ListView listView;
    LoadForm loadForm;
    public int Column { get; set; }
    public SortOrder Order { get; set; }
    public UlcSort UsbSorting { get; set; }
    public MeterComparer(int colIndex)//, LoadForm form)
    {
      Column = colIndex;
      Order = SortOrder.None;
      UsbSorting = UlcSort.DEFAULT;
    }
    public int Compare(object a, object b)
    {

      int result = -1;
      ListViewItem itemA = a as ListViewItem;
      ListViewItem itemB = b as ListViewItem;
      this.listView = itemA.ListView;
      var zz = this.listView.Parent.Parent.Parent;
      if (itemA == null && itemB == null)
        result = 0;
      else if (itemA == null)
        result = -1;
      else if (itemB == null)
        result = 1;
      if (itemA == itemB)
        result = 0;

      switch (UsbSorting)
      {
        case UlcSort.DEFAULT:
          result = String.Compare(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
          break;
        case UlcSort.IP:
          IPAddress addr1 = null;
          IPAddress addr2 = null;
          if (System.Net.IPAddress.TryParse(itemA.SubItems[Column].Text, out addr1) &&
            System.Net.IPAddress.TryParse(itemB.SubItems[Column].Text, out addr2))
          {
            result = this.CompareIpAddresses(addr1, addr2);
          }
          break;
        case UlcSort.DATETIME:
          result = this.CompareDateTime(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
          break;
        case UlcSort.SIGNAL:
          result = CompareSignal(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
          break;
        case UlcSort.TRAFFIC:
          result = CompareTraffic(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
          break;
        case UlcSort.NAME:
          {
            ToolStripMenuItem item = (ToolStripMenuItem)loadForm.ctxMenuHeader.Items["ctxMenuObject"];
            if (item.Checked)
            {
              result = String.Compare(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
            }
            else
            {
              result = CompareName(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
            }
          }

          break;
        default:
          break;
      }
      if (Order == SortOrder.Descending)
        result *= -1;
      return result;
    }

    public int CompareName(string first, string second)
    {
      Regex reg = new Regex(@"\d+$");
      Match match = reg.Match(first.TrimEnd());
      Match match1 = reg.Match(second.TrimEnd());
      if (match.Success && match1.Success)
      {
        int fInt = 0;
        int sInt = 0;
        bool fb = int.TryParse(match.Value, out fInt);
        bool sb = int.TryParse(match1.Value, out sInt);
        if (!fb && !sb)
        {
          return -1;
        }
        else
        {
          if (fInt == sInt)
            return 0;
          if (fInt > sInt)
            return 1;
        }
      }
      return -1;
    }


    public int CompareTraffic(string first, string second)
    {
      Regex reg = new Regex(@".*?\s");
      Match match = reg.Match(first);
      Match match1 = reg.Match(second);
      if (match.Success && match1.Success)
      {
        int fInt = 0;
        int sInt = 0;
        bool fb = int.TryParse(match.Value, out fInt);
        bool sb = int.TryParse(match1.Value, out sInt);
        if (!fb && !sb)
        {
          return -1;
        }
        else
        {
          if (fInt == sInt)
            return 0;
          if (fInt > sInt)
            return 1;
        }
      }
      return -1;
    }

    public int CompareSignal(string first, string second)
    {

      if (first.Equals("---") || second.Equals("---"))
        return 1;
      else
      {
        string stF = first.Substring(0, first.Length - 4);
        string stS = second.Substring(0, second.Length - 4);
        int iF;
        int iS;
        bool bF = int.TryParse(stF, out iF);
        bool bS = int.TryParse(stS, out iS);
        if (!bF && !bS)
          return -1;
        else
        {
          if (iF == iS)
            return 0;
          if (iF > iS)
            return 1;
        }
        //return 1;
      }
      //var int1 = this.ToUint32(first);
      //var int2 = this.ToUint32(second);
      //if (int1 == int2)
      //  return 0;
      //if (int1 > int2)
      //  return 1;
      return -1;
    }

    public int CompareIpAddresses(System.Net.IPAddress first, System.Net.IPAddress second)
    {
      var int1 = this.ToUint32(first);
      var int2 = this.ToUint32(second);
      if (int1 == int2)
        return 0;
      if (int1 > int2)
        return 1;
      return -1;
    }


    public int CompareDateTime(string first, string second)
    {
      DateTime dtF;
      DateTime dtS;
      bool bF = DateTime.TryParse(first, out dtF);
      bool bS = DateTime.TryParse(second, out dtS);
      //DateTime fst = DateTime.Parse(first);
      //DateTime scd = DateTime.Parse(second);
      if (!bF || !bS)
        return 0;
      if (dtF == dtS)
        return 0;
      if (dtF > dtS)
        return 1;
      return -1;
    }

    public uint ToUint32(System.Net.IPAddress ipAddress)
    {
      var bytes = ipAddress.GetAddressBytes();

      return ((uint)(bytes[0] << 24)) |
             ((uint)(bytes[1] << 16)) |
             ((uint)(bytes[2] << 8)) |
             ((uint)(bytes[3]));
    }
  }

  class ListObj
  {
    public int Row { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
      return this.Name;
    }
  }
}
