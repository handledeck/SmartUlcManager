namespace Ztp.Ui
{
  partial class SeasonForm
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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.cbMonthBegin = new System.Windows.Forms.ComboBox();
      this.cbDayBegin = new System.Windows.Forms.ComboBox();
      this.cbDayEnd = new System.Windows.Forms.ComboBox();
      this.cbMonthEnd = new System.Windows.Forms.ComboBox();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(83, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Начало сезона";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(11, 50);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(101, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Окончание сезона";
      // 
      // cbMonthBegin
      // 
      this.cbMonthBegin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbMonthBegin.FormattingEnabled = true;
      this.cbMonthBegin.Location = new System.Drawing.Point(15, 26);
      this.cbMonthBegin.Name = "cbMonthBegin";
      this.cbMonthBegin.Size = new System.Drawing.Size(147, 21);
      this.cbMonthBegin.TabIndex = 2;
      this.cbMonthBegin.SelectedIndexChanged += new System.EventHandler(this.cbMonthBegin_SelectedIndexChanged);
      // 
      // cbDayBegin
      // 
      this.cbDayBegin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbDayBegin.FormattingEnabled = true;
      this.cbDayBegin.Location = new System.Drawing.Point(169, 25);
      this.cbDayBegin.Name = "cbDayBegin";
      this.cbDayBegin.Size = new System.Drawing.Size(95, 21);
      this.cbDayBegin.TabIndex = 3;
      this.cbDayBegin.SelectedIndexChanged += new System.EventHandler(this.cbDayBegin_SelectedIndexChanged);
      // 
      // cbDayEnd
      // 
      this.cbDayEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbDayEnd.FormattingEnabled = true;
      this.cbDayEnd.Location = new System.Drawing.Point(168, 65);
      this.cbDayEnd.Name = "cbDayEnd";
      this.cbDayEnd.Size = new System.Drawing.Size(95, 21);
      this.cbDayEnd.TabIndex = 5;
      this.cbDayEnd.SelectedIndexChanged += new System.EventHandler(this.cbDayEnd_SelectedIndexChanged);
      // 
      // cbMonthEnd
      // 
      this.cbMonthEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbMonthEnd.FormattingEnabled = true;
      this.cbMonthEnd.Location = new System.Drawing.Point(14, 66);
      this.cbMonthEnd.Name = "cbMonthEnd";
      this.cbMonthEnd.Size = new System.Drawing.Size(147, 21);
      this.cbMonthEnd.TabIndex = 4;
      this.cbMonthEnd.SelectedIndexChanged += new System.EventHandler(this.cbMonthEnd_SelectedIndexChanged);
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(107, 104);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 6;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(188, 104);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 7;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // SeasonForm
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(279, 142);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.cbDayEnd);
      this.Controls.Add(this.cbMonthEnd);
      this.Controls.Add(this.cbDayBegin);
      this.Controls.Add(this.cbMonthBegin);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SeasonForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Сезон";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbMonthBegin;
    private System.Windows.Forms.ComboBox cbDayBegin;
    private System.Windows.Forms.ComboBox cbDayEnd;
    private System.Windows.Forms.ComboBox cbMonthEnd;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
  }
}