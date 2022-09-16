namespace ZtpManager
{
  partial class EditDeviceForm
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
      this.itDescription = new Ztp.Ui.InputTextControl();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.itName = new Ztp.Ui.InputTextControl();
      this.itIpAddress = new Ztp.Ui.InputTextControl();
      this.pswEdit = new Ztp.Ui.PasswordControl();
      this.DevTypeCtrl = new Ztp.Ui.SelectDevTypeControl();
      this.SuspendLayout();
      // 
      // itDescription
      // 
      this.itDescription.Caption = "Комментарий";
      this.itDescription.CaptionWidth = 150;
      this.itDescription.Location = new System.Drawing.Point(12, 165);
      this.itDescription.Name = "itDescription";
      this.itDescription.PasswordChar = '\0';
      this.itDescription.ReadOnly = false;
      this.itDescription.Size = new System.Drawing.Size(455, 26);
      this.itDescription.TabIndex = 3;
      this.itDescription.Value = "";
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(389, 199);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.Location = new System.Drawing.Point(308, 199);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 4;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // itName
      // 
      this.itName.Caption = "Наименование устройства";
      this.itName.CaptionWidth = 150;
      this.itName.Location = new System.Drawing.Point(12, 12);
      this.itName.Name = "itName";
      this.itName.PasswordChar = '\0';
      this.itName.ReadOnly = false;
      this.itName.Size = new System.Drawing.Size(455, 26);
      this.itName.TabIndex = 0;
      this.itName.Value = "";
      // 
      // itIpAddress
      // 
      this.itIpAddress.Caption = "IP-адрес";
      this.itIpAddress.CaptionWidth = 150;
      this.itIpAddress.Location = new System.Drawing.Point(12, 77);
      this.itIpAddress.Name = "itIpAddress";
      this.itIpAddress.PasswordChar = '\0';
      this.itIpAddress.ReadOnly = false;
      this.itIpAddress.Size = new System.Drawing.Size(455, 26);
      this.itIpAddress.TabIndex = 1;
      this.itIpAddress.Value = "";
      // 
      // pswEdit
      // 
      this.pswEdit.CaptionWidth = 150;
      this.pswEdit.Delay = 2000;
      this.pswEdit.Location = new System.Drawing.Point(12, 109);
      this.pswEdit.Name = "pswEdit";
      this.pswEdit.Size = new System.Drawing.Size(455, 50);
      this.pswEdit.TabIndex = 7;
      this.pswEdit.Value = "admin";
      // 
      // DevTypeCtrl
      // 
      this.DevTypeCtrl.Caption = "Тип устройства";
      this.DevTypeCtrl.Location = new System.Drawing.Point(13, 45);
      this.DevTypeCtrl.Name = "DevTypeCtrl";
      this.DevTypeCtrl.Size = new System.Drawing.Size(454, 26);
      this.DevTypeCtrl.TabIndex = 8;
      this.DevTypeCtrl.Value = Ztp.Enums.DevType.RVP18;
      // 
      // EditDeviceForm
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(479, 235);
      this.Controls.Add(this.DevTypeCtrl);
      this.Controls.Add(this.pswEdit);
      this.Controls.Add(this.itIpAddress);
      this.Controls.Add(this.itDescription);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.itName);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "EditDeviceForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Устройство";
      this.ResumeLayout(false);

    }

    #endregion

    private Ztp.Ui.InputTextControl itDescription;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOk;
    private Ztp.Ui.InputTextControl itName;
    private Ztp.Ui.InputTextControl itIpAddress;
    private Ztp.Ui.PasswordControl pswEdit;
    private Ztp.Ui.SelectDevTypeControl DevTypeCtrl;
  }
}