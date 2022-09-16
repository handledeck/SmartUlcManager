namespace Ztp.Ui
{
  partial class LogsStateControl
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
      this.groupBox = new System.Windows.Forms.GroupBox();
      this.label = new System.Windows.Forms.Label();
      this.cbLogLevel = new System.Windows.Forms.ComboBox();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.lab_logs = new System.Windows.Forms.Label();
      this.groupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox
      // 
      this.groupBox.Controls.Add(this.lab_logs);
      this.groupBox.Controls.Add(this.label);
      this.groupBox.Controls.Add(this.cbLogLevel);
      this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox.Location = new System.Drawing.Point(0, 0);
      this.groupBox.Name = "groupBox";
      this.groupBox.Size = new System.Drawing.Size(350, 67);
      this.groupBox.TabIndex = 0;
      this.groupBox.TabStop = false;
      this.groupBox.Text = "Логирование";
      // 
      // label
      // 
      this.label.Location = new System.Drawing.Point(6, 31);
      this.label.Name = "label";
      this.label.Size = new System.Drawing.Size(162, 29);
      this.label.TabIndex = 1;
      this.label.Text = "Минимальный уровень события для записи:";
      // 
      // cbLogLevel
      // 
      this.cbLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbLogLevel.FormattingEnabled = true;
      this.cbLogLevel.Items.AddRange(new object[] {
            "DEBUG",
            "INFO",
            "WARNING",
            "ERROR",
            "FATAL",
            "Логирование отключено"});
      this.cbLogLevel.Location = new System.Drawing.Point(172, 34);
      this.cbLogLevel.Name = "cbLogLevel";
      this.cbLogLevel.Size = new System.Drawing.Size(169, 21);
      this.cbLogLevel.TabIndex = 0;
      this.cbLogLevel.SelectedIndexChanged += new System.EventHandler(this.cbLogLevel_SelectedIndexChanged);
      // 
      // lab_logs
      // 
      this.lab_logs.AutoSize = true;
      this.lab_logs.Location = new System.Drawing.Point(172, 15);
      this.lab_logs.Name = "lab_logs";
      this.lab_logs.Size = new System.Drawing.Size(35, 13);
      this.lab_logs.TabIndex = 2;
      this.lab_logs.Text = "label1";
      // 
      // LogsStateControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox);
      this.Name = "LogsStateControl";
      this.Size = new System.Drawing.Size(350, 67);
      this.groupBox.ResumeLayout(false);
      this.groupBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox;
    private System.Windows.Forms.Label label;
    private System.Windows.Forms.ComboBox cbLogLevel;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.Label lab_logs;
  }
}
