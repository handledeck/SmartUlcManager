using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Protocol;
using Ztp.Utils;

namespace Ztp.Ui
{
  public partial class PasswordForm : Form
  {
    public PasswordForm()
    {
      InitializeComponent();
      this.Shown += PasswordForm_Shown;
    }

    private void PasswordForm_Shown(object sender, EventArgs e)
    {
      this.tbPwd.Text = this.Value;
    }

    public string Value { get; set; }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string psw = tbPwd.Text.Trim();
      Exception ex = StringUtils.CheckPasswordString(psw);
      if(ex != null)
      {
        Box.Error(this, ex);
        return;
      }
      Value = psw;
      DialogResult = DialogResult.OK;
    }

    public string Caption
    {
      get { return label1.Text; }
      set { label1.Text = value; }
    }
  }
}
