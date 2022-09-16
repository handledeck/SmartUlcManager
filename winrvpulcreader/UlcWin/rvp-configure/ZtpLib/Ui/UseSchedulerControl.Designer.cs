namespace Ztp.Ui
{
  partial class UseSchedulerControl
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
      this.cb = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // cb
      // 
      this.cb.AutoSize = true;
      this.cb.Dock = System.Windows.Forms.DockStyle.Top;
      this.cb.Location = new System.Drawing.Point(0, 0);
      this.cb.Name = "cb";
      this.cb.Size = new System.Drawing.Size(397, 17);
      this.cb.TabIndex = 0;
      this.cb.Text = "Активность планов освещения";
      this.cb.UseVisualStyleBackColor = true;
      // 
      // UseSchedulerControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.cb);
      this.Name = "UseSchedulerControl";
      this.Size = new System.Drawing.Size(397, 18);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox cb;
  }
}
