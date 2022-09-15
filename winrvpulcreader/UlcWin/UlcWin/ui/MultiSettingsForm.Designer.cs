namespace UlcWin.ui
{
    partial class MultiSettingsForm
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
      Ztp.Configuration.ZtpConfig ztpConfig3 = new Ztp.Configuration.ZtpConfig();
      Ztp.Port.ComPort.ComPortSettings comPortSettings3 = new Ztp.Port.ComPort.ComPortSettings();
      Ztp.Configuration.ZtpLight ztpLight3 = new Ztp.Configuration.ZtpLight();
      Ztp.Configuration.ZtpScheduler ztpScheduler3 = new Ztp.Configuration.ZtpScheduler();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.partitionConfigEditorControl1 = new UlcWin.ui.PartitionConfigEditorControl();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.cbReboot = new System.Windows.Forms.CheckBox();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.partitionConfigEditorControl1, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.66666F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(549, 549);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnOk);
      this.panel2.Controls.Add(this.btnCancel);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(5, 509);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(539, 35);
      this.panel2.TabIndex = 2;
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(365, 5);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 27);
      this.btnOk.TabIndex = 1;
      this.btnOk.Text = "Записать";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(451, 5);
      this.btnCancel.Margin = new System.Windows.Forms.Padding(33, 3, 13, 33);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 27);
      this.btnCancel.TabIndex = 0;
      this.btnCancel.Text = "Выход";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // partitionConfigEditorControl1
      // 
      this.partitionConfigEditorControl1.AutoScrollMargin = new System.Drawing.Size(3, 3);
      this.partitionConfigEditorControl1.Location = new System.Drawing.Point(5, 48);
      this.partitionConfigEditorControl1.Name = "partitionConfigEditorControl1";
      this.partitionConfigEditorControl1.Size = new System.Drawing.Size(530, 442);
      this.partitionConfigEditorControl1.TabIndex = 0;
      ztpConfig3.Ain = new bool[] {
        false,
        false,
        false,
        false};
      ztpConfig3.Apn = "vpn2.mts.by";
      ztpConfig3.ApnPassword = "";
      ztpConfig3.ApnUser = "vpn";
      ztpConfig3.Cain = new ushort[] {
        ((ushort)(0)),
        ((ushort)(0)),
        ((ushort)(0)),
        ((ushort)(0))};
      ztpConfig3.Cdin = new bool[] {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false};
      ztpConfig3.Cdout = new bool[] {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false};
      comPortSettings3.BaudRate = 9600;
      comPortSettings3.DataBits = ((byte)(8));
      comPortSettings3.Handshake = Ztp.Port.ComPort.Handshake.None;
      comPortSettings3.Kind = Ztp.Port.PortKind.Com;
      comPortSettings3.Parity = Ztp.Port.ComPort.Parity.None;
      comPortSettings3.PortName = "COM1";
      comPortSettings3.StopBits = Ztp.Port.ComPort.StopBits.One;
      comPortSettings3.Timeout = 5000;
      ztpConfig3.ComPortSetting = comPortSettings3;
      ztpConfig3.CoreVersion = "";
      ztpConfig3.CurTrafic = ((uint)(0u));
      ztpConfig3.dateTime = new System.DateTime(2022, 3, 26, 7, 3, 32, 63);
      ztpConfig3.DateTime = new System.DateTime(2022, 3, 26, 7, 3, 32, 63);
      ztpConfig3.DateTimeFirmware = new System.DateTime(((long)(0)));
      ztpConfig3.DbzPercent = ((byte)(1));
      ztpConfig3.Debounce = ((uint)(100u));
      ztpConfig3.Debug = false;
      ztpConfig3.Din = new bool[] {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false};
      ztpConfig3.Door = new bool[] {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false};
      ztpConfig3.Dout = new bool[] {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false};
      ztpConfig3.EstActive = false;
      ztpConfig3.EstAddress = "15;10;20;1";
      ztpConfig3.EstPort = ((ushort)(3080));
      ztpConfig3.EstTsend = ((uint)(50u));
      ztpConfig3.Flags = Ztp.Configuration.ZtpConfig.ConfigFlag.None;
      ztpConfig3.Gprs = ((uint)(0u));
      ztpConfig3.Gsm = ((uint)(0u));
      ztpConfig3.Imei = "";
      ztpConfig3.IpOwn = "";
      ztpConfig3.IpPing = "";
      ztpConfig3.IsHalfBright = false;
      ztpConfig3.IsReadedFromDevice = false;
      ztpConfig3.Latitude = 55.1911F;
      ztpLight3.Scheduler = ztpScheduler3;
      ztpLight3.UseScheduler = false;
      ztpConfig3.Light = ztpLight3;
      ztpConfig3.logLevel = ((byte)(5));
      ztpConfig3.Longitude = 30.12533F;
      ztpConfig3.NetTechnology = "";
      ztpConfig3.Number = 1;
      ztpConfig3.PingPeriod = ((byte)(1));
      ztpConfig3.rebootTime = "";
      ztpConfig3.Signal = 0;
      ztpConfig3.Sim = ((uint)(0u));
      ztpConfig3.SoftVersion = "";
      ztpConfig3.Sunrise = new System.DateTime(((long)(0)));
      ztpConfig3.Sunset = new System.DateTime(((long)(0)));
      ztpConfig3.TimeZone = ((sbyte)(3));
      ztpConfig3.Version = "I1O1A1-LDC-3";
      this.partitionConfigEditorControl1.Value = ztpConfig3;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.cbReboot);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(5, 5);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(539, 35);
      this.panel1.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 11);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(285, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "После изменения настороек, перегрузите контроллер";
      // 
      // cbReboot
      // 
      this.cbReboot.AutoSize = true;
      this.cbReboot.Location = new System.Drawing.Point(432, 10);
      this.cbReboot.Name = "cbReboot";
      this.cbReboot.Size = new System.Drawing.Size(98, 17);
      this.cbReboot.TabIndex = 0;
      this.cbReboot.Text = "Перезагрузка";
      this.cbReboot.UseVisualStyleBackColor = true;
      // 
      // MultiSettingsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(549, 549);
      this.ControlBox = false;
      this.Controls.Add(this.tableLayoutPanel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "MultiSettingsForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Настройки контроллеров";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private PartitionConfigEditorControl partitionConfigEditorControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox cbReboot;
  }
}