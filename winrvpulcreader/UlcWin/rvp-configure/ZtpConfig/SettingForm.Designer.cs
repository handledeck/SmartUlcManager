namespace Ztp
{
  partial class SettingForm
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
      this.pnlEditor = new System.Windows.Forms.Panel();
      this.btnAction = new System.Windows.Forms.Button();
      this.btnClose = new System.Windows.Forms.Button();
      this.btnSearchByCom = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // pnlEditor
      // 
      this.pnlEditor.Location = new System.Drawing.Point(12, 12);
      this.pnlEditor.Name = "pnlEditor";
      this.pnlEditor.Size = new System.Drawing.Size(409, 245);
      this.pnlEditor.TabIndex = 0;
      // 
      // btnAction
      // 
      this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAction.Location = new System.Drawing.Point(265, 263);
      this.btnAction.Name = "btnAction";
      this.btnAction.Size = new System.Drawing.Size(75, 23);
      this.btnAction.TabIndex = 1;
      this.btnAction.Text = "OK";
      this.btnAction.UseVisualStyleBackColor = true;
      this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnClose.Location = new System.Drawing.Point(346, 263);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 2;
      this.btnClose.Text = "Отмена";
      this.btnClose.UseVisualStyleBackColor = true;
      // 
      // btnSearchByCom
      // 
      this.btnSearchByCom.Location = new System.Drawing.Point(70, 263);
      this.btnSearchByCom.Name = "btnSearchByCom";
      this.btnSearchByCom.Size = new System.Drawing.Size(189, 23);
      this.btnSearchByCom.TabIndex = 3;
      this.btnSearchByCom.Text = "Поиск устройства по COM-порту";
      this.btnSearchByCom.UseVisualStyleBackColor = true;
      this.btnSearchByCom.Click += new System.EventHandler(this.btnSearchByCom_Click);
      // 
      // SettingForm
      // 
      this.AcceptButton = this.btnAction;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnClose;
      this.ClientSize = new System.Drawing.Size(432, 309);
      this.ControlBox = false;
      this.Controls.Add(this.btnSearchByCom);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.btnAction);
      this.Controls.Add(this.pnlEditor);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SettingForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Параметры соединения";
      this.Load += new System.EventHandler(this.SettingForm_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlEditor;
    private System.Windows.Forms.Button btnAction;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnSearchByCom;
  }
}