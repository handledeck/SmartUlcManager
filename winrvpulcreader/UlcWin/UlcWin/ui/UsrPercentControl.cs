using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.ui
{
  public partial class UsrPercentControl : UserControl
  {
    Color __color = Color.Black;
    public UsrPercentControl()
    {
      InitializeComponent();
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
        this.lblPercent.ForeColor = this.__color;
       
      }
    }

  }
}
