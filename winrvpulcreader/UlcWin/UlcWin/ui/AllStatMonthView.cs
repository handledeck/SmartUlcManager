using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.ui
{
  public partial class AllStatMonthView : Form
  {
    public AllStatMonthView(string connection)
    {
      InitializeComponent();
      this.usrUlcChartCtrl1.SetValue(connection);
    }
  }
}
