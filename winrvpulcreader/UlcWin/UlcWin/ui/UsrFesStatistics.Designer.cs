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
      this.roundBorderPanel5 = new UlcWin.ui.RoundBorderPanel();
      this.tblPanelAll = new System.Windows.Forms.TableLayoutPanel();
      this.usrStatAllRvp = new UlcWin.ui.UsrStatComponent();
      this.usrStatAllUlc = new UlcWin.ui.UsrStatComponent();
      this.usrStatAll = new UlcWin.ui.UsrStatComponent();
      this.usrAllPercent = new UlcWin.ui.UsrPercentControl();
      this.label20 = new System.Windows.Forms.Label();
      this.tblResControl = new System.Windows.Forms.TableLayoutPanel();
      this.roundBorderPanel5.SuspendLayout();
      this.tblPanelAll.SuspendLayout();
      this.SuspendLayout();
      // 
      // roundBorderPanel5
      // 
      this.roundBorderPanel5.BackShapeColor = System.Drawing.Color.White;
      this.roundBorderPanel5.Controls.Add(this.tblPanelAll);
      this.roundBorderPanel5.Controls.Add(this.label20);
      this.roundBorderPanel5.Dock = System.Windows.Forms.DockStyle.Top;
      this.roundBorderPanel5.Location = new System.Drawing.Point(0, 0);
      this.roundBorderPanel5.Name = "roundBorderPanel5";
      this.roundBorderPanel5.Padding = new System.Windows.Forms.Padding(10);
      this.roundBorderPanel5.RoundCorner = 5;
      this.roundBorderPanel5.ShapeBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(51)))), ((int)(((byte)(94)))), ((int)(((byte)(129)))));
      this.roundBorderPanel5.ShapeBorderPadding = 5;
      this.roundBorderPanel5.ShapeBorderWitdh = 1;
      this.roundBorderPanel5.Size = new System.Drawing.Size(1250, 153);
      this.roundBorderPanel5.TabIndex = 62;
      this.roundBorderPanel5.Paint += new System.Windows.Forms.PaintEventHandler(this.roundBorderPanel5_Paint);
      // 
      // tblPanelAll
      // 
      this.tblPanelAll.BackColor = System.Drawing.Color.White;
      this.tblPanelAll.ColumnCount = 4;
      this.tblPanelAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
      this.tblPanelAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
      this.tblPanelAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
      this.tblPanelAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
      this.tblPanelAll.Controls.Add(this.usrStatAllRvp, 0, 0);
      this.tblPanelAll.Controls.Add(this.usrStatAllUlc, 0, 0);
      this.tblPanelAll.Controls.Add(this.usrStatAll, 0, 0);
      this.tblPanelAll.Controls.Add(this.usrAllPercent, 3, 0);
      this.tblPanelAll.Dock = System.Windows.Forms.DockStyle.Top;
      this.tblPanelAll.Location = new System.Drawing.Point(10, 42);
      this.tblPanelAll.Margin = new System.Windows.Forms.Padding(5);
      this.tblPanelAll.Name = "tblPanelAll";
      this.tblPanelAll.Padding = new System.Windows.Forms.Padding(2);
      this.tblPanelAll.RowCount = 1;
      this.tblPanelAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tblPanelAll.Size = new System.Drawing.Size(1230, 98);
      this.tblPanelAll.TabIndex = 65;
      // 
      // usrStatAllRvp
      // 
      this.usrStatAllRvp.BackColor = System.Drawing.Color.Transparent;
      this.usrStatAllRvp.Dock = System.Windows.Forms.DockStyle.Fill;
      this.usrStatAllRvp.InitColor = System.Drawing.Color.CornflowerBlue;
      this.usrStatAllRvp.InitFont = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.usrStatAllRvp.Location = new System.Drawing.Point(673, 5);
      this.usrStatAllRvp.Name = "usrStatAllRvp";
      this.usrStatAllRvp.Size = new System.Drawing.Size(328, 88);
      this.usrStatAllRvp.TabIndex = 2;
      // 
      // usrStatAllUlc
      // 
      this.usrStatAllUlc.BackColor = System.Drawing.Color.Transparent;
      this.usrStatAllUlc.Dock = System.Windows.Forms.DockStyle.Fill;
      this.usrStatAllUlc.InitColor = System.Drawing.Color.Teal;
      this.usrStatAllUlc.InitFont = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.usrStatAllUlc.Location = new System.Drawing.Point(339, 5);
      this.usrStatAllUlc.Name = "usrStatAllUlc";
      this.usrStatAllUlc.Size = new System.Drawing.Size(328, 88);
      this.usrStatAllUlc.TabIndex = 1;
      // 
      // usrStatAll
      // 
      this.usrStatAll.BackColor = System.Drawing.Color.Transparent;
      this.usrStatAll.Dock = System.Windows.Forms.DockStyle.Fill;
      this.usrStatAll.InitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.usrStatAll.InitFont = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.usrStatAll.Location = new System.Drawing.Point(5, 5);
      this.usrStatAll.Name = "usrStatAll";
      this.usrStatAll.Size = new System.Drawing.Size(328, 88);
      this.usrStatAll.TabIndex = 0;
      // 
      // usrAllPercent
      // 
      this.usrAllPercent.Dock = System.Windows.Forms.DockStyle.Fill;
      this.usrAllPercent.InitColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
      this.usrAllPercent.Location = new System.Drawing.Point(1007, 5);
      this.usrAllPercent.Name = "usrAllPercent";
      this.usrAllPercent.Size = new System.Drawing.Size(218, 88);
      this.usrAllPercent.TabIndex = 3;
      // 
      // label20
      // 
      this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(196)))), ((int)(((byte)(192)))));
      this.label20.Dock = System.Windows.Forms.DockStyle.Top;
      this.label20.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label20.ForeColor = System.Drawing.Color.White;
      this.label20.Location = new System.Drawing.Point(10, 10);
      this.label20.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
      this.label20.Name = "label20";
      this.label20.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
      this.label20.Size = new System.Drawing.Size(1230, 32);
      this.label20.TabIndex = 64;
      this.label20.Text = "Общая статистика работы контроллеров";
      this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tblResControl
      // 
      this.tblResControl.AutoScroll = true;
      this.tblResControl.BackColor = System.Drawing.SystemColors.Control;
      this.tblResControl.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
      this.tblResControl.ColumnCount = 1;
      this.tblResControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tblResControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tblResControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tblResControl.Location = new System.Drawing.Point(0, 153);
      this.tblResControl.Name = "tblResControl";
      this.tblResControl.Padding = new System.Windows.Forms.Padding(25, 1, 25, 1);
      this.tblResControl.RowCount = 1;
      this.tblResControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tblResControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 361F));
      this.tblResControl.Size = new System.Drawing.Size(1250, 365);
      this.tblResControl.TabIndex = 63;
      // 
      // UsrFesStatistics
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tblResControl);
      this.Controls.Add(this.roundBorderPanel5);
      this.Name = "UsrFesStatistics";
      this.Size = new System.Drawing.Size(1250, 518);
      this.roundBorderPanel5.ResumeLayout(false);
      this.tblPanelAll.ResumeLayout(false);
      this.ResumeLayout(false);

    }

        #endregion

        private RoundBorderPanel roundBorderPanel5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TableLayoutPanel tblPanelAll;
        private System.Windows.Forms.TableLayoutPanel tblResControl;
        private UsrStatComponent usrStatAll;
        private UsrStatComponent usrStatAllRvp;
        private UsrStatComponent usrStatAllUlc;
    private UsrPercentControl usrAllPercent;
  }
}
