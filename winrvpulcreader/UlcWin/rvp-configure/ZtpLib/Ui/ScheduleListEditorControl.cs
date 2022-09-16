using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Configuration;
using Ztp.Enums;

namespace Ztp.Ui
{
  public partial class ScheduleListEditorControl : UserControl
  {
    private ItemCollection<ZtpTimeRange> _value;

    public ItemCollection<ZtpTimeRange> Value
    {
      get
      {
        return _value;
      }
      set
      {
        _value = value;
        Assign();
      }
    }

    public ZtpSeason Season { get; set; }

    LocationEditorControl.ZtpLocation _ztpLocation;// = new LocationEditorControl.ZtpLocation();
    public LocationEditorControl.ZtpLocation ZtpLocation
    {
      get { return _ztpLocation; }
      set { _ztpLocation = value; }
    }
    public ScheduleListEditorControl()
    {
      InitializeComponent();
    }

    void Assign()
    {
      lv.BeginUpdate();
      try
      {
        lv.Items.Clear();
        if (_value == null) return;
        foreach (ZtpTimeRange interval in _value)
        {
          ScheduleListViewItem item = new ScheduleListViewItem(interval);
          lv.Items.Add(item);
        }
      }
      finally
      {
        lv.EndUpdate();
      }
      if (lv.Items.Count > 0)
        lv.Items[0].Selected = true;
    }

    public void Clear()
    {
      lv.Items.Clear();
    }

    public bool ScheduleAddEnabled
    {
      get
      {
        return _value != null && _value.Count < ZtpScheduler.MaxSheduleCount;
      }
    }

    public bool ScheduleDeleteEnabled
    {
      get
      {
        return _value != null && lv.SelectedItems.Count > 0;
      }
    }

    public bool ScheduleEditEnabled
    {
      get
      {
        return _value != null && lv.SelectedItems.Count > 0;
      }
    }

    public bool ScheduleShowEnabled
    {
      get
      {
        return _value != null && lv.SelectedItems.Count > 0;
      }
    }


    public bool DoScheduleAdd()
    {
      return AddSchedule();
    }

    public void DoScheduleShow()
    {
      if (Season == null)
        return;
      if (lv.SelectedItems.Count == 0) return;

      ScheduleListViewItem item = (ScheduleListViewItem)lv.SelectedItems[0];

      using (ShowTicksForm frm = new ShowTicksForm(Season, item.Interval))
      {
        if (ZtpLocation == null)
        {
          frm.LocationEditorVisible = true;
          frm.ZtpLocation = LocationEditorControl.ZtpLocation.GetDefault();
        }
        else
        {
          frm.LocationEditorVisible = false;
          frm.ZtpLocation = ZtpLocation;
        }
        frm.ShowDialog(this);
      }
    }


    public bool DoScheduleDelete()
    {
      if (lv.SelectedItems.Count == 0) return false;
      ScheduleListViewItem item = (ScheduleListViewItem)lv.SelectedItems[0];
      if (Box.Confirm(this, string.Format("Вы действительно хотите удалить расписание '{0}'?", item.Text)))
      {
        _value.Remove(item.Interval);
        lv.Items.Remove(item);
        if (lv.Items.Count > 0)
          lv.Items[0].Selected = true;
        return true;
      }
      return false;
    }

    public bool DoScheduleEdit()
    {
      if (lv.SelectedItems.Count == 0) return false;
      ScheduleListViewItem item = (ScheduleListViewItem)lv.SelectedItems[0];
      using (ScheduleForm form = new ScheduleForm())
      {
        form.Begin = item.Interval.Begin.Clone();
        form.End = item.Interval.End.Clone();
        if (form.ShowDialog(this) == DialogResult.OK)
        {
          item.Interval.Begin = form.Begin;
          item.Interval.End = form.End;
          item.UpdateText();
          return true;
        }
      }
      return false;
    }


    bool AddSchedule()
    {
      using (ScheduleForm form = new ScheduleForm())
      {
        form.Begin = new ZtpTimeItem()
        {
          Kind = TimeKind.None,
          Time = new ZtpTime(0, 0)
        };
        form.End = new ZtpTimeItem()
        {
          Kind = TimeKind.None,
          Time = new ZtpTime(23, 59)
        };
        if (form.ShowDialog(this) == DialogResult.OK)
        {
          ZtpTimeRange interval = new ZtpTimeRange()
          {
            Begin = form.Begin,
            End = form.End
          };
          _value.Add(interval);
          ScheduleListViewItem listViewItem = new ScheduleListViewItem(interval);
          lv.Items.Add(listViewItem);
          listViewItem.Selected = true;
          return true;
        }
        return false;
      }
    }

    public event EventHandler SelectedIndexChanged;
    private void lv_SelectedIndexChanged(object sender, EventArgs e)
    {
      OnSelectedIndexChanged();
    }

    protected virtual void OnSelectedIndexChanged()
    {
      SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
    }

    class ScheduleListViewItem : ListViewItem
    {
      public ZtpTimeRange Interval;
      public ScheduleListViewItem(ZtpTimeRange interval)
        : base(interval.ToString())
      {
        this.ImageIndex = 0;
        Interval = interval;
      }

      public void UpdateText()
      {
        this.Text = Interval.ToString();
      }
    }

  }
}
