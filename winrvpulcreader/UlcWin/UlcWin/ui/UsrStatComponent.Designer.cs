namespace UlcWin.ui
{
  partial class UsrStatComponent
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
      this.roundedControl1 = new UlcWin.ui.RoundBorderPanel();
      this.label4 = new System.Windows.Forms.Label();
      this.lblAllGsm = new System.Windows.Forms.Label();
      this.label32 = new System.Windows.Forms.Label();
      this.lblAllNotRs = new System.Windows.Forms.Label();
      this.lblHeader = new System.Windows.Forms.Label();
      this.label28 = new System.Windows.Forms.Label();
      this.lblAll = new System.Windows.Forms.Label();
      this.lblAllNot = new System.Windows.Forms.Label();
      this.roundedControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // roundedControl1
      // 
      this.roundedControl1.BackColor = System.Drawing.Color.Transparent;
      this.roundedControl1.BackShapeColor = System.Drawing.Color.White;
      this.roundedControl1.Controls.Add(this.label4);
      this.roundedControl1.Controls.Add(this.lblAllGsm);
      this.roundedControl1.Controls.Add(this.label32);
      this.roundedControl1.Controls.Add(this.lblAllNotRs);
      this.roundedControl1.Controls.Add(this.lblHeader);
      this.roundedControl1.Controls.Add(this.label28);
      this.roundedControl1.Controls.Add(this.lblAll);
      this.roundedControl1.Controls.Add(this.lblAllNot);
      this.roundedControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.roundedControl1.Location = new System.Drawing.Point(0, 0);
      this.roundedControl1.Name = "roundedControl1";
      this.roundedControl1.Padding = new System.Windows.Forms.Padding(2);
      this.roundedControl1.RoundCorner = 5;
      this.roundedControl1.ShapeBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(51)))), ((int)(((byte)(94)))), ((int)(((byte)(129)))));
      this.roundedControl1.ShapeBorderPadding = 1;
      this.roundedControl1.ShapeBorderWitdh = 1;
      this.roundedControl1.Size = new System.Drawing.Size(315, 98);
      this.roundedControl1.TabIndex = 21;
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.label4.AutoEllipsis = true;
      this.label4.BackColor = System.Drawing.Color.White;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label4.ForeColor = System.Drawing.Color.Gray;
      this.label4.Location = new System.Drawing.Point(135, 37);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(73, 19);
      this.label4.TabIndex = 23;
      this.label4.Text = "Нет связи";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblAllGsm
      // 
      this.lblAllGsm.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.lblAllGsm.AutoEllipsis = true;
      this.lblAllGsm.BackColor = System.Drawing.Color.White;
      this.lblAllGsm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAllGsm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.lblAllGsm.Location = new System.Drawing.Point(250, 72);
      this.lblAllGsm.Name = "lblAllGsm";
      this.lblAllGsm.Size = new System.Drawing.Size(57, 18);
      this.lblAllGsm.TabIndex = 36;
      this.lblAllGsm.Text = "161345";
      this.lblAllGsm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label32
      // 
      this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.label32.AutoEllipsis = true;
      this.label32.BackColor = System.Drawing.Color.White;
      this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label32.ForeColor = System.Drawing.Color.Gray;
      this.label32.Location = new System.Drawing.Point(135, 72);
      this.label32.Name = "label32";
      this.label32.Size = new System.Drawing.Size(127, 18);
      this.label32.TabIndex = 35;
      this.label32.Text = "Слабый сигнал GSM";
      this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblAllNotRs
      // 
      this.lblAllNotRs.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.lblAllNotRs.AutoEllipsis = true;
      this.lblAllNotRs.BackColor = System.Drawing.Color.White;
      this.lblAllNotRs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAllNotRs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.lblAllNotRs.Location = new System.Drawing.Point(250, 54);
      this.lblAllNotRs.Name = "lblAllNotRs";
      this.lblAllNotRs.Size = new System.Drawing.Size(57, 17);
      this.lblAllNotRs.TabIndex = 34;
      this.lblAllNotRs.Text = "161345";
      this.lblAllNotRs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblHeader
      // 
      this.lblHeader.AutoEllipsis = true;
      this.lblHeader.BackColor = System.Drawing.Color.White;
      this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.lblHeader.Location = new System.Drawing.Point(23, 9);
      this.lblHeader.Name = "lblHeader";
      this.lblHeader.Size = new System.Drawing.Size(239, 24);
      this.lblHeader.TabIndex = 24;
      this.lblHeader.Text = "Активных контроллеров ";
      // 
      // label28
      // 
      this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.label28.AutoEllipsis = true;
      this.label28.BackColor = System.Drawing.Color.White;
      this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label28.ForeColor = System.Drawing.Color.Gray;
      this.label28.Location = new System.Drawing.Point(135, 54);
      this.label28.Name = "label28";
      this.label28.Size = new System.Drawing.Size(109, 18);
      this.label28.TabIndex = 33;
      this.label28.Text = "Нет связи RS-485";
      this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblAll
      // 
      this.lblAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.lblAll.AutoEllipsis = true;
      this.lblAll.BackColor = System.Drawing.Color.White;
      this.lblAll.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.lblAll.Location = new System.Drawing.Point(19, 36);
      this.lblAll.Name = "lblAll";
      this.lblAll.Size = new System.Drawing.Size(110, 45);
      this.lblAll.TabIndex = 22;
      this.lblAll.Text = "3076";
      this.lblAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblAllNot
      // 
      this.lblAllNot.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.lblAllNot.AutoEllipsis = true;
      this.lblAllNot.BackColor = System.Drawing.Color.White;
      this.lblAllNot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAllNot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.lblAllNot.Location = new System.Drawing.Point(250, 36);
      this.lblAllNot.Name = "lblAllNot";
      this.lblAllNot.Size = new System.Drawing.Size(57, 18);
      this.lblAllNot.TabIndex = 25;
      this.lblAllNot.Text = "161345";
      this.lblAllNot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // UsrStatComponent
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Transparent;
      this.Controls.Add(this.roundedControl1);
      this.Name = "UsrStatComponent";
      this.Size = new System.Drawing.Size(315, 98);
      this.roundedControl1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

        #endregion

        private RoundBorderPanel roundedControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label28;
        public System.Windows.Forms.Label lblAllGsm;
        public System.Windows.Forms.Label lblAllNotRs;
        public System.Windows.Forms.Label lblHeader;
        public System.Windows.Forms.Label lblAll;
        public System.Windows.Forms.Label lblAllNot;
    }
}
