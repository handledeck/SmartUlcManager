namespace ZtpManager
{
  partial class ZtpConfigForm
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
      Ztp.Configuration.ZtpScheduler ztpScheduler1 = new Ztp.Configuration.ZtpScheduler();
      Ztp.Port.ComPort.ComPortSettings comPortSettings2 = new Ztp.Port.ComPort.ComPortSettings();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZtpConfigForm));
      this.scDeviceDebug = new System.Windows.Forms.SplitContainer();
      this.scCurrentState = new System.Windows.Forms.SplitContainer();
      this.tcConfig = new System.Windows.Forms.TabControl();
      this.tpGeneral = new System.Windows.Forms.TabPage();
      this.configEditor = new Ztp.Ui.ConfigEditorControl();
      this.tpScheduler = new System.Windows.Forms.TabPage();
      this.lightPlanEditor = new Ztp.Ui.LightPlanEditorControl();
      this.tpRs485 = new System.Windows.Forms.TabPage();
      this.comPortEditor = new Ztp.Ui.ComPortSettingsEditorControl();
      this.iml = new System.Windows.Forms.ImageList(this.components);
      this.currentStateView = new Ztp.Ui.CurrentStateViewControl();
      this.label1 = new System.Windows.Forms.Label();
      this.uiLogConsole = new Ztp.Ui.UiLogConsoleControl();
      this.label2 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.scDeviceDebug)).BeginInit();
      this.scDeviceDebug.Panel1.SuspendLayout();
      this.scDeviceDebug.Panel2.SuspendLayout();
      this.scDeviceDebug.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.scCurrentState)).BeginInit();
      this.scCurrentState.Panel1.SuspendLayout();
      this.scCurrentState.Panel2.SuspendLayout();
      this.scCurrentState.SuspendLayout();
      this.tcConfig.SuspendLayout();
      this.tpGeneral.SuspendLayout();
      this.tpScheduler.SuspendLayout();
      this.tpRs485.SuspendLayout();
      this.SuspendLayout();
      // 
      // scDeviceDebug
      // 
      this.scDeviceDebug.Dock = System.Windows.Forms.DockStyle.Fill;
      this.scDeviceDebug.Location = new System.Drawing.Point(0, 0);
      this.scDeviceDebug.Name = "scDeviceDebug";
      this.scDeviceDebug.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // scDeviceDebug.Panel1
      // 
      this.scDeviceDebug.Panel1.Controls.Add(this.scCurrentState);
      // 
      // scDeviceDebug.Panel2
      // 
      this.scDeviceDebug.Panel2.Controls.Add(this.uiLogConsole);
      this.scDeviceDebug.Panel2.Controls.Add(this.label2);
      this.scDeviceDebug.Size = new System.Drawing.Size(1151, 603);
      this.scDeviceDebug.SplitterDistance = 459;
      this.scDeviceDebug.TabIndex = 3;
      // 
      // scCurrentState
      // 
      this.scCurrentState.Dock = System.Windows.Forms.DockStyle.Fill;
      this.scCurrentState.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.scCurrentState.IsSplitterFixed = true;
      this.scCurrentState.Location = new System.Drawing.Point(0, 0);
      this.scCurrentState.Name = "scCurrentState";
      // 
      // scCurrentState.Panel1
      // 
      this.scCurrentState.Panel1.Controls.Add(this.tcConfig);
      // 
      // scCurrentState.Panel2
      // 
      this.scCurrentState.Panel2.Controls.Add(this.currentStateView);
      this.scCurrentState.Panel2.Controls.Add(this.label1);
      this.scCurrentState.Panel2MinSize = 300;
      this.scCurrentState.Size = new System.Drawing.Size(1151, 459);
      this.scCurrentState.SplitterDistance = 800;
      this.scCurrentState.TabIndex = 0;
      // 
      // tcConfig
      // 
      this.tcConfig.Controls.Add(this.tpGeneral);
      this.tcConfig.Controls.Add(this.tpScheduler);
      this.tcConfig.Controls.Add(this.tpRs485);
      this.tcConfig.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tcConfig.ImageList = this.iml;
      this.tcConfig.ItemSize = new System.Drawing.Size(150, 22);
      this.tcConfig.Location = new System.Drawing.Point(0, 0);
      this.tcConfig.Name = "tcConfig";
      this.tcConfig.SelectedIndex = 0;
      this.tcConfig.Size = new System.Drawing.Size(800, 459);
      this.tcConfig.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
      this.tcConfig.TabIndex = 0;
      // 
      // tpGeneral
      // 
      this.tpGeneral.Controls.Add(this.configEditor);
      this.tpGeneral.ImageIndex = 0;
      this.tpGeneral.Location = new System.Drawing.Point(4, 26);
      this.tpGeneral.Name = "tpGeneral";
      this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
      this.tpGeneral.Size = new System.Drawing.Size(792, 429);
      this.tpGeneral.TabIndex = 0;
      this.tpGeneral.Text = "Общие";
      this.tpGeneral.UseVisualStyleBackColor = true;
      // 
      // configEditor
      // 
      this.configEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.configEditor.Location = new System.Drawing.Point(3, 3);
      this.configEditor.Name = "configEditor";
      this.configEditor.ShowApnProperty = true;
      this.configEditor.Size = new System.Drawing.Size(786, 423);
      this.configEditor.TabIndex = 0;
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
      ztpConfig1.DateTime = new System.DateTime(2017, 10, 12, 15, 45, 12, 730);
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
      ztpConfig1.Flags = ((Ztp.Configuration.ZtpConfig.ConfigFlag)(((((((((((((Ztp.Configuration.ZtpConfig.ConfigFlag.Din | Ztp.Configuration.ZtpConfig.ConfigFlag.Dout) 
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
            | Ztp.Configuration.ZtpConfig.ConfigFlag.Door)));
      ztpConfig1.Gprs = ((uint)(0u));
      ztpConfig1.Gsm = ((uint)(0u));
      ztpConfig1.IpOwn = "";
      ztpConfig1.IsReadedFromDevice = false;
      ztpConfig1.Latitude = 55.1911F;
      ztpConfig1.Longitude = 30.12533F;
      ztpConfig1.Number = 1;
      ztpConfig1.Signal = ((int)(0u));
      ztpConfig1.Sim = ((uint)(0u));
      ztpConfig1.Sunrise = new System.DateTime(((long)(0)));
      ztpConfig1.Sunset = new System.DateTime(((long)(0)));
      ztpConfig1.TimeZone = ((sbyte)(-12));
      ztpConfig1.Version = "I1O1A1-LDC-3";
      this.configEditor.Value = ztpConfig1;
      // 
      // tpScheduler
      // 
      this.tpScheduler.Controls.Add(this.lightPlanEditor);
      this.tpScheduler.ImageIndex = 1;
      this.tpScheduler.Location = new System.Drawing.Point(4, 26);
      this.tpScheduler.Name = "tpScheduler";
      this.tpScheduler.Padding = new System.Windows.Forms.Padding(3);
      this.tpScheduler.Size = new System.Drawing.Size(716, 429);
      this.tpScheduler.TabIndex = 1;
      this.tpScheduler.Text = "План освещения";
      this.tpScheduler.UseVisualStyleBackColor = true;
      // 
      // lightPlanEditor
      // 
      this.lightPlanEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lightPlanEditor.Location = new System.Drawing.Point(3, 3);
      this.lightPlanEditor.Name = "lightPlanEditor";
      this.lightPlanEditor.Size = new System.Drawing.Size(710, 423);
      this.lightPlanEditor.TabIndex = 0;
      this.lightPlanEditor.Value = null;
      this.lightPlanEditor.NeedEnableUpdate += new System.EventHandler(this.lightPlanEditor_NeedEnableUpdate);
      // 
      // tpRs485
      // 
      this.tpRs485.Controls.Add(this.comPortEditor);
      this.tpRs485.ImageIndex = 2;
      this.tpRs485.Location = new System.Drawing.Point(4, 26);
      this.tpRs485.Name = "tpRs485";
      this.tpRs485.Size = new System.Drawing.Size(716, 429);
      this.tpRs485.TabIndex = 2;
      this.tpRs485.Text = "RS485";
      this.tpRs485.UseVisualStyleBackColor = true;
      // 
      // comPortEditor
      // 
      this.comPortEditor.EnabledBaudrates = true;
      this.comPortEditor.EnabledDataBits = true;
      this.comPortEditor.EnabledHandshake = true;
      this.comPortEditor.EnabledParity = true;
      this.comPortEditor.EnabledPortName = true;
      this.comPortEditor.EnabledStopBits = true;
      this.comPortEditor.Location = new System.Drawing.Point(3, 3);
      this.comPortEditor.Name = "comPortEditor";
      this.comPortEditor.ShowHandshake = false;
      this.comPortEditor.ShowPortName = false;
      this.comPortEditor.ShowTimeout = false;
      this.comPortEditor.Size = new System.Drawing.Size(433, 132);
      this.comPortEditor.TabIndex = 1;
      comPortSettings2.BaudRate = 9600;
      comPortSettings2.DataBits = ((byte)(8));
      comPortSettings2.Handshake = Ztp.Port.ComPort.Handshake.None;
      comPortSettings2.Kind = Ztp.Port.PortKind.Com;
      comPortSettings2.Parity = Ztp.Port.ComPort.Parity.None;
      comPortSettings2.PortName = "COM1";
      comPortSettings2.StopBits = Ztp.Port.ComPort.StopBits.One;
      comPortSettings2.Timeout = 1000;
      this.comPortEditor.Value = comPortSettings2;
      // 
      // iml
      // 
      this.iml.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml.ImageStream")));
      this.iml.TransparentColor = System.Drawing.Color.Transparent;
      this.iml.Images.SetKeyName(0, "bricks.png");
      this.iml.Images.SetKeyName(1, "history.png");
      this.iml.Images.SetKeyName(2, "port.png");
      // 
      // currentStateView
      // 
      this.currentStateView.AinValue = new ushort[] {
        ((ushort)(0))};
      this.currentStateView.Caption = "";
      this.currentStateView.DinValue = new bool[] {
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
      this.currentStateView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.currentStateView.DoutValue = new bool[] {
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
      this.currentStateView.Location = new System.Drawing.Point(0, 18);
      this.currentStateView.Name = "currentStateView";
      this.currentStateView.Size = new System.Drawing.Size(347, 441);
      this.currentStateView.TabIndex = 0;
      this.currentStateView.Value = null;
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.label1.Dock = System.Windows.Forms.DockStyle.Top;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(347, 18);
      this.label1.TabIndex = 1;
      this.label1.Text = "Состояние";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // uiLogConsole
      // 
      this.uiLogConsole.Dock = System.Windows.Forms.DockStyle.Fill;
      this.uiLogConsole.Location = new System.Drawing.Point(0, 18);
      this.uiLogConsole.Name = "uiLogConsole";
      this.uiLogConsole.Size = new System.Drawing.Size(1151, 122);
      this.uiLogConsole.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.label2.Dock = System.Windows.Forms.DockStyle.Top;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(0, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(1151, 18);
      this.label2.TabIndex = 2;
      this.label2.Text = "Отладка";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // ZtpConfigForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1151, 603);
      this.Controls.Add(this.scDeviceDebug);
      this.Name = "ZtpConfigForm";
      this.scDeviceDebug.Panel1.ResumeLayout(false);
      this.scDeviceDebug.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.scDeviceDebug)).EndInit();
      this.scDeviceDebug.ResumeLayout(false);
      this.scCurrentState.Panel1.ResumeLayout(false);
      this.scCurrentState.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.scCurrentState)).EndInit();
      this.scCurrentState.ResumeLayout(false);
      this.tcConfig.ResumeLayout(false);
      this.tpGeneral.ResumeLayout(false);
      this.tpScheduler.ResumeLayout(false);
      this.tpRs485.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer scDeviceDebug;
    private System.Windows.Forms.SplitContainer scCurrentState;
    private System.Windows.Forms.TabControl tcConfig;
    private System.Windows.Forms.TabPage tpGeneral;
    private Ztp.Ui.ConfigEditorControl configEditor;
    private System.Windows.Forms.TabPage tpScheduler;
    private Ztp.Ui.LightPlanEditorControl lightPlanEditor;
    private System.Windows.Forms.TabPage tpRs485;
    private Ztp.Ui.ComPortSettingsEditorControl comPortEditor;
    private Ztp.Ui.CurrentStateViewControl currentStateView;
    private System.Windows.Forms.Label label1;
    private Ztp.Ui.UiLogConsoleControl uiLogConsole;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ImageList iml;
  }
}