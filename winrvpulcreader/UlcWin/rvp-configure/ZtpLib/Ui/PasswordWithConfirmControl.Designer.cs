namespace Ztp.Ui
{
  partial class PasswordWithConfirmControl
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
      this.components = new System.ComponentModel.Container();
      this.itPsw = new Ztp.Ui.InputTextControl();
      this.itPswConfirm = new Ztp.Ui.InputTextControl();
      this.cbShowPsw = new System.Windows.Forms.CheckBox();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // itPsw
      // 
      this.itPsw.Caption = "Пароль";
      this.itPsw.CaptionWidth = 100;
      this.itPsw.Dock = System.Windows.Forms.DockStyle.Top;
      this.itPsw.Location = new System.Drawing.Point(0, 0);
      this.itPsw.Name = "itPsw";
      this.itPsw.PasswordChar = '*';
      this.itPsw.ReadOnly = false;
      this.itPsw.Size = new System.Drawing.Size(336, 26);
      this.itPsw.TabIndex = 0;
      this.itPsw.Value = "";
      // 
      // itPswConfirm
      // 
      this.itPswConfirm.Caption = "Подтверждение";
      this.itPswConfirm.CaptionWidth = 100;
      this.itPswConfirm.Dock = System.Windows.Forms.DockStyle.Top;
      this.itPswConfirm.Location = new System.Drawing.Point(0, 26);
      this.itPswConfirm.Name = "itPswConfirm";
      this.itPswConfirm.PasswordChar = '*';
      this.itPswConfirm.ReadOnly = false;
      this.itPswConfirm.Size = new System.Drawing.Size(336, 26);
      this.itPswConfirm.TabIndex = 1;
      this.itPswConfirm.Value = "";
      // 
      // cbShowPsw
      // 
      this.cbShowPsw.AutoSize = true;
      this.cbShowPsw.Location = new System.Drawing.Point(103, 58);
      this.cbShowPsw.Name = "cbShowPsw";
      this.cbShowPsw.Size = new System.Drawing.Size(114, 17);
      this.cbShowPsw.TabIndex = 2;
      this.cbShowPsw.Text = "Показать пароль";
      this.cbShowPsw.UseVisualStyleBackColor = true;
      this.cbShowPsw.CheckedChanged += new System.EventHandler(this.cbShowPsw_CheckedChanged);
      // 
      // timer
      // 
      this.timer.Interval = 2000;
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // PasswordWithConfirmControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.cbShowPsw);
      this.Controls.Add(this.itPswConfirm);
      this.Controls.Add(this.itPsw);
      this.Name = "PasswordWithConfirmControl";
      this.Size = new System.Drawing.Size(336, 79);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private InputTextControl itPsw;
    private InputTextControl itPswConfirm;
    private System.Windows.Forms.CheckBox cbShowPsw;
    private System.Windows.Forms.Timer timer;
  }
}
