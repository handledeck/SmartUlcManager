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
  public partial class ViewTextControl : UserControl
  {
    public ViewTextControl()
    {
      InitializeComponent();
    }

    public string Caption
    {
      get { return label1.Text; }
      set { label1.Text = value; }
    }

    public string Value
    {
      get { return label2.Text; }
      set { label2.Text = value; }
    }

  }
}
