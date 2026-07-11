namespace UlcWin.Controls.Wait
{
  partial class ProgressDialog
  {
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.Label lblPercent;
    private System.Windows.Forms.Button btnCancel;

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.lblStatus = new System.Windows.Forms.Label();
      this.lblPercent = new System.Windows.Forms.Label();
      this.btnCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // progressBar
      // 
      this.progressBar.Location = new System.Drawing.Point(17, 43);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(351, 26);
      this.progressBar.Step = 1;
      this.progressBar.TabIndex = 0;
      // 
      // lblStatus
      // 
      this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblStatus.Location = new System.Drawing.Point(17, 17);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(351, 22);
      this.lblStatus.TabIndex = 1;
      this.lblStatus.Text = "Подготовка...";
      this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblPercent
      // 
      this.lblPercent.Location = new System.Drawing.Point(17, 78);
      this.lblPercent.Name = "lblPercent";
      this.lblPercent.Size = new System.Drawing.Size(86, 22);
      this.lblPercent.TabIndex = 2;
      this.lblPercent.Text = "0%";
      this.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.lblPercent.Visible = false;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.Location = new System.Drawing.Point(154, 86);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(64, 26);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // ProgressDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(386, 124);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.lblPercent);
      this.Controls.Add(this.lblStatus);
      this.Controls.Add(this.progressBar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ProgressDialog";
      this.ShowIcon = false;
      this.Text = "Выполнение операции";
      this.ResumeLayout(false);

    }
  }
}