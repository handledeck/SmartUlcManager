using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class InputTextControl : UserControl
  {
    public InputTextControl()
    {
      InitializeComponent();
    }

    public int CaptionWidth
    {
      get { return Convert.ToInt32(tableLayoutPanel.ColumnStyles[0].Width); }
      set { tableLayoutPanel.ColumnStyles[0].Width = value; }
    }

    public string Caption
    {
      get { return label1.Text; }
      set { label1.Text = value; }
    }

    public string Value
    {
      get { return textBox1.Text; }
      set { textBox1.Text = value; }
    }

    public char PasswordChar
    {
      get { return textBox1.PasswordChar; }
      set { textBox1.PasswordChar = value; }
    }

    public bool ReadOnly
    {
      get { return textBox1.ReadOnly; }
      set { textBox1.ReadOnly = value; }
    }

  }
}
