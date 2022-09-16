namespace Ztp.Ui
{
  partial class FotaInfoControlTelit
  {
    /// <summary> 
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором компонентов

    /// <summary> 
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FotaInfoControlTelit));
      this.gbFotaInfo = new System.Windows.Forms.GroupBox();
      this.itModem = new Ztp.Ui.InputTextControl();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.gbFotaInfo.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // gbFotaInfo
      // 
      this.gbFotaInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gbFotaInfo.Controls.Add(this.itModem);
      this.gbFotaInfo.Location = new System.Drawing.Point(56, 83);
      this.gbFotaInfo.Name = "gbFotaInfo";
      this.gbFotaInfo.Size = new System.Drawing.Size(507, 74);
      this.gbFotaInfo.TabIndex = 0;
      this.gbFotaInfo.TabStop = false;
      this.gbFotaInfo.Text = "Информация о прошивке";
      // 
      // itModem
      // 
      this.itModem.Caption = "Модем";
      this.itModem.CaptionWidth = 150;
      this.itModem.Dock = System.Windows.Forms.DockStyle.Top;
      this.itModem.Location = new System.Drawing.Point(3, 16);
      this.itModem.Name = "itModem";
      this.itModem.PasswordChar = '\0';
      this.itModem.ReadOnly = true;
      this.itModem.Size = new System.Drawing.Size(501, 26);
      this.itModem.TabIndex = 0;
      this.itModem.Value = "";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(3, 3);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(48, 48);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 4;
      this.pictureBox1.TabStop = false;
      // 
      // textBox1
      // 
      this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBox1.Location = new System.Drawing.Point(58, 1);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBox1.Size = new System.Drawing.Size(505, 76);
      this.textBox1.TabIndex = 5;
      this.textBox1.Text = resources.GetString("textBox1.Text");
      // 
      // FotaInfoControlTelit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.gbFotaInfo);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.pictureBox1);
      this.Name = "FotaInfoControlTelit";
      this.Size = new System.Drawing.Size(567, 160);
      this.gbFotaInfo.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox gbFotaInfo;
    private InputTextControl itModem;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.TextBox textBox1;
  }
}
