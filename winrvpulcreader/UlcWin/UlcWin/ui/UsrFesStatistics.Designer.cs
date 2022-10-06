namespace UlcWin.ui
{
  partial class UsrFesStatistics
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
      this.tblResControl = new System.Windows.Forms.TableLayoutPanel();
      this.panel1 = new UlcWin.ui.RoundBorderPanel();
      this.usrAllPercent = new UlcWin.ui.UsrPercentControl();
      this.label1 = new System.Windows.Forms.Label();
      this.usrStatAll = new UlcWin.ui.UsrStatComponent();
      this.usrStatAllUlc = new UlcWin.ui.UsrStatComponent();
      this.usrStatAllRvp = new UlcWin.ui.UsrStatComponent();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tblResControl
      // 
      this.tblResControl.AutoScroll = true;
      this.tblResControl.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
      this.tblResControl.ColumnCount = 1;
      this.tblResControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tblResControl.Location = new System.Drawing.Point(3, 169);
      this.tblResControl.Name = "tblResControl";
      this.tblResControl.Padding = new System.Windows.Forms.Padding(25, 5, 25, 1);
      this.tblResControl.RowCount = 1;
      this.tblResControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tblResControl.Size = new System.Drawing.Size(1172, 340);
      this.tblResControl.TabIndex = 5;
      // 
      // panel1
      // 
      this.panel1.AutoScroll = true;
      this.panel1.BackShapeColor = System.Drawing.Color.White;
      this.panel1.Controls.Add(this.usrAllPercent);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.usrStatAll);
      this.panel1.Controls.Add(this.usrStatAllUlc);
      this.panel1.Controls.Add(this.usrStatAllRvp);
      this.panel1.Location = new System.Drawing.Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.RoundCorner = 5;
      this.panel1.ShapeBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(51)))), ((int)(((byte)(94)))), ((int)(((byte)(129)))));
      this.panel1.ShapeBorderPadding = 3;
      this.panel1.ShapeBorderWitdh = 1;
      this.panel1.Size = new System.Drawing.Size(1172, 160);
      this.panel1.TabIndex = 4;
      // 
      // usrAllPercent
      // 
      this.usrAllPercent.InitColor = System.Drawing.Color.Black;
      this.usrAllPercent.Location = new System.Drawing.Point(928, 50);
      this.usrAllPercent.Name = "usrAllPercent";
      this.usrAllPercent.Size = new System.Drawing.Size(226, 98);
      this.usrAllPercent.TabIndex = 5;
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(196)))), ((int)(((byte)(192)))));
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(16, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(1138, 34);
      this.label1.TabIndex = 4;
      this.label1.Text = "Общая статистика работы контроллеров";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // usrStatAll
      // 
      this.usrStatAll.BackColor = System.Drawing.Color.Transparent;
      this.usrStatAll.InitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.usrStatAll.InitFont = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.usrStatAll.Location = new System.Drawing.Point(16, 50);
      this.usrStatAll.MinimumSize = new System.Drawing.Size(280, 90);
      this.usrStatAll.Name = "usrStatAll";
      this.usrStatAll.Size = new System.Drawing.Size(299, 98);
      this.usrStatAll.TabIndex = 0;
      // 
      // usrStatAllUlc
      // 
      this.usrStatAllUlc.BackColor = System.Drawing.Color.Transparent;
      this.usrStatAllUlc.InitColor = System.Drawing.Color.Teal;
      this.usrStatAllUlc.InitFont = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.usrStatAllUlc.Location = new System.Drawing.Point(321, 50);
      this.usrStatAllUlc.MinimumSize = new System.Drawing.Size(280, 90);
      this.usrStatAllUlc.Name = "usrStatAllUlc";
      this.usrStatAllUlc.Size = new System.Drawing.Size(301, 98);
      this.usrStatAllUlc.TabIndex = 1;
      // 
      // usrStatAllRvp
      // 
      this.usrStatAllRvp.BackColor = System.Drawing.Color.Transparent;
      this.usrStatAllRvp.InitColor = System.Drawing.Color.DodgerBlue;
      this.usrStatAllRvp.InitFont = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.usrStatAllRvp.Location = new System.Drawing.Point(628, 50);
      this.usrStatAllRvp.MinimumSize = new System.Drawing.Size(280, 90);
      this.usrStatAllRvp.Name = "usrStatAllRvp";
      this.usrStatAllRvp.Size = new System.Drawing.Size(294, 98);
      this.usrStatAllRvp.TabIndex = 2;
      // 
      // UsrFesStatistics
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.Controls.Add(this.tblResControl);
      this.Controls.Add(this.panel1);
      this.Name = "UsrFesStatistics";
      this.Size = new System.Drawing.Size(1178, 512);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private UsrStatComponent usrStatAllRvp;
    private UsrStatComponent usrStatAllUlc;
    private UsrStatComponent usrStatAll;
    private RoundBorderPanel panel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TableLayoutPanel tblResControl;
    private UsrPercentControl usrAllPercent;
  }
}
