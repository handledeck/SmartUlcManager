namespace ZtpManager
{
  partial class MultiPatchForm
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
      this.pnlFooter = new System.Windows.Forms.Panel();
      this.btnCheckVersion = new System.Windows.Forms.Button();
      this.btnStartWrite = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.selectDeviceControl = new ZtpManager.Controls.SelectDeviceControl();
      this.pnlTable = new System.Windows.Forms.Panel();
      this.listView1 = new System.Windows.Forms.ListView();
      this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chIp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chCore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.pnlHeader = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      this.pnlFooter.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.pnlTable.SuspendLayout();
      this.pnlHeader.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlFooter
      // 
      this.pnlFooter.Controls.Add(this.btnCheckVersion);
      this.pnlFooter.Controls.Add(this.btnStartWrite);
      this.pnlFooter.Controls.Add(this.btnCancel);
      this.pnlFooter.Controls.Add(this.label1);
      this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlFooter.Location = new System.Drawing.Point(0, 400);
      this.pnlFooter.Name = "pnlFooter";
      this.pnlFooter.Size = new System.Drawing.Size(800, 50);
      this.pnlFooter.TabIndex = 0;
      // 
      // btnCheckVersion
      // 
      this.btnCheckVersion.Location = new System.Drawing.Point(337, 17);
      this.btnCheckVersion.Name = "btnCheckVersion";
      this.btnCheckVersion.Size = new System.Drawing.Size(257, 23);
      this.btnCheckVersion.TabIndex = 3;
      this.btnCheckVersion.Text = "Поиск устройств с устаревшей версией ядра";
      this.btnCheckVersion.UseVisualStyleBackColor = true;
      this.btnCheckVersion.Click += new System.EventHandler(this.btnCheckVersion_Click);
      // 
      // btnStartWrite
      // 
      this.btnStartWrite.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnStartWrite.Location = new System.Drawing.Point(600, 17);
      this.btnStartWrite.Name = "btnStartWrite";
      this.btnStartWrite.Size = new System.Drawing.Size(105, 23);
      this.btnStartWrite.TabIndex = 2;
      this.btnStartWrite.Text = "Начать запись";
      this.btnStartWrite.UseVisualStyleBackColor = true;
      this.btnStartWrite.Click += new System.EventHandler(this.btnStartWrite_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(713, 17);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "label1";
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.pnlTable);
      this.splitContainer1.Panel2.Controls.Add(this.pnlHeader);
      this.splitContainer1.Size = new System.Drawing.Size(800, 400);
      this.splitContainer1.SplitterDistance = 266;
      this.splitContainer1.TabIndex = 1;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.selectDeviceControl);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(266, 400);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Устройства";
      // 
      // selectDeviceControl
      // 
      this.selectDeviceControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.selectDeviceControl.Location = new System.Drawing.Point(3, 16);
      this.selectDeviceControl.Name = "selectDeviceControl";
      this.selectDeviceControl.Size = new System.Drawing.Size(260, 381);
      this.selectDeviceControl.TabIndex = 0;
      this.selectDeviceControl.SelectionChanged += new System.EventHandler(this.selectDeviceControl_SelectionChanged);
      // 
      // pnlTable
      // 
      this.pnlTable.Controls.Add(this.listView1);
      this.pnlTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlTable.Location = new System.Drawing.Point(0, 44);
      this.pnlTable.Name = "pnlTable";
      this.pnlTable.Size = new System.Drawing.Size(530, 356);
      this.pnlTable.TabIndex = 1;
      // 
      // listView1
      // 
      this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chIp,
            this.chCore,
            this.chStatus});
      this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listView1.HideSelection = false;
      this.listView1.Location = new System.Drawing.Point(0, 0);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(530, 356);
      this.listView1.TabIndex = 0;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      // 
      // chId
      // 
      this.chId.Tag = "Id";
      this.chId.Text = "Id";
      this.chId.Width = 65;
      // 
      // chIp
      // 
      this.chIp.Text = "IP-адрес";
      this.chIp.Width = 120;
      // 
      // chCore
      // 
      this.chCore.Text = "Версия ядра";
      this.chCore.Width = 133;
      // 
      // chStatus
      // 
      this.chStatus.Text = "Статус";
      this.chStatus.Width = 208;
      // 
      // pnlHeader
      // 
      this.pnlHeader.Controls.Add(this.label2);
      this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlHeader.Location = new System.Drawing.Point(0, 0);
      this.pnlHeader.Name = "pnlHeader";
      this.pnlHeader.Size = new System.Drawing.Size(530, 44);
      this.pnlHeader.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.ForeColor = System.Drawing.Color.Red;
      this.label2.Location = new System.Drawing.Point(0, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(530, 44);
      this.label2.TabIndex = 0;
      this.label2.Text = "Данный функционал предназначен только для ULC02";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // MultiPatchForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.pnlFooter);
      this.Name = "MultiPatchForm";
      this.Text = "MultiPatchForm";
      this.pnlFooter.ResumeLayout(false);
      this.pnlFooter.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.pnlTable.ResumeLayout(false);
      this.pnlHeader.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlFooter;
    private System.Windows.Forms.Button btnCheckVersion;
    private System.Windows.Forms.Button btnStartWrite;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.GroupBox groupBox1;
    private Controls.SelectDeviceControl selectDeviceControl;
    private System.Windows.Forms.Panel pnlTable;
    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.ColumnHeader chId;
    private System.Windows.Forms.ColumnHeader chIp;
    private System.Windows.Forms.ColumnHeader chCore;
    private System.Windows.Forms.ColumnHeader chStatus;
    private System.Windows.Forms.Label label2;
  }
}