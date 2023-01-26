using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.Controls.UlcMeterComponet
{
  public class EventDateTimePicker : DateTimePicker
  {
    private DateTime cachedValue;
    private bool reverting;
    public event CancelEventHandler ValueChanging;
    public EventDateTimePicker()
    {
      this.cachedValue = this.Value;
    }

    protected override void OnValueChanged(EventArgs e) {
      if (!this.reverting) {
        CancelEventArgs evargs = new CancelEventArgs(false);
        this.OnValueChanging(evargs);
        if (evargs != null && evargs.Cancel) {
          DateTime value = this.Value;
          this.reverting = true;
          this.Value = this.cachedValue;
        }
        else
        {
          this.cachedValue = Value;
          base.OnValueChanged(e);
        }
        this.reverting = false;
      }
    }

    

    protected void OnValueChanging(CancelEventArgs e) {
      ValueChanging(this, e);
    }




  }
}
