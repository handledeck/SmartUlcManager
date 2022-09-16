namespace Ztp.Ui
{
  partial class ApnEditorControl
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
      this.groupBox = new System.Windows.Forms.GroupBox();
      this.itcApnAddress = new Ztp.Ui.InputTextControl();
      this.itcApnUser = new Ztp.Ui.InputTextControl();
      this.itcApnPassword = new Ztp.Ui.InputTextControl();
      this.groupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox
      // 
      this.groupBox.Controls.Add(this.itcApnPassword);
      this.groupBox.Controls.Add(this.itcApnUser);
      this.groupBox.Controls.Add(this.itcApnAddress);
      this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox.Location = new System.Drawing.Point(0, 0);
      this.groupBox.Name = "groupBox";
      this.groupBox.Size = new System.Drawing.Size(350, 98);
      this.groupBox.TabIndex = 0;
      this.groupBox.TabStop = false;
      this.groupBox.Text = "Доступ";
      // 
      // itcApnAddress
      // 
      this.itcApnAddress.Caption = "Адрес";
      this.itcApnAddress.CaptionWidth = 150;
      this.itcApnAddress.Dock = System.Windows.Forms.DockStyle.Top;
      this.itcApnAddress.Location = new System.Drawing.Point(3, 16);
      this.itcApnAddress.Name = "itcApnAddress";
      this.itcApnAddress.PasswordChar = '\0';
      this.itcApnAddress.ReadOnly = false;
      this.itcApnAddress.Size = new System.Drawing.Size(344, 26);
      this.itcApnAddress.TabIndex = 0;
      this.itcApnAddress.Value = "";
      // 
      // itcApnUser
      // 
      this.itcApnUser.Caption = "Имя пользователя";
      this.itcApnUser.CaptionWidth = 150;
      this.itcApnUser.Dock = System.Windows.Forms.DockStyle.Top;
      this.itcApnUser.Location = new System.Drawing.Point(3, 42);
      this.itcApnUser.Name = "itcApnUser";
      this.itcApnUser.PasswordChar = '\0';
      this.itcApnUser.ReadOnly = false;
      this.itcApnUser.Size = new System.Drawing.Size(344, 26);
      this.itcApnUser.TabIndex = 1;
      this.itcApnUser.Value = "";
      // 
      // itcApnPassword
      // 
      this.itcApnPassword.Caption = "Пароль";
      this.itcApnPassword.CaptionWidth = 150;
      this.itcApnPassword.Dock = System.Windows.Forms.DockStyle.Top;
      this.itcApnPassword.Location = new System.Drawing.Point(3, 68);
      this.itcApnPassword.Name = "itcApnPassword";
      this.itcApnPassword.PasswordChar = '*';
      this.itcApnPassword.ReadOnly = false;
      this.itcApnPassword.Size = new System.Drawing.Size(344, 26);
      this.itcApnPassword.TabIndex = 2;
      this.itcApnPassword.Value = "";
      // 
      // ApnEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox);
      this.Name = "ApnEditorControl";
      this.Size = new System.Drawing.Size(350, 98);
      this.groupBox.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox;
    private InputTextControl itcApnAddress;
    private InputTextControl itcApnPassword;
    private InputTextControl itcApnUser;
  }
}
