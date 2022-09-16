namespace Ztp.Ui
{
  partial class ModBusAddItemForm
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
      this.bCancel = new System.Windows.Forms.Button();
      this.bAdd = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.cbCmdNum = new System.Windows.Forms.ComboBox();
      this.nudTagAddr = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.nudIecIndex = new System.Windows.Forms.NumericUpDown();
      this.lblDBZ = new System.Windows.Forms.Label();
      this.nudDBZ = new System.Windows.Forms.NumericUpDown();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.idDevAddr = new Ztp.Ui.InputDoubleControl();
      ((System.ComponentModel.ISupportInitialize)(this.nudTagAddr)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudIecIndex)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudDBZ)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // bCancel
      // 
      this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.bCancel.Location = new System.Drawing.Point(135, 174);
      this.bCancel.Name = "bCancel";
      this.bCancel.Size = new System.Drawing.Size(75, 23);
      this.bCancel.TabIndex = 3;
      this.bCancel.TabStop = false;
      this.bCancel.Text = "Отмена";
      this.bCancel.UseVisualStyleBackColor = true;
      // 
      // bAdd
      // 
      this.bAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.bAdd.Location = new System.Drawing.Point(31, 174);
      this.bAdd.Name = "bAdd";
      this.bAdd.Size = new System.Drawing.Size(75, 23);
      this.bAdd.TabIndex = 4;
      this.bAdd.TabStop = false;
      this.bAdd.Text = "Добавить";
      this.bAdd.UseVisualStyleBackColor = true;
      this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(15, 51);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(90, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "Номер команды";
      // 
      // cbCmdNum
      // 
      this.cbCmdNum.DisplayMember = "0";
      this.cbCmdNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbCmdNum.FormattingEnabled = true;
      this.cbCmdNum.Items.AddRange(new object[] {
            "Цифровой вход",
            "Входной регистр"});
      this.cbCmdNum.Location = new System.Drawing.Point(115, 48);
      this.cbCmdNum.Name = "cbCmdNum";
      this.cbCmdNum.Size = new System.Drawing.Size(110, 21);
      this.cbCmdNum.TabIndex = 6;
      this.cbCmdNum.TabStop = false;
      this.cbCmdNum.ValueMember = "0";
      this.cbCmdNum.SelectedIndexChanged += new System.EventHandler(this.cbCmdNum_SelectedIndexChanged);
      // 
      // nudTagAddr
      // 
      this.nudTagAddr.Hexadecimal = true;
      this.nudTagAddr.Location = new System.Drawing.Point(115, 83);
      this.nudTagAddr.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.nudTagAddr.Name = "nudTagAddr";
      this.nudTagAddr.Size = new System.Drawing.Size(110, 20);
      this.nudTagAddr.TabIndex = 7;
      this.nudTagAddr.TabStop = false;
      this.nudTagAddr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(16, 85);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(91, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "Адрес поля [hex]";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(16, 117);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(80, 13);
      this.label3.TabIndex = 9;
      this.label3.Text = "Индекс iec104";
      // 
      // nudIecIndex
      // 
      this.nudIecIndex.Location = new System.Drawing.Point(115, 115);
      this.nudIecIndex.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.nudIecIndex.Minimum = new decimal(new int[] {
            49,
            0,
            0,
            0});
      this.nudIecIndex.Name = "nudIecIndex";
      this.nudIecIndex.Size = new System.Drawing.Size(110, 20);
      this.nudIecIndex.TabIndex = 10;
      this.nudIecIndex.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
      this.nudIecIndex.ValueChanged += new System.EventHandler(this.nudIecIndex_ValueChanged);
      this.nudIecIndex.Validating += new System.ComponentModel.CancelEventHandler(this.nudIecIndex_Validating);
      // 
      // lblDBZ
      // 
      this.lblDBZ.AutoSize = true;
      this.lblDBZ.Location = new System.Drawing.Point(16, 148);
      this.lblDBZ.Name = "lblDBZ";
      this.lblDBZ.Size = new System.Drawing.Size(94, 13);
      this.lblDBZ.TabIndex = 11;
      this.lblDBZ.Text = "Зона нечувств. %";
      // 
      // nudDBZ
      // 
      this.nudDBZ.Location = new System.Drawing.Point(115, 145);
      this.nudDBZ.Name = "nudDBZ";
      this.nudDBZ.Size = new System.Drawing.Size(110, 20);
      this.nudDBZ.TabIndex = 12;
      this.nudDBZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudDBZ.Validating += new System.ComponentModel.CancelEventHandler(this.nudDBZ_Validating);
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      this.errorProvider1.RightToLeft = true;
      // 
      // idDevAddr
      // 
      this.idDevAddr.Caption = "Адресс устройства";
      this.idDevAddr.CaptionWidth = 100;
      this.idDevAddr.DecimalPlaces = 0;
      this.idDevAddr.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.idDevAddr.Location = new System.Drawing.Point(12, 12);
      this.idDevAddr.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.idDevAddr.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
      this.idDevAddr.Name = "idDevAddr";
      this.idDevAddr.ReadOnly = false;
      this.idDevAddr.Size = new System.Drawing.Size(217, 26);
      this.idDevAddr.TabIndex = 0;
      this.idDevAddr.TabStop = false;
      this.idDevAddr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // ModBusAddItemForm
      // 
      this.AcceptButton = this.bAdd;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.bCancel;
      this.ClientSize = new System.Drawing.Size(237, 206);
      this.ControlBox = false;
      this.Controls.Add(this.nudDBZ);
      this.Controls.Add(this.lblDBZ);
      this.Controls.Add(this.nudIecIndex);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.nudTagAddr);
      this.Controls.Add(this.cbCmdNum);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.bAdd);
      this.Controls.Add(this.bCancel);
      this.Controls.Add(this.idDevAddr);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ModBusAddItemForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Добавление тега в список модбас";
      ((System.ComponentModel.ISupportInitialize)(this.nudTagAddr)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudIecIndex)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudDBZ)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private InputDoubleControl idDevAddr;
    private System.Windows.Forms.Button bCancel;
    private System.Windows.Forms.Button bAdd;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbCmdNum;
    private System.Windows.Forms.NumericUpDown nudTagAddr;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown nudIecIndex;
    private System.Windows.Forms.Label lblDBZ;
    private System.Windows.Forms.NumericUpDown nudDBZ;
    private System.Windows.Forms.ErrorProvider errorProvider1;
  }
}