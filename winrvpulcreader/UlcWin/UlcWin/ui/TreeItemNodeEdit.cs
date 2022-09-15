using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.ui
{
  public partial class TreeItemNodeForm : Form
  {
    public TreeItemNodeForm()
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.txtNodeName.Text))
      {
        this.btnOk.Enabled = false;
      }
      else {
        this.btnOk.Enabled = true;
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }
  }
}
