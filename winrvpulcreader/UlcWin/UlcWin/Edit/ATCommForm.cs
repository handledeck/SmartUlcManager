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
using UlcWin.ui;
using static UlcWin.LoadForm;

namespace UlcWin.Edit
{
  
  public partial class ATCommForm : Form
  {
    ItemIp __itemIp = null;
    GetConnectionDelegate __connection = null;
    public ATCommForm(GetConnectionDelegate connection,  ItemIp item)
    {
      InitializeComponent();
      this.__itemIp = item;
      this.__connection = connection;
      this.cbAtCommand.Items.Add("CONFIG?");
      this.cbAtCommand.Items.Add("UARTR");
      this.cbAtCommand.Items.Add("###AT#MONI");
      this.cbAtCommand.Items.Add("###AT#CEER");
      this.cbAtCommand.Items.Add("###AT+CGREG?");
    }

    private void SaveAt() {
      if (!this.cbAtCommand.Items.Contains(this.cbAtCommand.Text))
      {
        this.cbAtCommand.Items.Add(this.cbAtCommand.Text);
      }
    }

    private void btnAtOk_Click(object sender, EventArgs e)
    {

      using (SimpleWaitForm sfrm = new SimpleWaitForm())
      {
        sfrm.RunAction(new Action(() =>
        {
          TcpClient client = null;
          try
          {
            client = this.__connection(__itemIp.Ip, 10251);
            if (client == null)
              throw new Exception(string.Format("Ошибка подключения к контроллеру:{0}", __itemIp.Name));
            NetworkStream stream = client.GetStream();
            stream.ReadTimeout = 10000;
           
            IAsyncResult result= this.BeginInvoke(new Action(() =>
            {
              string sdata = string.Empty;
              //if (this.chBoxModem.Checked)
                sdata = string.Format(/*"###AT{0}\r"*/"{0}\r", this.cbAtCommand.Text.Trim());
              //else {
              //  sdata = string.Format("###AT{0}\r", this.cbAtCommand.Text);
              //}
              this.richTextBox1.AppendText("----------------------------------\r\n");
              this.richTextBox1.AppendText(string.Format("запрос команды {0}\r\n", this.cbAtCommand.Text.ToUpper()));
              byte[] rdata = new byte[1024];
              byte[] bsdata = System.Text.ASCIIEncoding.ASCII.GetBytes(sdata);
              stream.Write(bsdata, 0, bsdata.Length);
              int len = stream.Read(rdata, 0, 1024);
              string rsdata = System.Text.ASCIIEncoding.ASCII.GetString(rdata, 0, len);//.Replace("\r\n", string.Empty); ;
              rsdata = rsdata.TrimStart(new char[] { '\r', '\n' });
              rsdata = rsdata.TrimEnd(new char[] { '\r', '\n' });
              this.richTextBox1.Focus();
              this.richTextBox1.AppendText(rsdata + "\r\n");
              this.richTextBox1.AppendText("----------------------------------");
              this.SaveAt();
            }));
            result.AsyncWaitHandle.WaitOne();
            sfrm.DialogResult = DialogResult.OK;
          }
          catch (Exception exp)
          {
            MessageBox.Show(exp.Message);
          }
          finally
          {
            if (client != null)
              client.Close();
            sfrm.DialogResult = DialogResult.Abort;
          }
        }));
        sfrm.ShowDialog();
      }
    }
      

    private void cbAtCommand_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)13)
      {
        this.SaveAt();
        btnAtOk_Click(null, null);
      }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      this.richTextBox1.Clear();
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
      //if (this.__netStream != null)
        //this.__netStream.Close();
    }

    private void cbAtCommand_SelectedIndexChanged(object sender, EventArgs e)
    {
      btnAtOk_Click(null, null);
    }

    //private void chBoxModem_CheckedChanged(object sender, EventArgs e)
    //{
    //  CheckBox checkBox = (CheckBox)sender;
    //  if (checkBox.Checked)
    //  {
    //    lblAT.Enabled = true;
    //  }
    //  else {
    //    lblAT.Enabled = false;
    //  }
    //}
  }
}
