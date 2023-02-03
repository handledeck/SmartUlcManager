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
using UlcWin.Controls;
using UlcWin.DB;

namespace UlcWin.ui
{
  public partial class LogsViewForm : Form
  {
    DbReader __db = null;
    EventLogCheckBoxPanel __eventLogCheckBoxPanel;
    AplSetings.ASettings __aSettings = null;
    List<OrmDbLogs> __ormDbLogs;
    public LogsViewForm(DbReader db,AplSetings.ASettings aSettings)
    {
      __db = db;
      InitializeComponent();
      __aSettings = aSettings;

      __eventLogCheckBoxPanel = new EventLogCheckBoxPanel();
      __eventLogCheckBoxPanel.ItemEventChecked += __eventLogCheckBoxPanel_ItemEventChecked;
      this.popupComboBox1.DropDownControl = __eventLogCheckBoxPanel;
      //this.popupComboBox1.DropDownClosed += PopupComboBox1_DropDownClosed;
      //this.__eventLogCheckBoxPanel.EventCheckBoxSelected += __eventLogCheckBoxPanel_EventCheckBoxSelected;
      this.popupComboBox1.Text = "Выбор событий";
      
      if (__aSettings.DisplayEventChecked == null)
      {
        __aSettings.DisplayEventChecked = new List<int>() { 14,100};
        __aSettings.Settings_changed = true;
      }
      this.Shown += LogsViewForm_Shown;
      __aSettings = aSettings;
      
      //this.cbEvetCheckBox.DropDownHeight = 350;
      //this.cbEvetCheckBox.DropDownWidth = 280;
    }


    private void __eventLogCheckBoxPanel_ItemEventChecked(CbsEvents sender, ItemCheckEventArgs e)
    {
      if (e.NewValue == CheckState.Checked)
      {
        __aSettings.DisplayEventChecked.Add(sender.ID);
        __aSettings.Settings_changed = true;
      }
      else
      {
        __aSettings.DisplayEventChecked.Remove(sender.ID);
        __aSettings.Settings_changed = true;
      }

      //this.lstLogEvents.Clear();
      //this.lstLogEvents.VirtualMode = false;
      RefreshListEvents();
     
      //this.lstLogEvents.Clear();
      this.lstLogEvents.VirtualListSize = __sortList.Count;
      this.lstLogEvents.VirtualMode = true;
      //this.lstLogEvents.Refresh();
      this.lstLogEvents.Update();
    }

    private void __eventLogCheckBoxPanec_ItemEventChecked(CbsEvents sender,ItemCheckEventArgs e)
    {
      if (e.NewValue == CheckState.Checked)
      {
        __aSettings.DisplayEventChecked.Add(sender.ID);
        __aSettings.Settings_changed = true;
      }
      else
      {
        __aSettings.DisplayEventChecked.Remove(sender.ID);
        __aSettings.Settings_changed = false;
      }
      ReadAllLogs();
      this.__eventLogCheckBoxPanel.Show();
    }

    DbLogMsg EvtObjectWho(string message)
    {
      try
      {
        var dbFactory = new OrmLiteConnectionFactory(this.__db.__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          DbLogMsg dbLogMsg = (DbLogMsg)System.Text.Json.JsonSerializer.Deserialize(message, typeof(DbLogMsg));
          if (dbLogMsg == null)
            throw new Exception();
          OrmDbInfo ormDbInfo = db.Single<OrmDbInfo>(x => x.id == dbLogMsg.id);
          if (ormDbInfo != null)
            dbLogMsg.ip = ormDbInfo.ip_address;
          return dbLogMsg;
        }
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


    string GetSqlRequestByDate() {
      DateTime dt_start = this.cbDateTimeFrom.Value;
      DateTime dt_end_val = this.cbDateTimeBy.Value;
      DateTime dt_end = dt_end_val.AddDays(1);
      StringBuilder sb = new StringBuilder();
      string sql = string.Format("SELECT * FROM main_logs ml where ml.\"current_time\" > '{0}' and ml.\"current_time\" < '{1}'", dt_start.Date, dt_end.Date);
      sb.Append(sql);
      //foreach (var item in __aSettings.DisplayEventChecked)
      //{
      //  string or = string.Format("ml.log_event = {0} or ", item.ToString());
      //  sb.Append(or);
      //}
      //sb.Remove(sb.Length - 3, 3);
      //sb.Append(")");
      return sb.ToString();
    }

    

    List<OrmDbLogs> GetAllLogsPeriod() {
      List<OrmDbLogs> ormDbLogs = null;
      var dbFactory = new OrmLiteConnectionFactory(this.__db.__connection, PostgreSqlDialect.Provider);
      using (var db = dbFactory.Open())
      {
        try
        {
          string sb=GetSqlRequestByDate();
          ormDbLogs = db.Select<OrmDbLogs>(sb).ToList();
          foreach (var item in ormDbLogs)
          {
            item.dbLogMsg = EvtObjectWho(item.message.ToLower());
          }
          return ormDbLogs.OrderByDescending(x => x.current_time).ToList();
        }
        catch (Exception exp) {
          return null;
        }
      }
    }

    List<OrmDbLogs> __sortList=new List<OrmDbLogs>();
    void RefreshListEvents() {

      __sortList.Clear();
      //List<ListViewItem> lst = new List<ListViewItem>();
      foreach (var item in __ormDbLogs)
      {
        if (__aSettings.DisplayEventChecked.Contains(item.log_event))
          __sortList.Add(item);
      }
      //__sortList = __ormDbLogs.Select(x =>
      //{
      //  if (__aSettings.DisplayEventChecked.Contains(x.log_event))
      //  {
      //    return x;
      //  }
      //  else return null;
       
      //}).OrderBy(x => x.current_time).ToList();
     
      

      //foreach (var item in sortList)
      //{
      //  ListViewItem itr = new ListViewItem(item.current_time.ToString("dd.MM.yyyy HH:mm:ss"));

      //  //ListViewItem itr = this.lstLogEvents.Items.Add(item.current_time.ToString("dd.MM.yyyy HH:mm:ss"));
      //  itr.SubItems.Add(item.host_from + ":" + item.usr_name);
      //  itr.SubItems.Add(EvtDescription.GetDesc((EnLogEvt)item.log_event));
      //  DbLogMsg dbLogMsg = EvtObjectWho(item.message);
      //  if (dbLogMsg != null)
      //  {
      //    itr.Tag = dbLogMsg;
      //    itr.SubItems.Add(dbLogMsg.ip);

      //    itr.SubItems.Add(dbLogMsg.fes + "/" + dbLogMsg.res + "/" + dbLogMsg.tp);
      //  }//dbLogMsg.Ip + dbLogMsg.Fes + " / " + dbLogMsg.Res + "/" + dbLogMsg.Tp);
      //  else
      //  {
      //    //itr.SubItems.Add(item.message);
      //  }
      //  itr.ImageIndex = SetIconEvent((EnLogEvt)item.log_event);
      //  lst.Add(itr);
      //}
      //IAsyncResult res = this.lstLogEvents.BeginInvoke(new Action(() =>
      //{
      //  this.lstLogEvents.Items.Clear();
      //  this.lstLogEvents.Items.AddRange(lst.ToArray());


      //}));
    }

    public void ReadAllLogs()
    {
      //lstLogEvents.VirtualMode = false;
      using (SimpleWaitForm sfrm = new SimpleWaitForm())
      {

        sfrm.RunAction(new Action(() =>
        {
          sfrm.SetLabelText("Формирую журнал сообщений...");
          __ormDbLogs = GetAllLogsPeriod();
          RefreshListEvents();
          sfrm.DialogResult = DialogResult.OK;
        }));
        DialogResult result = sfrm.ShowDialog(this.lstLogEvents);
        if (result == DialogResult.OK)
        {
          if (__sortList.Count > 0)
          {
            lstLogEvents.VirtualMode = true;
            lstLogEvents.VirtualListSize = __sortList.Count;
          }
          else
          {
            lstLogEvents.VirtualMode = false;
          }
        }
      }
      
    }

    bool __loaded = false;
    private void LogsViewForm_Shown(object sender, EventArgs e)
    {
      ReadAllLogs();
      GetEvetDescription();
      //if (__sortList.Count > 0) {

        
      //}
      
      //var dbFactory = new OrmLiteConnectionFactory(this.__db.__connection, PostgreSqlDialect.Provider);
      //using (var db = dbFactory.Open())
      //{
      //  try
      //  {
      //    List<OrmDbUsers> lstUser = db.Select<OrmDbUsers>();
      //    //this.cbUsers.Items.Add("Все");

      //    this.cbUsers.Items.AddRange(lstUser.ToArray());
      //    this.cbUsers.SelectedIndex = 0;
      //    GetEvetDescription();
      //    this.cbEvents.SelectedIndex = 0;
      //    ReadAllLogs();
      //    __loaded = true;
      //  }
      //  catch (Exception ep)
      //  {

      //  }

      //}

    }

    private void lstLogEvents_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
    {
      try
      {
        ListViewItem itr = new ListViewItem(__sortList[e.ItemIndex].current_time.ToString("dd.MM.yyyy HH:mm:ss"));
        itr.Tag = __sortList[e.ItemIndex];
        //ListViewItem itr = this.lstLogEvents.Items.Add(item.current_time.ToString("dd.MM.yyyy HH:mm:ss"));
        itr.SubItems.Add(__sortList[e.ItemIndex].host_from /*+ ":" + __sortList[e.ItemIndex].usr_name*/);
        itr.SubItems.Add(EvtDescription.GetDesc((EnLogEvt)__sortList[e.ItemIndex].log_event));
        itr.SubItems.Add(__sortList[e.ItemIndex].dbLogMsg!=null ? __sortList[e.ItemIndex].dbLogMsg.ip:"");
        if (__sortList[e.ItemIndex].dbLogMsg != null)
        {
          string msg = __sortList[e.ItemIndex].dbLogMsg.fes + "/" + __sortList[e.ItemIndex].dbLogMsg.res + "/" + __sortList[e.ItemIndex].dbLogMsg.tp;
          itr.SubItems.Add(msg);// __sortList[e.ItemIndex].dbLogMsg.));
          if (__sortList[e.ItemIndex].dbLogMsg.feature != null)
          {
            itr.SubItems.Add(string.Format("{1}(rs-485:{0})", __sortList[e.ItemIndex].dbLogMsg.feature.rs_status.ToString(),
              __sortList[e.ItemIndex].dbLogMsg.feature.rs_last_request));
          }
          else
            itr.SubItems.Add("");
        }
        else {
          itr.SubItems.Add("");
          itr.SubItems.Add("");
        }
        //DbLogMsg dbLogMsg = EvtObjectWho(__sortList[e.ItemIndex].message);
        //if (dbLogMsg != null)
        //{
        //  itr.Tag = dbLogMsg;
        //  itr.SubItems.Add(dbLogMsg.ip);

        //  itr.SubItems.Add(dbLogMsg.fes + "/" + dbLogMsg.res + "/" + dbLogMsg.tp);
        //}//dbLogMsg.Ip + dbLogMsg.Fes + " / " + dbLogMsg.Res + "/" + dbLogMsg.Tp);
        //else
        //{
        //  itr.SubItems.Add("");
        //}
        itr.ImageIndex = SetIconEvent((EnLogEvt)__sortList[e.ItemIndex].log_event);
        e.Item = itr;
      }
      catch (Exception ex)
      {

       // throw;
      }
    }

    List<CbsEvents> lst = new List<CbsEvents>();
    void GetEvetDescription()
    {
      //CbsEvents cbsEvents = new CbsEvents() { ID = 0, EvtDesc = "Все" };
      //this.cbEvents.Items.Add(cbsEvents);
      //this.__eventLogCheckBoxPanel.AddCbsEvent(cbsEvents);
      List<CbsEvents> lst = new List<CbsEvents>();
      foreach (EnLogEvt suit in (EnLogEvt[])Enum.GetValues(typeof(EnLogEvt)))
      {
        string desc=EvtDescription.GetDesc(suit);
        int id = (int)suit;
        CbsEvents cbsEvents = new CbsEvents() {  ID=id, EvtDesc=desc, Checked=__aSettings.DisplayEventChecked.Contains(id)? true:false };
        this.cbEvents.Items.Add(cbsEvents);
        lst.Add(cbsEvents);
        //int x=this.cbEvetCheckBox.Items.Add(cbsEvents);
        //this.cbEvetCheckBox.CheckBoxItems[x].Checked = true;
        //this.cbEvetCheckBox.CheckBoxItems[x].CheckedChanged += LogsViewForm_CheckedChanged;
      }
      this.__eventLogCheckBoxPanel.AddCbsEvent(lst);
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
          if (dbLm.feature != null) {
            using (LogDetailEvent lgEvt = new LogDetailEvent())
            {
              CbsEvents cbsEvents = (CbsEvents)this.cbEvents.SelectedItem;
              List<OrmDbLogs> ormDbLogs = __db.GetAllLogsByEvent(cbsEvents.ID);
              foreach (var item in ormDbLogs)
              {
                try
                {
                  DbLogMsg dbLogMsg = (DbLogMsg)System.Text.Json.JsonSerializer.Deserialize(item.message, typeof(DbLogMsg), DbLogMsg.GetSerializeOption());
                  if (dbLogMsg.feature != null)
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

   

    private void popupComboBox1_DropDown(object sender, EventArgs e)
    {
      int x = 0;
    }

    private void lstLogEvents_SelectedIndexChanged(object sender, EventArgs e)
    {
      ListView.SelectedIndexCollection col = lstLogEvents.SelectedIndices;
      if (col.Count == 0)
        return;
      this.lstViewArchEvent.Items.Clear();
      if (lstLogEvents.Items[col[0]].Tag != null)
      {
        OrmDbLogs ormDbLogs = (OrmDbLogs)lstLogEvents.Items[col[0]].Tag;
        if (ormDbLogs != null)
        {
          var dbFactory = new OrmLiteConnectionFactory(this.__db.__connection, PostgreSqlDialect.Provider);
          using (var db = dbFactory.Open())
          {
            try
            {
              List<OrmDbLogs> lst;
              if (ormDbLogs.dbLogMsg == null)
                return;
              lst = db.Select<OrmDbLogs>(x => x.ctrl_id == ormDbLogs.dbLogMsg.id && ormDbLogs.log_event==x.log_event);
              if (lst.Count > 0)
              {
                foreach (var item in lst)
                {
                  ListViewItem listViewItem = this.lstViewArchEvent.Items.Add(item.current_time.ToString("dd.MM.yyyy hh:mm:ss"));
                  DbLogMsg dbLogMsg= EvtObjectWho(item.message.ToLower());
                  if (dbLogMsg != null)
                  {
                    string msg = dbLogMsg.fes + "/" + dbLogMsg.res + "/" + dbLogMsg.tp;
                    listViewItem.SubItems.Add(msg);
                    if (dbLogMsg.feature != null) {
                      listViewItem.SubItems.Add(string.Format("{1} (rs-485:{0})",dbLogMsg.feature.rs_status,dbLogMsg.feature.rs_last_request));
                    }
                    else
                      listViewItem.SubItems.Add("");
                  }
                  else {
                    listViewItem.SubItems.Add("");
                  }
                }
                this.lstViewArchEvent.Visible = true;
              }
              else {
                this.lstViewArchEvent.Visible = false;
              }
            }
            catch (Exception exp)
            {
              int x = 0;
            }
          }
        }
      }
    }
  }

  public class CbsEvents {
    public int ID { get; set; }
    public string EvtDesc  { get; set; }

    public bool Checked { get; set; }
    public override string ToString()
    {
      return EvtDesc;
    }
  }
}
