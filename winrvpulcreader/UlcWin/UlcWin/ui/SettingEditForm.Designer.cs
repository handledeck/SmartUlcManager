namespace UlcWin.ui
{
  partial class SettingEditForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingEditForm));
      Ztp.Port.ComPort.ComPortSettings comPortSettings2 = new Ztp.Port.ComPort.ComPortSettings();
      this.TabsController = new System.Windows.Forms.TabControl();
      this.TabMainPage = new System.Windows.Forms.TabPage();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.@__currentStateViewControl = new Ztp.Ui.CurrentStateViewControl();
      this.@__config = new Ztp.Ui.ConfigEditorControl();
      this.TabScheduleLight = new System.Windows.Forms.TabPage();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.@__planEditor = new Ztp.Ui.LightPlanEditorControl();
      this.btnShowAll = new System.Windows.Forms.Button();
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
      this.TabSerialPort = new System.Windows.Forms.TabPage();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.usrUartModule1 = new Uart.UsrUartModule();
      this.@__comPortEditor = new Ztp.Ui.ComPortSettingsEditorControl();
      this.TabForwardPage = new System.Windows.Forms.TabPage();
      this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.txtMask = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.txtGateway = new System.Windows.Forms.TextBox();
      this.txtIp = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.groupBox5 = new System.Windows.Forms.GroupBox();
      this.ethernetModule1 = new UlcWin.Controls.Modules.EthernetModule();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.btnClose = new System.Windows.Forms.Button();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.TabsController.SuspendLayout();
      this.TabMainPage.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.TabScheduleLight.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PicLightSwitcher)).BeginInit();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.TabSerialPort.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.TabForwardPage.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      this.panel1.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.panel2.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // TabsController
      // 
      this.TabsController.Controls.Add(this.TabMainPage);
      this.TabsController.Controls.Add(this.TabScheduleLight);
      this.TabsController.Controls.Add(this.TabSerialPort);
      this.TabsController.Controls.Add(this.TabForwardPage);
      this.TabsController.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TabsController.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.TabsController.ImageList = this.imlTc;
      this.TabsController.ItemSize = new System.Drawing.Size(130, 30);
      this.TabsController.Location = new System.Drawing.Point(4, 4);
      this.TabsController.Name = "TabsController";
      this.TabsController.SelectedIndex = 0;
      this.TabsController.Size = new System.Drawing.Size(992, 639);
      this.TabsController.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
      this.TabsController.TabIndex = 0;
      // 
      // TabMainPage
      // 
      this.TabMainPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.TabMainPage.Controls.Add(this.tableLayoutPanel2);
      this.TabMainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.TabMainPage.ImageIndex = 2;
      this.TabMainPage.Location = new System.Drawing.Point(4, 34);
      this.TabMainPage.Name = "TabMainPage";
      this.TabMainPage.Padding = new System.Windows.Forms.Padding(3);
      this.TabMainPage.Size = new System.Drawing.Size(984, 601);
      this.TabMainPage.TabIndex = 0;
      this.TabMainPage.Text = "Общие";
      this.TabMainPage.UseVisualStyleBackColor = true;
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
      this.tableLayoutPanel2.Size = new System.Drawing.Size(978, 595);
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
      this.@__currentStateViewControl.Location = new System.Drawing.Point(728, 3);
      this.@__currentStateViewControl.Name = "__currentStateViewControl";
      this.@__currentStateViewControl.Size = new System.Drawing.Size(247, 589);
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
      this.@__config.Size = new System.Drawing.Size(719, 589);
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
      // TabScheduleLight
      // 
      this.TabScheduleLight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.TabScheduleLight.Controls.Add(this.splitContainer1);
      this.TabScheduleLight.ImageIndex = 0;
      this.TabScheduleLight.Location = new System.Drawing.Point(4, 34);
      this.TabScheduleLight.Name = "TabScheduleLight";
      this.TabScheduleLight.Padding = new System.Windows.Forms.Padding(3);
      this.TabScheduleLight.Size = new System.Drawing.Size(984, 601);
      this.TabScheduleLight.TabIndex = 1;
      this.TabScheduleLight.Text = "План освещения";
      this.TabScheduleLight.UseVisualStyleBackColor = true;
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
      this.splitContainer1.Panel2.Controls.Add(this.btnShowAll);
      this.splitContainer1.Panel2.Controls.Add(this.PicLightSwitcher);
      this.splitContainer1.Panel2.Controls.Add(this.btnLightSwitcher);
      this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
      this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
      this.splitContainer1.Size = new System.Drawing.Size(978, 595);
      this.splitContainer1.SplitterDistance = 651;
      this.splitContainer1.SplitterWidth = 5;
      this.splitContainer1.TabIndex = 0;
      // 
      // __planEditor
      // 
      this.@__planEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.@__planEditor.Location = new System.Drawing.Point(0, 0);
      this.@__planEditor.Name = "__planEditor";
      this.@__planEditor.Size = new System.Drawing.Size(651, 595);
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
      // btnShowAll
      // 
      this.btnShowAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnShowAll.ImageIndex = 17;
      this.btnShowAll.ImageList = this.imlTc;
      this.btnShowAll.Location = new System.Drawing.Point(50, 542);
      this.btnShowAll.Name = "btnShowAll";
      this.btnShowAll.Size = new System.Drawing.Size(198, 26);
      this.btnShowAll.TabIndex = 12;
      this.btnShowAll.Text = "Просмотр расписаний";
      this.btnShowAll.UseVisualStyleBackColor = false;
      this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
      // 
      // PicLightSwitcher
      // 
      this.PicLightSwitcher.Image = global::UlcWin.Properties.Resources.lightbulb_off;
      this.PicLightSwitcher.Location = new System.Drawing.Point(117, 393);
      this.PicLightSwitcher.Name = "PicLightSwitcher";
      this.PicLightSwitcher.Size = new System.Drawing.Size(40, 37);
      this.PicLightSwitcher.TabIndex = 11;
      this.PicLightSwitcher.TabStop = false;
      // 
      // btnLightSwitcher
      // 
      this.btnLightSwitcher.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnLightSwitcher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnLightSwitcher.ImageIndex = 15;
      this.btnLightSwitcher.Location = new System.Drawing.Point(50, 436);
      this.btnLightSwitcher.Name = "btnLightSwitcher";
      this.btnLightSwitcher.Size = new System.Drawing.Size(198, 31);
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
      this.groupBox2.Location = new System.Drawing.Point(20, 188);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(245, 136);
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
      this.btnScheduleAdd.Location = new System.Drawing.Point(54, 22);
      this.btnScheduleAdd.Name = "btnScheduleAdd";
      this.btnScheduleAdd.Size = new System.Drawing.Size(166, 31);
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
      this.imlTc.Images.SetKeyName(16, "network_ip.png");
      this.imlTc.Images.SetKeyName(17, "time.png");
      // 
      // btnScheduleDelete
      // 
      this.btnScheduleDelete.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnScheduleDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnScheduleDelete.ImageIndex = 13;
      this.btnScheduleDelete.ImageList = this.imlTc;
      this.btnScheduleDelete.Location = new System.Drawing.Point(54, 92);
      this.btnScheduleDelete.Name = "btnScheduleDelete";
      this.btnScheduleDelete.Size = new System.Drawing.Size(166, 27);
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
      this.btnScheduleEdit.Location = new System.Drawing.Point(54, 59);
      this.btnScheduleEdit.Name = "btnScheduleEdit";
      this.btnScheduleEdit.Size = new System.Drawing.Size(166, 27);
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
      this.groupBox1.Location = new System.Drawing.Point(20, 27);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(245, 131);
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
      this.btnAddSeason.Location = new System.Drawing.Point(54, 22);
      this.btnAddSeason.Name = "btnAddSeason";
      this.btnAddSeason.Size = new System.Drawing.Size(153, 31);
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
      this.btnReamoveSeason.Location = new System.Drawing.Point(54, 92);
      this.btnReamoveSeason.Name = "btnReamoveSeason";
      this.btnReamoveSeason.Size = new System.Drawing.Size(153, 27);
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
      this.btnChangeSeason.Location = new System.Drawing.Point(54, 59);
      this.btnChangeSeason.Name = "btnChangeSeason";
      this.btnChangeSeason.Size = new System.Drawing.Size(153, 27);
      this.btnChangeSeason.TabIndex = 2;
      this.btnChangeSeason.Text = "Изменить сезон";
      this.btnChangeSeason.UseVisualStyleBackColor = true;
      this.btnChangeSeason.Click += new System.EventHandler(this.btnChangeSeason_Click);
      // 
      // TabSerialPort
      // 
      this.TabSerialPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.TabSerialPort.Controls.Add(this.groupBox3);
      this.TabSerialPort.Controls.Add(this.@__comPortEditor);
      this.TabSerialPort.ImageIndex = 1;
      this.TabSerialPort.Location = new System.Drawing.Point(4, 34);
      this.TabSerialPort.Name = "TabSerialPort";
      this.TabSerialPort.Size = new System.Drawing.Size(984, 601);
      this.TabSerialPort.TabIndex = 2;
      this.TabSerialPort.Text = "RS-485";
      this.TabSerialPort.UseVisualStyleBackColor = true;
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.usrUartModule1);
      this.groupBox3.Location = new System.Drawing.Point(4, 160);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(976, 438);
      this.groupBox3.TabIndex = 4;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Дополнительные настройки канала";
      // 
      // usrUartModule1
      // 
      this.usrUartModule1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.usrUartModule1.ListMBLabel = null;
      this.usrUartModule1.Location = new System.Drawing.Point(3, 17);
      this.usrUartModule1.Name = "usrUartModule1";
      this.usrUartModule1.ParentsForm = null;
      this.usrUartModule1.Size = new System.Drawing.Size(970, 418);
      this.usrUartModule1.TabIndex = 3;
      this.usrUartModule1.Value = null;
      this.usrUartModule1.EventReadUartData += new Uart.ReadUartData(this.usrUartModule1_EventReadUartData);
      this.usrUartModule1.EventHandlerUartData += new Uart.HendlerUartData(this.usrUartModule1_EventHandlerUartData);
      this.usrUartModule1.Load += new System.EventHandler(this.usrUartModule1_Load);
      // 
      // __comPortEditor
      // 
      this.@__comPortEditor.EnabledBaudrates = true;
      this.@__comPortEditor.EnabledDataBits = true;
      this.@__comPortEditor.EnabledHandshake = true;
      this.@__comPortEditor.EnabledParity = true;
      this.@__comPortEditor.EnabledPortName = true;
      this.@__comPortEditor.EnabledStopBits = true;
      this.@__comPortEditor.Location = new System.Drawing.Point(23, 14);
      this.@__comPortEditor.Name = "__comPortEditor";
      this.@__comPortEditor.ShowHandshake = true;
      this.@__comPortEditor.ShowPortName = false;
      this.@__comPortEditor.ShowTimeout = false;
      this.@__comPortEditor.Size = new System.Drawing.Size(637, 140);
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
      // TabForwardPage
      // 
      this.TabForwardPage.Controls.Add(this.tableLayoutPanel3);
      this.TabForwardPage.ImageIndex = 16;
      this.TabForwardPage.Location = new System.Drawing.Point(4, 34);
      this.TabForwardPage.Name = "TabForwardPage";
      this.TabForwardPage.Size = new System.Drawing.Size(984, 601);
      this.TabForwardPage.TabIndex = 3;
      this.TabForwardPage.Text = "Проброс портов";
      this.TabForwardPage.UseVisualStyleBackColor = true;
      // 
      // tableLayoutPanel3
      // 
      this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
      this.tableLayoutPanel3.ColumnCount = 1;
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
      this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 1);
      this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 2;
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.Size = new System.Drawing.Size(984, 601);
      this.tableLayoutPanel3.TabIndex = 0;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.groupBox4);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(5, 5);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(974, 94);
      this.panel1.TabIndex = 1;
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.txtMask);
      this.groupBox4.Controls.Add(this.label3);
      this.groupBox4.Controls.Add(this.label1);
      this.groupBox4.Controls.Add(this.txtGateway);
      this.groupBox4.Controls.Add(this.txtIp);
      this.groupBox4.Controls.Add(this.label2);
      this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox4.Location = new System.Drawing.Point(0, 0);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(974, 94);
      this.groupBox4.TabIndex = 6;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Сетевые настройки";
      // 
      // txtMask
      // 
      this.txtMask.Location = new System.Drawing.Point(496, 26);
      this.txtMask.Name = "txtMask";
      this.txtMask.Size = new System.Drawing.Size(161, 21);
      this.txtMask.TabIndex = 7;
      this.txtMask.Text = "255.255.255.0";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(384, 38);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(94, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Маска подсети";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(55, 43);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(59, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "IP-адрес";
      // 
      // txtGateway
      // 
      this.txtGateway.Location = new System.Drawing.Point(174, 63);
      this.txtGateway.Name = "txtGateway";
      this.txtGateway.Size = new System.Drawing.Size(161, 21);
      this.txtGateway.TabIndex = 5;
      this.txtGateway.Text = "192.168.1.1";
      this.txtGateway.Validating += new System.ComponentModel.CancelEventHandler(this.txtIp_Validating);
      // 
      // txtIp
      // 
      this.txtIp.Location = new System.Drawing.Point(174, 26);
      this.txtIp.Name = "txtIp";
      this.txtIp.Size = new System.Drawing.Size(161, 21);
      this.txtIp.TabIndex = 4;
      this.txtIp.Text = "192.168.1.1";
      this.txtIp.Validating += new System.ComponentModel.CancelEventHandler(this.txtIp_Validating);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(55, 75);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(100, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Основной шлюз";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.groupBox5);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(5, 107);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(974, 489);
      this.panel2.TabIndex = 2;
      // 
      // groupBox5
      // 
      this.groupBox5.Controls.Add(this.ethernetModule1);
      this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox5.Location = new System.Drawing.Point(0, 0);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new System.Drawing.Size(974, 489);
      this.groupBox5.TabIndex = 2;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Проброс портов";
      // 
      // ethernetModule1
      // 
      this.ethernetModule1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ethernetModule1.Location = new System.Drawing.Point(3, 17);
      this.ethernetModule1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
      this.ethernetModule1.Name = "ethernetModule1";
      this.ethernetModule1.ParentsForm = null;
      this.ethernetModule1.Size = new System.Drawing.Size(968, 469);
      this.ethernetModule1.TabIndex = 1;
      this.ethernetModule1.Value = null;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.TabsController, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.22767F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.772334F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 695);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.btnClose);
      this.panel3.Controls.Add(this.btnSave);
      this.panel3.Controls.Add(this.btnOk);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Location = new System.Drawing.Point(4, 650);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(992, 41);
      this.panel3.TabIndex = 1;
      // 
      // btnClose
      // 
      this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.btnClose.Location = new System.Drawing.Point(878, 6);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(104, 30);
      this.btnClose.TabIndex = 2;
      this.btnClose.Text = "Выход";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // btnSave
      // 
      this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.btnSave.Location = new System.Drawing.Point(10, 6);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(106, 30);
      this.btnSave.TabIndex = 0;
      this.btnSave.Text = "Обновить";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnUpdate_Click);
      // 
      // btnOk
      // 
      this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.btnOk.Location = new System.Drawing.Point(122, 6);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(104, 30);
      this.btnOk.TabIndex = 1;
      this.btnOk.Text = "Записать";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // SettingEditForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1000, 695);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SettingEditForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Редактирование настроек контроллера";
      this.TabsController.ResumeLayout(false);
      this.TabMainPage.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.TabScheduleLight.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.PicLightSwitcher)).EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.TabSerialPort.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.TabForwardPage.ResumeLayout(false);
      this.tableLayoutPanel3.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.groupBox5.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl TabsController;
    private System.Windows.Forms.TabPage TabMainPage;
    private System.Windows.Forms.TabPage TabScheduleLight;
    private System.Windows.Forms.TabPage TabSerialPort;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.Button btnAddSeason;
    private System.Windows.Forms.Button btnChangeSeason;
    private System.Windows.Forms.Button btnReamoveSeason;
    private Ztp.Ui.ComPortSettingsEditorControl __comPortEditor;
    private Ztp.Ui.LightPlanEditorControl __planEditor;
    private Ztp.Ui.CurrentStateViewControl __currentStateViewControl;
    private Ztp.Ui.ConfigEditorControl __config;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button btnScheduleAdd;
    private System.Windows.Forms.Button btnScheduleDelete;
    private System.Windows.Forms.Button btnScheduleEdit;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    public System.Windows.Forms.ImageList imlTc;
    private System.Windows.Forms.PictureBox PicLightSwitcher;
    private System.Windows.Forms.Button btnLightSwitcher;
    private Uart.UsrUartModule usrUartModule1;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.TabPage TabForwardPage;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    public System.Windows.Forms.TextBox txtGateway;
    public System.Windows.Forms.TextBox txtIp;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.Panel panel2;
    private Controls.Modules.EthernetModule ethernetModule1;
    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    public System.Windows.Forms.TextBox txtMask;
    private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnShowAll;
    }
}