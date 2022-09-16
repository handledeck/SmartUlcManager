using Ztp.Configuration;

namespace Ztp
{
  partial class MainForm
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

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      Ztp.Configuration.ZtpConfig ztpConfig1 = new Ztp.Configuration.ZtpConfig();
      Ztp.Port.ComPort.ComPortSettings comPortSettings1 = new Ztp.Port.ComPort.ComPortSettings();
      Ztp.Configuration.ZtpLight ztpLight1 = new Ztp.Configuration.ZtpLight();
      Ztp.Configuration.ZtpScheduler ztpScheduler1 = new Ztp.Configuration.ZtpScheduler();
      Ztp.Configuration.ZtpLight ztpLight2 = new Ztp.Configuration.ZtpLight();
      Ztp.Configuration.ZtpScheduler ztpScheduler2 = new Ztp.Configuration.ZtpScheduler();
      Ztp.Ui.LocationEditorControl.ZtpLocation ztpLocation1 = new Ztp.Ui.LocationEditorControl.ZtpLocation();
      Ztp.Port.ComPort.ComPortSettings comPortSettings2 = new Ztp.Port.ComPort.ComPortSettings();
      this.iml = new System.Windows.Forms.ImageList(this.components);
      this.ofd = new System.Windows.Forms.OpenFileDialog();
      this.sfd = new System.Windows.Forms.SaveFileDialog();
      this.hint = new System.Windows.Forms.ToolTip(this.components);
      this.bw = new System.ComponentModel.BackgroundWorker();
      this.ribbon = new System.Windows.Forms.Ribbon();
      this.rmiOpenFile = new System.Windows.Forms.RibbonOrbMenuItem();
      this.rmiFileSave = new System.Windows.Forms.RibbonOrbMenuItem();
      this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
      this.rmiAbout = new System.Windows.Forms.RibbonOrbMenuItem();
      this.rmiFileExit = new System.Windows.Forms.RibbonButton();
      this.ribbonOrbRecentItem1 = new System.Windows.Forms.RibbonOrbRecentItem();
      this.rbQuickOpen = new System.Windows.Forms.RibbonButton();
      this.rbQuickSave = new System.Windows.Forms.RibbonButton();
      this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
      this.rbAbout = new System.Windows.Forms.RibbonButton();
      this.rtConfiguration = new System.Windows.Forms.RibbonTab();
      this.rpPort = new System.Windows.Forms.RibbonPanel();
      this.rbOpenClose = new System.Windows.Forms.RibbonButton();
      this.rbRead = new System.Windows.Forms.RibbonButton();
      this.rbWrite = new System.Windows.Forms.RibbonButton();
      this.rbReboot = new System.Windows.Forms.RibbonButton();
      this.rbChangePwd = new System.Windows.Forms.RibbonButton();
      this.rbLight = new System.Windows.Forms.RibbonButton();
      this.rbBrightToggle = new System.Windows.Forms.RibbonButton();
      this.rpSeason = new System.Windows.Forms.RibbonPanel();
      this.rbAddSeason = new System.Windows.Forms.RibbonButton();
      this.rbDeleteSeason = new System.Windows.Forms.RibbonButton();
      this.rbEditSeason = new System.Windows.Forms.RibbonButton();
      this.rpSchedule = new System.Windows.Forms.RibbonPanel();
      this.rbAddSchedule = new System.Windows.Forms.RibbonButton();
      this.rbDeleteSchedule = new System.Windows.Forms.RibbonButton();
      this.rbEditSchedule = new System.Windows.Forms.RibbonButton();
      this.rbShowSched = new System.Windows.Forms.RibbonButton();
      this.rpFota = new System.Windows.Forms.RibbonPanel();
      this.rbFota = new System.Windows.Forms.RibbonButton();
      this.rpUpFile = new System.Windows.Forms.RibbonPanel();
      this.rbUpFile = new System.Windows.Forms.RibbonButton();
      this.rtView = new System.Windows.Forms.RibbonTab();
      this.rpView = new System.Windows.Forms.RibbonPanel();
      this.rbViewDebug = new System.Windows.Forms.RibbonButton();
      this.rbViewState = new System.Windows.Forms.RibbonButton();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.sslPort = new System.Windows.Forms.ToolStripStatusLabel();
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.splitContainerState = new System.Windows.Forms.SplitContainer();
      this.tcConfig = new System.Windows.Forms.TabControl();
      this.tpConfigGen = new System.Windows.Forms.TabPage();
      this.panel = new System.Windows.Forms.Panel();
      this.configEditor = new Ztp.Ui.ConfigEditorControl();
      this.tpConfigSched = new System.Windows.Forms.TabPage();
      this.planEditor = new Ztp.Ui.LightPlanEditorControl();
      this.tpRs485 = new System.Windows.Forms.TabPage();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label3 = new System.Windows.Forms.Label();
      this.modbusItemListControl1 = new Ztp.Ui.ModbusItemListControl();
      this.modBusEditor = new Ztp.Ui.ModBusSettingsEditorControl();
      this.comPortEditor = new Ztp.Ui.ComPortSettingsEditorControl();
      this.imlTc = new System.Windows.Forms.ImageList(this.components);
      this.currentStateView = new Ztp.Ui.CurrentStateViewControl();
      this.label2 = new System.Windows.Forms.Label();
      this.logConsole = new Ztp.Ui.UiLogConsoleControl();
      this.label1 = new System.Windows.Forms.Label();
      this.statusStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerState)).BeginInit();
      this.splitContainerState.Panel1.SuspendLayout();
      this.splitContainerState.Panel2.SuspendLayout();
      this.splitContainerState.SuspendLayout();
      this.tcConfig.SuspendLayout();
      this.tpConfigGen.SuspendLayout();
      this.panel.SuspendLayout();
      this.tpConfigSched.SuspendLayout();
      this.tpRs485.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // iml
      // 
      this.iml.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml.ImageStream")));
      this.iml.TransparentColor = System.Drawing.Color.White;
      this.iml.Images.SetKeyName(0, "folder_page.png");
      this.iml.Images.SetKeyName(1, "save_as.png");
      this.iml.Images.SetKeyName(2, "PCI-card_add.png");
      this.iml.Images.SetKeyName(3, "PCI-card_view.png");
      this.iml.Images.SetKeyName(4, "recycle.png");
      this.iml.Images.SetKeyName(5, "box_closed.png");
      this.iml.Images.SetKeyName(6, "box_open.png");
      // 
      // bw
      // 
      this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
      this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
      // 
      // ribbon
      // 
      this.ribbon.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.ribbon.Location = new System.Drawing.Point(0, 0);
      this.ribbon.Minimized = false;
      this.ribbon.Name = "ribbon";
      // 
      // 
      // 
      this.ribbon.OrbDropDown.BorderRoundness = 8;
      this.ribbon.OrbDropDown.Location = new System.Drawing.Point(0, 0);
      this.ribbon.OrbDropDown.MenuItems.Add(this.rmiOpenFile);
      this.ribbon.OrbDropDown.MenuItems.Add(this.rmiFileSave);
      this.ribbon.OrbDropDown.MenuItems.Add(this.ribbonSeparator1);
      this.ribbon.OrbDropDown.MenuItems.Add(this.rmiAbout);
      this.ribbon.OrbDropDown.Name = "";
      this.ribbon.OrbDropDown.OptionItems.Add(this.rmiFileExit);
      this.ribbon.OrbDropDown.RecentItems.Add(this.ribbonOrbRecentItem1);
      this.ribbon.OrbDropDown.RecentItemsCaption = "Последние файлы";
      this.ribbon.OrbDropDown.Size = new System.Drawing.Size(527, 207);
      this.ribbon.OrbDropDown.TabIndex = 0;
      this.ribbon.OrbImage = null;
      this.ribbon.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
      this.ribbon.OrbText = "ФАЙЛ";
      // 
      // 
      // 
      this.ribbon.QuickAcessToolbar.DropDownButtonVisible = false;
      this.ribbon.QuickAcessToolbar.Items.Add(this.rbQuickOpen);
      this.ribbon.QuickAcessToolbar.Items.Add(this.rbQuickSave);
      this.ribbon.QuickAcessToolbar.Items.Add(this.ribbonButton1);
      this.ribbon.QuickAcessToolbar.Items.Add(this.rbAbout);
      this.ribbon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
      this.ribbon.Size = new System.Drawing.Size(1239, 151);
      this.ribbon.TabIndex = 3;
      this.ribbon.Tabs.Add(this.rtConfiguration);
      this.ribbon.Tabs.Add(this.rtView);
      this.ribbon.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
      this.ribbon.Text = "ribbon1";
      this.ribbon.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
      // 
      // rmiOpenFile
      // 
      this.rmiOpenFile.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
      this.rmiOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("rmiOpenFile.Image")));
      this.rmiOpenFile.SmallImage = ((System.Drawing.Image)(resources.GetObject("rmiOpenFile.SmallImage")));
      this.rmiOpenFile.Text = "Открыть";
      this.rmiOpenFile.Click += new System.EventHandler(this.rmiOpenFile_Click);
      // 
      // rmiFileSave
      // 
      this.rmiFileSave.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
      this.rmiFileSave.Image = ((System.Drawing.Image)(resources.GetObject("rmiFileSave.Image")));
      this.rmiFileSave.SmallImage = ((System.Drawing.Image)(resources.GetObject("rmiFileSave.SmallImage")));
      this.rmiFileSave.Text = "Сохранить";
      this.rmiFileSave.Click += new System.EventHandler(this.rmiFileSave_Click);
      // 
      // rmiAbout
      // 
      this.rmiAbout.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
      this.rmiAbout.Image = ((System.Drawing.Image)(resources.GetObject("rmiAbout.Image")));
      this.rmiAbout.SmallImage = ((System.Drawing.Image)(resources.GetObject("rmiAbout.SmallImage")));
      this.rmiAbout.Text = "О программе";
      this.rmiAbout.Click += new System.EventHandler(this.rmiAbout_Click);
      // 
      // rmiFileExit
      // 
      this.rmiFileExit.Image = ((System.Drawing.Image)(resources.GetObject("rmiFileExit.Image")));
      this.rmiFileExit.SmallImage = ((System.Drawing.Image)(resources.GetObject("rmiFileExit.SmallImage")));
      this.rmiFileExit.Text = "Закрыть программу";
      this.rmiFileExit.Click += new System.EventHandler(this.rmiFileExit_Click);
      // 
      // ribbonOrbRecentItem1
      // 
      this.ribbonOrbRecentItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem1.Image")));
      this.ribbonOrbRecentItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbRecentItem1.SmallImage")));
      this.ribbonOrbRecentItem1.Text = "ribbonOrbRecentItem1";
      // 
      // rbQuickOpen
      // 
      this.rbQuickOpen.Image = ((System.Drawing.Image)(resources.GetObject("rbQuickOpen.Image")));
      this.rbQuickOpen.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
      this.rbQuickOpen.SmallImage = global::Ztp.Properties.Resources.folder_page;
      this.rbQuickOpen.ToolTip = "Открыть файл";
      this.rbQuickOpen.Click += new System.EventHandler(this.rmiOpenFile_Click);
      // 
      // rbQuickSave
      // 
      this.rbQuickSave.Image = ((System.Drawing.Image)(resources.GetObject("rbQuickSave.Image")));
      this.rbQuickSave.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
      this.rbQuickSave.SmallImage = global::Ztp.Properties.Resources.save_as;
      this.rbQuickSave.ToolTip = "Сохранить файл";
      this.rbQuickSave.Click += new System.EventHandler(this.rmiFileSave_Click);
      // 
      // ribbonButton1
      // 
      this.ribbonButton1.Enabled = false;
      this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
      this.ribbonButton1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
      this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
      this.ribbonButton1.Text = "ribbonButton1";
      // 
      // rbAbout
      // 
      this.rbAbout.Image = ((System.Drawing.Image)(resources.GetObject("rbAbout.Image")));
      this.rbAbout.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
      this.rbAbout.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbAbout.SmallImage")));
      this.rbAbout.Text = "";
      this.rbAbout.ToolTip = "О программе";
      this.rbAbout.Click += new System.EventHandler(this.rmiAbout_Click);
      // 
      // rtConfiguration
      // 
      this.rtConfiguration.Panels.Add(this.rpPort);
      this.rtConfiguration.Panels.Add(this.rpSeason);
      this.rtConfiguration.Panels.Add(this.rpSchedule);
      this.rtConfiguration.Panels.Add(this.rpFota);
      this.rtConfiguration.Panels.Add(this.rpUpFile);
      this.rtConfiguration.Text = "КОНФИГУРАЦИЯ";
      // 
      // rpPort
      // 
      this.rpPort.ButtonMoreVisible = false;
      this.rpPort.Items.Add(this.rbOpenClose);
      this.rpPort.Items.Add(this.rbRead);
      this.rpPort.Items.Add(this.rbWrite);
      this.rpPort.Items.Add(this.rbReboot);
      this.rpPort.Items.Add(this.rbChangePwd);
      this.rpPort.Items.Add(this.rbLight);
      this.rpPort.Items.Add(this.rbBrightToggle);
      this.rpPort.Text = "Порт";
      // 
      // rbOpenClose
      // 
      this.rbOpenClose.Image = global::Ztp.Properties.Resources.gear_connection;
      this.rbOpenClose.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbOpenClose.SmallImage")));
      this.rbOpenClose.Text = "Открыть";
      this.rbOpenClose.ToolTip = "Открыть/Закрыть порт";
      this.rbOpenClose.Click += new System.EventHandler(this.rbOpenClose_Click);
      // 
      // rbRead
      // 
      this.rbRead.Image = ((System.Drawing.Image)(resources.GetObject("rbRead.Image")));
      this.rbRead.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbRead.SmallImage")));
      this.rbRead.Text = "Прочитать";
      this.rbRead.ToolTip = "Прочитать конфигурацию с устройства";
      this.rbRead.Click += new System.EventHandler(this.rbRead_Click);
      // 
      // rbWrite
      // 
      this.rbWrite.Image = ((System.Drawing.Image)(resources.GetObject("rbWrite.Image")));
      this.rbWrite.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbWrite.SmallImage")));
      this.rbWrite.Text = "Записать";
      this.rbWrite.ToolTip = "Записать конфигурацию в устройство";
      this.rbWrite.Click += new System.EventHandler(this.rbWrite_Click);
      // 
      // rbReboot
      // 
      this.rbReboot.Image = ((System.Drawing.Image)(resources.GetObject("rbReboot.Image")));
      this.rbReboot.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbReboot.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbReboot.SmallImage")));
      this.rbReboot.Text = "Перезапустить";
      this.rbReboot.ToolTip = "Перезапустить устройство";
      this.rbReboot.Click += new System.EventHandler(this.rbReboot_Click);
      // 
      // rbChangePwd
      // 
      this.rbChangePwd.Image = ((System.Drawing.Image)(resources.GetObject("rbChangePwd.Image")));
      this.rbChangePwd.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbChangePwd.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbChangePwd.SmallImage")));
      this.rbChangePwd.Text = "Сменить пароль";
      this.rbChangePwd.ToolTip = "Сменить пароль доступа к устройству";
      this.rbChangePwd.Click += new System.EventHandler(this.rbChangePwd_Click);
      // 
      // rbLight
      // 
      this.rbLight.Image = ((System.Drawing.Image)(resources.GetObject("rbLight.Image")));
      this.rbLight.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbLight.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbLight.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbLight.SmallImage")));
      this.rbLight.Text = "Включить освещение";
      this.rbLight.ToolTip = "Включить/Выключить освещение";
      this.rbLight.Click += new System.EventHandler(this.rbLight_Click);
      // 
      // rbBrightToggle
      // 
      this.rbBrightToggle.Image = global::Ztp.Properties.Resources.bright_100;
      this.rbBrightToggle.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbBrightToggle.SmallImage")));
      this.rbBrightToggle.Text = "Изменить яркость";
      this.rbBrightToggle.Visible = false;
      this.rbBrightToggle.Click += new System.EventHandler(this.rbBrightToggle_Click);
      // 
      // rpSeason
      // 
      this.rpSeason.ButtonMoreVisible = false;
      this.rpSeason.Items.Add(this.rbAddSeason);
      this.rpSeason.Items.Add(this.rbDeleteSeason);
      this.rpSeason.Items.Add(this.rbEditSeason);
      this.rpSeason.Text = "Сезон";
      // 
      // rbAddSeason
      // 
      this.rbAddSeason.Image = ((System.Drawing.Image)(resources.GetObject("rbAddSeason.Image")));
      this.rbAddSeason.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbAddSeason.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbAddSeason.SmallImage")));
      this.rbAddSeason.Text = "Добавить сезон";
      this.rbAddSeason.ToolTip = "";
      this.rbAddSeason.Click += new System.EventHandler(this.rbAddSeason_Click);
      // 
      // rbDeleteSeason
      // 
      this.rbDeleteSeason.Image = ((System.Drawing.Image)(resources.GetObject("rbDeleteSeason.Image")));
      this.rbDeleteSeason.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbDeleteSeason.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbDeleteSeason.SmallImage")));
      this.rbDeleteSeason.Text = "Удалить сезон";
      this.rbDeleteSeason.Click += new System.EventHandler(this.rbDeleteSeason_Click);
      // 
      // rbEditSeason
      // 
      this.rbEditSeason.Image = ((System.Drawing.Image)(resources.GetObject("rbEditSeason.Image")));
      this.rbEditSeason.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbEditSeason.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbEditSeason.SmallImage")));
      this.rbEditSeason.Text = "Изменить сезон";
      this.rbEditSeason.Click += new System.EventHandler(this.rbEditSeason_Click);
      // 
      // rpSchedule
      // 
      this.rpSchedule.ButtonMoreVisible = false;
      this.rpSchedule.Items.Add(this.rbAddSchedule);
      this.rpSchedule.Items.Add(this.rbDeleteSchedule);
      this.rpSchedule.Items.Add(this.rbEditSchedule);
      this.rpSchedule.Items.Add(this.rbShowSched);
      this.rpSchedule.Text = "Расписание";
      // 
      // rbAddSchedule
      // 
      this.rbAddSchedule.Image = ((System.Drawing.Image)(resources.GetObject("rbAddSchedule.Image")));
      this.rbAddSchedule.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbAddSchedule.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbAddSchedule.SmallImage")));
      this.rbAddSchedule.Text = "Добавить расписание";
      this.rbAddSchedule.Click += new System.EventHandler(this.rbAddSchedule_Click);
      // 
      // rbDeleteSchedule
      // 
      this.rbDeleteSchedule.Image = ((System.Drawing.Image)(resources.GetObject("rbDeleteSchedule.Image")));
      this.rbDeleteSchedule.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbDeleteSchedule.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbDeleteSchedule.SmallImage")));
      this.rbDeleteSchedule.Text = "Удалить расписание";
      this.rbDeleteSchedule.Click += new System.EventHandler(this.rbDeleteSchedule_Click);
      // 
      // rbEditSchedule
      // 
      this.rbEditSchedule.DropDownItems.Add(this.ribbon.QuickAcessToolbar);
      this.rbEditSchedule.Image = ((System.Drawing.Image)(resources.GetObject("rbEditSchedule.Image")));
      this.rbEditSchedule.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbEditSchedule.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbEditSchedule.SmallImage")));
      this.rbEditSchedule.Text = "Изменить расписание";
      this.rbEditSchedule.Click += new System.EventHandler(this.rbEditSchedule_Click);
      // 
      // rbShowSched
      // 
      this.rbShowSched.Image = ((System.Drawing.Image)(resources.GetObject("rbShowSched.Image")));
      this.rbShowSched.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbShowSched.SmallImage")));
      this.rbShowSched.Text = "Просмотр";
      this.rbShowSched.ToolTip = "Просмотр времен срабатывания расписания";
      this.rbShowSched.Click += new System.EventHandler(this.rbShowSched_Click);
      // 
      // rpFota
      // 
      this.rpFota.ButtonMoreEnabled = false;
      this.rpFota.ButtonMoreVisible = false;
      this.rpFota.Items.Add(this.rbFota);
      this.rpFota.Text = "Прошивка";
      // 
      // rbFota
      // 
      this.rbFota.Image = ((System.Drawing.Image)(resources.GetObject("rbFota.Image")));
      this.rbFota.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbFota.SmallImage")));
      this.rbFota.Text = "Прошить";
      this.rbFota.Click += new System.EventHandler(this.rbFota_Click);
      // 
      // rpUpFile
      // 
      this.rpUpFile.ButtonMoreEnabled = false;
      this.rpUpFile.ButtonMoreVisible = false;
      this.rpUpFile.Items.Add(this.rbUpFile);
      this.rpUpFile.Text = "Загрузить файл";
      // 
      // rbUpFile
      // 
      this.rbUpFile.Image = ((System.Drawing.Image)(resources.GetObject("rbUpFile.Image")));
      this.rbUpFile.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbUpFile.SmallImage")));
      this.rbUpFile.Text = "Загрузить";
      this.rbUpFile.Click += new System.EventHandler(this.rbUpFile_Click);
      // 
      // rtView
      // 
      this.rtView.Panels.Add(this.rpView);
      this.rtView.Text = "ВИД";
      // 
      // rpView
      // 
      this.rpView.ButtonMoreVisible = false;
      this.rpView.Items.Add(this.rbViewDebug);
      this.rpView.Items.Add(this.rbViewState);
      this.rpView.Text = "";
      // 
      // rbViewDebug
      // 
      this.rbViewDebug.Image = ((System.Drawing.Image)(resources.GetObject("rbViewDebug.Image")));
      this.rbViewDebug.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbViewDebug.SmallImage")));
      this.rbViewDebug.Text = "Окно отладки";
      this.rbViewDebug.ToolTip = "Показать/Скрыть окно вывода отладочных сообщений";
      this.rbViewDebug.Click += new System.EventHandler(this.rbViewDebug_Click);
      // 
      // rbViewState
      // 
      this.rbViewState.Image = ((System.Drawing.Image)(resources.GetObject("rbViewState.Image")));
      this.rbViewState.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbViewState.SmallImage")));
      this.rbViewState.Text = "Окно состояния";
      this.rbViewState.Click += new System.EventHandler(this.rbViewState_Click);
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslPort});
      this.statusStrip.Location = new System.Drawing.Point(0, 642);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(1239, 22);
      this.statusStrip.TabIndex = 4;
      this.statusStrip.Text = "statusStrip1";
      // 
      // sslPort
      // 
      this.sslPort.Name = "sslPort";
      this.sslPort.Size = new System.Drawing.Size(118, 17);
      this.sslPort.Text = "toolStripStatusLabel1";
      // 
      // splitContainer
      // 
      this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer.Location = new System.Drawing.Point(0, 151);
      this.splitContainer.Name = "splitContainer";
      this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer.Panel1
      // 
      this.splitContainer.Panel1.Controls.Add(this.splitContainerState);
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.logConsole);
      this.splitContainer.Panel2.Controls.Add(this.label1);
      this.splitContainer.Panel2MinSize = 18;
      this.splitContainer.Size = new System.Drawing.Size(1239, 491);
      this.splitContainer.SplitterDistance = 300;
      this.splitContainer.TabIndex = 5;
      // 
      // splitContainerState
      // 
      this.splitContainerState.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainerState.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainerState.IsSplitterFixed = true;
      this.splitContainerState.Location = new System.Drawing.Point(0, 0);
      this.splitContainerState.Name = "splitContainerState";
      // 
      // splitContainerState.Panel1
      // 
      this.splitContainerState.Panel1.Controls.Add(this.tcConfig);
      // 
      // splitContainerState.Panel2
      // 
      this.splitContainerState.Panel2.Controls.Add(this.currentStateView);
      this.splitContainerState.Panel2.Controls.Add(this.label2);
      this.splitContainerState.Panel2MinSize = 300;
      this.splitContainerState.Size = new System.Drawing.Size(1239, 300);
      this.splitContainerState.SplitterDistance = 890;
      this.splitContainerState.TabIndex = 3;
      this.splitContainerState.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.splitContainerState_SplitterMoving);
      // 
      // tcConfig
      // 
      this.tcConfig.Controls.Add(this.tpConfigGen);
      this.tcConfig.Controls.Add(this.tpConfigSched);
      this.tcConfig.Controls.Add(this.tpRs485);
      this.tcConfig.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tcConfig.ImageList = this.imlTc;
      this.tcConfig.ItemSize = new System.Drawing.Size(150, 25);
      this.tcConfig.Location = new System.Drawing.Point(0, 0);
      this.tcConfig.Name = "tcConfig";
      this.tcConfig.SelectedIndex = 0;
      this.tcConfig.Size = new System.Drawing.Size(890, 300);
      this.tcConfig.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
      this.tcConfig.TabIndex = 2;
      this.tcConfig.SelectedIndexChanged += new System.EventHandler(this.tcConfig_SelectedIndexChanged);
      // 
      // tpConfigGen
      // 
      this.tpConfigGen.Controls.Add(this.panel);
      this.tpConfigGen.ImageIndex = 2;
      this.tpConfigGen.Location = new System.Drawing.Point(4, 29);
      this.tpConfigGen.Name = "tpConfigGen";
      this.tpConfigGen.Padding = new System.Windows.Forms.Padding(3);
      this.tpConfigGen.Size = new System.Drawing.Size(882, 267);
      this.tpConfigGen.TabIndex = 0;
      this.tpConfigGen.Text = "Общие";
      this.tpConfigGen.UseVisualStyleBackColor = true;
      // 
      // panel
      // 
      this.panel.Controls.Add(this.configEditor);
      this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel.Location = new System.Drawing.Point(3, 3);
      this.panel.Name = "panel";
      this.panel.Size = new System.Drawing.Size(876, 261);
      this.panel.TabIndex = 0;
      // 
      // configEditor
      // 
      this.configEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.configEditor.Location = new System.Drawing.Point(0, 0);
      this.configEditor.Name = "configEditor";
      this.configEditor.ShowApnProperty = false;
      this.configEditor.Size = new System.Drawing.Size(876, 261);
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
      ztpConfig1.dateTime = new System.DateTime(2017, 2, 21, 9, 33, 34, 512);
      ztpConfig1.DateTime = new System.DateTime(2017, 2, 21, 9, 33, 34, 512);
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
      ztpConfig1.Imei = "";
      ztpConfig1.IpOwn = null;
      ztpConfig1.IpPing = "";
      ztpConfig1.IsHalfBright = false;
      ztpConfig1.IsReadedFromDevice = false;
      ztpConfig1.Latitude = 55.1911F;
      ztpLight1.Scheduler = ztpScheduler1;
      ztpLight1.UseScheduler = false;
      ztpConfig1.Light = ztpLight1;
      ztpConfig1.logLevel = ((byte)(0));
      ztpConfig1.Longitude = 30.12533F;
      ztpConfig1.NetTechnology = "";
      ztpConfig1.Number = 0;
      ztpConfig1.PingPeriod = ((byte)(1));
      ztpConfig1.rebootTime = "";
      ztpConfig1.Signal = ((int)(0u));
      ztpConfig1.Sim = ((uint)(0u));
      ztpConfig1.SoftVersion = "";
      ztpConfig1.Sunrise = new System.DateTime(((long)(0)));
      ztpConfig1.Sunset = new System.DateTime(((long)(0)));
      ztpConfig1.TimeZone = ((sbyte)(-12));
      ztpConfig1.Version = "I1O1A1-LDC-3";
      this.configEditor.Value = ztpConfig1;
      // 
      // tpConfigSched
      // 
      this.tpConfigSched.Controls.Add(this.planEditor);
      this.tpConfigSched.ImageIndex = 0;
      this.tpConfigSched.Location = new System.Drawing.Point(4, 29);
      this.tpConfigSched.Name = "tpConfigSched";
      this.tpConfigSched.Padding = new System.Windows.Forms.Padding(3);
      this.tpConfigSched.Size = new System.Drawing.Size(882, 267);
      this.tpConfigSched.TabIndex = 1;
      this.tpConfigSched.Text = "План освещения";
      this.tpConfigSched.UseVisualStyleBackColor = true;
      // 
      // planEditor
      // 
      this.planEditor.AutoSize = true;
      this.planEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.planEditor.Location = new System.Drawing.Point(3, 3);
      this.planEditor.Name = "planEditor";
      this.planEditor.Size = new System.Drawing.Size(876, 261);
      this.planEditor.TabIndex = 0;
      this.planEditor.UseSchedulerEnable = true;
      this.planEditor.UseSchedulerVisible = false;
      ztpLight2.Scheduler = ztpScheduler2;
      ztpLight2.UseScheduler = true;
      this.planEditor.Value = ztpLight2;
      ztpLocation1.Latitude = 0F;
      ztpLocation1.Longitude = 0F;
      ztpLocation1.TimeZone = ((sbyte)(0));
      this.planEditor.ZtpLocation = ztpLocation1;
      // 
      // tpRs485
      // 
      this.tpRs485.Controls.Add(this.groupBox1);
      this.tpRs485.Controls.Add(this.modbusItemListControl1);
      this.tpRs485.Controls.Add(this.modBusEditor);
      this.tpRs485.Controls.Add(this.comPortEditor);
      this.tpRs485.ImageIndex = 1;
      this.tpRs485.Location = new System.Drawing.Point(4, 29);
      this.tpRs485.Name = "tpRs485";
      this.tpRs485.Size = new System.Drawing.Size(882, 267);
      this.tpRs485.TabIndex = 2;
      this.tpRs485.Text = "RS485";
      this.tpRs485.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Location = new System.Drawing.Point(3, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(432, 40);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Внимание";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.label3.Location = new System.Drawing.Point(1, 20);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(426, 17);
      this.label3.TabIndex = 0;
      this.label3.Text = "Сквозной канал и канал модбас привязаны на TCP порт 10250";
      // 
      // modbusItemListControl1
      // 
      this.modbusItemListControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.modbusItemListControl1.AutoSize = true;
      this.modbusItemListControl1.Location = new System.Drawing.Point(441, 3);
      this.modbusItemListControl1.max_mb_Tags = ((short)(100));
      this.modbusItemListControl1.Name = "modbusItemListControl1";
      this.modbusItemListControl1.Size = new System.Drawing.Size(441, 265);
      this.modbusItemListControl1.TabIndex = 2;
      this.modbusItemListControl1.Visible = false;
      // 
      // modBusEditor
      // 
      this.modBusEditor.AutoScroll = true;
      this.modBusEditor.AutoSize = true;
      this.modBusEditor.Location = new System.Drawing.Point(-1, 158);
      this.modBusEditor.Name = "modBusEditor";
      this.modBusEditor.Size = new System.Drawing.Size(436, 110);
      this.modBusEditor.TabIndex = 1;
      this.modBusEditor.Visible = false;
      // 
      // comPortEditor
      // 
      this.comPortEditor.EnabledBaudrates = true;
      this.comPortEditor.EnabledDataBits = true;
      this.comPortEditor.EnabledHandshake = true;
      this.comPortEditor.EnabledParity = true;
      this.comPortEditor.EnabledPortName = true;
      this.comPortEditor.EnabledStopBits = true;
      this.comPortEditor.Location = new System.Drawing.Point(3, 43);
      this.comPortEditor.Name = "comPortEditor";
      this.comPortEditor.ShowHandshake = false;
      this.comPortEditor.ShowPortName = false;
      this.comPortEditor.ShowTimeout = false;
      this.comPortEditor.Size = new System.Drawing.Size(433, 109);
      this.comPortEditor.TabIndex = 0;
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
      // imlTc
      // 
      this.imlTc.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTc.ImageStream")));
      this.imlTc.TransparentColor = System.Drawing.Color.Transparent;
      this.imlTc.Images.SetKeyName(0, "history.png");
      this.imlTc.Images.SetKeyName(1, "port.png");
      this.imlTc.Images.SetKeyName(2, "bricks.png");
      this.imlTc.Images.SetKeyName(3, "cpu_preferences.png");
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
      this.currentStateView.Size = new System.Drawing.Size(345, 282);
      this.currentStateView.TabIndex = 4;
      this.currentStateView.Value = null;
      // 
      // label2
      // 
      this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.label2.Dock = System.Windows.Forms.DockStyle.Top;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label2.Location = new System.Drawing.Point(0, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(345, 18);
      this.label2.TabIndex = 3;
      this.label2.Text = "Состояние";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // logConsole
      // 
      this.logConsole.Dock = System.Windows.Forms.DockStyle.Fill;
      this.logConsole.Location = new System.Drawing.Point(0, 18);
      this.logConsole.Name = "logConsole";
      this.logConsole.Size = new System.Drawing.Size(1239, 169);
      this.logConsole.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.label1.Dock = System.Windows.Forms.DockStyle.Top;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(1239, 18);
      this.label1.TabIndex = 2;
      this.label1.Text = "Отладка";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1239, 664);
      this.Controls.Add(this.splitContainer);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.ribbon);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(1050, 550);
      this.Name = "MainForm";
      this.Text = "Конфигурация УУСИ-16";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
      this.splitContainer.ResumeLayout(false);
      this.splitContainerState.Panel1.ResumeLayout(false);
      this.splitContainerState.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerState)).EndInit();
      this.splitContainerState.ResumeLayout(false);
      this.tcConfig.ResumeLayout(false);
      this.tpConfigGen.ResumeLayout(false);
      this.panel.ResumeLayout(false);
      this.tpConfigSched.ResumeLayout(false);
      this.tpConfigSched.PerformLayout();
      this.tpRs485.ResumeLayout(false);
      this.tpRs485.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Panel panel;
    private Ztp.Ui.ConfigEditorControl configEditor;
    private System.Windows.Forms.ImageList iml;
    private System.Windows.Forms.ToolTip hint;
    private System.Windows.Forms.OpenFileDialog ofd;
    private System.Windows.Forms.SaveFileDialog sfd;
    private System.ComponentModel.BackgroundWorker bw;
    private Ui.LightPlanEditorControl planEditor;
    private System.Windows.Forms.TabControl tcConfig;
    private System.Windows.Forms.TabPage tpConfigGen;
    private System.Windows.Forms.TabPage tpConfigSched;
    private System.Windows.Forms.Ribbon ribbon;
    private System.Windows.Forms.RibbonTab rtConfiguration;
    private System.Windows.Forms.RibbonPanel rpPort;
    private System.Windows.Forms.RibbonButton rbRead;
    private System.Windows.Forms.RibbonButton rbWrite;
    private System.Windows.Forms.RibbonPanel rpSeason;
    private System.Windows.Forms.RibbonButton rbAddSeason;
    private System.Windows.Forms.RibbonButton rbDeleteSeason;
    private System.Windows.Forms.RibbonButton rbEditSeason;
    private System.Windows.Forms.RibbonPanel rpSchedule;
    private System.Windows.Forms.RibbonButton rbAddSchedule;
    private System.Windows.Forms.RibbonButton rbDeleteSchedule;
    private System.Windows.Forms.RibbonButton rbEditSchedule;
    private System.Windows.Forms.RibbonButton rbReboot;
    private System.Windows.Forms.RibbonButton rbOpenClose;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel sslPort;
    private System.Windows.Forms.RibbonButton rbQuickOpen;
    private System.Windows.Forms.RibbonButton rbQuickSave;
    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.RibbonOrbMenuItem rmiOpenFile;
    private System.Windows.Forms.RibbonButton rmiFileExit;
    private System.Windows.Forms.RibbonOrbMenuItem rmiFileSave;
    private System.Windows.Forms.RibbonOrbRecentItem ribbonOrbRecentItem1;
    private System.Windows.Forms.RibbonButton rbShowSched;
    private Ui.UiLogConsoleControl logConsole;
    private System.Windows.Forms.RibbonTab rtView;
    private System.Windows.Forms.RibbonPanel rpView;
    private System.Windows.Forms.RibbonButton rbViewDebug;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.RibbonButton rbLight;
    private System.Windows.Forms.TabPage tpRs485;
    private Ui.ComPortSettingsEditorControl comPortEditor;
    private System.Windows.Forms.ImageList imlTc;
    private System.Windows.Forms.RibbonButton rbChangePwd;
    private System.Windows.Forms.SplitContainer splitContainerState;
    private System.Windows.Forms.Label label2;
    private Ui.CurrentStateViewControl currentStateView;
    private System.Windows.Forms.RibbonButton rbViewState;
    private System.Windows.Forms.RibbonPanel rpFota;
    private System.Windows.Forms.RibbonButton rbFota;
    private System.Windows.Forms.RibbonButton ribbonButton1;
    private System.Windows.Forms.RibbonButton rbAbout;
    private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
    private System.Windows.Forms.RibbonOrbMenuItem rmiAbout;
    private Ui.ModBusSettingsEditorControl modBusEditor;
    internal Ui.ModbusItemListControl modbusItemListControl1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.RibbonPanel rpUpFile;
    private System.Windows.Forms.RibbonButton rbUpFile;
    private System.Windows.Forms.RibbonButton rbBrightToggle;
  }
}

