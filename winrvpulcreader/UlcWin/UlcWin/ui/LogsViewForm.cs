using InterUlc.Db;
using PresentationControls;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.DB;

namespace UlcWin.ui
{
  public partial class LogsViewForm : Form
  {
    DbReader __db = null;
    public LogsViewForm(DbReader db)
    {
      __db = db;
      InitializeComponent();
      this.Shown += LogsViewForm_Shown;
      //this.cbEvetCheckBox.DropDownHeight = 350;
      //this.cbEvetCheckBox.DropDownWidth = 280;
    }

    DbLogMsg EvtObjectWho(string message) {

      try
      {
        return (DbLogMsg)System.Text.Json.JsonSerializer.Deserialize(message, typeof(DbLogMsg));

      }
      catch (Exception)
      {

        return null;
      }
    }

    int SetIconEvent(EnLogEvt enLogEvt) {
      int indx = 1;
      switch (enLogEvt)
      {
        case EnLogEvt.ADD_ITEM:
          indx=13;
          break;
        case EnLogEvt.EDIT_ITEM:
          indx = 15;
          break;
        case EnLogEvt.DELETE_ITEM:
          indx = 14;
          break;
        case EnLogEvt.ADD_NODE:
          indx = 2;
          break;
        case EnLogEvt.EDIT_NODE:
          indx = 4;
          break;
        case EnLogEvt.DELETE_NODE:
          indx = 3;
          break;
        case EnLogEvt.SETTING_CHANGE:
          indx = 12;
          break;
        case EnLogEvt.CHANGE_IMEI:
          indx = 11;
          break;
        case EnLogEvt.APP_CONNECT:
          indx = 9;
          break;
        case EnLogEvt.APP_EXIT:
          indx = 10;
          break;
        case EnLogEvt.APP_NEW_USER:
          indx = 5;
          break;
        case EnLogEvt.APP_DEL_USER:
          indx = 6;
          break;
        case EnLogEvt.APP_EDIT_USER:
          indx = 7;
          break;
        default:
          break;
      }
      return indx;
    }

    public void ReadAllLogs()
    {
      using (SimpleWaitForm sfrm = new SimpleWaitForm())
      {
        sfrm.RunAction(new Action(() =>
        {
          sfrm.SetLabelText("Формирую статистику по всем объектам");
          var dbFactory = new OrmLiteConnectionFactory(this.__db.__connection, PostgreSqlDialect.Provider);
          using (var db = dbFactory.Open())
          {
            try
            {
              List<OrmDbLogs> lstLogs = null;
             
              IAsyncResult re= this.BeginInvoke(new Action(() => {
                string usr = string.Empty;
                int id_usr = -1;
                int id_evet = -1;
                if(this.cbUsers.SelectedIndex!=0)
                  id_usr=((OrmDbUsers)this.cbUsers.SelectedItem).id;
                if(this.cbEvents.SelectedIndex!=0)
                  id_evet = ((CbsEvents)this.cbEvents.SelectedItem).ID;
                DateTime dt_start = this.cbDateTime.Value;
                DateTime dt_end = dt_start.AddDays(1);
              var xx = db.From<OrmDbLogs>().Where(x => x.current_time > dt_start.Date && x.current_time<dt_end.Date).
              And(x => id_usr == -1 ? x.id_user > -1 : x.id_user == id_usr).
              //And(b.ToString()).
              And(x=>id_evet == -1 ? x.log_event > -1 : x.log_event == id_evet).
              Select().OrderByDescending(x => x.current_time);
                lstLogs = db.SqlList<OrmDbLogs>(xx);
               
                //  lstLogs = db.Select<OrmDbLogs>(x => x.current_time > this.cbDateTime.Value.Date
                //    && id_usr==-1 ? x.id_user> -1 : x.id_user ==id_usr
                //    && id_evet==-1 ? x.log_event>-1 : x.log_event==id_evet);
                //  this.lstLogEvents.Items.Clear();
              }));
              re.AsyncWaitHandle.WaitOne();
              IAsyncResult res = this.lstLogEvents.BeginInvoke(new Action(() =>
              {
                this.lstLogEvents.Items.Clear();
                foreach (var item in lstLogs)
                {

                  ListViewItem itr = this.lstLogEvents.Items.Add(item.current_time.ToString("dd.MM.yyyy HH:mm:ss"));
                  itr.SubItems.Add(item.host_from + ":" + item.usr_name);
                  itr.SubItems.Add(EvtDescription.GetDesc((EnLogEvt)item.log_event));
                  DbLogMsg dbLogMsg = EvtObjectWho(item.message);
                  if (dbLogMsg != null)
                    itr.SubItems.Add(dbLogMsg.Fes + "/" + dbLogMsg.Res + "/" + dbLogMsg.Tp);
                  else {
                    itr.SubItems.Add(item.message);
                  }
                  itr.ImageIndex = SetIconEvent((EnLogEvt)item.log_event);
                }
              }
              ));
              res.AsyncWaitHandle.WaitOne();
              
              sfrm.DialogResult = DialogResult.OK;
            }
            catch (Exception exp)
            {
              sfrm.DialogResult = DialogResult.Cancel;
            }
          }
        }
        ));
        DialogResult result = sfrm.ShowDialog();
      }
    }
    bool __loaded = false;
    private void LogsViewForm_Shown(object sender, EventArgs e)
    {
      var dbFactory = new OrmLiteConnectionFactory(this.__db.__connection, PostgreSqlDialect.Provider);
      using (var db = dbFactory.Open())
      {
        try
        {
          List<OrmDbUsers> lstUser = db.Select<OrmDbUsers>();
          this.cbUsers.Items.Add("Все");
          this.cbUsers.Items.AddRange(lstUser.ToArray());
          this.cbUsers.SelectedIndex = 0;
          GetEvetDescription();
          this.cbEvents.SelectedIndex = 0;
          ReadAllLogs();
          __loaded = true;
        }
        catch (Exception ep)
        {

        }

      }

    }
    List<CbsEvents> lst = new List<CbsEvents>();
    void GetEvetDescription()
    {
      CbsEvents cbsEvents = new CbsEvents() { ID = 0, EvtDesc = "Все" };
      this.cbEvents.Items.Add(cbsEvents);
     
      foreach (EnLogEvt suit in (EnLogEvt[])Enum.GetValues(typeof(EnLogEvt)))
      {
        string desc=EvtDescription.GetDesc(suit);
        int id = (int)suit;
        cbsEvents = new CbsEvents() {  ID=id, EvtDesc=desc};
        this.cbEvents.Items.Add(cbsEvents);
        //int x=this.cbEvetCheckBox.Items.Add(cbsEvents);
        //this.cbEvetCheckBox.CheckBoxItems[x].Checked = true;
        //this.cbEvetCheckBox.CheckBoxItems[x].CheckedChanged += LogsViewForm_CheckedChanged;
      }

    }

    //StringBuilder b = new StringBuilder();
    //private void LogsViewForm_CheckedChanged(object sender, EventArgs e)
    //{
    //  b.Clear();
    //  for (int i = 0; i < this.cbEvetCheckBox.CheckBoxItems.Count; i++)
    //  {
    //    if (this.cbEvetCheckBox.CheckBoxItems[i].Checked)
    //    {
    //      CbsEvents cc = (CbsEvents)this.cbEvetCheckBox.Items[i];
    //      b.Append(string.Format("log_evet={0}", cc.ID));
    //      if (i != this.cbEvetCheckBox.CheckBoxItems.Count - 1)
    //        b.Append(" or ");
    //    }
    //  }
      
    //  this.Text = b.ToString();
    //}

    private void cbDateTime_ValueChanged(object sender, EventArgs e)
    {
      if (__loaded)
        ReadAllLogs();

    }

    private void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (__loaded)
        ReadAllLogs();
    }

    private void cbEvents_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (__loaded)
        ReadAllLogs();
    }
    
    private void checkBoxComboBox1_CheckBoxCheckedChanged(object sender, EventArgs e)
    {
      if (__loaded)
      {
        CheckBoxComboBoxItem ch = (CheckBoxComboBoxItem)sender;
        if (ch.Checked)
          lst.Add((CbsEvents)ch.ComboBoxItem);
        else
        { 
        lst.Remove((CbsEvents)ch.ComboBoxItem);
        }
      }
    }

    }

    public class CbsEvents {
    public int ID { get; set; }
    public string EvtDesc  { get; set; }

    public override string ToString()
    {
      return EvtDesc;
    }
  }
}
