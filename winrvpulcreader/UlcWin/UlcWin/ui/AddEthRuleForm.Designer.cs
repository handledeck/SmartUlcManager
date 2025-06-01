
namespace Ztp.Ui
{
  partial class AddEthRuleForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.cbProtocol = new System.Windows.Forms.ComboBox();
      this.idcDestPort = new Ztp.Ui.InputDoubleControl();
      this.idcSrcPort = new Ztp.Ui.InputDoubleControl();
      this.itcIP = new Ztp.Ui.InputTextControl();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
      this.SuspendLayout();
      // 
      // errorProvider
      // 
      this.errorProvider.ContainerControl = this;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(270, 142);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.Location = new System.Drawing.Point(189, 142);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "Принять";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(18, 112);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(56, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "Протокол";
      // 
      // cbProtocol
      // 
      this.cbProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbProtocol.FormattingEnabled = true;
      this.cbProtocol.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
      this.cbProtocol.Location = new System.Drawing.Point(165, 109);
      this.cbProtocol.Name = "cbProtocol";
      this.cbProtocol.Size = new System.Drawing.Size(180, 21);
      this.cbProtocol.TabIndex = 6;
      // 
      // idcDestPort
      // 
      this.idcDestPort.Caption = "Локальный порт";
      this.idcDestPort.CaptionWidth = 150;
      this.idcDestPort.DecimalPlaces = 0;
      this.idcDestPort.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idcDestPort.Location = new System.Drawing.Point(13, 44);
      this.idcDestPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.idcDestPort.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
      this.idcDestPort.Name = "idcDestPort";
      this.idcDestPort.ReadOnly = false;
      this.idcDestPort.Size = new System.Drawing.Size(334, 26);
      this.idcDestPort.TabIndex = 2;
      this.idcDestPort.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
      // 
      // idcSrcPort
      // 
      this.idcSrcPort.Caption = "Порт назначения";
      this.idcSrcPort.CaptionWidth = 150;
      this.idcSrcPort.DecimalPlaces = 0;
      this.idcSrcPort.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idcSrcPort.Location = new System.Drawing.Point(13, 76);
      this.idcSrcPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.idcSrcPort.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
      this.idcSrcPort.Name = "idcSrcPort";
      this.idcSrcPort.ReadOnly = false;
      this.idcSrcPort.Size = new System.Drawing.Size(335, 26);
      this.idcSrcPort.TabIndex = 1;
      this.idcSrcPort.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
      // 
      // itcIP
      // 
      this.itcIP.Caption = "Локальный IP-адрес";
      this.itcIP.CaptionWidth = 150;
      this.itcIP.Location = new System.Drawing.Point(12, 12);
      this.itcIP.Name = "itcIP";
      this.itcIP.PasswordChar = '\0';
      this.itcIP.ReadOnly = false;
      this.itcIP.Size = new System.Drawing.Size(335, 26);
      this.itcIP.TabIndex = 0;
      this.itcIP.Value = "127.0.0.1";
      this.itcIP.MouseLeave += new System.EventHandler(this.itcIP_Validated);
      this.itcIP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.itcIP_Validated);
      this.itcIP.Validated += new System.EventHandler(this.itcIP_Validated);
      // 
      // AddEthRuleForm
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(359, 177);
      this.ControlBox = false;
      this.Controls.Add(this.cbProtocol);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.idcDestPort);
      this.Controls.Add(this.idcSrcPort);
      this.Controls.Add(this.itcIP);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AddEthRuleForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Правило";
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ErrorProvider errorProvider;
    private InputTextControl itcIP;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private InputDoubleControl idcDestPort;
    private InputDoubleControl idcSrcPort;
    private System.Windows.Forms.ComboBox cbProtocol;
    private System.Windows.Forms.Label label1;
  }
}