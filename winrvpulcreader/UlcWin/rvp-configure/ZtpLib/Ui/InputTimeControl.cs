using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class InputTimeControl : UserControl
  {
    public InputTimeControl()
    {
      InitializeComponent();
    }

    public string Caption
    {
      get { return label1.Text; }
      set { label1.Text = value; }
    }

    public DateTime Value
    {
      get { return dateTimePicker1.Value; }
      set { dateTimePicker1.Value = value; }
    }

    public bool ReadOnly
    {
      get { return !dateTimePicker1.Enabled; }
      set { dateTimePicker1.Enabled = !value; }
    }
  }
}
