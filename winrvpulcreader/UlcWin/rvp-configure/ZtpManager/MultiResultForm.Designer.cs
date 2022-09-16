namespace ZtpManager
{
  partial class MultiResultForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiResultForm));
      this.lv = new BrightIdeasSoftware.ObjectListView();
      this.btnClose = new System.Windows.Forms.Button();
      this.iml = new System.Windows.Forms.ImageList(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.lv)).BeginInit();
      this.SuspendLayout();
      // 
      // lv
      // 
      this.lv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lv.CellEditUseWholeCell = false;
      this.lv.FullRowSelect = true;
      this.lv.HideSelection = false;
      this.lv.Location = new System.Drawing.Point(12, 12);
      this.lv.Name = "lv";
      this.lv.ShowGroups = false;
      this.lv.Size = new System.Drawing.Size(690, 319);
      this.lv.SmallImageList = this.iml;
      this.lv.TabIndex = 0;
      this.lv.UseCompatibleStateImageBehavior = false;
      this.lv.View = System.Windows.Forms.View.Details;
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnClose.Location = new System.Drawing.Point(627, 337);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 1;
      this.btnClose.Text = "Закрыть";
      this.btnClose.UseVisualStyleBackColor = true;
      // 
      // iml
      // 
      this.iml.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml.ImageStream")));
      this.iml.TransparentColor = System.Drawing.Color.Transparent;
      this.iml.Images.SetKeyName(0, "check2.png");
      this.iml.Images.SetKeyName(1, "exclamation.png");
      // 
      // MultiResultForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnClose;
      this.ClientSize = new System.Drawing.Size(714, 372);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.lv);
      this.MinimizeBox = false;
      this.Name = "MultiResultForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Результат операции";
      ((System.ComponentModel.ISupportInitialize)(this.lv)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private BrightIdeasSoftware.ObjectListView lv;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.ImageList iml;
  }
}