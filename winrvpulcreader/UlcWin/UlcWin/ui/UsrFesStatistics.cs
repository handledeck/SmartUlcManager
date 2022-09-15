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
  public partial class UsrFesStatistics : UserControl
  {
    List<StatisticRes> __lstStatisticRes = null;
    long __all = 0;
    long __all_ulc = 0;
    long __all_rvp = 0;
    long __all_net = 0;
    long __all_rs = 0;
    long __all_signal = 0;
    long __all_ulc_net = 0;
    long __all_ulc_rs = 0;
    long __all_ulc_signal = 0;
    long __all_rvp_net = 0;
    long __all_rvp_signal = 0;
    public UsrFesStatistics()
    {
      InitializeComponent();
      
    }

    

    void ReInit() {
       __all = 0;
       __all_net = 0;
       __all_rs = 0;
       __all_signal = 0;
      __all_ulc = 0;
      __all_ulc_net = 0;
      __all_ulc_rs = 0;
      __all_ulc_signal = 0;
      __all_rvp = 0;
      __all_rvp_net = 0;
      __all_rvp_signal = 0;
      //IAsyncResult result = this.BeginInvoke(new Action(() =>
      //{
      //  this.tblResControl.RowStyles.Clear();
      //  this.tblResControl.RowCount = 0;
      //  this.tblResControl.Controls.Clear();
      //}));
      //result.AsyncWaitHandle.WaitOne();
    }



    void SetStatistics()
    {
      this.tblResControl.RowStyles.Clear();
      this.tblResControl.RowCount = 0;
      this.tblResControl.Controls.Clear();

      if (__lstStatisticRes != null)
      {
        foreach (StatisticRes item in __lstStatisticRes)
        {
          __all += item.All;
          __all_ulc += item.AllUlc;
          __all_rvp += item.AllRvp;
          __all_net += item.AllUlcNet+item.AllRvpNet;
          __all_rs += item.AllUlcRs;
          __all_signal += (item.AllRvpBadSignal+item.AllUlcBadSignal);
          __all_ulc_net += item.AllUlcNet;
          __all_ulc_rs += item.AllUlcRs;
          __all_ulc_signal += item.AllUlcBadSignal;
          __all_rvp_net += item.AllRvpNet;
          __all_rvp_signal += item.AllRvpBadSignal;
          usrStatAll.lblAll.Text = __all.ToString(); ;
          usrStatAll.lblAllNot.Text = (__all-(__all_net)).ToString();
          usrStatAll.lblAllNotRs.Text = __all_rs.ToString();
          usrStatAll.lblAllGsm.Text = __all_signal.ToString();
          
          usrStatAllUlc.lblHeader.Text="Активных контроллеров ULC 02"; 
          usrStatAllUlc.lblAll.Text = __all_ulc.ToString(); 
          usrStatAllUlc.lblAllNot.Text = (__all_ulc - (__all_ulc_net)).ToString();
          usrStatAllUlc.lblAllNotRs.Text = __all_ulc_rs.ToString();
          usrStatAllUlc.lblAllGsm.Text = __all_ulc_signal.ToString();

          usrStatAllRvp.lblHeader.Text = "Активных контроллеров РВП-18";
          usrStatAllRvp.lblAll.Text = __all_rvp.ToString();
          usrStatAllRvp.lblAllNot.Text = (__all_rvp - (__all_rvp_net)).ToString();
          usrStatAllRvp.lblAllNotRs.Text = "0";
          usrStatAllRvp.lblAllGsm.Text = __all_rvp_signal.ToString();
          double count = 0;
          if (__all != 0)
          {
            double cnt = (double)((100 * ((double)(__all - (__all_net)) + (double)__all_rs)) / (double)__all);
            count = Math.Round(cnt, 2);
            if (count > 5)
            {
              usrAllPercent.lblPercent.ForeColor = Color.Salmon;
            }
            else
            {
              usrAllPercent.lblPercent.ForeColor = Color.FromArgb(124, 180, 136);
            }
          }
         
          usrAllPercent.lblPercent.Text = count.ToString();

          this.tblResControl.RowCount += 1;
          UsrStatResControl ctl = new UsrStatResControl() { Dock = DockStyle.Fill,HeaderText=item.ResName };
          ctl.AddItemStat(item);
          ////ctl.MinimumSize = new Size(100, 100);
          ////Label lbl = new Label() { Text = "1111" + i.ToString(), Font = this.label10.Font, Dock = DockStyle.Fill };
          //this.tblResControl.Controls.Add(ctl);
          //UsrStatResControl ctl1 = new UsrStatResControl() { Dock = DockStyle.Fill, HeaderText = item.ResName };
          //ctl.AddItemStat(item, Color.Blue);
          ////ctl.MinimumSize = new Size(100, 100);
          ////Label lbl = new Label() { Text = "1111" + i.ToString(), Font = this.label10.Font, Dock = DockStyle.Fill };
          //this.tblResControl.Controls.Add(ctl1);
          //UsrStatResControl ctl2 = new UsrStatResControl() { Dock = DockStyle.Fill, HeaderText = item.ResName };
          //ctl.AddItemStat(item, Color.Beige);
          ////ctl.MinimumSize = new Size(100, 100);
          ////Label lbl = new Label() { Text = "1111" + i.ToString(), Font = this.label10.Font, Dock = DockStyle.Fill };
          this.tblResControl.Controls.Add(ctl);
        }
      }
      //this.lblAll.Text =  __all.ToString(); ;
      //this.lblAllNot.Text = (__all-(__all_net)).ToString();
      //this.lblAllNotRs.Text = __all_rs.ToString();
      //this.lblAllGsm.Text = __all_signal.ToString();
      
      //this.lblAllUlc.Text = __all_ulc.ToString();
      //this.lblAllUlcNot.Text = (__all_ulc - __all_ulc_net).ToString();
      //this.lblUlcRs.Text = __all_ulc_rs.ToString();
      //this.lblUlcGsm.Text = __all_ulc_signal.ToString();

      //this.lblAllRvp.Text = __all_rvp.ToString();
      //this.lblAllTvpNot.Text = (__all_rvp-__all_rvp_net).ToString();
      //this.lblRvpRs.Text = "0";
      //this.lblRvpGsm.Text = __all_rvp_signal.ToString();
      //this.tblResControl.RowStyles.Clear();
      //this.tblResControl.RowCount = 0;
      //this.tblResControl.BackColor = Color.White;
   
      
     
    }



    public List<StatisticRes> Value
    {
      get { return __lstStatisticRes; }
      set
      {
        this.__lstStatisticRes = value;
        ReInit();
        this.SetStatistics();
      }
    }

        private void roundBorderPanel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
