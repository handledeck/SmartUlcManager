using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class InputDoubleControl : UserControl
  {
    public InputDoubleControl()
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

    public decimal Value
    {
      get { return numericUpDown.Value; }
      set { numericUpDown.Value = value; }
    }

    public decimal Maximum
    {
      get { return numericUpDown.Maximum; }
      set { numericUpDown.Maximum = value; }
    }

    public decimal Increment
    {
      get { return numericUpDown.Increment; }
      set { numericUpDown.Increment = value; }
    }
    public decimal Minimum
    {
      get { return numericUpDown.Minimum; }
      set { numericUpDown.Minimum = value; }
    }

    public bool ReadOnly
    {
      get { return numericUpDown.ReadOnly; }
      set { numericUpDown.ReadOnly = value; }
    }

    public int DecimalPlaces
    {
      get { return numericUpDown.DecimalPlaces; }
      set { numericUpDown.DecimalPlaces = value; }
    }

    public event EventHandler ValueChanged;
    private void numericUpDown_ValueChanged(object sender, EventArgs e)
    {
      OnValueChanged();
    }

    protected virtual void OnValueChanged()
    {
      ValueChanged?.Invoke(this, EventArgs.Empty);
    }
  }
}
