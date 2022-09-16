using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ztp.Configuration;
using Ztp.Enums;

namespace Ztp.Ui
{
  public partial class ScheduleForm : Form
  {
    class Item
    {
      public TimeKind Value;
      public Item(TimeKind value)
      {
        Value = value;
      }
      public override string ToString()
      {
        return Value.ToText();
      }

      public override bool Equals(object obj)
      {
        if (obj == null) return false;
        Item item = obj as Item;
        if (item == null) return false;
        return this.Value.Equals(item.Value);
      }

      public override int GetHashCode()
      {
        return Value.GetHashCode();
      }
    }

    public ZtpTimeItem Begin { get; set; }
    public ZtpTimeItem End { get; set; }
    public ScheduleForm()
    {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
      this.CenterToParent();
      FillComboBoxes();
      dtpRelBegin.Value = TimeToDateTime(Begin.Time);
      dtpRelEnd.Value = TimeToDateTime(End.Time);
      cbRelBegin.SelectedItem = new Item(Begin.Kind);
      cbRelEnd.SelectedItem = new Item(End.Kind);
    }

    void FillComboBoxes()
    {
      List<TimeKind> list = new List<TimeKind>((TimeKind[])Enum.GetValues(typeof(TimeKind)));
      IEnumerable<Item> items = list.Select((k) => new Item(k));
      cbRelBegin.Items.AddRange(items.ToArray());
      cbRelEnd.Items.AddRange(items.ToArray());
    }

    DateTime TimeToDateTime(ZtpTime ztpTime)
    {
      DateTime retVal = DateTime.Now.Date;
      retVal = retVal.AddHours(ztpTime.Hour).AddMinutes(ztpTime.Minute);
      return retVal;
    }

    ZtpTime TimeFromDateTime(DateTime dateTime)
    {
      ZtpTime retVal = new ZtpTime((byte)dateTime.Hour, (byte)dateTime.Minute);
      return retVal;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      Begin.Time = TimeFromDateTime(dtpRelBegin.Value);
      End.Time = TimeFromDateTime(dtpRelEnd.Value);
      DialogResult = DialogResult.OK;
    }

    private void cbRelBegin_SelectedIndexChanged(object sender, EventArgs e)
    {
      Begin.Kind = ((Item)cbRelBegin.SelectedItem).Value;
    }

    private void cbRelEnd_SelectedIndexChanged(object sender, EventArgs e)
    {
      End.Kind = ((Item)cbRelEnd.SelectedItem).Value;
    }

    void ValidateRelative(DateTimePicker picker)
    {
      if ((picker.Value.Hour == 12 && picker.Value.Minute > 0) || (picker.Value.Hour > 12))
      {
        picker.Value = picker.Value.Date.AddHours(12).AddMinutes(0);
        Box.Error(this, "Значение не может быть больше 12 часов");
      }
    }

    private void dtpRelEnd_Validated(object sender, EventArgs e)
    {
      if (((Item)cbRelEnd.SelectedItem).Value != TimeKind.None)
        ValidateRelative(dtpRelEnd);
    }

    private void dtpRelBegin_Validated(object sender, EventArgs e)
    {
      if(((Item)cbRelBegin.SelectedItem).Value != TimeKind.None)
        ValidateRelative(dtpRelBegin);
    }
  }
}
