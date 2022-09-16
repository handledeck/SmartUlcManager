using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Ztp.Model;
using Ztp.Ui;
using ZtpManager.Controls;
using ZtpManager.DataAccessLayer;

namespace ZtpManager
{
  public partial class HistoryForm : Form
  {
    private DateTimeToolStripItem _from;
    private DateTimeToolStripItem _to;

    public HistoryForm()
    {
      InitializeComponent();

      _from = new DateTimeToolStripItem();
      _to = new DateTimeToolStripItem();

      _from.Picker.Value = DateTime.Now.AddMonths(-1);
      _to.Picker.Value = DateTime.Now;

      toolStrip.Items.Insert(0, new ToolStripLabel("С: "));
      toolStrip.Items.Insert(1, _from);
      toolStrip.Items.Insert(2, new ToolStripLabel(" по: "));
      toolStrip.Items.Insert(3, _to);
      InitializeListView();
    }

    void InitializeListView()
    {
      flv.ListView.SmallImageList = iml;

      flv.ListView.Columns.Add(new OLVColumn("Дата/время", OpHistoryFld.OpDate));
      flv.ListView.Columns[0].Width = 150;
      ((OLVColumn)flv.ListView.Columns[0]).ImageGetter = (o) => Convert.ToInt32(((OpHistory)o).IsError);

      flv.ListView.Columns.Add(new OLVColumn("Пользователь", OpHistoryFld.UserName));
      flv.ListView.Columns[1].Width = 100;

      flv.ListView.Columns.Add(new OLVColumn("Операция", OpHistoryFld.OpName));
      flv.ListView.Columns[2].Width = 100;

      flv.ListView.Columns.Add(new OLVColumn("Результат", OpHistoryFld.OpResult));
      flv.ListView.Columns[3].Width = 100;

      flv.ListView.Columns.Add(new OLVColumn("Команда", OpHistoryFld.Cmd));
      flv.ListView.Columns[4].Width = 100;

      flv.ListView.Columns.Add(new OLVColumn("Объект", OpHistoryFld.ObjText));
      flv.ListView.Columns[5].Width = 100;

      flv.ListView.SelectionChanged += ListView_SelectionChanged;
      flv.ListView.MultiSelect = false;
      flv.RefreshButton.Visible = false;
    }

    private void ListView_SelectionChanged(object sender, EventArgs e)
    {
      OpHistory history = flv.ListView.SelectedObject as OpHistory;
      if(history == null)
      {
        ShowObjText("");        
        return;
      }
      ShowObjText(history.ObjText);
    }

    void ShowObjText(string text)
    {
      tbObj.Text = text;
    }

    public int DeviceId { get; set; }
    private void tbsRefresh_Click(object sender, EventArgs e)
    {
      Execute(_from.Picker.Value, _to.Picker.Value);
    }

    public void ShowData(IWin32Window owner, string caption)
    {
      this.Text = caption;
      this.Show(owner);
      Execute(_from.Picker.Value, _to.Picker.Value);
    }

    void Execute(DateTime st, DateTime et)
    {
      using (WaitForm frm = new WaitForm("Чтение данных", (sender, args) =>
      {
        args.Result = Dal.Default.ReadHistory(DeviceId, st, et);
      }, (sender, args) =>
      {
        IEnumerable<OpHistory> histories = (IEnumerable<OpHistory>) args.Result;
        flv.ListView.SetObjects(histories);
      }))
      {
        frm.Show(this);
      }
    }

    

  }
}
