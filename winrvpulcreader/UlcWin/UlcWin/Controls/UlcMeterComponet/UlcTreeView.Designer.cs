
namespace GettingStartedTree
{
  partial class UlcTreeView
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UlcTreeView));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.splitMeter = new System.Windows.Forms.SplitContainer();
      this.treeListView1 = new BrightIdeasSoftware.TreeListView();
      this.olvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvTp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvDateTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvIp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvMeterFactory = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvValueMonth = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvRs = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.menuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ctxMenuChange = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ctxTreeUpdateNotTrue = new System.Windows.Forms.ToolStripMenuItem();
      this.ctxTreeSimpleUpdate = new System.Windows.Forms.ToolStripMenuItem();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.status = new System.Windows.Forms.DataGridViewImageColumn();
      this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.rs_active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.street_light = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
      this.olvDt = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvVal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.panel1 = new System.Windows.Forms.Panel();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.monthPicker1 = new UlcWin.ui.MonthPicker();
      this.button3 = new System.Windows.Forms.Button();
      this.panel3 = new System.Windows.Forms.Panel();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitMeter)).BeginInit();
      this.splitMeter.Panel1.SuspendLayout();
      this.splitMeter.Panel2.SuspendLayout();
      this.splitMeter.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
      this.menuTree.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
      this.panel1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(4, 39);
      this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.splitMeter);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.objectListView1);
      this.splitContainer1.Size = new System.Drawing.Size(1099, 547);
      this.splitContainer1.SplitterDistance = 856;
      this.splitContainer1.SplitterWidth = 3;
      this.splitContainer1.TabIndex = 0;
      // 
      // splitMeter
      // 
      this.splitMeter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitMeter.Location = new System.Drawing.Point(0, 0);
      this.splitMeter.Name = "splitMeter";
      this.splitMeter.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitMeter.Panel1
      // 
      this.splitMeter.Panel1.Controls.Add(this.treeListView1);
      // 
      // splitMeter.Panel2
      // 
      this.splitMeter.Panel2.Controls.Add(this.dataGridView1);
      this.splitMeter.Size = new System.Drawing.Size(856, 547);
      this.splitMeter.SplitterDistance = 445;
      this.splitMeter.TabIndex = 6;
      // 
      // treeListView1
      // 
      this.treeListView1.AllColumns.Add(this.olvName);
      this.treeListView1.AllColumns.Add(this.olvTp);
      this.treeListView1.AllColumns.Add(this.olvDateTime);
      this.treeListView1.AllColumns.Add(this.olvType);
      this.treeListView1.AllColumns.Add(this.olvIp);
      this.treeListView1.AllColumns.Add(this.olvMeterFactory);
      this.treeListView1.AllColumns.Add(this.olvValue);
      this.treeListView1.AllColumns.Add(this.olvValueMonth);
      this.treeListView1.AllColumns.Add(this.olvRs);
      this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvName,
            this.olvTp,
            this.olvDateTime,
            this.olvType,
            this.olvIp,
            this.olvMeterFactory,
            this.olvValue,
            this.olvValueMonth,
            this.olvRs});
      this.treeListView1.ContextMenuStrip = this.menuTree;
      this.treeListView1.Cursor = System.Windows.Forms.Cursors.Default;
      this.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeListView1.FullRowSelect = true;
      this.treeListView1.HeaderUsesThemes = false;
      this.treeListView1.HideSelection = false;
      this.treeListView1.IncludeColumnHeadersInCopy = true;
      this.treeListView1.IncludeHiddenColumnsInDataTransfer = true;
      this.treeListView1.Location = new System.Drawing.Point(0, 0);
      this.treeListView1.MultiSelect = false;
      this.treeListView1.Name = "treeListView1";
      this.treeListView1.OwnerDraw = true;
      this.treeListView1.SelectColumnsOnRightClick = false;
      this.treeListView1.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
      this.treeListView1.ShowFilterMenuOnRightClick = false;
      this.treeListView1.ShowGroups = false;
      this.treeListView1.Size = new System.Drawing.Size(856, 445);
      this.treeListView1.SmallImageList = this.imageList1;
      this.treeListView1.TabIndex = 4;
      this.treeListView1.UseCompatibleStateImageBehavior = false;
      this.treeListView1.View = System.Windows.Forms.View.Details;
      this.treeListView1.VirtualMode = true;
      this.treeListView1.AfterSorting += new System.EventHandler<BrightIdeasSoftware.AfterSortingEventArgs>(this.treeListView1_AfterSorting);
      this.treeListView1.SubItemChecking += new System.EventHandler<BrightIdeasSoftware.SubItemCheckingEventArgs>(this.treeListView1_SubItemChecking);
      this.treeListView1.ColumnRightClick += new BrightIdeasSoftware.ColumnRightClickEventHandler(this.treeListView1_ColumnRightClick);
      this.treeListView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.treeListView1_ColumnClick);
      this.treeListView1.SelectedIndexChanged += new System.EventHandler(this.TreeListView1_SelectionChanged);
      this.treeListView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeListView1_MouseClick);
      // 
      // olvName
      // 
      this.olvName.AspectName = "name";
      this.olvName.CellPadding = null;
      this.olvName.IsEditable = false;
      this.olvName.Searchable = false;
      this.olvName.Sortable = false;
      this.olvName.Text = "Имя объекта";
      this.olvName.ToolTipText = "Имя объекта";
      this.olvName.Width = 230;
      // 
      // olvTp
      // 
      this.olvTp.AspectName = "name";
      this.olvTp.CellPadding = null;
      this.olvTp.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvTp.Sortable = false;
      this.olvTp.Text = "ТП";
      this.olvTp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvTp.Width = 66;
      // 
      // olvDateTime
      // 
      this.olvDateTime.AspectName = "date_time";
      this.olvDateTime.CellPadding = null;
      this.olvDateTime.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvDateTime.IsEditable = false;
      this.olvDateTime.Searchable = false;
      this.olvDateTime.Sortable = false;
      this.olvDateTime.Text = "Дата и время";
      this.olvDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvDateTime.ToolTipText = "Дата и время";
      this.olvDateTime.Width = 128;
      // 
      // olvType
      // 
      this.olvType.AspectName = "unit_type_id";
      this.olvType.CellPadding = null;
      this.olvType.IsEditable = false;
      this.olvType.Sortable = false;
      this.olvType.Text = "Тип";
      this.olvType.ToolTipText = "Тип контроллера";
      // 
      // olvIp
      // 
      this.olvIp.AspectName = "ip";
      this.olvIp.CellPadding = null;
      this.olvIp.IsEditable = false;
      this.olvIp.Sortable = false;
      this.olvIp.Text = "IP адрес";
      this.olvIp.ToolTipText = "IP Адрес";
      this.olvIp.Width = 112;
      // 
      // olvMeterFactory
      // 
      this.olvMeterFactory.AspectName = "meter_factory";
      this.olvMeterFactory.CellPadding = null;
      this.olvMeterFactory.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvMeterFactory.IsEditable = false;
      this.olvMeterFactory.Searchable = false;
      this.olvMeterFactory.Sortable = false;
      this.olvMeterFactory.Text = "Номер счетчика";
      this.olvMeterFactory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvMeterFactory.ToolTipText = "Серийный номер счетчика";
      this.olvMeterFactory.Width = 146;
      // 
      // olvValue
      // 
      this.olvValue.AspectName = "value";
      this.olvValue.CellPadding = null;
      this.olvValue.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvValue.IsEditable = false;
      this.olvValue.Sortable = false;
      this.olvValue.Text = "Сутки";
      this.olvValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvValue.ToolTipText = "Показания счетчика на начало суток";
      this.olvValue.Width = 65;
      // 
      // olvValueMonth
      // 
      this.olvValueMonth.AspectName = "value_month";
      this.olvValueMonth.CellPadding = null;
      this.olvValueMonth.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvValueMonth.Text = "Месяц";
      this.olvValueMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvValueMonth.ToolTipText = "Показания счетчика на начало месяц";
      this.olvValueMonth.Width = 65;
      // 
      // olvRs
      // 
      this.olvRs.AspectName = "rs_active";
      this.olvRs.CellPadding = null;
      this.olvRs.CheckBoxes = true;
      this.olvRs.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvRs.Sortable = false;
      this.olvRs.Text = "Статистика RS485";
      this.olvRs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvRs.ToolTipText = "Включение в статистику RS485";
      // 
      // menuTree
      // 
      this.menuTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuChange,
            this.toolStripSeparator1,
            this.ctxTreeUpdateNotTrue,
            this.ctxTreeSimpleUpdate});
      this.menuTree.Name = "menuTree";
      this.menuTree.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.menuTree.Size = new System.Drawing.Size(217, 76);
      // 
      // ctxMenuChange
      // 
      this.ctxMenuChange.Image = global::UlcWin.Properties.Resources.gear;
      this.ctxMenuChange.Name = "ctxMenuChange";
      this.ctxMenuChange.Size = new System.Drawing.Size(216, 22);
      this.ctxMenuChange.Text = "Изменить";
      this.ctxMenuChange.Click += new System.EventHandler(this.menu_meter_change);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
      // 
      // ctxTreeUpdateNotTrue
      // 
      this.ctxTreeUpdateNotTrue.Image = global::UlcWin.Properties.Resources.database_refresh;
      this.ctxTreeUpdateNotTrue.Name = "ctxTreeUpdateNotTrue";
      this.ctxTreeUpdateNotTrue.Size = new System.Drawing.Size(216, 22);
      this.ctxTreeUpdateNotTrue.Text = "Обновить недостоверные";
      this.ctxTreeUpdateNotTrue.Click += new System.EventHandler(this.menuTreeUpdateNotTrue_Click);
      // 
      // ctxTreeSimpleUpdate
      // 
      this.ctxTreeSimpleUpdate.Image = global::UlcWin.Properties.Resources.refresh1;
      this.ctxTreeSimpleUpdate.Name = "ctxTreeSimpleUpdate";
      this.ctxTreeSimpleUpdate.Size = new System.Drawing.Size(216, 22);
      this.ctxTreeSimpleUpdate.Text = "Обновить выбранный";
      this.ctxTreeSimpleUpdate.Click += new System.EventHandler(this.ctxTreeSimpleUpdate_Click);
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "ok");
      this.imageList1.Images.SetKeyName(1, "err");
      this.imageList1.Images.SetKeyName(2, "nav_down");
      this.imageList1.Images.SetKeyName(3, "warning");
      this.imageList1.Images.SetKeyName(4, "error");
      this.imageList1.Images.SetKeyName(5, "database_refresh.png");
      this.imageList1.Images.SetKeyName(6, "text.png");
      this.imageList1.Images.SetKeyName(7, "text_tree.png");
      this.imageList1.Images.SetKeyName(8, "part");
      this.imageList1.Images.SetKeyName(9, "excel_exports.png");
      this.imageList1.Images.SetKeyName(10, "error1");
      this.imageList1.Images.SetKeyName(11, "stop");
      this.imageList1.Images.SetKeyName(12, "exc");
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
      this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.status,
            this.Name,
            this.ip,
            this.rs_active,
            this.street_light});
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.Size = new System.Drawing.Size(856, 98);
      this.dataGridView1.TabIndex = 5;
      // 
      // status
      // 
      this.status.FillWeight = 53.35477F;
      this.status.HeaderText = "Активность";
      this.status.Name = "status";
      // 
      // Name
      // 
      this.Name.FillWeight = 203.0457F;
      this.Name.HeaderText = "Имя объекта";
      this.Name.Name = "Name";
      // 
      // ip
      // 
      this.ip.FillWeight = 91.31186F;
      this.ip.HeaderText = "Ip адрес";
      this.ip.Name = "ip";
      // 
      // rs_active
      // 
      this.rs_active.FillWeight = 52.28768F;
      this.rs_active.HeaderText = "Учет RS-485 в статистике";
      this.rs_active.Name = "rs_active";
      this.rs_active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.rs_active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      // 
      // street_light
      // 
      this.street_light.HeaderText = "Уличное освещение";
      this.street_light.Name = "street_light";
      // 
      // objectListView1
      // 
      this.objectListView1.AllColumns.Add(this.olvDt);
      this.objectListView1.AllColumns.Add(this.olvVal);
      this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvDt,
            this.olvVal});
      this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.objectListView1.FullRowSelect = true;
      this.objectListView1.HasCollapsibleGroups = false;
      this.objectListView1.HideSelection = false;
      this.objectListView1.Location = new System.Drawing.Point(0, 0);
      this.objectListView1.Margin = new System.Windows.Forms.Padding(2);
      this.objectListView1.Name = "objectListView1";
      this.objectListView1.ShowGroups = false;
      this.objectListView1.Size = new System.Drawing.Size(240, 547);
      this.objectListView1.TabIndex = 4;
      this.objectListView1.UseCompatibleStateImageBehavior = false;
      this.objectListView1.View = System.Windows.Forms.View.Details;
      this.objectListView1.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.objectListView1_FormatRow);
      // 
      // olvDt
      // 
      this.olvDt.AspectName = "dt";
      this.olvDt.CellPadding = null;
      this.olvDt.Text = "Дата и время";
      this.olvDt.Width = 140;
      // 
      // olvVal
      // 
      this.olvVal.AspectName = "value";
      this.olvVal.CellPadding = null;
      this.olvVal.Text = "Данные";
      this.olvVal.Width = 123;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.tableLayoutPanel1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1107, 590);
      this.panel1.TabIndex = 2;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1107, 590);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.label1);
      this.panel2.Controls.Add(this.textBox1);
      this.panel2.Controls.Add(this.monthPicker1);
      this.panel2.Controls.Add(this.button3);
      this.panel2.Controls.Add(this.panel3);
      this.panel2.Controls.Add(this.button2);
      this.panel2.Controls.Add(this.button1);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(4, 4);
      this.panel2.Margin = new System.Windows.Forms.Padding(2);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(1099, 29);
      this.panel2.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(117, 8);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "Фильтр";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(172, 5);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(202, 20);
      this.textBox1.TabIndex = 5;
      this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
      // 
      // monthPicker1
      // 
      this.monthPicker1.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.monthPicker1.CustomFormat = "MMMM yyyy";
      this.monthPicker1.Location = new System.Drawing.Point(896, 6);
      this.monthPicker1.Name = "monthPicker1";
      this.monthPicker1.Size = new System.Drawing.Size(200, 20);
      this.monthPicker1.TabIndex = 4;
      this.monthPicker1.ValueChanged += new System.EventHandler(this.MeterValueChnged);
      // 
      // button3
      // 
      this.button3.Dock = System.Windows.Forms.DockStyle.Left;
      this.button3.Image = global::UlcWin.Properties.Resources.excel_exports;
      this.button3.Location = new System.Drawing.Point(73, 0);
      this.button3.Margin = new System.Windows.Forms.Padding(22);
      this.button3.Name = "button3";
      this.button3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
      this.button3.Size = new System.Drawing.Size(32, 29);
      this.button3.TabIndex = 3;
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.btnExportExcel);
      // 
      // panel3
      // 
      this.panel3.BackColor = System.Drawing.SystemColors.Control;
      this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel3.Location = new System.Drawing.Point(64, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(9, 29);
      this.panel3.TabIndex = 2;
      // 
      // button2
      // 
      this.button2.Dock = System.Windows.Forms.DockStyle.Left;
      this.button2.ImageIndex = 7;
      this.button2.ImageList = this.imageList1;
      this.button2.Location = new System.Drawing.Point(32, 0);
      this.button2.Margin = new System.Windows.Forms.Padding(22);
      this.button2.Name = "button2";
      this.button2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
      this.button2.Size = new System.Drawing.Size(32, 29);
      this.button2.TabIndex = 1;
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button1
      // 
      this.button1.Dock = System.Windows.Forms.DockStyle.Left;
      this.button1.ImageIndex = 5;
      this.button1.ImageList = this.imageList1;
      this.button1.Location = new System.Drawing.Point(0, 0);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(32, 29);
      this.button1.TabIndex = 0;
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.tsUpdateMeterValue_Click);
      // 
      // UlcTreeView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel1);
      this.Margin = new System.Windows.Forms.Padding(2);
      //this.Name = "UlcTreeView";
      this.Size = new System.Drawing.Size(1107, 590);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.splitMeter.Panel1.ResumeLayout(false);
      this.splitMeter.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitMeter)).EndInit();
      this.splitMeter.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
      this.menuTree.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
      this.panel1.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private BrightIdeasSoftware.OLVColumn olvName;
    private BrightIdeasSoftware.OLVColumn olvDateTime;
    private BrightIdeasSoftware.OLVColumn olvMeterFactory;
    private BrightIdeasSoftware.OLVColumn olvValue;
    private BrightIdeasSoftware.ObjectListView objectListView1;
    private BrightIdeasSoftware.OLVColumn olvDt;
    private BrightIdeasSoftware.OLVColumn olvVal;
    private System.Windows.Forms.ImageList imageList1;
        private BrightIdeasSoftware.OLVColumn olvType;
        private BrightIdeasSoftware.OLVColumn olvIp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ContextMenuStrip menuTree;
    private System.Windows.Forms.ToolStripMenuItem ctxTreeUpdateNotTrue;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.ToolStripMenuItem ctxMenuChange;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem ctxTreeSimpleUpdate;
    public BrightIdeasSoftware.TreeListView treeListView1;
    private UlcWin.ui.MonthPicker monthPicker1;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.SplitContainer splitMeter;
    private System.Windows.Forms.DataGridViewImageColumn status;
    private System.Windows.Forms.DataGridViewTextBoxColumn Name;
    private System.Windows.Forms.DataGridViewTextBoxColumn ip;
    private System.Windows.Forms.DataGridViewCheckBoxColumn rs_active;
    private System.Windows.Forms.DataGridViewTextBoxColumn street_light;
    private BrightIdeasSoftware.OLVColumn olvRs;
    private BrightIdeasSoftware.OLVColumn olvTp;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label1;
    private BrightIdeasSoftware.OLVColumn olvValueMonth;
  }
}
