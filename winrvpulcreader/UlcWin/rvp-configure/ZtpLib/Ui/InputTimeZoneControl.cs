using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Utils;

namespace Ztp.Ui
{
  public partial class InputTimeZoneControl : UserControl
  {
    public InputTimeZoneControl()
    {
      InitializeComponent();
      FillList();
    }

    void FillList()
    {
      IEnumerable<TimeZoneInfo> timeZones = TimeZoneInfoUtils.GetSystemTimeZones();
      foreach (TimeZoneInfo timeZone in timeZones)
      {
        comboBox1.Items.Add(new TimeZoneItem(timeZone));
      }
      comboBox1.SelectedIndex = 0;
    }

    public int CaptionWidth
    {
      get { return Convert.ToInt32(tableLayoutPanel.ColumnStyles[0].Width); }
      set { tableLayoutPanel.ColumnStyles[0].Width = value; }
    }

    public string Caption
    {
      get { return label1.Text; }
      set { label1.Text = value; }
    }

    public sbyte Value
    {
      get
      {
        if (comboBox1.SelectedItem == null) return 0;
        return Convert.ToSByte(((TimeZoneItem) comboBox1.SelectedItem).Tzi.BaseUtcOffset.Hours);
      }
      set
      {
        for (int i = 0; i < comboBox1.Items.Count; i++)
        {
          TimeZoneItem tzi = (TimeZoneItem) comboBox1.Items[i];
          if (tzi.Tzi.BaseUtcOffset.Hours == value)
          {
            comboBox1.SelectedIndex = i;
            break;
          }
        }
      }
    }
    class TimeZoneItem
    {
      private readonly TimeZoneInfo _tzi;
      public TimeZoneItem(TimeZoneInfo tzi)
      {
        _tzi = tzi;
      }

      public TimeZoneInfo Tzi
      {
        get
        {
          return _tzi;
        }
      }

      public override string ToString()
      {
        return Tzi.ToString();
      }
    }

    public event EventHandler ValueChanged;
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      OnValueChanged();
    }

    protected virtual void OnValueChanged()
    {
      ValueChanged?.Invoke(this, EventArgs.Empty);
    }
  }
}
