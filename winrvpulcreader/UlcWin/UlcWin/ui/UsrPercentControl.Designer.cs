namespace UlcWin.ui
{
  partial class UsrPercentControl
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
      this.lblHeader = new System.Windows.Forms.Label();
      this.lblPercent = new System.Windows.Forms.Label();
      this.roundedControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // roundedControl1
      // 
      this.roundedControl1.BackColor = System.Drawing.Color.Transparent;
      this.roundedControl1.BackShapeColor = System.Drawing.Color.White;
      this.roundedControl1.Controls.Add(this.lblHeader);
      this.roundedControl1.Controls.Add(this.lblPercent);
      this.roundedControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.roundedControl1.Location = new System.Drawing.Point(0, 0);
      this.roundedControl1.Name = "roundedControl1";
      this.roundedControl1.Padding = new System.Windows.Forms.Padding(2);
      this.roundedControl1.RoundCorner = 5;
      this.roundedControl1.ShapeBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(51)))), ((int)(((byte)(94)))), ((int)(((byte)(129)))));
      this.roundedControl1.ShapeBorderPadding = 3;
      this.roundedControl1.ShapeBorderWitdh = 1;
      this.roundedControl1.Size = new System.Drawing.Size(213, 115);
      this.roundedControl1.TabIndex = 22;
      // 
      // lblHeader
      // 
      this.lblHeader.AutoEllipsis = true;
      this.lblHeader.BackColor = System.Drawing.Color.White;
      this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.lblHeader.Location = new System.Drawing.Point(23, 12);
      this.lblHeader.Name = "lblHeader";
      this.lblHeader.Size = new System.Drawing.Size(127, 24);
      this.lblHeader.TabIndex = 24;
      this.lblHeader.Text = "Отклонение в % ";
      // 
      // lblPercent
      // 
      this.lblPercent.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.lblPercent.AutoEllipsis = true;
      this.lblPercent.BackColor = System.Drawing.Color.White;
      this.lblPercent.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.lblPercent.Location = new System.Drawing.Point(19, 45);
      this.lblPercent.Name = "lblPercent";
      this.lblPercent.Size = new System.Drawing.Size(154, 46);
      this.lblPercent.TabIndex = 22;
      this.lblPercent.Text = "3076";
      this.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // UsrPercentControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Transparent;
      this.Controls.Add(this.roundedControl1);
      this.Name = "UsrPercentControl";
      this.Size = new System.Drawing.Size(213, 115);
      this.roundedControl1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

        #endregion

        private RoundBorderPanel roundedControl1;
        public System.Windows.Forms.Label lblHeader;
        public System.Windows.Forms.Label lblPercent;
    }
}
