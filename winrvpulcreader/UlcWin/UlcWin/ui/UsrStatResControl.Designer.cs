namespace UlcWin.ui
{
  partial class UsrStatResControl
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
      this.lblHeader = new System.Windows.Forms.Label();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.SuspendLayout();
      // 
      // lblHeader
      // 
      this.lblHeader.BackColor = System.Drawing.Color.LightSteelBlue;
      this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblHeader.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblHeader.ForeColor = System.Drawing.Color.White;
      this.lblHeader.Location = new System.Drawing.Point(0, 0);
      this.lblHeader.Margin = new System.Windows.Forms.Padding(50);
      this.lblHeader.Name = "lblHeader";
      this.lblHeader.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
      this.lblHeader.Size = new System.Drawing.Size(912, 26);
      this.lblHeader.TabIndex = 1;
      this.lblHeader.Text = "Добавить имяобъекта";
      this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.55102F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.55102F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.55102F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.34694F));
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 26);
      this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(30);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(912, 102);
      this.tableLayoutPanel1.TabIndex = 2;
      // 
      // UsrStatResControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Controls.Add(this.lblHeader);
      this.Name = "UsrStatResControl";
      this.Size = new System.Drawing.Size(912, 129);
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
