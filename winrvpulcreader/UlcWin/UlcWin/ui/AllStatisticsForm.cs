using InterUlc.Db;
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
  public partial class AllStatisticsForm : Form
  {
    DbReader __db;
    public AllStatisticsForm(DbReader db)
    {
      __db = db;
      InitializeComponent();
      LoadStatistic();
      this.Shown += TestForm_Shown;
      this.usrUlcChartCtrl1.monthViewClose += UsrUlcChartCtrl1_monthViewClose;
      this.usrUlcChartCtrl1.SetValue(this.__db.__connection);
    }

   

    public void LoadStatistic()
    {
      using (SimpleWaitForm sfrm = new SimpleWaitForm())
      {
        sfrm.RunAction(new Action(() =>
        {
          sfrm.SetLabelText("Формирую статистику по всем объектам");
          try
          {
            UlcStatistic ulcStatistic = __db.GetStatistic();
            this.lblAll.Text = ulcStatistic.All.ToString();
            this.lblAllUlc.Text = ulcStatistic.AllUlc.ToString();
            this.lblAllRvp.Text = ulcStatistic.AllRvp.ToString();
            this.lblAllNot.Text = ulcStatistic.NetErrorAll.ToString();
            this.lblAllTvpNot.Text = ulcStatistic.NetErrorRvp.ToString();
            this.lblAllUlcNot.Text = ulcStatistic.NetErrorUlc.ToString();
            this.lblFirstOrSecond.Text = ulcStatistic.AllUlcFirstOrTwo.ToString();
            this.lblFirstOrSecondNetNot.Text = ulcStatistic.AllUlcFirstOrTwoOnNet.ToString();
            this.lblFirstOrSecondRSNotTrue.Text = ulcStatistic.AllUlcFirstOrTwoRsNotTrue.ToString();
            this.lblThreeOrFour.Text = ulcStatistic.AllUlcThreeOrFour.ToString();
            this.lblThreeOrFourNotTrue.Text = ulcStatistic.AllUlcThreeOrFourOnNet.ToString();
            this.lblThreeOrFourRSNotTrue.Text = ulcStatistic.AllUlcThreeOrFourRsNotTrue.ToString();
            this.lblFive.Text = ulcStatistic.AllUlcFive.ToString();
            this.lblFiveNotTrue.Text = ulcStatistic.AllUlcFiveOnNet.ToString();
            this.lblFiveRSNotTrue.Text = ulcStatistic.AllUlcFiveRsNotTrue.ToString();
            this.lblAllNotRs.Text = ulcStatistic.AllErrorRs.ToString();
            this.lblAllGsm.Text = ulcStatistic.AllErrorGsm.ToString();
            this.lblUlcRs.Text = ulcStatistic.UlcErrorRs.ToString();
            this.lblUlcGsm.Text = ulcStatistic.UlcErrorGsm.ToString();
            this.lblRvpRs.Text = /*ulcStatistic.RvpErrorRs.ToString();*/"нет";
            this.lblRvpGsm.Text = ulcStatistic.RvpErrorGsm.ToString();
            this.lblFirstOrSecondLowGsm.Text = ulcStatistic.AllUlcFirstOrTwoGsm.ToString();
            this.lblFirstOrSecondVers.Text = ulcStatistic.AllUlcFirstOrTwoVersion.ToString();
            this.lblThreeOrFourGsm.Text = ulcStatistic.AllUlcThreeOrFourGsm.ToString();
            this.lblThreeOrFourVers.Text = ulcStatistic.AllUlcThreeOrFourVersion.ToString();
            this.lblFiveGsm.Text = ulcStatistic.AllUlcFiveGsm.ToString();
            this.lblFiveVers.Text = ulcStatistic.AllUlcFiveVersion.ToString();
            this.lblRvp.Text = ulcStatistic.AllCRvp.ToString();
            this.lblUusi.Text = ulcStatistic.AllUusi.ToString();
            this.lblCRvpNotNet.Text = (ulcStatistic.AllCRvp - ulcStatistic.AllCRvpNet).ToString();
            this.lblUusiNotNet.Text = (ulcStatistic.AllUusi - ulcStatistic.AllUusiNet).ToString();
            if (ulcStatistic.All > 0)
            {
              double count = (double)((100 * ((double)ulcStatistic.NetErrorAll + (double)ulcStatistic.AllErrorRs)) / (double)ulcStatistic.All);
              if (count > 5)
              {
                this.lblAllPercent.ForeColor = Color.Salmon;
              }
              else
              {
                this.lblAllPercent.ForeColor = Color.FromArgb(124, 180, 136);
              }
              this.lblAllPercent.Text = Math.Round(count,2).ToString() + "%";
            }
            else
              this.lblAllPercent.Text = "0";

          }
          catch (Exception)
          {

            throw;
          }
          sfrm.DialogResult = DialogResult.OK;
        }));
        sfrm.ShowDialog();
      }
    }

    private void TestForm_Shown(object sender, EventArgs e)
    {

    }

    private void UsrUlcChartCtrl1_monthViewClose()
    {
      this.usrUlcChartCtrl1.Visible = false;
      this.roundBorderPanel1.Visible = true;
      this.roundBorderPanel5.Visible = true;
    }

    private void btnMonthView_Click(object sender, EventArgs e)
    {
      this.roundBorderPanel1.Visible = false;
      this.roundBorderPanel5.Visible = false;

      this.usrUlcChartCtrl1.Visible = true;
      //using (AllStatMonthView frm = new AllStatMonthView(this.__db.__connection))
      //{
      //frm.ShowDialog();
      //}
    }
  }
}
