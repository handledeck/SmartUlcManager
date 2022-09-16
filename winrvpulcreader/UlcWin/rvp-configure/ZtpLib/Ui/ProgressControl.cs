using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class ProgressControl : UserControl
  {
    public ProgressControl()
    {
      InitializeComponent(); 
    }

    public string Caption
    {
      get { return label1.Text; }
      set { label1.Text = value; }
    }

    public int Minimum
    {
      get { return progressBar1.Minimum; }
      set { progressBar1.Minimum = value; }
    }

    public int Maximum
    {
      get { return progressBar1.Maximum; }
      set { progressBar1.Maximum = value; }
    }

    public int Step
    {
      get { return progressBar1.Step; }
      set { progressBar1.Step = value; }
    }

    public ProgressBarStyle Style
    {
      get { return progressBar1.Style; }
      set { progressBar1.Style = value; }
    }

    public void Increment(int value)
    {
      progressBar1.Increment(value);
      Application.DoEvents();
    }
  }
}
