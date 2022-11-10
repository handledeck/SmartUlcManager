
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
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
      this.olvDt = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.olvVal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.tsUpdateMeterValue = new System.Windows.Forms.ToolStripButton();
      this.panel1 = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
      this.toolStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Margin = new System.Windows.Forms.Padding(20);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.treeListView1);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.objectListView1);
      this.splitContainer1.Size = new System.Drawing.Size(1083, 434);
      this.splitContainer1.SplitterDistance = 757;
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
      this.treeListView1.Size = new System.Drawing.Size(757, 434);
      this.treeListView1.SmallImageList = this.imageList1;
      this.treeListView1.TabIndex = 4;
      this.treeListView1.UseCompatibleStateImageBehavior = false;
      this.treeListView1.UseFilterIndicator = false;
      this.treeListView1.UseHotItem = true;
      this.treeListView1.View = System.Windows.Forms.View.Details;
      this.treeListView1.VirtualMode = true;
      this.treeListView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.treeListView1_ItemSelectionChanged);
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
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "ok");
      this.imageList1.Images.SetKeyName(1, "err");
      this.imageList1.Images.SetKeyName(2, "nav_down");
      this.imageList1.Images.SetKeyName(3, "error");
      this.imageList1.Images.SetKeyName(4, "delete2.ico");
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
      this.objectListView1.Size = new System.Drawing.Size(323, 434);
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
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsUpdateMeterValue});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(1083, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // tsUpdateMeterValue
      // 
      this.tsUpdateMeterValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsUpdateMeterValue.Image = ((System.Drawing.Image)(resources.GetObject("tsUpdateMeterValue.Image")));
      this.tsUpdateMeterValue.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsUpdateMeterValue.Name = "tsUpdateMeterValue";
      this.tsUpdateMeterValue.Size = new System.Drawing.Size(23, 22);
      this.tsUpdateMeterValue.Text = "toolStripButton1";
      this.tsUpdateMeterValue.Click += new System.EventHandler(this.tsUpdateMeterValue_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.splitContainer1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 25);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1083, 434);
      this.panel1.TabIndex = 2;
      // 
      // UlcTreeView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.toolStrip1);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "UlcTreeView";
      this.Size = new System.Drawing.Size(1083, 459);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsUpdateMeterValue;
        private System.Windows.Forms.Panel panel1;
    }
}
