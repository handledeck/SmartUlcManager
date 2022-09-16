namespace UlcWin.Fota
{
  partial class FotaForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.lv = new System.Windows.Forms.ListView();
      this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Progress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.percent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.lblVersion = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnStart = new System.Windows.Forms.Button();
      this.btnChancel = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // lv
      // 
      this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.Ip,
            this.Progress,
            this.percent,
            this.time});
      this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lv.HideSelection = false;
      this.lv.Location = new System.Drawing.Point(4, 59);
      this.lv.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.lv.Name = "lv";
      this.lv.Size = new System.Drawing.Size(1057, 473);
      this.lv.TabIndex = 3;
      this.lv.UseCompatibleStateImageBehavior = false;
      this.lv.View = System.Windows.Forms.View.Details;
      // 
      // Name
      // 
      this.Name.Text = "Имя";
      this.Name.Width = 300;
      // 
      // Ip
      // 
      this.Ip.Text = "IP адрес";
      this.Ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.Ip.Width = 130;
      // 
      // Progress
      // 
      this.Progress.Text = "Прогресс";
      this.Progress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.Progress.Width = 230;
      // 
      // percent
      // 
      this.percent.Text = "% Исполнения";
      this.percent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.percent.Width = 183;
      // 
      // time
      // 
      this.time.Text = "Время прошивки";
      this.time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.time.Width = 195;
      // 
      // timer1
      // 
      this.timer1.Interval = 500;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.lv, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.61224F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.38776F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1065, 535);
      this.tableLayoutPanel1.TabIndex = 4;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 3;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 94.44444F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 177F));
      this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.lblVersion, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.panel1, 2, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(1059, 50);
      this.tableLayoutPanel2.TabIndex = 4;
      // 
      // lblVersion
      // 
      this.lblVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.lblVersion.AutoSize = true;
      this.lblVersion.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblVersion.Location = new System.Drawing.Point(61, 17);
      this.lblVersion.Margin = new System.Windows.Forms.Padding(13, 0, 13, 0);
      this.lblVersion.Name = "lblVersion";
      this.lblVersion.Size = new System.Drawing.Size(46, 16);
      this.lblVersion.TabIndex = 3;
      this.lblVersion.Text = "label1";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnStart);
      this.panel1.Controls.Add(this.btnChancel);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(883, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(173, 44);
      this.panel1.TabIndex = 5;
      // 
      // btnStart
      // 
      this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.btnStart.Location = new System.Drawing.Point(9, 9);
      this.btnStart.Margin = new System.Windows.Forms.Padding(41, 13, 14, 13);
      this.btnStart.Name = "btnStart";
      this.btnStart.Padding = new System.Windows.Forms.Padding(1);
      this.btnStart.Size = new System.Drawing.Size(70, 29);
      this.btnStart.TabIndex = 1;
      this.btnStart.Text = "Начать";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnFota_Click);
      // 
      // btnChancel
      // 
      this.btnChancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.btnChancel.Location = new System.Drawing.Point(87, 9);
      this.btnChancel.Margin = new System.Windows.Forms.Padding(41, 13, 14, 13);
      this.btnChancel.Name = "btnChancel";
      this.btnChancel.Padding = new System.Windows.Forms.Padding(1);
      this.btnChancel.Size = new System.Drawing.Size(63, 29);
      this.btnChancel.TabIndex = 2;
      this.btnChancel.Text = "Отмена";
      this.btnChancel.UseVisualStyleBackColor = true;
      this.btnChancel.Click += new System.EventHandler(this.button1_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::UlcWin.Properties.Resources._1488;
      this.pictureBox1.Location = new System.Drawing.Point(3, 3);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(42, 42);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 4;
      this.pictureBox1.TabStop = false;
      // 
      // FotaForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1065, 535);
      this.ControlBox = false;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      //this.Name = "FotaForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Обновление контроллеров";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

        #endregion
    private System.Windows.Forms.ColumnHeader Name;
    private System.Windows.Forms.ColumnHeader Ip;
    private System.Windows.Forms.ColumnHeader Progress;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.ColumnHeader percent;
    public System.Windows.Forms.ListView lv;
    private System.Windows.Forms.ColumnHeader time;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnChancel;
    }
}