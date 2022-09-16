using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Utils;

namespace Ztp.Ui
{
  public partial class PasswordWithConfirmControl : UserControl
  {
    public PasswordWithConfirmControl()
    {
      InitializeComponent();
    }

    public int Delay
    {
      get { return timer.Interval; }
      set { timer.Interval = value; }
    }

    private void cbShowPsw_CheckedChanged(object sender, EventArgs e)
    {
      itPsw.PasswordChar = itPswConfirm.PasswordChar = cbShowPsw.Checked ? '\0' : '*';
      timer.Enabled = cbShowPsw.Checked;
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      timer.Enabled = false;
      cbShowPsw.Checked = false;
    }

    public string Value
    {
      get { return itPsw.Value.Trim(); }
      set
      {
        itPsw.Value = value;
        itPswConfirm.Value = value;
      }
    }

    public int CaptionWidth
    {
      get { return itPsw.CaptionWidth; }
      set
      {
        itPsw.CaptionWidth = value;
        itPswConfirm.CaptionWidth = value;
        cbShowPsw.Left = value + 3;
        Invalidate();
      }
    }

    public Exception ValidatePassword()
    {
      string p1 = itPsw.Value.Trim();
      string p2 = itPswConfirm.Value.Trim();
      Exception ex = StringUtils.CheckPasswordString(p1);
      if (ex != null)
        return ex;
      ex = StringUtils.CheckPasswordString(p2);
      if (ex != null)
        return ex;
      if (p1 != p2)
        return new Exception("Пароли не совпадают. Повторите ввод.");
      return null;
    }
  }
}
