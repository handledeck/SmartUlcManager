namespace ZtpManager
{
  partial class AppConfigForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;


    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.tabControl = new System.Windows.Forms.TabControl();
      this.tpGeneral = new System.Windows.Forms.TabPage();
      this.cbAutoOpenConfigRibbon = new System.Windows.Forms.CheckBox();
      this.tpTcp = new System.Windows.Forms.TabPage();
      this.idTcpTimeout = new Ztp.Ui.InputDoubleControl();
      this.label1 = new System.Windows.Forms.Label();
      this.idTcpPort = new Ztp.Ui.InputDoubleControl();
      this.tpEstTools = new System.Windows.Forms.TabPage();
      this.idEstPort = new Ztp.Ui.InputDoubleControl();
      this.itEstUser = new Ztp.Ui.InputTextControl();
      this.cbEstEnabled = new System.Windows.Forms.CheckBox();
      this.itEstIpAddress = new Ztp.Ui.InputTextControl();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.pswEst = new Ztp.Ui.PasswordControl();
      this.tabControl.SuspendLayout();
      this.tpGeneral.SuspendLayout();
      this.tpTcp.SuspendLayout();
      this.tpEstTools.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.tpGeneral);
      this.tabControl.Controls.Add(this.tpTcp);
      this.tabControl.Controls.Add(this.tpEstTools);
      this.tabControl.Location = new System.Drawing.Point(12, 12);
      this.tabControl.Multiline = true;
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(455, 206);
      this.tabControl.TabIndex = 0;
      // 
      // tpGeneral
      // 
      this.tpGeneral.Controls.Add(this.cbAutoOpenConfigRibbon);
      this.tpGeneral.Location = new System.Drawing.Point(4, 22);
      this.tpGeneral.Name = "tpGeneral";
      this.tpGeneral.Size = new System.Drawing.Size(447, 180);
      this.tpGeneral.TabIndex = 2;
      this.tpGeneral.Text = "Общие";
      this.tpGeneral.UseVisualStyleBackColor = true;
      // 
      // cbAutoOpenConfigRibbon
      // 
      this.cbAutoOpenConfigRibbon.Location = new System.Drawing.Point(9, 6);
      this.cbAutoOpenConfigRibbon.Name = "cbAutoOpenConfigRibbon";
      this.cbAutoOpenConfigRibbon.Size = new System.Drawing.Size(429, 35);
      this.cbAutoOpenConfigRibbon.TabIndex = 2;
      this.cbAutoOpenConfigRibbon.Text = "Автоматически открывать ленту \'КОНФИГУРАЦИЯ\' при открытии окна устройства";
      this.cbAutoOpenConfigRibbon.UseVisualStyleBackColor = true;
      // 
      // tpTcp
      // 
      this.tpTcp.Controls.Add(this.idTcpTimeout);
      this.tpTcp.Controls.Add(this.label1);
      this.tpTcp.Controls.Add(this.idTcpPort);
      this.tpTcp.Location = new System.Drawing.Point(4, 22);
      this.tpTcp.Name = "tpTcp";
      this.tpTcp.Size = new System.Drawing.Size(447, 180);
      this.tpTcp.TabIndex = 1;
      this.tpTcp.Text = "TCP порт";
      this.tpTcp.UseVisualStyleBackColor = true;
      // 
      // idTcpTimeout
      // 
      this.idTcpTimeout.Caption = "Таймаут (мсек)";
      this.idTcpTimeout.CaptionWidth = 150;
      this.idTcpTimeout.DecimalPlaces = 0;
      this.idTcpTimeout.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idTcpTimeout.Location = new System.Drawing.Point(6, 60);
      this.idTcpTimeout.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
      this.idTcpTimeout.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.idTcpTimeout.Name = "idTcpTimeout";
      this.idTcpTimeout.ReadOnly = false;
      this.idTcpTimeout.Size = new System.Drawing.Size(435, 26);
      this.idTcpTimeout.TabIndex = 8;
      this.idTcpTimeout.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(212, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "Параметры соединения с устройствами";
      // 
      // idTcpPort
      // 
      this.idTcpPort.Caption = "Порт";
      this.idTcpPort.CaptionWidth = 150;
      this.idTcpPort.DecimalPlaces = 0;
      this.idTcpPort.Enabled = false;
      this.idTcpPort.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idTcpPort.Location = new System.Drawing.Point(6, 28);
      this.idTcpPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.idTcpPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
      this.idTcpPort.Name = "idTcpPort";
      this.idTcpPort.ReadOnly = true;
      this.idTcpPort.Size = new System.Drawing.Size(435, 26);
      this.idTcpPort.TabIndex = 6;
      this.idTcpPort.Value = new decimal(new int[] {
            10251,
            0,
            0,
            0});
      // 
      // tpEstTools
      // 
      this.tpEstTools.Controls.Add(this.pswEst);
      this.tpEstTools.Controls.Add(this.idEstPort);
      this.tpEstTools.Controls.Add(this.itEstUser);
      this.tpEstTools.Controls.Add(this.cbEstEnabled);
      this.tpEstTools.Controls.Add(this.itEstIpAddress);
      this.tpEstTools.Location = new System.Drawing.Point(4, 22);
      this.tpEstTools.Name = "tpEstTools";
      this.tpEstTools.Padding = new System.Windows.Forms.Padding(3);
      this.tpEstTools.Size = new System.Drawing.Size(447, 180);
      this.tpEstTools.TabIndex = 0;
      this.tpEstTools.Text = "EST Tools";
      this.tpEstTools.UseVisualStyleBackColor = true;
      // 
      // idEstPort
      // 
      this.idEstPort.Caption = "Порт";
      this.idEstPort.CaptionWidth = 150;
      this.idEstPort.DecimalPlaces = 0;
      this.idEstPort.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idEstPort.Location = new System.Drawing.Point(3, 61);
      this.idEstPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.idEstPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
      this.idEstPort.Name = "idEstPort";
      this.idEstPort.ReadOnly = false;
      this.idEstPort.Size = new System.Drawing.Size(435, 26);
      this.idEstPort.TabIndex = 5;
      this.idEstPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
      // 
      // itEstUser
      // 
      this.itEstUser.Caption = "Пользователь";
      this.itEstUser.CaptionWidth = 150;
      this.itEstUser.Location = new System.Drawing.Point(3, 93);
      this.itEstUser.Name = "itEstUser";
      this.itEstUser.PasswordChar = '\0';
      this.itEstUser.ReadOnly = false;
      this.itEstUser.Size = new System.Drawing.Size(435, 26);
      this.itEstUser.TabIndex = 3;
      this.itEstUser.Value = "";
      // 
      // cbEstEnabled
      // 
      this.cbEstEnabled.AutoSize = true;
      this.cbEstEnabled.Location = new System.Drawing.Point(9, 6);
      this.cbEstEnabled.Name = "cbEstEnabled";
      this.cbEstEnabled.Size = new System.Drawing.Size(352, 17);
      this.cbEstEnabled.TabIndex = 1;
      this.cbEstEnabled.Text = "Разрешить импортировать данные об устройствах из EST Tools";
      this.cbEstEnabled.UseVisualStyleBackColor = true;
      // 
      // itEstIpAddress
      // 
      this.itEstIpAddress.Caption = "IP-адрес";
      this.itEstIpAddress.CaptionWidth = 150;
      this.itEstIpAddress.Location = new System.Drawing.Point(3, 29);
      this.itEstIpAddress.Name = "itEstIpAddress";
      this.itEstIpAddress.PasswordChar = '\0';
      this.itEstIpAddress.ReadOnly = false;
      this.itEstIpAddress.Size = new System.Drawing.Size(435, 26);
      this.itEstIpAddress.TabIndex = 0;
      this.itEstIpAddress.Value = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(311, 250);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 1;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(392, 250);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // pswEst
      // 
      this.pswEst.CaptionWidth = 150;
      this.pswEst.Delay = 2000;
      this.pswEst.Location = new System.Drawing.Point(3, 124);
      this.pswEst.Name = "pswEst";
      this.pswEst.Size = new System.Drawing.Size(435, 50);
      this.pswEst.TabIndex = 6;
      this.pswEst.Value = "";
      // 
      // AppConfigForm
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(479, 285);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.tabControl);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AppConfigForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Настройка программы";
      this.tabControl.ResumeLayout(false);
      this.tpGeneral.ResumeLayout(false);
      this.tpTcp.ResumeLayout(false);
      this.tpTcp.PerformLayout();
      this.tpEstTools.ResumeLayout(false);
      this.tpEstTools.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tpEstTools;
    private Ztp.Ui.InputTextControl itEstIpAddress;
    private System.Windows.Forms.CheckBox cbEstEnabled;
    private Ztp.Ui.InputDoubleControl idEstPort;
    private Ztp.Ui.InputTextControl itEstUser;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.TabPage tpTcp;
    private Ztp.Ui.InputDoubleControl idTcpPort;
    private Ztp.Ui.InputDoubleControl idTcpTimeout;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TabPage tpGeneral;
    private System.Windows.Forms.CheckBox cbAutoOpenConfigRibbon;
    private Ztp.Ui.PasswordControl pswEst;
  }
}