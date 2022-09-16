namespace Ztp.Ui
{
  partial class SelectPortKindWithSettingsControl
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
      Ztp.Port.ComPort.ComPortSettings comPortSettings1 = new Ztp.Port.ComPort.ComPortSettings();
      Ztp.Port.TcpPort.TcpPortSettings tcpPortSettings1 = new Ztp.Port.TcpPort.TcpPortSettings();
      this.tabControl = new System.Windows.Forms.TabControl();
      this.tpCom = new System.Windows.Forms.TabPage();
      this.comPortSettingsEditorControl = new Ztp.Ui.ComPortSettingsEditorControl();
      this.tpTcp = new System.Windows.Forms.TabPage();
      this.tcpPortSettingsEditorControl = new Ztp.Ui.TcpPortSettingsEditorControl();
      this.selectPortKindControl = new Ztp.Ui.SelectPortKindControl();
      this.tabControl.SuspendLayout();
      this.tpCom.SuspendLayout();
      this.tpTcp.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.tpCom);
      this.tabControl.Controls.Add(this.tpTcp);
      this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
      this.tabControl.Location = new System.Drawing.Point(0, 26);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(411, 214);
      this.tabControl.TabIndex = 3;
      // 
      // tpCom
      // 
      this.tpCom.Controls.Add(this.comPortSettingsEditorControl);
      this.tpCom.Location = new System.Drawing.Point(4, 22);
      this.tpCom.Name = "tpCom";
      this.tpCom.Padding = new System.Windows.Forms.Padding(3);
      this.tpCom.Size = new System.Drawing.Size(403, 188);
      this.tpCom.TabIndex = 0;
      this.tpCom.Text = "COM";
      this.tpCom.UseVisualStyleBackColor = true;
      // 
      // comPortSettingsEditorControl
      // 
      this.comPortSettingsEditorControl.Dock = System.Windows.Forms.DockStyle.Top;
      this.comPortSettingsEditorControl.EnabledBaudrates = true;
      this.comPortSettingsEditorControl.EnabledDataBits = true;
      this.comPortSettingsEditorControl.EnabledHandshake = true;
      this.comPortSettingsEditorControl.EnabledParity = true;
      this.comPortSettingsEditorControl.EnabledPortName = true;
      this.comPortSettingsEditorControl.EnabledStopBits = true;
      this.comPortSettingsEditorControl.Location = new System.Drawing.Point(3, 3);
      this.comPortSettingsEditorControl.Name = "comPortSettingsEditorControl";
      this.comPortSettingsEditorControl.ShowHandshake = true;
      this.comPortSettingsEditorControl.ShowPortName = true;
      this.comPortSettingsEditorControl.ShowTimeout = true;
      this.comPortSettingsEditorControl.Size = new System.Drawing.Size(397, 183);
      this.comPortSettingsEditorControl.TabIndex = 1;
      comPortSettings1.BaudRate = 9600;
      comPortSettings1.DataBits = ((byte)(8));
      comPortSettings1.Handshake = Ztp.Port.ComPort.Handshake.None;
      comPortSettings1.Kind = Ztp.Port.PortKind.Com;
      comPortSettings1.Parity = Ztp.Port.ComPort.Parity.None;
      comPortSettings1.PortName = "COM1";
      comPortSettings1.StopBits = Ztp.Port.ComPort.StopBits.One;
      comPortSettings1.Timeout = 1000;
      this.comPortSettingsEditorControl.Value = comPortSettings1;
      // 
      // tpTcp
      // 
      this.tpTcp.Controls.Add(this.tcpPortSettingsEditorControl);
      this.tpTcp.Location = new System.Drawing.Point(4, 22);
      this.tpTcp.Name = "tpTcp";
      this.tpTcp.Padding = new System.Windows.Forms.Padding(3);
      this.tpTcp.Size = new System.Drawing.Size(403, 163);
      this.tpTcp.TabIndex = 1;
      this.tpTcp.Text = "TCP";
      this.tpTcp.UseVisualStyleBackColor = true;
      // 
      // tcpPortSettingsEditorControl
      // 
      this.tcpPortSettingsEditorControl.Dock = System.Windows.Forms.DockStyle.Top;
      this.tcpPortSettingsEditorControl.Location = new System.Drawing.Point(3, 3);
      this.tcpPortSettingsEditorControl.Name = "tcpPortSettingsEditorControl";
      this.tcpPortSettingsEditorControl.Size = new System.Drawing.Size(397, 78);
      this.tcpPortSettingsEditorControl.TabIndex = 2;
      tcpPortSettings1.IpAddress = "";
      tcpPortSettings1.Kind = Ztp.Port.PortKind.Tcp;
      tcpPortSettings1.Port = ((uint)(1024u));
      tcpPortSettings1.Timeout = 10000;
      this.tcpPortSettingsEditorControl.Value = tcpPortSettings1;
      // 
      // selectPortKindControl
      // 
      this.selectPortKindControl.Caption = "Порт";
      this.selectPortKindControl.Dock = System.Windows.Forms.DockStyle.Top;
      this.selectPortKindControl.Location = new System.Drawing.Point(0, 0);
      this.selectPortKindControl.Name = "selectPortKindControl";
      this.selectPortKindControl.Size = new System.Drawing.Size(411, 26);
      this.selectPortKindControl.TabIndex = 0;
      this.selectPortKindControl.Value = Ztp.Port.PortKind.Com;
      this.selectPortKindControl.PortKingChanged += new System.EventHandler(this.selectPortKindControl_PortKingChanged);
      // 
      // SelectPortKindWithSettingsControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tabControl);
      this.Controls.Add(this.selectPortKindControl);
      this.Name = "SelectPortKindWithSettingsControl";
      this.Size = new System.Drawing.Size(411, 241);
      this.tabControl.ResumeLayout(false);
      this.tpCom.ResumeLayout(false);
      this.tpTcp.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private SelectPortKindControl selectPortKindControl;
    private TcpPortSettingsEditorControl tcpPortSettingsEditorControl;
    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tpCom;
    private System.Windows.Forms.TabPage tpTcp;
    public ComPortSettingsEditorControl comPortSettingsEditorControl;
  }
}
