using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.Fota;
using static UlcWin.LoadForm;

namespace UlcWin.ui
{
  public partial class PingForm : Form
  {
    ListViewItem __lvItem;
    ItemIp __itemIp = null;
    public PingForm(ListViewItem lvItem)
    {
      InitializeComponent();
      this.__lvItem = lvItem;
      __itemIp = (ItemIp)this.__lvItem.Tag;
      this.richTextBox1.AppendText(string.Format("Начало пингования:{0}\r\n",__itemIp.Ip));
    }

    private void ping_Shown_1(object sender, EventArgs e)
    {

      Thread tr = new Thread(new ThreadStart(() => {
        try
        {
        while (true)
        {
          Ping ping = new Ping();
          PingReply reply = ping.Send(this.__itemIp.Ip);
          if (reply.Status == IPStatus.Success)
          {
            this.BeginInvoke(new Action(() => {
              this.richTextBox1.AppendText(string.Format("Ответ от {0}: число байт={1} время={2}мс TTL={3}\r\n",
             reply.Address, reply.Buffer.Length, reply.RoundtripTime, reply.Options.Ttl));

            }));
          }
          else
          {
            this.BeginInvoke(new Action(() => {
              this.richTextBox1.AppendText("Превышен интервал ожидания запроса\r\n");
            }));
          }
          Thread.Sleep(1000);
        }
        }
        catch (Exception)
        {
        }
      }));
      tr.Start();
    }
  }
}
