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
  public partial class WaitForm : Form
  {
    DoWorkEventHandler _doWork;
    RunWorkerCompletedEventHandler _runWorkerCompleted;
    public WaitForm(string caption, DoWorkEventHandler doWork, RunWorkerCompletedEventHandler runWorkerCompleted, bool showProgress = false)
    {
      if (doWork == null) throw new ArgumentNullException(nameof(doWork));
      if (runWorkerCompleted == null) throw new ArgumentNullException(nameof(runWorkerCompleted));
      if (string.IsNullOrEmpty(caption)) throw new ArgumentException("Value cannot be null or empty.", nameof(caption));
      InitializeComponent();
      label1.Text = caption;
      _doWork = doWork;
      _runWorkerCompleted = runWorkerCompleted;
      pb.Style = !showProgress ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
      bw.WorkerReportsProgress = showProgress;
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
      base.OnVisibleChanged(e);
      if(Visible)
        bw.RunWorkerAsync();
    }

    public void ReportProgress(int percentProgress)
    {
      if(bw.WorkerReportsProgress)
        bw.ReportProgress(percentProgress);
    }

    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
      _doWork?.Invoke(sender, e);
    }

    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      if(pb.Style == ProgressBarStyle.Blocks)
        pb.Value = e.ProgressPercentage;
    }

    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      DialogResult = DialogResult.OK;
      _runWorkerCompleted?.Invoke(sender, e);
    }
  }
}
