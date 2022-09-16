namespace Ztp.Ui
{
  partial class DinEditorControl
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
      this.cblDin = new System.Windows.Forms.CheckedListBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.cblDin);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(349, 58);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Дискретные входы";
      // 
      // cblDin
      // 
      this.cblDin.ColumnWidth = 40;
      this.cblDin.Dock = System.Windows.Forms.DockStyle.Top;
      this.cblDin.FormattingEnabled = true;
      this.cblDin.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
      this.cblDin.Location = new System.Drawing.Point(3, 16);
      this.cblDin.MinimumSize = new System.Drawing.Size(330, 34);
      this.cblDin.MultiColumn = true;
      this.cblDin.Name = "cblDin";
      this.cblDin.Size = new System.Drawing.Size(343, 34);
      this.cblDin.TabIndex = 16;
      // 
      // DinEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox1);
      this.MinimumSize = new System.Drawing.Size(336, 58);
      this.Name = "DinEditorControl";
      this.Size = new System.Drawing.Size(349, 58);
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckedListBox cblDin;
  }
}
