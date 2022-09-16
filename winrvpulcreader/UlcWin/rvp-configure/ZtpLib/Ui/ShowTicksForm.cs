using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Configuration;
using Ztp.Enums;
using Ztp.Utils;

namespace Ztp.Ui
{
  public partial class ShowTicksForm : Form
  {
    private readonly ZtpSeason _season;
    private readonly ZtpTimeRange _range;
    public ShowTicksForm(ZtpSeason season, ZtpTimeRange range)
    {
      if (season == null) throw new ArgumentNullException(nameof(season));
      if (range == null) throw new ArgumentNullException(nameof(range));
      _season = season;
      _range = range;
      InitializeComponent();
      Text = $"Срабатывание расписиния. Сезон с {_season.Bound.Begin} по {_season.Bound.End}";
    }

    public bool LocationEditorVisible
    {
      get { return locationEditorControl.Visible; }
      set { locationEditorControl.Visible = value; }
    }

    public LocationEditorControl.ZtpLocation ZtpLocation
    {
      get { return locationEditorControl.Value; }
      set { locationEditorControl.Value = value; }
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      ShowTicks();
    }

    Month GetMonth(DateTimePair tuple)
    {
      if (tuple.Item1 == null && tuple.Item2 == null)
        throw new ArgumentException();
      if (tuple.Item1.HasValue)
        return (Month)tuple.Item1.Value.Month;
      return (Month)tuple.Item2.Value.Month;
    }

    void ShowTicks()
    {
      listView.BeginUpdate();
      try
      {
        List<DateTimePair> list;
        list = ZtpScheduler.CalcTicks(_season, _range, ZtpLocation.TimeZone, ZtpLocation.Latitude,
          ZtpLocation.Longitude);

        listView.Items.Clear();
        ListViewGroup group = null;
        foreach (DateTimePair tuple in list)
        {
          Month month = GetMonth(tuple);
          string groupName = month.ToString();
          if (group == null || group.Name != groupName)
          {
            group = new ListViewGroup(month.ToString(), month.GetFieldAttribute().DisplayName);
            listView.Groups.Add(group);
          }

          string first = tuple.Item1.HasValue ? tuple.Item1.Value.ToString("dd MMM yyyy HH:mm") : "Нет";
          string second = tuple.Item2.HasValue ? tuple.Item2.Value.ToString("dd MMM yyyy HH:mm") : "Нет";

          ListViewItem item = new ListViewItem(new string[] {first, second}, group);
          item.ImageIndex = 0;
          listView.Items.Add(item);
        }
        listView.ShowGroups = true;
      }
      catch (Exception ex)
      {
        Box.Error(this, ex);
      }
      finally
      {
        listView.EndUpdate();
      }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
      ShowTicks();
    }
  }
}
