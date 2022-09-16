namespace ZtpManager
{
  partial class MainForm
  {
    /// <summary>
    /// Обязательная переменная конструктора.
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


    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.ribbon = new System.Windows.Forms.Ribbon();
      this.rbSetting = new System.Windows.Forms.RibbonButton();
      this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
      this.rbAbout = new System.Windows.Forms.RibbonButton();
      this.rtDevices = new System.Windows.Forms.RibbonTab();
      this.rpEditFolder = new System.Windows.Forms.RibbonPanel();
      this.rbAddFolder = new System.Windows.Forms.RibbonButton();
      this.rbDeleteFolder = new System.Windows.Forms.RibbonButton();
      this.rbEditFolder = new System.Windows.Forms.RibbonButton();
      this.rpEditDevice = new System.Windows.Forms.RibbonPanel();
      this.rbAddDevice = new System.Windows.Forms.RibbonButton();
      this.rbDropDownAddDevice = new System.Windows.Forms.RibbonButton();
      this.rbAddDeviceManual = new System.Windows.Forms.RibbonButton();
      this.rbAddDeviceEstTools = new System.Windows.Forms.RibbonButton();
      this.rbDeleteDevice = new System.Windows.Forms.RibbonButton();
      this.rbEditDevice = new System.Windows.Forms.RibbonButton();
      this.rbSyncEst = new System.Windows.Forms.RibbonButton();
      this.rpClipboard = new System.Windows.Forms.RibbonPanel();
      this.rbCopyNode = new System.Windows.Forms.RibbonButton();
      this.rbPasteNode = new System.Windows.Forms.RibbonButton();
      this.rpAudit = new System.Windows.Forms.RibbonPanel();
      this.rbAudit = new System.Windows.Forms.RibbonButton();
      this.rpCatalog = new System.Windows.Forms.RibbonPanel();
      this.rbCatalogs = new System.Windows.Forms.RibbonButton();
      this.rbCatScheduler = new System.Windows.Forms.RibbonButton();
      this.rbSummary = new System.Windows.Forms.RibbonButton();
      this.rbObjectList = new System.Windows.Forms.RibbonButton();
      this.rbLastOp = new System.Windows.Forms.RibbonButton();
      this.rtConfig = new System.Windows.Forms.RibbonTab();
      this.rpDevice = new System.Windows.Forms.RibbonPanel();
      this.rbDeviceOpen = new System.Windows.Forms.RibbonButton();
      this.rbDeviceRead = new System.Windows.Forms.RibbonButton();
      this.rbDeviceWrite = new System.Windows.Forms.RibbonButton();
      this.rbReboot = new System.Windows.Forms.RibbonButton();
      this.rbChangePassword = new System.Windows.Forms.RibbonButton();
      this.rbSwitchOnOff = new System.Windows.Forms.RibbonButton();
      this.rpSeason = new System.Windows.Forms.RibbonPanel();
      this.rbCopyPlanFromCat = new System.Windows.Forms.RibbonButton();
      this.rbSeasonAdd = new System.Windows.Forms.RibbonButton();
      this.rbSeasonDelete = new System.Windows.Forms.RibbonButton();
      this.rbSeasonEdit = new System.Windows.Forms.RibbonButton();
      this.rpSchedule = new System.Windows.Forms.RibbonPanel();
      this.rbScheduleAdd = new System.Windows.Forms.RibbonButton();
      this.rbScheduleDelete = new System.Windows.Forms.RibbonButton();
      this.rbScheduleEdit = new System.Windows.Forms.RibbonButton();
      this.rpShowScheduler = new System.Windows.Forms.RibbonPanel();
      this.rbShowScheduler = new System.Windows.Forms.RibbonButton();
      this.rtTools = new System.Windows.Forms.RibbonTab();
      this.rpMultiOperation = new System.Windows.Forms.RibbonPanel();
      this.rbMultiWriteConfig = new System.Windows.Forms.RibbonButton();
      this.rbMultiSwitchOnOff = new System.Windows.Forms.RibbonButton();
      this.rbMultiChangePassword = new System.Windows.Forms.RibbonButton();
      this.rbMultiReboot = new System.Windows.Forms.RibbonButton();
      this.rbMultiWriteFota = new System.Windows.Forms.RibbonButton();
      this.rbMultiWritePatch = new System.Windows.Forms.RibbonButton();
      this.rtView = new System.Windows.Forms.RibbonTab();
      this.rpView = new System.Windows.Forms.RibbonPanel();
      this.rbViewDebug = new System.Windows.Forms.RibbonButton();
      this.rbViewState = new System.Windows.Forms.RibbonButton();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.scMain = new System.Windows.Forms.SplitContainer();
      this.tv = new ZtpManager.Controls.DeviceTreeView();
      this.imlTv = new System.Windows.Forms.ImageList(this.components);
      this.tcZtpConfig = new MdiTabControl.TabControl();
      this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cmiDeviceOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.cmiAddFolder = new System.Windows.Forms.ToolStripMenuItem();
      this.cmiDeleteFolder = new System.Windows.Forms.ToolStripMenuItem();
      this.cmiEditFolder = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.cmiAddDevice = new System.Windows.Forms.ToolStripMenuItem();
      this.cmiDropDownAddDevice = new System.Windows.Forms.ToolStripMenuItem();
      this.cmiAddDeviceManual = new System.Windows.Forms.ToolStripMenuItem();
      this.cmiAddDeviceEstTools = new System.Windows.Forms.ToolStripMenuItem();
      this.cmiDeleteDevice = new System.Windows.Forms.ToolStripMenuItem();
      this.cmiEditDevice = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
      this.cmiCopyNode = new System.Windows.Forms.ToolStripMenuItem();
      this.cmiPasteNode = new System.Windows.Forms.ToolStripMenuItem();
      this.imlTabControl = new System.Windows.Forms.ImageList(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
      this.scMain.Panel1.SuspendLayout();
      this.scMain.Panel2.SuspendLayout();
      this.scMain.SuspendLayout();
      this.contextMenu.SuspendLayout();
      this.SuspendLayout();
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
      this.ribbon.OrbDropDown.Name = "";
      this.ribbon.OrbDropDown.Size = new System.Drawing.Size(527, 447);
      this.ribbon.OrbDropDown.TabIndex = 0;
      this.ribbon.OrbImage = null;
      this.ribbon.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
      this.ribbon.OrbVisible = false;
      // 
      // 
      // 
      this.ribbon.QuickAcessToolbar.Enabled = false;
      this.ribbon.QuickAcessToolbar.Items.Add(this.rbSetting);
      this.ribbon.QuickAcessToolbar.Items.Add(this.ribbonButton1);
      this.ribbon.QuickAcessToolbar.Items.Add(this.rbAbout);
      this.ribbon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
      this.ribbon.Size = new System.Drawing.Size(918, 169);
      this.ribbon.TabIndex = 0;
      this.ribbon.Tabs.Add(this.rtDevices);
      this.ribbon.Tabs.Add(this.rtConfig);
      this.ribbon.Tabs.Add(this.rtTools);
      this.ribbon.Tabs.Add(this.rtView);
      this.ribbon.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
      this.ribbon.Text = "7";
      this.ribbon.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
      // 
      // rbSetting
      // 
      this.rbSetting.Enabled = false;
      this.rbSetting.Image = ((System.Drawing.Image)(resources.GetObject("rbSetting.Image")));
      this.rbSetting.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
      this.rbSetting.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbSetting.SmallImage")));
      this.rbSetting.Text = "";
      this.rbSetting.ToolTip = "Настройка";
      this.rbSetting.Click += new System.EventHandler(this.rbSetting_Click);
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
      this.rbAbout.Enabled = false;
      this.rbAbout.Image = ((System.Drawing.Image)(resources.GetObject("rbAbout.Image")));
      this.rbAbout.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
      this.rbAbout.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbAbout.SmallImage")));
      this.rbAbout.Text = "";
      this.rbAbout.ToolTip = "О программе";
      this.rbAbout.Click += new System.EventHandler(this.rbAbout_Click);
      // 
      // rtDevices
      // 
      this.rtDevices.Panels.Add(this.rpEditFolder);
      this.rtDevices.Panels.Add(this.rpEditDevice);
      this.rtDevices.Panels.Add(this.rpClipboard);
      this.rtDevices.Panels.Add(this.rpAudit);
      this.rtDevices.Panels.Add(this.rpCatalog);
      this.rtDevices.Text = "ГЛАВНАЯ";
      // 
      // rpEditFolder
      // 
      this.rpEditFolder.ButtonMoreEnabled = false;
      this.rpEditFolder.ButtonMoreVisible = false;
      this.rpEditFolder.Items.Add(this.rbAddFolder);
      this.rpEditFolder.Items.Add(this.rbDeleteFolder);
      this.rpEditFolder.Items.Add(this.rbEditFolder);
      this.rpEditFolder.Text = "Папки";
      // 
      // rbAddFolder
      // 
      this.rbAddFolder.Image = ((System.Drawing.Image)(resources.GetObject("rbAddFolder.Image")));
      this.rbAddFolder.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbAddFolder.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbAddFolder.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbAddFolder.SmallImage")));
      this.rbAddFolder.Text = "Добавить папку";
      this.rbAddFolder.Click += new System.EventHandler(this.rbAddFolder_Click);
      // 
      // rbDeleteFolder
      // 
      this.rbDeleteFolder.Image = ((System.Drawing.Image)(resources.GetObject("rbDeleteFolder.Image")));
      this.rbDeleteFolder.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbDeleteFolder.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbDeleteFolder.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbDeleteFolder.SmallImage")));
      this.rbDeleteFolder.Text = "Удалить папку";
      this.rbDeleteFolder.Click += new System.EventHandler(this.rbDeleteFolder_Click);
      // 
      // rbEditFolder
      // 
      this.rbEditFolder.Image = ((System.Drawing.Image)(resources.GetObject("rbEditFolder.Image")));
      this.rbEditFolder.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbEditFolder.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbEditFolder.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbEditFolder.SmallImage")));
      this.rbEditFolder.Text = "Изменить папку";
      this.rbEditFolder.Click += new System.EventHandler(this.rbEditFolder_Click);
      // 
      // rpEditDevice
      // 
      this.rpEditDevice.ButtonMoreEnabled = false;
      this.rpEditDevice.ButtonMoreVisible = false;
      this.rpEditDevice.Items.Add(this.rbAddDevice);
      this.rpEditDevice.Items.Add(this.rbDropDownAddDevice);
      this.rpEditDevice.Items.Add(this.rbDeleteDevice);
      this.rpEditDevice.Items.Add(this.rbEditDevice);
      this.rpEditDevice.Items.Add(this.rbSyncEst);
      this.rpEditDevice.Text = "Устройства";
      // 
      // rbAddDevice
      // 
      this.rbAddDevice.Image = ((System.Drawing.Image)(resources.GetObject("rbAddDevice.Image")));
      this.rbAddDevice.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbAddDevice.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbAddDevice.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbAddDevice.SmallImage")));
      this.rbAddDevice.Text = "Добавить устройство";
      this.rbAddDevice.Click += new System.EventHandler(this.rbAddDevice_Click);
      // 
      // rbDropDownAddDevice
      // 
      this.rbDropDownAddDevice.DropDownItems.Add(this.rbAddDeviceManual);
      this.rbDropDownAddDevice.DropDownItems.Add(this.rbAddDeviceEstTools);
      this.rbDropDownAddDevice.Image = ((System.Drawing.Image)(resources.GetObject("rbDropDownAddDevice.Image")));
      this.rbDropDownAddDevice.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.DropDown;
      this.rbDropDownAddDevice.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.DropDown;
      this.rbDropDownAddDevice.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbDropDownAddDevice.SmallImage")));
      this.rbDropDownAddDevice.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
      this.rbDropDownAddDevice.Text = "Добавить устройство";
      // 
      // rbAddDeviceManual
      // 
      this.rbAddDeviceManual.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
      this.rbAddDeviceManual.Image = ((System.Drawing.Image)(resources.GetObject("rbAddDeviceManual.Image")));
      this.rbAddDeviceManual.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbAddDeviceManual.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbAddDeviceManual.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbAddDeviceManual.SmallImage")));
      this.rbAddDeviceManual.Text = "Добавить вручную";
      this.rbAddDeviceManual.Click += new System.EventHandler(this.rbAddDevice_Click);
      // 
      // rbAddDeviceEstTools
      // 
      this.rbAddDeviceEstTools.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
      this.rbAddDeviceEstTools.Image = ((System.Drawing.Image)(resources.GetObject("rbAddDeviceEstTools.Image")));
      this.rbAddDeviceEstTools.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbAddDeviceEstTools.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbAddDeviceEstTools.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbAddDeviceEstTools.SmallImage")));
      this.rbAddDeviceEstTools.Text = "Добавить из EST Tools";
      this.rbAddDeviceEstTools.Click += new System.EventHandler(this.rbAddDeviceEstTools_Click);
      // 
      // rbDeleteDevice
      // 
      this.rbDeleteDevice.Image = ((System.Drawing.Image)(resources.GetObject("rbDeleteDevice.Image")));
      this.rbDeleteDevice.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbDeleteDevice.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbDeleteDevice.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbDeleteDevice.SmallImage")));
      this.rbDeleteDevice.Text = "Удалить устройство";
      this.rbDeleteDevice.Click += new System.EventHandler(this.rbDeleteDevice_Click);
      // 
      // rbEditDevice
      // 
      this.rbEditDevice.Image = ((System.Drawing.Image)(resources.GetObject("rbEditDevice.Image")));
      this.rbEditDevice.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbEditDevice.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbEditDevice.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbEditDevice.SmallImage")));
      this.rbEditDevice.Text = "Изменить устройство";
      this.rbEditDevice.Click += new System.EventHandler(this.rbEditDevice_Click);
      // 
      // rbSyncEst
      // 
      this.rbSyncEst.Image = ((System.Drawing.Image)(resources.GetObject("rbSyncEst.Image")));
      this.rbSyncEst.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbSyncEst.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbSyncEst.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbSyncEst.SmallImage")));
      this.rbSyncEst.Text = "Обновить из EST Tools";
      this.rbSyncEst.ToolTip = "Обновить описания устройств из EST Tools";
      this.rbSyncEst.Click += new System.EventHandler(this.rbSyncEst_Click);
      // 
      // rpClipboard
      // 
      this.rpClipboard.ButtonMoreEnabled = false;
      this.rpClipboard.ButtonMoreVisible = false;
      this.rpClipboard.Items.Add(this.rbCopyNode);
      this.rpClipboard.Items.Add(this.rbPasteNode);
      this.rpClipboard.Text = "Буфер обмена";
      // 
      // rbCopyNode
      // 
      this.rbCopyNode.Image = ((System.Drawing.Image)(resources.GetObject("rbCopyNode.Image")));
      this.rbCopyNode.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbCopyNode.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbCopyNode.SmallImage")));
      this.rbCopyNode.Text = "Скопировать узел";
      this.rbCopyNode.Click += new System.EventHandler(this.rbCopyNode_Click);
      // 
      // rbPasteNode
      // 
      this.rbPasteNode.Image = ((System.Drawing.Image)(resources.GetObject("rbPasteNode.Image")));
      this.rbPasteNode.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbPasteNode.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbPasteNode.SmallImage")));
      this.rbPasteNode.Text = "Вставить узел";
      this.rbPasteNode.Click += new System.EventHandler(this.rbPasteNode_Click);
      // 
      // rpAudit
      // 
      this.rpAudit.ButtonMoreEnabled = false;
      this.rpAudit.ButtonMoreVisible = false;
      this.rpAudit.Items.Add(this.rbAudit);
      this.rpAudit.Text = "";
      // 
      // rbAudit
      // 
      this.rbAudit.Image = ((System.Drawing.Image)(resources.GetObject("rbAudit.Image")));
      this.rbAudit.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbAudit.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbAudit.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbAudit.SmallImage")));
      this.rbAudit.Text = "Аудит";
      this.rbAudit.Click += new System.EventHandler(this.rbAudit_Click);
      // 
      // rpCatalog
      // 
      this.rpCatalog.ButtonMoreEnabled = false;
      this.rpCatalog.ButtonMoreVisible = false;
      this.rpCatalog.Items.Add(this.rbCatalogs);
      this.rpCatalog.Items.Add(this.rbSummary);
      this.rpCatalog.Text = "Информация";
      // 
      // rbCatalogs
      // 
      this.rbCatalogs.DropDownItems.Add(this.rbCatScheduler);
      this.rbCatalogs.Image = ((System.Drawing.Image)(resources.GetObject("rbCatalogs.Image")));
      this.rbCatalogs.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbCatalogs.SmallImage")));
      this.rbCatalogs.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
      this.rbCatalogs.Text = "Справочники";
      // 
      // rbCatScheduler
      // 
      this.rbCatScheduler.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
      this.rbCatScheduler.Image = ((System.Drawing.Image)(resources.GetObject("rbCatScheduler.Image")));
      this.rbCatScheduler.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbCatScheduler.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbCatScheduler.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbCatScheduler.SmallImage")));
      this.rbCatScheduler.Text = "Справочник планов освещения";
      this.rbCatScheduler.Click += new System.EventHandler(this.rbCatScheduler_Click);
      // 
      // rbSummary
      // 
      this.rbSummary.DropDownItems.Add(this.rbObjectList);
      this.rbSummary.DropDownItems.Add(this.rbLastOp);
      this.rbSummary.Image = ((System.Drawing.Image)(resources.GetObject("rbSummary.Image")));
      this.rbSummary.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbSummary.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbSummary.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbSummary.SmallImage")));
      this.rbSummary.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
      this.rbSummary.Text = "Сводка";
      // 
      // rbObjectList
      // 
      this.rbObjectList.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
      this.rbObjectList.Image = ((System.Drawing.Image)(resources.GetObject("rbObjectList.Image")));
      this.rbObjectList.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbObjectList.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbObjectList.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbObjectList.SmallImage")));
      this.rbObjectList.Text = "Список объектов";
      this.rbObjectList.Click += new System.EventHandler(this.rbObjectList_Click);
      // 
      // rbLastOp
      // 
      this.rbLastOp.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
      this.rbLastOp.Image = ((System.Drawing.Image)(resources.GetObject("rbLastOp.Image")));
      this.rbLastOp.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbLastOp.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbLastOp.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbLastOp.SmallImage")));
      this.rbLastOp.Text = "Последние операции";
      this.rbLastOp.Click += new System.EventHandler(this.rbLastOp_Click);
      // 
      // rtConfig
      // 
      this.rtConfig.Panels.Add(this.rpDevice);
      this.rtConfig.Panels.Add(this.rpSeason);
      this.rtConfig.Panels.Add(this.rpSchedule);
      this.rtConfig.Panels.Add(this.rpShowScheduler);
      this.rtConfig.Text = "КОНФИГУРАЦИЯ";
      // 
      // rpDevice
      // 
      this.rpDevice.ButtonMoreEnabled = false;
      this.rpDevice.ButtonMoreVisible = false;
      this.rpDevice.Items.Add(this.rbDeviceOpen);
      this.rpDevice.Items.Add(this.rbDeviceRead);
      this.rpDevice.Items.Add(this.rbDeviceWrite);
      this.rpDevice.Items.Add(this.rbReboot);
      this.rpDevice.Items.Add(this.rbChangePassword);
      this.rpDevice.Items.Add(this.rbSwitchOnOff);
      this.rpDevice.Text = "Устройство";
      // 
      // rbDeviceOpen
      // 
      this.rbDeviceOpen.Image = ((System.Drawing.Image)(resources.GetObject("rbDeviceOpen.Image")));
      this.rbDeviceOpen.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbDeviceOpen.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbDeviceOpen.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbDeviceOpen.SmallImage")));
      this.rbDeviceOpen.Text = "Открыть";
      this.rbDeviceOpen.ToolTip = "Прочитать и открыть конфигурацию";
      this.rbDeviceOpen.Click += new System.EventHandler(this.rbDeviceOpen_Click);
      // 
      // rbDeviceRead
      // 
      this.rbDeviceRead.Image = ((System.Drawing.Image)(resources.GetObject("rbDeviceRead.Image")));
      this.rbDeviceRead.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbDeviceRead.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbDeviceRead.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbDeviceRead.SmallImage")));
      this.rbDeviceRead.Text = "Прочитать";
      this.rbDeviceRead.ToolTip = "Прочитать конфигурацию из устройства";
      this.rbDeviceRead.Click += new System.EventHandler(this.ribbonButton_Click);
      // 
      // rbDeviceWrite
      // 
      this.rbDeviceWrite.Image = ((System.Drawing.Image)(resources.GetObject("rbDeviceWrite.Image")));
      this.rbDeviceWrite.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbDeviceWrite.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbDeviceWrite.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbDeviceWrite.SmallImage")));
      this.rbDeviceWrite.Text = "Записать";
      this.rbDeviceWrite.ToolTip = "Записать конфигурацию в устройство";
      this.rbDeviceWrite.Click += new System.EventHandler(this.ribbonButton_Click);
      // 
      // rbReboot
      // 
      this.rbReboot.Image = ((System.Drawing.Image)(resources.GetObject("rbReboot.Image")));
      this.rbReboot.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbReboot.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbReboot.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbReboot.SmallImage")));
      this.rbReboot.Text = "Перезапустить";
      this.rbReboot.Click += new System.EventHandler(this.ribbonButton_Click);
      // 
      // rbChangePassword
      // 
      this.rbChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("rbChangePassword.Image")));
      this.rbChangePassword.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbChangePassword.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbChangePassword.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbChangePassword.SmallImage")));
      this.rbChangePassword.Text = "Сменить пароль";
      this.rbChangePassword.Click += new System.EventHandler(this.ribbonButton_Click);
      // 
      // rbSwitchOnOff
      // 
      this.rbSwitchOnOff.Image = ((System.Drawing.Image)(resources.GetObject("rbSwitchOnOff.Image")));
      this.rbSwitchOnOff.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbSwitchOnOff.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbSwitchOnOff.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbSwitchOnOff.SmallImage")));
      this.rbSwitchOnOff.Text = "Включить освещение";
      this.rbSwitchOnOff.Click += new System.EventHandler(this.rbSwitchOnOff_Click);
      // 
      // rpSeason
      // 
      this.rpSeason.ButtonMoreEnabled = false;
      this.rpSeason.ButtonMoreVisible = false;
      this.rpSeason.Items.Add(this.rbCopyPlanFromCat);
      this.rpSeason.Items.Add(this.rbSeasonAdd);
      this.rpSeason.Items.Add(this.rbSeasonDelete);
      this.rpSeason.Items.Add(this.rbSeasonEdit);
      this.rpSeason.Text = "Сезон";
      // 
      // rbCopyPlanFromCat
      // 
      this.rbCopyPlanFromCat.Image = ((System.Drawing.Image)(resources.GetObject("rbCopyPlanFromCat.Image")));
      this.rbCopyPlanFromCat.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbCopyPlanFromCat.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbCopyPlanFromCat.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbCopyPlanFromCat.SmallImage")));
      this.rbCopyPlanFromCat.Text = "Заполнить из справочника";
      this.rbCopyPlanFromCat.Click += new System.EventHandler(this.ribbonButton_Click);
      // 
      // rbSeasonAdd
      // 
      this.rbSeasonAdd.Image = ((System.Drawing.Image)(resources.GetObject("rbSeasonAdd.Image")));
      this.rbSeasonAdd.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbSeasonAdd.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbSeasonAdd.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbSeasonAdd.SmallImage")));
      this.rbSeasonAdd.Text = "Добавить сезон";
      this.rbSeasonAdd.Click += new System.EventHandler(this.ribbonButton_Click);
      // 
      // rbSeasonDelete
      // 
      this.rbSeasonDelete.Image = ((System.Drawing.Image)(resources.GetObject("rbSeasonDelete.Image")));
      this.rbSeasonDelete.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbSeasonDelete.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbSeasonDelete.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbSeasonDelete.SmallImage")));
      this.rbSeasonDelete.Text = "Удалить сезон";
      this.rbSeasonDelete.Click += new System.EventHandler(this.ribbonButton_Click);
      // 
      // rbSeasonEdit
      // 
      this.rbSeasonEdit.Image = ((System.Drawing.Image)(resources.GetObject("rbSeasonEdit.Image")));
      this.rbSeasonEdit.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbSeasonEdit.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbSeasonEdit.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbSeasonEdit.SmallImage")));
      this.rbSeasonEdit.Text = "Изменить сезон";
      this.rbSeasonEdit.Click += new System.EventHandler(this.ribbonButton_Click);
      // 
      // rpSchedule
      // 
      this.rpSchedule.ButtonMoreEnabled = false;
      this.rpSchedule.ButtonMoreVisible = false;
      this.rpSchedule.Items.Add(this.rbScheduleAdd);
      this.rpSchedule.Items.Add(this.rbScheduleDelete);
      this.rpSchedule.Items.Add(this.rbScheduleEdit);
      this.rpSchedule.Text = "Расписание";
      // 
      // rbScheduleAdd
      // 
      this.rbScheduleAdd.Image = ((System.Drawing.Image)(resources.GetObject("rbScheduleAdd.Image")));
      this.rbScheduleAdd.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbScheduleAdd.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbScheduleAdd.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbScheduleAdd.SmallImage")));
      this.rbScheduleAdd.Text = "Добавить расписание";
      this.rbScheduleAdd.Click += new System.EventHandler(this.ribbonButton_Click);
      // 
      // rbScheduleDelete
      // 
      this.rbScheduleDelete.Image = ((System.Drawing.Image)(resources.GetObject("rbScheduleDelete.Image")));
      this.rbScheduleDelete.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbScheduleDelete.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbScheduleDelete.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbScheduleDelete.SmallImage")));
      this.rbScheduleDelete.Text = "Удалить расписание";
      this.rbScheduleDelete.Click += new System.EventHandler(this.ribbonButton_Click);
      // 
      // rbScheduleEdit
      // 
      this.rbScheduleEdit.Image = ((System.Drawing.Image)(resources.GetObject("rbScheduleEdit.Image")));
      this.rbScheduleEdit.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbScheduleEdit.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbScheduleEdit.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbScheduleEdit.SmallImage")));
      this.rbScheduleEdit.Text = "Изменить расписание";
      this.rbScheduleEdit.Click += new System.EventHandler(this.ribbonButton_Click);
      // 
      // rpShowScheduler
      // 
      this.rpShowScheduler.ButtonMoreEnabled = false;
      this.rpShowScheduler.ButtonMoreVisible = false;
      this.rpShowScheduler.Items.Add(this.rbShowScheduler);
      this.rpShowScheduler.Text = "";
      // 
      // rbShowScheduler
      // 
      this.rbShowScheduler.Image = ((System.Drawing.Image)(resources.GetObject("rbShowScheduler.Image")));
      this.rbShowScheduler.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbShowScheduler.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbShowScheduler.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbShowScheduler.SmallImage")));
      this.rbShowScheduler.Text = "Просмотр срабатываний расписаний";
      this.rbShowScheduler.Click += new System.EventHandler(this.ribbonButton_Click);
      // 
      // rtTools
      // 
      this.rtTools.Panels.Add(this.rpMultiOperation);
      this.rtTools.Text = "УСТРОЙСТВА";
      // 
      // rpMultiOperation
      // 
      this.rpMultiOperation.ButtonMoreEnabled = false;
      this.rpMultiOperation.ButtonMoreVisible = false;
      this.rpMultiOperation.Items.Add(this.rbMultiWriteConfig);
      this.rpMultiOperation.Items.Add(this.rbMultiSwitchOnOff);
      this.rpMultiOperation.Items.Add(this.rbMultiChangePassword);
      this.rpMultiOperation.Items.Add(this.rbMultiReboot);
      this.rpMultiOperation.Items.Add(this.rbMultiWriteFota);
      this.rpMultiOperation.Items.Add(this.rbMultiWritePatch);
      this.rpMultiOperation.Text = "Пакетные операции с устройствами";
      // 
      // rbMultiWriteConfig
      // 
      this.rbMultiWriteConfig.Image = ((System.Drawing.Image)(resources.GetObject("rbMultiWriteConfig.Image")));
      this.rbMultiWriteConfig.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbMultiWriteConfig.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbMultiWriteConfig.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbMultiWriteConfig.SmallImage")));
      this.rbMultiWriteConfig.Text = "Запись конфигурации";
      this.rbMultiWriteConfig.ToolTip = "Запись плана освещения в произвольное количество устройств";
      this.rbMultiWriteConfig.Click += new System.EventHandler(this.rbMultiWriteLightPlan_Click);
      // 
      // rbMultiSwitchOnOff
      // 
      this.rbMultiSwitchOnOff.Image = ((System.Drawing.Image)(resources.GetObject("rbMultiSwitchOnOff.Image")));
      this.rbMultiSwitchOnOff.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbMultiSwitchOnOff.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbMultiSwitchOnOff.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbMultiSwitchOnOff.SmallImage")));
      this.rbMultiSwitchOnOff.Text = "Вкл/Откл освещения";
      this.rbMultiSwitchOnOff.ToolTip = "Включить/Отключить освещение на произвольном количестве устройств";
      this.rbMultiSwitchOnOff.Click += new System.EventHandler(this.rbMultiSwitchOnOff_Click);
      // 
      // rbMultiChangePassword
      // 
      this.rbMultiChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("rbMultiChangePassword.Image")));
      this.rbMultiChangePassword.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbMultiChangePassword.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbMultiChangePassword.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbMultiChangePassword.SmallImage")));
      this.rbMultiChangePassword.Text = "Сменить пароль";
      this.rbMultiChangePassword.ToolTip = "Сменить пароль на произвольном количестве устройств";
      this.rbMultiChangePassword.Click += new System.EventHandler(this.rbMultiChangePassword_Click);
      // 
      // rbMultiReboot
      // 
      this.rbMultiReboot.Image = ((System.Drawing.Image)(resources.GetObject("rbMultiReboot.Image")));
      this.rbMultiReboot.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbMultiReboot.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbMultiReboot.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbMultiReboot.SmallImage")));
      this.rbMultiReboot.Text = "Перезагрузка устройств";
      this.rbMultiReboot.ToolTip = "Перезагрузка произвольного количества устройств";
      this.rbMultiReboot.Click += new System.EventHandler(this.rbMultiReboot_Click);
      // 
      // rbMultiWriteFota
      // 
      this.rbMultiWriteFota.Image = ((System.Drawing.Image)(resources.GetObject("rbMultiWriteFota.Image")));
      this.rbMultiWriteFota.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbMultiWriteFota.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
      this.rbMultiWriteFota.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbMultiWriteFota.SmallImage")));
      this.rbMultiWriteFota.Text = "Запись ПО контроллера";
      this.rbMultiWriteFota.ToolTip = "Запись ПО контроллера в произвольное количество устройств";
      this.rbMultiWriteFota.Click += new System.EventHandler(this.rbMultiWriteFota_Click);
      // 
      // rbMultiWritePatch
      // 
      this.rbMultiWritePatch.Image = ((System.Drawing.Image)(resources.GetObject("rbMultiWritePatch.Image")));
      this.rbMultiWritePatch.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbMultiWritePatch.SmallImage")));
      this.rbMultiWritePatch.Text = "Запись патча ядра контроллера";
      this.rbMultiWritePatch.Click += new System.EventHandler(this.rbMultiWritePatch_Click);
      // 
      // rtView
      // 
      this.rtView.Panels.Add(this.rpView);
      this.rtView.Text = "ВИД";
      // 
      // rpView
      // 
      this.rpView.ButtonMoreEnabled = false;
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
      this.statusStrip.Location = new System.Drawing.Point(0, 626);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(918, 22);
      this.statusStrip.TabIndex = 1;
      // 
      // scMain
      // 
      this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.scMain.Location = new System.Drawing.Point(0, 169);
      this.scMain.Name = "scMain";
      // 
      // scMain.Panel1
      // 
      this.scMain.Panel1.Controls.Add(this.tv);
      this.scMain.Panel1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
      this.scMain.Panel1MinSize = 150;
      // 
      // scMain.Panel2
      // 
      this.scMain.Panel2.Controls.Add(this.tcZtpConfig);
      this.scMain.Size = new System.Drawing.Size(918, 457);
      this.scMain.SplitterDistance = 234;
      this.scMain.TabIndex = 2;
      // 
      // tv
      // 
      this.tv.AllowKeyASelectAll = false;
      this.tv.AllowKeyboardModKeyAlt = false;
      this.tv.AllowKeyEExpandAll = false;
      this.tv.AllowKeyF2LabelEditing = false;
      this.tv.AllowMouseModKeyAlt = false;
      this.tv.AutoCreateTree = false;
      this.tv.CheckedNodes = ((System.Collections.Hashtable)(resources.GetObject("tv.CheckedNodes")));
      this.tv.DevKind = Ztp.Model.DeviceKind.Unknown;
      this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tv.FullRowSelect = true;
      this.tv.HideSelection = false;
      this.tv.ImageIndex = 0;
      this.tv.ImageList = this.imlTv;
      this.tv.Location = new System.Drawing.Point(4, 0);
      this.tv.MultiSelect = Bss.Windows.Forms.Mstv.TreeViewMultiSelect.Classic;
      this.tv.Name = "tv";
      this.tv.RubberbandGradientBlend = new Bss.Windows.Forms.Mstv.MWRubberbandGradientBlend[0];
      this.tv.RubberbandGradientColorBlend = new Bss.Windows.Forms.Mstv.MWRubberbandGradientColorBlend[0];
      this.tv.SelectedImageIndex = 0;
      this.tv.SelNodes = ((System.Collections.Hashtable)(resources.GetObject("tv.SelNodes")));
      this.tv.Size = new System.Drawing.Size(230, 457);
      this.tv.TabIndex = 0;
      this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
      this.tv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tv_KeyDown);
      this.tv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tv_MouseClick);
      this.tv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tv_MouseDoubleClick);
      // 
      // imlTv
      // 
      this.imlTv.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTv.ImageStream")));
      this.imlTv.TransparentColor = System.Drawing.Color.Transparent;
      this.imlTv.Images.SetKeyName(0, "folders_explorer.png");
      this.imlTv.Images.SetKeyName(1, "folder.png");
      this.imlTv.Images.SetKeyName(2, "PCI-card.png");
      this.imlTv.Images.SetKeyName(3, "PCI-card_error.png");
      // 
      // tcZtpConfig
      // 
      this.tcZtpConfig.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tcZtpConfig.Location = new System.Drawing.Point(0, 0);
      this.tcZtpConfig.MenuRenderer = null;
      this.tcZtpConfig.Name = "tcZtpConfig";
      this.tcZtpConfig.Size = new System.Drawing.Size(680, 457);
      this.tcZtpConfig.TabCloseButtonImage = null;
      this.tcZtpConfig.TabCloseButtonImageDisabled = null;
      this.tcZtpConfig.TabCloseButtonImageHot = null;
      this.tcZtpConfig.TabIndex = 0;
      // 
      // contextMenu
      // 
      this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiDeviceOpen,
            this.toolStripMenuItem1,
            this.cmiAddFolder,
            this.cmiDeleteFolder,
            this.cmiEditFolder,
            this.toolStripMenuItem2,
            this.cmiAddDevice,
            this.cmiDropDownAddDevice,
            this.cmiDeleteDevice,
            this.cmiEditDevice,
            this.toolStripMenuItem3,
            this.cmiCopyNode,
            this.cmiPasteNode});
      this.contextMenu.Name = "contextMenu";
      this.contextMenu.Size = new System.Drawing.Size(216, 242);
      this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
      // 
      // cmiDeviceOpen
      // 
      this.cmiDeviceOpen.Image = ((System.Drawing.Image)(resources.GetObject("cmiDeviceOpen.Image")));
      this.cmiDeviceOpen.Name = "cmiDeviceOpen";
      this.cmiDeviceOpen.Size = new System.Drawing.Size(215, 22);
      this.cmiDeviceOpen.Text = "Открыть";
      this.cmiDeviceOpen.Click += new System.EventHandler(this.rbDeviceOpen_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(212, 6);
      // 
      // cmiAddFolder
      // 
      this.cmiAddFolder.Image = ((System.Drawing.Image)(resources.GetObject("cmiAddFolder.Image")));
      this.cmiAddFolder.Name = "cmiAddFolder";
      this.cmiAddFolder.Size = new System.Drawing.Size(215, 22);
      this.cmiAddFolder.Text = "Добавить папку";
      this.cmiAddFolder.Click += new System.EventHandler(this.rbAddFolder_Click);
      // 
      // cmiDeleteFolder
      // 
      this.cmiDeleteFolder.Image = ((System.Drawing.Image)(resources.GetObject("cmiDeleteFolder.Image")));
      this.cmiDeleteFolder.Name = "cmiDeleteFolder";
      this.cmiDeleteFolder.Size = new System.Drawing.Size(215, 22);
      this.cmiDeleteFolder.Text = "Удалить папку";
      this.cmiDeleteFolder.Click += new System.EventHandler(this.rbDeleteFolder_Click);
      // 
      // cmiEditFolder
      // 
      this.cmiEditFolder.Image = ((System.Drawing.Image)(resources.GetObject("cmiEditFolder.Image")));
      this.cmiEditFolder.Name = "cmiEditFolder";
      this.cmiEditFolder.Size = new System.Drawing.Size(215, 22);
      this.cmiEditFolder.Text = "Изменить папку";
      this.cmiEditFolder.Click += new System.EventHandler(this.rbEditFolder_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(212, 6);
      // 
      // cmiAddDevice
      // 
      this.cmiAddDevice.Image = ((System.Drawing.Image)(resources.GetObject("cmiAddDevice.Image")));
      this.cmiAddDevice.Name = "cmiAddDevice";
      this.cmiAddDevice.Size = new System.Drawing.Size(215, 22);
      this.cmiAddDevice.Text = "Добавить устройство";
      this.cmiAddDevice.Click += new System.EventHandler(this.rbAddDevice_Click);
      // 
      // cmiDropDownAddDevice
      // 
      this.cmiDropDownAddDevice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiAddDeviceManual,
            this.cmiAddDeviceEstTools});
      this.cmiDropDownAddDevice.Image = ((System.Drawing.Image)(resources.GetObject("cmiDropDownAddDevice.Image")));
      this.cmiDropDownAddDevice.Name = "cmiDropDownAddDevice";
      this.cmiDropDownAddDevice.Size = new System.Drawing.Size(215, 22);
      this.cmiDropDownAddDevice.Text = "Добавить устройство";
      // 
      // cmiAddDeviceManual
      // 
      this.cmiAddDeviceManual.Image = ((System.Drawing.Image)(resources.GetObject("cmiAddDeviceManual.Image")));
      this.cmiAddDeviceManual.Name = "cmiAddDeviceManual";
      this.cmiAddDeviceManual.Size = new System.Drawing.Size(192, 22);
      this.cmiAddDeviceManual.Text = "Добавить вручную";
      this.cmiAddDeviceManual.Click += new System.EventHandler(this.rbAddDevice_Click);
      // 
      // cmiAddDeviceEstTools
      // 
      this.cmiAddDeviceEstTools.Image = ((System.Drawing.Image)(resources.GetObject("cmiAddDeviceEstTools.Image")));
      this.cmiAddDeviceEstTools.Name = "cmiAddDeviceEstTools";
      this.cmiAddDeviceEstTools.Size = new System.Drawing.Size(192, 22);
      this.cmiAddDeviceEstTools.Text = "Добавить из EST Tools";
      this.cmiAddDeviceEstTools.Click += new System.EventHandler(this.rbAddDeviceEstTools_Click);
      // 
      // cmiDeleteDevice
      // 
      this.cmiDeleteDevice.Image = ((System.Drawing.Image)(resources.GetObject("cmiDeleteDevice.Image")));
      this.cmiDeleteDevice.Name = "cmiDeleteDevice";
      this.cmiDeleteDevice.Size = new System.Drawing.Size(215, 22);
      this.cmiDeleteDevice.Text = "Удалить устройство";
      this.cmiDeleteDevice.Click += new System.EventHandler(this.rbDeleteDevice_Click);
      // 
      // cmiEditDevice
      // 
      this.cmiEditDevice.Image = ((System.Drawing.Image)(resources.GetObject("cmiEditDevice.Image")));
      this.cmiEditDevice.Name = "cmiEditDevice";
      this.cmiEditDevice.Size = new System.Drawing.Size(215, 22);
      this.cmiEditDevice.Text = "Изменить устройство";
      this.cmiEditDevice.Click += new System.EventHandler(this.rbEditDevice_Click);
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new System.Drawing.Size(212, 6);
      // 
      // cmiCopyNode
      // 
      this.cmiCopyNode.Image = ((System.Drawing.Image)(resources.GetObject("cmiCopyNode.Image")));
      this.cmiCopyNode.Name = "cmiCopyNode";
      this.cmiCopyNode.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.cmiCopyNode.Size = new System.Drawing.Size(215, 22);
      this.cmiCopyNode.Text = "Скопировать узел";
      this.cmiCopyNode.Click += new System.EventHandler(this.rbCopyNode_Click);
      // 
      // cmiPasteNode
      // 
      this.cmiPasteNode.Image = ((System.Drawing.Image)(resources.GetObject("cmiPasteNode.Image")));
      this.cmiPasteNode.Name = "cmiPasteNode";
      this.cmiPasteNode.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
      this.cmiPasteNode.Size = new System.Drawing.Size(215, 22);
      this.cmiPasteNode.Text = "Вставить узел";
      this.cmiPasteNode.Click += new System.EventHandler(this.rbPasteNode_Click);
      // 
      // imlTabControl
      // 
      this.imlTabControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTabControl.ImageStream")));
      this.imlTabControl.TransparentColor = System.Drawing.Color.Transparent;
      this.imlTabControl.Images.SetKeyName(0, "bricks.png");
      this.imlTabControl.Images.SetKeyName(1, "history.png");
      this.imlTabControl.Images.SetKeyName(2, "port.png");
      this.imlTabControl.Images.SetKeyName(3, "list.png");
      this.imlTabControl.Images.SetKeyName(4, "tree_list.png");
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(918, 648);
      this.Controls.Add(this.scMain);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.ribbon);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MinimumSize = new System.Drawing.Size(900, 600);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Менеджер астрономических реле";
      this.scMain.Panel1.ResumeLayout(false);
      this.scMain.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
      this.scMain.ResumeLayout(false);
      this.contextMenu.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Ribbon ribbon;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.SplitContainer scMain;
    private System.Windows.Forms.ImageList imlTv;
    private System.Windows.Forms.RibbonTab rtDevices;
    private System.Windows.Forms.RibbonPanel rpEditFolder;
    private System.Windows.Forms.RibbonButton rbAddFolder;
    private System.Windows.Forms.RibbonButton rbDeleteFolder;
    private System.Windows.Forms.RibbonButton rbEditFolder;
    private System.Windows.Forms.RibbonPanel rpEditDevice;
    private System.Windows.Forms.RibbonButton rbAddDevice;
    private System.Windows.Forms.RibbonButton rbDeleteDevice;
    private System.Windows.Forms.RibbonButton rbEditDevice;
    private System.Windows.Forms.RibbonPanel rpClipboard;
    private System.Windows.Forms.RibbonButton rbCopyNode;
    private System.Windows.Forms.RibbonButton rbPasteNode;
    private System.Windows.Forms.RibbonButton rbSetting;
    private System.Windows.Forms.RibbonButton rbDropDownAddDevice;
    private System.Windows.Forms.RibbonButton rbAddDeviceManual;
    private System.Windows.Forms.RibbonButton rbAddDeviceEstTools;
    private System.Windows.Forms.RibbonPanel rpCatalog;
    private System.Windows.Forms.RibbonButton rbCatalogs;
    private System.Windows.Forms.RibbonButton rbCatScheduler;
    private System.Windows.Forms.RibbonTab rtConfig;
    private System.Windows.Forms.RibbonButton ribbonButton1;
    private System.Windows.Forms.RibbonButton rbAbout;
    private System.Windows.Forms.RibbonPanel rpDevice;
    private System.Windows.Forms.RibbonButton rbDeviceRead;
    private System.Windows.Forms.RibbonButton rbDeviceWrite;
    private System.Windows.Forms.ImageList imlTabControl;
    private System.Windows.Forms.RibbonTab rtView;
    private System.Windows.Forms.RibbonPanel rpView;
    private System.Windows.Forms.RibbonButton rbViewDebug;
    private System.Windows.Forms.RibbonButton rbViewState;
    private ZtpManager.Controls.DeviceTreeView tv;
    private System.Windows.Forms.RibbonPanel rpSeason;
    private System.Windows.Forms.RibbonButton rbSeasonAdd;
    private System.Windows.Forms.RibbonButton rbSeasonDelete;
    private System.Windows.Forms.RibbonButton rbSeasonEdit;
    private System.Windows.Forms.RibbonPanel rpSchedule;
    private System.Windows.Forms.RibbonButton rbScheduleAdd;
    private System.Windows.Forms.RibbonButton rbScheduleDelete;
    private System.Windows.Forms.RibbonButton rbScheduleEdit;
    private MdiTabControl.TabControl tcZtpConfig;
    private System.Windows.Forms.RibbonButton rbDeviceOpen;
    private System.Windows.Forms.RibbonTab rtTools;
    private System.Windows.Forms.RibbonPanel rpMultiOperation;
    private System.Windows.Forms.RibbonButton rbMultiWriteConfig;
    private System.Windows.Forms.RibbonButton rbMultiWriteFota;
    private System.Windows.Forms.RibbonButton rbObjectList;
    private System.Windows.Forms.RibbonButton rbReboot;
    private System.Windows.Forms.RibbonButton rbChangePassword;
    private System.Windows.Forms.RibbonButton rbSwitchOnOff;
    private System.Windows.Forms.RibbonButton rbMultiReboot;
    private System.Windows.Forms.RibbonButton rbCopyPlanFromCat;
    private System.Windows.Forms.RibbonPanel rpShowScheduler;
    private System.Windows.Forms.RibbonButton rbShowScheduler;
    private System.Windows.Forms.ContextMenuStrip contextMenu;
    private System.Windows.Forms.ToolStripMenuItem cmiDeviceOpen;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem cmiAddFolder;
    private System.Windows.Forms.ToolStripMenuItem cmiDeleteFolder;
    private System.Windows.Forms.ToolStripMenuItem cmiEditFolder;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem cmiAddDevice;
    private System.Windows.Forms.ToolStripMenuItem cmiDropDownAddDevice;
    private System.Windows.Forms.ToolStripMenuItem cmiDeleteDevice;
    private System.Windows.Forms.ToolStripMenuItem cmiEditDevice;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem cmiCopyNode;
    private System.Windows.Forms.ToolStripMenuItem cmiPasteNode;
    private System.Windows.Forms.ToolStripMenuItem cmiAddDeviceManual;
    private System.Windows.Forms.ToolStripMenuItem cmiAddDeviceEstTools;
    private System.Windows.Forms.RibbonButton rbMultiSwitchOnOff;
    private System.Windows.Forms.RibbonButton rbMultiChangePassword;
    private System.Windows.Forms.RibbonPanel rpAudit;
    private System.Windows.Forms.RibbonButton rbAudit;
    private System.Windows.Forms.RibbonButton rbSyncEst;
    private System.Windows.Forms.RibbonButton rbSummary;
    private System.Windows.Forms.RibbonButton rbLastOp;
    private System.Windows.Forms.RibbonButton rbMultiWritePatch;
  }
}

