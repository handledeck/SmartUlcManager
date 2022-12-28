using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.Controls.ListViewHeaderMenu
{
  public delegate void ColumnRightClickEvent(object sender, ColumnHeader e, Point point);
  public delegate void ListViewRightClickEvent(object sender);
  public partial class ListViewMenuHeaderControl : ListView
  {
    Dictionary<int, Rectangle> columns = new Dictionary<int, Rectangle>();
    public event ColumnRightClickEvent ColumnRightClick;
    public event ListViewRightClickEvent ListViewMouseRightClick;
    public ListViewMenuHeaderControl()
    {
      
      InitializeComponent();
      OwnerDraw = true;
    }
    protected override void OnDrawItem(DrawListViewItemEventArgs e)
    {
      e.DrawDefault = true;
      base.OnDrawItem(e);
    }
    protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
    {
      e.DrawDefault = true;
      base.OnDrawSubItem(e);
    }
    protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
    {
      columns[e.ColumnIndex] = RectangleToScreen(e.Bounds);
      e.DrawDefault = true;
      base.OnDrawColumnHeader(e);
    }
    protected override void WndProc(ref Message m)
    {
      if (m.Msg == 0x7b)//WM_CONTEXTMENU
      {
        int lp = m.LParam.ToInt32();
        int x = ((lp << 16) >> 16);
        int y = lp >> 16;
        foreach (KeyValuePair<int, Rectangle> p in columns)
        {
          if (p.Value.Contains(new Point(x, y)))
          {
            //this.contextMenuStrip.Show(new Point(x, y));
            if (ColumnRightClick != null)
              ColumnRightClick(this, Columns[p.Key], new Point(x, y));
            //MessageBox.Show(Columns[p.Key].Text);// <-- Try this to test if you want.
            //Show your HeaderContextMenu corresponding to a Column here.
            break;
          }
        }
      }
      else if (m.Msg == 0x205 || m.Msg==204) {
        if (this.ListViewMouseRightClick != null)
          this.ListViewMouseRightClick(this);
      }
      base.WndProc(ref m);
    }

    public ListViewMenuHeaderControl(IContainer container)
    {
      container.Add(this);

      InitializeComponent();
    }
  }

  internal static class ListViewExtensions
  {
    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    public struct HDITEM
    {
      public int mask;
      public int cxy;
      [System.Runtime.InteropServices.MarshalAs(UnmanagedType.LPTStr)]
      public string pszText;
      public IntPtr hbm;
      public int cchTextMax;
      public int fmt;
      public IntPtr lParam;
      // _WIN32_IE >= 0x0300 
      public int iImage;
      public int iOrder;
      // _WIN32_IE >= 0x0500
      public uint type;
      public IntPtr pvFilter;
      // _WIN32_WINNT >= 0x0600
      public uint state;
      [Flags]
      public enum Mask
      {
        Format = 0x4,  // HDI_FORMAT
      };
      [Flags]
      public enum Format
      {
        SortDown = 0x200,   // HDF_SORTDOWN
        SortUp = 0x400,     // HDF_SORTUP
      };
    };
    private const int HDM_FIRST = 0x1200;
    private const int LVM_FIRST = 0x1000;
    private const int HDM_GETITEMCOUNT = (HDM_FIRST + 0);
    private const int HDM_SETITEM = (HDM_FIRST + 4);
    private const int LVM_GETHEADER = (LVM_FIRST + 31);
    private const int HDM_GETITEM = (HDM_FIRST + 3);
    [DllImport("user32.dll", EntryPoint = "SendMessageA")]
    private static extern IntPtr SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
    [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessage")]
    public static extern IntPtr SendMessageHDITEM(IntPtr hWnd, uint Msg, IntPtr wParam, ref HDITEM hdItem);
    public static void SetSortIcon(this System.Windows.Forms.ListView ListViewControl, int ColumnIndex, System.Windows.Forms.SortOrder Order)
    {
      IntPtr ColumnHeader = SendMessage(ListViewControl.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
      for (int ColumnNumber = 0; ColumnNumber <= ListViewControl.Columns.Count - 1; ColumnNumber++)
      {
        IntPtr ColumnPtr = new IntPtr(ColumnNumber);
        HDITEM item = new HDITEM();
        item.mask = (int)HDITEM.Mask.Format;
        SendMessageHDITEM(ColumnHeader, HDM_GETITEM, ColumnPtr, ref item);
        if (!(Order == System.Windows.Forms.SortOrder.None) && ColumnNumber == ColumnIndex)
        {
          switch (Order)
          {
            case System.Windows.Forms.SortOrder.Ascending:
              item.fmt &= ~(int)HDITEM.Format.SortDown;
              item.fmt |= (int)HDITEM.Format.SortUp;
              break;
            case System.Windows.Forms.SortOrder.Descending:
              item.fmt &= ~(int)HDITEM.Format.SortUp;
              item.fmt |= (int)HDITEM.Format.SortDown;
              break;
          }
        }
        else
        {
          item.fmt &= ~(int)HDITEM.Format.SortDown & ~(int)HDITEM.Format.SortUp;
        }
        SendMessageHDITEM(ColumnHeader, HDM_SETITEM, ColumnPtr, ref item);
      }
    }
  }
}
