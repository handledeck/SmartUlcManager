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
using UlcWin.Controls.LogNet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UlcWin.Controls.Wait
{
  

  public partial class ProgressDialog : Form
  {
    private CancellationTokenSource _cts;
    private Task _currentTask;
    private bool _isCompleted = false;

    public ProgressDialog()
    {
      InitializeComponent();
      this.FormClosing += ProgressDialog_FormClosing;
      this.btnCancel.Click += btnCancel_Click;
      this.StartPosition = FormStartPosition.Manual;
    }

    public string DialogTitle
    {
      get => this.Text;
      set => this.Text = value;
    }

    public async Task<DialogResult> ShowTaskAsync(IWin32Window owner,
        Func<CancellationToken, IProgress<ProgressReport>, Task> taskAction)
    {
      if (owner == null)
      {
        throw new ArgumentNullException(nameof(owner));
      }

      // Ручное центрирование относительно главной формы
      if (owner is Form ownerForm)
      {
        int x = ownerForm.Location.X + (ownerForm.Width - this.Width) / 2;
        int y = ownerForm.Location.Y + (ownerForm.Height - this.Height) / 2;
        this.Location = new System.Drawing.Point(x, y);
      }

      // Показываем диалог
      this.TopMost = true;
      this.Show(owner);
      this.BringToFront();

      _cts = new CancellationTokenSource();
      _isCompleted = false;

      var progress = new Progress<ProgressReport>(OnProgressReport);

      try
      {
        _currentTask = taskAction(_cts.Token, progress);
        await _currentTask;

        _isCompleted = true;
        return DialogResult.OK;
      }
      catch (OperationCanceledException)
      {
        _isCompleted = true;
        return DialogResult.Cancel;
      }
      catch (Exception ex)
      {
        _isCompleted = true;
        MessageBox.Show(this, $"Ошибка: {ex.Message}", "Ошибка",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        return DialogResult.Abort;
      }
      finally
      {
        _cts?.Dispose();
        _cts = null;
        this.Close();
      }
    }

    private void OnProgressReport(ProgressReport report)
    {
      if (this.IsHandleCreated && !this.IsDisposed)
      {
        if (this.InvokeRequired)
        {
          this.Invoke(new Action(() => OnProgressReport(report)));
          return;
        }

        // Обработка Marquee режима (когда процент = -1)
        if (report.Percent == -1)
        {
          if (progressBar.Style != ProgressBarStyle.Marquee)
          {
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 30;
            lblPercent.Text = "Выполнение...";
          }
        }
        else
        {
          // Обычный режим с процентами
          if (progressBar.Style != ProgressBarStyle.Blocks)
          {
            progressBar.Style = ProgressBarStyle.Blocks;
          }

          if (report.Percent >= 0 && report.Percent <= 100)
          {
            progressBar.Value = report.Percent;
            lblPercent.Text = $"{report.Percent}%";
          }
        }

        // Обновляем текст статуса
        if (!string.IsNullOrEmpty(report.StatusText))
        {
          lblStatus.Text = report.StatusText;
        }
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      if (_cts != null && !_isCompleted)
      {
        btnCancel.Enabled = false;
        btnCancel.Text = "Отмена...";
        lblStatus.Text = "Отмена операции...";

        // Принудительная отмена через закрытие сокета
        TcpLogNet.ForceCancel();

        _cts.Cancel();
      }
    }

    private void ProgressDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!_isCompleted && _cts != null && !_cts.IsCancellationRequested)
      {
        e.Cancel = true;
        btnCancel_Click(sender, EventArgs.Empty);
      }
    }

    public new DialogResult ShowDialog()
    {
      throw new InvalidOperationException("Используйте ShowTaskAsync");
    }

    public new DialogResult ShowDialog(IWin32Window owner)
    {
      throw new InvalidOperationException("Используйте ShowTaskAsync");
    }
  }

  public class ProgressReport
  {
    public int Percent { get; set; }
    public string StatusText { get; set; }

    public ProgressReport(int percent, string statusText)
    {
      Percent = percent;
      StatusText = statusText;
    }
  }
}
