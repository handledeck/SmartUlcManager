namespace ZtpManager
{
  partial class MultiFotaForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;


    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiFotaForm));
      this.pnlFooter = new System.Windows.Forms.Panel();
      this.btnCheckVersion = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.selectDevTypeControl = new Ztp.Ui.SelectDevTypeControl();
      this.fotaInfoTelit = new Ztp.Ui.FotaInfoControlTelit();
      this.fotaInfo = new Ztp.Ui.FotaInfoControl();
      this.listView1 = new System.Windows.Forms.ListView();
      this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chIp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.selectDeviceControl = new ZtpManager.Controls.SelectDeviceControl();
      this.pnlFooter.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlFooter
      // 
      this.pnlFooter.Controls.Add(this.btnCheckVersion);
      this.pnlFooter.Controls.Add(this.label1);
      this.pnlFooter.Controls.Add(this.btnCancel);
      this.pnlFooter.Controls.Add(this.btnOk);
      this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlFooter.Location = new System.Drawing.Point(0, 458);
      this.pnlFooter.Name = "pnlFooter";
      this.pnlFooter.Size = new System.Drawing.Size(779, 53);
      this.pnlFooter.TabIndex = 3;
      // 
      // btnCheckVersion
      // 
      this.btnCheckVersion.Location = new System.Drawing.Point(412, 18);
      this.btnCheckVersion.Name = "btnCheckVersion";
      this.btnCheckVersion.Size = new System.Drawing.Size(193, 23);
      this.btnCheckVersion.TabIndex = 3;
      this.btnCheckVersion.Text = "Поиск устройств для обновления";
      this.btnCheckVersion.UseVisualStyleBackColor = true;
      this.btnCheckVersion.Click += new System.EventHandler(this.btnCheckVersion_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "label1";
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(692, 18);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.Location = new System.Drawing.Point(611, 18);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 0;
      this.btnOk.Text = "Записать";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // splitContainer
      // 
      this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer.Location = new System.Drawing.Point(0, 0);
      this.splitContainer.Name = "splitContainer";
      // 
      // splitContainer.Panel1
      // 
      this.splitContainer.Panel1.Controls.Add(this.groupBox1);
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.listView1);
      this.splitContainer.Panel2.Controls.Add(this.fotaInfoTelit);
      this.splitContainer.Panel2.Controls.Add(this.fotaInfo);
      this.splitContainer.Size = new System.Drawing.Size(779, 458);
      this.splitContainer.SplitterDistance = 316;
      this.splitContainer.TabIndex = 4;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.selectDevTypeControl);
      this.groupBox1.Controls.Add(this.selectDeviceControl);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(316, 458);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Список устройств";
      // 
      // selectDevTypeControl
      // 
      this.selectDevTypeControl.Caption = "Тип устройства";
      this.selectDevTypeControl.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.selectDevTypeControl.Location = new System.Drawing.Point(3, 429);
      this.selectDevTypeControl.Name = "selectDevTypeControl";
      this.selectDevTypeControl.Size = new System.Drawing.Size(310, 26);
      this.selectDevTypeControl.TabIndex = 1;
      this.selectDevTypeControl.Value = Ztp.Enums.DevType.RVP18;
      // 
      // fotaInfoTelit
      // 
      this.fotaInfoTelit.Dock = System.Windows.Forms.DockStyle.Top;
      this.fotaInfoTelit.IconImage = ((System.Drawing.Image)(resources.GetObject("fotaInfoTelit.IconImage")));
      this.fotaInfoTelit.Location = new System.Drawing.Point(0, 187);
      this.fotaInfoTelit.Name = "fotaInfoTelit";
      this.fotaInfoTelit.Size = new System.Drawing.Size(459, 160);
      this.fotaInfoTelit.TabIndex = 2;
      // 
      // fotaInfo
      // 
      this.fotaInfo.Dock = System.Windows.Forms.DockStyle.Top;
      this.fotaInfo.IconImage = ((System.Drawing.Image)(resources.GetObject("fotaInfo.IconImage")));
      this.fotaInfo.Location = new System.Drawing.Point(0, 0);
      this.fotaInfo.Name = "fotaInfo";
      this.fotaInfo.Size = new System.Drawing.Size(459, 187);
      this.fotaInfo.TabIndex = 0;
      // 
      // listView1
      // 
      this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chIp,
            this.chVersion,
            this.chStatus});
      this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listView1.HideSelection = false;
      this.listView1.Location = new System.Drawing.Point(0, 347);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(459, 111);
      this.listView1.TabIndex = 3;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      // 
      // chId
      // 
      this.chId.Text = "Id";
      // 
      // chIp
      // 
      this.chIp.Text = "Ip";
      this.chIp.Width = 115;
      // 
      // chVersion
      // 
      this.chVersion.Text = "Версия устройства";
      this.chVersion.Width = 167;
      // 
      // chStatus
      // 
      this.chStatus.Text = "Статус";
      this.chStatus.Width = 113;
      // 
      // selectDeviceControl
      // 
      this.selectDeviceControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.selectDeviceControl.Location = new System.Drawing.Point(3, 16);
      this.selectDeviceControl.Name = "selectDeviceControl";
      this.selectDeviceControl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 28);
      this.selectDeviceControl.Size = new System.Drawing.Size(310, 439);
      this.selectDeviceControl.TabIndex = 0;
      // 
      // MultiFotaForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(779, 511);
      this.Controls.Add(this.splitContainer);
      this.Controls.Add(this.pnlFooter);
      this.MinimizeBox = false;
      this.Name = "MultiFotaForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Пакетная запись ПО контроллера";
      this.pnlFooter.ResumeLayout(false);
      this.pnlFooter.PerformLayout();
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
      this.splitContainer.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlFooter;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.GroupBox groupBox1;
    private Controls.SelectDeviceControl selectDeviceControl;
    private Ztp.Ui.FotaInfoControl fotaInfo;
    private Ztp.Ui.FotaInfoControlTelit fotaInfoTelit;
    private Ztp.Ui.SelectDevTypeControl selectDevTypeControl;
    private System.Windows.Forms.Button btnCheckVersion;
    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.ColumnHeader chId;
    private System.Windows.Forms.ColumnHeader chIp;
    private System.Windows.Forms.ColumnHeader chVersion;
    private System.Windows.Forms.ColumnHeader chStatus;
  }
}