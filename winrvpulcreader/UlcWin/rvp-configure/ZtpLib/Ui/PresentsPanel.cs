using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class PresentsPanel : UserControl
  {
    public PresentsPanel()
    {
      InitializeComponent();
    }

    private Color _lineColor = Color.Black;

    public Color LineColor
    {
      get { return _lineColor; }
      set
      {
        _lineColor = value;
        Invalidate();
      }
    }

    private int _lineWeight = 3;

    public int LineWeight
    {
      get { return _lineWeight; }
      set
      {
        _lineWeight = value; 
        Invalidate();
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      Rectangle rect = new Rectangle(ClientRectangle.X + 5, ClientRectangle.Y + 5, ClientRectangle.Width - 5, LineWeight);
      Brush brush = new LinearGradientBrush(rect, LineColor, Color.White, LinearGradientMode.Horizontal);
      e.Graphics.FillRectangle(brush, rect);
      brush.Dispose();
    }

    protected override void OnResize(EventArgs e)
    {
      Invalidate();
    }
  }
}
