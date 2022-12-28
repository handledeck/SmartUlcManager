namespace UlcWin.Edit
{
  partial class Editor
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
      this.btnOk = new System.Windows.Forms.Button();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.cbType = new System.Windows.Forms.ComboBox();
      this.chBoxActive = new System.Windows.Forms.CheckBox();
      this.label3 = new System.Windows.Forms.Label();
      this.cbFunction = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.GrpMeter = new System.Windows.Forms.GroupBox();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.BtnDelete = new System.Windows.Forms.Button();
      this.BtnEdit = new System.Windows.Forms.Button();
      this.BtnAdd = new System.Windows.Forms.Button();
      this.lstMeter = new System.Windows.Forms.ListView();
      this.MeterType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.MeterPlant = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Отмена = new System.Windows.Forms.Button();
      this.txtBoxComment = new UlcWin.ui.TextBoxPlaceHolder();
      this.txtBoxIpAddress = new UlcWin.ui.TextBoxPlaceHolder();
      this.txtBoxPhones = new UlcWin.ui.TextBoxPlaceHolder();
      this.txtBoxZtp = new UlcWin.ui.TextBoxPlaceHolder();
      this.txtBoxCity = new UlcWin.ui.TextBoxPlaceHolder();
      this.txtBoxState = new UlcWin.ui.TextBoxPlaceHolder();
      this.chBoxStat = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.GrpMeter.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.Location = new System.Drawing.Point(410, 471);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(91, 27);
      this.btnOk.TabIndex = 4;
      this.btnOk.Text = "Ок";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // errorProvider1
      // 
      this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
      this.errorProvider1.ContainerControl = this;
      this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "check.ico");
      this.imageList1.Images.SetKeyName(1, "delete.ico");
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(23, 102);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(58, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "IP адрес";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(240, 191);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(107, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Тип контроллера";
      // 
      // cbType
      // 
      this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbType.FormattingEnabled = true;
      this.cbType.Location = new System.Drawing.Point(243, 207);
      this.cbType.Name = "cbType";
      this.cbType.Size = new System.Drawing.Size(167, 21);
      this.cbType.TabIndex = 4;
      // 
      // chBoxActive
      // 
      this.chBoxActive.AutoSize = true;
      this.chBoxActive.Checked = true;
      this.chBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chBoxActive.Location = new System.Drawing.Point(331, 112);
      this.chBoxActive.Name = "chBoxActive";
      this.chBoxActive.Size = new System.Drawing.Size(171, 17);
      this.chBoxActive.TabIndex = 6;
      this.chBoxActive.Text = "Активность контроллера";
      this.chBoxActive.UseVisualStyleBackColor = true;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(22, 191);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(138, 13);
      this.label3.TabIndex = 9;
      this.label3.Text = "Функция контроллера";
      // 
      // cbFunction
      // 
      this.cbFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbFunction.FormattingEnabled = true;
      this.cbFunction.Location = new System.Drawing.Point(25, 207);
      this.cbFunction.Name = "cbFunction";
      this.cbFunction.Size = new System.Drawing.Size(167, 21);
      this.cbFunction.TabIndex = 5;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(23, 142);
      this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(76, 13);
      this.label5.TabIndex = 11;
      this.label5.Text = "Комметарий";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(22, 22);
      this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(106, 13);
      this.label6.TabIndex = 13;
      this.label6.Text = "Район установки";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(23, 62);
      this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(69, 13);
      this.label7.TabIndex = 15;
      this.label7.Text = "Нас. пункт";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(328, 22);
      this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(105, 13);
      this.label8.TabIndex = 17;
      this.label8.Text = "Пункт установки";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(330, 62);
      this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(103, 13);
      this.label9.TabIndex = 18;
      this.label9.Text = "Номер телефона";
      // 
      // GrpMeter
      // 
      this.GrpMeter.Controls.Add(this.tableLayoutPanel1);
      this.GrpMeter.Location = new System.Drawing.Point(23, 244);
      this.GrpMeter.Name = "GrpMeter";
      this.GrpMeter.Size = new System.Drawing.Size(580, 208);
      this.GrpMeter.TabIndex = 22;
      this.GrpMeter.TabStop = false;
      this.GrpMeter.Text = "Устройства";
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.13937F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.86063F));
      this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.lstMeter, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(574, 188);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.BtnDelete);
      this.panel1.Controls.Add(this.BtnEdit);
      this.panel1.Controls.Add(this.BtnAdd);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(463, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(108, 182);
      this.panel1.TabIndex = 0;
      // 
      // BtnDelete
      // 
      this.BtnDelete.Location = new System.Drawing.Point(9, 80);
      this.BtnDelete.Name = "BtnDelete";
      this.BtnDelete.Size = new System.Drawing.Size(80, 27);
      this.BtnDelete.TabIndex = 4;
      this.BtnDelete.Text = "Удалить";
      this.BtnDelete.UseVisualStyleBackColor = true;
      this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
      // 
      // BtnEdit
      // 
      this.BtnEdit.AutoEllipsis = true;
      this.BtnEdit.Location = new System.Drawing.Point(11, 47);
      this.BtnEdit.Name = "BtnEdit";
      this.BtnEdit.Size = new System.Drawing.Size(78, 27);
      this.BtnEdit.TabIndex = 3;
      this.BtnEdit.Text = "Редактировать";
      this.BtnEdit.UseVisualStyleBackColor = true;
      this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
      // 
      // BtnAdd
      // 
      this.BtnAdd.Location = new System.Drawing.Point(9, 14);
      this.BtnAdd.Name = "BtnAdd";
      this.BtnAdd.Size = new System.Drawing.Size(80, 27);
      this.BtnAdd.TabIndex = 2;
      this.BtnAdd.Text = "Добавить";
      this.BtnAdd.UseVisualStyleBackColor = true;
      this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
      // 
      // lstMeter
      // 
      this.lstMeter.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.lstMeter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MeterType,
            this.MeterPlant});
      this.lstMeter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstMeter.FullRowSelect = true;
      this.lstMeter.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.lstMeter.HideSelection = false;
      this.lstMeter.Location = new System.Drawing.Point(3, 3);
      this.lstMeter.MultiSelect = false;
      this.lstMeter.Name = "lstMeter";
      this.lstMeter.ShowGroups = false;
      this.lstMeter.Size = new System.Drawing.Size(454, 182);
      this.lstMeter.TabIndex = 1;
      this.lstMeter.UseCompatibleStateImageBehavior = false;
      this.lstMeter.View = System.Windows.Forms.View.Details;
      // 
      // MeterType
      // 
      this.MeterType.Text = "Тип устройства";
      this.MeterType.Width = 185;
      // 
      // MeterPlant
      // 
      this.MeterPlant.Text = "Серийный номер";
      this.MeterPlant.Width = 162;
      // 
      // Отмена
      // 
      this.Отмена.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.Отмена.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Отмена.Location = new System.Drawing.Point(509, 471);
      this.Отмена.Name = "Отмена";
      this.Отмена.Size = new System.Drawing.Size(91, 27);
      this.Отмена.TabIndex = 23;
      this.Отмена.Text = "Отмена";
      this.Отмена.UseVisualStyleBackColor = true;
      // 
      // txtBoxComment
      // 
      this.txtBoxComment.CueText = "Макс. 100 символов";
      this.txtBoxComment.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.txtBoxComment.IsValid = false;
      this.txtBoxComment.Location = new System.Drawing.Point(25, 158);
      this.txtBoxComment.MaxLength = 100;
      this.txtBoxComment.Name = "txtBoxComment";
      this.txtBoxComment.Size = new System.Drawing.Size(567, 21);
      this.txtBoxComment.TabIndex = 21;
      // 
      // txtBoxIpAddress
      // 
      this.txtBoxIpAddress.CueText = "IP адрес точки (127.0.0.1)";
      this.txtBoxIpAddress.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.txtBoxIpAddress.IsValid = false;
      this.txtBoxIpAddress.Location = new System.Drawing.Point(23, 118);
      this.txtBoxIpAddress.MaxLength = 15;
      this.txtBoxIpAddress.Name = "txtBoxIpAddress";
      this.txtBoxIpAddress.Size = new System.Drawing.Size(206, 21);
      this.txtBoxIpAddress.TabIndex = 20;
      // 
      // txtBoxPhones
      // 
      this.txtBoxPhones.CueText = "тел. (пример 375298555555)";
      this.txtBoxPhones.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.txtBoxPhones.IsValid = false;
      this.txtBoxPhones.Location = new System.Drawing.Point(330, 78);
      this.txtBoxPhones.MaxLength = 20;
      this.txtBoxPhones.Name = "txtBoxPhones";
      this.txtBoxPhones.Size = new System.Drawing.Size(262, 21);
      this.txtBoxPhones.TabIndex = 19;
      // 
      // txtBoxZtp
      // 
      this.txtBoxZtp.CueText = "Точка установки(пример КТП-127)";
      this.txtBoxZtp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.txtBoxZtp.IsValid = false;
      this.txtBoxZtp.Location = new System.Drawing.Point(330, 38);
      this.txtBoxZtp.MaxLength = 30;
      this.txtBoxZtp.Name = "txtBoxZtp";
      this.txtBoxZtp.Size = new System.Drawing.Size(262, 21);
      this.txtBoxZtp.TabIndex = 16;
      // 
      // txtBoxCity
      // 
      this.txtBoxCity.CueText = "Населенный пункт(пример Вороны)";
      this.txtBoxCity.Font = new System.Drawing.Font("Verdana", 8.25F);
      this.txtBoxCity.IsValid = false;
      this.txtBoxCity.Location = new System.Drawing.Point(23, 78);
      this.txtBoxCity.MaxLength = 30;
      this.txtBoxCity.Name = "txtBoxCity";
      this.txtBoxCity.Size = new System.Drawing.Size(246, 21);
      this.txtBoxCity.TabIndex = 14;
      // 
      // txtBoxState
      // 
      this.txtBoxState.CueText = "Район установки(пример Вороновский)";
      this.txtBoxState.Font = new System.Drawing.Font("Verdana", 8.25F);
      this.txtBoxState.IsValid = false;
      this.txtBoxState.Location = new System.Drawing.Point(23, 38);
      this.txtBoxState.MaxLength = 30;
      this.txtBoxState.Name = "txtBoxState";
      this.txtBoxState.Size = new System.Drawing.Size(246, 21);
      this.txtBoxState.TabIndex = 12;
      // 
      // chBoxStat
      // 
      this.chBoxStat.AutoSize = true;
      this.chBoxStat.Checked = true;
      this.chBoxStat.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chBoxStat.Location = new System.Drawing.Point(331, 135);
      this.chBoxStat.Name = "chBoxStat";
      this.chBoxStat.Size = new System.Drawing.Size(141, 17);
      this.chBoxStat.TabIndex = 24;
      this.chBoxStat.Text = "Статистстка RS-485";
      this.chBoxStat.UseVisualStyleBackColor = true;
      // 
      // Editor
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(613, 510);
      this.Controls.Add(this.chBoxStat);
      this.Controls.Add(this.Отмена);
      this.Controls.Add(this.GrpMeter);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.txtBoxComment);
      this.Controls.Add(this.txtBoxIpAddress);
      this.Controls.Add(this.txtBoxPhones);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.txtBoxZtp);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.txtBoxCity);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.txtBoxState);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.cbFunction);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.chBoxActive);
      this.Controls.Add(this.cbType);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Editor";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Новый объект";
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.GrpMeter.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.GroupBox GrpMeter;
    public ui.TextBoxPlaceHolder txtBoxComment;
    public ui.TextBoxPlaceHolder txtBoxIpAddress;
    public ui.TextBoxPlaceHolder txtBoxPhones;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    public ui.TextBoxPlaceHolder txtBoxZtp;
    private System.Windows.Forms.Label label7;
    public ui.TextBoxPlaceHolder txtBoxCity;
    private System.Windows.Forms.Label label6;
    public ui.TextBoxPlaceHolder txtBoxState;
    private System.Windows.Forms.Label label5;
    public System.Windows.Forms.ComboBox cbFunction;
    private System.Windows.Forms.Label label3;
    public System.Windows.Forms.CheckBox chBoxActive;
    public System.Windows.Forms.ComboBox cbType;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button Отмена;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button BtnAdd;
    private System.Windows.Forms.Button BtnDelete;
    private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.ColumnHeader MeterType;
        private System.Windows.Forms.ColumnHeader MeterPlant;
    public System.Windows.Forms.ListView lstMeter;
    public System.Windows.Forms.CheckBox chBoxStat;
  }
}