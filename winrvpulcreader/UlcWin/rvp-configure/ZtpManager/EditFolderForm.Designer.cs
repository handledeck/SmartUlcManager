namespace ZtpManager
{
  partial class EditFolderForm
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
      this.itName = new Ztp.Ui.InputTextControl();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.itDescription = new Ztp.Ui.InputTextControl();
      this.SuspendLayout();
      // 
      // itName
      // 
      this.itName.Caption = "Наименование папки";
      this.itName.Location = new System.Drawing.Point(12, 12);
      this.itName.Name = "itName";
      this.itName.PasswordChar = '\0';
      this.itName.ReadOnly = false;
      this.itName.Size = new System.Drawing.Size(455, 26);
      this.itName.TabIndex = 0;
      this.itName.Value = "";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(311, 99);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 2;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(392, 99);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // itDescription
      // 
      this.itDescription.Caption = "Комментарий";
      this.itDescription.Location = new System.Drawing.Point(12, 44);
      this.itDescription.Name = "itDescription";
      this.itDescription.PasswordChar = '\0';
      this.itDescription.ReadOnly = false;
      this.itDescription.Size = new System.Drawing.Size(455, 26);
      this.itDescription.TabIndex = 1;
      this.itDescription.Value = "";
      // 
      // EditFolderForm
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(479, 134);
      this.Controls.Add(this.itDescription);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.itName);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "EditFolderForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Папка";
      this.ResumeLayout(false);

    }

    #endregion

    private Ztp.Ui.InputTextControl itName;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
    private Ztp.Ui.InputTextControl itDescription;
  }
}