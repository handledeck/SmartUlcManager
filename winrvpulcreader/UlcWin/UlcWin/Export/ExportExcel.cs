using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.ui;

namespace UlcWin.Export
{
  public class ExportExcel
  {

    ListView __listView = null;
    DataGridView __dataGridView1=null;
    string __summ = string.Empty;
    public ExportExcel(ListView listView)
    {
      this.__listView = listView;
    }

    public ExportExcel(DataGridView dataGridView,string summ)
    {
      this.__dataGridView1 = dataGridView;
      this.__summ = summ;
    }

    public Exception PrintStatistics(SimpleWaitForm sfrm) {
      Exception exp = null;
      Microsoft.Office.Interop.Excel.Application excelApp = null;
      Workbook excelWorkbook = null;
      Worksheet excelWorksheet = null;
      try
      {
        excelApp = new Microsoft.Office.Interop.Excel.Application();
        if (excelApp != null)
        {
          excelWorkbook = excelApp.Workbooks.Add();
          excelWorksheet = (Worksheet)excelWorkbook.Sheets[1];
          excelWorksheet.Cells[1, 1] = "Общая статистика работы контроллеров";
          excelWorksheet.Cells[2, 1] = DateTime.Now.ToString("dd.MM.yyyy");
          excelWorksheet.Cells[1, 1].Font.Size = 18;
          excelWorksheet.Cells[2, 1].Font.Size = 14;
          int header = 3;
          int index = 1;
          for (int i = 0; i < this.__dataGridView1.ColumnCount; i++)
          {

            excelWorksheet.Cells[header, index] = this.__dataGridView1.Columns[i].HeaderText;
            excelWorksheet.Cells[header, index].EntireRow.Font.Bold = true;
            excelWorksheet.Columns[index].NumberFormat = "@";
            excelWorksheet.Cells[header, index].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            excelWorksheet.Cells[header, index].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            index++;


          }
          header++;
          Microsoft.Office.Interop.Excel.XlRgbColor bed = Microsoft.Office.Interop.Excel.XlRgbColor.rgbRed;
          Microsoft.Office.Interop.Excel.XlRgbColor good = Microsoft.Office.Interop.Excel.XlRgbColor.rgbBlack;
          int coln = 1;
          for (int i = 0; i < this.__dataGridView1.RowCount; i++)
          {

            coln = 1;
            Microsoft.Office.Interop.Excel.XlRgbColor color;
            //if (!itemIp.IsTrue)
            //{
            //color = bed;
            //}
            //else color = good;
            for (int n = 0; n < this.__dataGridView1.Rows[i].Cells.Count; n++)
            {
              //if (n == __listView.Columns.Count)
              //  break;
              //if (this.__listView.Columns[n].Width != 0)
              //{
              if (n == 0)
              {
                DateTime dt = (DateTime)this.__dataGridView1.Rows[i].Cells[n].Value;
                excelWorksheet.Cells[header, coln] = dt.Date.ToString("dd.MM.yyyy");
              }
              else
              {
                excelWorksheet.Cells[header, coln] = this.__dataGridView1.Rows[i].Cells[n].Value;
              }

              //excelWorksheet.Cells[header, coln].Font.Color = color;
              coln++;
              //}
            }
            header++;
          }
          excelWorksheet.Cells[header, coln - 2] = "среднее за месяц:";
          excelWorksheet.Cells[header, coln - 1] = __summ;
          //Microsoft.Office.Interop.Excel.Range range = excelApp.get_Range(3,coln);
          //range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
          index = 1;
          for (int i = 0; i < this.__dataGridView1.Columns.Count; i++)
          {
            //if (this.__listView.Columns[i].Width != 0)
            //{
            if (index != 1)
              excelWorksheet.Columns[index].EntireColumn.AutoFit();
            index++;
            //}
          }
          //sfrm.DialogResult = DialogResult.OK;
          object name = excelApp.GetSaveAsFilename(Directory.GetCurrentDirectory(), "Excel Files (*.xls), *.xls");
          if (name.GetType() != typeof(bool))
          {
            excelApp.ActiveWorkbook.SaveAs(name, XlFileFormat.xlWorkbookNormal);
          }
          excelWorkbook.Close();
        }
        sfrm.DialogResult = DialogResult.OK;
        return null;
      }
      catch (Exception ex)
      {
        sfrm.DialogResult = DialogResult.Abort;
        return ex;
      }
      finally
      {
        if (excelApp != null)
          excelApp.Quit();
      }
    }
  

    public bool PrintToExcel(string fes,string res, SimpleWaitForm sfrm) {
      Microsoft.Office.Interop.Excel.Application excelApp = null;
      Workbook excelWorkbook = null;
      Worksheet excelWorksheet = null;
      try
      {
        excelApp = new Microsoft.Office.Interop.Excel.Application();
        if (excelApp != null)
        {
          excelWorkbook = excelApp.Workbooks.Add();
          excelWorksheet = (Worksheet)excelWorkbook.Sheets.Add();
          excelWorksheet.Cells[1, 1] = fes;
          excelWorksheet.Cells[2, 1] = res;
          excelWorksheet.Cells[1,1].Font.Size = 18;
          excelWorksheet.Cells[2, 1].Font.Size = 14;
          int header = 3;
          int index = 1;
          for (int i = 0; i < this.__listView.Columns.Count; i++)
          {
            if (this.__listView.Columns[i].Width != 0)
            {
              excelWorksheet.Cells[header, index] = this.__listView.Columns[i].Text;
              excelWorksheet.Cells[header, index].EntireRow.Font.Bold = true;
              excelWorksheet.Columns[index].NumberFormat = "@";
              excelWorksheet.Cells[header, index].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
              excelWorksheet.Cells[header, index].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
              index++;
            }
            
          }
          header++;
          Microsoft.Office.Interop.Excel.XlRgbColor bed= Microsoft.Office.Interop.Excel.XlRgbColor.rgbRed;
          Microsoft.Office.Interop.Excel.XlRgbColor good = Microsoft.Office.Interop.Excel.XlRgbColor.rgbBlack;
          for (int i = 0; i < this.__listView.Items.Count; i++)
          {
            
            int coln = 1;
            ItemIp itemIp = (ItemIp)this.__listView.Items[i].Tag;
            ListViewItem lvi= this.__listView.Items[i];
            Microsoft.Office.Interop.Excel.XlRgbColor color;
            if (!itemIp.IsTrue)
            {
              color = bed;
            }
            else color = good;
            for (int n = 0; n < this.__listView.Items[i].SubItems.Count; n++)
            {
              if (n == __listView.Columns.Count)
                break;
              if (this.__listView.Columns[n].Width != 0)
              {
                excelWorksheet.Cells[header, coln] = lvi.SubItems[n].Text;
                excelWorksheet.Cells[header, coln].Font.Color = color; 
                coln++;
              }
            }
            header++;
          }
          index = 1;
          for (int i = 0; i < this.__listView.Columns.Count; i++)
          {
            if (this.__listView.Columns[i].Width != 0)
            {
              excelWorksheet.Columns[index+1].EntireColumn.AutoFit();
              index++;
            }
          }
          sfrm.DialogResult = DialogResult.OK;
          object name = excelApp.GetSaveAsFilename(Directory.GetCurrentDirectory(), "Excel Files (*.xls), *.xls");
          if (name.GetType() != typeof(bool))
          {
            excelApp.ActiveWorkbook.SaveAs(name,XlFileFormat.xlWorkbookNormal);
          }
          excelWorkbook.Close();
        }
        return true;
      }
      catch (Exception exp)
      {
        return false;
      }
      finally
      {
        if (excelApp != null)
          excelApp.Quit();
      }
    }
  }
}


