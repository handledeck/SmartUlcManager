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
  public partial class RoundedControl : UserControl
  {
    public RoundedControl()
    {
      InitializeComponent();
    }

    [Category("Custom")]
    [Browsable(true)]
    [Description("Sets the color of the round ")]
    [Editor(typeof(System.Windows.Forms.Design.WindowsFormsComponentEditor), typeof(System.Drawing.Color))]
    public Color BackShapeColor
    {
      get
      {
        return this.roundBorderShape1.fillColor;
      }
      set
      {
        this.roundBorderShape1.isFill = true;
        this.roundBorderShape1.fillColor = value;
        this.Invalidate();
      }
    }

    [Category("Custom")]
    [Browsable(true)]
    [Description("Sets radius angle")]
    /*[Editor(typeof(System.Windows.Forms.Design.WindowsFormsComponentEditor), typeof(System.Drawing.Color))]*/
    public int RoundCorner
    {
      get
      {
        return this.roundBorderShape1.radius;
      }
      set
      {
        this.roundBorderShape1.radius = value;
        this.Invalidate();
      }
    }

    private void roundBorderPanel1_SizeChanged(object sender, EventArgs e)
    {
      this.Invalidate();
    }
  }
}
