namespace ZtpManager
{
  partial class StartForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
      this.label1 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.label2 = new System.Windows.Forms.Label();
      this.pnlBanner = new System.Windows.Forms.Panel();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.lnkMultiWriteConfig = new System.Windows.Forms.LinkLabel();
      this.pictureBox3 = new System.Windows.Forms.PictureBox();
      this.lnkMultiFota = new System.Windows.Forms.LinkLabel();
      this.pictureBox4 = new System.Windows.Forms.PictureBox();
      this.lnkMultiReboot = new System.Windows.Forms.LinkLabel();
      this.lnkMultiWriteSwitchOnOff = new System.Windows.Forms.LinkLabel();
      this.pictureBox5 = new System.Windows.Forms.PictureBox();
      this.lnkMultiWriteChangePassword = new System.Windows.Forms.LinkLabel();
      this.pictureBox6 = new System.Windows.Forms.PictureBox();
      this.presentsPanel = new Ztp.Ui.PresentsPanel();
      this.pictureBox7 = new System.Windows.Forms.PictureBox();
      this.lnkMultiPatch = new System.Windows.Forms.LinkLabel();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.pnlBanner.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(77, 3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(293, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Программа управления устройствами";
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(3, 3);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(68, 62);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 1;
      this.pictureBox1.TabStop = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.BackColor = System.Drawing.Color.Transparent;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(77, 19);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(190, 25);
      this.label2.TabIndex = 2;
      this.label2.Text = "РВП-18 и ULC02";
      // 
      // pnlBanner
      // 
      this.pnlBanner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlBanner.BackgroundImage")));
      this.pnlBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pnlBanner.Controls.Add(this.pictureBox1);
      this.pnlBanner.Controls.Add(this.label1);
      this.pnlBanner.Controls.Add(this.label2);
      this.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlBanner.Location = new System.Drawing.Point(0, 0);
      this.pnlBanner.Name = "pnlBanner";
      this.pnlBanner.Size = new System.Drawing.Size(958, 70);
      this.pnlBanner.TabIndex = 4;
      // 
      // pictureBox2
      // 
      this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
      this.pictureBox2.Location = new System.Drawing.Point(12, 85);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(32, 32);
      this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox2.TabIndex = 5;
      this.pictureBox2.TabStop = false;
      // 
      // lnkMultiWriteConfig
      // 
      this.lnkMultiWriteConfig.AutoSize = true;
      this.lnkMultiWriteConfig.Location = new System.Drawing.Point(50, 94);
      this.lnkMultiWriteConfig.Name = "lnkMultiWriteConfig";
      this.lnkMultiWriteConfig.Size = new System.Drawing.Size(331, 13);
      this.lnkMultiWriteConfig.TabIndex = 6;
      this.lnkMultiWriteConfig.TabStop = true;
      this.lnkMultiWriteConfig.Text = "Записать конфигурацию в произвольное количество устройств";
      this.lnkMultiWriteConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMultiWriteConfig_LinkClicked);
      // 
      // pictureBox3
      // 
      this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
      this.pictureBox3.Location = new System.Drawing.Point(12, 237);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new System.Drawing.Size(32, 32);
      this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox3.TabIndex = 7;
      this.pictureBox3.TabStop = false;
      // 
      // lnkMultiFota
      // 
      this.lnkMultiFota.AutoSize = true;
      this.lnkMultiFota.Location = new System.Drawing.Point(50, 247);
      this.lnkMultiFota.Name = "lnkMultiFota";
      this.lnkMultiFota.Size = new System.Drawing.Size(330, 13);
      this.lnkMultiFota.TabIndex = 8;
      this.lnkMultiFota.TabStop = true;
      this.lnkMultiFota.Text = "Запись ПО контроллера в произвольное количество устройств";
      this.lnkMultiFota.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMultiFota_LinkClicked);
      // 
      // pictureBox4
      // 
      this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
      this.pictureBox4.Location = new System.Drawing.Point(12, 199);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new System.Drawing.Size(32, 32);
      this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox4.TabIndex = 9;
      this.pictureBox4.TabStop = false;
      // 
      // lnkMultiReboot
      // 
      this.lnkMultiReboot.AutoSize = true;
      this.lnkMultiReboot.Location = new System.Drawing.Point(50, 208);
      this.lnkMultiReboot.Name = "lnkMultiReboot";
      this.lnkMultiReboot.Size = new System.Drawing.Size(274, 13);
      this.lnkMultiReboot.TabIndex = 10;
      this.lnkMultiReboot.TabStop = true;
      this.lnkMultiReboot.Text = "Перезагрузка произвольного количества устройств";
      this.lnkMultiReboot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMultiReboot_LinkClicked);
      // 
      // lnkMultiWriteSwitchOnOff
      // 
      this.lnkMultiWriteSwitchOnOff.AutoSize = true;
      this.lnkMultiWriteSwitchOnOff.Location = new System.Drawing.Point(50, 132);
      this.lnkMultiWriteSwitchOnOff.Name = "lnkMultiWriteSwitchOnOff";
      this.lnkMultiWriteSwitchOnOff.Size = new System.Drawing.Size(385, 13);
      this.lnkMultiWriteSwitchOnOff.TabIndex = 12;
      this.lnkMultiWriteSwitchOnOff.TabStop = true;
      this.lnkMultiWriteSwitchOnOff.Text = "Включить/Выключить освещение на произвольном количестве устройств";
      this.lnkMultiWriteSwitchOnOff.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMultiWriteSwitchOnOff_LinkClicked);
      // 
      // pictureBox5
      // 
      this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
      this.pictureBox5.Location = new System.Drawing.Point(12, 123);
      this.pictureBox5.Name = "pictureBox5";
      this.pictureBox5.Size = new System.Drawing.Size(32, 32);
      this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox5.TabIndex = 11;
      this.pictureBox5.TabStop = false;
      // 
      // lnkMultiWriteChangePassword
      // 
      this.lnkMultiWriteChangePassword.AutoSize = true;
      this.lnkMultiWriteChangePassword.Location = new System.Drawing.Point(50, 170);
      this.lnkMultiWriteChangePassword.Name = "lnkMultiWriteChangePassword";
      this.lnkMultiWriteChangePassword.Size = new System.Drawing.Size(297, 13);
      this.lnkMultiWriteChangePassword.TabIndex = 14;
      this.lnkMultiWriteChangePassword.TabStop = true;
      this.lnkMultiWriteChangePassword.Text = "Сменить пароль на произвольном количестве устройств";
      this.lnkMultiWriteChangePassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMultiWriteChangePassword_LinkClicked);
      // 
      // pictureBox6
      // 
      this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
      this.pictureBox6.Location = new System.Drawing.Point(12, 161);
      this.pictureBox6.Name = "pictureBox6";
      this.pictureBox6.Size = new System.Drawing.Size(32, 32);
      this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox6.TabIndex = 13;
      this.pictureBox6.TabStop = false;
      // 
      // presentsPanel
      // 
      this.presentsPanel.BackColor = System.Drawing.Color.White;
      this.presentsPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.presentsPanel.LineColor = System.Drawing.Color.RoyalBlue;
      this.presentsPanel.LineWeight = 2;
      this.presentsPanel.Location = new System.Drawing.Point(0, 70);
      this.presentsPanel.Name = "presentsPanel";
      this.presentsPanel.Size = new System.Drawing.Size(958, 253);
      this.presentsPanel.TabIndex = 3;
      // 
      // pictureBox7
      // 
      this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
      this.pictureBox7.Location = new System.Drawing.Point(13, 276);
      this.pictureBox7.Name = "pictureBox7";
      this.pictureBox7.Size = new System.Drawing.Size(32, 32);
      this.pictureBox7.TabIndex = 15;
      this.pictureBox7.TabStop = false;
      // 
      // lnkMultiPatch
      // 
      this.lnkMultiPatch.AutoSize = true;
      this.lnkMultiPatch.Location = new System.Drawing.Point(51, 285);
      this.lnkMultiPatch.Name = "lnkMultiPatch";
      this.lnkMultiPatch.Size = new System.Drawing.Size(405, 13);
      this.lnkMultiPatch.TabIndex = 16;
      this.lnkMultiPatch.TabStop = true;
      this.lnkMultiPatch.Text = "Запись патча ядра контроллера ULC02 в произвольное количество устройств";
      this.lnkMultiPatch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMultiPatch_LinkClicked);
      // 
      // StartForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(958, 507);
      this.Controls.Add(this.lnkMultiPatch);
      this.Controls.Add(this.pictureBox7);
      this.Controls.Add(this.lnkMultiWriteChangePassword);
      this.Controls.Add(this.pictureBox6);
      this.Controls.Add(this.lnkMultiWriteSwitchOnOff);
      this.Controls.Add(this.pictureBox5);
      this.Controls.Add(this.lnkMultiReboot);
      this.Controls.Add(this.pictureBox4);
      this.Controls.Add(this.lnkMultiFota);
      this.Controls.Add(this.pictureBox3);
      this.Controls.Add(this.lnkMultiWriteConfig);
      this.Controls.Add(this.pictureBox2);
      this.Controls.Add(this.presentsPanel);
      this.Controls.Add(this.pnlBanner);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "StartForm";
      this.Text = "Начальная страница";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartForm_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.pnlBanner.ResumeLayout(false);
      this.pnlBanner.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label2;
    private Ztp.Ui.PresentsPanel presentsPanel;
    private System.Windows.Forms.Panel pnlBanner;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.PictureBox pictureBox3;
    internal System.Windows.Forms.LinkLabel lnkMultiFota;
    private System.Windows.Forms.PictureBox pictureBox4;
    internal System.Windows.Forms.LinkLabel lnkMultiReboot;
    private System.Windows.Forms.PictureBox pictureBox5;
    private System.Windows.Forms.PictureBox pictureBox6;
    internal System.Windows.Forms.LinkLabel lnkMultiWriteConfig;
    internal System.Windows.Forms.LinkLabel lnkMultiWriteSwitchOnOff;
    internal System.Windows.Forms.LinkLabel lnkMultiWriteChangePassword;
    private System.Windows.Forms.PictureBox pictureBox7;
    private System.Windows.Forms.LinkLabel lnkMultiPatch;
  }
}