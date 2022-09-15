using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.Statistics;

namespace UlcWin.ui
{
  public partial class UsrStatResControl : UserControl
  {
    string __header = "Name object";

    public UsrStatResControl()
    {
      InitializeComponent();
    }

    public string HeaderText
    {
      get { return __header; }
      set {
        __header = value;
        this.lblHeader.Text = value;
      }
    }

    StatisticRes __statisticRes = null;

    public StatisticRes ResStatistiscs
    {
      get
      {
        return __statisticRes;
      }

      set
      {
        __statisticRes = value;
        //this.lblAll.Text = this.__statisticRes.All.ToString();
      }
    }

    public void AddItemStat(StatisticRes statisticRes) {
     
      UsrStatComponent statComponent = new UsrStatComponent() { Dock = DockStyle.Fill, InitColor = Color.FromArgb(255, 128, 0) };
      
      statComponent.lblAll.Text = statisticRes.All.ToString();
      statComponent.lblAllNot.Text = (statisticRes.All-(statisticRes.AllRvpNet+ statisticRes.AllUlcNet)).ToString();
      statComponent.lblAllGsm.Text = (statisticRes.AllUlcBadSignal + statisticRes.AllRvpBadSignal).ToString();
      statComponent.lblAllNotRs.Text = statisticRes.AllUlcRs.ToString();
      this.tableLayoutPanel1.Controls.Add(statComponent);
      UsrStatComponent statComponent1 = new UsrStatComponent() { Dock = DockStyle.Fill, InitColor = Color.Teal };
      statComponent1.lblHeader.Text += " ULC 02";
      statComponent1.lblAll.Text = statisticRes.AllUlc.ToString();
      statComponent1.lblAllNot.Text = (statisticRes.AllUlc-statisticRes.AllUlcNet).ToString();
      statComponent1.lblAllGsm.Text = statisticRes.AllUlcBadSignal.ToString();
      statComponent1.lblAllNotRs.Text = statisticRes.AllUlcRs.ToString();
      this.tableLayoutPanel1.Controls.Add(statComponent1);
      UsrStatComponent statComponent2 = new UsrStatComponent() { Dock = DockStyle.Fill, InitColor = Color.CornflowerBlue };
      statComponent2.lblHeader.Text += "РВП-18";
      statComponent2.lblAll.Text = statisticRes.AllRvp.ToString();
      statComponent2.lblAllNot.Text = (statisticRes.AllRvp - statisticRes.AllRvpNet).ToString();
      statComponent2.lblAllGsm.Text = statisticRes.AllRvpBadSignal.ToString();
      statComponent2.lblAllNotRs.Text = "0";
      this.tableLayoutPanel1.Controls.Add(statComponent2);
      UsrPercentControl usrPercentControl = new UsrPercentControl() { Dock = DockStyle.Fill, InitColor = Color.FromArgb(0, 192, 192) };
      long cnt_err_net = statisticRes.All - (statisticRes.AllRvpNet + statisticRes.AllUlcNet);
      if (statisticRes.All > 0)
      {
        double cnt = (double)((100 * ((double)cnt_err_net + (double)statisticRes.AllUlcRs)) / (double)statisticRes.All);
        double count = Math.Round(cnt, 2);
        if (count > 5)
        {
          usrPercentControl.lblPercent.ForeColor = Color.Salmon;
        }
        else
        {
          usrPercentControl.lblPercent.ForeColor = Color.FromArgb(124, 180, 136);
        }
        usrPercentControl.lblPercent.Text = count.ToString();
      }
      else {
        usrPercentControl.lblPercent.Text = "0";
      }
      this.tableLayoutPanel1.Controls.Add(usrPercentControl);
    }
  }
}
