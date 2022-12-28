using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.Native
{
  class NativeSort
  {
    public class NativeListView
    {



      public static IntPtr GetHeaderControl(ListView list)
      {
        return NativeMethod.SendMessage(list.Handle, NativeMethod.LVM_GETHEADER, 0, 0);
      }

      private Bitmap MakeTriangleBitmap(Size sz, Point[] pts)
      {
        Bitmap bm = new Bitmap(sz.Width, sz.Height);
        Graphics g = Graphics.FromImage(bm);
        g.FillPolygon(new SolidBrush(Color.Gray), pts);
        return bm;
      }

      public static void SetColumnImage(ListView list, int columnIndex, SortOrder order, int imageIndex)
      {
        IntPtr hdrCntl = GetHeaderControl(list);
        if (hdrCntl.ToInt32() == 0)
          return;

        NativeMethod.HDITEM item = new NativeMethod.HDITEM();
        item.mask = NativeMethod.HDI_FORMAT;
        IntPtr result = NativeMethod.SendMessageHDItem(hdrCntl, NativeMethod.HDM_GETITEM, columnIndex, ref item);

        item.fmt &= ~(NativeMethod.HDF_SORTUP | NativeMethod.HDF_SORTDOWN | NativeMethod.HDF_IMAGE | NativeMethod.HDF_BITMAP_ON_RIGHT);

        //if (NativeMethods.HasBuiltinSortIndicators())
        //{
        if (order == SortOrder.Ascending)
          item.fmt |= NativeMethod.HDF_SORTUP;
        if (order == SortOrder.Descending)
          item.fmt |= NativeMethod.HDF_SORTDOWN;
        //}
        //else
        //{
        //  item.mask |= NativeMethod.HDI_IMAGE;
        //  item.fmt |= (NativeMethod.HDF_IMAGE | NativeMethod.HDF_BITMAP_ON_RIGHT);
        //  item.iImage = imageIndex;
        //}

        result = NativeMethod.SendMessageHDItem(hdrCntl, NativeMethod.HDM_SETITEM, columnIndex, ref item);
      }
    }
  }
}
