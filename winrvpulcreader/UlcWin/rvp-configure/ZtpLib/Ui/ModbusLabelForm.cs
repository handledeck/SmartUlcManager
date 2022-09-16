using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class ModbusLabelForm : Form
  {
    private string LabelModbus = "";

    public string labelModbus
    {
      get { return LabelModbus; }
      set { LabelModbus = value; }
    }
    public ModbusLabelForm()
    {
      InitializeComponent();
      tbModbuslabel.Focus();
    }

    public ModbusLabelForm(string inp)
    {
      InitializeComponent();
      tbModbuslabel.Text = inp;
      tbModbuslabel.Focus();
    }

    private void tbModbuslabel_TextChanged(object sender, EventArgs e)
    {
      labelModbus = tbModbuslabel.Text;
    }

    private void tbModbuslabel_Validating(object sender, CancelEventArgs e)
    {
      TextBox txt = sender as TextBox;
      if (txt.Text.Length > 15)
      {
        txt.Text = txt.Text.Remove(15, txt.Text.Length - 15);
        tbModbuslabel.Focus();
        e.Cancel = true;
      }
      else
      {
        e.Cancel = false;
      }
        
    }
  }
}
