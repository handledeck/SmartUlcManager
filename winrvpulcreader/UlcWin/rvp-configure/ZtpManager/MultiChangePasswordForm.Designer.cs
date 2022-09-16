using System.Windows.Forms;

namespace ZtpManager
{
  partial class MultiChangePasswordForm
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
      Application.Idle -= Application_Idle;
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiChangePasswordForm));
      this.pnlFooter = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.pnlPassword = new System.Windows.Forms.Panel();
      this.selectDeviceControl = new ZtpManager.Controls.SelectDeviceControl();
      this.pswEditor = new Ztp.Ui.PasswordWithConfirmControl();
      this.pnlFooter.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.pnlPassword.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlFooter
      // 
      this.pnlFooter.Controls.Add(this.label1);
      this.pnlFooter.Controls.Add(this.btnCancel);
      this.pnlFooter.Controls.Add(this.btnOk);
      this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlFooter.Location = new System.Drawing.Point(0, 461);
      this.pnlFooter.Name = "pnlFooter";
      this.pnlFooter.Size = new System.Drawing.Size(729, 53);
      this.pnlFooter.TabIndex = 5;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "label1";
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(642, 18);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.Location = new System.Drawing.Point(561, 18);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 0;
      this.btnOk.Text = "Записать";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.pictureBox1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(729, 72);
      this.panel1.TabIndex = 7;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.Location = new System.Drawing.Point(67, 13);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(650, 48);
      this.label2.TabIndex = 1;
      this.label2.Text = "На указанных устройствах будет изменен пароль доступа";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(13, 13);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(48, 48);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // pnlPassword
      // 
      this.pnlPassword.Controls.Add(this.pswEditor);
      this.pnlPassword.Dock = System.Windows.Forms.DockStyle.Right;
      this.pnlPassword.Location = new System.Drawing.Point(402, 72);
      this.pnlPassword.Name = "pnlPassword";
      this.pnlPassword.Size = new System.Drawing.Size(327, 389);
      this.pnlPassword.TabIndex = 8;
      // 
      // selectDeviceControl
      // 
      this.selectDeviceControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.selectDeviceControl.Location = new System.Drawing.Point(0, 72);
      this.selectDeviceControl.Name = "selectDeviceControl";
      this.selectDeviceControl.Size = new System.Drawing.Size(402, 389);
      this.selectDeviceControl.TabIndex = 9;
      this.selectDeviceControl.SelectionChanged += new System.EventHandler(this.selectDeviceControl_SelectionChanged);
      // 
      // pswEditor
      // 
      this.pswEditor.Location = new System.Drawing.Point(6, 21);
      this.pswEditor.Name = "pswEditor";
      this.pswEditor.Size = new System.Drawing.Size(309, 79);
      this.pswEditor.TabIndex = 0;
      this.pswEditor.Value = "";
      // 
      // MultiChangePasswordForm
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(729, 514);
      this.Controls.Add(this.selectDeviceControl);
      this.Controls.Add(this.pnlPassword);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.pnlFooter);
      this.MinimizeBox = false;
      this.Name = "MultiChangePasswordForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Пакетная смена пароля";
      this.pnlFooter.ResumeLayout(false);
      this.pnlFooter.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.pnlPassword.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlFooter;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Panel pnlPassword;
    private Controls.SelectDeviceControl selectDeviceControl;
    private Ztp.Ui.PasswordWithConfirmControl pswEditor;
  }
}