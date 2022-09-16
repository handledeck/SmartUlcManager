using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.ui
{
  public class TextBoxPlaceHolder:TextBox
  {
    private const int EM_SETCUEBANNER = 0x1501;

    [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
    private static extern Int32 SendMessage(IntPtr hWnd, int msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
    public TextBoxPlaceHolder()
    {
      //this._cueFont = new Font(this.Font, FontStyle.Italic);
      _cueText = "Insert text";
      SendMessage(this.Handle, EM_SETCUEBANNER, 0, _cueText);
    }

    private string _cueText;

    [Browsable(true)]
    [Category("CueText")]
    public string CueText
    {
      get
      {
        return _cueText;
      }
      set
      {
        _cueText = value;
        SendMessage(this.Handle, EM_SETCUEBANNER, 0, _cueText);
        //Invalidate();
      }
    }

    public bool IsValid { get; set; }

    //protected override void WndProc(ref Message m)
    //{
    //  base.WndProc(ref m);

    //  const int WM_PAINT = 0xF;
    //  if (m.Msg == WM_PAINT)
    //  {
    //    if (!Focused && String.IsNullOrEmpty(Text) && !String.IsNullOrEmpty(CueText))
    //    {
    //      using (var graphics = CreateGraphics())
    //      {
    //        TextRenderer.DrawText(
    //            dc: graphics,
    //            text: CueText,
    //            font: new Font(this.Font, FontStyle.Italic),
    //            bounds: ClientRectangle,
    //            foreColor: SystemColors.GrayText,
    //            backColor: Enabled ? BackColor : SystemColors.Control,
    //            flags: TextFormatFlags.VerticalCenter | TextFormatFlags.Left); ;
    //      }
    //    }
    //  }
    //}
  }
}
