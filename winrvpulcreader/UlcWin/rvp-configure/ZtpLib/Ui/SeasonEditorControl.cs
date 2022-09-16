using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Configuration;

namespace Ztp.Ui
{
  public partial class SeasonEditorControl : UserControl
  {
    private ZtpScheduler _value;

    public ZtpScheduler Value
    {
      get { return _value; }
      set
      {
        _value = value;
        Assign();
      }
    }

    public SeasonEditorControl()
    {
      InitializeComponent();
    }

    void Assign()
    {
      lv.Items.Clear();

      if (_value != null)
      {
        int index = 0;
        foreach (ZtpSeason item in _value.Seasons)
        {
          SeasonItem node = new SeasonItem(item, index);
          lv.Items.Add(node);
          index++;
        }
      }

      if (lv.Items.Count > 0)
      {
        lv.Items[0].Selected = true;
      }
      else
      {
        lv_SelectedIndexChanged(null, null);
      }
    }

    public class SeasonSelectedEventArgs
    {
      public ZtpSeason Season { get; set; }
    }

    public event Action<SeasonSelectedEventArgs> SeasonSelected;

    private void lv_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (SeasonSelected != null)
      {
        if (lv.SelectedItems.Count == 0)
        {
          SeasonSelected(new SeasonSelectedEventArgs() { Season = null });
          return;
        }
        SeasonItem stn = lv.SelectedItems[0] as SeasonItem;
        ZtpSeason season = stn?.Season;
        SeasonSelected(new SeasonSelectedEventArgs() { Season = season });
      }
    }

    public bool SeasonAddEnabled
    {
      get { return _value != null && _value.Seasons.Count < ZtpScheduler.MaxSeasonCount; }
    }

    public bool SeasonDeleteEnabled
    {
      get { return lv.SelectedItems.Count > 0; }
    }

    public bool SeasonEditEnabled
    {
      get { return lv.SelectedItems.Count > 0; }
    }

    public bool DoSeasonAdd()
    {
      using (SeasonForm form = new SeasonForm())
      {
        if (form.ShowDialog(this) == DialogResult.OK)
        {
          ZtpSeason season = new ZtpSeason()
          {
            Bound = new ZtpDateItem(form.Begin, form.End)
          };
          _value.Seasons.Add(season);
          SeasonItem item = new SeasonItem(season, lv.Items.Count);
          lv.Items.Add(item);
          item.Selected = true;
          return true;
        }
      }
      return false;
    }

    public bool DoSeasonDelete()
    {
      if (lv.SelectedItems.Count == 0) return false;
      SeasonItem item = (SeasonItem)lv.SelectedItems[0];

      int index = _value.Seasons.IndexOf(item.Season);
      if (index < 0)
        return false;
      if (!Box.Confirm(this, $"Вы действительно хотите удалить сезон '{item.Text}'?")) return false;
      _value.Seasons.Remove(item.Season);
      lv.Items.Remove(item);
      if (lv.Items.Count > 0)
        lv.Items[0].Selected = true;
      else
        lv_SelectedIndexChanged(lv, EventArgs.Empty);
      for (int i = 0; i < lv.Items.Count; i++)
        ((SeasonItem)lv.Items[i]).UpdateText(i);
      return true;
    }

    public bool DoSeasonEdit()
    {
      if (lv.SelectedItems.Count == 0) return false;
      SeasonItem node = (SeasonItem)lv.SelectedItems[0];
      if (node == null) return false;
      using (SeasonForm form = new SeasonForm())
      {
        form.Begin = node.Season.Bound.Begin.Clone();
        form.End = node.Season.Bound.End.Clone();
        if (form.ShowDialog(this) == DialogResult.OK)
        {
          node.Season.Bound.Begin = form.Begin;
          node.Season.Bound.End = form.End;

          for (int i = 0; i < lv.Items.Count; i++)
            ((SeasonItem)lv.Items[i]).UpdateText(i);
          return true;
        }
      }
      return false;
    }
  }


  class SeasonItem : ListViewItem
  {
    public ZtpSeason Season;
    public string Description { get; set; }
    public SeasonItem(ZtpSeason season, int index)
      : base()
    {
      ImageIndex = 0;
      Season = season;
      Text = GetText(index);
    }

    public void UpdateText(int index)
    {
      Text = GetText(index);
    }
    string GetText(int index)
    {
      return $"{ZtpSeason.GetDisplayName(index)} [{Season.Bound}]";
    }
  }

}
