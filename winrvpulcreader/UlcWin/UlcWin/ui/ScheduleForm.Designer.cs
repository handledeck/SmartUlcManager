namespace UlcWin.ui
{
  partial class ScheduleForm
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
      Ztp.Configuration.ZtpLight ztpLight1 = new Ztp.Configuration.ZtpLight();
      Ztp.Configuration.ZtpScheduler ztpScheduler1 = new Ztp.Configuration.ZtpScheduler();
      Ztp.Ui.LocationEditorControl.ZtpLocation ztpLocation1 = new Ztp.Ui.LocationEditorControl.ZtpLocation();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleForm));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.@__planEditor = new Ztp.Ui.LightPlanEditorControl();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.btnScheduleAdd = new System.Windows.Forms.Button();
      this.imlTc = new System.Windows.Forms.ImageList(this.components);
      this.btnScheduleDelete = new System.Windows.Forms.Button();
      this.btnScheduleEdit = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnAddSeason = new System.Windows.Forms.Button();
      this.btnReamoveSeason = new System.Windows.Forms.Button();
      this.btnChangeSeason = new System.Windows.Forms.Button();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnFile = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.89474F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.10526F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(747, 558);
      this.tableLayoutPanel1.TabIndex = 2;
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tabControl1.ImageList = this.imlTc;
      this.tabControl1.ItemSize = new System.Drawing.Size(130, 30);
      this.tabControl1.Location = new System.Drawing.Point(4, 4);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(739, 492);
      this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage2
      // 
      this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.tabPage2.Controls.Add(this.splitContainer1);
      this.tabPage2.ImageIndex = 7;
      this.tabPage2.Location = new System.Drawing.Point(4, 34);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(731, 454);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "План освещения";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(3, 3);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.@__planEditor);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
      this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
      this.splitContainer1.Size = new System.Drawing.Size(725, 448);
      this.splitContainer1.SplitterDistance = 508;
      this.splitContainer1.SplitterWidth = 5;
      this.splitContainer1.TabIndex = 0;
      // 
      // __planEditor
      // 
      this.@__planEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.@__planEditor.Location = new System.Drawing.Point(0, 0);
      this.@__planEditor.Name = "__planEditor";
      this.@__planEditor.Size = new System.Drawing.Size(508, 448);
      this.@__planEditor.TabIndex = 0;
      this.@__planEditor.UseSchedulerEnable = true;
      this.@__planEditor.UseSchedulerVisible = false;
      ztpLight1.Scheduler = ztpScheduler1;
      ztpLight1.UseScheduler = true;
      this.@__planEditor.Value = ztpLight1;
      ztpLocation1.Latitude = 0F;
      ztpLocation1.Longitude = 0F;
      ztpLocation1.TimeZone = ((sbyte)(0));
      this.@__planEditor.ZtpLocation = ztpLocation1;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.btnScheduleAdd);
      this.groupBox2.Controls.Add(this.btnScheduleDelete);
      this.groupBox2.Controls.Add(this.btnScheduleEdit);
      this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.groupBox2.Location = new System.Drawing.Point(20, 163);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(181, 131);
      this.groupBox2.TabIndex = 9;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Расписание";
      // 
      // btnScheduleAdd
      // 
      this.btnScheduleAdd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnScheduleAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnScheduleAdd.ImageIndex = 7;
      this.btnScheduleAdd.ImageList = this.imlTc;
      this.btnScheduleAdd.Location = new System.Drawing.Point(30, 20);
      this.btnScheduleAdd.Name = "btnScheduleAdd";
      this.btnScheduleAdd.Size = new System.Drawing.Size(123, 31);
      this.btnScheduleAdd.TabIndex = 0;
      this.btnScheduleAdd.Text = "Добавить";
      this.btnScheduleAdd.UseVisualStyleBackColor = true;
      this.btnScheduleAdd.Click += new System.EventHandler(this.btnScheduleAdd_Click);
      // 
      // imlTc
      // 
      this.imlTc.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTc.ImageStream")));
      this.imlTc.TransparentColor = System.Drawing.Color.Transparent;
      this.imlTc.Images.SetKeyName(0, "history.png");
      this.imlTc.Images.SetKeyName(1, "port.png");
      this.imlTc.Images.SetKeyName(2, "bricks.png");
      this.imlTc.Images.SetKeyName(3, "cpu_preferences.png");
      this.imlTc.Images.SetKeyName(4, "bookmark_add.ico");
      this.imlTc.Images.SetKeyName(5, "bookmarks_preferences.ico");
      this.imlTc.Images.SetKeyName(6, "bookmark_delete.ico");
      this.imlTc.Images.SetKeyName(7, "clock.ico");
      this.imlTc.Images.SetKeyName(8, "clock_pause.ico");
      this.imlTc.Images.SetKeyName(9, "clock_preferences.ico");
      this.imlTc.Images.SetKeyName(10, "clock_refresh.ico");
      this.imlTc.Images.SetKeyName(11, "clock_reset.ico");
      this.imlTc.Images.SetKeyName(12, "clock_run.ico");
      this.imlTc.Images.SetKeyName(13, "clock_stop.ico");
      // 
      // btnScheduleDelete
      // 
      this.btnScheduleDelete.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnScheduleDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnScheduleDelete.ImageIndex = 13;
      this.btnScheduleDelete.ImageList = this.imlTc;
      this.btnScheduleDelete.Location = new System.Drawing.Point(30, 90);
      this.btnScheduleDelete.Name = "btnScheduleDelete";
      this.btnScheduleDelete.Size = new System.Drawing.Size(123, 27);
      this.btnScheduleDelete.TabIndex = 1;
      this.btnScheduleDelete.Text = "Удалить";
      this.btnScheduleDelete.UseVisualStyleBackColor = true;
      this.btnScheduleDelete.Click += new System.EventHandler(this.btnScheduleDelete_Click);
      // 
      // btnScheduleEdit
      // 
      this.btnScheduleEdit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnScheduleEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnScheduleEdit.ImageIndex = 9;
      this.btnScheduleEdit.ImageList = this.imlTc;
      this.btnScheduleEdit.Location = new System.Drawing.Point(30, 57);
      this.btnScheduleEdit.Name = "btnScheduleEdit";
      this.btnScheduleEdit.Size = new System.Drawing.Size(123, 27);
      this.btnScheduleEdit.TabIndex = 2;
      this.btnScheduleEdit.Text = "Изменить";
      this.btnScheduleEdit.UseVisualStyleBackColor = true;
      this.btnScheduleEdit.Click += new System.EventHandler(this.btnScheduleEdit_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.btnAddSeason);
      this.groupBox1.Controls.Add(this.btnReamoveSeason);
      this.groupBox1.Controls.Add(this.btnChangeSeason);
      this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.groupBox1.Location = new System.Drawing.Point(20, 16);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(181, 131);
      this.groupBox1.TabIndex = 8;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Сезоны";
      // 
      // btnAddSeason
      // 
      this.btnAddSeason.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnAddSeason.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnAddSeason.ImageIndex = 4;
      this.btnAddSeason.ImageList = this.imlTc;
      this.btnAddSeason.Location = new System.Drawing.Point(30, 20);
      this.btnAddSeason.Name = "btnAddSeason";
      this.btnAddSeason.Size = new System.Drawing.Size(123, 31);
      this.btnAddSeason.TabIndex = 0;
      this.btnAddSeason.Text = "Добавить";
      this.btnAddSeason.UseVisualStyleBackColor = true;
      this.btnAddSeason.Click += new System.EventHandler(this.btnAddSeason_Click);
      // 
      // btnReamoveSeason
      // 
      this.btnReamoveSeason.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnReamoveSeason.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnReamoveSeason.ImageIndex = 5;
      this.btnReamoveSeason.ImageList = this.imlTc;
      this.btnReamoveSeason.Location = new System.Drawing.Point(30, 92);
      this.btnReamoveSeason.Name = "btnReamoveSeason";
      this.btnReamoveSeason.Size = new System.Drawing.Size(123, 27);
      this.btnReamoveSeason.TabIndex = 1;
      this.btnReamoveSeason.Text = "Удалить";
      this.btnReamoveSeason.UseVisualStyleBackColor = true;
      this.btnReamoveSeason.Click += new System.EventHandler(this.btnReamoveSeason_Click);
      // 
      // btnChangeSeason
      // 
      this.btnChangeSeason.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnChangeSeason.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnChangeSeason.ImageIndex = 6;
      this.btnChangeSeason.ImageList = this.imlTc;
      this.btnChangeSeason.Location = new System.Drawing.Point(30, 59);
      this.btnChangeSeason.Name = "btnChangeSeason";
      this.btnChangeSeason.Size = new System.Drawing.Size(123, 27);
      this.btnChangeSeason.TabIndex = 2;
      this.btnChangeSeason.Text = "Изменить";
      this.btnChangeSeason.UseVisualStyleBackColor = true;
      this.btnChangeSeason.Click += new System.EventHandler(this.btnChangeSeason_Click);
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.flowLayoutPanel1.Controls.Add(this.btnOk);
      this.flowLayoutPanel1.Controls.Add(this.btnSave);
      this.flowLayoutPanel1.Controls.Add(this.btnFile);
      this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 512);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(739, 32);
      this.flowLayoutPanel1.TabIndex = 1;
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(628, 3);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(108, 27);
      this.btnOk.TabIndex = 0;
      this.btnOk.Text = "Ок";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnChancel_Click);
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(516, 3);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(106, 27);
      this.btnSave.TabIndex = 0;
      this.btnSave.Text = "Сохранить";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Visible = false;
      // 
      // btnFile
      // 
      this.btnFile.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.btnFile.Location = new System.Drawing.Point(388, 3);
      this.btnFile.Name = "btnFile";
      this.btnFile.Size = new System.Drawing.Size(122, 27);
      this.btnFile.TabIndex = 1;
      this.btnFile.Text = "Из файла";
      this.btnFile.UseVisualStyleBackColor = true;
      this.btnFile.Visible = false;
      // 
      // ScheduleForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(747, 558);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "ScheduleForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Редактор расписания";
      this.TopMost = true;
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tabControl1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.flowLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Ztp.Ui.LightPlanEditorControl __planEditor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnScheduleAdd;
        private System.Windows.Forms.Button btnScheduleDelete;
        private System.Windows.Forms.Button btnScheduleEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddSeason;
        private System.Windows.Forms.Button btnReamoveSeason;
        private System.Windows.Forms.Button btnChangeSeason;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFile;
        public System.Windows.Forms.ImageList imlTc;
  }
}