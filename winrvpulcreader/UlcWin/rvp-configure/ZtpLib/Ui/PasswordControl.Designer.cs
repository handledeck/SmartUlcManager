namespace Ztp.Ui
{
  partial class PasswordControl
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
      this.cbShowPsw = new System.Windows.Forms.CheckBox();
      this.itPsw = new Ztp.Ui.InputTextControl();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // cbShowPsw
      // 
      this.cbShowPsw.AutoSize = true;
      this.cbShowPsw.Location = new System.Drawing.Point(103, 32);
      this.cbShowPsw.Name = "cbShowPsw";
      this.cbShowPsw.Size = new System.Drawing.Size(114, 17);
      this.cbShowPsw.TabIndex = 4;
      this.cbShowPsw.Text = "Показать пароль";
      this.cbShowPsw.UseVisualStyleBackColor = true;
      this.cbShowPsw.CheckedChanged += new System.EventHandler(this.cbShowPsw_CheckedChanged);
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
      this.itPsw.Size = new System.Drawing.Size(355, 26);
      this.itPsw.TabIndex = 3;
      this.itPsw.Value = "";
      // 
      // timer
      // 
      this.timer.Interval = 2000;
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // PasswordControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.cbShowPsw);
      this.Controls.Add(this.itPsw);
      this.Name = "PasswordControl";
      this.Size = new System.Drawing.Size(355, 50);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox cbShowPsw;
    private Ui.InputTextControl itPsw;
    private System.Windows.Forms.Timer timer;
  }
}
