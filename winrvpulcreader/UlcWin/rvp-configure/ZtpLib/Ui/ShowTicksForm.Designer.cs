namespace Ztp.Ui
{
  partial class ShowTicksForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowTicksForm));
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnClose = new System.Windows.Forms.Button();
      this.listView = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.iml = new System.Windows.Forms.ImageList(this.components);
      this.locationEditorControl = new Ztp.Ui.LocationEditorControl();
      this.pnlLocation = new System.Windows.Forms.Panel();
      this.btnRefresh = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.pnlLocation.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnClose);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 347);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(704, 35);
      this.panel1.TabIndex = 0;
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnClose.Location = new System.Drawing.Point(617, 3);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 0;
      this.btnClose.Text = "Закрыть";
      this.btnClose.UseVisualStyleBackColor = true;
      // 
      // listView
      // 
      this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listView.FullRowSelect = true;
      this.listView.Location = new System.Drawing.Point(0, 33);
      this.listView.Name = "listView";
      this.listView.Size = new System.Drawing.Size(704, 314);
      this.listView.SmallImageList = this.iml;
      this.listView.TabIndex = 2;
      this.listView.UseCompatibleStateImageBehavior = false;
      this.listView.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Включение";
      this.columnHeader1.Width = 150;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Выключение";
      this.columnHeader2.Width = 150;
      // 
      // iml
      // 
      this.iml.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml.ImageStream")));
      this.iml.TransparentColor = System.Drawing.Color.Transparent;
      this.iml.Images.SetKeyName(0, "absolute.png");
      this.iml.Images.SetKeyName(1, "relative.png");
      // 
      // locationEditorControl
      // 
      this.locationEditorControl.Location = new System.Drawing.Point(3, 3);
      this.locationEditorControl.Name = "locationEditorControl";
      this.locationEditorControl.Size = new System.Drawing.Size(615, 28);
      this.locationEditorControl.TabIndex = 3;
      this.locationEditorControl.Value = null;
      // 
      // pnlLocation
      // 
      this.pnlLocation.Controls.Add(this.btnRefresh);
      this.pnlLocation.Controls.Add(this.locationEditorControl);
      this.pnlLocation.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlLocation.Location = new System.Drawing.Point(0, 0);
      this.pnlLocation.Name = "pnlLocation";
      this.pnlLocation.Size = new System.Drawing.Size(704, 33);
      this.pnlLocation.TabIndex = 4;
      // 
      // btnRefresh
      // 
      this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnRefresh.Location = new System.Drawing.Point(617, 5);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(75, 23);
      this.btnRefresh.TabIndex = 4;
      this.btnRefresh.Text = "Обновить";
      this.btnRefresh.UseVisualStyleBackColor = true;
      this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      // 
      // ShowTicksForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnClose;
      this.ClientSize = new System.Drawing.Size(704, 382);
      this.Controls.Add(this.listView);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.pnlLocation);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(720, 200);
      this.Name = "ShowTicksForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Срабатывания расписания";
      this.panel1.ResumeLayout(false);
      this.pnlLocation.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.ListView listView;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ImageList iml;
    private LocationEditorControl locationEditorControl;
    private System.Windows.Forms.Panel pnlLocation;
    private System.Windows.Forms.Button btnRefresh;
  }
}