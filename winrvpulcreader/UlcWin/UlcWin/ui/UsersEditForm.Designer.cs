namespace UlcWin.ui
{
  partial class UsersEditForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersEditForm));
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnDelete = new System.Windows.Forms.Button();
      this.btnEdit = new System.Windows.Forms.Button();
      this.btnAddUser = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.ListUser = new System.Windows.Forms.ListView();
      this.UserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Comment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnDelete);
      this.panel1.Controls.Add(this.btnEdit);
      this.panel1.Controls.Add(this.btnAddUser);
      this.panel1.Controls.Add(this.btnCancel);
      this.panel1.Controls.Add(this.groupBox2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Padding = new System.Windows.Forms.Padding(1);
      this.panel1.Size = new System.Drawing.Size(570, 412);
      this.panel1.TabIndex = 0;
      // 
      // btnDelete
      // 
      this.btnDelete.Location = new System.Drawing.Point(15, 372);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(77, 27);
      this.btnDelete.TabIndex = 7;
      this.btnDelete.Text = "Удалить";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // btnEdit
      // 
      this.btnEdit.Location = new System.Drawing.Point(181, 373);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new System.Drawing.Size(105, 27);
      this.btnEdit.TabIndex = 7;
      this.btnEdit.Text = "Редактировать";
      this.btnEdit.UseVisualStyleBackColor = true;
      this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
      // 
      // btnAddUser
      // 
      this.btnAddUser.Location = new System.Drawing.Point(98, 373);
      this.btnAddUser.Name = "btnAddUser";
      this.btnAddUser.Size = new System.Drawing.Size(77, 27);
      this.btnAddUser.TabIndex = 6;
      this.btnAddUser.Text = "Добавить";
      this.btnAddUser.UseVisualStyleBackColor = true;
      this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(480, 373);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(77, 27);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Выход";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.ListUser);
      this.groupBox2.Location = new System.Drawing.Point(12, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 10, 3, 5);
      this.groupBox2.Size = new System.Drawing.Size(548, 354);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Пользователи";
      // 
      // ListUser
      // 
      this.ListUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.ListUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserName,
            this.Comment});
      this.ListUser.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ListUser.FullRowSelect = true;
      this.ListUser.HideSelection = false;
      this.ListUser.Location = new System.Drawing.Point(3, 24);
      this.ListUser.MultiSelect = false;
      this.ListUser.Name = "ListUser";
      this.ListUser.ShowGroups = false;
      this.ListUser.Size = new System.Drawing.Size(542, 325);
      this.ListUser.TabIndex = 0;
      this.ListUser.UseCompatibleStateImageBehavior = false;
      this.ListUser.View = System.Windows.Forms.View.Details;
      // 
      // UserName
      // 
      this.UserName.Text = "Пользователь";
      this.UserName.Width = 184;
      // 
      // Comment
      // 
      this.Comment.Text = "Комментарий";
      this.Comment.Width = 354;
      // 
      // UsersEditForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(570, 412);
      this.ControlBox = false;
      this.Controls.Add(this.panel1);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "UsersEditForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Редактор пользователь";
      this.panel1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView ListUser;
    private System.Windows.Forms.ColumnHeader UserName;
    private System.Windows.Forms.ColumnHeader Comment;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnEdit;
    private System.Windows.Forms.Button btnAddUser;
    private System.Windows.Forms.Button btnCancel;
  }
}