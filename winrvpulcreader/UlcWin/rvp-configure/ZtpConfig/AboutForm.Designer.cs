namespace Ztp
{
  partial class AboutForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
      this.label1 = new System.Windows.Forms.Label();
      this.lblVersion = new System.Windows.Forms.Label();
      this.btnOk = new System.Windows.Forms.Button();
      this.pb = new System.Windows.Forms.PictureBox();
      this.label2 = new System.Windows.Forms.Label();
      this.lbCopyrigth = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(95, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(149, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Конфигурация ULC";
      // 
      // lblVersion
      // 
      this.lblVersion.AutoSize = true;
      this.lblVersion.Location = new System.Drawing.Point(95, 77);
      this.lblVersion.Name = "lblVersion";
      this.lblVersion.Size = new System.Drawing.Size(44, 13);
      this.lblVersion.TabIndex = 3;
      this.lblVersion.Text = "Версия";
      // 
      // btnOk
      // 
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnOk.Location = new System.Drawing.Point(221, 114);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 4;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // pb
      // 
      this.pb.Image = ((System.Drawing.Image)(resources.GetObject("pb.Image")));
      this.pb.Location = new System.Drawing.Point(12, 12);
      this.pb.Name = "pb";
      this.pb.Size = new System.Drawing.Size(48, 48);
      this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pb.TabIndex = 0;
      this.pb.TabStop = false;
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(95, 47);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(201, 30);
      this.label2.TabIndex = 5;
      this.label2.Text = "РУП \"Витебскэнерго\",\r\nФилиал \"Учебный центр\", ОПО; ОЭС";
      // 
      // lbCopyrigth
      // 
      this.lbCopyrigth.AutoSize = true;
      this.lbCopyrigth.Location = new System.Drawing.Point(12, 124);
      this.lbCopyrigth.Name = "lbCopyrigth";
      this.lbCopyrigth.Size = new System.Drawing.Size(51, 13);
      this.lbCopyrigth.TabIndex = 6;
      this.lbCopyrigth.Text = "Copyright";
      // 
      // AboutForm
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(308, 149);
      this.ControlBox = false;
      this.Controls.Add(this.lbCopyrigth);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.lblVersion);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.pb);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AboutForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "О программе";
      ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pb;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblVersion;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lbCopyrigth;
  }
}