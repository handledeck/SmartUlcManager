using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.Controls.MeterProgress
{
  public partial class LineHorizont : Label

  {
    public LineHorizont()
    {
      InitializeComponent();
      this.AutoSize = false;
      this.Text = "";
    }

    public override string Text { get => ""; }

    public override bool AutoSize { get => false; }
    public override BorderStyle BorderStyle { get => BorderStyle.Fixed3D; }

    public override Size MaximumSize
    {
      get => new Size(base.MaximumSize.Width, 2);
      set => new Size(value.Width, 2);
    }
    //public override Size MaximumSize { get => new Size(this.Size.Width,2);}
    //public override Size Size{ get => new Size(base.Size.Width,2); }

    //public override Size MaximumSize { get => base.MaximumSize; set => base.MaximumSize = value; }

    public LineHorizont(IContainer container)
    {
      container.Add(this);

      InitializeComponent();
      //this.Resize += Borer_Resize;

    }

    private void Borer_Resize(object sender, EventArgs e)
    {
      //this.Size = new System.Drawing.Size(this.Width, 2);
    }
  }
}
