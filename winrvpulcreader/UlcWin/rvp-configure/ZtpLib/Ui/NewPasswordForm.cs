using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Utils;

namespace Ztp.Ui
{
  public partial class NewPasswordForm : Form
  {
    public NewPasswordForm()
    {
      InitializeComponent();
    }

    public string Value { get; set; }
    private void btnOk_Click(object sender, EventArgs e)
    {
      Exception validatePassword = pwd.ValidatePassword();
      if (validatePassword != null)
      {
        Box.Error(this, validatePassword);
        return;
      }
      Value = pwd.Value;
      DialogResult = DialogResult.OK;
    }
  }
}
