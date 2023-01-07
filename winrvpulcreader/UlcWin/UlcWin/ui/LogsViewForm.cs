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

    DbLogMsg EvtObjectWho(string message, IDbConnection db)
    {
      try
      {
        DbLogMsg dbLogMsg = (DbLogMsg)System.Text.Json.JsonSerializer.Deserialize(message, typeof(DbLogMsg));
        if (dbLogMsg == null)
          throw new Exception();
        OrmDbInfo ormDbInfo = db.Single<OrmDbInfo>(x => x.id == dbLogMsg.id);
        if (ormDbInfo != null)
          dbLogMsg.ip = ormDbInfo.ip_address;
        return dbLogMsg;
      }
      catch (Exception e)
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
        DateTime dt_start = this.cbDateTimeFrom.Value;
        DateTime dt_end_val = this.cbDateTimeBy.Value;
        DateTime dt_end = dt_end_val.AddDays(1);
        string usr = string.Empty;
        int id_usr = -1;
        int id_evet = -1;
        if (this.cbUsers.SelectedIndex != 0)
          id_usr = ((OrmDbUsers)this.cbUsers.SelectedItem).id;
        if (this.cbEvents.SelectedIndex != 0)
          id_evet = ((CbsEvents)this.cbEvents.SelectedItem).ID;
        sfrm.RunAction(new Action(() =>
        {
          sfrm.SetLabelText("Формирую журнал сообщений...");
          var dbFactory = new OrmLiteConnectionFactory(this.__db.__connection, PostgreSqlDialect.Provider);
          using (var db = dbFactory.Open())
          {
            try
            {
              List<OrmDbLogs> lstLogs = null;
              //IAsyncResult re= this.BeginInvoke(new Action(() => {
              var xx = db.From<OrmDbLogs>().Where(x => x.current_time > dt_start.Date && x.current_time < dt_end.Date).
              And(x => id_usr == -1 ? x.id_user > -1 : x.id_user == id_usr).
              And(x => id_evet == -1 ? x.log_event > -1 : x.log_event == id_evet).
              Select().OrderByDescending(x => x.current_time);
              lstLogs = db.SqlList<OrmDbLogs>(xx);
              //}));
              //re.AsyncWaitHandle.WaitOne();
              List<ListViewItem> lst = new List<ListViewItem>();
              foreach (var item in lstLogs)
              {
                ListViewItem itr = new ListViewItem(item.current_time.ToString("dd.MM.yyyy HH:mm:ss"));

                //ListViewItem itr = this.lstLogEvents.Items.Add(item.current_time.ToString("dd.MM.yyyy HH:mm:ss"));
                itr.SubItems.Add(item.host_from + ":" + item.usr_name);
                itr.SubItems.Add(EvtDescription.GetDesc((EnLogEvt)item.log_event));
                DbLogMsg dbLogMsg = EvtObjectWho(item.message, db);
                if (dbLogMsg != null)
                {
                  itr.Tag = dbLogMsg;
                  itr.SubItems.Add(dbLogMsg.ip);

                  itr.SubItems.Add(dbLogMsg.fes + "/" + dbLogMsg.res + "/" + dbLogMsg.tp);
                }//dbLogMsg.Ip + dbLogMsg.Fes + " / " + dbLogMsg.Res + "/" + dbLogMsg.Tp);
                else
                {
                  itr.SubItems.Add(item.message);
                }
                itr.ImageIndex = SetIconEvent((EnLogEvt)item.log_event);
                lst.Add(itr);
              }
              IAsyncResult res = this.lstLogEvents.BeginInvoke(new Action(() =>
              {
                this.lstLogEvents.Items.Clear();
                this.lstLogEvents.Items.AddRange(lst.ToArray());
                sfrm.DialogResult = DialogResult.OK;
              }));
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
      if (this.cbDateTimeFrom.Value > this.cbDateTimeBy.Value)
      {
        MessageBox.Show("Начальная дата не может быть больше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
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

    private void cbDateTimeFrom_ValueChanged(object sender, EventArgs e)
    {
      if (this.cbDateTimeFrom.Value > this.cbDateTimeBy.Value)
      {
        MessageBox.Show("Начальная дата не может быть больше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      if (__loaded)
        ReadAllLogs();
    }


    private void lstLogEvents_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (this.lstLogEvents.SelectedItems.Count > 0)
      {
        if (this.lstLogEvents.SelectedItems[0].Tag != null)
        {
          DbLogMsg dbLm = (DbLogMsg)lstLogEvents.SelectedItems[0].Tag;

          //OrmDbLogs ormDbLogs = (OrmDbLogs)this.lstLogEvents.SelectedItems[0].Tag;
          if (dbLm.Feature != null) {
            using (LogDetailEvent lgEvt = new LogDetailEvent())
            {
              CbsEvents cbsEvents = (CbsEvents)this.cbEvents.SelectedItem;
              List<OrmDbLogs> ormDbLogs = __db.GetAllLogsByEvent(cbsEvents.ID);
              foreach (var item in ormDbLogs)
              {
                try
                {
                  DbLogMsg dbLogMsg = (DbLogMsg)System.Text.Json.JsonSerializer.Deserialize(item.message, typeof(DbLogMsg), DbLogMsg.GetSerializeOption());
                  if (dbLogMsg.Feature != null)
                  {
                    int x = 0;
                  }
                }
                catch (Exception ex)
                {

                }

              }
              lgEvt.ShowDialog();
            }
          }
        }
        else
        {
          
        }
      }
    }

    private void LogMenuMouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button ==  MouseButtons.Right) {
        if (this.lstLogEvents.SelectedItems[0].Tag != null)
        {
          this.ctxMenuLogItem.Show(Cursor.Position);
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
