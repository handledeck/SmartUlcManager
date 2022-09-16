namespace UlcWin.ui
{
  partial class UsersAccsessForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersAccsessForm));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.cbLevel = new System.Windows.Forms.ComboBox();
      this.btnAllSelect = new System.Windows.Forms.Button();
      this.btnUnSelect = new System.Windows.Forms.Button();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.txtBoxPwd = new UlcWin.ui.TextBoxPlaceHolder();
      this.txtBoxComment = new UlcWin.ui.TextBoxPlaceHolder();
      this.txtBoxName = new UlcWin.ui.TextBoxPlaceHolder();
      this.triStateTreeView1 = new UlcWin.ui.TriStateTreeView();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.triStateTreeView1);
      this.groupBox1.Location = new System.Drawing.Point(12, 130);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 10, 3, 5);
      this.groupBox1.Size = new System.Drawing.Size(580, 429);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Объекты доступа";
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(483, 576);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(87, 23);
      this.btnCancel.TabIndex = 7;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(380, 576);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(87, 23);
      this.btnOk.TabIndex = 6;
      this.btnOk.Text = "Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(141, 17);
      this.label1.TabIndex = 7;
      this.label1.Text = "Имя пользователя";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(349, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(61, 17);
      this.label2.TabIndex = 9;
      this.label2.Text = "Пароль";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(349, 49);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(131, 17);
      this.label3.TabIndex = 11;
      this.label3.Text = "Уровень доступа";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 49);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(106, 17);
      this.label4.TabIndex = 13;
      this.label4.Text = "Комментарий";
      // 
      // cbLevel
      // 
      this.cbLevel.FormattingEnabled = true;
      this.cbLevel.Items.AddRange(new object[] {
            "Чтение и запись данных",
            "Чтение данных"});
      this.cbLevel.Location = new System.Drawing.Point(352, 65);
      this.cbLevel.Name = "cbLevel";
      this.cbLevel.Size = new System.Drawing.Size(198, 25);
      this.cbLevel.TabIndex = 5;
      // 
      // btnAllSelect
      // 
      this.btnAllSelect.Location = new System.Drawing.Point(557, 104);
      this.btnAllSelect.Name = "btnAllSelect";
      this.btnAllSelect.Size = new System.Drawing.Size(32, 30);
      this.btnAllSelect.TabIndex = 14;
      this.btnAllSelect.UseVisualStyleBackColor = true;
      this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
      // 
      // btnUnSelect
      // 
      this.btnUnSelect.Location = new System.Drawing.Point(519, 104);
      this.btnUnSelect.Name = "btnUnSelect";
      this.btnUnSelect.Size = new System.Drawing.Size(32, 30);
      this.btnUnSelect.TabIndex = 15;
      this.btnUnSelect.UseVisualStyleBackColor = true;
      this.btnUnSelect.Click += new System.EventHandler(this.btnUnSelect_Click);
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
      // 
      // txtBoxPwd
      // 
      this.txtBoxPwd.CueText = "макс. 20 симв";
      this.txtBoxPwd.IsValid = false;
      this.txtBoxPwd.Location = new System.Drawing.Point(352, 26);
      this.txtBoxPwd.MaxLength = 20;
      this.txtBoxPwd.Name = "txtBoxPwd";
      this.txtBoxPwd.PasswordChar = '*';
      this.txtBoxPwd.Size = new System.Drawing.Size(199, 24);
      this.txtBoxPwd.TabIndex = 18;
      // 
      // txtBoxComment
      // 
      this.txtBoxComment.CueText = "макс. 50 симв.";
      this.txtBoxComment.IsValid = false;
      this.txtBoxComment.Location = new System.Drawing.Point(15, 65);
      this.txtBoxComment.MaxLength = 50;
      this.txtBoxComment.Name = "txtBoxComment";
      this.txtBoxComment.Size = new System.Drawing.Size(297, 24);
      this.txtBoxComment.TabIndex = 17;
      // 
      // txtBoxName
      // 
      this.txtBoxName.CueText = "макс. 30 симв.";
      this.txtBoxName.IsValid = false;
      this.txtBoxName.Location = new System.Drawing.Point(15, 25);
      this.txtBoxName.Name = "txtBoxName";
      this.txtBoxName.Size = new System.Drawing.Size(222, 24);
      this.txtBoxName.TabIndex = 1;
      // 
      // triStateTreeView1
      // 
      this.triStateTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.triStateTreeView1.Location = new System.Drawing.Point(3, 27);
      this.triStateTreeView1.Name = "triStateTreeView1";
      this.triStateTreeView1.Size = new System.Drawing.Size(574, 397);
      this.triStateTreeView1.TabIndex = 0;
      this.triStateTreeView1.TriStateStyleProperty = UlcWin.ui.TriStateTreeView.TriStateStyles.Standard;
      this.triStateTreeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.triStateTreeView1_AfterCheck);
      this.triStateTreeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.triStateTreeView1_AfterExpand);
      this.triStateTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.triStateTreeView1_AfterSelect);
      // 
      // UsersAccsessForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(604, 611);
      this.ControlBox = false;
      this.Controls.Add(this.txtBoxPwd);
      this.Controls.Add(this.txtBoxComment);
      this.Controls.Add(this.txtBoxName);
      this.Controls.Add(this.btnUnSelect);
      this.Controls.Add(this.btnAllSelect);
      this.Controls.Add(this.cbLevel);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.groupBox1);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "UsersAccsessForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Новый пользователь";
      this.groupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        public TriStateTreeView triStateTreeView1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnAllSelect;
    private System.Windows.Forms.Button btnUnSelect;
    public System.Windows.Forms.ComboBox cbLevel;
        public TextBoxPlaceHolder txtBoxName;
        public TextBoxPlaceHolder txtBoxPwd;
        public TextBoxPlaceHolder txtBoxComment;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}