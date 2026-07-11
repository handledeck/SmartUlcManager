using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace UlcWin.Controls.LogNet
{

  public partial class SignalChartDialog : Form
  {
    private List<SignalMeasurement> measurements = new List<SignalMeasurement>();
    private bool isDataLoaded = false;
    private ComboBox cmbInterval;
    private RichTextBox rtbStatistics;
    public string ObjectName { get; set; } = "";

    public SignalChartDialog(List<string> logLines,string objectName)
    {
      this.ObjectName=objectName;
      InitializeComponent();

      InitializeCustomControls();

      ParseLogLines(logLines);
      BuildChart();
    }

    private void InitializeComponent()
    {
      this.Text = "Signal Chart";
      this.Size = new Size(1200, 700);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.MinimumSize = new Size(800, 500);
      this.ShowIcon = false;
    }

    private void InitializeCustomControls()
    {
      // Темный фон всей формы
      this.BackColor = Color.FromArgb(30, 30, 30);

      // Очищаем то, что создал дизайнер
      chart1.Series.Clear();
      chart1.ChartAreas.Clear();

      // Фон графика
      chart1.BackColor = Color.FromArgb(45, 45, 48);

      // Создание области графика
      var chartArea = new ChartArea("MainArea");
      chartArea.BackColor = Color.FromArgb(45, 45, 48);

      chartArea.AxisX.Title = "Время и дата";
      chartArea.AxisX.TitleForeColor = Color.White;
      chartArea.AxisX.LabelStyle.ForeColor = Color.LightGray;
      chartArea.AxisX.LabelStyle.Format = "dd.MM\nHH:mm";
      chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 7);
      chartArea.AxisX.IntervalType = DateTimeIntervalType.Minutes;
      chartArea.AxisX.Interval = 30;
      chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(60, 60, 60);
      chartArea.AxisX.LineColor = Color.Gray;
      chartArea.AxisX.Minimum = 0;
      chartArea.AxisX.Maximum = 1;

      // Настройка оси Y
      chartArea.AxisY.Title = "RSCP (дБм)";
      chartArea.AxisY.TitleForeColor = Color.White;
      chartArea.AxisY.LabelStyle.ForeColor = Color.LightGray;
      chartArea.AxisY.Minimum = -120;
      chartArea.AxisY.Maximum = -70;
      chartArea.AxisY.Interval = 10;
      chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(60, 60, 60);
      chartArea.AxisY.LineColor = Color.Gray;
      chartArea.AxisY.LabelStyle.Format = "0";

      // Линии уровней
      StripLine goodLine = new StripLine
      {
        Interval = 0,
        IntervalOffset = -90,
        BorderColor = Color.LimeGreen,
        BorderWidth = 2,
        BorderDashStyle = ChartDashStyle.Dash,
        Text = "Хорошо (≥ -90)",
        TextAlignment = StringAlignment.Far,
        ForeColor = Color.LimeGreen
      };

      StripLine badLine = new StripLine
      {
        Interval = 0,
        IntervalOffset = -100,
        BorderColor = Color.Red,
        BorderWidth = 2,
        BorderDashStyle = ChartDashStyle.Dash,
        Text = "Плохо (≤ -100)",
        TextAlignment = StringAlignment.Far,
        ForeColor = Color.Red
      };

      chartArea.AxisY.StripLines.Add(goodLine);
      chartArea.AxisY.StripLines.Add(badLine);

      // Прокрутка и зум
      chartArea.AxisX.ScrollBar.Enabled = true;
      chartArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
      chartArea.AxisX.ScrollBar.LineColor = Color.Gray;
      chartArea.AxisX.ScrollBar.BackColor = Color.FromArgb(60, 60, 60);
      chartArea.AxisX.ScaleView.Zoomable = true;
      chart1.AxisViewChanged += Chart1_AxisViewChanged;
      chart1.ChartAreas.Add(chartArea);

      // Серия
      var series = new Series("RSCP")
      {
        ChartType = SeriesChartType.Line,
        MarkerSize = 6,
        MarkerStyle = MarkerStyle.Circle,
        BorderWidth = 1,
        XValueType = ChartValueType.DateTime
      };
      chart1.Series.Add(series);

      // Легенда (тема)
      chart1.Legends.Clear();
      var legend = new Legend("Legend1")
      {
        
        Title = string.IsNullOrEmpty(ObjectName) ? "Качество сигнала" : ObjectName,
        Docking = Docking.Top,
        BackColor = Color.FromArgb(45, 45, 48),
        ForeColor = Color.White,
        TitleForeColor = Color.White,
        TitleFont = new Font("Courier New", 11, FontStyle.Regular)     // ← шрифт для заголовка
      };
      chart1.Legends.Add(legend);

      // ========== ВЕРХНЯЯ ПАНЕЛЬ ==========
      var panelTop = new Panel
      {
        Dock = DockStyle.Top,
        Height = 35,
        Padding = new Padding(5),
        BackColor = Color.FromArgb(30, 30, 30)
      };

      // Метка интервала
      var lblInterval = new Label
      {
        Text = "Видимый интервал:",
        AutoSize = true,
        Location = new Point(10, 8),
        ForeColor = Color.White
      };
      panelTop.Controls.Add(lblInterval);

      // ComboBox интервала
      cmbInterval = new ComboBox
      {
        Size = new Size(80, 23),
        Location = new Point(lblInterval.Right + 10, 5),
        DropDownStyle = ComboBoxStyle.DropDownList,
        BackColor = Color.FromArgb(60, 60, 60),
        ForeColor = Color.White
      };
      cmbInterval.Items.AddRange(new object[] { "15 минут", "30 минут", "1 час" });
      cmbInterval.SelectedIndex = 2;
      cmbInterval.SelectedIndexChanged += CmbInterval_SelectedIndexChanged;
      panelTop.Controls.Add(cmbInterval);

      // ========== НИЖНЯЯ ПАНЕЛЬ ДЛЯ СТАТИСТИКИ ==========
      var panelBottom = new Panel
      {
        Dock = DockStyle.Bottom,
        Height = 55,
        BackColor = Color.FromArgb(30, 30, 30),
        Padding = new Padding(10, 5, 10, 5)
      };

      rtbStatistics = new RichTextBox
      {
        Dock = DockStyle.Fill,
        Font = new Font("Segoe UI", 11, FontStyle.Regular),
        BackColor = Color.FromArgb(30, 30, 30),
        ForeColor = Color.White,
        BorderStyle = BorderStyle.None,
        ReadOnly = true,
        DetectUrls = false
      };
      panelBottom.Controls.Add(rtbStatistics);

      // ========== ПАНЕЛЬ ДЛЯ ГРАФИКА ==========
      var chartPanel = new Panel
      {
        Dock = DockStyle.Fill,
        Padding = new Padding(5),
        BackColor = Color.FromArgb(45, 45, 48)
      };

      chart1.Dock = DockStyle.Fill;
      chartPanel.Controls.Add(chart1);

      // Добавляем панели на форму
      this.Controls.Add(chartPanel);
      this.Controls.Add(panelBottom);
      this.Controls.Add(panelTop);

      // Подписка на события мыши для прокрутки
      chart1.MouseWheel += Chart_MouseWheel;
      chart1.MouseEnter += (s, e) => chart1.Focus();
    }

    private void Chart1_AxisViewChanged(object sender, ViewEventArgs e)
    {
      // Срабатывает при изменении масштаба/позиции (скролл, зум, колесо)
      // Можете добавить логику при необходимости
      // Например, обновить какие-то данные или просто перерисовать
      chart1.Invalidate();
    }

    private Chart chart1 = new Chart();

    private void ParseLogLines(List<string> logLines)
    {
      var timePattern = new Regex(@"(?<day>\d{2})\.(?<month>\d{2})\.(?<year>\d{2})\s+(?<hour>\d{2}):(?<minute>\d{2}):(?<second>\d{2})");

      var allMeasurements = new List<SignalMeasurement>();
      DateTime? currentTimestamp = null;

      foreach (var line in logLines)
      {
        var timeMatch = timePattern.Match(line);
        if (timeMatch.Success)
        {
          int day = int.Parse(timeMatch.Groups["day"].Value);
          int month = int.Parse(timeMatch.Groups["month"].Value);
          int year = 2000 + int.Parse(timeMatch.Groups["year"].Value);
          int hour = int.Parse(timeMatch.Groups["hour"].Value);
          int minute = int.Parse(timeMatch.Groups["minute"].Value);
          int second = int.Parse(timeMatch.Groups["second"].Value);

          try
          {
            currentTimestamp = new DateTime(year, month, day, hour, minute, second);
          }
          catch { }
        }

        if (!currentTimestamp.HasValue) continue;

        // 2G: +CPSI: GSM
        if (line.Contains("+CPSI: GSM"))
        {
          var gsmPattern = new Regex(@"\+CPSI:\s+GSM,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,(?<rssi>\d+),\d+,\S+");
          var match = gsmPattern.Match(line);

          if (match.Success)
          {
            int rssi = int.Parse(match.Groups["rssi"].Value);
            int rscp = rssi * 2 - 113;

            if (rscp >= -120 && rscp <= -40)
            {
              allMeasurements.Add(new SignalMeasurement
              {
                Timestamp = currentTimestamp.Value,
                RSCP = rscp,
                Technology = "2G",
                Band = "GSM"
              });
            }
          }
        }
        // 3G: +CPSI: WCDMA
        else if (line.Contains("+CPSI: WCDMA"))
        {
          var wcdmaPattern = new Regex(@"\+CPSI:\s+WCDMA,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,(?<ecio>-?\d+),(?<rscp>-?\d+)");
          var match = wcdmaPattern.Match(line);

          if (match.Success)
          {
            int rscp = int.Parse(match.Groups["rscp"].Value);
            int ecIo = int.Parse(match.Groups["ecio"].Value);

            if (rscp != -32768 && rscp >= -120 && rscp <= -40)
            {
              allMeasurements.Add(new SignalMeasurement
              {
                Timestamp = currentTimestamp.Value,
                RSCP = rscp,
                EcIo = ecIo,
                Technology = "3G",
                Band = "WCDMA"
              });
            }
          }
        }
        // 4G: +CPSI: LTE
        else if (line.Contains("+CPSI: LTE"))
        {
          var ltePattern = new Regex(@"\+CPSI:\s+LTE,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,(?<rsrp>\d+)");
          var match = ltePattern.Match(line);

          if (match.Success)
          {
            int rsrpValue = int.Parse(match.Groups["rsrp"].Value);
            int rscp = -rsrpValue;

            if (rscp >= -120 && rscp <= -40)
            {
              allMeasurements.Add(new SignalMeasurement
              {
                Timestamp = currentTimestamp.Value,
                RSCP = rscp,
                Technology = "4G",
                Band = "LTE"
              });
            }
          }
        }
      }

      measurements = allMeasurements.OrderBy(m => m.Timestamp).ToList();
    }

    private void BuildChart()
    {
      if (measurements.Count == 0)
      {
        MessageBox.Show("Не найдено валидных измерений сигнала", "Ошибка",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      PlotData();
      isDataLoaded = true;

      int minutes = GetSelectedMinutes();
      ApplyScaleView(minutes);

      UpdateStatisticsPanel();
    }

    private int GetSelectedMinutes()
    {
      string selectedText = cmbInterval.SelectedItem.ToString();
      switch (selectedText)
      {
        case "15 минут": return 15;
        case "30 минут": return 30;
        case "1 час": return 60;
        default: return 60;
      }
    }

    private void ApplyScaleView(int visibleMinutes)
    {
      if (measurements.Count == 0) return;

      var chartArea = chart1.ChartAreas["MainArea"];
      if (chartArea == null) return;

      double totalDays = (measurements.Last().Timestamp - measurements.First().Timestamp).TotalDays;
      double visibleDays = visibleMinutes / 60.0 / 24.0;

      if (visibleDays >= totalDays)
      {
        chartArea.AxisX.ScaleView.ZoomReset();
        chartArea.AxisX.ScrollBar.Enabled = false;
        chart1.Invalidate();
        return;
      }

      chartArea.AxisX.ScrollBar.Enabled = true;
      chartArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
      chartArea.AxisX.ScaleView.Zoomable = true;

      // Размер видимой области
      chartArea.AxisX.ScaleView.Size = visibleDays;

      // Позиция
      double currentStart = chartArea.AxisX.ScaleView.ViewMinimum;
      if (double.IsNaN(currentStart) || currentStart < chartArea.AxisX.Minimum)
      {
        currentStart = chartArea.AxisX.Minimum;
      }

      double currentEnd = currentStart + visibleDays;
      if (currentEnd > chartArea.AxisX.Maximum)
      {
        currentEnd = chartArea.AxisX.Maximum;
        currentStart = currentEnd - visibleDays;
      }

      chartArea.AxisX.ScaleView.Zoom(currentStart, currentEnd);
      chart1.Invalidate();
    }

    private (double min, double max) GetYAxisRange()
    {
      if (measurements.Count == 0) return (-120, -70);

      double minRscp = measurements.Min(m => m.RSCP);
      double maxRscp = measurements.Max(m => m.RSCP);

      double padding = 5;
      double min = minRscp - padding;
      double max = maxRscp + padding;

      min = Math.Floor(min / 10) * 10;
      max = Math.Ceiling(max / 10) * 10;

      if (max > -40) max = -40;

      return (min, max);
    }

    private void PlotData()
    {
      if (measurements.Count == 0) return;

      chart1.SuspendLayout();
      chart1.Series["RSCP"].Points.Clear();

      var minTime = measurements.First().Timestamp;
      var maxTime = measurements.Last().Timestamp;
      var chartArea = chart1.ChartAreas["MainArea"];

      // Настройка оси X
      chartArea.AxisX.Minimum = minTime.ToOADate();
      chartArea.AxisX.Maximum = maxTime.ToOADate();
      chartArea.AxisX.LabelStyle.Format = "dd.MM\nHH:mm";
      chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 7);
      chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(60, 60, 60);

      string currentInterval = cmbInterval.SelectedItem.ToString();
      int intervalMinutes;

      switch (currentInterval)
      {
        case "15 минут": intervalMinutes = 5; break;
        case "30 минут": intervalMinutes = 10; break;
        case "1 час": intervalMinutes = 15; break;
        default: intervalMinutes = 15; break;
      }

      chartArea.AxisX.IntervalType = DateTimeIntervalType.Minutes;
      chartArea.AxisX.Interval = intervalMinutes;

      // Динамическая ось Y
      var (yMin, yMax) = GetYAxisRange();
      chartArea.AxisY.Minimum = yMin;
      chartArea.AxisY.Maximum = yMax;
      chartArea.AxisY.Interval = 10;

      // Очищаем старые метки Y
      chartArea.AxisY.CustomLabels.Clear();
      for (int value = (int)Math.Ceiling(yMin / 10) * 10; value <= yMax; value += 10)
      {
        CustomLabel label = new CustomLabel
        {
          FromPosition = value - 0.5,
          ToPosition = value + 0.5,
          Text = value.ToString(),
          ForeColor = Color.LightGray
        };
        chartArea.AxisY.CustomLabels.Add(label);
      }

      // Линии уровней
      chartArea.AxisY.StripLines.Clear();

      if (yMax >= -90 && yMin <= -90)
      {
        chartArea.AxisY.StripLines.Add(new StripLine
        {
          Interval = 0,
          IntervalOffset = -90,
          BorderColor = Color.LimeGreen,
          BorderWidth = 2,
          BorderDashStyle = ChartDashStyle.Dash,
          Text = "Хорошо (≥ -90)",
          TextAlignment = StringAlignment.Far,
          ForeColor = Color.LimeGreen
        });
      }

      if (yMax >= -100 && yMin <= -100)
      {
        chartArea.AxisY.StripLines.Add(new StripLine
        {
          Interval = 0,
          IntervalOffset = -100,
          BorderColor = Color.Red,
          BorderWidth = 2,
          BorderDashStyle = ChartDashStyle.Dash,
          Text = "Плохо (≤ -100)",
          TextAlignment = StringAlignment.Far,
          ForeColor = Color.Red
        });
      }

      // Подписи точек - ИСПРАВЛЕНО
      bool showLabels = (currentInterval == "15 минут" || currentInterval == "30 минут" || currentInterval == "1 час");

      chart1.Series["RSCP"].IsValueShownAsLabel = showLabels;
      chart1.Series["RSCP"].LabelForeColor = Color.White;
      chart1.Series["RSCP"].LabelBackColor = Color.Transparent;

      // Добавление точек
      DateTime? lastTimestamp = null;
      int breakCount = 0;

      chart1.Legends["Legend1"].CustomItems.Clear();

      foreach (var m in measurements)
      {
        if (lastTimestamp.HasValue && (m.Timestamp - lastTimestamp.Value).TotalMinutes > 10)
        {
          breakCount++;
          int emptyIndex = chart1.Series["RSCP"].Points.AddXY(m.Timestamp.ToOADate(), double.NaN);
          var emptyPoint = chart1.Series["RSCP"].Points[emptyIndex];
          emptyPoint.IsEmpty = true;
          emptyPoint.ToolTip = $"⚠️ РАЗРЫВ СВЯЗИ\n{lastTimestamp:dd.MM HH:mm:ss} → {m.Timestamp:dd.MM HH:mm:ss}";
        }

        int pointIndex = chart1.Series["RSCP"].Points.AddXY(m.Timestamp.ToOADate(), m.RSCP);
        var point = chart1.Series["RSCP"].Points[pointIndex];

        // Цвет по уровню сигнала в зависимости от технологии
        if (m.Technology == "2G")
        {
          if (m.RSCP >= -75)
            point.Color = Color.Green;
          else if (m.RSCP >= -85)
            point.Color = Color.LimeGreen;
          else if (m.RSCP >= -95)
            point.Color = Color.Gold;
          else
            point.Color = Color.Red;
        }
        else if (m.Technology == "3G")
        {
          if (m.RSCP >= -75)
            point.Color = Color.Green;
          else if (m.RSCP >= -90)
            point.Color = Color.LimeGreen;
          else if (m.RSCP >= -100)
            point.Color = Color.Gold;
          else
            point.Color = Color.Red;
        }
        else if (m.Technology == "4G")
        {
          if (m.RSCP >= -80)
            point.Color = Color.Green;
          else if (m.RSCP >= -95)
            point.Color = Color.LimeGreen;
          else if (m.RSCP >= -105)
            point.Color = Color.Gold;
          else
            point.Color = Color.Red;
        }
        else
        {
          if (m.RSCP >= -90)
            point.Color = Color.Green;
          else if (m.RSCP > -100)
            point.Color = Color.Gold;
          else
            point.Color = Color.Red;
        }

        // Форма маркера в зависимости от технологии
        switch (m.Technology)
        {
          case "2G":
            point.MarkerStyle = MarkerStyle.Square;
            break;
          case "3G":
            point.MarkerStyle = MarkerStyle.Circle;
            break;
          case "4G":
            point.MarkerStyle = MarkerStyle.Diamond;
            break;
          default:
            point.MarkerStyle = MarkerStyle.Circle;
            break;
        }
        point.MarkerSize = 6;

        if (showLabels)
          point.LabelForeColor = point.Color;

        string quality = "";
        if (m.Technology == "2G")
        {
          if (m.RSCP >= -75) quality = "Отличный";
          else if (m.RSCP >= -85) quality = "Хороший";
          else if (m.RSCP >= -95) quality = "Средний";
          else quality = "Плохой";
        }
        else if (m.Technology == "3G")
        {
          if (m.RSCP >= -75) quality = "Отличный";
          else if (m.RSCP >= -90) quality = "Хороший";
          else if (m.RSCP >= -100) quality = "Средний";
          else quality = "Плохой";
        }
        else if (m.Technology == "4G")
        {
          if (m.RSCP >= -80) quality = "Отличный";
          else if (m.RSCP >= -95) quality = "Хороший";
          else if (m.RSCP >= -105) quality = "Средний";
          else quality = "Плохой";
        }
        else
        {
          quality = m.RSCP >= -90 ? "Хороший" : (m.RSCP > -100 ? "Средний" : "Плохой");
        }

        point.ToolTip = $"📅 {m.Timestamp:dd.MM.yyyy}\n" +
                       $"⏰ {m.Timestamp:HH:mm:ss}\n" +
                       $"📶 RSCP: {m.RSCP} дБм\n" +
                       $"📡 {m.Technology} - {m.Band}\n" +
                       $"⭐ {quality}";

        lastTimestamp = m.Timestamp;
      }

      // Легенда
      chart1.Legends["Legend1"].Font = new Font("Courier New", 11, FontStyle.Regular);
      chart1.Legends["Legend1"].CustomItems.Add(Color.Green, "Хороший (RSCP ≥ -90)");
      chart1.Legends["Legend1"].CustomItems.Add(Color.Gold, "Средний (RSCP -100...-90)");
      chart1.Legends["Legend1"].CustomItems.Add(Color.Red, "Плохой (RSCP ≤ -100)");
      
      //chart1.Legends["Legend1"].CustomItems.Add(Color.White, "□ 2G | ○ 3G | ◇ 4G");

      chart1.ResumeLayout();
      chart1.Invalidate();
    }

    private void UpdateStatisticsPanel()
    {
      if (measurements.Count == 0)
      {
        rtbStatistics.Text = "Нет данных";
        return;
      }

      var rscpValues = measurements.Select(m => m.RSCP).ToList();
      double avg = rscpValues.Average();
      int min = rscpValues.Min();
      int max = rscpValues.Max();

      // Считаем по единой шкале (как в легенде)
      int good = measurements.Count(m => m.RSCP >= -90);
      int medium = measurements.Count(m => m.RSCP > -100 && m.RSCP < -90);
      int bad = measurements.Count(m => m.RSCP <= -100);
      int total = measurements.Count;

      double goodPercent = (double)good / total * 100;
      double mediumPercent = (double)medium / total * 100;
      double badPercent = (double)bad / total * 100;

      // Статистика по технологиям
      int count2G = measurements.Count(m => m.Technology == "2G");
      int count3G = measurements.Count(m => m.Technology == "3G");
      int count4G = measurements.Count(m => m.Technology == "4G");

      rtbStatistics.Clear();

      rtbStatistics.SelectionColor = Color.White;
      rtbStatistics.AppendText($"📊 {total} изм | Средний: {avg:F1} дБм | Мин: {min} | Макс: {max} | ");

      rtbStatistics.SelectionColor = Color.Green;
      rtbStatistics.AppendText($"● {good} ({goodPercent:F1}%)");

      rtbStatistics.SelectionColor = Color.White;
      rtbStatistics.AppendText(" | ");

      rtbStatistics.SelectionColor = Color.Gold;
      rtbStatistics.AppendText($"● {medium} ({mediumPercent:F1}%)");

      rtbStatistics.SelectionColor = Color.White;
      rtbStatistics.AppendText(" | ");

      rtbStatistics.SelectionColor = Color.Red;
      rtbStatistics.AppendText($"● {bad} ({badPercent:F1}%)");

      rtbStatistics.SelectionColor = Color.White;
      rtbStatistics.AppendText($"\n📡 2G: {count2G} | 3G: {count3G} | 4G: {count4G}");
    }

    private void CmbInterval_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!isDataLoaded || measurements.Count == 0) return;

      int minutes = GetSelectedMinutes();

      PlotData();
      ApplyScaleView(minutes);
    }

    #region Прокрутка графика колесом мыши

    private void Chart_MouseWheel(object sender, MouseEventArgs e)
    {
      if (!isDataLoaded || measurements.Count == 0) return;

      try
      {
        var chartArea = chart1.ChartAreas["MainArea"];
        double viewSize = chartArea.AxisX.ScaleView.Size;
        double stepPercent = 0.1;
        double stepDays = viewSize * stepPercent;

        double deltaDays = e.Delta > 0 ? -stepDays : stepDays;
        double newPosition = chartArea.AxisX.ScaleView.Position + deltaDays;

        double minPosition = chartArea.AxisX.Minimum;
        double maxPosition = chartArea.AxisX.Maximum - viewSize;

        if (newPosition < minPosition) newPosition = minPosition;
        if (newPosition > maxPosition) newPosition = maxPosition;

        chartArea.AxisX.ScaleView.Position = newPosition;
        chart1.Invalidate();
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine($"MouseWheel error: {ex.Message}");
      }
    }

    #endregion
  }

  public class SignalMeasurement
  {
    public DateTime Timestamp { get; set; }
    public int RSCP { get; set; }
    public int EcIo { get; set; }
    public string Band { get; set; }
    public string Technology { get; set; }
  }
}




