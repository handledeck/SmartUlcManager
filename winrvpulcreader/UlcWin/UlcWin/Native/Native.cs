﻿using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin
{
  public class NativeMethod
  {

    public static IntPtr GetHeaderControl(ListView list)
    {
      return SendMessage(list.Handle, LVM_GETHEADER, 0, 0);
    }

    /// <summary>
    /// Setup the given column of the listview to show the given image to the right of the text.
    /// If the image index is -1, any previous image is cleared
    /// </summary>
    /// <param name="list">The listview to send a m to</param>
    /// <param name="columnIndex">Index of the column to modify</param>
    /// <param name="order"></param>
    /// <param name="imageIndex">Index into the small image list</param>
    public static void SetColumnImage(ListView list, int columnIndex, SortOrder order, int imageIndex)
    {
      IntPtr hdrCntl = GetHeaderControl(list);
      if (hdrCntl.ToInt32() == 0)
        return;

      HDITEM item = new HDITEM();
      item.mask = HDI_FORMAT;
      IntPtr result = SendMessageHDItem(hdrCntl, HDM_GETITEM, columnIndex, ref item);

      item.fmt &= ~(HDF_SORTUP | HDF_SORTDOWN | HDF_IMAGE | HDF_BITMAP_ON_RIGHT);

     //// if (NativeMethods.HasBuiltinSortIndicators())
     // //{
     //   if (order == SortOrder.Ascending)
     //     item.fmt |= HDF_SORTUP;
     //   if (order == SortOrder.Descending)
     //     item.fmt |= HDF_SORTDOWN;
     // //}
     // else
     // {
        item.mask |= HDI_IMAGE;
        item.fmt |= (HDF_IMAGE | HDF_BITMAP_ON_RIGHT);
        item.iImage = imageIndex;
      //}

      result = SendMessageHDItem(hdrCntl, HDM_SETITEM, columnIndex, ref item);
    }

    public void DrawSortIcon(ListView listView, int itemIndex) {
      Rectangle r = GetHeaderDrawRect(listView, itemIndex);
    }

    public Rectangle GetHeaderDrawRect(ListView listView,int itemIndex)
    {
      Rectangle r = this.GetItemRect(listView,itemIndex);

      // Tweak the text rectangle a little to improve aesthetics
      r.Inflate(-3, 0);
      r.Y -= 2;

      return r;
    }

    

    public Rectangle GetItemRect(ListView listView, int itemIndex)
    {
      const int HDM_FIRST = 0x1200;
      const int HDM_GETITEMRECT = HDM_FIRST + 7;
      RECT r = new RECT();
      IntPtr hdrCntl = GetHeaderControl(listView);
      SendMessageRECT(hdrCntl, HDM_GETITEMRECT, itemIndex, ref r);
      return Rectangle.FromLTRB(r.left, r.top, r.right, r.bottom);
    }

    public static void SetSubItemImage(ListView list, int itemIndex, int subItemIndex, int imageIndex)
    {
      LVITEM lvItem = new LVITEM();
      lvItem.mask = LVIF_IMAGE;
      lvItem.iItem = itemIndex;
      lvItem.iSubItem = subItemIndex;
      lvItem.iImage = imageIndex;
      SendMessageLVItem(list.Handle, LVM_SETITEM, 0, ref lvItem);
    }

    public const int LVM_FIRST = 0x1000;
    public const int LVM_GETCOLUMN = LVM_FIRST + 95;
    public const int LVM_GETCOUNTPERPAGE = LVM_FIRST + 40;
    public const int LVM_GETGROUPINFO = LVM_FIRST + 149;
    public const int LVM_GETGROUPSTATE = LVM_FIRST + 92;
    public const int LVM_GETHEADER = LVM_FIRST + 31;
    public const int LVM_GETTOOLTIPS = LVM_FIRST + 78;
    public const int LVM_GETTOPINDEX = LVM_FIRST + 39;
    public const int LVM_HITTEST = LVM_FIRST + 18;
    public const int LVM_INSERTGROUP = LVM_FIRST + 145;
    public const int LVM_REMOVEALLGROUPS = LVM_FIRST + 160;
    public const int LVM_SCROLL = LVM_FIRST + 20;
    public const int LVM_SETBKIMAGE = LVM_FIRST + 0x8A;
    public const int LVM_SETCOLUMN = LVM_FIRST + 96;
    public const int LVM_SETEXTENDEDLISTVIEWSTYLE = LVM_FIRST + 54;
    public const int LVM_SETGROUPINFO = LVM_FIRST + 147;
    public const int LVM_SETGROUPMETRICS = LVM_FIRST + 155;
    public const int LVM_SETIMAGELIST = LVM_FIRST + 3;
    public const int LVM_SETITEM = LVM_FIRST + 76;
    public const int LVM_SETITEMCOUNT = LVM_FIRST + 47;
    public const int LVM_SETITEMSTATE = LVM_FIRST + 43;
    public const int LVM_SETSELECTEDCOLUMN = LVM_FIRST + 140;
    public const int LVM_SETTOOLTIPS = LVM_FIRST + 74;
    public const int LVM_SUBITEMHITTEST = LVM_FIRST + 57;
    public const int LVS_EX_SUBITEMIMAGES = 0x0002;
    public const int LVIF_TEXT = 0x0001;
    public const int LVIF_IMAGE = 0x0002;
    public const int LVIF_PARAM = 0x0004;
    public const int LVIF_STATE = 0x0008;
    public const int LVIF_INDENT = 0x0010;
    public const int LVIF_NORECOMPUTE = 0x0800;
    public const int LVIS_SELECTED = 2;
    public const int LVCF_FMT = 0x0001;
    public const int LVCF_WIDTH = 0x0002;
    public const int LVCF_TEXT = 0x0004;
    public const int LVCF_SUBITEM = 0x0008;
    public const int LVCF_IMAGE = 0x0010;
    public const int LVCF_ORDER = 0x0020;
    public const int LVCFMT_LEFT = 0x0000;
    public const int LVCFMT_RIGHT = 0x0001;
    public const int LVCFMT_CENTER = 0x0002;
    public const int LVCFMT_JUSTIFYMASK = 0x0003;
    public const int LVCFMT_IMAGE = 0x0800;
    public const int LVCFMT_BITMAP_ON_RIGHT = 0x1000;
    public const int LVCFMT_COL_HAS_IMAGES = 0x8000;
    public const int LVBKIF_SOURCE_NONE = 0x0;
    public const int LVBKIF_SOURCE_HBITMAP = 0x1;
    public const int LVBKIF_SOURCE_URL = 0x2;
    public const int LVBKIF_SOURCE_MASK = 0x3;
    public const int LVBKIF_STYLE_NORMAL = 0x0;
    public const int LVBKIF_STYLE_TILE = 0x10;
    public const int LVBKIF_STYLE_MASK = 0x10;
    public const int LVBKIF_FLAG_TILEOFFSET = 0x100;
    public const int LVBKIF_TYPE_WATERMARK = 0x10000000;
    public const int LVBKIF_FLAG_ALPHABLEND = 0x20000000;
    public const int LVSICF_NOINVALIDATEALL = 1;
    public const int LVSICF_NOSCROLL = 2;
    public const int HDM_FIRST = 0x1200;
    public const int HDM_HITTEST = HDM_FIRST + 6;
    public const int HDM_GETITEMRECT = HDM_FIRST + 7;
    public const int HDM_GETITEM = HDM_FIRST + 11;
    public const int HDM_SETITEM = HDM_FIRST + 12;
    public const int HDI_WIDTH = 0x0001;
    public const int HDI_TEXT = 0x0002;
    public const int HDI_FORMAT = 0x0004;
    public const int HDI_BITMAP = 0x0010;
    public const int HDI_IMAGE = 0x0020;
    public const int HDF_LEFT = 0x0000;
    public const int HDF_RIGHT = 0x0001;
    public const int HDF_CENTER = 0x0002;
    public const int HDF_JUSTIFYMASK = 0x0003;
    public const int HDF_RTLREADING = 0x0004;
    public const int HDF_STRING = 0x4000;
    public const int HDF_BITMAP = 0x2000;
    public const int HDF_BITMAP_ON_RIGHT = 0x1000;
    public const int HDF_IMAGE = 0x0800;
    public const int HDF_SORTUP = 0x0400;
    public const int HDF_SORTDOWN = 0x0200;
    public const int SB_HORZ = 0;
    public const int SB_VERT = 1;
    public const int SB_CTL = 2;
    public const int SB_BOTH = 3;
    public const int SIF_RANGE = 0x0001;
    public const int SIF_PAGE = 0x0002;
    public const int SIF_POS = 0x0004;
    public const int SIF_DISABLENOSCROLL = 0x0008;
    public const int SIF_TRACKPOS = 0x0010;
    public const int SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS);
    public const int ILD_NORMAL = 0x0;
    public const int ILD_TRANSPARENT = 0x1;
    public const int ILD_MASK = 0x10;
    public const int ILD_IMAGE = 0x20;
    public const int ILD_BLEND25 = 0x2;
    public const int ILD_BLEND50 = 0x4;

    const int SWP_NOSIZE = 1;
    const int SWP_NOMOVE = 2;
    const int SWP_NOZORDER = 4;
    const int SWP_NOREDRAW = 8;
    const int SWP_NOACTIVATE = 16;
    public const int SWP_FRAMECHANGED = 32;

    const int SWP_ZORDERONLY = SWP_NOSIZE | SWP_NOMOVE | SWP_NOREDRAW | SWP_NOACTIVATE;
    const int SWP_SIZEONLY = SWP_NOMOVE | SWP_NOREDRAW | SWP_NOZORDER | SWP_NOACTIVATE;
    const int SWP_UPDATE_FRAME = SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVATE | SWP_NOZORDER | SWP_FRAMECHANGED;



    #region Structures

    [StructLayout(LayoutKind.Sequential)]
    public struct HDITEM
    {
      public int mask;
      public int cxy;
      public IntPtr pszText;
      public IntPtr hbm;
      public int cchTextMax;
      public int fmt;
      public IntPtr lParam;
      public int iImage;
      public int iOrder;
      //if (_WIN32_IE >= 0x0500)
      public int type;
      public IntPtr pvFilter;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class HDHITTESTINFO
    {
      public int pt_x;
      public int pt_y;
      public int flags;
      public int iItem;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class HDLAYOUT
    {
      public IntPtr prc;
      public IntPtr pwpos;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGELISTDRAWPARAMS
    {
      public int cbSize;
      public IntPtr himl;
      public int i;
      public IntPtr hdcDst;
      public int x;
      public int y;
      public int cx;
      public int cy;
      public int xBitmap;
      public int yBitmap;
      public uint rgbBk;
      public uint rgbFg;
      public uint fStyle;
      public uint dwRop;
      public uint fState;
      public uint Frame;
      public uint crEffect;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct LVBKIMAGE
    {
      public int ulFlags;
      public IntPtr hBmp;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string pszImage;
      public int cchImageMax;
      public int xOffset;
      public int yOffset;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct LVCOLUMN
    {
      public int mask;
      public int fmt;
      public int cx;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string pszText;
      public int cchTextMax;
      public int iSubItem;
      // These are available in Common Controls >= 0x0300
      public int iImage;
      public int iOrder;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct LVFINDINFO
    {
      public int flags;
      public string psz;
      public IntPtr lParam;
      public int ptX;
      public int ptY;
      public int vkDirection;
    }

    [StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct LVGROUP
    {
      public uint cbSize;
      public uint mask;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string pszHeader;
      public int cchHeader;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string pszFooter;
      public int cchFooter;
      public int iGroupId;
      public uint stateMask;
      public uint state;
      public uint uAlign;
    }

    [StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct LVGROUP2
    {
      public uint cbSize;
      public uint mask;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string pszHeader;
      public uint cchHeader;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string pszFooter;
      public int cchFooter;
      public int iGroupId;
      public uint stateMask;
      public uint state;
      public uint uAlign;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string pszSubtitle;
      public uint cchSubtitle;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string pszTask;
      public uint cchTask;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string pszDescriptionTop;
      public uint cchDescriptionTop;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string pszDescriptionBottom;
      public uint cchDescriptionBottom;
      public int iTitleImage;
      public int iExtendedImage;
      public int iFirstItem;         // Read only
      public int cItems;             // Read only
      [MarshalAs(UnmanagedType.LPTStr)]
      public string pszSubsetTitle;     // NULL if group is not subset
      public uint cchSubsetTitle;
    }

    [StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct LVGROUPMETRICS
    {
      public uint cbSize;
      public uint mask;
      public uint Left;
      public uint Top;
      public uint Right;
      public uint Bottom;
      public int crLeft;
      public int crTop;
      public int crRight;
      public int crBottom;
      public int crHeader;
      public int crFooter;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct LVHITTESTINFO
    {
      public int pt_x;
      public int pt_y;
      public int flags;
      public int iItem;
      public int iSubItem;
      public int iGroup;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct LVITEM
    {
      public int mask;
      public int iItem;
      public int iSubItem;
      public int state;
      public int stateMask;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string pszText;
      public int cchTextMax;
      public int iImage;
      public IntPtr lParam;
      // These are available in Common Controls >= 0x0300
      public int iIndent;
      // These are available in Common Controls >= 0x056
      public int iGroupId;
      public int cColumns;
      public IntPtr puColumns;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NMHDR
    {
      public IntPtr hwndFrom;
      public IntPtr idFrom;
      public int code;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMCUSTOMDRAW
    {
      public NMHDR nmcd;
      public int dwDrawStage;
      public IntPtr hdc;
      public RECT rc;
      public IntPtr dwItemSpec;
      public int uItemState;
      public IntPtr lItemlParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMHEADER
    {
      public NMHDR nhdr;
      public int iItem;
      public int iButton;
      public IntPtr pHDITEM;
    }

    const int MAX_LINKID_TEXT = 48;
    const int L_MAX_URL_LENGTH = 2048 + 32 + 4;
    //#define L_MAX_URL_LENGTH    (2048 + 32 + sizeof("://"))

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LITEM
    {
      public uint mask;
      public int iLink;
      public uint state;
      public uint stateMask;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_LINKID_TEXT)]
      public string szID;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = L_MAX_URL_LENGTH)]
      public string szUrl;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMLISTVIEW
    {
      public NMHDR hdr;
      public int iItem;
      public int iSubItem;
      public int uNewState;
      public int uOldState;
      public int uChanged;
      public IntPtr lParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMLVCUSTOMDRAW
    {
      public NMCUSTOMDRAW nmcd;
      public int clrText;
      public int clrTextBk;
      public int iSubItem;
      public int dwItemType;
      public int clrFace;
      public int iIconEffect;
      public int iIconPhase;
      public int iPartId;
      public int iStateId;
      public RECT rcText;
      public uint uAlign;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMLVFINDITEM
    {
      public NMHDR hdr;
      public int iStart;
      public LVFINDINFO lvfi;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMLVGETINFOTIP
    {
      public NMHDR hdr;
      public int dwFlags;
      public string pszText;
      public int cchTextMax;
      public int iItem;
      public int iSubItem;
      public IntPtr lParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMLVGROUP
    {
      public NMHDR hdr;
      public int iGroupId; // which group is changing
      public uint uNewState; // LVGS_xxx flags
      public uint uOldState;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMLVLINK
    {
      public NMHDR hdr;
      public LITEM link;
      public int iItem;
      public int iSubItem;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NMLVSCROLL
    {
      public NMHDR hdr;
      public int dx;
      public int dy;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct NMTTDISPINFO
    {
      public NMHDR hdr;
      [MarshalAs(UnmanagedType.LPTStr)]
      public string lpszText;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
      public string szText;
      public IntPtr hinst;
      public int uFlags;
      public IntPtr lParam;
      //public int hbmp; This is documented but doesn't work
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
      public int left;
      public int top;
      public int right;
      public int bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class SCROLLINFO
    {
      public int cbSize = Marshal.SizeOf(typeof(SCROLLINFO));
      public int fMask;
      public int nMin;
      public int nMax;
      public int nPage;
      public int nPos;
      public int nTrackPos;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class TOOLINFO
    {
      public int cbSize = Marshal.SizeOf(typeof(TOOLINFO));
      public int uFlags;
      public IntPtr hwnd;
      public IntPtr uId;
      public RECT rect;
      public IntPtr hinst = IntPtr.Zero;
      public IntPtr lpszText;
      public IntPtr lParam = IntPtr.Zero;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
      public IntPtr hwnd;
      public IntPtr hwndInsertAfter;
      public int x;
      public int y;
      public int cx;
      public int cy;
      public int flags;
    }

    #endregion



    // Various flavours of SendMessage: plain vanilla, and passing references to various structures
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, int lParam);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
    [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessageLVItem(IntPtr hWnd, int msg, int wParam, ref LVITEM lvi);
    [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref LVHITTESTINFO ht);
    [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessageRECT(IntPtr hWnd, int msg, int wParam, ref RECT r);
    //[DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
    //private static extern IntPtr SendMessageLVColumn(IntPtr hWnd, int m, int wParam, ref LVCOLUMN lvc);
    [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessageHDItem(IntPtr hWnd, int msg, int wParam, ref HDITEM hdi);
    [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessageHDHITTESTINFO(IntPtr hWnd, int Msg, IntPtr wParam, [In, Out] HDHITTESTINFO lParam);
    [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessageTOOLINFO(IntPtr hWnd, int Msg, int wParam, TOOLINFO lParam);
    [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessageLVBKIMAGE(IntPtr hWnd, int Msg, int wParam, ref LVBKIMAGE lParam);
    [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessageString(IntPtr hWnd, int Msg, int wParam, string lParam);
    [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessageIUnknown(IntPtr hWnd, int msg, [MarshalAs(UnmanagedType.IUnknown)] object wParam, int lParam);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref LVGROUP lParam);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref LVGROUP2 lParam);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref LVGROUPMETRICS lParam);

    [DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr objectHandle);

    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern bool GetClientRect(IntPtr hWnd, ref Rectangle r);

    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern bool GetScrollInfo(IntPtr hWnd, int fnBar, SCROLLINFO scrollInfo);

    [DllImport("user32.dll", EntryPoint = "GetUpdateRect", CharSet = CharSet.Auto)]
    public static extern bool GetUpdateRectInternal(IntPtr hWnd, ref Rectangle r, bool eraseBackground);

    [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
    public static extern bool ImageList_Draw(IntPtr himl, int i, IntPtr hdcDst, int x, int y, int fStyle);

    [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
    public static extern bool ImageList_DrawIndirect(ref IMAGELISTDRAWPARAMS parms);

    [DllImport("user32.dll")]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle r);

    [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
    public static extern IntPtr GetWindowLong32(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr", CharSet = CharSet.Auto)]
    public static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
    public static extern IntPtr SetWindowLongPtr32(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto)]
    public static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll", EntryPoint = "ValidateRect", CharSet = CharSet.Auto)]
    public static extern IntPtr ValidatedRectInternal(IntPtr hWnd, ref Rectangle r);

  }
}
