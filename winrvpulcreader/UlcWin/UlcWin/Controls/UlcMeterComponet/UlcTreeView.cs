using BrightIdeasSoftware;
using InterUlc.Db;
using ServiceStack.OrmLite;
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
using UlcWin;
using UlcWin.Controls.ListViewHeaderMenu;
using UlcWin.Controls.UlcMeterComponet;
using UlcWin.Drivers;
using UlcWin.Edit;
using UlcWin.Export;
using UlcWin.ui;

namespace GettingStartedTree
{
  public partial class UlcTreeView : UserControl
  {
    DbReader __db;
    string __connection = string.Empty;
    int __parent_id = -1;
    List<TreeListNodeModel> __treeNodes = new List<TreeListNodeModel>();
    List<ValueDateTime> __valueDateTimes = new List<ValueDateTime>();
    UlcWin.LoadForm __loadForm = null;
    public UlcTreeView()
    {
      InitializeComponent();
      TextOverlay textOverlay = this.objectListView1.EmptyListMsgOverlay as TextOverlay;
      textOverlay.TextColor = Color.Gray;
      textOverlay.BackColor = Color.Transparent;
      textOverlay.BorderColor = Color.Transparent;
      textOverlay.BorderWidth = 0.0f;
      textOverlay.Font = new Font("Chiller", 36);
      textOverlay.Rotation = 0;
      TextOverlay textOverlay1 = this.treeListView1.EmptyListMsgOverlay as TextOverlay;

      textOverlay1.TextColor = Color.Gray;
      textOverlay1.BackColor = Color.Transparent;
      textOverlay1.BorderColor = Color.Transparent;
      textOverlay1.BorderWidth = 0.0f;
      textOverlay1.Font = new Font("Chiller", 36);
      textOverlay1.Rotation = 0;
      this.treeListView1.SetObjects(__treeNodes);
      this.objectListView1.SetObjects(__valueDateTimes);
      this.objectListView1.EmptyListMsg = "Нет данных для просмотра";
      this.objectListView1.EmptyListMsgFont = new Font("Tahoma", 10);
      this.treeListView1.EmptyListMsg = "Нет данных для просмотра";
      this.treeListView1.EmptyListMsgFont = new Font("Tahoma", 10);
      this.treeListView1.SelectionChanged += TreeListView1_SelectionChanged;
      
      //this.treeListView1.CustomSorter = delegate (OLVColumn column, SortOrder order)
      //{
      //  //SortOrder sortOrder = SortOrder.None;
      //  //if (this.treeListView1.Columns[column.Index].Tag == null)
      //  //{
      //  //  this.treeListView1.Columns[column.Index].Tag = SortOrder.Ascending;
      //  //  sortOrder = SortOrder.Ascending;
      //  //}
      //  //else
      //  //{
      //  //  sortOrder = (SortOrder)this.treeListView1.Columns[column.Index].Tag;
      //  //  if (sortOrder == SortOrder.Ascending)
      //  //    sortOrder = SortOrder.Descending;
      //  //  else
      //  //    sortOrder = SortOrder.Ascending;
      //  //  this.treeListView1.Columns[column.Index].Tag = sortOrder;
      //  //}
      //  //ListViewExtensions.SetSortIcon(this.treeListView1, column.Index, sortOrder);
      //  //MeterComparer sorter = this.treeListView1.ListViewItemSorter as MeterComparer;
      //  //if (sorter == null)
      //  //{
      //  //  //if (this.LstViewItm.Columns[selCoumn].ImageIndex == -1)
      //  //  //  this.LstViewItm.Columns[selCoumn].ImageIndex = 11;
      //  //  sorter = new MeterComparer(column.Index);
      //  //  this.treeListView1.ListViewItemSorter = (MeterComparer)sorter;
      //  //  return;
      //  //}
      //  //else
      //  //{
      //  //  //if (this.LstViewItm.Columns[e.Column].ImageIndex == 11)
      //  //  //{
      //  //  //  this.LstViewItm.Columns[e.Column].ImageIndex = 12;
      //  //  //  sorter.Order = SortOrder.Descending;
      //  //  //}
      //  //  //else
      //  //  //{
      //  //  //  this.LstViewItm.Columns[e.Column].ImageIndex = 11;
      //  //  //  sorter.Order = SortOrder.Ascending;
      //  //  //}
      //  //  sorter.Order = sortOrder;
      //  //  sorter.Column =column.Index;
      //  //  //}

      //  //  //if (e.Column == 2)
      //  //  //  sorter.UsbSorting = UlcSort.IP;
      //  //  //else if (e.Column == 0)
      //  //  //  sorter.UsbSorting = UlcSort.NAME;
      //  //  //else if (e.Column == 6)
      //  //  //{
      //  //  //  sorter.UsbSorting = UlcSort.SIGNAL;
      //  //  //}
      //  //  //else if (e.Column == 13)
      //  //  //{
      //  //  //  sorter.UsbSorting = UlcSort.TRAFFIC;
      //  //  // }
      //  //  if (column.Index == 0)
      //  //    sorter.UsbSorting = UlcSort.NAME;
      //  //  else
      //  //    sorter.UsbSorting = UlcSort.DEFAULT;
      //  //  //selCoumn = e.Column;
      //  //}
      //  //this.treeListView1.Sort();
      //};
    }

    public void SetValue(string connection, int parent_id)
    {
      this.__connection = connection;
      this.__parent_id = parent_id;
      __loadForm = (UlcWin.LoadForm)this.ParentForm;
      this.__db = __loadForm.__db;
      FillTreeList();
      ResetDelegate();
      this.treeListView1.FormatRow += TreeListView1_FormatRow;
    }

    private void FillTreeList()
    {
      Dictionary<int, TreeListNodeModel> dic = new Dictionary<int, TreeListNodeModel>();
      MeterValue.CheckTableDb(__connection);
      List<MeterValue> mv = new List<MeterValue>();
      this.objectListView1.SetObjects(null);
      try
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          //string sql = string.Format("select mn.id as idmain,mc.unit_type_id, mn.\"name\", mi.id, mi.ctrl_id, mi.parent_id,mi.ip ,mi.meter_type, mi.meter_factory, mv.value, mv.is_true,mv.date_time FROM meter_info mi " +
          //             "left join main_nodes mn on mn.id = mi.ctrl_id " +
          //             "left join main_ctrlinfo mc on mc.id =mn.id "+
          //             "left join meter_value mv on mi.id = mv.ctrl_id and mv.date_time > '{0}' where mi.parent_id ={1}",
          //             DateTime.Now.ToString("yyyy-MM-dd"),__parent_id);
          string sql = string.Format("select mi.id ,mn.\"name\",mi.ip,mi.meter_type,mi.meter_factory,mv.date_time,mv.value,mv.is_true, mc.unit_type_id, mc.id as id_home " +
                                    "from meter_info mi " +
                                    "left join meter_value mv on mi.id = mv.ctrl_id and mv.date_time > '{0}' " +
                                    "left join main_nodes mn on mn.id = mi.ctrl_id " +
                                    "left join main_ctrlinfo mc on mc.id = mi.ctrl_id " +
                                    "where mi.parent_id = {1} and mn.active = 1", DateTime.Now.ToString("yyyy-MM-dd"), __parent_id);
          IDbCommand cmd = db.CreateCommand();
          cmd.CommandText = sql;
          var reader = cmd.ExecuteReader();
          //Random random = new Random();
          while (reader.Read())
          {
            int id = (int)reader[0];
            //int unit_type_id = (int)reader[1];
            string name = (string)reader[1];
            //int id = (int)reader[3];
            //int ctrl_id = (int)reader[4];
            //int parent_id = (int)reader[5];
            string ip = (string)reader[2];
            //DateTime dt = (DateTime)reader[3];
            if (reader[3].GetType() == typeof(DBNull) || reader[4].GetType() == typeof(DBNull))
              continue;
            string meter_type = (string)reader[3];
            string meter_factory = (string)reader[4];
            DateTime dt = reader[5].GetType() == typeof(DBNull) ? DateTime.MinValue : (DateTime)reader[5];
            double value = reader[6].GetType() == typeof(DBNull) ? 0 : (double)reader[6];
            bool is_true = reader[7].GetType() == typeof(DBNull) ? false : (bool)reader[7];
            int unit_type_id = (int)reader[8];
            int id_home = (int)reader[9];
            TreeListNodeModel mt = new TreeListNodeModel
            {
              name = name,
              is_true = true,
            };
            TreeListNodeModel treeListNodeModel = new TreeListNodeModel()
            {
              ctrl_id = id,
              name = meter_type,
              date_time = dt,
              ip = ip,
              is_true = is_true,
              value = Math.Round(value, 2),
              meter_factory = meter_factory,
              meter_type = meter_type,
              unit_type_id = unit_type_id
            };
            if (!dic.ContainsKey(id_home))
            {
              mt.Nodes = new List<TreeListNodeModel>();
              mt.Nodes.Add(treeListNodeModel);
              if (!treeListNodeModel.is_true)
              {
                mt.is_true = false;
              }
              dic.Add(id_home, mt);
            }
            else
            {
              dic[id_home].Nodes.Add(treeListNodeModel);
              if (!treeListNodeModel.is_true)
              {
                if (dic[id_home].is_true)
                {
                  dic[id_home].is_part_true = true;
                }

              }
            }
          }
          reader.Close();
        }
        if (__treeNodes != null)
          __treeNodes.Clear();
        foreach (var item in dic)
        {
          if (__treeNodes == null)
          {
            __treeNodes = new List<TreeListNodeModel>();
          }
          if (item.Value.Nodes.Count == 1)
          {
            item.Value.original_name = item.Value.name;
            item.Value.name = item.Value.name + "(" + item.Value.Nodes[0].name + ")";
            item.Value.ip = item.Value.Nodes[0].ip;
            item.Value.meter_type = item.Value.Nodes[0].meter_type;
            item.Value.meter_factory = item.Value.Nodes[0].meter_factory;
            item.Value.value = item.Value.Nodes[0].value;
            item.Value.date_time = item.Value.Nodes[0].date_time;
            item.Value.unit_type_id = item.Value.Nodes[0].unit_type_id;
            item.Value.ctrl_id = item.Value.Nodes[0].ctrl_id;
            item.Value.is_true = item.Value.Nodes[0].is_true;
          }
          __treeNodes.Add(item.Value);
        }
        this.treeListView1.SetObjects(__treeNodes);
        ResetDelegate();
        if (__treeNodes.Count == 0)
        {
          this.button1.Enabled = false;
          this.button2.Enabled = false;
          this.button3.Enabled = false;
        }
        else
        {
          this.button1.Enabled = true;
          this.button2.Enabled = true;
          this.button3.Enabled = true;
        }
        //this.treeListView1.CustomSorter = delegate (OLVColumn column, SortOrder order) {
        //  this.treeListView1.ListViewItemSorter = new MetCom();
        //};
        //  this.treeListView1.CustomSorter = delegate (OLVColumn column, SortOrder order) {
        //  //  SortOrder sortOrder = SortOrder.None;
        //  //  if (this.treeListView1.Columns[column.Index].Tag == null)
        //  //  {
        //  //    this.treeListView1.Columns[column.Index].Tag = SortOrder.Ascending;
        //  //    sortOrder = SortOrder.Ascending;
        //  //  }
        //  //  else
        //  //  {
        //  //    sortOrder = (SortOrder)this.treeListView1.Columns[column.Index].Tag;
        //  //    if (sortOrder == SortOrder.Ascending)
        //  //      sortOrder = SortOrder.Descending;
        //  //    else
        //  //      sortOrder = SortOrder.Ascending;
        //  //    this.treeListView1.Columns[column.Index].Tag = sortOrder;
        //  //  }
        //  //  ListViewExtensions.SetSortIcon(this.treeListView1, column.Index, sortOrder);
        //  //  MeterComparer sorter = this.treeListView1.ListViewItemSorter as MeterComparer;
        //  //  if (sorter == null)
        //  //  {
        //  //    //if (this.LstViewItm.Columns[selCoumn].ImageIndex == -1)
        //  //    //  this.LstViewItm.Columns[selCoumn].ImageIndex = 11;
        //  //    sorter = new MeterComparer(column.Index);
        //  //    this.treeListView1.ListViewItemSorter = (MeterComparer)sorter;
        //  //    return;
        //  //  }
        //  //  else
        //  //  {
        //  //    //if (this.LstViewItm.Columns[e.Column].ImageIndex == 11)
        //  //    //{
        //  //    //  this.LstViewItm.Columns[e.Column].ImageIndex = 12;
        //  //    //  sorter.Order = SortOrder.Descending;
        //  //    //}
        //  //    //else
        //  //    //{
        //  //    //  this.LstViewItm.Columns[e.Column].ImageIndex = 11;
        //  //    //  sorter.Order = SortOrder.Ascending;
        //  //    //}
        //  //    sorter.Order = sortOrder;
        //  //    sorter.Column = column.Index;
        //  //    //}

        //  //    //if (e.Column == 2)
        //  //    //  sorter.UsbSorting = UlcSort.IP;
        //  //    //else if (e.Column == 0)
        //  //    //  sorter.UsbSorting = UlcSort.NAME;
        //  //    //else if (e.Column == 6)
        //  //    //{
        //  //    //  sorter.UsbSorting = UlcSort.SIGNAL;
        //  //    //}
        //  //    //else if (e.Column == 13)
        //  //    //{
        //  //    //  sorter.UsbSorting = UlcSort.TRAFFIC;
        //  //    // }
        //  //    if (column.Index == 0)
        //  //      sorter.UsbSorting = UlcSort.NAME;
        //  //    else
        //  //      sorter.UsbSorting = UlcSort.DEFAULT;
        //  //    //selCoumn = e.Column;
        //  //  }
        //  //  //this.treeListView1.Sort();
        //  //};
      }
      catch (Exception ex)
      {
        int xx = 0;
      }
    }

    private void TreeListView1_FormatRow(object sender, FormatRowEventArgs e)
    {

      TreeListNodeModel vv = (TreeListNodeModel)e.Model;
      if (!vv.is_true)
        e.Item.ForeColor = Color.Gray;
      if (vv.Nodes == null)
      {
        //e.ListView.FullRowSelect = true;
        //TreeListView1_SelectionChanged(this.treeListView1, null);
        //if (!vv.is_true)
        //e.Item.ForeColor = Color.Gray;
        //e.Item.Font = new Font("Tahoma", e.Item.Font.Size);

      }
      else
      {
        //if (vv.Nodes.Count == 1)
        //{
        //  vv.name = vv.name+"(" + vv.Nodes[0].name + ")";
        //  vv.ip = vv.Nodes[0].ip;
        //  vv.meter_type = vv.Nodes[0].meter_type;
        //  vv.meter_factory = vv.Nodes[0].meter_factory;
        //  vv.value = vv.Nodes[0].value;
        //  vv.date_time = vv.Nodes[0].date_time;
        //  vv.unit_type_id = vv.Nodes[0].unit_type_id;
        //}
        //e.ListView.FullRowSelect = false;

        //if (!vv.is_true)
        //  e.Item.ForeColor = Color.Gray;
        //e.ListView.FullRowSelect = true;
        //if (!vv.is_true)
        //  e.Item.ForeColor = Color.Red;
        //e.Item.Font = new Font("Tahoma", e.Item.Font.Size);
      }
    }



    void ResetDelegate()
    {
      this.treeListView1.CanExpandGetter = delegate (Object x)
      {
        TreeListNodeModel vv = (TreeListNodeModel)x;
        if (vv.Nodes == null)
          return false;
        else if (vv.Nodes.Count > 1)
          return true;

        return false;//(x is ArtistExample) || (x is AlbumExample);
      };

      // What objects should belong underneath the given model object?
      this.treeListView1.ChildrenGetter = delegate (Object x)
      {
        TreeListNodeModel vv = (TreeListNodeModel)x;
        //List<MeterValue> l = (List<MeterValue>)x;
        //if (vv.Nodes.Count == 1) {
        //  vv.ip = vv.Nodes[0].ip;
        //  vv.meter_type = vv.Nodes[0].meter_type;
        //  vv.meter_factory = vv.Nodes[0].meter_factory;
        //  vv.name = vv.Nodes[0].name
        //  vv.meter_type = vv.Nodes[0].meter_ty
        //}
        //else
        return vv.Nodes;
        //throw new ArgumentException("Should be Artist or Album");
      };

      this.olvName.ImageGetter = delegate (Object x)
      {
        TreeListNodeModel vv = (TreeListNodeModel)x;
        if (vv.Nodes != null)
        {
          if (!vv.is_true)
            return "error1";
          else if (vv.is_part_true)
            return "part";
          else
            return "ok";
        }

        else
        {
          if (!vv.is_true)
            return "error";
          else
            return "nav_down";
        }


      };

      this.olvDateTime.AspectToStringConverter = delegate (object x)
      {
        if (x != null)
        {
          DateTime? dt = (DateTime)x;
          if (dt.HasValue)
          {
            return dt.Value.ToString("dd.MM.yy HH:mm:ss");
          }
          else return "";
        }
        return "";
        //return String.Format("{0} bytes", size);
        ;
      };

      this.olvType.AspectToStringConverter = delegate (object x)
      {
        if (x != null)
        {
          int? t = (int)x;
          if (t.HasValue)
          {
            if (t == 1)
              return "ULC 2";
            else if (t == 0)
              return "РВП-18";
          }
        }
        return "";
      };

    }

    private void TreeListView1_SelectionChanged(object sender, EventArgs e)
    {
      try
      {
        TreeListView treeListView = (TreeListView)sender;
        TreeListNodeModel treeListNodeModel = (TreeListNodeModel)treeListView.SelectedObject;
        if (treeListNodeModel != null)
        {
          if (treeListNodeModel.Nodes != null)
          {
            if (treeListNodeModel.Nodes.Count > 1)
            {
              this.objectListView1.SetObjects(null);
              this.ctxMenuChange.Enabled = false;
              this.ctxTreeSimpleUpdate.Enabled = false;
              return;
            }
            else
            {
              this.ctxMenuChange.Enabled = true;
              this.ctxTreeSimpleUpdate.Enabled = true;
            }
          }
          else
          {
            this.ctxTreeSimpleUpdate.Enabled = true;
            this.ctxMenuChange.Enabled = true;
          }
          DateTime dtend = DateTime.Now.AddDays(1);
          DateTime dtstart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
          Dictionary<string, ValueDateTime> lstVdt = new Dictionary<string, ValueDateTime>();
          int res = dtend.Day - dtstart.Day;
          DateTime lstDt = dtstart;
          for (int i = 1; i < dtend.Day; i++)
          {
            lstVdt.Add(lstDt.ToString("yyyy-MM-dd"), new ValueDateTime()
            {
              dt = lstDt.ToString("yyyy-MM-dd"),
              is_true = false
            }); ;
            lstDt = lstDt.AddDays(1);
          }
          int id = treeListNodeModel.ctrl_id;
          string sql = string.Format("select date_time,value,is_true from meter_value mv " +
                        "where mv.ctrl_id ={0} " +
                        "and mv.date_time between '{1}' and '{2}'", id,
                        dtstart.ToString("yyyy-MM-dd"), dtend.ToString("yyyy-MM-dd"));
          try
          {
            var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
            using (var db = dbFactory.Open())
            {
              IDbCommand cmd = db.CreateCommand();
              cmd.CommandText = sql;
              var reader = cmd.ExecuteReader();
              while (reader.Read())
              {
                DateTime dt = (DateTime)reader[0];
                string dt_str = dt.ToString("yyyy-MM-dd");
                double value = (double)reader[1];
                bool is_true = (bool)reader[2];
                if (lstVdt.ContainsKey(dt_str))
                {
                  lstVdt[dt_str] = new ValueDateTime()
                  {
                    dt = dt_str,
                    id = id,
                    value = Math.Round(value, 2),
                    is_true = true
                  };
                }
              }
              reader.Close();
            }
            //this.objectListView1.Clear();
            __valueDateTimes = lstVdt.Values.ToList<ValueDateTime>();
            this.objectListView1.SetObjects(__valueDateTimes);
          }
          catch (Exception exp)
          {

            throw;
          }
        }
        else
        {
          this.objectListView1.SetObjects(null);

        }
      }
      catch { }
    }

    private void objectListView1_FormatRow(object sender, FormatRowEventArgs e)
    {

      var ol = (ValueDateTime)e.Item.RowObject;
      if (!ol.is_true)
      {
        e.Item.ForeColor = Color.Gray;
      }
      else
      {
        e.Item.ForeColor = Color.Black;
      }

      int x = 0;
    }

    private void treeListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
      TreeListView treeListView = (TreeListView)sender;
      TreeListNodeModel vv = (TreeListNodeModel)treeListView.SelectedObject;
      //if (vv.Nodes.Count > 1)
      //{
      //  this.ctxMenuChange.Enabled = false;
      //}
      //else {
      //  this.ctxMenuChange.Enabled = true;
      //}
      //if (vv.Nodes == null)
      //{
      //  //treeListView.FullRowSelect = true;

      //  //ll.SubItems[5].BackColor = Color.Red;
      //  //TreeListView1_SelectionChanged(this.treeListView1, null);
      //  //if (!vv.is_true)
      //  //  e.Item.ForeColor = Color.Gray;
      //  //e.Item.Font = new Font("Courier New", e.Item.Font.Size);

      //}
      //else
      //{
      //  //treeListView.FullRowSelect = false;

      //  //if (!vv.is_true)
      //  //  e.Item.ForeColor = Color.Gray;
      //  //e.ListView.FullRowSelect = true;
      //  //if (!vv.is_true)
      //  //  e.Item.ForeColor = Color.Red;
      //  //e.Item.Font = new Font("Tahoma", e.Item.Font.Size);
      //}
    }

    private void tsUpdateMeterValue_Click(object sender, EventArgs e)
    {
      List<TreeListNodeModel> tLst = new List<TreeListNodeModel>();
      int count = 0;
      foreach (var item in this.treeListView1.Roots)
      {
        TreeListNodeModel model = (TreeListNodeModel)item;
        bool add = false;
        foreach (var it in model.Nodes)
        {
          if (!it.is_true)
          {
            if (!add)
            {
              tLst.Add(model);
              add = true;
            }
            count++;
          }
        }
      }
      ReadMetersValue(tLst, count);
      List<MeterValue> lstMv = new List<MeterValue>();
      foreach (var item in tLst)
      {
        foreach (var it in item.Nodes)
        {
          if (it.updated)
          {
            lstMv.Add(new MeterValue()
            {
              ctrl_id = it.ctrl_id,
              ip = it.ip,
              is_true = it.is_true,
              date_time = it.date_time.Value,
              meter_factory = it.meter_factory,
              meter_type = it.meter_type,
              //parent_id = it.parent_id,
              value = it.value.Value
            });
            it.updated = false;
          }
        }
      }

      if (lstMv.Count > 0)
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          DateTime dtc = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
          using (IDbTransaction dbTrans = db.OpenTransaction(IsolationLevel.ReadCommitted))
          {
            try
            {
              foreach (var item in lstMv)
              {
                MeterValue mv = db.Single<MeterValue>(x => x.date_time > dtc && x.ctrl_id == item.ctrl_id);
                if (mv != null)
                {
                  item.id = mv.id;
                }
                db.Save<MeterValue>(item);
              }
              dbTrans.Commit();
            }
            catch
            {
              dbTrans.Rollback();
            }
          }
        }
      }
      MessageBox.Show(string.Format("Обновлено {0} счетчиков", lstMv.Count), "Обновление", MessageBoxButtons.OK, MessageBoxIcon.Information);
      FillTreeList();
    }


    public void ReadMetersValue(List<TreeListNodeModel> tLst, int count)
    {
      CancellationTokenSource tokenSource = new CancellationTokenSource();
      CancellationToken token = tokenSource.Token;
      long prog_value = 0;
      List<Task> tasks = new List<Task>();
      using (MeterProgress mp = new MeterProgress())
      {
        mp.SetTasksToken(tokenSource, count);
        for (int i = 0; i < tLst.Count; i++)
        {
          Task tsk = new Task(new Action<object>((obj) =>
          {
            TreeListNodeModel model = (TreeListNodeModel)obj;
            string ip_loc = string.Empty;
            TcpClient client = null;
            foreach (var item in model.Nodes)
            {
              if (item.is_true)
                continue;
              if (token.IsCancellationRequested)
              {
                return;
              }
              mp.SetLabelText(string.Format("{1}:{0}", item.ip, model.name));
              try
              {
                if (client != null && ip_loc.Equals(item.ip))
                {
                }
                else
                {
                  if (client != null)
                  {
                    client.Close();
                    client = null;
                  }
                  client = GetConnection(item.ip, 10250);
                  if (client == null)
                    throw new Exception();
                }
                ip_loc = item.ip;
                if (item.meter_type.Contains("СЕ102") || item.meter_type.Contains("CE102"))
                {

                  Exception ex;
                  float? value = EnMera102.GetSumDayValue(item.meter_factory, client, out ex);
                  if (ex == null && value.HasValue)
                  {
                    item.value = value.Value;
                    item.is_true = true;
                    item.updated = true;
                    item.date_time = DateTime.Now;
                  }
                  else
                  {
                    throw new Exception("ошибка получения данных");
                  }

                }
                else if (item.meter_type.Contains("СС") || item.meter_type.Contains("СС"))
                {
                  Exception exp = null;
                  float? value = Granelectro.GetSumDayValue(item.meter_factory, client, out exp);
                  if (exp == null && value.HasValue)
                  {
                    item.value = value.Value;
                    item.is_true = true;
                    item.updated = true;
                    item.date_time = DateTime.Now;
                  }
                  else
                  {
                    throw new Exception("ошибка получения данных");
                  }

                }
              }
              catch (Exception ex)
              {
                int xxx = 0;
              }
              Interlocked.Increment(ref prog_value);
              mp.SetProgressValue(Interlocked.Read(ref prog_value));
            }
            if (client != null)
            {
              client.Close();
            }
          }), tLst[i], token);
          tasks.Add(tsk);
        }


        mp.Shown += delegate (object sender, EventArgs e)
        {
          Task.Factory.StartNew(() =>
        {
          try
          {
            foreach (var item in tasks)
            {
              item.Start();
            }
            Task.WaitAll(tasks.ToArray());
            mp.DialogResult = DialogResult.OK;
          }
          catch { }
        }, token);
        };
        mp.ShowDialog();
        mp.DialogResult = DialogResult.OK;
      }
    }



    TcpClient GetConnection(string host, int port)
    {
      TcpClient client = new TcpClient();
      IAsyncResult result = client.BeginConnect(host, port, (i) =>
      {
        if (client.Client != null)
        {
          if (!client.Connected)
          {
            client = null;
          }
        }
      }, null);
      bool state = result.AsyncWaitHandle.WaitOne(10000);
      if (!state)
        return null;
      else return client;
    }


    bool __colapssed = false;
    private void button2_Click(object sender, EventArgs e)
    {
      if (!__colapssed)
      {
        this.treeListView1.ExpandAll();
        __colapssed = true;
        this.button2.ImageIndex = 6;
      }
      else
      {
        this.treeListView1.CollapseAll();
        __colapssed = false;
        this.button2.ImageIndex = 7;
      }

    }

    private void treeListView1_MouseUp(object sender, MouseEventArgs e)
    {
      if (this.treeListView1.Items.Count > 0)
      {
        if (e.Button == MouseButtons.Right)
        {
          this.menuTree.Visible = true;
        }
        else
        {
          this.menuTree.Visible = false;
        }
      }
    }

    private void menuTreeUpdate_Click(object sender, EventArgs e)
    {

    }

    private void menuTreeUpdateNotTrue_Click(object sender, EventArgs e)
    {
      tsUpdateMeterValue_Click(null, null);
    }

    private void menu_meter_change(object sender, EventArgs e)
    {
      TreeListNodeModel item = (TreeListNodeModel)this.treeListView1.SelectedObject;

      MeterInfo meterInfo = new MeterInfo()
      {
        crud_record = CrudRecord.Edit,
        ctrl_id = item.ctrl_id,
        id = item.id,
        ip = item.ip,
        meter_factory = item.meter_factory,
        meter_type = item.meter_type,
        parent_id = item.parent_id

      };
      using (MeterEditFrom mMrom = new MeterEditFrom(meterInfo))
      {
        if (mMrom.ShowDialog() == DialogResult.OK)
        {
          meterInfo.meter_factory = mMrom.txtBoxPlant.Text;
          meterInfo.meter_type = mMrom.GetDeviceByIndex();
          __db.SetCrudMeterInfo(new List<MeterInfo>() { meterInfo });
          item.meter_factory = mMrom.txtBoxPlant.Text;
          item.meter_type = mMrom.GetDeviceByIndex();
        }
      }
    }

    private void ctxTreeSimpleUpdate_Click(object sender, EventArgs e)
    {
      List<TreeListNodeModel> treeListNodeModels = new List<TreeListNodeModel>();

      //OLVListItem item = this.treeListView1.SelectedItem;
      TreeListNodeModel item = (TreeListNodeModel)this.treeListView1.SelectedObject;
      //treeListNodeModels.Add((TreeListNodeModel)this.treeListView1.SelectedObject);
      item.updated = false;
      using (SimpleWaitForm wf = new SimpleWaitForm())
      {
        wf.RunAction(() =>
        {
          wf.SetLabelText(string.Format("Опрашиваю:{0}-{1}", item.name, item.ip));
          TcpClient client = null;
          try
          {
            client = GetConnection(item.ip, 10250);
            if (client == null)
              throw new Exception();
            if (item.meter_type.Contains("СЕ102") || item.meter_type.Contains("CE102"))
            {
              Exception ex;
              float? value = EnMera102.GetSumDayValue(item.meter_factory, client, out ex);
              if (ex == null && value.HasValue)
              {
                item.value = value.Value;
                item.is_true = true;
                item.updated = true;
                item.date_time = DateTime.Now;
                wf.SetLabelText(value.Value.ToString());
              }
              else
              {
                throw new Exception("ошибка получения данных");
              }
            }
            else if (item.meter_type.Contains("СС") || item.meter_type.Contains("СС"))
            {
              Exception exp = null;
              float? value = Granelectro.GetSumDayValue(item.meter_factory, client, out exp);
              if (exp == null && value.HasValue)
              {
                item.value = value.Value;
                item.is_true = true;
                item.updated = true;
                item.date_time = DateTime.Now;
                wf.SetLabelText(value.Value.ToString());
              }
              else
              {
                throw new Exception("ошибка получения данных");
              }
            }
            if (item.updated)
            {
              var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
              using (var db = dbFactory.Open())
              {
                DateTime dtc = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                using (IDbTransaction dbTrans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                  try
                  {
                    MeterValue mv = db.Single<MeterValue>(x => x.date_time > dtc && x.ctrl_id == item.ctrl_id);
                    if (mv != null)
                    {
                      item.id = mv.id;
                    }
                    db.Save<MeterValue>(TreeListNodeModel.ConvertToMeterValue(item));
                    dbTrans.Commit();
                  }
                  catch
                  {
                    dbTrans.Rollback();
                    wf.DialogResult = DialogResult.Abort;
                  }
                }
              }
              wf.DialogResult = DialogResult.OK;
            }
            else
            {
              wf.DialogResult = DialogResult.Abort;
            }


          }
          catch (Exception exp)
          {
            wf.SetLabelText(exp.Message);
            wf.DialogResult = DialogResult.Abort;
          }
          finally
          {
            if (client != null)
            {
              client.Close();
              client.Dispose();
            }
          }
        });
        DialogResult result = wf.ShowDialog();
        if (result == DialogResult.OK)
        {
          MessageBox.Show("Элемент обновлен успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
          MessageBox.Show("Ошибка обновленя элемента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }

    }

    private void btnExportExcel(object sender, EventArgs e)
    {
      object[] cItem = new object[this.treeListView1.Items.Count];
      this.treeListView1.Items.CopyTo(cItem, 0);
      ListView listView3 = new ListView();
      listView3.Columns.AddRange((from ColumnHeader Col in this.treeListView1.Columns
                                  select (ColumnHeader)Col.Clone()).ToArray());
      string fpth = __loadForm.GetFullPathNode();
      string[] fpthArr = fpth.Split('\\');
      List<TreeListNodeModel> treeNodes = new List<TreeListNodeModel>();
      treeNodes.AddRange(__treeNodes.ToArray());
      using (SimpleWaitForm sf = new SimpleWaitForm())
      {
        sf.RunAction(() =>
        {
          sf.SetLabelText("Формирую отчет по счетчикам");

          ExportExcel exportExcel = new ExportExcel();

          exportExcel.PrintMeterToExcel(fpthArr[0], fpthArr[1], listView3, treeNodes);
          sf.DialogResult = DialogResult.OK;
        });
        sf.ShowDialog();
      }
    }

    private void treeListView1_MouseClick(object sender, MouseEventArgs e)
    {
      ListViewExtensions.SetSortIcon(this.treeListView1, 1, SortOrder.Ascending);
      if (e.Button == MouseButtons.Right)
      {
        //Control p = this.GetChildAtPoint(e.Location);
        this.menuTree.Show(Cursor.Position);
      }

    }

    private void ctxMenuSortByName_Click(object sender, EventArgs e)
    {
      ToolStripMenuItem mItemNum = (ToolStripMenuItem)ctxMeterMenu.Items["ctxMenuSortByNumber"];
      ToolStripMenuItem mItemObj = (ToolStripMenuItem)ctxMeterMenu.Items["ctxMenuSortByName"];
      mItemNum.Checked = false;
      mItemObj.Checked = true;
      this.treeListView1_ColumnClick(this.treeListView1, new ColumnClickEventArgs(1));
    }

    private void ctxMenuSortByNumber_Click(object sender, EventArgs e)
    {
      ToolStripMenuItem mItemNum = (ToolStripMenuItem)ctxMeterMenu.Items["ctxMenuSortByNumber"];
      ToolStripMenuItem mItemObj = (ToolStripMenuItem)ctxMeterMenu.Items["ctxMenuSortByName"];
      mItemNum.Checked = true;
      mItemObj.Checked = false;
      this.treeListView1_ColumnClick(this.treeListView1, new ColumnClickEventArgs(1));
    }

    private void treeListView1_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      //SortOrder sortOrder = SortOrder.Ascending;
      //if (e.Column == 0)
      //{
      //  if (this.treeListView1.Columns[e.Column].Tag == null) {
      //    this.treeListView1.Columns[e.Column].Tag = SortOrder.Ascending;
      //    sortOrder = SortOrder.Ascending;
      //  }
      //  else {
      //    sortOrder = (SortOrder)this.treeListView1.Columns[e.Column].Tag;
      //  }
      //  __treeNodes.Sort((x, y) =>
      //  {
      //    if (sortOrder == SortOrder.Ascending)
      //    {
      //      return x.name.CompareTo(y.name);
      //    }
      //    else {
      //      return y.name.CompareTo(x.name);
      //    }
      //  });

      //  if (sortOrder == SortOrder.Ascending)
      //  {
      //    this.treeListView1.Columns[e.Column].Tag = SortOrder.Descending;
      //  }
      //  else {
      //    this.treeListView1.Columns[e.Column].Tag = SortOrder.Ascending;
      //  }

      //  ListViewExtensions.SetSortIcon(this.treeListView1, e.Column, sortOrder);
      //}
      //this.treeListView1.SetObjects(__treeNodes);
      //ResetDelegate();
      this.treeListView1.Sort(e.Column);
    }

    private void treeListView1_ColumnRightClick(object sender, ColumnClickEventArgs e)
    {
      this.ctxMeterMenu.Show(Cursor.Position);
    }

   
  }
}

