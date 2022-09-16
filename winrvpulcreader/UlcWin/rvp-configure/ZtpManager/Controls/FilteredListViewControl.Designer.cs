namespace ZtpManager.Controls
{
  partial class FilteredListViewControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilteredListViewControl));
      this.iml = new System.Windows.Forms.ImageList(this.components);
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.tstbFilter = new System.Windows.Forms.ToolStripTextBox();
      this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
      this.toolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // iml
      // 
      this.iml.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml.ImageStream")));
      this.iml.TransparentColor = System.Drawing.Color.Transparent;
      this.iml.Images.SetKeyName(0, "PCI-card.png");
      // 
      // toolStrip
      // 
      this.toolStrip.CanOverflow = false;
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tstbFilter,
            this.tsbRefresh});
      this.toolStrip.Location = new System.Drawing.Point(0, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new System.Drawing.Size(511, 25);
      this.toolStrip.TabIndex = 0;
      this.toolStrip.Text = "toolStrip1";
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(48, 22);
      this.toolStripLabel1.Text = "Фильтр";
      // 
      // tstbFilter
      // 
      this.tstbFilter.AutoSize = false;
      this.tstbFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tstbFilter.Name = "tstbFilter";
      this.tstbFilter.Size = new System.Drawing.Size(300, 23);
      this.tstbFilter.TextChanged += new System.EventHandler(this.tstbFilter_TextChanged);
      // 
      // tsbRefresh
      // 
      this.tsbRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
      this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbRefresh.Name = "tsbRefresh";
      this.tsbRefresh.Size = new System.Drawing.Size(81, 22);
      this.tsbRefresh.Text = "Обновить";
      // 
      // FilteredListViewControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.toolStrip);
      this.Name = "FilteredListViewControl";
      this.Size = new System.Drawing.Size(511, 258);
      this.SizeChanged += new System.EventHandler(this.FilteredListViewControl_SizeChanged);
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ImageList iml;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStripTextBox tstbFilter;
    private System.Windows.Forms.ToolStripButton tsbRefresh;
  }
}
