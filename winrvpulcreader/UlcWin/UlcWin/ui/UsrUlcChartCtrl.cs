using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ServiceStack.OrmLite;
using UlcWin.DB;
using UlcWin.ui;

namespace GraphStatic
{
  public delegate void MonthViewClose();
  public partial class UsrUlcChartCtrl : UserControl
  {
    List<UlcSmalllStatistic> __lst;
    string __connection = string.Empty;
    DateTime __start;// = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
    DateTime __end; //= __start.AddMonths(1);
    public event MonthViewClose monthViewClose;
    public UsrUlcChartCtrl()
    {
      InitializeComponent();
      chart1.Series[0].ChartType = SeriesChartType.Line;
      chart1.Series[1].ChartType = SeriesChartType.Line;
      chart1.Series[2].ChartType = SeriesChartType.Line;
      //Title title = new Title("Статистика работы контроллеров");
      //chart1.Titles.Add(title);
      chart1.Series[0].IsValueShownAsLabel = true;
      chart1.Series[1].IsValueShownAsLabel = true;
      chart1.Series[2].IsValueShownAsLabel = true;
      __lst = new List<UlcSmalllStatistic>();
      dataGridView1.RowHeadersVisible = false;
      dataGridView1.AllowUserToResizeRows = false;
      chart1.Series[0].IsValueShownAsLabel = true;
      chart1.Series[1].IsValueShownAsLabel = true;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.monthPicker1.ValueChanged += MonthPicker1_ValueChanged;
      dataGridView1.EnableHeadersVisualStyles = false;
      dataGridView1.Columns[4].HeaderCell.Style.BackColor = Color.FromArgb(255, 128, 0);
      dataGridView1.Columns[4].HeaderCell.Style.ForeColor = Color.White;
      dataGridView1.Columns[5].HeaderCell.Style.BackColor = Color.Teal;
      dataGridView1.Columns[5].HeaderCell.Style.ForeColor = Color.White;
      dataGridView1.Columns[6].HeaderCell.Style.BackColor = Color.DodgerBlue;//Color.Olive;
      dataGridView1.Columns[6].HeaderCell.Style.ForeColor = Color.White;
      dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8);
      this.dataGridView1.DefaultCellStyle.Font = new Font("Verdana", 8);
      chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.Gainsboro;
      chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.Gainsboro;
      chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.Gainsboro;
      chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = 1;
      chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
      dataGridView1.CellFormatting += DataGridView1_CellFormatting;
      this.dataGridView1.ReadOnly = true;
      dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    }

    private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if (e.Value != null)
      {
        if (e.ColumnIndex == 0)
        {
          DateTime dt = (DateTime)e.Value;
          e.Value = dt.Date;
        }
      }
    }

    private void MonthPicker1_ValueChanged(object sender, EventArgs e)
    {
      this.__lst.Clear();
      foreach (var item in this.chart1.Series)
      {
        item.Points.Clear();
      }
      this.dataGridView1.DataSource = null;
      this.chart1.DataSource = null;
      SelMonthData(__connection);
      rest = true;
      if (this.dataGridView1.Rows.Count > 1)
      {
        this.btnMonthExport.Enabled = true;
        
      }
      else {
        this.btnMonthExport.Enabled = false;
        this.label2.ForeColor = Color.Black;
        this.label2.Text = "0.0";
      }
    }
  
    void SelMonthData(string connection)
    {
      this.__connection = connection;
      __start = new DateTime(this.monthPicker1.Value.Year, this.monthPicker1.Value.Month, 1);
      __end = __start.AddMonths(1);
      string sql = string.Format("select * from main_stat ms where ms.\"current_time\" >'{0}'" +
        " and ms.\"current_time\" <'{1}'", __start, __end);
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
          __connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          Dictionary<DateTime, UlcSmalllStatistic> dick = new Dictionary<DateTime, UlcSmalllStatistic>();
          List<UlcSmalllStatistic> zz = db.Select<UlcSmalllStatistic>(sql);
          foreach (var item in zz)
          {
            DateTime dtn = item.current_time.Date;
            if (!dick.ContainsKey(dtn))
            {
              dick.Add(dtn, item);
            }
            else
            {
              if (dick[dtn].current_time < item.current_time)
              {
                dick[dtn] = item;
              }
            }
          }
          foreach (var item in dick)
          {
            __lst.Add(item.Value);
          }
          if (__lst.Count != 0)
          {
            this.dataGridView1.DataSource = __lst;
            this.chart1.DataSource = null;
            this.chart1.DataSource = this.dataGridView1.DataSource;
          }
        }
      }
      catch (Exception ex)
      {
        int x = 0;
      }
    }

    void reset_chart()
    {
      foreach (DataGridViewRow item in this.dataGridView1.Rows)
      {
        string dt = ((DateTime)item.Cells[0].Value).ToString("dd.MM.yy");
        chart1.Series[0].Points.AddXY(dt, item.Cells[4].Value.ToString());
        chart1.Series[1].Points.AddXY(dt, item.Cells[5].Value.ToString());
        chart1.Series[2].Points.AddXY(dt, item.Cells[6].Value.ToString());
      }
    }

    public void SetValue(string connection)
    {
      this.__connection = connection;
      SelMonthData(this.__connection);
      reset_chart();
    }

    bool rest = false;
    private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
      if (this.__lst.Count > 0)
      {
        double sum = 0;
        foreach (DataGridViewRow row in this.dataGridView1.Rows)
        {

          double xx = (double)row.Cells[13].Value;
          sum += xx;
          if (xx < 5)
          {
            row.Cells[13].Style.BackColor = Color.Green;
            row.Cells[13].Style.ForeColor = Color.White;
          }
          else
          {
            row.Cells[13].Style.BackColor = Color.Red;
            row.Cells[13].Style.ForeColor = Color.White;

          }
          double sum_mid = (sum / this.dataGridView1.RowCount);

          this.label2.Text = Math.Round(sum_mid,3).ToString();
          if (sum_mid > 5)
            this.label2.ForeColor = Color.Red;
          else
          {
            this.label2.ForeColor = Color.Green;
          }
        }
        
        if (rest)
        {
          reset_chart();
          rest = false;
        }
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      using (SimpleWaitForm sfrm = new SimpleWaitForm())
      {
        sfrm.RunAction(new Action(() =>
        {
          sfrm.SetLabelText("Формирую документ");
          UlcWin.Export.ExportExcel exe = new UlcWin.Export.ExportExcel(this.dataGridView1,this.label2.Text);// this.LstViewItm);
          Exception ex = exe.PrintStatistics(sfrm);
          //sfrm.DialogResult = DialogResult.OK;
        }));
        sfrm.ShowDialog();
      }
    }

    private void btnMonthViewClose_Click(object sender, EventArgs e)
    {
      if (this.monthViewClose != null)
        this.monthViewClose();
    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
