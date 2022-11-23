
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
      this.treeListView1 = new BrightIdeasSoftware.TreeListView();
      this.olvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvDateTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvIp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvMeterFactory = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.menuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.menuTreeUpdateNotTrue = new System.Windows.Forms.ToolStripMenuItem();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
      this.olvDt = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvVal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.panel1 = new System.Windows.Forms.Panel();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.button3 = new System.Windows.Forms.Button();
      this.panel3 = new System.Windows.Forms.Panel();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
      this.menuTree.SuspendLayout();
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
      this.splitContainer1.Panel1.Controls.Add(this.treeListView1);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.objectListView1);
      this.splitContainer1.Size = new System.Drawing.Size(1075, 416);
      this.splitContainer1.SplitterDistance = 838;
      this.splitContainer1.SplitterWidth = 3;
      this.splitContainer1.TabIndex = 0;
      // 
      // treeListView1
      // 
      this.treeListView1.AllColumns.Add(this.olvName);
      this.treeListView1.AllColumns.Add(this.olvDateTime);
      this.treeListView1.AllColumns.Add(this.olvType);
      this.treeListView1.AllColumns.Add(this.olvIp);
      this.treeListView1.AllColumns.Add(this.olvMeterFactory);
      this.treeListView1.AllColumns.Add(this.olvValue);
      this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvName,
            this.olvDateTime,
            this.olvType,
            this.olvIp,
            this.olvMeterFactory,
            this.olvValue});
      this.treeListView1.ContextMenuStrip = this.menuTree;
      this.treeListView1.Cursor = System.Windows.Forms.Cursors.Default;
      this.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeListView1.FullRowSelect = true;
      this.treeListView1.HideSelection = false;
      this.treeListView1.IncludeColumnHeadersInCopy = true;
      this.treeListView1.IncludeHiddenColumnsInDataTransfer = true;
      this.treeListView1.Location = new System.Drawing.Point(0, 0);
      this.treeListView1.MultiSelect = false;
      this.treeListView1.Name = "treeListView1";
      this.treeListView1.OwnerDraw = true;
      this.treeListView1.ShowGroups = false;
      this.treeListView1.ShowSortIndicators = false;
      this.treeListView1.Size = new System.Drawing.Size(838, 416);
      this.treeListView1.SmallImageList = this.imageList1;
      this.treeListView1.TabIndex = 4;
      this.treeListView1.UseCompatibleStateImageBehavior = false;
      this.treeListView1.UseFilterIndicator = false;
      this.treeListView1.UseHotItem = true;
      this.treeListView1.View = System.Windows.Forms.View.Details;
      this.treeListView1.VirtualMode = true;
      this.treeListView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.treeListView1_ItemSelectionChanged);
      this.treeListView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeListView1_MouseUp);
      // 
      // olvName
      // 
      this.olvName.AspectName = "name";
      this.olvName.Text = "Имя объекта";
      this.olvName.Width = 316;
      // 
      // olvDateTime
      // 
      this.olvDateTime.AspectName = "date_time";
      this.olvDateTime.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvDateTime.Text = "Дата и время";
      this.olvDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvDateTime.Width = 152;
      // 
      // olvType
      // 
      this.olvType.AspectName = "unit_type_id";
      this.olvType.Text = "Тип";
      // 
      // olvIp
      // 
      this.olvIp.AspectName = "ip";
      this.olvIp.Text = "IP адрес";
      this.olvIp.Width = 112;
      // 
      // olvMeterFactory
      // 
      this.olvMeterFactory.AspectName = "meter_factory";
      this.olvMeterFactory.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvMeterFactory.Text = "Номер счетчика";
      this.olvMeterFactory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvMeterFactory.Width = 146;
      // 
      // olvValue
      // 
      this.olvValue.AspectName = "value";
      this.olvValue.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvValue.Text = "Данные (на начало суток)";
      this.olvValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.olvValue.Width = 177;
      this.olvValue.WordWrap = true;
      // 
      // menuTree
      // 
      this.menuTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTreeUpdateNotTrue});
      this.menuTree.Name = "menuTree";
      this.menuTree.Size = new System.Drawing.Size(217, 48);
      // 
      // menuTreeUpdateNotTrue
      // 
      this.menuTreeUpdateNotTrue.Name = "menuTreeUpdateNotTrue";
      this.menuTreeUpdateNotTrue.Size = new System.Drawing.Size(216, 22);
      this.menuTreeUpdateNotTrue.Text = "Обновить недостоверные";
      this.menuTreeUpdateNotTrue.Click += new System.EventHandler(this.menuTreeUpdateNotTrue_Click);
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "ok");
      this.imageList1.Images.SetKeyName(1, "err");
      this.imageList1.Images.SetKeyName(2, "nav_down");
      this.imageList1.Images.SetKeyName(3, "error");
      this.imageList1.Images.SetKeyName(4, "error1");
      this.imageList1.Images.SetKeyName(5, "database_refresh.png");
      this.imageList1.Images.SetKeyName(6, "text.png");
      this.imageList1.Images.SetKeyName(7, "text_tree.png");
      this.imageList1.Images.SetKeyName(8, "part");
      this.imageList1.Images.SetKeyName(9, "excel_exports.png");
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
      this.objectListView1.Size = new System.Drawing.Size(234, 416);
      this.objectListView1.TabIndex = 4;
      this.objectListView1.UseCompatibleStateImageBehavior = false;
      this.objectListView1.View = System.Windows.Forms.View.Details;
      this.objectListView1.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.objectListView1_FormatRow);
      // 
      // olvDt
      // 
      this.olvDt.AspectName = "dt";
      this.olvDt.Text = "Дата и время";
      this.olvDt.Width = 140;
      // 
      // olvVal
      // 
      this.olvVal.AspectName = "value";
      this.olvVal.Text = "Данные";
      this.olvVal.Width = 123;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.tableLayoutPanel1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1083, 459);
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
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1083, 459);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.button3);
      this.panel2.Controls.Add(this.panel3);
      this.panel2.Controls.Add(this.button2);
      this.panel2.Controls.Add(this.button1);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(4, 4);
      this.panel2.Margin = new System.Windows.Forms.Padding(2);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(1075, 29);
      this.panel2.TabIndex = 1;
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
      this.Name = "UlcTreeView";
      this.Size = new System.Drawing.Size(1083, 459);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
      this.menuTree.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
      this.panel1.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private BrightIdeasSoftware.TreeListView treeListView1;
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
    private System.Windows.Forms.ToolStripMenuItem menuTreeUpdateNotTrue;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Panel panel3;
  }
}
