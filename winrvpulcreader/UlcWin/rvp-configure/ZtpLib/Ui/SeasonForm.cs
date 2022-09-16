using System;
using System.ComponentModel;
using System.Windows.Forms;
using Ztp.Configuration;
using Ztp.Enums;

namespace Ztp.Ui
{
  public partial class SeasonForm : Form
  {

    class MonthItem
    {
      static Type _type = typeof(Month);

      public readonly Month Month;
      public MonthItem(Month month)
      {
        Month = month;
      }

      public override string ToString()
      {
        return Month.GetFieldAttribute().DisplayName;
      }

      public override bool Equals(object obj)
      {
        if (obj == null) return false;
        MonthItem item = obj as MonthItem;
        if (item == null) return false;
        return Month.Equals(item.Month);
      }

      public override int GetHashCode()
      {
        return Month.GetHashCode();
      }
    }

    public ZtpDate Begin { get; set; }
    public ZtpDate End { get; set; }
    public string SeasonName { get; set; }
    public string Description { get; set; }

    public SeasonForm()
    {
      InitializeComponent();
      Begin = new ZtpDate(Month.Jan, 1);
      End = new ZtpDate(Month.Dec, 31);
      FillMonthComboBoxes();
    }

    protected override void OnLoad(EventArgs e)
    {
      this.CenterToParent();
      MonthItem begin = new MonthItem(Begin.Month);
      cbMonthBegin.SelectedItem = begin;
      MonthItem end = new MonthItem(End.Month);
      cbMonthEnd.SelectedItem = end;
    }


    void FillMonthComboBoxes()
    {
      Month[] arr = (Month[])Enum.GetValues(typeof(Month));
      foreach (Month month in arr)
      {
        MonthItem item = new MonthItem(month);
        cbMonthBegin.Items.Add(item);
        cbMonthEnd.Items.Add(item);
      }
    }

    int[] GetDaysForMonth(Month month)
    {
      int count = month.GetFieldAttribute().CountOfDay;
      int[] retVal = new int[count];
      for (int i = 0; i < count; i++)
        retVal[i] = i + 1;
      return retVal;
    }
    private void cbMonthBegin_SelectedIndexChanged(object sender, EventArgs e)
    {
      ChangeMonth(Begin);
    }

    private void cbDayBegin_SelectedIndexChanged(object sender, EventArgs e)
    {
      ChangeDay(cbDayBegin);
    }

    private void cbMonthEnd_SelectedIndexChanged(object sender, EventArgs e)
    {
      ChangeMonth(End);
    }

    private void cbDayEnd_SelectedIndexChanged(object sender, EventArgs e)
    {
      ChangeDay(cbDayEnd);
    }

    void ChangeDay(ComboBox sender)
    {
      if (sender.SelectedItem == null) return;
      ZtpDate date = sender == cbDayBegin ? Begin : End;
      date.Day = (byte)(sender.SelectedIndex + 1);
    }

    void ChangeMonth(ZtpDate date)
    {
      ComboBox sender = date == Begin ? cbMonthBegin : cbMonthEnd;
      ComboBox cbDay = date == Begin ? cbDayBegin : cbDayEnd;

      if (sender.SelectedItem == null) return;
      MonthItem item = (MonthItem)sender.SelectedItem;
      date.Month = item.Month;

      cbDay.Items.Clear();
      int[] days = GetDaysForMonth(item.Month);
      foreach (int day in days)
        cbDay.Items.Add(day);

      if (date.Day <= days.Length)
        cbDay.SelectedIndex = date.Day - 1;
      else
        cbDay.SelectedIndex = 0;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }

  }
}
