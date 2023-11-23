namespace UlcWin
{
  partial class RequestForm
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
      this.components = new System.ComponentModel.Container();
      Ztp.Configuration.ZtpConfig ztpConfig1 = new Ztp.Configuration.ZtpConfig();
      Ztp.Port.ComPort.ComPortSettings comPortSettings1 = new Ztp.Port.ComPort.ComPortSettings();
      Ztp.Configuration.ZtpLight ztpLight1 = new Ztp.Configuration.ZtpLight();
      Ztp.Configuration.ZtpScheduler ztpScheduler1 = new Ztp.Configuration.ZtpScheduler();
      Ztp.Configuration.ZtpLight ztpLight2 = new Ztp.Configuration.ZtpLight();
      Ztp.Configuration.ZtpScheduler ztpScheduler2 = new Ztp.Configuration.ZtpScheduler();
      Ztp.Ui.LocationEditorControl.ZtpLocation ztpLocation1 = new Ztp.Ui.LocationEditorControl.ZtpLocation();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestForm));
      Ztp.Port.ComPort.ComPortSettings comPortSettings2 = new Ztp.Port.ComPort.ComPortSettings();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.@__currentStateViewControl = new Ztp.Ui.CurrentStateViewControl();
      this.@__config = new Ztp.Ui.ConfigEditorControl();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.@__planEditor = new Ztp.Ui.LightPlanEditorControl();
      this.PicLightSwitcher = new System.Windows.Forms.PictureBox();
      this.btnLightSwitcher = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.btnScheduleAdd = new System.Windows.Forms.Button();
      this.imlTc = new System.Windows.Forms.ImageList(this.components);
      this.btnScheduleDelete = new System.Windows.Forms.Button();
      this.btnScheduleEdit = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnAddSeason = new System.Windows.Forms.Button();
      this.btnReamoveSeason = new System.Windows.Forms.Button();
      this.btnChangeSeason = new System.Windows.Forms.Button();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.@__modbusItemList = new Ztp.Ui.ModbusItemListControl();
      this.@__comPortEditor = new Ztp.Ui.ComPortSettingsEditorControl();
      this.@__modBusSettings = new Ztp.Ui.ModBusSettingsEditorControl();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.btnChancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnFile = new System.Windows.Forms.Button();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PicLightSwitcher)).BeginInit();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tabControl1.ImageList = this.imlTc;
      this.tabControl1.ItemSize = new System.Drawing.Size(130, 30);
      this.tabControl1.Location = new System.Drawing.Point(4, 4);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(1109, 639);
      this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.tabPage1.Controls.Add(this.tableLayoutPanel2);
      this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tabPage1.ImageIndex = 2;
      this.tabPage1.Location = new System.Drawing.Point(4, 34);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(1101, 601);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Общие";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.20237F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.79763F));
      this.tableLayoutPanel2.Controls.Add(this.@__currentStateViewControl, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.@__config, 0, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(1095, 595);
      this.tableLayoutPanel2.TabIndex = 0;
      // 
      // __currentStateViewControl
      // 
      this.@__currentStateViewControl.AinValue = new ushort[] {
        ((ushort)(0))};
      this.@__currentStateViewControl.Caption = "";
      this.@__currentStateViewControl.DinValue = new bool[] {
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
      this.@__currentStateViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.@__currentStateViewControl.DoutValue = new bool[] {
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
      this.@__currentStateViewControl.Location = new System.Drawing.Point(815, 3);
      this.@__currentStateViewControl.Name = "__currentStateViewControl";
      this.@__currentStateViewControl.Size = new System.Drawing.Size(277, 589);
      this.@__currentStateViewControl.TabIndex = 0;
      this.@__currentStateViewControl.Value = null;
      // 
      // __config
      // 
      this.@__config.Dock = System.Windows.Forms.DockStyle.Fill;
      this.@__config.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.@__config.Location = new System.Drawing.Point(3, 3);
      this.@__config.Name = "__config";
      this.@__config.ShowApnProperty = false;
      this.@__config.Size = new System.Drawing.Size(806, 589);
      this.@__config.TabIndex = 1;
      ztpConfig1.Ain = new bool[] {
        false,
        false,
        false,
        false};
      ztpConfig1.Apn = "";
      ztpConfig1.ApnPassword = "";
      ztpConfig1.ApnUser = "";
      ztpConfig1.Cain = new ushort[] {
        ((ushort)(0)),
        ((ushort)(0)),
        ((ushort)(0)),
        ((ushort)(0))};
      ztpConfig1.Cdin = new bool[] {
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
      ztpConfig1.Cdout = new bool[] {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false};
      comPortSettings1.BaudRate = 9600;
      comPortSettings1.DataBits = ((byte)(8));
      comPortSettings1.Handshake = Ztp.Port.ComPort.Handshake.None;
      comPortSettings1.Kind = Ztp.Port.PortKind.Com;
      comPortSettings1.Parity = Ztp.Port.ComPort.Parity.None;
      comPortSettings1.PortName = "COM1";
      comPortSettings1.StopBits = Ztp.Port.ComPort.StopBits.One;
      comPortSettings1.Timeout = 1000;
      ztpConfig1.ComPortSetting = comPortSettings1;
      ztpConfig1.CoreVersion = "";
      ztpConfig1.CurTrafic = ((uint)(0u));
      ztpConfig1.dateTime = new System.DateTime(2022, 1, 25, 11, 52, 32, 840);
      ztpConfig1.DateTime = new System.DateTime(2022, 1, 25, 11, 52, 32, 840);
      ztpConfig1.DateTimeFirmware = new System.DateTime(((long)(0)));
      ztpConfig1.DbzPercent = ((byte)(1));
      ztpConfig1.Debounce = ((uint)(500u));
      ztpConfig1.Debug = false;
      ztpConfig1.Din = new bool[] {
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
      ztpConfig1.Door = new bool[] {
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
      ztpConfig1.Dout = new bool[] {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false};
      ztpConfig1.EstActive = false;
      ztpConfig1.EstAddress = "";
      ztpConfig1.EstPort = ((ushort)(1024));
      ztpConfig1.EstTsend = ((uint)(30u));
      ztpConfig1.Flags = ((Ztp.Configuration.ZtpConfig.ConfigFlag)((((((((((((((((((Ztp.Configuration.ZtpConfig.ConfigFlag.Din | Ztp.Configuration.ZtpConfig.ConfigFlag.Dout) 
            | Ztp.Configuration.ZtpConfig.ConfigFlag.Ain) 
            | Ztp.Configuration.ZtpConfig.ConfigFlag.UseScheduler) 
            | Ztp.Configuration.ZtpConfig.ConfigFlag.EstActive) 
            | Ztp.Configuration.ZtpConfig.ConfigFlag.EstParams) 
            | Ztp.Configuration.ZtpConfig.ConfigFlag.DbzPercent) 
            | Ztp.Configuration.ZtpConfig.ConfigFlag.Debug) 
            | Ztp.Configuration.ZtpConfig.ConfigFlag.Debounce) 
            | Ztp.Configuration.ZtpConfig.ConfigFlag.Location) 
            | Ztp.Configuration.ZtpConfig.ConfigFlag.Scheduler) 
            | Ztp.Configuration.ZtpConfig.ConfigFlag.Rs485) 
            | Ztp.Configuration.ZtpConfig.ConfigFlag.Door) 
            | Ztp.Configuration.ZtpConfig.ConfigFlag.PlanReboot) 
            | Ztp.Configuration.ZtpConfig.ConfigFlag.UseIec) 
            | Ztp.Configuration.ZtpConfig.ConfigFlag.ComType) 
            | Ztp.Configuration.ZtpConfig.ConfigFlag.Ping) 
            | Ztp.Configuration.ZtpConfig.ConfigFlag.Logs)));
      ztpConfig1.Gprs = ((uint)(0u));
      ztpConfig1.Gsm = ((uint)(0u));
      ztpConfig1.Imei = "";
      ztpConfig1.IpOwn = "";
      ztpConfig1.IpPing = "";
      ztpConfig1.IsHalfBright = false;
      ztpConfig1.IsReadedFromDevice = false;
      ztpConfig1.Latitude = 55.1911F;
      ztpLight1.Scheduler = ztpScheduler1;
      ztpLight1.UseScheduler = false;
      ztpConfig1.Light = ztpLight1;
      ztpConfig1.logLevel = ((byte)(5));
      ztpConfig1.Longitude = 30.12533F;
      ztpConfig1.NetTechnology = "";
      ztpConfig1.Number = 1;
      ztpConfig1.PingPeriod = ((byte)(1));
      ztpConfig1.rebootTime = "";
      ztpConfig1.Signal = 0;
      ztpConfig1.Sim = ((uint)(0u));
      ztpConfig1.SoftVersion = "";
      ztpConfig1.Sunrise = new System.DateTime(((long)(0)));
      ztpConfig1.Sunset = new System.DateTime(((long)(0)));
      ztpConfig1.TimeZone = ((sbyte)(-12));
      ztpConfig1.Version = "I1O1A1-LDC-3";
      this.@__config.Value = ztpConfig1;
      // 
      // tabPage2
      // 
      this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.tabPage2.Controls.Add(this.splitContainer1);
      this.tabPage2.ImageIndex = 0;
      this.tabPage2.Location = new System.Drawing.Point(4, 34);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(1101, 601);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "План освещения";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(3, 3);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.@__planEditor);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.PicLightSwitcher);
      this.splitContainer1.Panel2.Controls.Add(this.btnLightSwitcher);
      this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
      this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
      this.splitContainer1.Size = new System.Drawing.Size(1095, 595);
      this.splitContainer1.SplitterDistance = 851;
      this.splitContainer1.TabIndex = 0;
      // 
      // __planEditor
      // 
      this.@__planEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.@__planEditor.Location = new System.Drawing.Point(0, 0);
      this.@__planEditor.Name = "__planEditor";
      this.@__planEditor.Size = new System.Drawing.Size(851, 595);
      this.@__planEditor.TabIndex = 0;
      this.@__planEditor.UseSchedulerEnable = true;
      this.@__planEditor.UseSchedulerVisible = false;
      ztpLight2.Scheduler = ztpScheduler2;
      ztpLight2.UseScheduler = true;
      this.@__planEditor.Value = ztpLight2;
      ztpLocation1.Latitude = 0F;
      ztpLocation1.Longitude = 0F;
      ztpLocation1.TimeZone = ((sbyte)(0));
      this.@__planEditor.ZtpLocation = ztpLocation1;
      // 
      // PicLightSwitcher
      // 
      this.PicLightSwitcher.Image = global::UlcWin.Properties.Resources.lightbulb_off;
      this.PicLightSwitcher.Location = new System.Drawing.Point(100, 393);
      this.PicLightSwitcher.Name = "PicLightSwitcher";
      this.PicLightSwitcher.Size = new System.Drawing.Size(34, 37);
      this.PicLightSwitcher.TabIndex = 11;
      this.PicLightSwitcher.TabStop = false;
      // 
      // btnLightSwitcher
      // 
      this.btnLightSwitcher.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnLightSwitcher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnLightSwitcher.ImageIndex = 15;
      this.btnLightSwitcher.Location = new System.Drawing.Point(43, 436);
      this.btnLightSwitcher.Name = "btnLightSwitcher";
      this.btnLightSwitcher.Size = new System.Drawing.Size(170, 31);
      this.btnLightSwitcher.TabIndex = 10;
      this.btnLightSwitcher.Text = "Включить освещение";
      this.btnLightSwitcher.UseVisualStyleBackColor = true;
      this.btnLightSwitcher.Click += new System.EventHandler(this.pictureBox1_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.btnScheduleAdd);
      this.groupBox2.Controls.Add(this.btnScheduleDelete);
      this.groupBox2.Controls.Add(this.btnScheduleEdit);
      this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.groupBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.groupBox2.Location = new System.Drawing.Point(17, 188);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(210, 136);
      this.groupBox2.TabIndex = 9;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Расписание";
      // 
      // btnScheduleAdd
      // 
      this.btnScheduleAdd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnScheduleAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnScheduleAdd.ImageIndex = 7;
      this.btnScheduleAdd.ImageList = this.imlTc;
      this.btnScheduleAdd.Location = new System.Drawing.Point(26, 22);
      this.btnScheduleAdd.Name = "btnScheduleAdd";
      this.btnScheduleAdd.Size = new System.Drawing.Size(170, 31);
      this.btnScheduleAdd.TabIndex = 0;
      this.btnScheduleAdd.Text = "Добавить расписание";
      this.btnScheduleAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnScheduleAdd.UseVisualStyleBackColor = true;
      this.btnScheduleAdd.Click += new System.EventHandler(this.btnScheduleAdd_Click);
      // 
      // imlTc
      // 
      this.imlTc.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTc.ImageStream")));
      this.imlTc.TransparentColor = System.Drawing.Color.Transparent;
      this.imlTc.Images.SetKeyName(0, "history.png");
      this.imlTc.Images.SetKeyName(1, "port.png");
      this.imlTc.Images.SetKeyName(2, "bricks.png");
      this.imlTc.Images.SetKeyName(3, "cpu_preferences.png");
      this.imlTc.Images.SetKeyName(4, "bookmark_add.ico");
      this.imlTc.Images.SetKeyName(5, "bookmarks_preferences.ico");
      this.imlTc.Images.SetKeyName(6, "bookmark_delete.ico");
      this.imlTc.Images.SetKeyName(7, "clock.ico");
      this.imlTc.Images.SetKeyName(8, "clock_pause.ico");
      this.imlTc.Images.SetKeyName(9, "clock_preferences.ico");
      this.imlTc.Images.SetKeyName(10, "clock_refresh.ico");
      this.imlTc.Images.SetKeyName(11, "clock_reset.ico");
      this.imlTc.Images.SetKeyName(12, "clock_run.ico");
      this.imlTc.Images.SetKeyName(13, "clock_stop.ico");
      this.imlTc.Images.SetKeyName(14, "lightbulb.ico");
      this.imlTc.Images.SetKeyName(15, "lightbulb_off.ico");
      // 
      // btnScheduleDelete
      // 
      this.btnScheduleDelete.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnScheduleDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnScheduleDelete.ImageIndex = 13;
      this.btnScheduleDelete.ImageList = this.imlTc;
      this.btnScheduleDelete.Location = new System.Drawing.Point(26, 92);
      this.btnScheduleDelete.Name = "btnScheduleDelete";
      this.btnScheduleDelete.Size = new System.Drawing.Size(170, 27);
      this.btnScheduleDelete.TabIndex = 1;
      this.btnScheduleDelete.Text = "Удалить расписание";
      this.btnScheduleDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnScheduleDelete.UseVisualStyleBackColor = true;
      this.btnScheduleDelete.Click += new System.EventHandler(this.btnScheduleDelete_Click);
      // 
      // btnScheduleEdit
      // 
      this.btnScheduleEdit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnScheduleEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnScheduleEdit.ImageIndex = 9;
      this.btnScheduleEdit.ImageList = this.imlTc;
      this.btnScheduleEdit.Location = new System.Drawing.Point(26, 59);
      this.btnScheduleEdit.Name = "btnScheduleEdit";
      this.btnScheduleEdit.Size = new System.Drawing.Size(170, 27);
      this.btnScheduleEdit.TabIndex = 2;
      this.btnScheduleEdit.Text = "Изменить расписание";
      this.btnScheduleEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnScheduleEdit.UseVisualStyleBackColor = true;
      this.btnScheduleEdit.Click += new System.EventHandler(this.btnScheduleEdit_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.btnAddSeason);
      this.groupBox1.Controls.Add(this.btnReamoveSeason);
      this.groupBox1.Controls.Add(this.btnChangeSeason);
      this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.groupBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.groupBox1.Location = new System.Drawing.Point(17, 27);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(210, 131);
      this.groupBox1.TabIndex = 8;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Сезоны";
      // 
      // btnAddSeason
      // 
      this.btnAddSeason.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnAddSeason.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnAddSeason.ImageIndex = 4;
      this.btnAddSeason.ImageList = this.imlTc;
      this.btnAddSeason.Location = new System.Drawing.Point(26, 22);
      this.btnAddSeason.Name = "btnAddSeason";
      this.btnAddSeason.Size = new System.Drawing.Size(158, 31);
      this.btnAddSeason.TabIndex = 0;
      this.btnAddSeason.Text = "Добавить сезон";
      this.btnAddSeason.UseVisualStyleBackColor = true;
      this.btnAddSeason.Click += new System.EventHandler(this.btnAddSeason_Click);
      // 
      // btnReamoveSeason
      // 
      this.btnReamoveSeason.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnReamoveSeason.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnReamoveSeason.ImageIndex = 5;
      this.btnReamoveSeason.ImageList = this.imlTc;
      this.btnReamoveSeason.Location = new System.Drawing.Point(26, 92);
      this.btnReamoveSeason.Name = "btnReamoveSeason";
      this.btnReamoveSeason.Size = new System.Drawing.Size(158, 27);
      this.btnReamoveSeason.TabIndex = 1;
      this.btnReamoveSeason.Text = "Удалить сезон";
      this.btnReamoveSeason.UseVisualStyleBackColor = true;
      this.btnReamoveSeason.Click += new System.EventHandler(this.btnReamoveSeason_Click);
      // 
      // btnChangeSeason
      // 
      this.btnChangeSeason.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnChangeSeason.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnChangeSeason.ImageIndex = 6;
      this.btnChangeSeason.ImageList = this.imlTc;
      this.btnChangeSeason.Location = new System.Drawing.Point(26, 59);
      this.btnChangeSeason.Name = "btnChangeSeason";
      this.btnChangeSeason.Size = new System.Drawing.Size(158, 27);
      this.btnChangeSeason.TabIndex = 2;
      this.btnChangeSeason.Text = "Изменить сезон";
      this.btnChangeSeason.UseVisualStyleBackColor = true;
      this.btnChangeSeason.Click += new System.EventHandler(this.btnChangeSeason_Click);
      // 
      // tabPage3
      // 
      this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.tabPage3.Controls.Add(this.@__modbusItemList);
      this.tabPage3.Controls.Add(this.@__comPortEditor);
      this.tabPage3.Controls.Add(this.@__modBusSettings);
      this.tabPage3.ImageIndex = 1;
      this.tabPage3.Location = new System.Drawing.Point(4, 34);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new System.Drawing.Size(1101, 601);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "RS-485";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // __modbusItemList
      // 
      this.@__modbusItemList.AutoSize = true;
      this.@__modbusItemList.Location = new System.Drawing.Point(20, 160);
      this.@__modbusItemList.max_mb_Tags = ((short)(100));
      this.@__modbusItemList.Name = "__modbusItemList";
      this.@__modbusItemList.Size = new System.Drawing.Size(1065, 429);
      this.@__modbusItemList.TabIndex = 2;
      // 
      // __comPortEditor
      // 
      this.@__comPortEditor.EnabledBaudrates = true;
      this.@__comPortEditor.EnabledDataBits = true;
      this.@__comPortEditor.EnabledHandshake = true;
      this.@__comPortEditor.EnabledParity = true;
      this.@__comPortEditor.EnabledPortName = true;
      this.@__comPortEditor.EnabledStopBits = true;
      this.@__comPortEditor.Location = new System.Drawing.Point(20, 14);
      this.@__comPortEditor.Name = "__comPortEditor";
      this.@__comPortEditor.ShowHandshake = true;
      this.@__comPortEditor.ShowPortName = false;
      this.@__comPortEditor.ShowTimeout = false;
      this.@__comPortEditor.Size = new System.Drawing.Size(523, 140);
      this.@__comPortEditor.TabIndex = 1;
      comPortSettings2.BaudRate = 9600;
      comPortSettings2.DataBits = ((byte)(8));
      comPortSettings2.Handshake = Ztp.Port.ComPort.Handshake.None;
      comPortSettings2.Kind = Ztp.Port.PortKind.Com;
      comPortSettings2.Parity = Ztp.Port.ComPort.Parity.None;
      comPortSettings2.PortName = "COM1";
      comPortSettings2.StopBits = Ztp.Port.ComPort.StopBits.One;
      comPortSettings2.Timeout = 5000;
      this.@__comPortEditor.Value = comPortSettings2;
      // 
      // __modBusSettings
      // 
      this.@__modBusSettings.Location = new System.Drawing.Point(581, 14);
      this.@__modBusSettings.Name = "__modBusSettings";
      this.@__modBusSettings.Size = new System.Drawing.Size(504, 115);
      this.@__modBusSettings.TabIndex = 0;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.22767F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.772334F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1117, 695);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.flowLayoutPanel1.Controls.Add(this.btnChancel);
      this.flowLayoutPanel1.Controls.Add(this.btnOk);
      this.flowLayoutPanel1.Controls.Add(this.btnSave);
      this.flowLayoutPanel1.Controls.Add(this.btnFile);
      this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 659);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(1109, 32);
      this.flowLayoutPanel1.TabIndex = 1;
      // 
      // btnChancel
      // 
      this.btnChancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnChancel.Location = new System.Drawing.Point(1013, 3);
      this.btnChancel.Name = "btnChancel";
      this.btnChancel.Size = new System.Drawing.Size(93, 27);
      this.btnChancel.TabIndex = 0;
      this.btnChancel.Text = "Выход";
      this.btnChancel.UseVisualStyleBackColor = true;
      this.btnChancel.Click += new System.EventHandler(this.btnChancel_Click);
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(918, 3);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(89, 27);
      this.btnOk.TabIndex = 1;
      this.btnOk.Text = "Записать";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(821, 3);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(91, 27);
      this.btnSave.TabIndex = 0;
      this.btnSave.Text = "Обновить";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnFile
      // 
      this.btnFile.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.btnFile.Location = new System.Drawing.Point(710, 3);
      this.btnFile.Name = "btnFile";
      this.btnFile.Size = new System.Drawing.Size(105, 27);
      this.btnFile.TabIndex = 1;
      this.btnFile.Text = "Из файла";
      this.btnFile.UseVisualStyleBackColor = true;
      this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // RequestForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnChancel;
      this.ClientSize = new System.Drawing.Size(1117, 695);
      this.ControlBox = false;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.Name = "RequestForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Редактирование настроек контроллера";
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.PicLightSwitcher)).EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.Button btnAddSeason;
        private System.Windows.Forms.Button btnChangeSeason;
        private System.Windows.Forms.Button btnReamoveSeason;
        private Ztp.Ui.ComPortSettingsEditorControl __comPortEditor;
        private Ztp.Ui.ModBusSettingsEditorControl __modBusSettings;
        private Ztp.Ui.ModbusItemListControl __modbusItemList;
        private Ztp.Ui.LightPlanEditorControl __planEditor;
        private Ztp.Ui.CurrentStateViewControl __currentStateViewControl;
        private Ztp.Ui.ConfigEditorControl __config;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button btnScheduleAdd;
    private System.Windows.Forms.Button btnScheduleDelete;
    private System.Windows.Forms.Button btnScheduleEdit;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.Button btnChancel;
    private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    public System.Windows.Forms.ImageList imlTc;
    private System.Windows.Forms.PictureBox PicLightSwitcher;
    private System.Windows.Forms.Button btnLightSwitcher;
  }
}