namespace UlcWin.ui
{
  partial class PartitionConfigEditorControl
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
      Ztp.Port.ComPort.ComPortSettings comPortSettings1 = new Ztp.Port.ComPort.ComPortSettings();
      this.flp = new System.Windows.Forms.FlowLayoutPanel();
      this.exDin = new Ztp.Ui.ExpanderControl();
      this.dinEditor = new Ztp.Ui.DinEditorControl();
      this.exDout = new Ztp.Ui.ExpanderControl();
      this.doutEditor = new Ztp.Ui.DoutEditorControl();
      this.exAin = new Ztp.Ui.ExpanderControl();
      this.ainEditor = new Ztp.Ui.AinEditorControl();
      this.exDoor = new Ztp.Ui.ExpanderControl();
      this.doorEditor = new Ztp.Ui.DinEditorControl();
      this.exUseSchedule = new Ztp.Ui.ExpanderControl();
      this.useSchedulerEditor = new Ztp.Ui.UseSchedulerControl();
      this.exScheduler = new Ztp.Ui.ExpanderControl();
      this.wb = new System.Windows.Forms.WebBrowser();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnSelectLightPlan = new System.Windows.Forms.Button();
      this.exEstActive = new Ztp.Ui.ExpanderControl();
      this.cbEstActive = new System.Windows.Forms.CheckBox();
      this.exEstParams = new Ztp.Ui.ExpanderControl();
      this.itEstTsend = new Ztp.Ui.InputDoubleControl();
      this.itEstPort = new Ztp.Ui.InputDoubleControl();
      this.itEstAddress = new Ztp.Ui.InputTextControl();
      this.exLocation = new Ztp.Ui.ExpanderControl();
      this.inputTimeZone = new Ztp.Ui.InputTimeZoneControl();
      this.idLongitude = new Ztp.Ui.InputDoubleControl();
      this.idLatitude = new Ztp.Ui.InputDoubleControl();
      this.exDbz = new Ztp.Ui.ExpanderControl();
      this.idDbz = new Ztp.Ui.InputDoubleControl();
      this.exDebounce = new Ztp.Ui.ExpanderControl();
      this.itDebounce = new Ztp.Ui.InputDoubleControl();
      this.exDebug = new Ztp.Ui.ExpanderControl();
      this.cbDebug = new System.Windows.Forms.CheckBox();
      this.exRs485 = new Ztp.Ui.ExpanderControl();
      this.comPortSettingsEditor = new Ztp.Ui.ComPortSettingsEditorControl();
      this.exPing = new Ztp.Ui.ExpanderControl();
      this.pingEditorControl1 = new Ztp.Ui.PingEditorControl();
      this.exPlanReboot = new Ztp.Ui.ExpanderControl();
      this.planResetControl1 = new Ztp.Ui.PlanResetControl();
      this.exIec104Control = new Ztp.Ui.ExpanderControl();
      this.iec104EditorControl = new Ztp.Ui.Iec104EditorControl();
      this.exLogsControl = new Ztp.Ui.ExpanderControl();
      this.lscLogs = new Ztp.Ui.LogsStateControl();
      this.flp.SuspendLayout();
      this.exDin.Content.SuspendLayout();
      this.exDin.SuspendLayout();
      this.exDout.Content.SuspendLayout();
      this.exDout.SuspendLayout();
      this.exAin.Content.SuspendLayout();
      this.exAin.SuspendLayout();
      this.exDoor.Content.SuspendLayout();
      this.exDoor.SuspendLayout();
      this.exUseSchedule.Content.SuspendLayout();
      this.exUseSchedule.SuspendLayout();
      this.exScheduler.Content.SuspendLayout();
      this.exScheduler.SuspendLayout();
      this.panel1.SuspendLayout();
      this.exEstActive.Content.SuspendLayout();
      this.exEstActive.SuspendLayout();
      this.exEstParams.Content.SuspendLayout();
      this.exEstParams.SuspendLayout();
      this.exLocation.Content.SuspendLayout();
      this.exLocation.SuspendLayout();
      this.exDbz.Content.SuspendLayout();
      this.exDbz.SuspendLayout();
      this.exDebounce.Content.SuspendLayout();
      this.exDebounce.SuspendLayout();
      this.exDebug.Content.SuspendLayout();
      this.exDebug.SuspendLayout();
      this.exRs485.Content.SuspendLayout();
      this.exRs485.SuspendLayout();
      this.exPing.Content.SuspendLayout();
      this.exPing.SuspendLayout();
      this.exPlanReboot.Content.SuspendLayout();
      this.exPlanReboot.SuspendLayout();
      this.exIec104Control.Content.SuspendLayout();
      this.exIec104Control.SuspendLayout();
      this.exLogsControl.Content.SuspendLayout();
      this.exLogsControl.SuspendLayout();
      this.SuspendLayout();
      // 
      // flp
      // 
      this.flp.AutoScroll = true;
      this.flp.Controls.Add(this.exDin);
      this.flp.Controls.Add(this.exDout);
      this.flp.Controls.Add(this.exAin);
      this.flp.Controls.Add(this.exDoor);
      this.flp.Controls.Add(this.exUseSchedule);
      this.flp.Controls.Add(this.exScheduler);
      this.flp.Controls.Add(this.exEstActive);
      this.flp.Controls.Add(this.exEstParams);
      this.flp.Controls.Add(this.exLocation);
      this.flp.Controls.Add(this.exDbz);
      this.flp.Controls.Add(this.exDebounce);
      this.flp.Controls.Add(this.exDebug);
      this.flp.Controls.Add(this.exRs485);
      this.flp.Controls.Add(this.exPing);
      this.flp.Controls.Add(this.exPlanReboot);
      this.flp.Controls.Add(this.exIec104Control);
      this.flp.Controls.Add(this.exLogsControl);
      this.flp.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.flp.Location = new System.Drawing.Point(0, 0);
      this.flp.Name = "flp";
      this.flp.Size = new System.Drawing.Size(547, 551);
      this.flp.TabIndex = 0;
      this.flp.WrapContents = false;
      // 
      // exDin
      // 
      this.exDin.BackColor = System.Drawing.Color.White;
      this.exDin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exDin.Content
      // 
      this.exDin.Content.Controls.Add(this.dinEditor);
      this.exDin.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exDin.Content.Location = new System.Drawing.Point(0, 26);
      this.exDin.Content.Name = "Content";
      this.exDin.Content.Size = new System.Drawing.Size(501, 64);
      this.exDin.Content.TabIndex = 1;
      this.exDin.Header = "Активность дискретных входов";
      this.exDin.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exDin.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exDin.IsExpanded = true;
      this.exDin.Location = new System.Drawing.Point(3, 3);
      this.exDin.Name = "exDin";
      this.exDin.Size = new System.Drawing.Size(503, 92);
      this.exDin.TabIndex = 0;
      // 
      // dinEditor
      // 
      this.dinEditor.Caption = "Дискретные входы";
      this.dinEditor.Location = new System.Drawing.Point(3, 3);
      this.dinEditor.MinimumSize = new System.Drawing.Size(392, 58);
      this.dinEditor.Name = "dinEditor";
      this.dinEditor.ReadOnly = false;
      this.dinEditor.Size = new System.Drawing.Size(392, 58);
      this.dinEditor.TabIndex = 0;
      this.dinEditor.Value = new bool[] {
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
      this.dinEditor.VisibleItemCount = 16;
      // 
      // exDout
      // 
      this.exDout.BackColor = System.Drawing.Color.White;
      this.exDout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exDout.Content
      // 
      this.exDout.Content.Controls.Add(this.doutEditor);
      this.exDout.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exDout.Content.Location = new System.Drawing.Point(0, 26);
      this.exDout.Content.Name = "Content";
      this.exDout.Content.Size = new System.Drawing.Size(501, 47);
      this.exDout.Content.TabIndex = 1;
      this.exDout.Header = "Активность дискретных выходов";
      this.exDout.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exDout.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exDout.IsExpanded = true;
      this.exDout.Location = new System.Drawing.Point(3, 101);
      this.exDout.Name = "exDout";
      this.exDout.Size = new System.Drawing.Size(503, 75);
      this.exDout.TabIndex = 1;
      // 
      // doutEditor
      // 
      this.doutEditor.Caption = "Дискретные выходы";
      this.doutEditor.Location = new System.Drawing.Point(3, 4);
      this.doutEditor.Name = "doutEditor";
      this.doutEditor.ReadOnly = false;
      this.doutEditor.Size = new System.Drawing.Size(392, 40);
      this.doutEditor.TabIndex = 0;
      this.doutEditor.Value = new bool[] {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false};
      this.doutEditor.VisibleItemCount = 8;
      // 
      // exAin
      // 
      this.exAin.BackColor = System.Drawing.Color.White;
      this.exAin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exAin.Content
      // 
      this.exAin.Content.Controls.Add(this.ainEditor);
      this.exAin.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exAin.Content.Location = new System.Drawing.Point(0, 26);
      this.exAin.Content.Name = "Content";
      this.exAin.Content.Size = new System.Drawing.Size(501, 47);
      this.exAin.Content.TabIndex = 1;
      this.exAin.Header = "Активность аналоговых входов";
      this.exAin.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exAin.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exAin.IsExpanded = true;
      this.exAin.Location = new System.Drawing.Point(3, 182);
      this.exAin.Name = "exAin";
      this.exAin.Size = new System.Drawing.Size(503, 75);
      this.exAin.TabIndex = 2;
      // 
      // ainEditor
      // 
      this.ainEditor.Caption = "Аналоговые входы";
      this.ainEditor.Location = new System.Drawing.Point(3, 7);
      this.ainEditor.Name = "ainEditor";
      this.ainEditor.ReadOnly = false;
      this.ainEditor.Size = new System.Drawing.Size(392, 37);
      this.ainEditor.TabIndex = 0;
      this.ainEditor.Value = new bool[] {
        false,
        false,
        false,
        false};
      this.ainEditor.VisibleItemCount = 4;
      // 
      // exDoor
      // 
      this.exDoor.BackColor = System.Drawing.Color.White;
      this.exDoor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exDoor.Content
      // 
      this.exDoor.Content.Controls.Add(this.doorEditor);
      this.exDoor.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exDoor.Content.Location = new System.Drawing.Point(0, 26);
      this.exDoor.Content.Name = "Content";
      this.exDoor.Content.Size = new System.Drawing.Size(501, 64);
      this.exDoor.Content.TabIndex = 1;
      this.exDoor.Header = "Активность каналов контроля дверей";
      this.exDoor.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exDoor.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exDoor.IsExpanded = true;
      this.exDoor.Location = new System.Drawing.Point(3, 263);
      this.exDoor.Name = "exDoor";
      this.exDoor.Size = new System.Drawing.Size(503, 92);
      this.exDoor.TabIndex = 12;
      // 
      // doorEditor
      // 
      this.doorEditor.Caption = "Контроль дверей";
      this.doorEditor.Location = new System.Drawing.Point(3, 5);
      this.doorEditor.MinimumSize = new System.Drawing.Size(392, 58);
      this.doorEditor.Name = "doorEditor";
      this.doorEditor.ReadOnly = false;
      this.doorEditor.Size = new System.Drawing.Size(392, 58);
      this.doorEditor.TabIndex = 0;
      this.doorEditor.Value = new bool[] {
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
      this.doorEditor.VisibleItemCount = 16;
      // 
      // exUseSchedule
      // 
      this.exUseSchedule.BackColor = System.Drawing.Color.White;
      this.exUseSchedule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exUseSchedule.Content
      // 
      this.exUseSchedule.Content.Controls.Add(this.useSchedulerEditor);
      this.exUseSchedule.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exUseSchedule.Content.Location = new System.Drawing.Point(0, 26);
      this.exUseSchedule.Content.Name = "Content";
      this.exUseSchedule.Content.Size = new System.Drawing.Size(501, 27);
      this.exUseSchedule.Content.TabIndex = 1;
      this.exUseSchedule.Header = "Активность планов освещения";
      this.exUseSchedule.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exUseSchedule.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exUseSchedule.IsExpanded = true;
      this.exUseSchedule.Location = new System.Drawing.Point(3, 361);
      this.exUseSchedule.Name = "exUseSchedule";
      this.exUseSchedule.Size = new System.Drawing.Size(503, 55);
      this.exUseSchedule.TabIndex = 3;
      // 
      // useSchedulerEditor
      // 
      this.useSchedulerEditor.Location = new System.Drawing.Point(3, 6);
      this.useSchedulerEditor.Name = "useSchedulerEditor";
      this.useSchedulerEditor.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.useSchedulerEditor.Size = new System.Drawing.Size(463, 18);
      this.useSchedulerEditor.TabIndex = 0;
      this.useSchedulerEditor.UseScheduler = false;
      // 
      // exScheduler
      // 
      this.exScheduler.BackColor = System.Drawing.Color.White;
      this.exScheduler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exScheduler.Content
      // 
      this.exScheduler.Content.Controls.Add(this.wb);
      this.exScheduler.Content.Controls.Add(this.panel1);
      this.exScheduler.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exScheduler.Content.Location = new System.Drawing.Point(0, 26);
      this.exScheduler.Content.Name = "Content";
      this.exScheduler.Content.Size = new System.Drawing.Size(501, 132);
      this.exScheduler.Content.TabIndex = 1;
      this.exScheduler.Header = "План освещения";
      this.exScheduler.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exScheduler.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exScheduler.IsExpanded = true;
      this.exScheduler.Location = new System.Drawing.Point(3, 422);
      this.exScheduler.Name = "exScheduler";
      this.exScheduler.Size = new System.Drawing.Size(503, 160);
      this.exScheduler.TabIndex = 10;
      // 
      // wb
      // 
      this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
      this.wb.Location = new System.Drawing.Point(0, 29);
      this.wb.MinimumSize = new System.Drawing.Size(20, 20);
      this.wb.Name = "wb";
      this.wb.Size = new System.Drawing.Size(501, 103);
      this.wb.TabIndex = 1;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnSelectLightPlan);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(501, 29);
      this.panel1.TabIndex = 0;
      // 
      // btnSelectLightPlan
      // 
      this.btnSelectLightPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSelectLightPlan.Location = new System.Drawing.Point(423, 3);
      this.btnSelectLightPlan.Name = "btnSelectLightPlan";
      this.btnSelectLightPlan.Size = new System.Drawing.Size(75, 23);
      this.btnSelectLightPlan.TabIndex = 0;
      this.btnSelectLightPlan.Text = "Выбрать";
      this.btnSelectLightPlan.UseVisualStyleBackColor = true;
      this.btnSelectLightPlan.Click += new System.EventHandler(this.btnSelectLightPlan_Click);
      // 
      // exEstActive
      // 
      this.exEstActive.BackColor = System.Drawing.Color.White;
      this.exEstActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exEstActive.Content
      // 
      this.exEstActive.Content.Controls.Add(this.cbEstActive);
      this.exEstActive.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exEstActive.Content.Location = new System.Drawing.Point(0, 26);
      this.exEstActive.Content.Name = "Content";
      this.exEstActive.Content.Size = new System.Drawing.Size(501, 27);
      this.exEstActive.Content.TabIndex = 1;
      this.exEstActive.Header = "Активность EST Tools";
      this.exEstActive.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exEstActive.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exEstActive.IsExpanded = true;
      this.exEstActive.Location = new System.Drawing.Point(3, 588);
      this.exEstActive.Name = "exEstActive";
      this.exEstActive.Size = new System.Drawing.Size(503, 55);
      this.exEstActive.TabIndex = 4;
      // 
      // cbEstActive
      // 
      this.cbEstActive.AutoSize = true;
      this.cbEstActive.Dock = System.Windows.Forms.DockStyle.Top;
      this.cbEstActive.Location = new System.Drawing.Point(0, 0);
      this.cbEstActive.Name = "cbEstActive";
      this.cbEstActive.Padding = new System.Windows.Forms.Padding(5, 4, 0, 0);
      this.cbEstActive.Size = new System.Drawing.Size(501, 21);
      this.cbEstActive.TabIndex = 3;
      this.cbEstActive.Text = "Использовать EST Tools";
      this.cbEstActive.UseVisualStyleBackColor = true;
      // 
      // exEstParams
      // 
      this.exEstParams.BackColor = System.Drawing.Color.White;
      this.exEstParams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exEstParams.Content
      // 
      this.exEstParams.Content.Controls.Add(this.itEstTsend);
      this.exEstParams.Content.Controls.Add(this.itEstPort);
      this.exEstParams.Content.Controls.Add(this.itEstAddress);
      this.exEstParams.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exEstParams.Content.Location = new System.Drawing.Point(0, 26);
      this.exEstParams.Content.Name = "Content";
      this.exEstParams.Content.Size = new System.Drawing.Size(501, 82);
      this.exEstParams.Content.TabIndex = 1;
      this.exEstParams.Header = "Параметры EST Tools";
      this.exEstParams.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exEstParams.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exEstParams.IsExpanded = true;
      this.exEstParams.Location = new System.Drawing.Point(3, 649);
      this.exEstParams.Name = "exEstParams";
      this.exEstParams.Size = new System.Drawing.Size(503, 110);
      this.exEstParams.TabIndex = 5;
      // 
      // itEstTsend
      // 
      this.itEstTsend.Caption = "Интервал отправки пустого пакета (сек)";
      this.itEstTsend.CaptionWidth = 150;
      this.itEstTsend.DecimalPlaces = 0;
      this.itEstTsend.Dock = System.Windows.Forms.DockStyle.Top;
      this.itEstTsend.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.itEstTsend.Location = new System.Drawing.Point(0, 52);
      this.itEstTsend.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
      this.itEstTsend.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
      this.itEstTsend.Name = "itEstTsend";
      this.itEstTsend.ReadOnly = false;
      this.itEstTsend.Size = new System.Drawing.Size(501, 26);
      this.itEstTsend.TabIndex = 5;
      this.itEstTsend.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
      // 
      // itEstPort
      // 
      this.itEstPort.Caption = "Порт";
      this.itEstPort.CaptionWidth = 150;
      this.itEstPort.DecimalPlaces = 0;
      this.itEstPort.Dock = System.Windows.Forms.DockStyle.Top;
      this.itEstPort.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.itEstPort.Location = new System.Drawing.Point(0, 26);
      this.itEstPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.itEstPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
      this.itEstPort.Name = "itEstPort";
      this.itEstPort.ReadOnly = false;
      this.itEstPort.Size = new System.Drawing.Size(501, 26);
      this.itEstPort.TabIndex = 4;
      this.itEstPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
      // 
      // itEstAddress
      // 
      this.itEstAddress.Caption = "IP Адрес";
      this.itEstAddress.CaptionWidth = 150;
      this.itEstAddress.Dock = System.Windows.Forms.DockStyle.Top;
      this.itEstAddress.Location = new System.Drawing.Point(0, 0);
      this.itEstAddress.Name = "itEstAddress";
      this.itEstAddress.PasswordChar = '\0';
      this.itEstAddress.ReadOnly = false;
      this.itEstAddress.Size = new System.Drawing.Size(501, 26);
      this.itEstAddress.TabIndex = 3;
      this.itEstAddress.Value = "";
      // 
      // exLocation
      // 
      this.exLocation.BackColor = System.Drawing.Color.White;
      this.exLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exLocation.Content
      // 
      this.exLocation.Content.Controls.Add(this.inputTimeZone);
      this.exLocation.Content.Controls.Add(this.idLongitude);
      this.exLocation.Content.Controls.Add(this.idLatitude);
      this.exLocation.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exLocation.Content.Location = new System.Drawing.Point(0, 26);
      this.exLocation.Content.Name = "Content";
      this.exLocation.Content.Size = new System.Drawing.Size(501, 82);
      this.exLocation.Content.TabIndex = 1;
      this.exLocation.Header = "Расположение";
      this.exLocation.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exLocation.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exLocation.IsExpanded = true;
      this.exLocation.Location = new System.Drawing.Point(3, 765);
      this.exLocation.Name = "exLocation";
      this.exLocation.Size = new System.Drawing.Size(503, 110);
      this.exLocation.TabIndex = 6;
      // 
      // inputTimeZone
      // 
      this.inputTimeZone.Caption = "Часовой пояс";
      this.inputTimeZone.CaptionWidth = 150;
      this.inputTimeZone.Dock = System.Windows.Forms.DockStyle.Top;
      this.inputTimeZone.Location = new System.Drawing.Point(0, 52);
      this.inputTimeZone.Name = "inputTimeZone";
      this.inputTimeZone.Size = new System.Drawing.Size(501, 26);
      this.inputTimeZone.TabIndex = 2;
      this.inputTimeZone.Value = ((sbyte)(-12));
      // 
      // idLongitude
      // 
      this.idLongitude.Caption = "Долгота";
      this.idLongitude.CaptionWidth = 150;
      this.idLongitude.DecimalPlaces = 3;
      this.idLongitude.Dock = System.Windows.Forms.DockStyle.Top;
      this.idLongitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idLongitude.Location = new System.Drawing.Point(0, 26);
      this.idLongitude.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
      this.idLongitude.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
      this.idLongitude.Name = "idLongitude";
      this.idLongitude.ReadOnly = false;
      this.idLongitude.Size = new System.Drawing.Size(501, 26);
      this.idLongitude.TabIndex = 4;
      this.idLongitude.Tag = "";
      this.idLongitude.Value = new decimal(new int[] {
            30125326,
            0,
            0,
            393216});
      // 
      // idLatitude
      // 
      this.idLatitude.Caption = "Широта";
      this.idLatitude.CaptionWidth = 150;
      this.idLatitude.DecimalPlaces = 3;
      this.idLatitude.Dock = System.Windows.Forms.DockStyle.Top;
      this.idLatitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idLatitude.Location = new System.Drawing.Point(0, 0);
      this.idLatitude.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
      this.idLatitude.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
      this.idLatitude.Name = "idLatitude";
      this.idLatitude.ReadOnly = false;
      this.idLatitude.Size = new System.Drawing.Size(501, 26);
      this.idLatitude.TabIndex = 3;
      this.idLatitude.Value = new decimal(new int[] {
            55191097,
            0,
            0,
            393216});
      // 
      // exDbz
      // 
      this.exDbz.BackColor = System.Drawing.Color.White;
      this.exDbz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exDbz.Content
      // 
      this.exDbz.Content.Controls.Add(this.idDbz);
      this.exDbz.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exDbz.Content.Location = new System.Drawing.Point(0, 26);
      this.exDbz.Content.Name = "Content";
      this.exDbz.Content.Size = new System.Drawing.Size(501, 32);
      this.exDbz.Content.TabIndex = 1;
      this.exDbz.Header = "Зона нечувствительности";
      this.exDbz.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exDbz.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exDbz.IsExpanded = true;
      this.exDbz.Location = new System.Drawing.Point(3, 881);
      this.exDbz.Name = "exDbz";
      this.exDbz.Size = new System.Drawing.Size(503, 60);
      this.exDbz.TabIndex = 7;
      // 
      // idDbz
      // 
      this.idDbz.Caption = "Зона нечувствительности аналоговых входов (%)";
      this.idDbz.CaptionWidth = 150;
      this.idDbz.DecimalPlaces = 0;
      this.idDbz.Dock = System.Windows.Forms.DockStyle.Top;
      this.idDbz.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idDbz.Location = new System.Drawing.Point(0, 0);
      this.idDbz.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.idDbz.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idDbz.Name = "idDbz";
      this.idDbz.ReadOnly = false;
      this.idDbz.Size = new System.Drawing.Size(501, 26);
      this.idDbz.TabIndex = 2;
      this.idDbz.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // exDebounce
      // 
      this.exDebounce.BackColor = System.Drawing.Color.White;
      this.exDebounce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exDebounce.Content
      // 
      this.exDebounce.Content.Controls.Add(this.itDebounce);
      this.exDebounce.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exDebounce.Content.Location = new System.Drawing.Point(0, 26);
      this.exDebounce.Content.Name = "Content";
      this.exDebounce.Content.Size = new System.Drawing.Size(501, 30);
      this.exDebounce.Content.TabIndex = 1;
      this.exDebounce.Header = "Дребезг";
      this.exDebounce.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exDebounce.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exDebounce.IsExpanded = true;
      this.exDebounce.Location = new System.Drawing.Point(3, 947);
      this.exDebounce.Name = "exDebounce";
      this.exDebounce.Size = new System.Drawing.Size(503, 58);
      this.exDebounce.TabIndex = 8;
      // 
      // itDebounce
      // 
      this.itDebounce.Caption = "Интервал дребезга (мсек)";
      this.itDebounce.CaptionWidth = 150;
      this.itDebounce.DecimalPlaces = 0;
      this.itDebounce.Dock = System.Windows.Forms.DockStyle.Top;
      this.itDebounce.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.itDebounce.Location = new System.Drawing.Point(0, 0);
      this.itDebounce.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.itDebounce.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.itDebounce.Name = "itDebounce";
      this.itDebounce.ReadOnly = false;
      this.itDebounce.Size = new System.Drawing.Size(501, 26);
      this.itDebounce.TabIndex = 3;
      this.itDebounce.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // exDebug
      // 
      this.exDebug.BackColor = System.Drawing.Color.White;
      this.exDebug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exDebug.Content
      // 
      this.exDebug.Content.Controls.Add(this.cbDebug);
      this.exDebug.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exDebug.Content.Location = new System.Drawing.Point(0, 26);
      this.exDebug.Content.Name = "Content";
      this.exDebug.Content.Size = new System.Drawing.Size(501, 27);
      this.exDebug.Content.TabIndex = 1;
      this.exDebug.Header = "Отладка";
      this.exDebug.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exDebug.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exDebug.IsExpanded = true;
      this.exDebug.Location = new System.Drawing.Point(3, 1011);
      this.exDebug.Name = "exDebug";
      this.exDebug.Size = new System.Drawing.Size(503, 55);
      this.exDebug.TabIndex = 9;
      // 
      // cbDebug
      // 
      this.cbDebug.AutoSize = true;
      this.cbDebug.Dock = System.Windows.Forms.DockStyle.Top;
      this.cbDebug.Location = new System.Drawing.Point(0, 0);
      this.cbDebug.Name = "cbDebug";
      this.cbDebug.Padding = new System.Windows.Forms.Padding(5, 4, 0, 0);
      this.cbDebug.Size = new System.Drawing.Size(501, 21);
      this.cbDebug.TabIndex = 4;
      this.cbDebug.Text = "Включить отладку";
      this.cbDebug.UseVisualStyleBackColor = true;
      // 
      // exRs485
      // 
      this.exRs485.BackColor = System.Drawing.Color.White;
      this.exRs485.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exRs485.Content
      // 
      this.exRs485.Content.Controls.Add(this.comPortSettingsEditor);
      this.exRs485.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exRs485.Content.Location = new System.Drawing.Point(0, 26);
      this.exRs485.Content.Name = "Content";
      this.exRs485.Content.Size = new System.Drawing.Size(501, 110);
      this.exRs485.Content.TabIndex = 1;
      this.exRs485.Header = "RS485";
      this.exRs485.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exRs485.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exRs485.IsExpanded = true;
      this.exRs485.Location = new System.Drawing.Point(3, 1072);
      this.exRs485.Name = "exRs485";
      this.exRs485.Size = new System.Drawing.Size(503, 138);
      this.exRs485.TabIndex = 11;
      // 
      // comPortSettingsEditor
      // 
      this.comPortSettingsEditor.EnabledBaudrates = true;
      this.comPortSettingsEditor.EnabledDataBits = true;
      this.comPortSettingsEditor.EnabledHandshake = true;
      this.comPortSettingsEditor.EnabledParity = true;
      this.comPortSettingsEditor.EnabledPortName = true;
      this.comPortSettingsEditor.EnabledStopBits = true;
      this.comPortSettingsEditor.Location = new System.Drawing.Point(3, 3);
      this.comPortSettingsEditor.Name = "comPortSettingsEditor";
      this.comPortSettingsEditor.ShowHandshake = false;
      this.comPortSettingsEditor.ShowPortName = false;
      this.comPortSettingsEditor.ShowTimeout = false;
      this.comPortSettingsEditor.Size = new System.Drawing.Size(495, 108);
      this.comPortSettingsEditor.TabIndex = 0;
      comPortSettings1.BaudRate = 9600;
      comPortSettings1.DataBits = ((byte)(8));
      comPortSettings1.Handshake = Ztp.Port.ComPort.Handshake.None;
      comPortSettings1.Kind = Ztp.Port.PortKind.Com;
      comPortSettings1.Parity = Ztp.Port.ComPort.Parity.None;
      comPortSettings1.PortName = "COM1";
      comPortSettings1.StopBits = Ztp.Port.ComPort.StopBits.One;
      comPortSettings1.Timeout = 5000;
      this.comPortSettingsEditor.Value = comPortSettings1;
      // 
      // exPing
      // 
      this.exPing.BackColor = System.Drawing.Color.White;
      this.exPing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exPing.Content
      // 
      this.exPing.Content.Controls.Add(this.pingEditorControl1);
      this.exPing.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exPing.Content.Location = new System.Drawing.Point(0, 26);
      this.exPing.Content.Name = "Content";
      this.exPing.Content.Size = new System.Drawing.Size(501, 132);
      this.exPing.Content.TabIndex = 1;
      this.exPing.Header = "Пингование";
      this.exPing.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exPing.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exPing.IsExpanded = true;
      this.exPing.Location = new System.Drawing.Point(3, 1216);
      this.exPing.Name = "exPing";
      this.exPing.Size = new System.Drawing.Size(503, 160);
      this.exPing.TabIndex = 16;
      // 
      // pingEditorControl1
      // 
      this.pingEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pingEditorControl1.Ip = "";
      this.pingEditorControl1.IsValidOk = false;
      this.pingEditorControl1.Location = new System.Drawing.Point(0, 0);
      this.pingEditorControl1.Name = "pingEditorControl1";
      this.pingEditorControl1.Padding = new System.Windows.Forms.Padding(5);
      this.pingEditorControl1.Period = ((byte)(1));
      this.pingEditorControl1.Size = new System.Drawing.Size(501, 132);
      this.pingEditorControl1.TabIndex = 0;
      // 
      // exPlanReboot
      // 
      this.exPlanReboot.BackColor = System.Drawing.Color.White;
      this.exPlanReboot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exPlanReboot.Content
      // 
      this.exPlanReboot.Content.Controls.Add(this.planResetControl1);
      this.exPlanReboot.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exPlanReboot.Content.Location = new System.Drawing.Point(0, 26);
      this.exPlanReboot.Content.Name = "Content";
      this.exPlanReboot.Content.Size = new System.Drawing.Size(501, 81);
      this.exPlanReboot.Content.TabIndex = 1;
      this.exPlanReboot.Header = "Плановый перезапуск";
      this.exPlanReboot.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exPlanReboot.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exPlanReboot.IsExpanded = true;
      this.exPlanReboot.Location = new System.Drawing.Point(3, 1382);
      this.exPlanReboot.Name = "exPlanReboot";
      this.exPlanReboot.Size = new System.Drawing.Size(503, 109);
      this.exPlanReboot.TabIndex = 13;
      // 
      // planResetControl1
      // 
      this.planResetControl1.Active = false;
      this.planResetControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.planResetControl1.Location = new System.Drawing.Point(0, 0);
      this.planResetControl1.Name = "planResetControl1";
      this.planResetControl1.Padding = new System.Windows.Forms.Padding(5);
      this.planResetControl1.Size = new System.Drawing.Size(501, 81);
      this.planResetControl1.TabIndex = 0;
      this.planResetControl1.Value = "";
      // 
      // exIec104Control
      // 
      this.exIec104Control.BackColor = System.Drawing.Color.White;
      this.exIec104Control.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exIec104Control.Content
      // 
      this.exIec104Control.Content.Controls.Add(this.iec104EditorControl);
      this.exIec104Control.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exIec104Control.Content.Location = new System.Drawing.Point(0, 26);
      this.exIec104Control.Content.Name = "Content";
      this.exIec104Control.Content.Size = new System.Drawing.Size(501, 87);
      this.exIec104Control.Content.TabIndex = 1;
      this.exIec104Control.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exIec104Control.Header = "Мэк104";
      this.exIec104Control.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exIec104Control.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exIec104Control.IsExpanded = true;
      this.exIec104Control.Location = new System.Drawing.Point(3, 1497);
      this.exIec104Control.Name = "exIec104Control";
      this.exIec104Control.Size = new System.Drawing.Size(503, 115);
      this.exIec104Control.TabIndex = 14;
      // 
      // iec104EditorControl
      // 
      this.iec104EditorControl.Location = new System.Drawing.Point(3, 2);
      this.iec104EditorControl.Name = "iec104EditorControl";
      this.iec104EditorControl.qValue = ((ushort)(3080));
      this.iec104EditorControl.Size = new System.Drawing.Size(499, 86);
      this.iec104EditorControl.TabIndex = 0;
      this.iec104EditorControl.TimeValue = "15;10;20;1";
      // 
      // exLogsControl
      // 
      this.exLogsControl.BackColor = System.Drawing.Color.White;
      this.exLogsControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      // 
      // exLogsControl.Content
      // 
      this.exLogsControl.Content.Controls.Add(this.lscLogs);
      this.exLogsControl.Content.Dock = System.Windows.Forms.DockStyle.Fill;
      this.exLogsControl.Content.Location = new System.Drawing.Point(0, 26);
      this.exLogsControl.Content.Name = "Content";
      this.exLogsControl.Content.Size = new System.Drawing.Size(501, 76);
      this.exLogsControl.Content.TabIndex = 1;
      this.exLogsControl.Header = "Логирование";
      this.exLogsControl.HeaderBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.exLogsControl.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.exLogsControl.IsExpanded = true;
      this.exLogsControl.Location = new System.Drawing.Point(3, 1618);
      this.exLogsControl.Name = "exLogsControl";
      this.exLogsControl.Size = new System.Drawing.Size(503, 104);
      this.exLogsControl.TabIndex = 15;
      // 
      // lscLogs
      // 
      this.lscLogs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lscLogs.Location = new System.Drawing.Point(0, 0);
      this.lscLogs.LogLevel = ((byte)(5));
      this.lscLogs.Name = "lscLogs";
      this.lscLogs.Size = new System.Drawing.Size(501, 76);
      this.lscLogs.TabIndex = 0;
      // 
      // PartitionConfigEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScrollMargin = new System.Drawing.Size(3, 3);
      this.Controls.Add(this.flp);
      this.Name = "PartitionConfigEditorControl";
      this.Size = new System.Drawing.Size(547, 551);
      this.flp.ResumeLayout(false);
      this.exDin.Content.ResumeLayout(false);
      this.exDin.ResumeLayout(false);
      this.exDout.Content.ResumeLayout(false);
      this.exDout.ResumeLayout(false);
      this.exAin.Content.ResumeLayout(false);
      this.exAin.ResumeLayout(false);
      this.exDoor.Content.ResumeLayout(false);
      this.exDoor.ResumeLayout(false);
      this.exUseSchedule.Content.ResumeLayout(false);
      this.exUseSchedule.ResumeLayout(false);
      this.exScheduler.Content.ResumeLayout(false);
      this.exScheduler.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.exEstActive.Content.ResumeLayout(false);
      this.exEstActive.Content.PerformLayout();
      this.exEstActive.ResumeLayout(false);
      this.exEstParams.Content.ResumeLayout(false);
      this.exEstParams.ResumeLayout(false);
      this.exLocation.Content.ResumeLayout(false);
      this.exLocation.ResumeLayout(false);
      this.exDbz.Content.ResumeLayout(false);
      this.exDbz.ResumeLayout(false);
      this.exDebounce.Content.ResumeLayout(false);
      this.exDebounce.ResumeLayout(false);
      this.exDebug.Content.ResumeLayout(false);
      this.exDebug.Content.PerformLayout();
      this.exDebug.ResumeLayout(false);
      this.exRs485.Content.ResumeLayout(false);
      this.exRs485.ResumeLayout(false);
      this.exPing.Content.ResumeLayout(false);
      this.exPing.ResumeLayout(false);
      this.exPlanReboot.Content.ResumeLayout(false);
      this.exPlanReboot.ResumeLayout(false);
      this.exIec104Control.Content.ResumeLayout(false);
      this.exIec104Control.ResumeLayout(false);
      this.exLogsControl.Content.ResumeLayout(false);
      this.exLogsControl.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.FlowLayoutPanel flp;
    private Ztp.Ui.ExpanderControl exDin;
    private Ztp.Ui.ExpanderControl exDout;
    private Ztp.Ui.DoutEditorControl doutEditor;
    private Ztp.Ui.ExpanderControl exAin;
    private Ztp.Ui.AinEditorControl ainEditor;
    private Ztp.Ui.ExpanderControl exUseSchedule;
    private Ztp.Ui.UseSchedulerControl useSchedulerEditor;
    private Ztp.Ui.ExpanderControl exEstActive;
    private System.Windows.Forms.CheckBox cbEstActive;
    private Ztp.Ui.ExpanderControl exEstParams;
    private Ztp.Ui.InputDoubleControl itEstTsend;
    private Ztp.Ui.InputDoubleControl itEstPort;
    private Ztp.Ui.InputTextControl itEstAddress;
    private Ztp.Ui.ExpanderControl exLocation;
    private Ztp.Ui.InputTimeZoneControl inputTimeZone;
    private Ztp.Ui.InputDoubleControl idLongitude;
    private Ztp.Ui.InputDoubleControl idLatitude;
    private Ztp.Ui.DinEditorControl dinEditor;
    private Ztp.Ui.ExpanderControl exDbz;
    private Ztp.Ui.InputDoubleControl idDbz;
    private Ztp.Ui.ExpanderControl exDebounce;
    private Ztp.Ui.InputDoubleControl itDebounce;
    private Ztp.Ui.ExpanderControl exDebug;
    private System.Windows.Forms.CheckBox cbDebug;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnSelectLightPlan;
    private Ztp.Ui.ExpanderControl exRs485;
    private Ztp.Ui.ComPortSettingsEditorControl comPortSettingsEditor;
    private Ztp.Ui.ExpanderControl exDoor;
    private Ztp.Ui.DinEditorControl doorEditor;
    private Ztp.Ui.ExpanderControl exPlanReboot;
    private Ztp.Ui.PlanResetControl planResetControl1;
    private Ztp.Ui.ExpanderControl exIec104Control;
    private Ztp.Ui.Iec104EditorControl iec104EditorControl;
    private Ztp.Ui.ExpanderControl exLogsControl;
        public Ztp.Ui.LogsStateControl lscLogs;
        private Ztp.Ui.ExpanderControl exScheduler;
        private System.Windows.Forms.WebBrowser wb;
        private Ztp.Ui.ExpanderControl exPing;
        private Ztp.Ui.PingEditorControl pingEditorControl1;
    }
}
