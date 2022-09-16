namespace ZtpManager.Controls
{
  partial class SelectLightPlanControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectLightPlanControl));
      this.flv = new ZtpManager.Controls.FilteredListViewControl();
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.iml = new System.Windows.Forms.ImageList(this.components);
      this.webBrowser = new System.Windows.Forms.WebBrowser();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // flv
      // 
      this.flv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flv.Location = new System.Drawing.Point(0, 0);
      this.flv.Name = "flv";
      this.flv.Size = new System.Drawing.Size(834, 300);
      this.flv.TabIndex = 0;
      // 
      // splitContainer
      // 
      this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer.Location = new System.Drawing.Point(0, 0);
      this.splitContainer.Name = "splitContainer";
      this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer.Panel1
      // 
      this.splitContainer.Panel1.Controls.Add(this.flv);
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.webBrowser);
      this.splitContainer.Size = new System.Drawing.Size(834, 510);
      this.splitContainer.SplitterDistance = 300;
      this.splitContainer.TabIndex = 1;
      // 
      // iml
      // 
      this.iml.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml.ImageStream")));
      this.iml.TransparentColor = System.Drawing.Color.Transparent;
      this.iml.Images.SetKeyName(0, "history.png");
      // 
      // webBrowser
      // 
      this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
      this.webBrowser.Location = new System.Drawing.Point(0, 0);
      this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
      this.webBrowser.Name = "webBrowser";
      this.webBrowser.Size = new System.Drawing.Size(834, 206);
      this.webBrowser.TabIndex = 0;
      this.webBrowser.WebBrowserShortcutsEnabled = false;
      // 
      // SelectLightPlanControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer);
      this.Name = "SelectLightPlanControl";
      this.Size = new System.Drawing.Size(834, 510);
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
      this.splitContainer.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private FilteredListViewControl flv;
    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.ImageList iml;
    private System.Windows.Forms.WebBrowser webBrowser;
  }
}
