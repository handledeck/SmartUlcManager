using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.ui
{
  public partial class SimpleWaitForm : Form
  {
    Task __tsk;
    CancellationTokenSource tokenSource2;
    CancellationToken ct;
    Action __action;
    public SimpleWaitForm()
    {
      InitializeComponent();

      this.Shown += SimpleWaitForm_Shown;
    }

    public SimpleWaitForm(Action action)
    {
      InitializeComponent();
      this.RunAction(action);
      this.Shown += SimpleWaitForm_Shown;
    }

    private void SimpleWaitForm_Shown(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.None;
      __tsk = new Task(__action, tokenSource2.Token);
      __tsk.Start();
    }

    public void RunAction(Action action) {
      
      tokenSource2 = new CancellationTokenSource();
      ct = tokenSource2.Token;
      __action = action;
    }

    public void SetHeaderText(string text)
    {
      this.BeginInvoke(new Action(() => {

        this.Text = text;

      }));
    }

    public void SetLabelText(string text) {
      this.BeginInvoke(new Action(() => {

        if (text.Length >= 50) {
          text = text.Substring(0, 47) + "...";
        }
        this.label1.Text = text;
        
      }));
    }

    public void SetLabelTextError(string text)
    {
      this.BeginInvoke(new Action(() => {
        this.label1.ForeColor = Color.Red;
        this.label1.Text = text;
      }));
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      if (__tsk != null)
      {
        tokenSource2.Cancel();
      }
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }
  }
}
