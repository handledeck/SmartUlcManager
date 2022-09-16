namespace Ztp.Ui
{
  partial class LightPlanEditorControl
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
      Ztp.Ui.LocationEditorControl.ZtpLocation ztpLocation1 = new Ztp.Ui.LocationEditorControl.ZtpLocation();
      this.seasonEditor = new Ztp.Ui.SeasonEditorControl();
      this.scheduleListEditor = new Ztp.Ui.ScheduleListEditorControl();
      this.useSchedulerControl = new Ztp.Ui.UseSchedulerControl();
      this.SuspendLayout();
      // 
      // seasonEditor
      // 
      this.seasonEditor.Dock = System.Windows.Forms.DockStyle.Top;
      this.seasonEditor.Location = new System.Drawing.Point(0, 24);
      this.seasonEditor.Name = "seasonEditor";
      this.seasonEditor.Size = new System.Drawing.Size(416, 156);
      this.seasonEditor.TabIndex = 0;
      this.seasonEditor.Value = null;
      // 
      // scheduleListEditor
      // 
      this.scheduleListEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.scheduleListEditor.Location = new System.Drawing.Point(0, 180);
      this.scheduleListEditor.Name = "scheduleListEditor";
      this.scheduleListEditor.Season = null;
      this.scheduleListEditor.Size = new System.Drawing.Size(416, 202);
      this.scheduleListEditor.TabIndex = 1;
      this.scheduleListEditor.Value = null;
      ztpLocation1.Latitude = 0F;
      ztpLocation1.Longitude = 0F;
      ztpLocation1.TimeZone = ((sbyte)(0));
      this.scheduleListEditor.ZtpLocation = ztpLocation1;
      // 
      // useSchedulerControl
      // 
      this.useSchedulerControl.Dock = System.Windows.Forms.DockStyle.Top;
      this.useSchedulerControl.Location = new System.Drawing.Point(0, 0);
      this.useSchedulerControl.Margin = new System.Windows.Forms.Padding(6);
      this.useSchedulerControl.Name = "useSchedulerControl";
      this.useSchedulerControl.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
      this.useSchedulerControl.Size = new System.Drawing.Size(416, 24);
      this.useSchedulerControl.TabIndex = 2;
      this.useSchedulerControl.UseScheduler = false;
      // 
      // LightPlanEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.scheduleListEditor);
      this.Controls.Add(this.seasonEditor);
      this.Controls.Add(this.useSchedulerControl);
      this.Name = "LightPlanEditorControl";
      this.Size = new System.Drawing.Size(416, 382);
      this.ResumeLayout(false);

    }

    #endregion

    private SeasonEditorControl seasonEditor;
    private ScheduleListEditorControl scheduleListEditor;
    private UseSchedulerControl useSchedulerControl;
  }
}
