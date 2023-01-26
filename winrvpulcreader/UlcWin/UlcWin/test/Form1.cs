using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.test
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      this.eventDateTimePicker1.ValueChanging += EventDateTimePicker1_ValueChanging;
    }

    private void EventDateTimePicker1_ValueChanging(object sender, CancelEventArgs e)
    {
      if(this.eventDateTimePicker1.Value!=DateTime.Now)
      e.Cancel=true;
    }
  }
}
