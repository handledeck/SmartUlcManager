namespace ZtpManager
{
  partial class ObjectListForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectListForm));
      this.flv = new ZtpManager.Controls.FilteredListViewControl();
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.tsbSave = new System.Windows.Forms.ToolStripDropDownButton();
      this.tsbSaveAsXml = new System.Windows.Forms.ToolStripMenuItem();
      this.tsbSaveAsCsv = new System.Windows.Forms.ToolStripMenuItem();
      this.iml = new System.Windows.Forms.ImageList(this.components);
      this.sfd = new System.Windows.Forms.SaveFileDialog();
      this.toolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // flv
      // 
      this.flv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flv.Location = new System.Drawing.Point(0, 25);
      this.flv.Name = "flv";
      this.flv.Size = new System.Drawing.Size(648, 494);
      this.flv.TabIndex = 1;
      // 
      // toolStrip
      // 
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave});
      this.toolStrip.Location = new System.Drawing.Point(0, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new System.Drawing.Size(648, 25);
      this.toolStrip.TabIndex = 2;
      this.toolStrip.Text = "toolStrip1";
      // 
      // tsbSave
      // 
      this.tsbSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSaveAsXml,
            this.tsbSaveAsCsv});
      this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
      this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbSave.Name = "tsbSave";
      this.tsbSave.Size = new System.Drawing.Size(124, 22);
      this.tsbSave.Text = "Сохранить как...";
      // 
      // tsbSaveAsXml
      // 
      this.tsbSaveAsXml.Name = "tsbSaveAsXml";
      this.tsbSaveAsXml.Size = new System.Drawing.Size(191, 22);
      this.tsbSaveAsXml.Text = "Файл в формате XML";
      this.tsbSaveAsXml.Click += new System.EventHandler(this.tsbSaveAsXml_Click);
      // 
      // tsbSaveAsCsv
      // 
      this.tsbSaveAsCsv.Name = "tsbSaveAsCsv";
      this.tsbSaveAsCsv.Size = new System.Drawing.Size(191, 22);
      this.tsbSaveAsCsv.Text = "Файл в формате CSV";
      this.tsbSaveAsCsv.Click += new System.EventHandler(this.tsbSaveAsCsv_Click);
      // 
      // iml
      // 
      this.iml.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml.ImageStream")));
      this.iml.TransparentColor = System.Drawing.Color.Transparent;
      this.iml.Images.SetKeyName(0, "ip.png");
      // 
      // sfd
      // 
      this.sfd.RestoreDirectory = true;
      this.sfd.Title = "Сохранить адреса в...";
      // 
      // IpAddressForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(648, 519);
      this.Controls.Add(this.flv);
      this.Controls.Add(this.toolStrip);
      this.MinimizeBox = false;
      this.Name = "IpAddressForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Список объектов";
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private Controls.FilteredListViewControl flv;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ToolStripDropDownButton tsbSave;
    private System.Windows.Forms.ToolStripMenuItem tsbSaveAsXml;
    private System.Windows.Forms.ToolStripMenuItem tsbSaveAsCsv;
    private System.Windows.Forms.ImageList iml;
    private System.Windows.Forms.SaveFileDialog sfd;
  }
}