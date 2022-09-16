namespace ZtpManager
{
  partial class MultiSwitchOnOffForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiSwitchOnOffForm));
      this.selectDeviceControl = new ZtpManager.Controls.SelectDeviceControl();
      this.pnlLeft = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.pnlFooter = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.rbOff = new System.Windows.Forms.RadioButton();
      this.rbOn = new System.Windows.Forms.RadioButton();
      this.pnlLeft.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.pnlFooter.SuspendLayout();
      this.SuspendLayout();
      // 
      // selectDeviceControl
      // 
      this.selectDeviceControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.selectDeviceControl.Location = new System.Drawing.Point(0, 72);
      this.selectDeviceControl.Name = "selectDeviceControl";
      this.selectDeviceControl.Size = new System.Drawing.Size(489, 310);
      this.selectDeviceControl.TabIndex = 13;
      this.selectDeviceControl.SelectionChanged += new System.EventHandler(this.selectDeviceControl_SelectionChanged);
      // 
      // pnlLeft
      // 
      this.pnlLeft.Controls.Add(this.rbOn);
      this.pnlLeft.Controls.Add(this.rbOff);
      this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Right;
      this.pnlLeft.Location = new System.Drawing.Point(489, 72);
      this.pnlLeft.Name = "pnlLeft";
      this.pnlLeft.Size = new System.Drawing.Size(187, 310);
      this.pnlLeft.TabIndex = 12;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.pictureBox1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(676, 72);
      this.panel1.TabIndex = 11;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.Location = new System.Drawing.Point(67, 13);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(597, 48);
      this.label2.TabIndex = 1;
      this.label2.Text = "На указанных устройствах будет включено или отключено освещение";
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
      // pnlFooter
      // 
      this.pnlFooter.Controls.Add(this.label1);
      this.pnlFooter.Controls.Add(this.btnCancel);
      this.pnlFooter.Controls.Add(this.btnOk);
      this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlFooter.Location = new System.Drawing.Point(0, 382);
      this.pnlFooter.Name = "pnlFooter";
      this.pnlFooter.Size = new System.Drawing.Size(676, 53);
      this.pnlFooter.TabIndex = 10;
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
      this.btnCancel.Location = new System.Drawing.Point(589, 18);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.Location = new System.Drawing.Point(508, 18);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 0;
      this.btnOk.Text = "Записать";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // rbOff
      // 
      this.rbOff.Appearance = System.Windows.Forms.Appearance.Button;
      this.rbOff.Checked = true;
      this.rbOff.Image = ((System.Drawing.Image)(resources.GetObject("rbOff.Image")));
      this.rbOff.Location = new System.Drawing.Point(6, 23);
      this.rbOff.Name = "rbOff";
      this.rbOff.Size = new System.Drawing.Size(174, 64);
      this.rbOff.TabIndex = 0;
      this.rbOff.TabStop = true;
      this.rbOff.Text = "Отключить";
      this.rbOff.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.rbOff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.rbOff.UseVisualStyleBackColor = true;
      // 
      // rbOn
      // 
      this.rbOn.Appearance = System.Windows.Forms.Appearance.Button;
      this.rbOn.Image = ((System.Drawing.Image)(resources.GetObject("rbOn.Image")));
      this.rbOn.Location = new System.Drawing.Point(6, 93);
      this.rbOn.Name = "rbOn";
      this.rbOn.Size = new System.Drawing.Size(174, 64);
      this.rbOn.TabIndex = 1;
      this.rbOn.Text = "Включить";
      this.rbOn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.rbOn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.rbOn.UseVisualStyleBackColor = true;
      // 
      // MultiSwitchOnOffForm
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(676, 435);
      this.Controls.Add(this.selectDeviceControl);
      this.Controls.Add(this.pnlLeft);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.pnlFooter);
      this.MinimizeBox = false;
      this.Name = "MultiSwitchOnOffForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Пакетное включение/отключение освещения";
      this.pnlLeft.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.pnlFooter.ResumeLayout(false);
      this.pnlFooter.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.SelectDeviceControl selectDeviceControl;
    private System.Windows.Forms.Panel pnlLeft;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Panel pnlFooter;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.RadioButton rbOn;
    private System.Windows.Forms.RadioButton rbOff;
  }
}