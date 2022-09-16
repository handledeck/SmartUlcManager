namespace Ztp.Ui
{
  partial class PlanResetControl
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
      this.cbActivePlanReboot = new System.Windows.Forms.CheckBox();
      this.label1 = new System.Windows.Forms.Label();
      this.dtpRebootTime = new System.Windows.Forms.DateTimePicker();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.dtpRebootTime);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.cbActivePlanReboot);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(350, 73);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Плановый перезапуск";
      // 
      // cbActivePlanReboot
      // 
      this.cbActivePlanReboot.AutoSize = true;
      this.cbActivePlanReboot.Location = new System.Drawing.Point(15, 19);
      this.cbActivePlanReboot.Name = "cbActivePlanReboot";
      this.cbActivePlanReboot.Size = new System.Drawing.Size(209, 17);
      this.cbActivePlanReboot.TabIndex = 0;
      this.cbActivePlanReboot.Text = "Активность планового перезапуска";
      this.cbActivePlanReboot.UseVisualStyleBackColor = true;
      this.cbActivePlanReboot.CheckedChanged += new System.EventHandler(this.cbActivePlanReboot_CheckedChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 46);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(108, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Время перезапуска";
      // 
      // dtpRebootTime
      // 
      this.dtpRebootTime.CustomFormat = "HH:mm";
      this.dtpRebootTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpRebootTime.Location = new System.Drawing.Point(159, 43);
      this.dtpRebootTime.Name = "dtpRebootTime";
      this.dtpRebootTime.ShowUpDown = true;
      this.dtpRebootTime.Size = new System.Drawing.Size(171, 20);
      this.dtpRebootTime.TabIndex = 2;
      this.dtpRebootTime.Value = new System.DateTime(2020, 5, 14, 14, 45, 0, 0);
      this.dtpRebootTime.ValueChanged += new System.EventHandler(this.dtpRebootTime_ValueChanged);
      // 
      // PlanResetControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox1);
      this.Name = "PlanResetControl";
      this.Size = new System.Drawing.Size(350, 73);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox cbActivePlanReboot;
    private System.Windows.Forms.DateTimePicker dtpRebootTime;
  }
}
