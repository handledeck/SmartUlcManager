namespace ZtpManager
{
  partial class HistoryForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryForm));
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
      this.pnlFooter = new System.Windows.Forms.Panel();
      this.tbObj = new System.Windows.Forms.TextBox();
      this.pnlFlv = new System.Windows.Forms.Panel();
      this.flv = new ZtpManager.Controls.FilteredListViewControl();
      this.iml = new System.Windows.Forms.ImageList(this.components);
      this.toolStrip.SuspendLayout();
      this.pnlFooter.SuspendLayout();
      this.pnlFlv.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip
      // 
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefresh});
      this.toolStrip.Location = new System.Drawing.Point(0, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new System.Drawing.Size(784, 25);
      this.toolStrip.TabIndex = 0;
      this.toolStrip.Text = "toolStrip1";
      // 
      // tsbRefresh
      // 
      this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
      this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.White;
      this.tsbRefresh.Name = "tsbRefresh";
      this.tsbRefresh.Size = new System.Drawing.Size(81, 22);
      this.tsbRefresh.Text = "Обновить";
      this.tsbRefresh.Click += new System.EventHandler(this.tbsRefresh_Click);
      // 
      // pnlFooter
      // 
      this.pnlFooter.Controls.Add(this.tbObj);
      this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlFooter.Location = new System.Drawing.Point(0, 269);
      this.pnlFooter.Name = "pnlFooter";
      this.pnlFooter.Size = new System.Drawing.Size(784, 107);
      this.pnlFooter.TabIndex = 1;
      // 
      // tbObj
      // 
      this.tbObj.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbObj.Location = new System.Drawing.Point(0, 0);
      this.tbObj.Multiline = true;
      this.tbObj.Name = "tbObj";
      this.tbObj.ReadOnly = true;
      this.tbObj.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tbObj.Size = new System.Drawing.Size(784, 107);
      this.tbObj.TabIndex = 0;
      // 
      // pnlFlv
      // 
      this.pnlFlv.Controls.Add(this.flv);
      this.pnlFlv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlFlv.Location = new System.Drawing.Point(0, 25);
      this.pnlFlv.Name = "pnlFlv";
      this.pnlFlv.Size = new System.Drawing.Size(784, 244);
      this.pnlFlv.TabIndex = 2;
      // 
      // flv
      // 
      this.flv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flv.Location = new System.Drawing.Point(0, 0);
      this.flv.Name = "flv";
      this.flv.Size = new System.Drawing.Size(784, 244);
      this.flv.TabIndex = 0;
      // 
      // iml
      // 
      this.iml.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml.ImageStream")));
      this.iml.TransparentColor = System.Drawing.Color.Transparent;
      this.iml.Images.SetKeyName(0, "check.png");
      this.iml.Images.SetKeyName(1, "delete.png");
      // 
      // HistoryForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 376);
      this.Controls.Add(this.pnlFlv);
      this.Controls.Add(this.pnlFooter);
      this.Controls.Add(this.toolStrip);
      this.Name = "HistoryForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.pnlFooter.ResumeLayout(false);
      this.pnlFooter.PerformLayout();
      this.pnlFlv.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.Panel pnlFooter;
    private System.Windows.Forms.Panel pnlFlv;
    private System.Windows.Forms.ImageList iml;
    private Controls.FilteredListViewControl flv;
    private System.Windows.Forms.TextBox tbObj;
    private System.Windows.Forms.ToolStripButton tsbRefresh;
  }
}