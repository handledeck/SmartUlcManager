namespace UlcWin.Edit
{
  partial class MeterEditFrom
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeterEditFrom));
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.cbActMeter = new System.Windows.Forms.CheckBox();
      this.lineHorizont1 = new UlcWin.Controls.MeterProgress.LineHorizont(this.components);
      this.txtBoxPlant = new UlcWin.ui.TextBoxPlaceHolder();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.Location = new System.Drawing.Point(312, 127);
      this.btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(88, 23);
      this.btnOk.TabIndex = 4;
      this.btnOk.Text = "Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.Location = new System.Drawing.Point(216, 127);
      this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(88, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // comboBox1
      // 
      this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(18, 34);
      this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(282, 21);
      this.comboBox1.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(24, 18);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(96, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Тип устройства";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(24, 58);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(109, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Заводской номер";
      // 
      // errorProvider1
      // 
      this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
      this.errorProvider1.ContainerControl = this;
      this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
      // 
      // cbActMeter
      // 
      this.cbActMeter.AutoSize = true;
      this.cbActMeter.Checked = true;
      this.cbActMeter.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbActMeter.Location = new System.Drawing.Point(236, 78);
      this.cbActMeter.Name = "cbActMeter";
      this.cbActMeter.Size = new System.Drawing.Size(137, 17);
      this.cbActMeter.TabIndex = 25;
      this.cbActMeter.Text = "Акитвность опроса";
      this.cbActMeter.UseVisualStyleBackColor = true;
      // 
      // lineHorizont1
      // 
      this.lineHorizont1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lineHorizont1.Location = new System.Drawing.Point(2, 112);
      this.lineHorizont1.MaximumSize = new System.Drawing.Size(0, 2);
      this.lineHorizont1.Name = "lineHorizont1";
      this.lineHorizont1.Size = new System.Drawing.Size(408, 2);
      this.lineHorizont1.TabIndex = 26;
      // 
      // txtBoxPlant
      // 
      this.txtBoxPlant.CueText = "макс. 30 симв.";
      this.txtBoxPlant.IsValid = false;
      this.txtBoxPlant.Location = new System.Drawing.Point(18, 74);
      this.txtBoxPlant.Name = "txtBoxPlant";
      this.txtBoxPlant.Size = new System.Drawing.Size(193, 21);
      this.txtBoxPlant.TabIndex = 6;
      // 
      // MeterEditFrom
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(413, 162);
      this.Controls.Add(this.lineHorizont1);
      this.Controls.Add(this.cbActMeter);
      this.Controls.Add(this.txtBoxPlant);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.comboBox1);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MeterEditFrom";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Устройство";
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    public System.Windows.Forms.ComboBox comboBox1;
    public ui.TextBoxPlaceHolder txtBoxPlant;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    private Controls.MeterProgress.LineHorizont lineHorizont1;
    public System.Windows.Forms.CheckBox cbActMeter;
  }
}