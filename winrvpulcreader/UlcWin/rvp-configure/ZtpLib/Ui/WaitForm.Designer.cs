namespace Ztp.Ui
{
  partial class WaitForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.pb = new System.Windows.Forms.ProgressBar();
      this.bw = new System.ComponentModel.BackgroundWorker();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "label1";
      // 
      // pb
      // 
      this.pb.Location = new System.Drawing.Point(12, 40);
      this.pb.Name = "pb";
      this.pb.Size = new System.Drawing.Size(347, 23);
      this.pb.Step = 1;
      this.pb.TabIndex = 1;
      // 
      // bw
      // 
      this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
      this.bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
      this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 85);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(347, 100);
      this.flowLayoutPanel1.TabIndex = 2;
      // 
      // WaitForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(371, 184);
      this.ControlBox = false;
      this.Controls.Add(this.flowLayoutPanel1);
      this.Controls.Add(this.pb);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "WaitForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Ждите...";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ProgressBar pb;
    private System.ComponentModel.BackgroundWorker bw;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
  }
}