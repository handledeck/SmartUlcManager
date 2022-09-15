namespace UlcWin.ui
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
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.lbCopyrigth = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btnOk = new System.Windows.Forms.Button();
      this.lblVersion = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::UlcWin.Properties.Resources.PCI_card_view2;
      this.pictureBox1.Location = new System.Drawing.Point(15, 32);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(54, 54);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // lbCopyrigth
      // 
      this.lbCopyrigth.AutoSize = true;
      this.lbCopyrigth.Location = new System.Drawing.Point(12, 120);
      this.lbCopyrigth.Name = "lbCopyrigth";
      this.lbCopyrigth.Size = new System.Drawing.Size(51, 13);
      this.lbCopyrigth.TabIndex = 11;
      this.lbCopyrigth.Text = "Copyright";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(89, 56);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(260, 30);
      this.label2.TabIndex = 10;
      this.label2.Text = "РУП \"Витебскэнерго\",\r\nФилиал \"Учебный центр\", ОЭС, САСТУ";
      // 
      // btnOk
      // 
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnOk.Location = new System.Drawing.Point(293, 110);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 9;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // lblVersion
      // 
      this.lblVersion.AutoSize = true;
      this.lblVersion.Location = new System.Drawing.Point(89, 89);
      this.lblVersion.Name = "lblVersion";
      this.lblVersion.Size = new System.Drawing.Size(44, 13);
      this.lblVersion.TabIndex = 8;
      this.lblVersion.Text = "Версия";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(89, 28);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(279, 16);
      this.label1.TabIndex = 7;
      this.label1.Text = "Система диагностики контроллеров";
      // 
      // AboutForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(380, 145);
      this.ControlBox = false;
      this.Controls.Add(this.lbCopyrigth);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.lblVersion);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.pictureBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "AboutForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "О программе";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbCopyrigth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label1;
    }
}