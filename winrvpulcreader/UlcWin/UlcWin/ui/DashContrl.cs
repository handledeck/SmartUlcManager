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
  public partial class DashContrl : UserControl
  {
    public DashContrl()
    {
      InitializeComponent();
      
      
    }



    public void SetValueInControl(string header, string data, string comment) {
      this.lblValue.Text = header;
      this.lblComment.Text = comment;
      this.lblHeader.Text = data;

    }

    public void SetComment(Color color) {
      this.lblComment.ForeColor = color;
    }
    Color __color = Color.White; 
    [Browsable(true)]
    [Category("Uncnow")]
    public Color ColorData
    {
      get { return __color; }
      set { __color = value; }
    }

    private void panel_Paint(object sender, PaintEventArgs e)
    {

      ControlPaint.DrawBorder(e.Graphics, ((Control)sender).ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid);
      this.lblValue.BackColor = __color;
      this.lblValue.ForeColor= Color.White;

    }

  }
}
