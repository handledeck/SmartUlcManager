using UlcWin.DB;
using UlcWin.ui;

namespace GraphStatic
{
  partial class UsrUlcChartCtrl
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
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnMonthViewClose = new System.Windows.Forms.Button();
      this.btnMonthExport = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.monthPicker1 = new UlcWin.ui.MonthPicker();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.currenttimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.allDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.allrvpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.allulcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.neterrorallDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.allrserrorrsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.allerrorgsmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.neterrorulcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ulcrserrorrsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ulcerrorgsmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.neterrorrvpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.rvprserrorrsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.rvperrorgsmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.percentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ulcSmalllStatisticBindingSource = new System.Windows.Forms.BindingSource(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
      this.panel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ulcSmalllStatisticBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
      this.splitContainer1.Size = new System.Drawing.Size(933, 595);
      this.splitContainer1.SplitterDistance = 289;
      this.splitContainer1.TabIndex = 1;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.40141F));
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(933, 289);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // tableLayoutPanel3
      // 
      this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
      this.tableLayoutPanel3.ColumnCount = 2;
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
      this.tableLayoutPanel3.Controls.Add(this.chart1, 0, 0);
      this.tableLayoutPanel3.Controls.Add(this.panel1, 1, 0);
      this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 5);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 1;
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.Size = new System.Drawing.Size(923, 279);
      this.tableLayoutPanel3.TabIndex = 0;
      // 
      // chart1
      // 
      chartArea1.AxisX.TitleFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      chartArea1.Name = "ChartArea1";
      this.chart1.ChartAreas.Add(chartArea1);
      this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
      legend1.BorderWidth = 5;
      legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
      legend1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      legend1.IsTextAutoFit = false;
      legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
      legend1.Name = "Legend1";
      this.chart1.Legends.Add(legend1);
      this.chart1.Location = new System.Drawing.Point(5, 5);
      this.chart1.Name = "chart1";
      series1.ChartArea = "ChartArea1";
      series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      series1.IsValueShownAsLabel = true;
      series1.Legend = "Legend1";
      series1.LegendText = "Нет связи GSM";
      series1.Name = "Series1";
      series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
      series2.ChartArea = "ChartArea1";
      series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series2.Color = System.Drawing.Color.Teal;
      series2.Legend = "Legend1";
      series2.LegendText = "Нет связи по RS-485";
      series2.MarkerBorderWidth = 3;
      series2.Name = "Series2";
      series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
      series3.ChartArea = "ChartArea1";
      series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series3.Color = System.Drawing.Color.DodgerBlue;
      series3.Legend = "Legend1";
      series3.LegendText = "Неустойчивая связь ";
      series3.Name = "Series3";
      series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
      this.chart1.Series.Add(series1);
      this.chart1.Series.Add(series2);
      this.chart1.Series.Add(series3);
      this.chart1.Size = new System.Drawing.Size(711, 269);
      this.chart1.TabIndex = 0;
      this.chart1.Text = "chart1";
      title1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      title1.Name = "Title1";
      title1.Text = "Статистика работы контроллеров";
      this.chart1.Titles.Add(title1);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnMonthViewClose);
      this.panel1.Controls.Add(this.btnMonthExport);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.monthPicker1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(724, 5);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(194, 269);
      this.panel1.TabIndex = 1;
      // 
      // btnMonthViewClose
      // 
      this.btnMonthViewClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnMonthViewClose.Location = new System.Drawing.Point(107, 227);
      this.btnMonthViewClose.Name = "btnMonthViewClose";
      this.btnMonthViewClose.Size = new System.Drawing.Size(79, 27);
      this.btnMonthViewClose.TabIndex = 4;
      this.btnMonthViewClose.Text = "Закрыть";
      this.btnMonthViewClose.UseVisualStyleBackColor = true;
      this.btnMonthViewClose.Click += new System.EventHandler(this.btnMonthViewClose_Click);
      // 
      // btnMonthExport
      // 
      this.btnMonthExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnMonthExport.Image = global::UlcWin.Properties.Resources.excel_exports;
      this.btnMonthExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnMonthExport.Location = new System.Drawing.Point(22, 227);
      this.btnMonthExport.Name = "btnMonthExport";
      this.btnMonthExport.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
      this.btnMonthExport.Size = new System.Drawing.Size(79, 27);
      this.btnMonthExport.TabIndex = 3;
      this.btnMonthExport.Text = "Экспорт";
      this.btnMonthExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnMonthExport.UseVisualStyleBackColor = true;
      this.btnMonthExport.Click += new System.EventHandler(this.button1_Click);
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(60, 82);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(0, 42);
      this.label2.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(18, 55);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(146, 14);
      this.label1.TabIndex = 1;
      this.label1.Text = "Отклонение за месяц";
      // 
      // monthPicker1
      // 
      this.monthPicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.monthPicker1.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.monthPicker1.CustomFormat = "MMMM yyyy";
      this.monthPicker1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.monthPicker1.Location = new System.Drawing.Point(13, 15);
      this.monthPicker1.Name = "monthPicker1";
      this.monthPicker1.Size = new System.Drawing.Size(165, 21);
      this.monthPicker1.TabIndex = 0;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
      this.tableLayoutPanel2.ColumnCount = 1;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 0, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(933, 302);
      this.tableLayoutPanel2.TabIndex = 0;
      // 
      // dataGridView1
      // 
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
      this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.currenttimeDataGridViewTextBoxColumn,
            this.allDataGridViewTextBoxColumn,
            this.allrvpDataGridViewTextBoxColumn,
            this.allulcDataGridViewTextBoxColumn,
            this.neterrorallDataGridViewTextBoxColumn,
            this.allrserrorrsDataGridViewTextBoxColumn,
            this.allerrorgsmDataGridViewTextBoxColumn,
            this.neterrorulcDataGridViewTextBoxColumn,
            this.ulcrserrorrsDataGridViewTextBoxColumn,
            this.ulcerrorgsmDataGridViewTextBoxColumn,
            this.neterrorrvpDataGridViewTextBoxColumn,
            this.rvprserrorrsDataGridViewTextBoxColumn,
            this.rvperrorgsmDataGridViewTextBoxColumn,
            this.percentDataGridViewTextBoxColumn});
      this.dataGridView1.DataSource = this.ulcSmalllStatisticBindingSource;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(7, 7);
      this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
      this.dataGridView1.Name = "dataGridView1";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
      this.dataGridView1.Size = new System.Drawing.Size(919, 288);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
      this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView1_DataBindingComplete);
      // 
      // currenttimeDataGridViewTextBoxColumn
      // 
      this.currenttimeDataGridViewTextBoxColumn.DataPropertyName = "current_time";
      this.currenttimeDataGridViewTextBoxColumn.HeaderText = "Дата и время";
      this.currenttimeDataGridViewTextBoxColumn.Name = "currenttimeDataGridViewTextBoxColumn";
      // 
      // allDataGridViewTextBoxColumn
      // 
      this.allDataGridViewTextBoxColumn.DataPropertyName = "all";
      this.allDataGridViewTextBoxColumn.HeaderText = "Все котроллеры";
      this.allDataGridViewTextBoxColumn.Name = "allDataGridViewTextBoxColumn";
      // 
      // allrvpDataGridViewTextBoxColumn
      // 
      this.allrvpDataGridViewTextBoxColumn.DataPropertyName = "allrvp";
      this.allrvpDataGridViewTextBoxColumn.HeaderText = "РВП";
      this.allrvpDataGridViewTextBoxColumn.Name = "allrvpDataGridViewTextBoxColumn";
      // 
      // allulcDataGridViewTextBoxColumn
      // 
      this.allulcDataGridViewTextBoxColumn.DataPropertyName = "allulc";
      this.allulcDataGridViewTextBoxColumn.HeaderText = "ULC";
      this.allulcDataGridViewTextBoxColumn.Name = "allulcDataGridViewTextBoxColumn";
      // 
      // neterrorallDataGridViewTextBoxColumn
      // 
      this.neterrorallDataGridViewTextBoxColumn.DataPropertyName = "neterrorall";
      this.neterrorallDataGridViewTextBoxColumn.HeaderText = "Нет связи";
      this.neterrorallDataGridViewTextBoxColumn.Name = "neterrorallDataGridViewTextBoxColumn";
      // 
      // allrserrorrsDataGridViewTextBoxColumn
      // 
      this.allrserrorrsDataGridViewTextBoxColumn.DataPropertyName = "all_rs_errorrs";
      this.allrserrorrsDataGridViewTextBoxColumn.HeaderText = "Нет связи RS-485";
      this.allrserrorrsDataGridViewTextBoxColumn.Name = "allrserrorrsDataGridViewTextBoxColumn";
      // 
      // allerrorgsmDataGridViewTextBoxColumn
      // 
      this.allerrorgsmDataGridViewTextBoxColumn.DataPropertyName = "allerrorgsm";
      this.allerrorgsmDataGridViewTextBoxColumn.HeaderText = "Неустойчивая связь";
      this.allerrorgsmDataGridViewTextBoxColumn.Name = "allerrorgsmDataGridViewTextBoxColumn";
      // 
      // neterrorulcDataGridViewTextBoxColumn
      // 
      this.neterrorulcDataGridViewTextBoxColumn.DataPropertyName = "neterrorulc";
      this.neterrorulcDataGridViewTextBoxColumn.HeaderText = "Нет связи(ULC)";
      this.neterrorulcDataGridViewTextBoxColumn.Name = "neterrorulcDataGridViewTextBoxColumn";
      // 
      // ulcrserrorrsDataGridViewTextBoxColumn
      // 
      this.ulcrserrorrsDataGridViewTextBoxColumn.DataPropertyName = "ulc_rs_errorrs";
      this.ulcrserrorrsDataGridViewTextBoxColumn.HeaderText = "Нет связи RS-485(ULC)";
      this.ulcrserrorrsDataGridViewTextBoxColumn.Name = "ulcrserrorrsDataGridViewTextBoxColumn";
      // 
      // ulcerrorgsmDataGridViewTextBoxColumn
      // 
      this.ulcerrorgsmDataGridViewTextBoxColumn.DataPropertyName = "ulcerrorgsm";
      this.ulcerrorgsmDataGridViewTextBoxColumn.HeaderText = "Плохая связь(ULC)";
      this.ulcerrorgsmDataGridViewTextBoxColumn.Name = "ulcerrorgsmDataGridViewTextBoxColumn";
      // 
      // neterrorrvpDataGridViewTextBoxColumn
      // 
      this.neterrorrvpDataGridViewTextBoxColumn.DataPropertyName = "neterrorrvp";
      this.neterrorrvpDataGridViewTextBoxColumn.HeaderText = "Нет связи(RVP)";
      this.neterrorrvpDataGridViewTextBoxColumn.Name = "neterrorrvpDataGridViewTextBoxColumn";
      // 
      // rvprserrorrsDataGridViewTextBoxColumn
      // 
      this.rvprserrorrsDataGridViewTextBoxColumn.DataPropertyName = "rvp_rs_errorrs";
      this.rvprserrorrsDataGridViewTextBoxColumn.HeaderText = "Нет связи RS-485(RVP)";
      this.rvprserrorrsDataGridViewTextBoxColumn.Name = "rvprserrorrsDataGridViewTextBoxColumn";
      // 
      // rvperrorgsmDataGridViewTextBoxColumn
      // 
      this.rvperrorgsmDataGridViewTextBoxColumn.DataPropertyName = "rvperrorgsm";
      this.rvperrorgsmDataGridViewTextBoxColumn.HeaderText = "Плохая связь(RVP)";
      this.rvperrorgsmDataGridViewTextBoxColumn.Name = "rvperrorgsmDataGridViewTextBoxColumn";
      // 
      // percentDataGridViewTextBoxColumn
      // 
      this.percentDataGridViewTextBoxColumn.DataPropertyName = "percent";
      this.percentDataGridViewTextBoxColumn.HeaderText = "%";
      this.percentDataGridViewTextBoxColumn.Name = "percentDataGridViewTextBoxColumn";
      this.percentDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // ulcSmalllStatisticBindingSource
      // 
      this.ulcSmalllStatisticBindingSource.DataSource = typeof(UlcWin.DB.UlcSmalllStatistic);
      // 
      // UsrUlcChartCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer1);
      this.Name = "UsrUlcChartCtrl";
      this.Size = new System.Drawing.Size(933, 595);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.tableLayoutPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ulcSmalllStatisticBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    private System.Windows.Forms.Panel panel1;
        private MonthPicker monthPicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMonthExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn currenttimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn allDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn allrvpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn allulcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn neterrorallDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn allrserrorrsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn allerrorgsmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn neterrorulcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ulcrserrorrsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ulcerrorgsmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn neterrorrvpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rvprserrorrsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rvperrorgsmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource ulcSmalllStatisticBindingSource;
    private System.Windows.Forms.Button btnMonthViewClose;
    public System.Windows.Forms.Label label2;
    }
}
