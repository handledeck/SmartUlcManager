using InterUlc.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.DB;
using UlcWin.Fota;
using UlcWin.win;
using Ztp.Configuration;
using Ztp.Enums;
using Ztp.Protocol;
using Ztp.Ui;
using static UlcWin.LoadForm;
using WaitForm = UlcWin.win.WaitForm;

namespace UlcWin.ui
{

  
  public partial class MultiSettingsForm : Form
  {
    List<ListViewItem> __items_checked = null;
    GetConnectionDelegate __getConnection = null;
    string __pwd = string.Empty;
    string __command = string.Empty;
    DbReader __db = null;
    string __node_full_path = string.Empty;
    public MultiSettingsForm(List<ListViewItem> items_checked, GetConnectionDelegate getConnection,
      DevType device, DbReader db, string node_full_path)
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
      this.__items_checked = items_checked;
      this.__getConnection = getConnection;
      __db = db;
      this.partitionConfigEditorControl1.ViewConfigByDevType(device);// Ztp.Enums.DevType.RVP18);
      this.Value = new ZtpConfig();
      this.__node_full_path = node_full_path;
      //this.partitionConfigEditorControl1.Value.TimeZone = 3;
      
    }

    ///ZtpConfig __value;
    public ZtpConfig Value
    {
      get
      {
        return this.partitionConfigEditorControl1.Value;
      }
      set {
        this.partitionConfigEditorControl1.Value = value;
      }
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      if (this.partitionConfigEditorControl1.CheckedFlags.Count == 0)
      {
        this.btnOk.Enabled = false;
        this.label1.Text = "Не выбрано ни одного элемента для записи";
        //this.checkBox1.Visible = false;
      }
      else
      {

        //this.checkBox1.Visible = true;
        this.btnOk.Enabled = true;
        this.Value = this.partitionConfigEditorControl1.Value;
        this.label1.Text = "После изменения настроек, необходима перезагрузка";
        //string xx= ZtpProtocol.SerializeZtpConfig(this.Value);

        // System.Diagnostics.Debug.WriteLine(xx);
      }
    }


    public bool CheckSessionPassword()
    {

      using (PasswordForm frm = new PasswordForm())
      {
        frm.Value = __pwd;
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          this.__pwd = frm.Value;
          return true;

        }
      }
      return false;
    }

    int __count_update = 0;
    void CallBackTaskEnd(Task task)
    {

      lock (this.__lstTaskRunner)
      {
        bool rm = this.__lstTaskRunner.Remove(task);
        if (__wForm != null)
        {
          int ct = __lstTaskUpdate.Count;
          __count_update++;
          double pst = (__count_update * 100) / ct;
          if (pst == 0)
            __wForm.ChangePercent(1);
          else
            __wForm.ChangePercent(Math.Abs(pst));
        }
      }
    }

    WaitForm __wForm = null;
    private void btnOk_Click(object sender, EventArgs e)
    {
      __count_update = 0;
      __command = ZtpProtocol.SetConfigCommand(__pwd, this.Value);

      //this.label1.Text = __command;
        if (CheckSessionPassword())
        {
          __command = ZtpProtocol.SetConfigCommand(__pwd, this.Value);
        }
      using (__wForm = new WaitForm("Запись настроек контроллеров",RunSettingsWrite, StateWaitForm.StateOverSimple))
      {
        // __wForm.InitListView(this.__items_checked);
        __wForm.ShowDialog();
        __wForm.Close();

      }
    }

    List<Task>  __lstTaskUpdate = new List<Task>();
    List<Task> __lstTaskRunner = new List<Task>();

    void RunSettingsWrite()
    {
      //string command = string.Empty;

      __lstTaskUpdate = new List<Task>();
      __lstTaskRunner = new List<Task>();

      foreach (ListViewItem item in this.__items_checked)
      {
        ItemCallBack itcb = new ItemCallBack(item);

        Task tsk = new Task(new Action<object>((oItem) =>
        {
          ItemCallBack ositem = (ItemCallBack)oItem;
          ItemIp itemIp = (ItemIp)ositem.Item.Tag;
          TcpClient client=null;
          try
          {
            client = this.__getConnection(itemIp.Ip, 10251);//new TcpClient(item.IP, 10251);
              if (client == null)
              throw new Exception(string.Format("Error connect to:{0}", itemIp.Ip));
            NetworkStream stream = client.GetStream();
            stream.ReadTimeout = 15000;
            byte[] bCfg = System.Text.ASCIIEncoding.ASCII.GetBytes(__command);
            stream.Write(bCfg, 0, bCfg.Length);
            int len = stream.Read(bCfg, 0, bCfg.Length);
            if (len > 0)
            {
              string answ = System.Text.ASCIIEncoding.ASCII.GetString(bCfg, 0, len);
              if (answ.Equals("PWD:OK\r\n"))
              {
                DbLogMsg dbLogMsg = new DbLogMsg()
                {
                  Id = itemIp.Id,
                  Tp = itemIp.Name
                };
                DbLogMsg.ParseNodePath(__node_full_path, ref dbLogMsg);
                string msg = System.Text.Json.JsonSerializer.Serialize(dbLogMsg, typeof(DbLogMsg), DbLogMsg.GetSerializeOption());
                __db.LogsInsertEvent(DB.EnLogEvt.SETTING_CHANGE, msg);
                if (this.cbReboot.Checked)
                {
                  string command = ZtpProtocol.RebootCommand(this.__pwd);
                  stream.Write(bCfg, 0, bCfg.Length);
                  if (len > 0)
                  {
                    answ = System.Text.ASCIIEncoding.ASCII.GetString(bCfg, 0, len);
                    if (answ.Equals("PWD:OK\r\n"))
                    {
                     
                      __wForm.ChangeLabelText(itemIp.Name, itemIp.Name, itemIp.Ip, true, itemIp.UType, 0);
                    }
                    else
                    {
                      __wForm.ChangeLabelText(itemIp.Name, itemIp.Name, itemIp.Ip, false, itemIp.UType, 9);
                    }
                  }
                  else
                  {
                    throw new Exception("Ошибка чтения...");
                  }
                }
                else {
                  __wForm.ChangeLabelText(itemIp.Name, itemIp.Name, itemIp.Ip, true, itemIp.UType, 0);
                }
              }
              else if (answ.Equals("PWD:ERROR\r\n"))
              {
                __wForm.ChangeLabelText(itemIp.Name, itemIp.Name, itemIp.Ip, false, itemIp.UType, 7);
              }
              else
              {
                __wForm.ChangeLabelText(itemIp.Name, itemIp.Name, itemIp.Ip, false, itemIp.UType, 6);
              }
            }
          }
          catch (Exception exp)
          {
            __wForm.ChangeLabelText(itemIp.Name, itemIp.Name, itemIp.Ip, false, itemIp.UType, 1);
          }
          finally
          {
            ositem.runOff(ositem.TaskOwn);
            if (client != null)
              client.Close();
          }
        }), itcb);
        itcb.TaskOwn = tsk;
        itcb.runOff = this.CallBackTaskEnd;
        __lstTaskUpdate.Add(tsk);

      }
      var iner = Task.Factory.StartNew(() =>
      {
        for (int i = 0; i < __lstTaskUpdate.Count; i++)
        {
          while (true)
          {
            if (this.__lstTaskRunner.Count < 100)
            {
              lock (__lstTaskRunner)
              {
                this.__lstTaskRunner.Add(__lstTaskUpdate[i]);
                __lstTaskUpdate[i].Start();
              }
              break;
            }
            Thread.Sleep(10);
          }

        }
        while (this.__lstTaskRunner.Count != 0)
        {
          Thread.Sleep(100);
        }
        try
        {
          __wForm.BeginInvoke(new Action(() =>
          {
            __wForm.CompleetWork(true);
          }));
          //this.BeginInvoke(new Action(() => {
          //  //this.pictureBox1.Visible = false;
          //  //this.btnChancel.Text = "Выход";
          //}));
        }
        catch { }

      });
    }

    void SetSettingsMultiWrite()
    {
      
      string command = string.Empty;
      if (CheckSessionPassword())
      {
        //string xxxxx = ZtpProtocol.SerializeZtpConfig(this.Value);
        command = ZtpProtocol.SetConfigCommand(__pwd, this.Value);
      }
        UlcWin.win.WaitForm wFrm = null;
      
      using (wFrm = new win.WaitForm(new Action(() =>
      {
        foreach (ListViewItem item in this.__items_checked)
        {
          Task tsk = new Task(new Action<object>((oItem) =>
          {
            ListViewItem itL = (ListViewItem)oItem;
            ItemIp itip = (ItemIp)itL.Tag;
            TcpClient client = null;
            try
            {

              client = this.__getConnection(itip.Ip, 10251);//new TcpClient(item.IP, 10251);
              if (client == null)
                throw new Exception(string.Format("Error connect to:{0}", itip.Ip));
              NetworkStream stream = client.GetStream();
              stream.ReadTimeout = 15000;
              byte[] bCfg = System.Text.ASCIIEncoding.ASCII.GetBytes(command);
              stream.Write(bCfg, 0, bCfg.Length);
              int len = stream.Read(bCfg, 0, bCfg.Length);
              if (len > 0)
              {
                string answ = System.Text.ASCIIEncoding.ASCII.GetString(bCfg, 0, len);
                if (answ.Equals("PWD:OK\r\n"))
                {
                  wFrm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, true, itip.UType, 0);
                }
                else if (answ.Equals("PWD:ERROR\r\n"))
                {
                  wFrm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, itip.UType, 7);
                }
                else
                {
                  wFrm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, itip.UType, 6);
                }
              }
              else
              {
                wFrm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, itip.UType, 6);
              }
            }
            catch
            {
              wFrm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, itip.UType, 1);
            }
            finally
            {
              if (client != null)
              {
                client.Close();
              }
            }
          }), item);
          tsk.Start();
        }
      
      }), StateWaitForm.StateOverSimple))
      {
        wFrm.ShowDialog();
      }
    }
  }
}
