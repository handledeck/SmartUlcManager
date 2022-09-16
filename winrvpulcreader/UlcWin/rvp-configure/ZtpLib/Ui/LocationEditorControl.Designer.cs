namespace Ztp.Ui
{
  partial class LocationEditorControl
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
      this.idLatitude = new Ztp.Ui.InputDoubleControl();
      this.idLongitude = new Ztp.Ui.InputDoubleControl();
      this.itzTz = new Ztp.Ui.InputTimeZoneControl();
      this.SuspendLayout();
      // 
      // idLatitude
      // 
      this.idLatitude.Caption = "Широта";
      this.idLatitude.CaptionWidth = 70;
      this.idLatitude.DecimalPlaces = 3;
      this.idLatitude.Dock = System.Windows.Forms.DockStyle.Left;
      this.idLatitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idLatitude.Location = new System.Drawing.Point(0, 0);
      this.idLatitude.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
      this.idLatitude.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
      this.idLatitude.Name = "idLatitude";
      this.idLatitude.ReadOnly = false;
      this.idLatitude.Size = new System.Drawing.Size(160, 28);
      this.idLatitude.TabIndex = 0;
      this.idLatitude.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
      this.idLatitude.ValueChanged += new System.EventHandler(this.idLatitude_ValueChanged);
      // 
      // idLongitude
      // 
      this.idLongitude.Caption = "Долгота";
      this.idLongitude.CaptionWidth = 70;
      this.idLongitude.DecimalPlaces = 3;
      this.idLongitude.Dock = System.Windows.Forms.DockStyle.Left;
      this.idLongitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idLongitude.Location = new System.Drawing.Point(160, 0);
      this.idLongitude.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
      this.idLongitude.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
      this.idLongitude.Name = "idLongitude";
      this.idLongitude.ReadOnly = false;
      this.idLongitude.Size = new System.Drawing.Size(160, 28);
      this.idLongitude.TabIndex = 1;
      this.idLongitude.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
      this.idLongitude.ValueChanged += new System.EventHandler(this.idLongitude_ValueChanged);
      // 
      // itzTz
      // 
      this.itzTz.Caption = "Часовой пояс";
      this.itzTz.CaptionWidth = 90;
      this.itzTz.Dock = System.Windows.Forms.DockStyle.Left;
      this.itzTz.Location = new System.Drawing.Point(320, 0);
      this.itzTz.Name = "itzTz";
      this.itzTz.Size = new System.Drawing.Size(288, 28);
      this.itzTz.TabIndex = 2;
      this.itzTz.Value = ((sbyte)(-12));
      this.itzTz.ValueChanged += new System.EventHandler(this.itzTz_ValueChanged);
      // 
      // LocationEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.itzTz);
      this.Controls.Add(this.idLongitude);
      this.Controls.Add(this.idLatitude);
      this.Name = "LocationEditorControl";
      this.Size = new System.Drawing.Size(610, 28);
      this.ResumeLayout(false);

    }

    #endregion

    private InputDoubleControl idLatitude;
    private InputDoubleControl idLongitude;
    private InputTimeZoneControl itzTz;
  }
}
