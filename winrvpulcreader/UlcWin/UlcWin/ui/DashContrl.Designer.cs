using System.Windows.Forms;

namespace UlcWin.ui
{
  partial class DashContrl
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblHeader = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.lblComment = new System.Windows.Forms.Label();
      this.panel3 = new System.Windows.Forms.Panel();
      this.lblValue = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.lblHeader);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Padding = new System.Windows.Forms.Padding(5);
      this.panel1.Size = new System.Drawing.Size(294, 30);
      this.panel1.TabIndex = 0;
      this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
      // 
      // lblHeader
      // 
      this.lblHeader.BackColor = System.Drawing.SystemColors.Window;
      this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblHeader.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblHeader.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.lblHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.lblHeader.Location = new System.Drawing.Point(5, 5);
      this.lblHeader.Name = "lblHeader";
      this.lblHeader.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
      this.lblHeader.Size = new System.Drawing.Size(284, 20);
      this.lblHeader.TabIndex = 1;
      this.lblHeader.Text = "header";
      this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.lblComment);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(3, 140);
      this.panel2.Name = "panel2";
      this.panel2.Padding = new System.Windows.Forms.Padding(5);
      this.panel2.Size = new System.Drawing.Size(294, 30);
      this.panel2.TabIndex = 1;
      this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
      // 
      // lblComment
      // 
      this.lblComment.BackColor = System.Drawing.SystemColors.Control;
      this.lblComment.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblComment.ForeColor = System.Drawing.SystemColors.ControlText;
      this.lblComment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.lblComment.Location = new System.Drawing.Point(5, 5);
      this.lblComment.Name = "lblComment";
      this.lblComment.Padding = new System.Windows.Forms.Padding(2);
      this.lblComment.Size = new System.Drawing.Size(284, 20);
      this.lblComment.TabIndex = 0;
      this.lblComment.Text = "label2";
      this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // panel3
      // 
      this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.panel3.Controls.Add(this.lblValue);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Location = new System.Drawing.Point(3, 33);
      this.panel3.Margin = new System.Windows.Forms.Padding(0);
      this.panel3.Name = "panel3";
      this.panel3.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
      this.panel3.Size = new System.Drawing.Size(294, 107);
      this.panel3.TabIndex = 2;
      this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
      // 
      // lblValue
      // 
      this.lblValue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblValue.Font = new System.Drawing.Font("Verdana", 36F);
      this.lblValue.Location = new System.Drawing.Point(1, 0);
      this.lblValue.Margin = new System.Windows.Forms.Padding(0);
      this.lblValue.Name = "lblValue";
      this.lblValue.Padding = new System.Windows.Forms.Padding(5);
      this.lblValue.Size = new System.Drawing.Size(292, 107);
      this.lblValue.TabIndex = 0;
      this.lblValue.Text = "label1";
      this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // DashContrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Font = new System.Drawing.Font("Verdana", 8.25F);
      this.Margin = new System.Windows.Forms.Padding(10);
      this.MaximumSize = new System.Drawing.Size(500, 173);
      this.MinimumSize = new System.Drawing.Size(300, 173);
      this.Name = "DashContrl";
      this.Padding = new System.Windows.Forms.Padding(3);
      this.Size = new System.Drawing.Size(300, 173);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Panel panel1;
    private Panel panel2;
    private Panel panel3;
    private Label lblValue;
    private Label lblComment;
    private Label lblHeader;
  }
}

