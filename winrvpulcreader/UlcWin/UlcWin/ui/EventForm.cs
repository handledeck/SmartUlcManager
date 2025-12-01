using InterUlc.Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UlcWin.LoadForm;
using static UlcWin.ui.SettingEditForm;

namespace UlcWin
{



  public partial class EventForm : Form
  {
    Dictionary<DateTime, List<Log>> dicEvt;
    public EventForm()
    {
      InitializeComponent();
    }

    public event eventdata __eventdata = null;
    public event CommandWriteDelegate __commandWrite=null;
    

    public EventForm(eventdata eventdata, CommandWriteDelegate commandWrite)
    {
      __commandWrite = commandWrite;
      __eventdata = eventdata;
      InitializeComponent();
      this.Shown += EventForm_Shown;
    }

    private void EventForm_Shown(object sender, EventArgs e)
    {
      SetEventList();
    }

    public Dictionary<DateTime, List<Log>> Events
    {
      get { return dicEvt; }
      set { dicEvt = value; }
    }

    public void SetEventList()
    {
      this.BeginInvoke(new Action(() =>
      {
        this.listView1.Items.Clear();
        this.listView1.Groups.Clear();
      }));

      string dt_evtLst = "dd.MM.yy HH:mm:ss";
      string dt_evtGrp = "dd.MM.yy";
      var orKey = dicEvt.OrderByDescending(x => x.Key);
      foreach (var item in orKey)
      {
        this.BeginInvoke(new Action(() =>
        {
          var grp = this.listView1.Groups.Add(item.Key.ToString(dt_evtGrp), item.Key.ToString("dd.MM.yy"));
          var ord = item.Value.ToList().OrderBy(x => x.event_time);
          foreach (var itdata in ord)
          {
            ListViewItem itevt = new ListViewItem(itdata.event_time.ToString(dt_evtLst), grp);

            switch (itdata.event_level)
            {
              case EnumLogs.LOG_LVL.logDEBUG:
                itevt.ImageIndex = 2;
                break;
              case EnumLogs.LOG_LVL.logINFO:
                itevt.ImageIndex = 0;
                break;
              case EnumLogs.LOG_LVL.logWARNING:
                itevt.ImageIndex = 1;
                break;
              case EnumLogs.LOG_LVL.logERROR:
                itevt.ImageIndex = 3;
                break;
              case EnumLogs.LOG_LVL.logFATAL:
                itevt.ImageIndex = 3;
                break;
              default:
                itevt.ImageIndex = 0;
                break;
            }
            itevt.SubItems.Add(Log.ParceLevel((EnumLogs.LOG_LVL)itdata.event_level));
            itevt.SubItems.Add(itdata.event_msg);
            this.listView1.Items.Add(itevt);
          }
        }));
      }
    }
    private void btnUpdateEvents(object sender, EventArgs e)
    {
      if (this.__eventdata != null)
        __eventdata(null, null);
    }

    private void Evt_clearLog(object sender, EventArgs e)
    {
      DialogResult result= MessageBox.Show("Все записи журнала будут стерты. Вы уверены в своих действиях","Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (result == DialogResult.Yes)
      {
        if (__commandWrite != null)
        {
          __commandWrite("CLEARLOG\r");
        }
        if (__eventdata != null)
        {
          __eventdata(null, null);
        }
      }
    }
  }
}
