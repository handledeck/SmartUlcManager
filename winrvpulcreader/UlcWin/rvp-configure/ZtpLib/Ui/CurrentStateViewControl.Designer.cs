namespace Ztp.Ui
{
  partial class CurrentStateViewControl
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
      this.groupBox = new System.Windows.Forms.GroupBox();
      this.richTextBox = new System.Windows.Forms.RichTextBox();
      this.bitViewDout = new Ztp.Ui.FlayoutBitArrayViewControl();
      this.bitViewDin = new Ztp.Ui.FlayoutBitArrayViewControl();
      this.ainView = new Ztp.Ui.CurrentAinViewControl();
      this.groupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox
      // 
      this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.groupBox.Controls.Add(this.richTextBox);
      this.groupBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.groupBox.Location = new System.Drawing.Point(0, 0);
      this.groupBox.Name = "groupBox";
      this.groupBox.Size = new System.Drawing.Size(346, 218);
      this.groupBox.TabIndex = 0;
      this.groupBox.TabStop = false;
      // 
      // richTextBox
      // 
      this.richTextBox.BackColor = System.Drawing.SystemColors.Window;
      this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.richTextBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.richTextBox.Location = new System.Drawing.Point(3, 18);
      this.richTextBox.Name = "richTextBox";
      this.richTextBox.ReadOnly = true;
      this.richTextBox.Size = new System.Drawing.Size(340, 197);
      this.richTextBox.TabIndex = 0;
      this.richTextBox.Text = "";
      this.richTextBox.WordWrap = false;
      // 
      // bitViewDout
      // 
      this.bitViewDout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.bitViewDout.BackColor = System.Drawing.SystemColors.Window;
      this.bitViewDout.Caption = "Дискретные выходы";
      this.bitViewDout.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.bitViewDout.Location = new System.Drawing.Point(0, 280);
      this.bitViewDout.Name = "bitViewDout";
      this.bitViewDout.Size = new System.Drawing.Size(346, 65);
      this.bitViewDout.TabIndex = 2;
      this.bitViewDout.Value = new bool[] {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false};
      this.bitViewDout.VisibleCount = 1;
      // 
      // bitViewDin
      // 
      this.bitViewDin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.bitViewDin.BackColor = System.Drawing.SystemColors.Window;
      this.bitViewDin.Caption = "Дискретные входы";
      this.bitViewDin.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.bitViewDin.Location = new System.Drawing.Point(0, 215);
      this.bitViewDin.Name = "bitViewDin";
      this.bitViewDin.Size = new System.Drawing.Size(346, 65);
      this.bitViewDin.TabIndex = 3;
      this.bitViewDin.Value = new bool[] {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false};
      this.bitViewDin.VisibleCount = 1;
      // 
      // ainView
      // 
      this.ainView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.ainView.BackColor = System.Drawing.SystemColors.Window;
      this.ainView.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.ainView.Location = new System.Drawing.Point(0, 341);
      this.ainView.Name = "ainView";
      this.ainView.Size = new System.Drawing.Size(346, 81);
      this.ainView.TabIndex = 1;
      this.ainView.Value = new ushort[] {
        ((ushort)(0))};
      this.ainView.VisibleCount = 1;
      // 
      // CurrentStateViewControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.ainView);
      this.Controls.Add(this.bitViewDout);
      this.Controls.Add(this.bitViewDin);
      this.Controls.Add(this.groupBox);
      this.Name = "CurrentStateViewControl";
      this.Size = new System.Drawing.Size(346, 422);
      this.groupBox.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox;
    private System.Windows.Forms.RichTextBox richTextBox;
    private FlayoutBitArrayViewControl bitViewDin;
    private FlayoutBitArrayViewControl bitViewDout;
    private CurrentAinViewControl ainView;
  }
}
