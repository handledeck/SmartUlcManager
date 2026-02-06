using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.ui;
using Ztp.Configuration;
using Ztp.Enums;
using Excel = Microsoft.Office.Interop.Excel;

namespace UlcWin
{
  public partial class AllShcedulesForm : Form
  {
    ZtpConfig __ztpConfig;
    ItemIp __itemIp;
    public AllShcedulesForm(ZtpConfig ztpConfig, ItemIp itemIp)
    {
      InitializeComponent();
      __itemIp = itemIp;
      __ztpConfig = ztpConfig;
    }

    void ExportToExcelWithGroupingAndHeader(ZtpConfig config, ItemIp itemIp)
    {
      Excel.Application excelApp = null;
      Excel.Workbook workbook = null;
      Excel.Worksheet worksheet = null;

      try
      {
        // Создаем приложение Excel
        excelApp = new Excel.Application();
        excelApp.Visible = false;

        // Создаем новую книгу
        workbook = excelApp.Workbooks.Add();
        worksheet = (Excel.Worksheet)workbook.Sheets[1];
        worksheet.Name = $"{itemIp.Name}";

        // ===== ЗАГОЛОВОК =====
        // Пустая первая строка
        worksheet.Cells[1, 1] = "";

        // Заголовок во второй строке
        Excel.Range headerRange = worksheet.Range["A2", "C2"];
        headerRange.Merge();
        headerRange.Value = $"{itemIp.NodeFullPath} {itemIp.Name}"; //"Добейский, КТП-111";
        headerRange.Font.Size = 14;
        headerRange.Font.Bold = true;
        headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);

        // ===== ПУСТАЯ СТРОКА ПОСЛЕ ЗАГОЛОВКА =====
        worksheet.Cells[3, 1] = "";

        // ===== ЗАГОЛОВКИ ТАБЛИЦЫ =====
        worksheet.Cells[4, 1] = "Месяц";
        worksheet.Cells[4, 2] = "Включение";
        worksheet.Cells[4, 3] = "Отключение";

        // Форматирование заголовков таблицы
        Excel.Range tableHeaderRange = worksheet.Range["A4", "C4"];
        tableHeaderRange.Font.Bold = true;
        tableHeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
        tableHeaderRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        tableHeaderRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
        List<DateTimePair> list = null;
        // ===== ПОЛУЧАЕМ И СОРТИРУЕМ ДАННЫЕ С ЯНВАРЯ =====
        this.Invoke(new Action(() =>
        {
          //ZtpConfig config = __ztpConfig;
          ZtpSeason season = config.Light.Scheduler.Seasons[0];
          list = ZtpScheduler.CalcTicks(season, config.Light.Scheduler.Seasons[0].Intervals[0], config.TimeZone, config.Latitude,
            config.Longitude);
        }));


        // Создаем словарь для сортировки месяцев
        Dictionary<string, int> monthOrder = new Dictionary<string, int>
        {
            {"Январь", 1}, {"Февраль", 2}, {"Март", 3}, {"Апрель", 4},
            {"Май", 5}, {"Июнь", 6}, {"Июль", 7}, {"Август", 8},
            {"Сентябрь", 9}, {"Октябрь", 10}, {"Ноябрь", 11}, {"Декабрь", 12}
        };

        // Группируем данные по месяцам и сортируем с января
        var groupedData = list
            .Select(tuple => new
            {
              Tuple = tuple,
              Month = GetMonth(tuple),
              MonthName = GetMonth(tuple).GetFieldAttribute().DisplayName
            })
            .GroupBy(x => x.MonthName)
            .OrderBy(g =>
            {
              // Сортируем по порядку месяцев, начиная с января
              string monthName = g.Key;
              if (monthOrder.ContainsKey(monthName))
                return monthOrder[monthName];
              return 13; // Если месяц не найден, помещаем в конец
            })
            .ThenBy(g => g.First().Tuple.Item1) // Дополнительная сортировка по дате
            .ToList();

        int row = 5; // Начинаем с 5 строки
        int groupStartRow = 5;

        // Заполняем данные, сгруппированные по месяцам
        foreach (var monthGroup in groupedData)
        {
          string monthName = monthGroup.Key;
          groupStartRow = row;

          foreach (var item in monthGroup)
          {
            DateTimePair tuple = item.Tuple;

            // Записываем данные
            worksheet.Cells[row, 1] = monthName;
            worksheet.Cells[row, 2] = tuple.Item1.HasValue ?
                tuple.Item1.Value.ToString("dd MMM yyyy HH:mm") : "Нет";
            worksheet.Cells[row, 3] = tuple.Item2.HasValue ?
                tuple.Item2.Value.ToString("dd MMM yyyy HH:mm") : "Нет";

            // Добавляем границы для ячеек с данными
            Excel.Range dataRowRange = worksheet.Range[$"A{row}", $"C{row}"];
            dataRowRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            dataRowRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

            // Чередующаяся заливка для читаемости
            if (row % 2 == 0)
            {
              dataRowRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(
                  System.Drawing.Color.FromArgb(248, 248, 248));
            }

            row++;
          }

          // Группируем строки текущего месяца (если больше одной строки)
          if (row - 1 > groupStartRow)
          {
            Excel.Range monthGroupRange = worksheet.Range[$"A{groupStartRow}:C{row - 1}"];
            monthGroupRange.Rows.Group();
          }
        }

        // ===== ФОРМАТИРОВАНИЕ =====

        // Форматирование столбца с месяцами
        Excel.Range monthColumn = worksheet.Range["A5", $"A{row - 1}"];
        monthColumn.Font.Bold = true;

        // Автоподбор ширины столбцов
        worksheet.Columns.AutoFit();

        // Добавляем дополнительное форматирование ширины
        worksheet.Columns["A"].ColumnWidth = 20;
        worksheet.Columns["B"].ColumnWidth = 25;
        worksheet.Columns["C"].ColumnWidth = 25;

        // Настраиваем высоту строк
        worksheet.Rows[2].RowHeight = 30;
        worksheet.Rows[4].RowHeight = 25;

        // Разворачиваем все группы (чтобы данные были видны)
        worksheet.Outline.ShowLevels(1, 0);

        // Добавляем фильтр
        Excel.Range filterRange = worksheet.Range["A4", $"C{row - 1}"];
        filterRange.AutoFilter(1, Type.Missing, Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);

        // ===== ИТОГОВАЯ СТРОКА =====
        Excel.Range totalRow = worksheet.Range[$"A{row}", $"C{row}"];
        totalRow.Merge();
        totalRow.Value = $"Всего записей: {list.Count} | Сортировка: с января по декабрь";
        totalRow.Font.Bold = true;
        totalRow.Font.Size = 10;
        totalRow.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
        totalRow.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);
        totalRow.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

        // ===== СОХРАНЕНИЕ =====
        SaveFileDialog saveDialog = new SaveFileDialog();
        saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
        saveDialog.FilterIndex = 1;
        saveDialog.RestoreDirectory = true;
        saveDialog.FileName = $"{itemIp.Name}.xlsx";
        DialogResult result = DialogResult.Cancel;
        EventWaitHandle eventWaitHandle = new AutoResetEvent(false);
        Thread t = new Thread(() =>
        {
          result = saveDialog.ShowDialog();
          eventWaitHandle.Set();
        });
        t.SetApartmentState(ApartmentState.STA);
        t.Start();
        eventWaitHandle.WaitOne();
        if (result == DialogResult.OK)
        {
          excelApp.DisplayAlerts = false;
          excelApp.ActiveWorkbook.SaveAs(saveDialog.FileName);//,Microsoft.Office.XlFileFormat.xlWorkbookNormal);
                                                              //workbook.SaveAs(saveDialog.FileName);
                                                              //MessageBox.Show($"Экспортировано {list.Count} записей!\nСортировка с января.",
                                                              //  "Экспорт в Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
          object misValue = System.Reflection.Missing.Value;
          workbook.Close(false, misValue, misValue);
        }
      }
      catch (Exception ex)
      {
        int x = 0;
        //MessageBox.Show(ex.Message);
        //Box.Error(this, ex);
      }
      finally
      {
        CleanupExcelObjects(worksheet, workbook, excelApp);

      }
    }
    void CleanupExcelObjects(Excel.Worksheet worksheet, Excel.Workbook workbook, Excel.Application excelApp)
    {
      try
      {
        if (workbook != null)
        {
          workbook.Close(false);
          System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
        }

        if (excelApp != null)
        {
          excelApp.Quit();
          System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }

        if (worksheet != null)
        {
          System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
        }
      }
      catch { }
      finally
      {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
      }
    }

    Month GetMonth(DateTimePair tuple)
    {
      if (tuple.Item1 == null && tuple.Item2 == null)
        throw new ArgumentException();
      if (tuple.Item1.HasValue)
        return (Month)tuple.Item1.Value.Month;
      return (Month)tuple.Item2.Value.Month;
    }


    public  void ShowAllSchedulers()
    {
      ZtpConfig config;
      //using (AllShcedulesForm s = new AllShcedulesForm())
      //{
        this.Text = this.__itemIp.Name;
        config = __ztpConfig;
        ZtpSeason season = config.Light.Scheduler.Seasons[0];
        List<DateTimePair> list = ZtpScheduler.CalcTicks(season, config.Light.Scheduler.Seasons[0].Intervals[0], config.TimeZone, config.Latitude,
          config.Longitude);
        //ListView listView = new ListView();
        this.listView1.Items.Clear();
        ListViewGroup group = null;
        foreach (DateTimePair tuple in list)
        {
          Month month = GetMonth(tuple);
          string groupName = month.ToString();
          if (group == null || group.Name != groupName)
          {
            group = new ListViewGroup(month.ToString(), month.GetFieldAttribute().DisplayName);
            this.listView1.Groups.Add(group);
          }

          string first = tuple.Item1.HasValue ? tuple.Item1.Value.ToString("dd MMM yyyy HH:mm") : "Нет";
          string second = tuple.Item2.HasValue ? tuple.Item2.Value.ToString("dd MMM yyyy HH:mm") : "Нет";

          ListViewItem item = new ListViewItem(new string[] { first, second }, group);
          item.ImageIndex = 0;
          this.listView1.Items.Add(item);
        }
        this.listView1.ShowGroups = true;
        //s.ShowDialog();
      //}
    }

    private void button2_Click(object sender, EventArgs e)
    {
      using (SimpleWaitForm sfrm = new SimpleWaitForm())
      {
        sfrm.RunAction(new Action(() =>
        {
          sfrm.SetHeaderText("Экспорт в Excel");
          sfrm.SetLabelText("Формирую документ");
          ExportToExcelWithGroupingAndHeader(__ztpConfig,__itemIp);
          sfrm.DialogResult = DialogResult.OK;
        }));
        DialogResult result = sfrm.ShowDialog();
      }
    }
  }
}
