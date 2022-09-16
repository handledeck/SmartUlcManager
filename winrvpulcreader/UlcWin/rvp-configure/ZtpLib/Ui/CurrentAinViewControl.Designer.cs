namespace Ztp.Ui
{
  partial class CurrentAinViewControl
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
      this.lbValues = new System.Windows.Forms.ListBox();
      this.groupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox
      // 
      this.groupBox.Controls.Add(this.lbValues);
      this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox.Location = new System.Drawing.Point(0, 0);
      this.groupBox.Name = "groupBox";
      this.groupBox.Size = new System.Drawing.Size(411, 81);
      this.groupBox.TabIndex = 0;
      this.groupBox.TabStop = false;
      this.groupBox.Text = "Аналоговые входы";
      // 
      // lbValues
      // 
      this.lbValues.BackColor = System.Drawing.SystemColors.Control;
      this.lbValues.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbValues.Enabled = false;
      this.lbValues.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lbValues.FormattingEnabled = true;
      this.lbValues.ItemHeight = 14;
      this.lbValues.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
      this.lbValues.Location = new System.Drawing.Point(3, 16);
      this.lbValues.Name = "lbValues";
      this.lbValues.Size = new System.Drawing.Size(405, 62);
      this.lbValues.TabIndex = 0;
      // 
      // CurrentAinViewControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox);
      this.Name = "CurrentAinViewControl";
      this.Size = new System.Drawing.Size(411, 81);
      this.groupBox.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox;
    private System.Windows.Forms.ListBox lbValues;
  }
}
