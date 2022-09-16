namespace Ztp.Ui
{
  partial class ScheduleForm
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
      this.cbRelEnd = new System.Windows.Forms.ComboBox();
      this.dtpRelEnd = new System.Windows.Forms.DateTimePicker();
      this.label4 = new System.Windows.Forms.Label();
      this.cbRelBegin = new System.Windows.Forms.ComboBox();
      this.dtpRelBegin = new System.Windows.Forms.DateTimePicker();
      this.label1 = new System.Windows.Forms.Label();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // cbRelEnd
      // 
      this.cbRelEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbRelEnd.FormattingEnabled = true;
      this.cbRelEnd.Location = new System.Drawing.Point(103, 51);
      this.cbRelEnd.Name = "cbRelEnd";
      this.cbRelEnd.Size = new System.Drawing.Size(185, 21);
      this.cbRelEnd.TabIndex = 8;
      this.cbRelEnd.SelectedIndexChanged += new System.EventHandler(this.cbRelEnd_SelectedIndexChanged);
      // 
      // dtpRelEnd
      // 
      this.dtpRelEnd.CustomFormat = "HH:mm";
      this.dtpRelEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpRelEnd.Location = new System.Drawing.Point(297, 52);
      this.dtpRelEnd.Name = "dtpRelEnd";
      this.dtpRelEnd.ShowUpDown = true;
      this.dtpRelEnd.Size = new System.Drawing.Size(72, 20);
      this.dtpRelEnd.TabIndex = 7;
      this.dtpRelEnd.Validated += new System.EventHandler(this.dtpRelEnd_Validated);
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(27, 59);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(70, 23);
      this.label4.TabIndex = 5;
      this.label4.Text = "Выключить";
      // 
      // cbRelBegin
      // 
      this.cbRelBegin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbRelBegin.FormattingEnabled = true;
      this.cbRelBegin.Location = new System.Drawing.Point(103, 17);
      this.cbRelBegin.Name = "cbRelBegin";
      this.cbRelBegin.Size = new System.Drawing.Size(185, 21);
      this.cbRelBegin.TabIndex = 4;
      this.cbRelBegin.SelectedIndexChanged += new System.EventHandler(this.cbRelBegin_SelectedIndexChanged);
      // 
      // dtpRelBegin
      // 
      this.dtpRelBegin.CustomFormat = "HH:mm";
      this.dtpRelBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpRelBegin.Location = new System.Drawing.Point(297, 18);
      this.dtpRelBegin.Name = "dtpRelBegin";
      this.dtpRelBegin.ShowUpDown = true;
      this.dtpRelBegin.Size = new System.Drawing.Size(72, 20);
      this.dtpRelBegin.TabIndex = 3;
      this.dtpRelBegin.Validated += new System.EventHandler(this.dtpRelBegin_Validated);
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(27, 25);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(70, 23);
      this.label1.TabIndex = 1;
      this.label1.Text = "Включить";
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(213, 95);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 1;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(294, 95);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // ScheduleForm
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(389, 130);
      this.Controls.Add(this.cbRelEnd);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.dtpRelEnd);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.cbRelBegin);
      this.Controls.Add(this.dtpRelBegin);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ScheduleForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Расписание";
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.ComboBox cbRelEnd;
    private System.Windows.Forms.DateTimePicker dtpRelEnd;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox cbRelBegin;
    private System.Windows.Forms.DateTimePicker dtpRelBegin;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
  }
}