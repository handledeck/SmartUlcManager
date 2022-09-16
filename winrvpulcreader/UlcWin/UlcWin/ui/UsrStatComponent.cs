using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.Statistics;

namespace UlcWin.ui
{
  public partial class UsrStatComponent : UserControl
  {
    Color __color = Color.Black;
    Font __font = null;
    public UsrStatComponent()
    {
      InitializeComponent();
      this.__font = this.lblAll.Font;
    }

    [Category("Custom")]
    [Browsable(true)]
    [Description("Sets the color of the round ")]
    [Editor(typeof(System.Windows.Forms.Design.WindowsFormsComponentEditor), typeof(System.Drawing.Color))]
    public Color InitColor
    {
      get
      {
        return __color;
      }
      set
      {
        this.__color = value;
        this.lblAll.ForeColor = this.__color;
        this.lblAllNot.ForeColor = this.__color;
        this.lblAllNotRs.ForeColor = this.__color;
        this.lblAllGsm.ForeColor = this.__color;
      }
    }

    [Category("Custom")]
    [Browsable(true)]
    [Description("Sets the color of the round ")]
    [Editor(typeof(System.Windows.Forms.Design.WindowsFormsComponentEditor), typeof(System.Drawing.Font))]
    public Font InitFont
    {
      get
      {
        return __font;
      }
      set
      {
        this.__font = value;
        this.lblAll.Font = this.__font;
        
      }
    }


  }

}
