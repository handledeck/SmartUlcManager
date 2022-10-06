namespace UlcWin.test
{
  partial class UserControl1
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.usrStatComponent1 = new UlcWin.ui.UsrStatComponent();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoScroll = true;
      this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.Controls.Add(this.usrStatComponent1, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(916, 100);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1203, 186);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // usrStatComponent1
      // 
      this.usrStatComponent1.AutoScroll = true;
      this.usrStatComponent1.BackColor = System.Drawing.Color.Transparent;
      this.usrStatComponent1.InitColor = System.Drawing.Color.Black;
      this.usrStatComponent1.InitFont = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.usrStatComponent1.Location = new System.Drawing.Point(5, 5);
      this.usrStatComponent1.Name = "usrStatComponent1";
      this.usrStatComponent1.Size = new System.Drawing.Size(292, 176);
      this.usrStatComponent1.TabIndex = 0;
      // 
      // UserControl1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "UserControl1";
      this.Size = new System.Drawing.Size(1203, 468);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ui.UsrStatComponent usrStatComponent1;
    }
}
