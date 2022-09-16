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
  public partial class PasswordControl : UserControl
  {
    public PasswordControl()
    {
      InitializeComponent();
    }

    public int Delay
    {
      get { return timer.Interval; }
      set { timer.Interval = value; }
    }
    private void timer_Tick(object sender, EventArgs e)
    {
      timer.Enabled = false;
      cbShowPsw.Checked = false;
    }

    public int CaptionWidth
    {
      get { return itPsw.CaptionWidth; }
      set
      {
        itPsw.CaptionWidth = value;
        cbShowPsw.Left = value + 3;
        Invalidate();
      }
    }
    private void cbShowPsw_CheckedChanged(object sender, EventArgs e)
    {
      itPsw.PasswordChar = cbShowPsw.Checked ? '\0' : '*';
      timer.Enabled = cbShowPsw.Checked;
    }

    public string Value
    {
      get { return itPsw.Value.Trim(); }
      set
      {
        itPsw.Value = value;
      }
    }

  }
}
