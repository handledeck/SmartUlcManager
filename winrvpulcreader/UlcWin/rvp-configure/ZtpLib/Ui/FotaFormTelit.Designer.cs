namespace Ztp.Ui
{
  partial class FotaFormTelit
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    /*protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }*/

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.pcFota = new Ztp.Ui.ProgressControl();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnFota = new System.Windows.Forms.Button();
      this.fotaInfo = new Ztp.Ui.FotaInfoControlTelit();
      this.SuspendLayout();
      // 
      // pcFota
      // 
      this.pcFota.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pcFota.Caption = "";
      this.pcFota.Location = new System.Drawing.Point(12, 192);
      this.pcFota.Maximum = 100;
      this.pcFota.Minimum = 0;
      this.pcFota.Name = "pcFota";
      this.pcFota.Size = new System.Drawing.Size(551, 50);
      this.pcFota.Step = 10;
      this.pcFota.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
      this.pcFota.TabIndex = 3;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(488, 257);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnFota
      // 
      this.btnFota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFota.Location = new System.Drawing.Point(407, 257);
      this.btnFota.Name = "btnFota";
      this.btnFota.Size = new System.Drawing.Size(75, 23);
      this.btnFota.TabIndex = 0;
      this.btnFota.Text = "Прошить";
      this.btnFota.UseVisualStyleBackColor = true;
      this.btnFota.Click += new System.EventHandler(this.btnFota_Click);
      // 
      // fotaInfo
      // 
      this.fotaInfo.IconImage = global::Ztp.Properties.Resources.cpu_preferences;
      this.fotaInfo.Location = new System.Drawing.Point(12, 12);
      this.fotaInfo.Name = "fotaInfo";
      this.fotaInfo.Size = new System.Drawing.Size(558, 153);
      this.fotaInfo.TabIndex = 4;
      // 
      // FotaFormTelit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(575, 292);
      this.ControlBox = false;
      this.Controls.Add(this.fotaInfo);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnFota);
      this.Controls.Add(this.pcFota);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FotaFormTelit";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Прошивка ULC2";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnCancel;
    private ProgressControl pcFota;
    private System.Windows.Forms.Button btnFota;
    private FotaInfoControlTelit fotaInfo;
  }
}