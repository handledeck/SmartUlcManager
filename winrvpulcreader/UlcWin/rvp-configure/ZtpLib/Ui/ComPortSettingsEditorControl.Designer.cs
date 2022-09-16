namespace Ztp.Ui
{
  partial class ComPortSettingsEditorControl
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.cbPortName = new System.Windows.Forms.ComboBox();
      this.cbBaudrates = new System.Windows.Forms.ComboBox();
      this.cbDataBits = new System.Windows.Forms.ComboBox();
      this.cbParity = new System.Windows.Forms.ComboBox();
      this.cbHandshake = new System.Windows.Forms.ComboBox();
      this.cbStopBits = new System.Windows.Forms.ComboBox();
      this.nudTimeout = new System.Windows.Forms.NumericUpDown();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.label1, 0, 6);
      this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
      this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
      this.tableLayoutPanel1.Controls.Add(this.cbPortName, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.cbBaudrates, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.cbDataBits, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.cbParity, 1, 3);
      this.tableLayoutPanel1.Controls.Add(this.cbHandshake, 1, 4);
      this.tableLayoutPanel1.Controls.Add(this.cbStopBits, 1, 5);
      this.tableLayoutPanel1.Controls.Add(this.nudTimeout, 1, 6);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 7;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(433, 181);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Location = new System.Drawing.Point(3, 156);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(210, 26);
      this.label1.TabIndex = 34;
      this.label1.Text = "Таймаут (мсек)";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label2
      // 
      this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label2.Location = new System.Drawing.Point(3, 26);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(210, 26);
      this.label2.TabIndex = 19;
      this.label2.Text = "Скорость";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label3
      // 
      this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label3.Location = new System.Drawing.Point(3, 52);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(210, 26);
      this.label3.TabIndex = 21;
      this.label3.Text = "Битность";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label7
      // 
      this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label7.Location = new System.Drawing.Point(3, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(210, 26);
      this.label7.TabIndex = 17;
      this.label7.Text = "Порт";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label4
      // 
      this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label4.Location = new System.Drawing.Point(3, 78);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(210, 26);
      this.label4.TabIndex = 23;
      this.label4.Text = "Четность";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label5
      // 
      this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label5.Location = new System.Drawing.Point(3, 104);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(210, 26);
      this.label5.TabIndex = 25;
      this.label5.Text = "Управление потоком";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label6
      // 
      this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label6.Location = new System.Drawing.Point(3, 130);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(210, 26);
      this.label6.TabIndex = 27;
      this.label6.Text = "Стоповых бит";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // cbPortName
      // 
      this.cbPortName.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbPortName.FormattingEnabled = true;
      this.cbPortName.Location = new System.Drawing.Point(219, 3);
      this.cbPortName.Name = "cbPortName";
      this.cbPortName.Size = new System.Drawing.Size(211, 21);
      this.cbPortName.TabIndex = 28;
      // 
      // cbBaudrates
      // 
      this.cbBaudrates.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbBaudrates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbBaudrates.FormattingEnabled = true;
      this.cbBaudrates.Location = new System.Drawing.Point(219, 29);
      this.cbBaudrates.Name = "cbBaudrates";
      this.cbBaudrates.Size = new System.Drawing.Size(211, 21);
      this.cbBaudrates.TabIndex = 29;
      // 
      // cbDataBits
      // 
      this.cbDataBits.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbDataBits.FormattingEnabled = true;
      this.cbDataBits.Location = new System.Drawing.Point(219, 55);
      this.cbDataBits.Name = "cbDataBits";
      this.cbDataBits.Size = new System.Drawing.Size(211, 21);
      this.cbDataBits.TabIndex = 30;
      // 
      // cbParity
      // 
      this.cbParity.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbParity.FormattingEnabled = true;
      this.cbParity.Location = new System.Drawing.Point(219, 81);
      this.cbParity.Name = "cbParity";
      this.cbParity.Size = new System.Drawing.Size(211, 21);
      this.cbParity.TabIndex = 31;
      // 
      // cbHandshake
      // 
      this.cbHandshake.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbHandshake.FormattingEnabled = true;
      this.cbHandshake.Location = new System.Drawing.Point(219, 107);
      this.cbHandshake.Name = "cbHandshake";
      this.cbHandshake.Size = new System.Drawing.Size(211, 21);
      this.cbHandshake.TabIndex = 32;
      // 
      // cbStopBits
      // 
      this.cbStopBits.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbStopBits.FormattingEnabled = true;
      this.cbStopBits.Location = new System.Drawing.Point(219, 133);
      this.cbStopBits.Name = "cbStopBits";
      this.cbStopBits.Size = new System.Drawing.Size(211, 21);
      this.cbStopBits.TabIndex = 33;
      // 
      // nudTimeout
      // 
      this.nudTimeout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.nudTimeout.Location = new System.Drawing.Point(219, 159);
      this.nudTimeout.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
      this.nudTimeout.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.nudTimeout.Name = "nudTimeout";
      this.nudTimeout.Size = new System.Drawing.Size(211, 20);
      this.nudTimeout.TabIndex = 35;
      this.nudTimeout.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
      // 
      // ComPortSettingsEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "ComPortSettingsEditorControl";
      this.Size = new System.Drawing.Size(433, 181);
      this.tableLayoutPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox cbPortName;
    private System.Windows.Forms.ComboBox cbBaudrates;
    private System.Windows.Forms.ComboBox cbDataBits;
    private System.Windows.Forms.ComboBox cbParity;
    private System.Windows.Forms.ComboBox cbHandshake;
    private System.Windows.Forms.ComboBox cbStopBits;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown nudTimeout;
  }
}
