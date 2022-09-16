namespace ZtpManager
{
  partial class EstDevicesForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstDevicesForm));
      this.flvEst = new ZtpManager.Controls.FilteredListViewControl();
      this.iml = new System.Windows.Forms.ImageList(this.components);
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.pnlFooter = new System.Windows.Forms.Panel();
      this.pswEdit = new Ztp.Ui.PasswordWithConfirmControl();
      this.pnlFooter.SuspendLayout();
      this.SuspendLayout();
      // 
      // flvEst
      // 
      this.flvEst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.flvEst.Location = new System.Drawing.Point(12, 12);
      this.flvEst.Name = "flvEst";
      this.flvEst.Size = new System.Drawing.Size(630, 352);
      this.flvEst.TabIndex = 1;
      // 
      // iml
      // 
      this.iml.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml.ImageStream")));
      this.iml.TransparentColor = System.Drawing.Color.Transparent;
      this.iml.Images.SetKeyName(0, "PCI-card.png");
      this.iml.Images.SetKeyName(1, "forbidden.png");
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.Location = new System.Drawing.Point(486, 113);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 0;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(567, 113);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(287, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Укажите пароль доступа к создаваемым усиройствам";
      // 
      // pnlFooter
      // 
      this.pnlFooter.Controls.Add(this.pswEdit);
      this.pnlFooter.Controls.Add(this.label1);
      this.pnlFooter.Controls.Add(this.btnCancel);
      this.pnlFooter.Controls.Add(this.btnOk);
      this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlFooter.Location = new System.Drawing.Point(0, 370);
      this.pnlFooter.Name = "pnlFooter";
      this.pnlFooter.Size = new System.Drawing.Size(654, 148);
      this.pnlFooter.TabIndex = 0;
      // 
      // pswEdit
      // 
      this.pswEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pswEdit.CaptionWidth = 100;
      this.pswEdit.Location = new System.Drawing.Point(12, 16);
      this.pswEdit.Name = "pswEdit";
      this.pswEdit.Size = new System.Drawing.Size(630, 79);
      this.pswEdit.TabIndex = 3;
      this.pswEdit.Value = "";
      // 
      // EstDevicesForm
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(654, 518);
      this.Controls.Add(this.flvEst);
      this.Controls.Add(this.pnlFooter);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(670, 400);
      this.Name = "EstDevicesForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "Устройства УУСИ-16 зарегистрированные в EST Tools";
      this.pnlFooter.ResumeLayout(false);
      this.pnlFooter.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    private Controls.FilteredListViewControl flvEst;
    private System.Windows.Forms.ImageList iml;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel pnlFooter;
    private Ztp.Ui.PasswordWithConfirmControl pswEdit;
  }
}