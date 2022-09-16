namespace Ztp.Ui
{
  partial class TcpPortSettingsEditorControl
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
      this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.label1 = new System.Windows.Forms.Label();
      this.tbTimeout = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.tbAddress = new System.Windows.Forms.TextBox();
      this.tbPort = new System.Windows.Forms.NumericUpDown();
      this.tableLayoutPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tbTimeout)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.tbPort)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel
      // 
      this.tableLayoutPanel.ColumnCount = 2;
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel.Controls.Add(this.label1, 0, 2);
      this.tableLayoutPanel.Controls.Add(this.tbTimeout, 0, 2);
      this.tableLayoutPanel.Controls.Add(this.label2, 0, 1);
      this.tableLayoutPanel.Controls.Add(this.label7, 0, 0);
      this.tableLayoutPanel.Controls.Add(this.tbAddress, 1, 0);
      this.tableLayoutPanel.Controls.Add(this.tbPort, 1, 1);
      this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel.Name = "tableLayoutPanel";
      this.tableLayoutPanel.RowCount = 3;
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
      this.tableLayoutPanel.Size = new System.Drawing.Size(338, 82);
      this.tableLayoutPanel.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Location = new System.Drawing.Point(3, 52);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(163, 30);
      this.label1.TabIndex = 24;
      this.label1.Text = "Таймаут (мсек)";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tbTimeout
      // 
      this.tbTimeout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbTimeout.Location = new System.Drawing.Point(172, 55);
      this.tbTimeout.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
      this.tbTimeout.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.tbTimeout.Name = "tbTimeout";
      this.tbTimeout.Size = new System.Drawing.Size(163, 20);
      this.tbTimeout.TabIndex = 23;
      this.tbTimeout.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
      // 
      // label2
      // 
      this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label2.Location = new System.Drawing.Point(3, 26);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(163, 26);
      this.label2.TabIndex = 19;
      this.label2.Text = "Порт";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label7
      // 
      this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label7.Location = new System.Drawing.Point(3, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(163, 26);
      this.label7.TabIndex = 17;
      this.label7.Text = "IP-адрес";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tbAddress
      // 
      this.tbAddress.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbAddress.Location = new System.Drawing.Point(172, 3);
      this.tbAddress.Name = "tbAddress";
      this.tbAddress.Size = new System.Drawing.Size(163, 20);
      this.tbAddress.TabIndex = 20;
      // 
      // tbPort
      // 
      this.tbPort.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbPort.Location = new System.Drawing.Point(172, 29);
      this.tbPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
      this.tbPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
      this.tbPort.Name = "tbPort";
      this.tbPort.Size = new System.Drawing.Size(163, 20);
      this.tbPort.TabIndex = 21;
      this.tbPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
      // 
      // TcpPortSettingsEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel);
      this.Name = "TcpPortSettingsEditorControl";
      this.Size = new System.Drawing.Size(338, 82);
      this.tableLayoutPanel.ResumeLayout(false);
      this.tableLayoutPanel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tbTimeout)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.tbPort)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox tbAddress;
    private System.Windows.Forms.NumericUpDown tbPort;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown tbTimeout;
  }
}
