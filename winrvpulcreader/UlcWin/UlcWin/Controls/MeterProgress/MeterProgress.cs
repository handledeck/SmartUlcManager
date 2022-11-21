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

namespace UlcWin.Controls.UlcMeterComponet
{
  public partial class MeterProgress : Form
  {
    CancellationTokenSource __cancellationToken = null;
    int count = 0;
    public MeterProgress()
    {
      InitializeComponent();
    }

    public void SetLabelText(string text)
    {
      try
      {
        this.BeginInvoke(new Action(() =>
        {
          try
          {
            this.label1.Text = text;
          }
          catch { }
        }));
      }
      catch{}
    }

    public void SetProgressValue(long value)
    {
      try
      {
        this.BeginInvoke(new Action(() =>
        {
          try
          {
            this.progressBar1.Value += 1;
            this.Text =string.Format("Завершено: {0} %",((this.progressBar1.Value * 100) / this.progressBar1.Maximum).ToString());
          }
          catch { }
        }));
      }
      catch{}
    }



    public void SetTasksToken(CancellationTokenSource cancellationToken,int progressMax) {

      __cancellationToken = cancellationToken;
      this.progressBar1.Maximum = progressMax;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      __cancellationToken.Cancel();
    }
  }
}
