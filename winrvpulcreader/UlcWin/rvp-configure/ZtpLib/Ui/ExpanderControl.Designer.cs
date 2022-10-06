namespace Ztp.Ui
{
  partial class ExpanderControl
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
      this.pnlHeader = new System.Windows.Forms.Panel();
      this.cbHeader = new System.Windows.Forms.CheckBox();
      this.pnlContent = new System.Windows.Forms.Panel();
      this.pnlHeader.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlHeader
      // 
      this.pnlHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.pnlHeader.Controls.Add(this.cbHeader);
      this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlHeader.Location = new System.Drawing.Point(0, 0);
      this.pnlHeader.Name = "pnlHeader";
      this.pnlHeader.Size = new System.Drawing.Size(503, 26);
      this.pnlHeader.TabIndex = 0;
      // 
      // cbHeader
      // 
      this.cbHeader.Checked = true;
      this.cbHeader.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbHeader.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.cbHeader.Location = new System.Drawing.Point(0, 0);
      this.cbHeader.Name = "cbHeader";
      this.cbHeader.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
      this.cbHeader.Size = new System.Drawing.Size(503, 26);
      this.cbHeader.TabIndex = 0;
      this.cbHeader.Text = "Header";
      this.cbHeader.UseVisualStyleBackColor = true;
      // 
      // pnlContent
      // 
      this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlContent.Location = new System.Drawing.Point(0, 26);
      this.pnlContent.Name = "pnlContent";
      this.pnlContent.Size = new System.Drawing.Size(503, 134);
      this.pnlContent.TabIndex = 1;
      // 
      // ExpanderControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.Controls.Add(this.pnlContent);
      this.Controls.Add(this.pnlHeader);
      this.Name = "ExpanderControl";
      this.Size = new System.Drawing.Size(503, 160);
      this.pnlHeader.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.CheckBox cbHeader;
    private System.Windows.Forms.Panel pnlContent;
  }
}
