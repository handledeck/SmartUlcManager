namespace Ztp.Ui
{
  partial class PingEditorControl
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cbActivePing = new System.Windows.Forms.CheckBox();
      this.bPingTest = new System.Windows.Forms.Button();
      this.idcPeriod = new Ztp.Ui.InputDoubleControl();
      this.itcIP = new Ztp.Ui.InputTextControl();
      this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.cbActivePing);
      this.groupBox1.Controls.Add(this.bPingTest);
      this.groupBox1.Controls.Add(this.idcPeriod);
      this.groupBox1.Controls.Add(this.itcIP);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(353, 100);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "IP адрес для пингования";
      // 
      // cbActivePing
      // 
      this.cbActivePing.AutoSize = true;
      this.cbActivePing.Location = new System.Drawing.Point(7, 20);
      this.cbActivePing.Name = "cbActivePing";
      this.cbActivePing.Size = new System.Drawing.Size(238, 17);
      this.cbActivePing.TabIndex = 3;
      this.cbActivePing.Text = "Активировать контроль связи через пинг";
      this.cbActivePing.UseVisualStyleBackColor = true;
      this.cbActivePing.CheckedChanged += new System.EventHandler(this.cbActivePing_CheckedChanged);
      // 
      // bPingTest
      // 
      this.bPingTest.Location = new System.Drawing.Point(90, 39);
      this.bPingTest.Name = "bPingTest";
      this.bPingTest.Size = new System.Drawing.Size(64, 23);
      this.bPingTest.TabIndex = 2;
      this.bPingTest.Text = "Ping Тест";
      this.bPingTest.UseVisualStyleBackColor = true;
      this.bPingTest.Click += new System.EventHandler(this.bPingTest_Click);
      // 
      // idcPeriod
      // 
      this.idcPeriod.Caption = "период пингования, мин:";
      this.idcPeriod.CaptionWidth = 150;
      this.idcPeriod.DecimalPlaces = 0;
      this.idcPeriod.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idcPeriod.Location = new System.Drawing.Point(7, 62);
      this.idcPeriod.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
      this.idcPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idcPeriod.Name = "idcPeriod";
      this.idcPeriod.ReadOnly = false;
      this.idcPeriod.Size = new System.Drawing.Size(340, 26);
      this.idcPeriod.TabIndex = 1;
      this.idcPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idcPeriod.ValueChanged += new System.EventHandler(this.idcPeriod_ValueChanged);
      // 
      // itcIP
      // 
      this.itcIP.Caption = "IP:";
      this.itcIP.CaptionWidth = 125;
      this.itcIP.Location = new System.Drawing.Point(32, 37);
      this.itcIP.Name = "itcIP";
      this.itcIP.PasswordChar = '\0';
      this.itcIP.ReadOnly = false;
      this.itcIP.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.itcIP.Size = new System.Drawing.Size(315, 26);
      this.itcIP.TabIndex = 0;
      this.itcIP.Value = "";
      this.itcIP.MouseLeave += new System.EventHandler(this.itcIP_Validated);
      this.itcIP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.itcIP_Validated);
      this.itcIP.Validated += new System.EventHandler(this.itcIP_Validated);
      // 
      // errorProvider
      // 
      this.errorProvider.ContainerControl = this;
      this.errorProvider.RightToLeft = true;
      // 
      // PingEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox1);
      this.Name = "PingEditorControl";
      this.Size = new System.Drawing.Size(353, 100);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private InputTextControl itcIP;
    private System.Windows.Forms.ErrorProvider errorProvider;
    private InputDoubleControl idcPeriod;
    private System.Windows.Forms.Button bPingTest;
    private System.Windows.Forms.CheckBox cbActivePing;
  }
}
