namespace Ztp.Ui
{
  partial class ModbusItemListControl
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.bAddLabel = new System.Windows.Forms.Button();
      this.bCorrectTag = new System.Windows.Forms.Button();
      this.bAddTag = new System.Windows.Forms.Button();
      this.bDeleteTag = new System.Windows.Forms.Button();
      this.listView1 = new System.Windows.Forms.ListView();
      this.chIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chFieldAddr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chIecIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chDBZ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.splitContainer);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(433, 148);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Список тегов опроса модбас";
      // 
      // splitContainer
      // 
      this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer.IsSplitterFixed = true;
      this.splitContainer.Location = new System.Drawing.Point(3, 16);
      this.splitContainer.Name = "splitContainer";
      this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer.Panel1
      // 
      this.splitContainer.Panel1.Controls.Add(this.bAddLabel);
      this.splitContainer.Panel1.Controls.Add(this.bCorrectTag);
      this.splitContainer.Panel1.Controls.Add(this.bAddTag);
      this.splitContainer.Panel1.Controls.Add(this.bDeleteTag);
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.listView1);
      this.splitContainer.Size = new System.Drawing.Size(427, 129);
      this.splitContainer.SplitterDistance = 27;
      this.splitContainer.TabIndex = 2;
      // 
      // bAddLabel
      // 
      this.bAddLabel.Location = new System.Drawing.Point(273, 3);
      this.bAddLabel.Name = "bAddLabel";
      this.bAddLabel.Size = new System.Drawing.Size(151, 23);
      this.bAddLabel.TabIndex = 3;
      this.bAddLabel.Text = "Редактировать описание тега";
      this.bAddLabel.UseVisualStyleBackColor = true;
      this.bAddLabel.Click += new System.EventHandler(this.bAddLabel_Click);
      // 
      // bCorrectTag
      // 
      this.bCorrectTag.Location = new System.Drawing.Point(183, 3);
      this.bCorrectTag.Name = "bCorrectTag";
      this.bCorrectTag.Size = new System.Drawing.Size(85, 23);
      this.bCorrectTag.TabIndex = 2;
      this.bCorrectTag.Text = "Править тег";
      this.bCorrectTag.UseVisualStyleBackColor = true;
      this.bCorrectTag.Click += new System.EventHandler(this.bCorrectTag_Click);
      // 
      // bAddTag
      // 
      this.bAddTag.Location = new System.Drawing.Point(3, 3);
      this.bAddTag.Name = "bAddTag";
      this.bAddTag.Size = new System.Drawing.Size(86, 23);
      this.bAddTag.TabIndex = 0;
      this.bAddTag.Text = "Добавить тег";
      this.bAddTag.UseVisualStyleBackColor = true;
      this.bAddTag.Click += new System.EventHandler(this.bAddTag_Click);
      // 
      // bDeleteTag
      // 
      this.bDeleteTag.Location = new System.Drawing.Point(95, 3);
      this.bDeleteTag.Name = "bDeleteTag";
      this.bDeleteTag.Size = new System.Drawing.Size(82, 23);
      this.bDeleteTag.TabIndex = 1;
      this.bDeleteTag.Text = "Удалить тег";
      this.bDeleteTag.UseVisualStyleBackColor = true;
      this.bDeleteTag.Click += new System.EventHandler(this.bDeleteTag_Click);
      // 
      // listView1
      // 
      this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chIndex,
            this.chAddress,
            this.chType,
            this.chFieldAddr,
            this.chIecIndex,
            this.chDBZ,
            this.chLabel});
      this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listView1.FullRowSelect = true;
      this.listView1.GridLines = true;
      this.listView1.HideSelection = false;
      this.listView1.Location = new System.Drawing.Point(0, 0);
      this.listView1.MultiSelect = false;
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(427, 98);
      this.listView1.TabIndex = 0;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
      // 
      // chIndex
      // 
      this.chIndex.Text = "номер";
      this.chIndex.Width = 45;
      // 
      // chAddress
      // 
      this.chAddress.Text = "Адрес устройства";
      this.chAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.chAddress.Width = 105;
      // 
      // chType
      // 
      this.chType.Text = "Команда";
      this.chType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.chType.Width = 70;
      // 
      // chFieldAddr
      // 
      this.chFieldAddr.Text = "Адрес поля";
      this.chFieldAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.chFieldAddr.Width = 100;
      // 
      // chIecIndex
      // 
      this.chIecIndex.Text = "id мэк104";
      this.chIecIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.chIecIndex.Width = 80;
      // 
      // chDBZ
      // 
      this.chDBZ.Text = "Зона нч, %";
      this.chDBZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.chDBZ.Width = 70;
      // 
      // chLabel
      // 
      this.chLabel.Text = "Описание тега";
      this.chLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.chLabel.Width = 105;
      // 
      // ModbusItemListControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.Controls.Add(this.groupBox1);
      this.Name = "ModbusItemListControl";
      this.Size = new System.Drawing.Size(433, 148);
      this.groupBox1.ResumeLayout(false);
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
      this.splitContainer.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.ColumnHeader chIndex;
    private System.Windows.Forms.ColumnHeader chAddress;
    private System.Windows.Forms.ColumnHeader chType;
    private System.Windows.Forms.ColumnHeader chFieldAddr;
    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.Button bCorrectTag;
    private System.Windows.Forms.Button bAddTag;
    private System.Windows.Forms.Button bDeleteTag;
    private System.Windows.Forms.ColumnHeader chIecIndex;
    private System.Windows.Forms.ColumnHeader chLabel;
    private System.Windows.Forms.Button bAddLabel;
    private System.Windows.Forms.ColumnHeader chDBZ;
  }
}
