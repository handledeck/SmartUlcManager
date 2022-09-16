using System.Windows.Forms;

namespace Ztp.Ui
{
  partial class ConfigEditorControl
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
      Application.Idle -= Application_Idle;
    }

    #region Код, автоматически созданный конструктором компонентов

    /// <summary> 
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.gbEst = new System.Windows.Forms.GroupBox();
      this.itEstTsend = new Ztp.Ui.InputDoubleControl();
      this.itEstPort = new Ztp.Ui.InputDoubleControl();
      this.itEstAddress = new Ztp.Ui.InputTextControl();
      this.cbEstActive = new System.Windows.Forms.CheckBox();
      this.gbCoord = new System.Windows.Forms.GroupBox();
      this.inputTimeZone = new Ztp.Ui.InputTimeZoneControl();
      this.idLongitude = new Ztp.Ui.InputDoubleControl();
      this.idLatitude = new Ztp.Ui.InputDoubleControl();
      this.gbMisc = new System.Windows.Forms.GroupBox();
      this.cbDebug = new System.Windows.Forms.CheckBox();
      this.itDebounce = new Ztp.Ui.InputDoubleControl();
      this.idDbz = new Ztp.Ui.InputDoubleControl();
      this.idNumber = new Ztp.Ui.InputDoubleControl();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.apnEditorControl = new Ztp.Ui.ApnEditorControl();
      this.dinEditor = new Ztp.Ui.DinEditorControl();
      this.doutEditor = new Ztp.Ui.DoutEditorControl();
      this.pnl = new System.Windows.Forms.Panel();
      this.ainEditor = new Ztp.Ui.AinEditorControl();
      this.doorEditor = new Ztp.Ui.DinEditorControl();
      this.gbIec104 = new System.Windows.Forms.GroupBox();
      this.iec104EditorControl = new Ztp.Ui.Iec104EditorControl();
      this.gsmTechn = new Ztp.Ui.GsmTechn();
      this.planResetControl = new Ztp.Ui.PlanResetControl();
      this.pingEditorControl = new Ztp.Ui.PingEditorControl();
      this.logsStateControl = new Ztp.Ui.LogsStateControl();
      this.gbEst.SuspendLayout();
      this.gbCoord.SuspendLayout();
      this.gbMisc.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.pnl.SuspendLayout();
      this.gbIec104.SuspendLayout();
      this.SuspendLayout();
      // 
      // gbEst
      // 
      this.gbEst.Controls.Add(this.itEstTsend);
      this.gbEst.Controls.Add(this.itEstPort);
      this.gbEst.Controls.Add(this.itEstAddress);
      this.gbEst.Controls.Add(this.cbEstActive);
      this.gbEst.Location = new System.Drawing.Point(3, 283);
      this.gbEst.Name = "gbEst";
      this.gbEst.Size = new System.Drawing.Size(350, 120);
      this.gbEst.TabIndex = 1;
      this.gbEst.TabStop = false;
      this.gbEst.Text = "EST Tools";
      // 
      // itEstTsend
      // 
      this.itEstTsend.Caption = "Интервал отправки пустого пакета (сек)";
      this.itEstTsend.CaptionWidth = 150;
      this.itEstTsend.DecimalPlaces = 0;
      this.itEstTsend.Dock = System.Windows.Forms.DockStyle.Top;
      this.itEstTsend.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.itEstTsend.Location = new System.Drawing.Point(3, 85);
      this.itEstTsend.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
      this.itEstTsend.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
      this.itEstTsend.Name = "itEstTsend";
      this.itEstTsend.ReadOnly = false;
      this.itEstTsend.Size = new System.Drawing.Size(344, 26);
      this.itEstTsend.TabIndex = 2;
      this.itEstTsend.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
      // 
      // itEstPort
      // 
      this.itEstPort.Caption = "Порт";
      this.itEstPort.CaptionWidth = 150;
      this.itEstPort.DecimalPlaces = 0;
      this.itEstPort.Dock = System.Windows.Forms.DockStyle.Top;
      this.itEstPort.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.itEstPort.Location = new System.Drawing.Point(3, 59);
      this.itEstPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.itEstPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
      this.itEstPort.Name = "itEstPort";
      this.itEstPort.ReadOnly = false;
      this.itEstPort.Size = new System.Drawing.Size(344, 26);
      this.itEstPort.TabIndex = 1;
      this.itEstPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
      // 
      // itEstAddress
      // 
      this.itEstAddress.Caption = "IP Адрес";
      this.itEstAddress.CaptionWidth = 150;
      this.itEstAddress.Dock = System.Windows.Forms.DockStyle.Top;
      this.itEstAddress.Location = new System.Drawing.Point(3, 33);
      this.itEstAddress.Name = "itEstAddress";
      this.itEstAddress.PasswordChar = '\0';
      this.itEstAddress.ReadOnly = false;
      this.itEstAddress.Size = new System.Drawing.Size(344, 26);
      this.itEstAddress.TabIndex = 0;
      this.itEstAddress.Value = "";
      // 
      // cbEstActive
      // 
      this.cbEstActive.AutoSize = true;
      this.cbEstActive.Dock = System.Windows.Forms.DockStyle.Top;
      this.cbEstActive.Location = new System.Drawing.Point(3, 16);
      this.cbEstActive.Name = "cbEstActive";
      this.cbEstActive.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
      this.cbEstActive.Size = new System.Drawing.Size(344, 17);
      this.cbEstActive.TabIndex = 2;
      this.cbEstActive.Text = "Использовать EST Tools";
      this.cbEstActive.UseVisualStyleBackColor = true;
      // 
      // gbCoord
      // 
      this.gbCoord.Controls.Add(this.inputTimeZone);
      this.gbCoord.Controls.Add(this.idLongitude);
      this.gbCoord.Controls.Add(this.idLatitude);
      this.gbCoord.Location = new System.Drawing.Point(3, 409);
      this.gbCoord.Name = "gbCoord";
      this.gbCoord.Size = new System.Drawing.Size(350, 100);
      this.gbCoord.TabIndex = 3;
      this.gbCoord.TabStop = false;
      this.gbCoord.Text = "Расположение";
      // 
      // inputTimeZone
      // 
      this.inputTimeZone.Caption = "Часовой пояс";
      this.inputTimeZone.CaptionWidth = 150;
      this.inputTimeZone.Dock = System.Windows.Forms.DockStyle.Top;
      this.inputTimeZone.Location = new System.Drawing.Point(3, 68);
      this.inputTimeZone.Name = "inputTimeZone";
      this.inputTimeZone.Size = new System.Drawing.Size(344, 26);
      this.inputTimeZone.TabIndex = 0;
      this.inputTimeZone.Value = ((sbyte)(-12));
      // 
      // idLongitude
      // 
      this.idLongitude.Caption = "Долгота";
      this.idLongitude.CaptionWidth = 150;
      this.idLongitude.DecimalPlaces = 3;
      this.idLongitude.Dock = System.Windows.Forms.DockStyle.Top;
      this.idLongitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idLongitude.Location = new System.Drawing.Point(3, 42);
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
      this.idLongitude.Size = new System.Drawing.Size(344, 26);
      this.idLongitude.TabIndex = 1;
      this.idLongitude.Tag = "";
      this.idLongitude.Value = new decimal(new int[] {
            30125326,
            0,
            0,
            393216});
      // 
      // idLatitude
      // 
      this.idLatitude.Caption = "Широта";
      this.idLatitude.CaptionWidth = 150;
      this.idLatitude.DecimalPlaces = 3;
      this.idLatitude.Dock = System.Windows.Forms.DockStyle.Top;
      this.idLatitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idLatitude.Location = new System.Drawing.Point(3, 16);
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
      this.idLatitude.Size = new System.Drawing.Size(344, 26);
      this.idLatitude.TabIndex = 0;
      this.idLatitude.Value = new decimal(new int[] {
            55191097,
            0,
            0,
            393216});
      // 
      // gbMisc
      // 
      this.gbMisc.Controls.Add(this.cbDebug);
      this.gbMisc.Controls.Add(this.itDebounce);
      this.gbMisc.Controls.Add(this.idDbz);
      this.gbMisc.Controls.Add(this.idNumber);
      this.gbMisc.Location = new System.Drawing.Point(359, 283);
      this.gbMisc.Name = "gbMisc";
      this.gbMisc.Size = new System.Drawing.Size(350, 120);
      this.gbMisc.TabIndex = 4;
      this.gbMisc.TabStop = false;
      this.gbMisc.Text = "Разное";
      // 
      // cbDebug
      // 
      this.cbDebug.AutoSize = true;
      this.cbDebug.Location = new System.Drawing.Point(3, 94);
      this.cbDebug.Name = "cbDebug";
      this.cbDebug.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
      this.cbDebug.Size = new System.Drawing.Size(125, 17);
      this.cbDebug.TabIndex = 3;
      this.cbDebug.Text = "Включить отладку";
      this.cbDebug.UseVisualStyleBackColor = true;
      // 
      // itDebounce
      // 
      this.itDebounce.Caption = "Интервал дребезга (мсек)";
      this.itDebounce.CaptionWidth = 150;
      this.itDebounce.DecimalPlaces = 0;
      this.itDebounce.Dock = System.Windows.Forms.DockStyle.Top;
      this.itDebounce.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.itDebounce.Location = new System.Drawing.Point(3, 68);
      this.itDebounce.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.itDebounce.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.itDebounce.Name = "itDebounce";
      this.itDebounce.ReadOnly = false;
      this.itDebounce.Size = new System.Drawing.Size(344, 26);
      this.itDebounce.TabIndex = 2;
      this.itDebounce.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
      // 
      // idDbz
      // 
      this.idDbz.Caption = "Зона нечувствительности аналоговых входов (%)";
      this.idDbz.CaptionWidth = 150;
      this.idDbz.DecimalPlaces = 0;
      this.idDbz.Dock = System.Windows.Forms.DockStyle.Top;
      this.idDbz.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idDbz.Location = new System.Drawing.Point(3, 42);
      this.idDbz.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.idDbz.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idDbz.Name = "idDbz";
      this.idDbz.ReadOnly = false;
      this.idDbz.Size = new System.Drawing.Size(344, 26);
      this.idDbz.TabIndex = 1;
      this.idDbz.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // idNumber
      // 
      this.idNumber.Caption = "Номер прибора";
      this.idNumber.CaptionWidth = 150;
      this.idNumber.DecimalPlaces = 0;
      this.idNumber.Dock = System.Windows.Forms.DockStyle.Top;
      this.idNumber.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idNumber.Location = new System.Drawing.Point(3, 16);
      this.idNumber.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.idNumber.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
      this.idNumber.Name = "idNumber";
      this.idNumber.ReadOnly = false;
      this.idNumber.Size = new System.Drawing.Size(344, 26);
      this.idNumber.TabIndex = 0;
      this.idNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.AutoScroll = true;
      this.flowLayoutPanel1.AutoSize = true;
      this.flowLayoutPanel1.Controls.Add(this.apnEditorControl);
      this.flowLayoutPanel1.Controls.Add(this.dinEditor);
      this.flowLayoutPanel1.Controls.Add(this.doutEditor);
      this.flowLayoutPanel1.Controls.Add(this.pnl);
      this.flowLayoutPanel1.Controls.Add(this.doorEditor);
      this.flowLayoutPanel1.Controls.Add(this.gbIec104);
      this.flowLayoutPanel1.Controls.Add(this.gbEst);
      this.flowLayoutPanel1.Controls.Add(this.gbMisc);
      this.flowLayoutPanel1.Controls.Add(this.gbCoord);
      this.flowLayoutPanel1.Controls.Add(this.gsmTechn);
      this.flowLayoutPanel1.Controls.Add(this.planResetControl);
      this.flowLayoutPanel1.Controls.Add(this.pingEditorControl);
      this.flowLayoutPanel1.Controls.Add(this.logsStateControl);
      this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(727, 447);
      this.flowLayoutPanel1.TabIndex = 7;
      // 
      // apnEditorControl
      // 
      this.apnEditorControl.ApnAddress = "";
      this.apnEditorControl.ApnPassword = "";
      this.apnEditorControl.ApnUser = "";
      this.apnEditorControl.Location = new System.Drawing.Point(3, 3);
      this.apnEditorControl.Name = "apnEditorControl";
      this.apnEditorControl.Size = new System.Drawing.Size(350, 98);
      this.apnEditorControl.TabIndex = 1;
      // 
      // dinEditor
      // 
      this.dinEditor.Caption = "Активность дискретных входов";
      this.dinEditor.Location = new System.Drawing.Point(359, 3);
      this.dinEditor.MinimumSize = new System.Drawing.Size(336, 58);
      this.dinEditor.Name = "dinEditor";
      this.dinEditor.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
      this.dinEditor.ReadOnly = false;
      this.dinEditor.Size = new System.Drawing.Size(350, 61);
      this.dinEditor.TabIndex = 0;
      this.dinEditor.Value = new bool[] {
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
      this.dinEditor.VisibleItemCount = 16;
      // 
      // doutEditor
      // 
      this.doutEditor.Caption = "Активность дискретных выходов";
      this.doutEditor.Location = new System.Drawing.Point(3, 107);
      this.doutEditor.Name = "doutEditor";
      this.doutEditor.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
      this.doutEditor.ReadOnly = false;
      this.doutEditor.Size = new System.Drawing.Size(350, 40);
      this.doutEditor.TabIndex = 1;
      this.doutEditor.Value = new bool[] {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false};
      this.doutEditor.VisibleItemCount = 8;
      // 
      // pnl
      // 
      this.pnl.Controls.Add(this.ainEditor);
      this.pnl.Location = new System.Drawing.Point(359, 107);
      this.pnl.Name = "pnl";
      this.pnl.Size = new System.Drawing.Size(350, 40);
      this.pnl.TabIndex = 8;
      // 
      // ainEditor
      // 
      this.ainEditor.Caption = "Активность аналоговых входов";
      this.ainEditor.Dock = System.Windows.Forms.DockStyle.Top;
      this.ainEditor.Location = new System.Drawing.Point(0, 0);
      this.ainEditor.Name = "ainEditor";
      this.ainEditor.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
      this.ainEditor.ReadOnly = false;
      this.ainEditor.Size = new System.Drawing.Size(350, 40);
      this.ainEditor.TabIndex = 3;
      this.ainEditor.Value = new bool[] {
        false,
        false,
        false,
        false};
      this.ainEditor.VisibleItemCount = 4;
      // 
      // doorEditor
      // 
      this.doorEditor.Caption = "Активность каналов контроля дверей";
      this.doorEditor.Location = new System.Drawing.Point(3, 153);
      this.doorEditor.MinimumSize = new System.Drawing.Size(336, 58);
      this.doorEditor.Name = "doorEditor";
      this.doorEditor.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
      this.doorEditor.ReadOnly = false;
      this.doorEditor.Size = new System.Drawing.Size(350, 62);
      this.doorEditor.TabIndex = 3;
      this.doorEditor.Value = new bool[] {
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
      this.doorEditor.VisibleItemCount = 16;
      // 
      // gbIec104
      // 
      this.gbIec104.AutoSize = true;
      this.gbIec104.Controls.Add(this.iec104EditorControl);
      this.gbIec104.Location = new System.Drawing.Point(359, 153);
      this.gbIec104.Name = "gbIec104";
      this.gbIec104.Size = new System.Drawing.Size(341, 124);
      this.gbIec104.TabIndex = 6;
      this.gbIec104.TabStop = false;
      this.gbIec104.Text = "МЭК104";
      this.gbIec104.Visible = false;
      // 
      // iec104EditorControl
      // 
      this.iec104EditorControl.Location = new System.Drawing.Point(7, 20);
      this.iec104EditorControl.Name = "iec104EditorControl";
      this.iec104EditorControl.qValue = ((ushort)(3080));
      this.iec104EditorControl.Size = new System.Drawing.Size(328, 85);
      this.iec104EditorControl.TabIndex = 0;
      this.iec104EditorControl.TimeValue = "15;10;20;1";
      // 
      // gsmTechn
      // 
      this.gsmTechn.Location = new System.Drawing.Point(359, 409);
      this.gsmTechn.Name = "gsmTechn";
      this.gsmTechn.Size = new System.Drawing.Size(350, 51);
      this.gsmTechn.TabIndex = 10;
      this.gsmTechn.Techn = ((uint)(1u));
      this.gsmTechn.Visible = false;
      // 
      // planResetControl
      // 
      this.planResetControl.Active = false;
      this.planResetControl.Location = new System.Drawing.Point(3, 515);
      this.planResetControl.Name = "planResetControl";
      this.planResetControl.Size = new System.Drawing.Size(342, 73);
      this.planResetControl.TabIndex = 9;
      this.planResetControl.Value = "";
      this.planResetControl.Visible = false;
      // 
      // pingEditorControl
      // 
      this.pingEditorControl.Ip = "";
      this.pingEditorControl.Location = new System.Drawing.Point(351, 515);
      this.pingEditorControl.Name = "pingEditorControl";
      this.pingEditorControl.Period = ((byte)(1));
      this.pingEditorControl.Size = new System.Drawing.Size(350, 95);
      this.pingEditorControl.TabIndex = 11;
      this.pingEditorControl.Visible = false;
      // 
      // logsStateControl
      // 
      this.logsStateControl.Location = new System.Drawing.Point(3, 616);
      this.logsStateControl.Name = "logsStateControl";
      this.logsStateControl.Size = new System.Drawing.Size(350, 64);
      this.logsStateControl.TabIndex = 12;
      this.logsStateControl.Visible = false;
      // 
      // ConfigEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.flowLayoutPanel1);
      this.Name = "ConfigEditorControl";
      this.Size = new System.Drawing.Size(727, 447);
      this.gbEst.ResumeLayout(false);
      this.gbEst.PerformLayout();
      this.gbCoord.ResumeLayout(false);
      this.gbMisc.ResumeLayout(false);
      this.gbMisc.PerformLayout();
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.PerformLayout();
      this.pnl.ResumeLayout(false);
      this.gbIec104.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.GroupBox gbEst;
    private InputDoubleControl itEstPort;
    private InputTextControl itEstAddress;
    private System.Windows.Forms.CheckBox cbEstActive;
    private InputDoubleControl itEstTsend;
    private GroupBox gbCoord;
    private InputDoubleControl idLongitude;
    private InputDoubleControl idLatitude;
    private DinEditorControl dinEditor;
    private DinEditorControl doorEditor;
    private DoutEditorControl doutEditor;
    private GroupBox gbMisc;
    private CheckBox cbDebug;
    private InputTimeZoneControl inputTimeZone;
    private InputDoubleControl itDebounce;
    private InputDoubleControl idDbz;
    private InputDoubleControl idNumber;
    private FlowLayoutPanel flowLayoutPanel1;
    private Panel pnl;
    private AinEditorControl ainEditor;
    private GroupBox gbIec104;
    private PlanResetControl planResetControl;
    private GsmTechn gsmTechn;
    private Iec104EditorControl iec104EditorControl;
    private PingEditorControl pingEditorControl;
    private ApnEditorControl apnEditorControl;
    private LogsStateControl logsStateControl;
  }
}
