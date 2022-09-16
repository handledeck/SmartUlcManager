namespace UlcWin
{
  partial class LoadForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadForm));
      PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.tsSelectShow = new System.Windows.Forms.ToolStripSplitButton();
      this.showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.showNotTrueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemNetLow = new System.Windows.Forms.ToolStripMenuItem();
      this.tsDwnUpdate_1 = new System.Windows.Forms.ToolStripDropDownButton();
      this.tsMenuItem_Pgrm_1 = new System.Windows.Forms.ToolStripMenuItem();
      this.tsMenuItem_Patch_1 = new System.Windows.Forms.ToolStripMenuItem();
      this.geniralSettingsToolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
      this.tsComboBoxDev_1 = new System.Windows.Forms.ToolStripComboBox();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.tsSelectedItems_1 = new System.Windows.Forms.ToolStripDropDownButton();
      this.tsSelectAll_1 = new System.Windows.Forms.ToolStripMenuItem();
      this.tsDeselectAll_1 = new System.Windows.Forms.ToolStripMenuItem();
      this.tsUpdate_1 = new System.Windows.Forms.ToolStripButton();
      this.tsBtnConnect = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.tsBtnUsersEdit = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.tsBtnStatistics = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.tsBtnEventLog = new System.Windows.Forms.ToolStripButton();
      this.tsBtnAbout = new System.Windows.Forms.ToolStripButton();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.panel2 = new System.Windows.Forms.Panel();
      this.treeView1 = new System.Windows.Forms.TreeView();
      this.treeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.tsMnuAddRootItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tsMnuTreeAddItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tsMnuTreeDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.tsMnuTreeEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.tsTreePanel = new System.Windows.Forms.ToolStrip();
      this.tsTreeBtnEdit = new System.Windows.Forms.ToolStripButton();
      this.tsTreeBtnDelete = new System.Windows.Forms.ToolStripButton();
      this.tsTreeBtnAdd = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.tsTreeBtnAddRoot = new System.Windows.Forms.ToolStripButton();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.checkBoxComboBox1 = new PresentationControls.CheckBoxComboBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.LstViewItm = new System.Windows.Forms.ListView();
      this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.UType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Signal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.soft = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.logs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.core = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.imai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.schedule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.rs485 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.traph = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.active = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.isLight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.comments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.LvMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ctxMenuUpdateCurrent = new System.Windows.Forms.ToolStripMenuItem();
      this.ctxMenuUpdateSelected = new System.Windows.Forms.ToolStripMenuItem();
      this.ctxMenuUpdateNotTrue = new System.Windows.Forms.ToolStripMenuItem();
      this.ctxMenuUpdateAll = new System.Windows.Forms.ToolStripMenuItem();
      this.tsMenuSeparate = new System.Windows.Forms.ToolStripSeparator();
      this.ctxMenuReadCurrentLog = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ctxMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
      this.ctxMenuItemChange = new System.Windows.Forms.ToolStripMenuItem();
      this.ctxMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.ctxSeparateEdit = new System.Windows.Forms.ToolStripSeparator();
      this.ctxMenuPingCurrentItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ctxMenuAllPingItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ctxSeparatePing = new System.Windows.Forms.ToolStripSeparator();
      this.ctxMenuAtCommand = new System.Windows.Forms.ToolStripMenuItem();
      this.ctxMenuMeter = new System.Windows.Forms.ToolStripMenuItem();
      this.ctxNotTrueMeter = new System.Windows.Forms.ToolStripMenuItem();
      this.usrFesStatistics1 = new UlcWin.ui.UsrFesStatistics();
      this.tsResView = new System.Windows.Forms.ToolStrip();
      this.tsComboBoxDev = new System.Windows.Forms.ToolStripComboBox();
      this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
      this.tsBtnExport = new System.Windows.Forms.ToolStripButton();
      this.tsDwnUpdate = new System.Windows.Forms.ToolStripDropDownButton();
      this.tsMenuItem_Pgrm = new System.Windows.Forms.ToolStripMenuItem();
      this.tsMenuItem_Patch = new System.Windows.Forms.ToolStripMenuItem();
      this.geniralSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tsMenuItemReboot = new System.Windows.Forms.ToolStripMenuItem();
      this.tsSelectedItems = new System.Windows.Forms.ToolStripDropDownButton();
      this.tsSelectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.tsDeselectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.tsBtnEventShowHide = new System.Windows.Forms.ToolStripButton();
      this.tsUpdate = new System.Windows.Forms.ToolStripButton();
      this.tsLblFind = new System.Windows.Forms.ToolStripLabel();
      this.LstViewEvent = new System.Windows.Forms.ListView();
      this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Evt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.tsEvent = new System.Windows.Forms.ToolStrip();
      this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
      this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
      this.lblNotExist = new System.Windows.Forms.Label();
      this.tsStatusLbl = new System.Windows.Forms.StatusStrip();
      this.tsStsLabelAll = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsStsLblNotTrue = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsStsNetBad = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsStsRssBad = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsStsIMEI = new System.Windows.Forms.ToolStripStatusLabel();
      this.imlTc = new System.Windows.Forms.ImageList(this.components);
      this.imageList2 = new System.Windows.Forms.ImageList(this.components);
      this.helpProvider1 = new System.Windows.Forms.HelpProvider();
      this.toolStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.treeMenu.SuspendLayout();
      this.tsTreePanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.LvMenu.SuspendLayout();
      this.tsResView.SuspendLayout();
      this.tsEvent.SuspendLayout();
      this.tsStatusLbl.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      this.toolStrip1.AutoSize = false;
      this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
      this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.toolStrip1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(10, 12, 2, 20);
      this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSelectShow,
            this.tsDwnUpdate_1,
            this.tsComboBoxDev_1,
            this.toolStripSeparator5,
            this.tsSelectedItems_1,
            this.tsUpdate_1,
            this.tsBtnConnect,
            this.toolStripSeparator7,
            this.tsBtnUsersEdit,
            this.toolStripSeparator2,
            this.tsBtnStatistics,
            this.toolStripSeparator4,
            this.tsBtnEventLog,
            this.tsBtnAbout});
      this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(1924, 37);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // tsSelectShow
      // 
      this.tsSelectShow.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsSelectShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsSelectShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllToolStripMenuItem,
            this.showNotTrueToolStripMenuItem,
            this.toolStripMenuItemNetLow});
      this.tsSelectShow.Image = ((System.Drawing.Image)(resources.GetObject("tsSelectShow.Image")));
      this.tsSelectShow.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsSelectShow.Margin = new System.Windows.Forms.Padding(10, 0, 30, 1);
      this.tsSelectShow.Name = "tsSelectShow";
      this.tsSelectShow.Size = new System.Drawing.Size(39, 36);
      this.tsSelectShow.Text = "Обзор";
      this.tsSelectShow.Visible = false;
      // 
      // showAllToolStripMenuItem
      // 
      this.showAllToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showAllToolStripMenuItem.Image")));
      this.showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
      this.showAllToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
      this.showAllToolStripMenuItem.Text = "Показать все";
      this.showAllToolStripMenuItem.Click += new System.EventHandler(this.showAllToolStripMenuItem_Click);
      // 
      // showNotTrueToolStripMenuItem
      // 
      this.showNotTrueToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showNotTrueToolStripMenuItem.Image")));
      this.showNotTrueToolStripMenuItem.Name = "showNotTrueToolStripMenuItem";
      this.showNotTrueToolStripMenuItem.Size = new System.Drawing.Size(354, 26);
      this.showNotTrueToolStripMenuItem.Text = "Показать недостоверные";
      this.showNotTrueToolStripMenuItem.Click += new System.EventHandler(this.showNotTrueToolStripMenuItem_Click);
      // 
      // toolStripMenuItemNetLow
      // 
      this.toolStripMenuItemNetLow.Image = global::UlcWin.Properties.Resources.shield_yellow;
      this.toolStripMenuItemNetLow.Name = "toolStripMenuItemNetLow";
      this.toolStripMenuItemNetLow.Size = new System.Drawing.Size(354, 26);
      this.toolStripMenuItemNetLow.Text = "Показать низкий уровень сигнала";
      this.toolStripMenuItemNetLow.Click += new System.EventHandler(this.toolStripMenuItemNetLow_Click);
      // 
      // tsDwnUpdate_1
      // 
      this.tsDwnUpdate_1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsDwnUpdate_1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsDwnUpdate_1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItem_Pgrm_1,
            this.tsMenuItem_Patch_1,
            this.geniralSettingsToolStripMenuItem_1});
      this.tsDwnUpdate_1.Image = global::UlcWin.Properties.Resources.gear_replace;
      this.tsDwnUpdate_1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsDwnUpdate_1.Name = "tsDwnUpdate_1";
      this.tsDwnUpdate_1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
      this.tsDwnUpdate_1.RightToLeftAutoMirrorImage = true;
      this.tsDwnUpdate_1.Size = new System.Drawing.Size(39, 34);
      this.tsDwnUpdate_1.Text = "Обновление";
      this.tsDwnUpdate_1.Visible = false;
      // 
      // tsMenuItem_Pgrm_1
      // 
      this.tsMenuItem_Pgrm_1.Image = global::UlcWin.Properties.Resources.document_refresh;
      this.tsMenuItem_Pgrm_1.Name = "tsMenuItem_Pgrm_1";
      this.tsMenuItem_Pgrm_1.Size = new System.Drawing.Size(260, 26);
      this.tsMenuItem_Pgrm_1.Text = "Обновить прошивку";
      this.tsMenuItem_Pgrm_1.Click += new System.EventHandler(this.tsMenuItem_Pgrm_Click);
      // 
      // tsMenuItem_Patch_1
      // 
      this.tsMenuItem_Patch_1.Image = global::UlcWin.Properties.Resources.document_gear;
      this.tsMenuItem_Patch_1.Name = "tsMenuItem_Patch_1";
      this.tsMenuItem_Patch_1.Size = new System.Drawing.Size(260, 26);
      this.tsMenuItem_Patch_1.Text = "Обновить патч";
      this.tsMenuItem_Patch_1.Click += new System.EventHandler(this.tsMenuItem_Patch_Click);
      // 
      // geniralSettingsToolStripMenuItem_1
      // 
      this.geniralSettingsToolStripMenuItem_1.Image = global::UlcWin.Properties.Resources.document_add;
      this.geniralSettingsToolStripMenuItem_1.Name = "geniralSettingsToolStripMenuItem_1";
      this.geniralSettingsToolStripMenuItem_1.Size = new System.Drawing.Size(260, 26);
      this.geniralSettingsToolStripMenuItem_1.Text = "Запись конфигурации";
      this.geniralSettingsToolStripMenuItem_1.Click += new System.EventHandler(this.geniralSettingsToolStripMenuItem_Click);
      // 
      // tsComboBoxDev_1
      // 
      this.tsComboBoxDev_1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsComboBoxDev_1.Items.AddRange(new object[] {
            "РВП-18",
            "ULC 02",
            "Все"});
      this.tsComboBoxDev_1.Margin = new System.Windows.Forms.Padding(5, 0, 20, 0);
      this.tsComboBoxDev_1.Name = "tsComboBoxDev_1";
      this.tsComboBoxDev_1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
      this.tsComboBoxDev_1.Size = new System.Drawing.Size(75, 37);
      this.tsComboBoxDev_1.Visible = false;
      this.tsComboBoxDev_1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.toolStripSeparator5.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new System.Drawing.Size(6, 37);
      // 
      // tsSelectedItems_1
      // 
      this.tsSelectedItems_1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsSelectedItems_1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsSelectedItems_1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSelectAll_1,
            this.tsDeselectAll_1});
      this.tsSelectedItems_1.Image = global::UlcWin.Properties.Resources.btnUncheck;
      this.tsSelectedItems_1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsSelectedItems_1.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
      this.tsSelectedItems_1.Name = "tsSelectedItems_1";
      this.tsSelectedItems_1.Size = new System.Drawing.Size(34, 34);
      this.tsSelectedItems_1.Text = "tsSelectedItems";
      this.tsSelectedItems_1.Visible = false;
      // 
      // tsSelectAll_1
      // 
      this.tsSelectAll_1.Image = global::UlcWin.Properties.Resources.btnCheck;
      this.tsSelectAll_1.Name = "tsSelectAll_1";
      this.tsSelectAll_1.Size = new System.Drawing.Size(186, 26);
      this.tsSelectAll_1.Text = "Выбрать все";
      this.tsSelectAll_1.Click += new System.EventHandler(this.tsSelectAll_Click);
      // 
      // tsDeselectAll_1
      // 
      this.tsDeselectAll_1.Image = global::UlcWin.Properties.Resources.btnUncheck;
      this.tsDeselectAll_1.Name = "tsDeselectAll_1";
      this.tsDeselectAll_1.Size = new System.Drawing.Size(186, 26);
      this.tsDeselectAll_1.Text = "Отмена";
      this.tsDeselectAll_1.Click += new System.EventHandler(this.tsDeselectAll_Click);
      // 
      // tsUpdate_1
      // 
      this.tsUpdate_1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsUpdate_1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsUpdate_1.Image = ((System.Drawing.Image)(resources.GetObject("tsUpdate_1.Image")));
      this.tsUpdate_1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsUpdate_1.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
      this.tsUpdate_1.Name = "tsUpdate_1";
      this.tsUpdate_1.Size = new System.Drawing.Size(29, 34);
      this.tsUpdate_1.Text = "Обновить";
      this.tsUpdate_1.Visible = false;
      this.tsUpdate_1.Click += new System.EventHandler(this.tsUpdate_Click);
      // 
      // tsBtnConnect
      // 
      this.tsBtnConnect.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tsBtnConnect.Image = global::UlcWin.Properties.Resources.server_connection;
      this.tsBtnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsBtnConnect.Name = "tsBtnConnect";
      this.tsBtnConnect.Size = new System.Drawing.Size(129, 34);
      this.tsBtnConnect.Text = "Подключится";
      this.tsBtnConnect.ToolTipText = "Подключение";
      this.tsBtnConnect.Click += new System.EventHandler(this.toolStripButton3_Click_1);
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new System.Drawing.Size(6, 37);
      // 
      // tsBtnUsersEdit
      // 
      this.tsBtnUsersEdit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tsBtnUsersEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnUsersEdit.Image")));
      this.tsBtnUsersEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsBtnUsersEdit.Name = "tsBtnUsersEdit";
      this.tsBtnUsersEdit.Size = new System.Drawing.Size(133, 34);
      this.tsBtnUsersEdit.Text = "Пользователи";
      this.tsBtnUsersEdit.Click += new System.EventHandler(this.toolStripButton3_Click_2);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 37);
      // 
      // tsBtnStatistics
      // 
      this.tsBtnStatistics.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tsBtnStatistics.Image = global::UlcWin.Properties.Resources.chart;
      this.tsBtnStatistics.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsBtnStatistics.Name = "tsBtnStatistics";
      this.tsBtnStatistics.Size = new System.Drawing.Size(113, 34);
      this.tsBtnStatistics.Text = "Статистика";
      this.tsBtnStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.tsBtnStatistics.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
      this.tsBtnStatistics.Click += new System.EventHandler(this.toolStripButton4_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(6, 37);
      // 
      // tsBtnEventLog
      // 
      this.tsBtnEventLog.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tsBtnEventLog.Image = global::UlcWin.Properties.Resources.text_marked;
      this.tsBtnEventLog.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsBtnEventLog.Name = "tsBtnEventLog";
      this.tsBtnEventLog.Size = new System.Drawing.Size(90, 34);
      this.tsBtnEventLog.Text = "Журнал";
      this.tsBtnEventLog.ToolTipText = "Журнал событий";
      this.tsBtnEventLog.Click += new System.EventHandler(this.toolStripButton3_Click_4);
      // 
      // tsBtnAbout
      // 
      this.tsBtnAbout.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tsBtnAbout.Image = global::UlcWin.Properties.Resources.about;
      this.tsBtnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsBtnAbout.Name = "tsBtnAbout";
      this.tsBtnAbout.Size = new System.Drawing.Size(127, 34);
      this.tsBtnAbout.Text = "О программе";
      this.tsBtnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.tsBtnAbout.ToolTipText = "О программе";
      this.tsBtnAbout.Click += new System.EventHandler(this.tsBtnAbout_Click);
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 37);
      this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.panel2);
      this.splitContainer1.Panel1.Controls.Add(this.tsTreePanel);
      this.splitContainer1.Panel1.Resize += new System.EventHandler(this.splitContainer1_Panel1_Resize);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
      this.splitContainer1.Size = new System.Drawing.Size(1924, 567);
      this.splitContainer1.SplitterDistance = 383;
      this.splitContainer1.SplitterWidth = 5;
      this.splitContainer1.TabIndex = 2;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.treeView1);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(0, 27);
      this.panel2.Margin = new System.Windows.Forms.Padding(4);
      this.panel2.Name = "panel2";
      this.panel2.Padding = new System.Windows.Forms.Padding(1);
      this.panel2.Size = new System.Drawing.Size(383, 540);
      this.panel2.TabIndex = 1;
      // 
      // treeView1
      // 
      this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.treeView1.ContextMenuStrip = this.treeMenu;
      this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeView1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.treeView1.FullRowSelect = true;
      this.treeView1.HideSelection = false;
      this.treeView1.ImageIndex = 17;
      this.treeView1.ImageList = this.imageList1;
      this.treeView1.Location = new System.Drawing.Point(1, 1);
      this.treeView1.Margin = new System.Windows.Forms.Padding(0);
      this.treeView1.Name = "treeView1";
      this.treeView1.SelectedImageIndex = 0;
      this.treeView1.Size = new System.Drawing.Size(381, 538);
      this.treeView1.StateImageList = this.imageList1;
      this.treeView1.TabIndex = 100000;
      this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
      this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
      this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
      // 
      // treeMenu
      // 
      this.treeMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.treeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMnuAddRootItem,
            this.tsMnuTreeAddItem,
            this.tsMnuTreeDeleteItem,
            this.toolStripSeparator6,
            this.tsMnuTreeEdit});
      this.treeMenu.Name = "contextMenuStrip1";
      this.treeMenu.Size = new System.Drawing.Size(283, 114);
      // 
      // tsMnuAddRootItem
      // 
      this.tsMnuAddRootItem.Image = global::UlcWin.Properties.Resources.table_sql_add;
      this.tsMnuAddRootItem.Name = "tsMnuAddRootItem";
      this.tsMnuAddRootItem.Size = new System.Drawing.Size(282, 26);
      this.tsMnuAddRootItem.Text = "Добавить корневой элемент";
      this.tsMnuAddRootItem.Click += new System.EventHandler(this.tsAddRootItem_Click);
      // 
      // tsMnuTreeAddItem
      // 
      this.tsMnuTreeAddItem.Image = global::UlcWin.Properties.Resources.add2;
      this.tsMnuTreeAddItem.Name = "tsMnuTreeAddItem";
      this.tsMnuTreeAddItem.Size = new System.Drawing.Size(282, 26);
      this.tsMnuTreeAddItem.Text = "Добавить элемент";
      this.tsMnuTreeAddItem.Click += new System.EventHandler(this.tsTreeAddItem_Click);
      // 
      // tsMnuTreeDeleteItem
      // 
      this.tsMnuTreeDeleteItem.Image = global::UlcWin.Properties.Resources.delete21;
      this.tsMnuTreeDeleteItem.Name = "tsMnuTreeDeleteItem";
      this.tsMnuTreeDeleteItem.Size = new System.Drawing.Size(282, 26);
      this.tsMnuTreeDeleteItem.Text = "Удалить элемент";
      this.tsMnuTreeDeleteItem.Click += new System.EventHandler(this.tsTreeDeleteItem_Click);
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new System.Drawing.Size(279, 6);
      // 
      // tsMnuTreeEdit
      // 
      this.tsMnuTreeEdit.Image = global::UlcWin.Properties.Resources.edit1;
      this.tsMnuTreeEdit.Name = "tsMnuTreeEdit";
      this.tsMnuTreeEdit.Size = new System.Drawing.Size(282, 26);
      this.tsMnuTreeEdit.Text = "Изменить";
      this.tsMnuTreeEdit.Click += new System.EventHandler(this.tsTreeEdit_Click);
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "check2.png");
      this.imageList1.Images.SetKeyName(1, "forbidden.ico");
      this.imageList1.Images.SetKeyName(2, "shield_yellow.ico");
      this.imageList1.Images.SetKeyName(3, "debug.png");
      this.imageList1.Images.SetKeyName(4, "warning.png");
      this.imageList1.Images.SetKeyName(5, "error.ico");
      this.imageList1.Images.SetKeyName(6, "stop.ico");
      this.imageList1.Images.SetKeyName(7, "nav_left_blue.ico");
      this.imageList1.Images.SetKeyName(8, "nav_right_blue.ico");
      this.imageList1.Images.SetKeyName(9, "add.png");
      this.imageList1.Images.SetKeyName(10, "information.png");
      this.imageList1.Images.SetKeyName(11, "navigate_down.png");
      this.imageList1.Images.SetKeyName(12, "navigate_up.png");
      this.imageList1.Images.SetKeyName(13, "gear_replace.ico");
      this.imageList1.Images.SetKeyName(14, "import1.png");
      this.imageList1.Images.SetKeyName(15, "delete2.png");
      this.imageList1.Images.SetKeyName(16, "nav_right_red.ico");
      this.imageList1.Images.SetKeyName(17, "data_table.png");
      this.imageList1.Images.SetKeyName(18, "data_next.png");
      this.imageList1.Images.SetKeyName(19, "user1.png");
      this.imageList1.Images.SetKeyName(20, "import2.png");
      this.imageList1.Images.SetKeyName(21, "warning");
      this.imageList1.Images.SetKeyName(22, "text_marked.ico");
      // 
      // tsTreePanel
      // 
      this.tsTreePanel.BackColor = System.Drawing.SystemColors.ControlLight;
      this.tsTreePanel.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.tsTreePanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTreeBtnEdit,
            this.tsTreeBtnDelete,
            this.tsTreeBtnAdd,
            this.toolStripSeparator3,
            this.tsTreeBtnAddRoot,
            this.toolStripLabel1});
      this.tsTreePanel.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
      this.tsTreePanel.Location = new System.Drawing.Point(0, 0);
      this.tsTreePanel.Name = "tsTreePanel";
      this.tsTreePanel.Padding = new System.Windows.Forms.Padding(0);
      this.tsTreePanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
      this.tsTreePanel.Size = new System.Drawing.Size(383, 27);
      this.tsTreePanel.TabIndex = 0;
      this.tsTreePanel.Text = "toolStrip2";
      // 
      // tsTreeBtnEdit
      // 
      this.tsTreeBtnEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsTreeBtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsTreeBtnEdit.Image = global::UlcWin.Properties.Resources.edit1;
      this.tsTreeBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsTreeBtnEdit.Name = "tsTreeBtnEdit";
      this.tsTreeBtnEdit.Size = new System.Drawing.Size(29, 24);
      this.tsTreeBtnEdit.Text = "Перименовать элемент";
      this.tsTreeBtnEdit.Click += new System.EventHandler(this.tsTreeBtnEdit_Click);
      // 
      // tsTreeBtnDelete
      // 
      this.tsTreeBtnDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsTreeBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsTreeBtnDelete.Image = global::UlcWin.Properties.Resources.delete21;
      this.tsTreeBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsTreeBtnDelete.Name = "tsTreeBtnDelete";
      this.tsTreeBtnDelete.Size = new System.Drawing.Size(29, 24);
      this.tsTreeBtnDelete.Text = "Удалить элемент";
      this.tsTreeBtnDelete.Click += new System.EventHandler(this.tsTreeBtnDelete_Click);
      // 
      // tsTreeBtnAdd
      // 
      this.tsTreeBtnAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsTreeBtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsTreeBtnAdd.Image = global::UlcWin.Properties.Resources.document_add;
      this.tsTreeBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsTreeBtnAdd.Name = "tsTreeBtnAdd";
      this.tsTreeBtnAdd.Size = new System.Drawing.Size(29, 24);
      this.tsTreeBtnAdd.Text = "Добавить элемент";
      this.tsTreeBtnAdd.ToolTipText = "Добавить элемент";
      this.tsTreeBtnAdd.Click += new System.EventHandler(this.tsTreeBtnAdd_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
      // 
      // tsTreeBtnAddRoot
      // 
      this.tsTreeBtnAddRoot.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsTreeBtnAddRoot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsTreeBtnAddRoot.Image = global::UlcWin.Properties.Resources.table_sql_add;
      this.tsTreeBtnAddRoot.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsTreeBtnAddRoot.Name = "tsTreeBtnAddRoot";
      this.tsTreeBtnAddRoot.Size = new System.Drawing.Size(29, 24);
      this.tsTreeBtnAddRoot.Text = "toolStripButton5";
      this.tsTreeBtnAddRoot.ToolTipText = "Добавить корневой элемент";
      this.tsTreeBtnAddRoot.Click += new System.EventHandler(this.tsTreeBtnAddRoot_Click);
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(125, 24);
      this.toolStripLabel1.Text = "Редактирование";
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.checkBoxComboBox1);
      this.splitContainer2.Panel1.Controls.Add(this.panel1);
      this.splitContainer2.Panel1.Controls.Add(this.tsResView);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.LstViewEvent);
      this.splitContainer2.Panel2.Controls.Add(this.tsEvent);
      this.splitContainer2.Panel2.Controls.Add(this.lblNotExist);
      this.splitContainer2.Size = new System.Drawing.Size(1536, 567);
      this.splitContainer2.SplitterDistance = 361;
      this.splitContainer2.SplitterWidth = 5;
      this.splitContainer2.TabIndex = 0;
      // 
      // checkBoxComboBox1
      // 
      checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
      this.checkBoxComboBox1.CheckBoxProperties = checkBoxProperties1;
      this.checkBoxComboBox1.DisplayMemberSingleItem = "";
      this.checkBoxComboBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.checkBoxComboBox1.FormattingEnabled = true;
      this.checkBoxComboBox1.Location = new System.Drawing.Point(168, 0);
      this.checkBoxComboBox1.Margin = new System.Windows.Forms.Padding(4);
      this.checkBoxComboBox1.MaxDropDownItems = 15;
      this.checkBoxComboBox1.Name = "checkBoxComboBox1";
      this.checkBoxComboBox1.Size = new System.Drawing.Size(233, 25);
      this.checkBoxComboBox1.TabIndex = 3;
      this.checkBoxComboBox1.CheckBoxCheckedChanged += new System.EventHandler(this.checkBoxComboBox1_CheckBoxCheckedChanged);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.LstViewItm);
      this.panel1.Controls.Add(this.usrFesStatistics1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 27);
      this.panel1.Margin = new System.Windows.Forms.Padding(4);
      this.panel1.Name = "panel1";
      this.panel1.Padding = new System.Windows.Forms.Padding(1);
      this.panel1.Size = new System.Drawing.Size(1536, 334);
      this.panel1.TabIndex = 2;
      // 
      // LstViewItm
      // 
      this.LstViewItm.AllowColumnReorder = true;
      this.LstViewItm.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.LstViewItm.CheckBoxes = true;
      this.LstViewItm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Name,
            this.Ip,
            this.phone,
            this.UType,
            this.Version,
            this.Signal,
            this.soft,
            this.logs,
            this.core,
            this.imai,
            this.schedule,
            this.rs485,
            this.traph,
            this.active,
            this.isLight,
            this.comments});
      this.LstViewItm.ContextMenuStrip = this.LvMenu;
      this.LstViewItm.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LstViewItm.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.LstViewItm.FullRowSelect = true;
      this.LstViewItm.HideSelection = false;
      this.LstViewItm.Location = new System.Drawing.Point(1, 1);
      this.LstViewItm.Margin = new System.Windows.Forms.Padding(4);
      this.LstViewItm.MultiSelect = false;
      this.LstViewItm.Name = "LstViewItm";
      this.LstViewItm.Size = new System.Drawing.Size(1534, 332);
      this.LstViewItm.SmallImageList = this.imageList1;
      this.LstViewItm.TabIndex = 0;
      this.LstViewItm.UseCompatibleStateImageBehavior = false;
      this.LstViewItm.View = System.Windows.Forms.View.Details;
      this.LstViewItm.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LstViewItm_ColumnClick);
      this.LstViewItm.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.LstViewItm_ColumnWidthChanged);
      this.LstViewItm.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LstViewItm_ItemCheck);
      this.LstViewItm.SelectedIndexChanged += new System.EventHandler(this.LstViewItm_SelectedIndexChanged);
      this.LstViewItm.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LstViewItm_MouseDoubleClick);
      // 
      // Id
      // 
      this.Id.Text = "Дата";
      this.Id.Width = 155;
      // 
      // Name
      // 
      this.Name.Text = "Имя объекта";
      this.Name.Width = 264;
      // 
      // Ip
      // 
      this.Ip.Text = "IP адрес";
      this.Ip.Width = 120;
      // 
      // phone
      // 
      this.phone.Text = "Телефон";
      this.phone.Width = 116;
      // 
      // UType
      // 
      this.UType.Text = "Тип";
      this.UType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.UType.Width = 72;
      // 
      // Version
      // 
      this.Version.Text = "Версия";
      this.Version.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // Signal
      // 
      this.Signal.Text = "Сигнал";
      this.Signal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.Signal.Width = 71;
      // 
      // soft
      // 
      this.soft.Text = "Прошивка";
      this.soft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.soft.Width = 161;
      // 
      // logs
      // 
      this.logs.Text = "Сост. лога";
      this.logs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.logs.Width = 66;
      // 
      // core
      // 
      this.core.Text = "Патч";
      this.core.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // imai
      // 
      this.imai.Text = "IMAI";
      this.imai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.imai.Width = 68;
      // 
      // schedule
      // 
      this.schedule.Text = "Акт. расп.";
      this.schedule.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.schedule.Width = 72;
      // 
      // rs485
      // 
      this.rs485.Text = "RS-485";
      this.rs485.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.rs485.Width = 55;
      // 
      // traph
      // 
      this.traph.Text = "Траффик";
      this.traph.Width = 80;
      // 
      // active
      // 
      this.active.Text = "Актив.";
      this.active.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // isLight
      // 
      this.isLight.Text = "освещ.";
      this.isLight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // comments
      // 
      this.comments.Text = "Комент.";
      this.comments.Width = 120;
      // 
      // LvMenu
      // 
      this.LvMenu.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.LvMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.LvMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuUpdateCurrent,
            this.ctxMenuUpdateSelected,
            this.ctxMenuUpdateNotTrue,
            this.ctxMenuUpdateAll,
            this.tsMenuSeparate,
            this.ctxMenuReadCurrentLog,
            this.toolStripSeparator1,
            this.ctxMenuItemAdd,
            this.ctxMenuItemChange,
            this.ctxMenuItemDelete,
            this.ctxSeparateEdit,
            this.ctxMenuPingCurrentItem,
            this.ctxMenuAllPingItem,
            this.ctxSeparatePing,
            this.ctxMenuAtCommand,
            this.ctxMenuMeter,
            this.ctxNotTrueMeter});
      this.LvMenu.Name = "contextMenuStrip1";
      this.LvMenu.ShowImageMargin = false;
      this.LvMenu.Size = new System.Drawing.Size(269, 314);
      this.LvMenu.Opening += new System.ComponentModel.CancelEventHandler(this.LvMenu_Opening);
      // 
      // ctxMenuUpdateCurrent
      // 
      this.ctxMenuUpdateCurrent.Name = "ctxMenuUpdateCurrent";
      this.ctxMenuUpdateCurrent.Size = new System.Drawing.Size(268, 22);
      this.ctxMenuUpdateCurrent.Text = "Обновить текущий ";
      this.ctxMenuUpdateCurrent.Click += new System.EventHandler(this.CurrentMenuClick);
      // 
      // ctxMenuUpdateSelected
      // 
      this.ctxMenuUpdateSelected.Name = "ctxMenuUpdateSelected";
      this.ctxMenuUpdateSelected.Size = new System.Drawing.Size(268, 22);
      this.ctxMenuUpdateSelected.Text = "Обновить выбранные";
      this.ctxMenuUpdateSelected.Click += new System.EventHandler(this.tsUpdateSelectedMenuItem_Click);
      // 
      // ctxMenuUpdateNotTrue
      // 
      this.ctxMenuUpdateNotTrue.Name = "ctxMenuUpdateNotTrue";
      this.ctxMenuUpdateNotTrue.Size = new System.Drawing.Size(268, 22);
      this.ctxMenuUpdateNotTrue.Text = "Обновить недостоверные";
      this.ctxMenuUpdateNotTrue.Click += new System.EventHandler(this.NotTrueMenuClick);
      // 
      // ctxMenuUpdateAll
      // 
      this.ctxMenuUpdateAll.Name = "ctxMenuUpdateAll";
      this.ctxMenuUpdateAll.Size = new System.Drawing.Size(268, 22);
      this.ctxMenuUpdateAll.Text = "Обновить все";
      this.ctxMenuUpdateAll.Click += new System.EventHandler(this.tsUpdateItemCurrent_Click);
      // 
      // tsMenuSeparate
      // 
      this.tsMenuSeparate.Name = "tsMenuSeparate";
      this.tsMenuSeparate.Size = new System.Drawing.Size(265, 6);
      // 
      // ctxMenuReadCurrentLog
      // 
      this.ctxMenuReadCurrentLog.Name = "ctxMenuReadCurrentLog";
      this.ctxMenuReadCurrentLog.Size = new System.Drawing.Size(268, 22);
      this.ctxMenuReadCurrentLog.Text = "Чтение журнала с устройства";
      this.ctxMenuReadCurrentLog.Click += new System.EventHandler(this.tsMenuReadCurrentLog_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(265, 6);
      // 
      // ctxMenuItemAdd
      // 
      this.ctxMenuItemAdd.Name = "ctxMenuItemAdd";
      this.ctxMenuItemAdd.Size = new System.Drawing.Size(268, 22);
      this.ctxMenuItemAdd.Text = "Добавить";
      this.ctxMenuItemAdd.Click += new System.EventHandler(this.TsMenuAdd_Click);
      // 
      // ctxMenuItemChange
      // 
      this.ctxMenuItemChange.Name = "ctxMenuItemChange";
      this.ctxMenuItemChange.Size = new System.Drawing.Size(268, 22);
      this.ctxMenuItemChange.Text = "Изменить";
      this.ctxMenuItemChange.Click += new System.EventHandler(this.tsMenuItChange_Click);
      // 
      // ctxMenuItemDelete
      // 
      this.ctxMenuItemDelete.Name = "ctxMenuItemDelete";
      this.ctxMenuItemDelete.Size = new System.Drawing.Size(268, 22);
      this.ctxMenuItemDelete.Text = "Удалить";
      this.ctxMenuItemDelete.Click += new System.EventHandler(this.TsMenuItemDelete_Click);
      // 
      // ctxSeparateEdit
      // 
      this.ctxSeparateEdit.Name = "ctxSeparateEdit";
      this.ctxSeparateEdit.Size = new System.Drawing.Size(265, 6);
      // 
      // ctxMenuPingCurrentItem
      // 
      this.ctxMenuPingCurrentItem.Name = "ctxMenuPingCurrentItem";
      this.ctxMenuPingCurrentItem.Size = new System.Drawing.Size(268, 22);
      this.ctxMenuPingCurrentItem.Text = "Ping текущего устройства";
      this.ctxMenuPingCurrentItem.Click += new System.EventHandler(this.tsPingCurrentlStriMenuItem_Click);
      // 
      // ctxMenuAllPingItem
      // 
      this.ctxMenuAllPingItem.Name = "ctxMenuAllPingItem";
      this.ctxMenuAllPingItem.Size = new System.Drawing.Size(268, 22);
      this.ctxMenuAllPingItem.Text = "Ping всех устройств";
      this.ctxMenuAllPingItem.Visible = false;
      this.ctxMenuAllPingItem.Click += new System.EventHandler(this.tsAllPingToolStripMenuItem_Click);
      // 
      // ctxSeparatePing
      // 
      this.ctxSeparatePing.Name = "ctxSeparatePing";
      this.ctxSeparatePing.Size = new System.Drawing.Size(265, 6);
      // 
      // ctxMenuAtCommand
      // 
      this.ctxMenuAtCommand.Name = "ctxMenuAtCommand";
      this.ctxMenuAtCommand.Size = new System.Drawing.Size(268, 22);
      this.ctxMenuAtCommand.Text = "AT команды";
      this.ctxMenuAtCommand.Click += new System.EventHandler(this.tsATCommandMenuItem_Click);
      // 
      // ctxMenuMeter
      // 
      this.ctxMenuMeter.Name = "ctxMenuMeter";
      this.ctxMenuMeter.Size = new System.Drawing.Size(268, 22);
      this.ctxMenuMeter.Text = "Счетчики ";
      this.ctxMenuMeter.Click += new System.EventHandler(this.testmeterToolStripMenuItem_Click);
      // 
      // ctxNotTrueMeter
      // 
      this.ctxNotTrueMeter.Name = "ctxNotTrueMeter";
      this.ctxNotTrueMeter.Size = new System.Drawing.Size(268, 22);
      this.ctxNotTrueMeter.Text = "Счетчики недоставерные";
      this.ctxNotTrueMeter.Click += new System.EventHandler(this.ctxNotTrueMeter_Click);
      // 
      // usrFesStatistics1
      // 
      this.usrFesStatistics1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.usrFesStatistics1.Location = new System.Drawing.Point(1, 1);
      this.usrFesStatistics1.Margin = new System.Windows.Forms.Padding(5);
      this.usrFesStatistics1.Name = "usrFesStatistics1";
      this.usrFesStatistics1.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
      this.usrFesStatistics1.Size = new System.Drawing.Size(1534, 332);
      this.usrFesStatistics1.TabIndex = 1;
      this.usrFesStatistics1.Value = null;
      this.usrFesStatistics1.Visible = false;
      // 
      // tsResView
      // 
      this.tsResView.BackColor = System.Drawing.SystemColors.ControlLight;
      this.tsResView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tsResView.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.tsResView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsComboBoxDev,
            this.toolStripSeparator9,
            this.tsBtnExport,
            this.tsDwnUpdate,
            this.tsSelectedItems,
            this.tsBtnEventShowHide,
            this.tsUpdate,
            this.tsLblFind});
      this.tsResView.Location = new System.Drawing.Point(0, 0);
      this.tsResView.Name = "tsResView";
      this.tsResView.Size = new System.Drawing.Size(1536, 27);
      this.tsResView.TabIndex = 1;
      this.tsResView.Text = "toolStrip2";
      // 
      // tsComboBoxDev
      // 
      this.tsComboBoxDev.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsComboBoxDev.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
      this.tsComboBoxDev.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tsComboBoxDev.Items.AddRange(new object[] {
            "РВП-18",
            "ULC 02"});
      this.tsComboBoxDev.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.tsComboBoxDev.Name = "tsComboBoxDev";
      this.tsComboBoxDev.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
      this.tsComboBoxDev.Size = new System.Drawing.Size(75, 27);
      this.tsComboBoxDev.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
      // 
      // toolStripSeparator9
      // 
      this.toolStripSeparator9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.toolStripSeparator9.Name = "toolStripSeparator9";
      this.toolStripSeparator9.Size = new System.Drawing.Size(6, 27);
      // 
      // tsBtnExport
      // 
      this.tsBtnExport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsBtnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsBtnExport.Image = global::UlcWin.Properties.Resources.excel_exports;
      this.tsBtnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsBtnExport.Name = "tsBtnExport";
      this.tsBtnExport.Size = new System.Drawing.Size(29, 24);
      this.tsBtnExport.Text = "Экспорт";
      this.tsBtnExport.ToolTipText = "Экспорт в Excel";
      this.tsBtnExport.Click += new System.EventHandler(this.tsBtnExport_Click);
      // 
      // tsDwnUpdate
      // 
      this.tsDwnUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsDwnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsDwnUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItem_Pgrm,
            this.tsMenuItem_Patch,
            this.geniralSettingsToolStripMenuItem,
            this.tsMenuItemReboot});
      this.tsDwnUpdate.Image = global::UlcWin.Properties.Resources.gear_replace;
      this.tsDwnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsDwnUpdate.Name = "tsDwnUpdate";
      this.tsDwnUpdate.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
      this.tsDwnUpdate.RightToLeftAutoMirrorImage = true;
      this.tsDwnUpdate.Size = new System.Drawing.Size(39, 24);
      this.tsDwnUpdate.Text = "Обновление";
      // 
      // tsMenuItem_Pgrm
      // 
      this.tsMenuItem_Pgrm.Image = global::UlcWin.Properties.Resources.data_refresh;
      this.tsMenuItem_Pgrm.Name = "tsMenuItem_Pgrm";
      this.tsMenuItem_Pgrm.Size = new System.Drawing.Size(246, 26);
      this.tsMenuItem_Pgrm.Text = "Обновить прошивку";
      this.tsMenuItem_Pgrm.Click += new System.EventHandler(this.tsMenuItem_Pgrm_Click);
      // 
      // tsMenuItem_Patch
      // 
      this.tsMenuItem_Patch.Image = global::UlcWin.Properties.Resources.data_into;
      this.tsMenuItem_Patch.Name = "tsMenuItem_Patch";
      this.tsMenuItem_Patch.Size = new System.Drawing.Size(246, 26);
      this.tsMenuItem_Patch.Text = "Обновить патч";
      this.tsMenuItem_Patch.Click += new System.EventHandler(this.tsMenuItem_Patch_Click);
      // 
      // geniralSettingsToolStripMenuItem
      // 
      this.geniralSettingsToolStripMenuItem.Image = global::UlcWin.Properties.Resources.data_up;
      this.geniralSettingsToolStripMenuItem.Name = "geniralSettingsToolStripMenuItem";
      this.geniralSettingsToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
      this.geniralSettingsToolStripMenuItem.Text = "Запись конфигурации";
      this.geniralSettingsToolStripMenuItem.Click += new System.EventHandler(this.geniralSettingsToolStripMenuItem_Click);
      // 
      // tsMenuItemReboot
      // 
      this.tsMenuItemReboot.Image = global::UlcWin.Properties.Resources.refresh1;
      this.tsMenuItemReboot.Name = "tsMenuItemReboot";
      this.tsMenuItemReboot.Size = new System.Drawing.Size(246, 26);
      this.tsMenuItemReboot.Text = "Перезапуск устройств";
      this.tsMenuItemReboot.Click += new System.EventHandler(this.tsMenuItemReboot_Click);
      // 
      // tsSelectedItems
      // 
      this.tsSelectedItems.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsSelectedItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsSelectedItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSelectAll,
            this.tsDeselectAll});
      this.tsSelectedItems.Image = global::UlcWin.Properties.Resources.btnUncheck;
      this.tsSelectedItems.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsSelectedItems.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
      this.tsSelectedItems.Name = "tsSelectedItems";
      this.tsSelectedItems.Size = new System.Drawing.Size(34, 24);
      this.tsSelectedItems.Text = "tsSelectedItems";
      // 
      // tsSelectAll
      // 
      this.tsSelectAll.Image = global::UlcWin.Properties.Resources.btnCheck;
      this.tsSelectAll.Name = "tsSelectAll";
      this.tsSelectAll.Size = new System.Drawing.Size(179, 26);
      this.tsSelectAll.Text = "Выбрать все";
      this.tsSelectAll.Click += new System.EventHandler(this.tsSelectAll_Click);
      // 
      // tsDeselectAll
      // 
      this.tsDeselectAll.Image = global::UlcWin.Properties.Resources.btnUncheck;
      this.tsDeselectAll.Name = "tsDeselectAll";
      this.tsDeselectAll.Size = new System.Drawing.Size(179, 26);
      this.tsDeselectAll.Text = "Отмена";
      this.tsDeselectAll.Click += new System.EventHandler(this.tsDeselectAll_Click);
      // 
      // tsBtnEventShowHide
      // 
      this.tsBtnEventShowHide.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsBtnEventShowHide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsBtnEventShowHide.Image = global::UlcWin.Properties.Resources.window_split_ver;
      this.tsBtnEventShowHide.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsBtnEventShowHide.Name = "tsBtnEventShowHide";
      this.tsBtnEventShowHide.Size = new System.Drawing.Size(29, 24);
      this.tsBtnEventShowHide.Text = "tsBtnEventShowHide";
      this.tsBtnEventShowHide.Click += new System.EventHandler(this.toolStripButton3_Click_3);
      // 
      // tsUpdate
      // 
      this.tsUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsUpdate.Image")));
      this.tsUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsUpdate.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
      this.tsUpdate.Name = "tsUpdate";
      this.tsUpdate.Size = new System.Drawing.Size(29, 24);
      this.tsUpdate.Text = "Обновить";
      this.tsUpdate.Visible = false;
      this.tsUpdate.Click += new System.EventHandler(this.tsUpdate_Click);
      // 
      // tsLblFind
      // 
      this.tsLblFind.Name = "tsLblFind";
      this.tsLblFind.Size = new System.Drawing.Size(52, 24);
      this.tsLblFind.Text = "Поиск";
      // 
      // LstViewEvent
      // 
      this.LstViewEvent.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.LstViewEvent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.Evt});
      this.LstViewEvent.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LstViewEvent.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.LstViewEvent.HideSelection = false;
      this.LstViewEvent.Location = new System.Drawing.Point(0, 27);
      this.LstViewEvent.Margin = new System.Windows.Forms.Padding(4);
      this.LstViewEvent.Name = "LstViewEvent";
      this.LstViewEvent.Size = new System.Drawing.Size(1536, 174);
      this.LstViewEvent.SmallImageList = this.imageList1;
      this.LstViewEvent.TabIndex = 1;
      this.LstViewEvent.UseCompatibleStateImageBehavior = false;
      this.LstViewEvent.View = System.Windows.Forms.View.Details;
      // 
      // Date
      // 
      this.Date.Text = "Дата и время";
      this.Date.Width = 181;
      // 
      // Evt
      // 
      this.Evt.Text = "Событие";
      this.Evt.Width = 688;
      // 
      // tsEvent
      // 
      this.tsEvent.BackColor = System.Drawing.SystemColors.ControlLight;
      this.tsEvent.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.tsEvent.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.tsEvent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
      this.tsEvent.Location = new System.Drawing.Point(0, 0);
      this.tsEvent.Name = "tsEvent";
      this.tsEvent.Size = new System.Drawing.Size(1536, 27);
      this.tsEvent.TabIndex = 3;
      this.tsEvent.Text = "toolStrip2";
      // 
      // toolStripButton1
      // 
      this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButton1.Image = global::UlcWin.Properties.Resources.arrow_left_blue;
      this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
      this.toolStripButton1.Text = "toolStripButton1";
      this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
      // 
      // toolStripButton2
      // 
      this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButton2.Image = global::UlcWin.Properties.Resources.arrow_right_blue;
      this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton2.Name = "toolStripButton2";
      this.toolStripButton2.Size = new System.Drawing.Size(29, 24);
      this.toolStripButton2.Text = "toolStripButton2";
      this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click_1);
      // 
      // lblNotExist
      // 
      this.lblNotExist.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblNotExist.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblNotExist.Location = new System.Drawing.Point(0, 0);
      this.lblNotExist.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblNotExist.Name = "lblNotExist";
      this.lblNotExist.Size = new System.Drawing.Size(1536, 201);
      this.lblNotExist.TabIndex = 2;
      this.lblNotExist.Text = "Нет информации";
      this.lblNotExist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tsStatusLbl
      // 
      this.tsStatusLbl.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tsStatusLbl.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.tsStatusLbl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStsLabelAll,
            this.tsStsLblNotTrue,
            this.tsStsNetBad,
            this.tsStsRssBad,
            this.tsStsIMEI});
      this.tsStatusLbl.Location = new System.Drawing.Point(0, 604);
      this.tsStatusLbl.Name = "tsStatusLbl";
      this.tsStatusLbl.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
      this.tsStatusLbl.Size = new System.Drawing.Size(1924, 26);
      this.tsStatusLbl.TabIndex = 3;
      // 
      // tsStsLabelAll
      // 
      this.tsStsLabelAll.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
      this.tsStsLabelAll.Image = global::UlcWin.Properties.Resources.check2;
      this.tsStsLabelAll.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
      this.tsStsLabelAll.Name = "tsStsLabelAll";
      this.tsStsLabelAll.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
      this.tsStsLabelAll.Size = new System.Drawing.Size(30, 21);
      // 
      // tsStsLblNotTrue
      // 
      this.tsStsLblNotTrue.Image = global::UlcWin.Properties.Resources.warning;
      this.tsStsLblNotTrue.Name = "tsStsLblNotTrue";
      this.tsStsLblNotTrue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
      this.tsStsLblNotTrue.Size = new System.Drawing.Size(30, 20);
      // 
      // tsStsNetBad
      // 
      this.tsStsNetBad.Image = global::UlcWin.Properties.Resources.information;
      this.tsStsNetBad.Name = "tsStsNetBad";
      this.tsStsNetBad.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
      this.tsStsNetBad.Size = new System.Drawing.Size(30, 20);
      // 
      // tsStsRssBad
      // 
      this.tsStsRssBad.Image = global::UlcWin.Properties.Resources.exclamation;
      this.tsStsRssBad.Name = "tsStsRssBad";
      this.tsStsRssBad.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
      this.tsStsRssBad.Size = new System.Drawing.Size(30, 20);
      // 
      // tsStsIMEI
      // 
      this.tsStsIMEI.Image = global::UlcWin.Properties.Resources.monitor_go;
      this.tsStsIMEI.Name = "tsStsIMEI";
      this.tsStsIMEI.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
      this.tsStsIMEI.Size = new System.Drawing.Size(30, 20);
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
      // 
      // imageList2
      // 
      this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
      this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList2.Images.SetKeyName(0, "gear_ok.ico");
      this.imageList2.Images.SetKeyName(1, "gear_connection.ico");
      this.imageList2.Images.SetKeyName(2, "gear_stop.ico");
      // 
      // LoadForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1924, 630);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.tsStatusLbl);
      this.Controls.Add(this.toolStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4);
      //this.Name = "LoadForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.treeMenu.ResumeLayout(false);
      this.tsTreePanel.ResumeLayout(false);
      this.tsTreePanel.PerformLayout();
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel1.PerformLayout();
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
      this.splitContainer2.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.LvMenu.ResumeLayout(false);
      this.tsResView.ResumeLayout(false);
      this.tsResView.PerformLayout();
      this.tsEvent.ResumeLayout(false);
      this.tsEvent.PerformLayout();
      this.tsStatusLbl.ResumeLayout(false);
      this.tsStatusLbl.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TreeView treeView1;
    private System.Windows.Forms.ListView LstViewItm;
    private System.Windows.Forms.ColumnHeader Id;
    private System.Windows.Forms.ColumnHeader Name;
    private System.Windows.Forms.ColumnHeader Ip;
    private System.Windows.Forms.ColumnHeader phone;
    private System.Windows.Forms.ColumnHeader UType;
    private System.Windows.Forms.ColumnHeader Version;
    private System.Windows.Forms.ColumnHeader Signal;
    private System.Windows.Forms.ColumnHeader soft;
    private System.Windows.Forms.ContextMenuStrip LvMenu;
    private System.Windows.Forms.ToolStripMenuItem ctxMenuUpdateCurrent;
    private System.Windows.Forms.ToolStripMenuItem ctxMenuUpdateNotTrue;
    private System.Windows.Forms.ToolStripMenuItem ctxMenuUpdateAll;
    private System.Windows.Forms.ToolStripButton tsUpdate_1;
    private System.Windows.Forms.ToolStripSeparator tsMenuSeparate;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuItemChange;
    private System.Windows.Forms.ToolStripMenuItem ctxMenuItemDelete;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem ctxMenuReadCurrentLog;
    private System.Windows.Forms.ToolStripMenuItem ctxMenuItemAdd;
    public System.Windows.Forms.ListView LstViewEvent;
    private System.Windows.Forms.ColumnHeader Date;
    private System.Windows.Forms.ColumnHeader Evt;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.Label lblNotExist;
    private System.Windows.Forms.StatusStrip tsStatusLbl;
    private System.Windows.Forms.ToolStrip tsEvent;
    private System.Windows.Forms.ToolStripButton toolStripButton1;
    private System.Windows.Forms.ToolStripButton toolStripButton2;
    private System.Windows.Forms.ColumnHeader logs;
    private System.Windows.Forms.ColumnHeader core;
    private System.Windows.Forms.ToolStripSeparator ctxSeparateEdit;
    private System.Windows.Forms.ColumnHeader imai;
    private System.Windows.Forms.ToolStripMenuItem ctxMenuAtCommand;
    private System.Windows.Forms.ToolStripMenuItem ctxMenuUpdateSelected;
    public System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.ColumnHeader schedule;
    private System.Windows.Forms.ColumnHeader rs485;
    private System.Windows.Forms.ToolStripMenuItem ctxMenuPingCurrentItem;
    private System.Windows.Forms.ToolStripSeparator ctxSeparatePing;
    private System.Windows.Forms.ToolStripMenuItem ctxMenuAllPingItem;
        private System.Windows.Forms.ColumnHeader traph;
    public System.Windows.Forms.ImageList imlTc;
    private System.Windows.Forms.ToolStripButton tsBtnConnect;
        private System.Windows.Forms.ContextMenuStrip treeMenu;
    private System.Windows.Forms.ToolStripMenuItem tsMnuTreeAddItem;
        private System.Windows.Forms.ToolStripMenuItem tsMnuTreeDeleteItem;
    private System.Windows.Forms.ToolStripMenuItem tsMnuAddRootItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripMenuItem tsMnuTreeEdit;
    private System.Windows.Forms.ToolStrip tsTreePanel;
    private System.Windows.Forms.ToolStripButton tsTreeBtnDelete;
    private System.Windows.Forms.ToolStripButton tsTreeBtnAdd;
    private System.Windows.Forms.ToolStripButton tsTreeBtnAddRoot;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStripButton tsTreeBtnEdit;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripStatusLabel tsStsLabelAll;
    private System.Windows.Forms.ToolStripStatusLabel tsStsLblNotTrue;
    private System.Windows.Forms.ToolStripStatusLabel tsStsNetBad;
    private System.Windows.Forms.ToolStrip tsResView;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.ToolStripButton tsUpdate;
    private System.Windows.Forms.ToolStripDropDownButton tsSelectedItems;
    private System.Windows.Forms.ToolStripMenuItem tsSelectAll;
    private System.Windows.Forms.ToolStripMenuItem tsDeselectAll;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
    private System.Windows.Forms.ToolStripDropDownButton tsDwnUpdate;
    private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Pgrm;
    private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Patch;
    private System.Windows.Forms.ToolStripMenuItem geniralSettingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripComboBox tsComboBoxDev;
    private System.Windows.Forms.ImageList imageList2;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.ToolStripButton tsBtnUsersEdit;
    private System.Windows.Forms.ToolStripButton tsBtnEventShowHide;
    private System.Windows.Forms.ToolStripMenuItem tsMenuItemReboot;
    private System.Windows.Forms.HelpProvider helpProvider1;
    private PresentationControls.CheckBoxComboBox checkBoxComboBox1;
    private System.Windows.Forms.ToolStripSplitButton tsSelectShow;
    private System.Windows.Forms.ToolStripMenuItem showAllToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem showNotTrueToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNetLow;
    private System.Windows.Forms.ToolStripDropDownButton tsDwnUpdate_1;
    private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Pgrm_1;
    private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Patch_1;
    private System.Windows.Forms.ToolStripMenuItem geniralSettingsToolStripMenuItem_1;
    private System.Windows.Forms.ToolStripComboBox tsComboBoxDev_1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripDropDownButton tsSelectedItems_1;
    private System.Windows.Forms.ToolStripMenuItem tsSelectAll_1;
    private System.Windows.Forms.ToolStripMenuItem tsDeselectAll_1;
    private System.Windows.Forms.ToolStripButton tsBtnExport;
    private System.Windows.Forms.ColumnHeader active;
    private System.Windows.Forms.ColumnHeader isLight;
    private System.Windows.Forms.ColumnHeader comments;
    private System.Windows.Forms.ToolStripButton tsBtnStatistics;
    private System.Windows.Forms.ToolStripStatusLabel tsStsRssBad;
    private System.Windows.Forms.ToolStripStatusLabel tsStsIMEI;
    private System.Windows.Forms.ToolStripMenuItem ctxMenuMeter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripButton tsBtnAbout;
    private System.Windows.Forms.ToolStripLabel tsLblFind;
    private ui.UsrFesStatistics usrFesStatistics1;
        private System.Windows.Forms.ToolStripButton tsBtnEventLog;
    private System.Windows.Forms.ToolStripMenuItem ctxNotTrueMeter;
  }
}

