namespace Ztp.Ui
{
  partial class ModBusSettingsEditorControl
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
      this.components = new System.ComponentModel.Container();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.pModBusitems = new System.Windows.Forms.Panel();
      this.bMBLoad = new System.Windows.Forms.Button();
      this.bUpload = new System.Windows.Forms.Button();
      this.bMBSave = new System.Windows.Forms.Button();
      this.bLoadMB = new System.Windows.Forms.Button();
      this.idPollPeriod = new Ztp.Ui.InputDoubleControl();
      this.cbWorkMode = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.ofd = new System.Windows.Forms.OpenFileDialog();
      this.sfd = new System.Windows.Forms.SaveFileDialog();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.groupBox1.SuspendLayout();
      this.pModBusitems.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.pModBusitems);
      this.groupBox1.Controls.Add(this.cbWorkMode);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(433, 143);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Дополнительная настройка последовательного канала";
      // 
      // pModBusitems
      // 
      this.pModBusitems.Controls.Add(this.bMBLoad);
      this.pModBusitems.Controls.Add(this.bUpload);
      this.pModBusitems.Controls.Add(this.bMBSave);
      this.pModBusitems.Controls.Add(this.bLoadMB);
      this.pModBusitems.Controls.Add(this.idPollPeriod);
      this.pModBusitems.Location = new System.Drawing.Point(3, 48);
      this.pModBusitems.Name = "pModBusitems";
      this.pModBusitems.Size = new System.Drawing.Size(427, 92);
      this.pModBusitems.TabIndex = 6;
      this.pModBusitems.Visible = false;
      // 
      // bMBLoad
      // 
      this.bMBLoad.Image = global::Ztp.Properties.Resources.folder_out;
      this.bMBLoad.Location = new System.Drawing.Point(6, 43);
      this.bMBLoad.Name = "bMBLoad";
      this.bMBLoad.Size = new System.Drawing.Size(23, 23);
      this.bMBLoad.TabIndex = 7;
      this.toolTip.SetToolTip(this.bMBLoad, "загрузить конфигурацию тегов Modbus");
      this.bMBLoad.UseVisualStyleBackColor = true;
      this.bMBLoad.Click += new System.EventHandler(this.bMBLoad_Click);
      // 
      // bUpload
      // 
      this.bUpload.Location = new System.Drawing.Point(149, 32);
      this.bUpload.Name = "bUpload";
      this.bUpload.Size = new System.Drawing.Size(275, 23);
      this.bUpload.TabIndex = 5;
      this.bUpload.Text = "Загрузить список тегов модбас в устройство";
      this.bUpload.UseVisualStyleBackColor = true;
      this.bUpload.Click += new System.EventHandler(this.bUpload_Click);
      // 
      // bMBSave
      // 
      this.bMBSave.Image = global::Ztp.Properties.Resources.disk_blue;
      this.bMBSave.Location = new System.Drawing.Point(35, 43);
      this.bMBSave.Name = "bMBSave";
      this.bMBSave.Size = new System.Drawing.Size(23, 23);
      this.bMBSave.TabIndex = 8;
      this.toolTip.SetToolTip(this.bMBSave, "Сохранить конфигурацию тегов Modbus");
      this.bMBSave.UseVisualStyleBackColor = true;
      this.bMBSave.Click += new System.EventHandler(this.bMBSave_Click);
      // 
      // bLoadMB
      // 
      this.bLoadMB.Location = new System.Drawing.Point(149, 3);
      this.bLoadMB.Name = "bLoadMB";
      this.bLoadMB.Size = new System.Drawing.Size(275, 23);
      this.bLoadMB.TabIndex = 9;
      this.bLoadMB.Text = "Прочитать список тегов с устройства";
      this.bLoadMB.UseVisualStyleBackColor = true;
      this.bLoadMB.Click += new System.EventHandler(this.bLoadMB_Click);
      // 
      // idPollPeriod
      // 
      this.idPollPeriod.Caption = "Период опроса, секунд";
      this.idPollPeriod.CaptionWidth = 213;
      this.idPollPeriod.DecimalPlaces = 0;
      this.idPollPeriod.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idPollPeriod.Location = new System.Drawing.Point(-1, 63);
      this.idPollPeriod.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.idPollPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idPollPeriod.Name = "idPollPeriod";
      this.idPollPeriod.ReadOnly = false;
      this.idPollPeriod.Size = new System.Drawing.Size(425, 26);
      this.idPollPeriod.TabIndex = 6;
      this.idPollPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // cbWorkMode
      // 
      this.cbWorkMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbWorkMode.FormattingEnabled = true;
      this.cbWorkMode.IntegralHeight = false;
      this.cbWorkMode.Items.AddRange(new object[] {
            "Сквозной канал",
            "С опросом Modbus RTU"});
      this.cbWorkMode.Location = new System.Drawing.Point(152, 21);
      this.cbWorkMode.Name = "cbWorkMode";
      this.cbWorkMode.Size = new System.Drawing.Size(275, 21);
      this.cbWorkMode.TabIndex = 1;
      this.cbWorkMode.TabStop = false;
      this.cbWorkMode.SelectedIndexChanged += new System.EventHandler(this.cbWorkMode_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(121, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Режим работы канала";
      // 
      // ofd
      // 
      this.ofd.FileName = "openFileDialog1";
      // 
      // ModBusSettingsEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox1);
      this.Name = "ModBusSettingsEditorControl";
      this.Size = new System.Drawing.Size(433, 143);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.pModBusitems.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel pModBusitems;
    private System.Windows.Forms.Button bUpload;
    private System.Windows.Forms.Button bMBSave;
    private System.Windows.Forms.Button bMBLoad;
    private System.Windows.Forms.OpenFileDialog ofd;
    private System.Windows.Forms.SaveFileDialog sfd;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.Button bLoadMB;
    public System.Windows.Forms.ComboBox cbWorkMode;
    public InputDoubleControl idPollPeriod;
  }
}
