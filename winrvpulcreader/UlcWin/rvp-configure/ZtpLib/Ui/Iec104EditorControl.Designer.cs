namespace Ztp.Ui
{
  partial class Iec104EditorControl
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
      this.idT1 = new Ztp.Ui.InputDoubleControl();
      this.idT2 = new Ztp.Ui.InputDoubleControl();
      this.idT3 = new Ztp.Ui.InputDoubleControl();
      this.idK = new Ztp.Ui.InputDoubleControl();
      this.idW = new Ztp.Ui.InputDoubleControl();
      this.SuspendLayout();
      // 
      // idT1
      // 
      this.idT1.Caption = "t1";
      this.idT1.CaptionWidth = 40;
      this.idT1.DecimalPlaces = 0;
      this.idT1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idT1.Location = new System.Drawing.Point(18, 5);
      this.idT1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.idT1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idT1.Name = "idT1";
      this.idT1.ReadOnly = false;
      this.idT1.Size = new System.Drawing.Size(123, 26);
      this.idT1.TabIndex = 0;
      this.idT1.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
      // 
      // idT2
      // 
      this.idT2.Caption = "t2";
      this.idT2.CaptionWidth = 40;
      this.idT2.DecimalPlaces = 0;
      this.idT2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idT2.Location = new System.Drawing.Point(18, 31);
      this.idT2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.idT2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idT2.Name = "idT2";
      this.idT2.ReadOnly = false;
      this.idT2.Size = new System.Drawing.Size(123, 26);
      this.idT2.TabIndex = 1;
      this.idT2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // idT3
      // 
      this.idT3.Caption = "t3";
      this.idT3.CaptionWidth = 40;
      this.idT3.DecimalPlaces = 0;
      this.idT3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idT3.Location = new System.Drawing.Point(18, 57);
      this.idT3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.idT3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idT3.Name = "idT3";
      this.idT3.ReadOnly = false;
      this.idT3.Size = new System.Drawing.Size(123, 26);
      this.idT3.TabIndex = 2;
      this.idT3.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
      // 
      // idK
      // 
      this.idK.Caption = "k";
      this.idK.CaptionWidth = 40;
      this.idK.DecimalPlaces = 0;
      this.idK.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idK.Location = new System.Drawing.Point(178, 19);
      this.idK.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.idK.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idK.Name = "idK";
      this.idK.ReadOnly = false;
      this.idK.Size = new System.Drawing.Size(123, 26);
      this.idK.TabIndex = 3;
      this.idK.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
      // 
      // idW
      // 
      this.idW.Caption = "w";
      this.idW.CaptionWidth = 40;
      this.idW.DecimalPlaces = 0;
      this.idW.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idW.Location = new System.Drawing.Point(178, 44);
      this.idW.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.idW.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idW.Name = "idW";
      this.idW.ReadOnly = false;
      this.idW.Size = new System.Drawing.Size(123, 26);
      this.idW.TabIndex = 4;
      this.idW.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
      // 
      // Iec104EditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.idW);
      this.Controls.Add(this.idK);
      this.Controls.Add(this.idT3);
      this.Controls.Add(this.idT2);
      this.Controls.Add(this.idT1);
      this.Name = "Iec104EditorControl";
      this.Size = new System.Drawing.Size(310, 86);
      this.ResumeLayout(false);

    }

    #endregion

    private InputDoubleControl idT1;
    private InputDoubleControl idT2;
    private InputDoubleControl idT3;
    private InputDoubleControl idK;
    private InputDoubleControl idW;
  }
}
