using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.DB;
using UlcWin.Drivers;
using static UlcWin.Drivers.EnMera102;

namespace UlcWin.ui
{
  public delegate TcpClient GetConnection(string host, int port);
  public partial class MeterForm : Form
  {
    
    ItemIp __itemIp = null;
    List<Controls.UlcMeterComponet.MeterInfo> __meterInfos = null;
    GetConnection __getConnection = null;
    public MeterForm(ItemIp itemIp, List<Controls.UlcMeterComponet.MeterInfo> meterInfos, GetConnection getConnection)
    {
      this.__itemIp = itemIp;
      __meterInfos = meterInfos;
      this.__getConnection = getConnection;

      InitializeComponent();
      this.pictureBox1.Visible = false;
      this.lblObject.Text = itemIp.Name + ":" + itemIp.Ip;
      foreach (var item in __meterInfos)
      {
        ListViewItem its = this.lstViewMeter.Items.Add(item.meter_type);
        its.SubItems.Add(item.meter_factory);
        its.SubItems.Add("----");

      }
    }

    void ReadMeterValue() {
      using (SimpleWaitForm si=new SimpleWaitForm())
      {
        si.RunAction(new Action(() =>
        {
          
          si.DialogResult = DialogResult.OK;
        }));
        si.ShowDialog();
      }
    }
    void run() {
     
    }
    private void button1_Click(object sender, EventArgs e)
    {
      ListView lstCopy = new ListView();
      lstCopy.Items.AddRange((from ListViewItem item in this.lstViewMeter.Items
                              select (ListViewItem)item.Clone()).ToArray());
      this.pictureBox1.Visible = true;
      this.btnRun.Enabled = false;
      this.btnCancel.Enabled = false;
      Task tsk = new Task(new Action(() =>
      {
        
        TcpClient client = this.__getConnection(this.__itemIp.Ip, 10250);
        if (client != null)
        {
          foreach (ListViewItem item in lstCopy.Items)
          {
            try
            {
              if (item.SubItems[0].Text.Contains("СЕ102") || item.SubItems[0].Text.Contains("CE102"))
              {
                string num = item.SubItems[1].Text;
                Exception exp = null;
                float? ds= EnMera102.GetSumDayValue(num, client, out exp);
                if (exp == null) {
                  item.SubItems[2].Text = (ds.Value / 100).ToString();
                }
                else throw new Exception("ошибка получения данных");
              }
              else if (item.SubItems[0].Text.Contains("СЕ318") || item.SubItems[0].Text.Contains("CE318")) {
                string num = item.SubItems[1].Text;
                float value = 0;
                if(!EnMera318BY.GetValue( EnMera318Fun.EnergyStartDay,num,client,10000,out value))
                  throw new Exception("ошибка получения данных");
                item.SubItems[2].Text = value.ToString();
              }
              else if (item.SubItems[0].Text.Contains("СС") || item.SubItems[0].Text.Contains("СС"))
              {
                string num = item.SubItems[1].Text;
                if (client == null)
                  throw new Exception("Ошибка открытия соединения");
                Exception ex = null;
                float? val=Granelectro.GetSumValue( EnGranSys.ACCUMULATED_ENERGY_DAY,num, client, out ex);
                if (!val.HasValue)
                {
                  item.SubItems[2].Text = "ошибка получения данных";
                }
                else
                  item.SubItems[2].Text = val.ToString();
              }
              else
              {
                throw new Exception("Счетчик не поддерживается");
              }
            }

            catch (Exception ex)
            {
              item.SubItems[2].Text = ex.Message;
              //MessageBox.Show(ex.Message, "Ошибка опроса", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


          }
          //si.DialogResult = DialogResult.OK;
        }
        else
        {
          MessageBox.Show("Ошибка соединения с контроллером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        if (client != null)
        {
          client.Close();
        }
        IAsyncResult res = this.BeginInvoke(new Action(() =>
         {
           this.lstViewMeter.Items.Clear();
           this.lstViewMeter.Items.AddRange((from ListViewItem item in lstCopy.Items
                                             select (ListViewItem)item.Clone()).ToArray());
           this.pictureBox1.Visible = false;
           this.btnRun.Enabled = true;
           this.btnCancel.Enabled = true;
         }));
        res.AsyncWaitHandle.WaitOne();
      }));

      tsk.Start();
      //tsk.Wait();
      
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
   

        ControlPaint.DrawBorder(e.Graphics, ((Control)sender).ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid);
       
     
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
