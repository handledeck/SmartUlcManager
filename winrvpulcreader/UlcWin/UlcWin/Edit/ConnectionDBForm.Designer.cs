namespace UlcWin
{
  partial class ConnectionDBForm
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
      this.btnOk = new System.Windows.Forms.Button();
      this.btnTest = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txtIpOrName = new System.Windows.Forms.TextBox();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.txtUser = new System.Windows.Forms.TextBox();
      this.lblUser = new System.Windows.Forms.Label();
      this.btnSave = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(282, 182);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(87, 23);
      this.btnOk.TabIndex = 6;
      this.btnOk.Text = "Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnTest
      // 
      this.btnTest.Location = new System.Drawing.Point(10, 182);
      this.btnTest.Name = "btnTest";
      this.btnTest.Size = new System.Drawing.Size(87, 23);
      this.btnTest.TabIndex = 4;
      this.btnTest.Text = "Тест";
      this.btnTest.UseVisualStyleBackColor = true;
      this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(17, 19);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(351, 17);
      this.label1.TabIndex = 2;
      this.label1.Text = "Имя или Ip адрес соединения с  базой данных";
      // 
      // txtIpOrName
      // 
      this.txtIpOrName.Location = new System.Drawing.Point(19, 34);
      this.txtIpOrName.Name = "txtIpOrName";
      this.txtIpOrName.Size = new System.Drawing.Size(290, 24);
      this.txtIpOrName.TabIndex = 1;
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(19, 134);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new System.Drawing.Size(144, 24);
      this.txtPassword.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(17, 118);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(61, 17);
      this.label2.TabIndex = 4;
      this.label2.Text = "Пароль";
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // txtUser
      // 
      this.txtUser.Location = new System.Drawing.Point(19, 82);
      this.txtUser.Name = "txtUser";
      this.txtUser.Size = new System.Drawing.Size(208, 24);
      this.txtUser.TabIndex = 2;
      // 
      // lblUser
      // 
      this.lblUser.AutoSize = true;
      this.lblUser.Location = new System.Drawing.Point(17, 66);
      this.lblUser.Name = "lblUser";
      this.lblUser.Size = new System.Drawing.Size(108, 17);
      this.lblUser.TabIndex = 6;
      this.lblUser.Text = "Пользователь";
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(102, 182);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(87, 23);
      this.btnSave.TabIndex = 5;
      this.btnSave.Text = "Сохранить";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // ConnectionDBForm
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(379, 211);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.txtUser);
      this.Controls.Add(this.lblUser);
      this.Controls.Add(this.txtPassword);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtIpOrName);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnTest);
      this.Controls.Add(this.btnOk);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ConnectionDBForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Соединение с базой данных";
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtIpOrName;
        public System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.Button btnSave;
    public System.Windows.Forms.TextBox txtUser;
    private System.Windows.Forms.Label lblUser;
  }
}