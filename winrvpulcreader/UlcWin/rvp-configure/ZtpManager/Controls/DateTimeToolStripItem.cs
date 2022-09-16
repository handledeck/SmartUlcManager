using System;
using System.Windows.Forms;

namespace ZtpManager.Controls
{
  class DateTimeToolStripItem : ToolStripControlHost
  {
    public DateTimeToolStripItem()
      :base(new DateTimePicker())
    {
      this.Picker.Width = 150;
      this.Picker.CustomFormat = "dd.MM.yyyy HH:mm:ss";
      this.Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
    }

    public DateTimePicker Picker
    {
      get
      {
        return base.Control as DateTimePicker;
      }
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      if (PressEnter != null)
        PressEnter(this, EventArgs.Empty);
    }

    public event EventHandler PressEnter;
  }

}
