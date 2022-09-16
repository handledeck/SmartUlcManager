namespace UlcWin.ui
{
  partial class LogsViewForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogsViewForm));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.cbEvents = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.cbUsers = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cbDateTime = new System.Windows.Forms.DateTimePicker();
      this.lstLogEvents = new System.Windows.Forms.ListView();
      this.clnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.clnUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.clnEventNmae = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.clnItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.tableLayoutPanel1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.lstLogEvents, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.107926F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.89207F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1247, 710);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.cbEvents);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.cbUsers);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.cbDateTime);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(7, 7);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1233, 36);
      this.panel1.TabIndex = 0;
      // 
      // cbEvents
      // 
      this.cbEvents.FormattingEnabled = true;
      this.cbEvents.Location = new System.Drawing.Point(627, 9);
      this.cbEvents.Name = "cbEvents";
      this.cbEvents.Size = new System.Drawing.Size(275, 21);
      this.cbEvents.TabIndex = 5;
      this.cbEvents.SelectedIndexChanged += new System.EventHandler(this.cbEvents_SelectedIndexChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(563, 13);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(58, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Событие";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(254, 13);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(89, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Пользователь";
      // 
      // cbUsers
      // 
      this.cbUsers.DisplayMember = "Text";
      this.cbUsers.FormattingEnabled = true;
      this.cbUsers.Location = new System.Drawing.Point(349, 9);
      this.cbUsers.Name = "cbUsers";
      this.cbUsers.Size = new System.Drawing.Size(196, 21);
      this.cbUsers.TabIndex = 2;
      this.cbUsers.ValueMember = "Value";
      this.cbUsers.SelectedIndexChanged += new System.EventHandler(this.cbUsers_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(33, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(34, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Дата";
      // 
      // cbDateTime
      // 
      this.cbDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.cbDateTime.Location = new System.Drawing.Point(73, 9);
      this.cbDateTime.Name = "cbDateTime";
      this.cbDateTime.Size = new System.Drawing.Size(157, 21);
      this.cbDateTime.TabIndex = 0;
      this.cbDateTime.ValueChanged += new System.EventHandler(this.cbDateTime_ValueChanged);
      // 
      // lstLogEvents
      // 
      this.lstLogEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnDate,
            this.clnUser,
            this.clnEventNmae,
            this.clnItem});
      this.lstLogEvents.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstLogEvents.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lstLogEvents.FullRowSelect = true;
      this.lstLogEvents.HideSelection = false;
      this.lstLogEvents.Location = new System.Drawing.Point(7, 50);
      this.lstLogEvents.Name = "lstLogEvents";
      this.lstLogEvents.Size = new System.Drawing.Size(1233, 653);
      this.lstLogEvents.SmallImageList = this.imageList1;
      this.lstLogEvents.TabIndex = 1;
      this.lstLogEvents.UseCompatibleStateImageBehavior = false;
      this.lstLogEvents.View = System.Windows.Forms.View.Details;
      // 
      // clnDate
      // 
      this.clnDate.Text = "Дата";
      this.clnDate.Width = 150;
      // 
      // clnUser
      // 
      this.clnUser.Text = "Пользователь";
      this.clnUser.Width = 220;
      // 
      // clnEventNmae
      // 
      this.clnEventNmae.Text = "Событие";
      this.clnEventNmae.Width = 225;
      // 
      // clnItem
      // 
      this.clnItem.Text = "Объект";
      this.clnItem.Width = 595;
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "add2.png");
      this.imageList1.Images.SetKeyName(1, "delete2.png");
      this.imageList1.Images.SetKeyName(2, "folder_add.png");
      this.imageList1.Images.SetKeyName(3, "folder_delete.png");
      this.imageList1.Images.SetKeyName(4, "folder_edit.png");
      this.imageList1.Images.SetKeyName(5, "user1_add.png");
      this.imageList1.Images.SetKeyName(6, "user1_delete.png");
      this.imageList1.Images.SetKeyName(7, "user1_information.png");
      this.imageList1.Images.SetKeyName(8, "note_edit.ico");
      this.imageList1.Images.SetKeyName(9, "lock_ok.png");
      this.imageList1.Images.SetKeyName(10, "lock_delete.png");
      this.imageList1.Images.SetKeyName(11, "shield_red.png");
      this.imageList1.Images.SetKeyName(12, "note_edit.png");
      this.imageList1.Images.SetKeyName(13, "document_add.png");
      this.imageList1.Images.SetKeyName(14, "document_delete.png");
      this.imageList1.Images.SetKeyName(15, "document_edit.png");
      // 
      // LogsViewForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1247, 710);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "LogsViewForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Журнал событий";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker cbDateTime;
        private System.Windows.Forms.ListView lstLogEvents;
        private System.Windows.Forms.ColumnHeader clnDate;
        private System.Windows.Forms.ColumnHeader clnUser;
        private System.Windows.Forms.ColumnHeader clnEventNmae;
        private System.Windows.Forms.ColumnHeader clnItem;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.ComboBox cbEvents;
    private System.Windows.Forms.Label label3;
  }
}