namespace Ztp.Ui
{
  partial class AinEditorControl
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
      this.cblAin = new System.Windows.Forms.CheckedListBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.cblAin);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(734, 37);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Аналоговые входы";
      // 
      // cblAin
      // 
      this.cblAin.ColumnWidth = 40;
      this.cblAin.Dock = System.Windows.Forms.DockStyle.Top;
      this.cblAin.FormattingEnabled = true;
      this.cblAin.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
      this.cblAin.Location = new System.Drawing.Point(3, 16);
      this.cblAin.MultiColumn = true;
      this.cblAin.Name = "cblAin";
      this.cblAin.Size = new System.Drawing.Size(728, 19);
      this.cblAin.TabIndex = 16;
      // 
      // AinEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox1);
      this.Name = "AinEditorControl";
      this.Size = new System.Drawing.Size(734, 37);
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckedListBox cblAin;
  }
}
