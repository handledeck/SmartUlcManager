using BrightIdeasSoftware;
using InterUlc.Db;
using ServiceStack.OrmLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin;
using UlcWin.Controls.ListViewHeaderMenu;
using UlcWin.Controls.UlcMeterComponet;
using UlcWin.DB;
using UlcWin.Drivers;
using UlcWin.Edit;
using UlcWin.Export;
using UlcWin.ui;
using static UlcWin.Native.NativeSort;

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
    internal StatusStrip __statusStrip;
    List<TreeListNodeModel> __search_model;
    int sort_column_num = 0;
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
      //this.treeListView1.SetObjects(__treeNodes);
      this.objectListView1.SetObjects(__valueDateTimes);
      this.objectListView1.EmptyListMsg = "Нет данных для просмотра";
      this.objectListView1.EmptyListMsgFont = new Font("Tahoma", 10);
      this.treeListView1.EmptyListMsg = "Нет данных для просмотра";
      this.treeListView1.EmptyListMsgFont = new Font("Tahoma", 10);
      //this.treeListView1.SelectionChanged += TreeListView1_SelectionChanged;
      // HeaderControl h = new HeaderControl(this.treeListView1);
      splitMeter.Panel2Collapsed = true;
      
    }

    
    public void SetValue(string connection, int parent_id)
    {
      this.__connection = connection;
      this.__parent_id = parent_id;
      __loadForm = (UlcWin.LoadForm)this.ParentForm;
      this.__db = __loadForm.__db;
      FillTreeList(DateTime.Now);
      ResetDelegate();
      this.treeListView1.FormatRow += TreeListView1_FormatRow;

    }

    public void RecalcStatusLebel() {
      int all = 0;
      int nData = 0;
      int swOff = 0;
      this.__statusStrip.Items[2].Visible = false;
      this.__statusStrip.Items[4].Visible = false;
      if (this.treeListView1.Items.Count != 0) {
        foreach (TreeListNodeModel item in this.treeListView1.Roots)
        {
          foreach (TreeListNodeModel it in item.Nodes)
          {
            all+=1;
            if (!it.is_true && it.meter_active==1)
            {
              nData+=1;
            }

            if (it.meter_active == 0)
              swOff+=1;
          }
          
        }
        this.__statusStrip.Items[0].Text = string.Format("Всего:{0}", all);
        this.__statusStrip.Items[1].Text = string.Format("Нет данных:{0}", nData);
        this.__statusStrip.Items[3].Text = string.Format("Отключенных:{0}", swOff);
      }

    }

    private void FillTreeList(DateTime dtData)
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
          string sql = string.Format("select mi.id ,mn.\"name\",mi.ip,mi.meter_type,mi.meter_factory,mv.date_time,mv.value,mv.is_true, mc.unit_type_id, mc.id as id_home, mc.rs_stat as rs_stat, mi.active as meter_active,mi.ctrl_id, mn.active as controller_active, mv.value_month as mv_month from main_nodes mn " +
                       "left join main_ctrlinfo mc on mc.id = mn.id " +
                       "left join meter_info mi on mi.ctrl_id = mc.id " +
                       "left join meter_value mv on mv.ctrl_id = mi.id and mv.date_time > '{0}' " +
                       "where mi.parent_id = {1}", dtData.ToString("yyyy-MM-dd"), __parent_id);
          IDbCommand cmd = db.CreateCommand();
          cmd.CommandText = sql;
          var reader = cmd.ExecuteReader();
          //Random random = new Random();
          while (reader.Read())
          {
            int id = int.MaxValue;
            string name = string.Empty;
            string ip = string.Empty;
            string meter_type = string.Empty;
            string meter_factory = string.Empty;
            DateTime dt = DateTime.MaxValue;
            bool is_true = false;
            int unit_type_id = int.MaxValue;
            int id_home = int.MaxValue;
            double value = double.MaxValue;
            double value_month = double.MaxValue;
            int rs_active = int.MaxValue;
            int meter_active = int.MaxValue;
            int ctrl_id = int.MaxValue;
            int controller_active = int.MaxValue;
            try
            {
              id = (int)reader[0];
              //int unit_type_id = (int)reader[1];
              name = (string)reader[1];
              //int id = (int)reader[3];
              //int ctrl_id = (int)reader[4];
              //int parent_id = (int)reader[5];
              ip = (string)reader[2];
              //DateTime dt = (DateTime)reader[3];
              if (reader[3].GetType() == typeof(DBNull) || reader[4].GetType() == typeof(DBNull))
                continue;
              meter_type = (string)reader[3];
              meter_factory = (string)reader[4];
              dt = reader[5].GetType() == typeof(DBNull) ? DateTime.MinValue : (DateTime)reader[5];
              value = reader[6].GetType() == typeof(DBNull) ? 0 : (double)reader[6];
              is_true = reader[7].GetType() == typeof(DBNull) ? false : (bool)reader[7];
              unit_type_id = reader[8].GetType() == typeof(DBNull) ? -1 : (int)reader[8];
              id_home = reader[9].GetType() == typeof(DBNull) ? -1 : (int)reader[9];
              rs_active = reader[10].GetType() == typeof(DBNull) ? -1 : (int)reader[10];
              meter_active = reader[11].GetType() == typeof(DBNull) ? -1 : (int)reader[11];
              ctrl_id = reader[12].GetType() == typeof(DBNull) ? -1 : (int)reader[12];
              controller_active = reader["controller_active"].GetType() == typeof(DBNull) ? -1 : (int)reader["controller_active"];
              value_month = reader["mv_month"].GetType() == typeof(DBNull) ? 0 : (double)reader["mv_month"];
            }
            catch (Exception el)
            {
              int x = 0;
            }
            TreeListNodeModel mt = new TreeListNodeModel
            {
              name = name,
              is_true = true,
              ip = ip,
              unit_type_id = unit_type_id,
              ctrl_id = ctrl_id,
              controller_active = controller_active,
              rs_active = Convert.ToBoolean(rs_active)
            };
            TreeListNodeModel treeListNodeModel = new TreeListNodeModel()
            {
              id = id,
              ctrl_id = ctrl_id,
              name = meter_type,
              date_time = dt,
              ip = ip,
              is_true = is_true,
              value = Math.Round(value, 2),
              meter_factory = meter_factory,
              meter_type = meter_type,
              unit_type_id = unit_type_id,
              rs_active = Convert.ToBoolean(rs_active),
              meter_active = meter_active,
              controller_active = controller_active,
              value_month=value_month
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
              treeListNodeModel.ParentNode = dic[id_home];
            }
            else
            {
              treeListNodeModel.ParentNode = dic[id_home];
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
            item.Value.name = item.Value.name;// + "(" + item.Value.Nodes[0].name + ")";
            item.Value.ip = item.Value.Nodes[0].ip;
            item.Value.meter_type = item.Value.Nodes[0].meter_type;
            item.Value.meter_factory = item.Value.Nodes[0].meter_factory;
            item.Value.value = item.Value.Nodes[0].value;
            item.Value.date_time = item.Value.Nodes[0].date_time;
            item.Value.unit_type_id = item.Value.Nodes[0].unit_type_id;
            item.Value.ctrl_id = item.Value.Nodes[0].ctrl_id;
            item.Value.is_true = item.Value.Nodes[0].is_true;
            item.Value.id = item.Value.Nodes[0].id;
            item.Value.parent_id = __parent_id;
            item.Value.meter_active = item.Value.Nodes[0].meter_active;
            item.Value.rs_active = item.Value.Nodes[0].rs_active;
            item.Value.controller_active = item.Value.Nodes[0].controller_active;
            item.Value.value_month = item.Value.Nodes[0].value_month;
            //item.Value.ParentNode = item.Value;
          }
          else if (item.Value.Nodes.Count > 1)
          {
            item.Value.rs_active = item.Value.Nodes[0].rs_active;
            item.Value.date_time = DateTime.MinValue;
            item.Value.meter_factory = "......";
            item.Value.meter_type = "......";
            item.Value.controller_active = item.Value.Nodes[0].controller_active;
           // item.Value.ParentNode = item.Value;
            //item.Value.value = "......";
            foreach (var itNodes in item.Value.Nodes)
            {
              if (itNodes.is_true)
              {
                item.Value.date_time = itNodes.date_time;
                
                break;
              }
            }
          }

          __treeNodes.Add(item.Value);
        }
        this.__search_model = new List<TreeListNodeModel>();
        this.__search_model.AddRange(__treeNodes.ToArray());
        this.treeListView1.SetObjects(__search_model.ToArray());
        ResetDelegate();
        if (__treeNodes.Count == 0)
        {
          this.button1.Enabled = false;
          this.button2.Enabled = false;
          this.button3.Enabled = false;
          this.label1.Enabled = false;
          this.textBox1.Enabled = false;
          this.treeListView1.ContextMenuStrip = null;
        }
        else
        {
          this.button1.Enabled = true;
          this.button2.Enabled = true;
          this.button3.Enabled = true;
          this.label1.Enabled = true;
          this.textBox1.Enabled = true;
          this.treeListView1.ContextMenuStrip = this.menuTree;
          this.textBox1.Text = "";

          if (this.sortOrder == SortOrder.Ascending)
          {
            this.sortOrder = SortOrder.Descending;
          }
          else if (this.sortOrder == SortOrder.Descending) {
            this.sortOrder = SortOrder.Ascending;
          }
          this.treeListView1_ColumnClick(this.treeListView1, new ColumnClickEventArgs(sort_column_num));
        }
      }
      catch (Exception ex)
      {
        int xx = 0;
      }
    }

    private void TreeListView1_FormatRow(object sender, FormatRowEventArgs e)
    {

      TreeListNodeModel vv = (TreeListNodeModel)e.Model;
      if (vv.unit_type_id == 0)
      {
        olvRs.CheckBoxes = false;
      }
      else {
        if (vv.ParentNode != null) {
          olvRs.CheckBoxes = false;
          
        }
         
        else {
          olvRs.CheckBoxes = true;
        }
       
      }
      if (vv.Nodes == null)
      {
        //if (vv.Nodes.Count > 1)
        //  return;
        //if (vv.Nodes.Count == 1)
        //{ 
        if (vv.meter_active == 0 || vv.controller_active == 0 || !vv.is_true)
        {
          e.Item.ForeColor = Color.Gray;
        }
        //}
      }
      else {
        if (vv.Nodes.Count == 1)
        { 
        if (vv.meter_active == 0 || vv.controller_active == 0 || !vv.is_true)
        {
          e.Item.ForeColor = Color.Gray;
        }
        }
      }
      ////if (vv.meter_active == 0)
      ////  e.Item.ForeColor = Color.Gray;
      //if (vv.Nodes == null)
      //{
      //  //e.ListView.FullRowSelect = true;
      //  //TreeListView1_SelectionChanged(this.treeListView1, null);
      //  //if (!vv.is_true)
      //  //e.Item.ForeColor = Color.Gray;
      //  //e.Item.Font = new Font("Tahoma", e.Item.Font.Size);

      //}
      //else
      //{
      //  //if (vv.Nodes.Count == 1)
      //  //{
      //  //  vv.name = vv.name+"(" + vv.Nodes[0].name + ")";
      //  //  vv.ip = vv.Nodes[0].ip;
      //  //  vv.meter_type = vv.Nodes[0].meter_type;
      //  //  vv.meter_factory = vv.Nodes[0].meter_factory;
      //  //  vv.value = vv.Nodes[0].value;
      //  //  vv.date_time = vv.Nodes[0].date_time;
      //  //  vv.unit_type_id = vv.Nodes[0].unit_type_id;
      //  //}
      //  //e.ListView.FullRowSelect = false;

      //  //if (!vv.is_true)
      //  //  e.Item.ForeColor = Color.Gray;
      //  //e.ListView.FullRowSelect = true;
      //  //if (!vv.is_true)
      //  //  e.Item.ForeColor = Color.Red;
      //  //e.Item.Font = new Font("Tahoma", e.Item.Font.Size);
      //}
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
          if (vv.Nodes.Count < 2)
          {
            if (vv.controller_active == 0)
              return "error";
            if (vv.meter_active == 0)
            {
              return "stop";
            }
            else
            {
              if (vv.is_true)
                return "nav_down";
              else
                return "warning";
            }


          }
          else
          {
            if (vv.is_part_true)
              return "part";
            else
            {
              if (vv.is_true)
                return "ok";
              else
                return "warning";
            }

          }
        }
        else
        {
          if (vv.meter_active == 0)
          {
            return "stop";
          }
          else
          {
            if (!vv.is_true)
              return "warning";
            else
              return "nav_down";
          }
        }

        //  if (!vv.is_true)
        //    return "error1";
        //  else if (vv.is_part_true)
        //    return "part";

        //  else {
        //    if (vv.Nodes.Count > 1)
        //    {
        //      if (vv.is_true)
        //        return "ok";
        //    }
        //    else { 
        //      if(vv.is_true)
        //        return "nav_down";
        //    }
        //    return "";
        //  }
        //}
        //else
        //{
        //  if (!vv.is_true)
        //    return "error";
        //  else
        //    return "nav_down";
        //}


      };

      this.olvTp.AspectToStringConverter = delegate (object x)
      {
        string name = (string)x;
        string[] aTp = name.Split(',');
        if (aTp.Length == 3)
        {
          return aTp[2].Trim();
        }
        else
        {
          return "---";
        }
      };

      this.olvName.AspectToStringConverter = delegate (object x)
      {
        string name = (string)x;
        string[] aTp = name.Split(',');
        if (aTp.Length == 3)
        {
          return string.Format("{0}({1})",aTp[0].Trim(),aTp[1].Trim());
        }
        else
        {
          return aTp[0];
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

      this.olvRs.AspectToStringConverter = delegate (object x)
      {
        if (x != null)
        {
          bool? t = (bool)x;
          if (t.HasValue)
          {
            if (t == false)
              return "...";
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
              //return;
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
          DateTime selDt = this.monthPicker1.Value;
          DateTime dtstart = new DateTime(selDt.Year, selDt.Month, 1, 0, 0, 0);
          DateTime selEndDt = selDt.AddMonths(1);
          DateTime dtend = new DateTime(selEndDt.Year, selEndDt.Month, 1, 0, 0, 0);
          //DateTime dtend = DateTime.Now.AddDays(1);
          //DateTime dtstart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
          Dictionary<string, ValueDateTime> lstVdt = new Dictionary<string, ValueDateTime>();
          DateTime res = dtstart;
          //DateTime lstDt = dtstart;

          for (int i = 0; i < DateTime.DaysInMonth(dtstart.Year, dtstart.Month); i++)
          {
            lstVdt.Add(res.ToString("yyyy-MM-dd"), new ValueDateTime()
            {
              dt = res.ToString("yyyy-MM-dd"),
              is_true = false
            });
            res = res.AddDays(1);
          }
          int id = treeListNodeModel.id;
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


                //if (!lstVdt.ContainsKey(dt_str))
                //{
                lstVdt[dt_str] = new ValueDateTime()
                {
                  dt = dt_str,
                  id = id,
                  value = Math.Round(value, 2),
                  is_true = true
                };
                //}
              }
              reader.Close();
              string sql_cntrl = string.Format("select mn.id , mn.\"name\", mc.ip_address,mn.active ,mc.rs_stat,mn.light,mc.unit_type_id from main_nodes mn " +
                                             "left join main_ctrlinfo mc on mc.id = mn.id " +
                                              "where mn.id = {0}", treeListNodeModel.ctrl_id);
              List<DbUlcShortView> ormDbConfig = db.Select<DbUlcShortView>(sql_cntrl);
              __valueDateTimes = lstVdt.Values.ToList<ValueDateTime>();

              this.objectListView1.SetObjects(__valueDateTimes);

              //this.dbUlcShortViewBindingSource.DataSource= ormDbConfig.ToArray();
              //if (ormDbConfig[0].unit_type_id == 0)
              //{
              //  this.dataGridView1.Columns[4].Visible = false;
              //}
              //else
              //{
              //  this.dataGridView1.Columns[4].Visible = true;
              //}
              this.dataGridView1.Rows.Clear();
              if (ormDbConfig[0].active)
              {
                dataGridView1.Rows.Add(this.imageList1.Images["nav_down"],
                  ormDbConfig[0].name, ormDbConfig[0].ip_address, ormDbConfig[0].rs_stat, ormDbConfig[0].light);
              }
              else
              {
                dataGridView1.Rows.Add(this.imageList1.Images["error"],
                  ormDbConfig[0].name, ormDbConfig[0].ip_address, ormDbConfig[0].rs_stat, ormDbConfig[0].light);
              }

            }
           

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
          if (!it.is_true && it.rs_active)
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
              ctrl_id = it.id,
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
      FillTreeList(this.monthPicker1.Value);
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
                  MeterAllValues meterAllValues = EnMera318BY.GetSumAllValue(item.meter_factory, client);
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
                else if (item.meter_type.Contains("СЕ318") || item.meter_type.Contains("CE318"))
                {
                 
                  float value = 0;
                  if (!EnMera318BY.GetValue(EnMera318Fun.EnergyStartDay, item.meter_factory, client, 10000, out value))
                    throw new Exception("ошибка получения данных");
                  item.value = value;
                  item.is_true = true;
                  item.updated = true;
                  item.date_time = DateTime.Now;
                }
                else if (item.meter_type.Contains("СС") || item.meter_type.Contains("СС"))
                {
                  MeterAllValues meterAllValues = Granelectro.GetSumAllValue(item.meter_factory, client);
                  Exception exp = null;
                  float? value = Granelectro.GetSumValue( EnGranSys.ACCUMULATED_ENERGY_DAY,item.meter_factory, client, out exp);
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

    //private void treeListView1_MouseUp(object sender, MouseEventArgs e)
    //{
    //  if (this.treeListView1.Items.Count > 0)
    //  {
    //    if (e.Button == MouseButtons.Right)
    //    {
    //      this.menuTree.Visible = true;
    //    }
    //    else
    //    {
    //      this.menuTree.Visible = false;
    //    }
    //  }
    //  else {
    //    this.menuTree.Visible = false;
    //  }
    //}

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
        parent_id = item.parent_id,
        active = item.meter_active
      };
      using (MeterEditFrom mMrom = new MeterEditFrom(meterInfo))
      {
        if (mMrom.ShowDialog() == DialogResult.OK)
        {
          meterInfo.meter_factory = mMrom.txtBoxPlant.Text;
          meterInfo.meter_type = mMrom.GetDeviceByIndex();
          meterInfo.active = mMrom.cbActMeter.Checked ? 1 : 0;
          item.meter_factory = mMrom.txtBoxPlant.Text;
          item.meter_type = mMrom.GetDeviceByIndex();
          meterInfo.active = mMrom.cbActMeter.Checked ? 1 : 0;
          meterInfo.parent_id = __parent_id;
          __db.SetCrudMeterInfo(new List<MeterInfo>() { meterInfo });

          FillTreeList(this.monthPicker1.Value);

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
              //Exception ex;
              //float? value = EnMera102.GetSumDayValue(item.meter_factory, client, out ex);
              MeterAllValues meterAllValues = EnMera102.GetSumAllValue(item.meter_factory, client);
              if (meterAllValues != null)
              {
                item.value = meterAllValues.EnergySumDay.Value;
                item.value_month = meterAllValues.EnergySumMonth.Value;
                item.is_true = true;
                item.updated = true;
                item.date_time = DateTime.Now;
                wf.SetLabelText(meterAllValues.EnergySumDay.Value.ToString());
              }
              else {
                throw new Exception("ошибка получения данных");
              }
            }
            else if (item.meter_type.Contains("СЕ318") || item.meter_type.Contains("CE318"))
            {
              MeterAllValues meterAllValues= EnMera318BY.GetSumAllValue(item.meter_factory, client);
              //float value = 0;
              //if (!EnMera318BY.GetValue(EnMera318Fun.EnergyStartDay, item.meter_factory, client, 10000, out value))
              //throw new Exception("ошибка получения данных");
              if (meterAllValues != null)
              {
                item.value = Math.Round(meterAllValues.EnergySumDay.Value, 2);
                item.value_month = Math.Round(meterAllValues.EnergySumMonth.Value, 2);
                item.is_true = true;
                item.updated = true;
                item.date_time = DateTime.Now;
                wf.SetLabelText(meterAllValues.EnergySumDay.Value.ToString());
              }
              else
              {
                throw new Exception("ошибка получения данных");
              }
            }
            else if (item.meter_type.Contains("СС") || item.meter_type.Contains("СС"))
            {
              MeterAllValues meterAllValues= Granelectro.GetSumAllValue(item.meter_factory, client);
              if (meterAllValues != null)
              {
                //float? value = Granelectro.GetSumValue(EnGranSys.ACCUMULATED_ENERGY_DAY, item.meter_factory, client, out exp);
                //if (exp == null && value.HasValue)
                //{
                item.value = Math.Round(meterAllValues.EnergySumDay.Value, 2);
                item.value_month = Math.Round(meterAllValues.EnergySumMonth.Value,2);
                item.is_true = true;
                item.updated = true;
                item.date_time = DateTime.Now;
                wf.SetLabelText(meterAllValues.EnergySumDay.ToString());
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
                    MeterValue mv = db.Single<MeterValue>(x => x.date_time > dtc && x.ctrl_id == item.id);
                    if (mv != null)
                    {
                      //item.id = mv.id;
                      mv.value = Math.Round(item.value.Value, 2);
                      mv.value_month = Math.Round(item.value_month.Value,2);
                      mv.date_time = DateTime.Now;
                      mv.is_true = true;
                      db.Save<MeterValue>(mv);
                    }
                    else
                      db.Insert<MeterValue>(TreeListNodeModel.ConvertToMeterValue(item));
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
      //ListViewExtensions.SetSortIcon(this.treeListView1, 1, SortOrder.Ascending);
      if (e.Button == MouseButtons.Right)
      {
        if (this.treeListView1.Items.Count ==0)
        {
          this.menuTree.Hide();
        }
        //Control p = this.GetChildAtPoint(e.Location);
        //this.menuTree.Show(Cursor.Position);
      }
    }

    private void ctxMenuSortByName_Click(object sender, EventArgs e)
    {
      //ToolStripMenuItem mItemNum = (ToolStripMenuItem)ctxMeterMenu.Items["ctxMenuSortByNumber"];
      //ToolStripMenuItem mItemObj = (ToolStripMenuItem)ctxMeterMenu.Items["ctxMenuSortByName"];
      //mItemNum.Checked = false;
      //mItemObj.Checked = true;
      //this.treeListView1_ColumnClick(this.treeListView1, new ColumnClickEventArgs(0));
    }

    private void ctxMenuSortByNumber_Click(object sender, EventArgs e)
    {
      //ToolStripMenuItem mItemNum = (ToolStripMenuItem)ctxMeterMenu.Items["ctxMenuSortByNumber"];
      //ToolStripMenuItem mItemObj = (ToolStripMenuItem)ctxMeterMenu.Items["ctxMenuSortByName"];
      //mItemNum.Checked = true;
      //mItemObj.Checked = false;
      //this.treeListView1_ColumnClick(this.treeListView1, new ColumnClickEventArgs(0));
    }

    SortOrder __sortOrder = SortOrder.None;
    
    class comp : IComparer<TreeListNodeModel>
    {
      SortOrder sortOrder = SortOrder.None;
      UlcSort ulcSort = UlcSort.NAME;
      public comp(SortOrder sortOrder, UlcSort ulcSort)
      {
        this.sortOrder = sortOrder;
        this.ulcSort = ulcSort;
      }

      int ParceTp(string x, string y) {

        Regex reg = new Regex(@"\d+$");
        Match match = reg.Match(x.TrimEnd());
        Match match1 = reg.Match(y.TrimEnd());
        if (match.Success && match1.Success)
        {
          int fInt = 0;
          int sInt = 0;
          bool fb = int.TryParse(match.Value, out fInt);
          bool sb = int.TryParse(match1.Value, out sInt);

          if (!fb && !sb)
          {
            return -1;
          }
          else
          {
            if (fInt == sInt)
              return 0;
            if (sortOrder == SortOrder.Ascending)
            {
              if (fInt > sInt)
                return 1;
              else return -1;
            }
            else
            {
              if (fInt < sInt)
                return 1;
              else return -1;
            }
          }
        }
        return 0;
      }

      public int CompareDateTime(DateTime? dtF, DateTime? dtS)
      {
        //DateTime dtF;
        //DateTime dtS;
        //bool bF = DateTime.TryParse(first, out dtF);
        //bool bS = DateTime.TryParse(second, out dtS);
        ////DateTime fst = DateTime.Parse(first);
        ////DateTime scd = DateTime.Parse(second);
        //if (!bF || !bS)
        //  return 0;
        if (dtF == dtS)
          return 0;
        if (dtF > dtS)
          return 1;
        return -1;
      }

      public int CompareIpAddresses(System.Net.IPAddress first, System.Net.IPAddress second)
      {
        var int1 = this.ToUint32(first);
        var int2 = this.ToUint32(second);
        if (int1 == int2)
          return 0;
        if (this.sortOrder == SortOrder.Ascending)
        {
          if (int1 > int2)
            return 1;
        }
        else if (this.sortOrder == SortOrder.Descending)
        {
          if (int1 < int2)
            return 1;
        }
        return -1;
      }

      public int Compare(TreeListNodeModel x, TreeListNodeModel y)
      {
        if (x == null || y == null)
          return 0; ;
        if (ulcSort == UlcSort.DATETIME)
          return CompareDateTime(x.date_time, y.date_time);
        else if (ulcSort == UlcSort.IP)
          return CompareIpAddresses(System.Net.IPAddress.Parse(x.ip), System.Net.IPAddress.Parse(y.ip));
        else if (ulcSort == UlcSort.TP)
          return ParceTp(x.name, y.name);
        else if (ulcSort == UlcSort.CONTROLER_TYPE) {
          return CompareControllerType(x, y);
        }
        //switch (ulcSort)
        //{
        //  case UlcSort.IP:
        //    return CompareTp(x.ip, y.ip);
        //  case UlcSort.DATETIME:
        //    CompareDateTime(x.date_time, y.date_time);
        //    break;
        //  case UlcSort.TP:
        //    return ParceTp(x.name, y.name);

          //}
        return 0;
      }

      public int CompareControllerType(TreeListNodeModel x, TreeListNodeModel y) {
        try
        {
          if (x.unit_type_id == y.unit_type_id)
            return 0;
          if (this.sortOrder == SortOrder.Ascending)
          {
            if (x.unit_type_id > y.unit_type_id)
              return 1;
          }
          else if (this.sortOrder == SortOrder.Descending)
          {
            if (x.unit_type_id < y.unit_type_id)
              return 1;
          }
          return -1;
        }
        catch (Exception)
        {

          return -1;
        }
       
      }

      public uint ToUint32(System.Net.IPAddress ipAddress)
      {
        var bytes = ipAddress.GetAddressBytes();

        return ((uint)(bytes[0] << 24)) |
               ((uint)(bytes[1] << 16)) |
               ((uint)(bytes[2] << 8)) |
               ((uint)(bytes[3]));
      }
    }


    SortOrder sortOrder = SortOrder.None;
    private void treeListView1_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      
      if (e.Column>4)
      {
        NativeListView.SetColumnImage(this.treeListView1, sort_column_num, SortOrder.None, -1);
        return;
      }
      //sortOrder = SortOrder.None;
      var clTag = this.treeListView1.Columns[e.Column].Tag;
      if (clTag != null)
      {
        sortOrder = (SortOrder)clTag;
      }
      else {
        sortOrder = SortOrder.Ascending;
        this.treeListView1.Columns[e.Column].Tag = SortOrder.Ascending;
      }
      if (e.Column == 0)
      {
        if (sortOrder == SortOrder.Ascending)
        {
          __treeNodes = __treeNodes.OrderBy(x => x.name).ToList();
        }
        else if (sortOrder == SortOrder.Descending)
        {
          __treeNodes = __treeNodes.OrderByDescending(x => x.name).ToList();
        }
      }
      else if (e.Column == 1)
      {
        if (sortOrder == SortOrder.Ascending)
        {
          __treeNodes.Sort(new comp(SortOrder.Ascending, UlcSort.TP));
        }
        else
        {
          __treeNodes.Sort(new comp(SortOrder.Descending, UlcSort.TP));
        }

      }
      else if (e.Column == 2)
      {
        if (sortOrder == SortOrder.Ascending)
        {
          __treeNodes = __treeNodes.OrderBy(x => x.date_time).ToList();
        }
        else
        {
          __treeNodes = __treeNodes.OrderByDescending(x => x.date_time).ToList();
        }
      }
      else if (e.Column == 4)
      {
          __treeNodes.Sort(new comp(sortOrder, UlcSort.IP));
      }
      else if (e.Column == 3)
      {
        __treeNodes.Sort(new comp(sortOrder, UlcSort.CONTROLER_TYPE));
      }
      //__treeNodes.Sort(new comp(sortOrder));
      this.treeListView1.SetObjects(__treeNodes);
      if (sortOrder == SortOrder.Ascending)
      {
        NativeListView.SetColumnImage(this.treeListView1, e.Column, SortOrder.Descending, 1);
        this.treeListView1.Columns[e.Column].Tag = SortOrder.Descending;
      }
      else
      {
        NativeListView.SetColumnImage(this.treeListView1, e.Column, SortOrder.Ascending, 1);
        this.treeListView1.Columns[e.Column].Tag = SortOrder.Ascending;
      }
      if (sort_column_num != e.Column)
      {
        NativeListView.SetColumnImage(this.treeListView1, sort_column_num, SortOrder.None, -1);
      }
      //if (e.Column == 1 || e.Column == 4)
      //{

      //  //__treeNodes.Sort(new comp(__sortOrder));

      //  //this.treeListView1.SetObjects(__treeNodes);
      //  //this.treeListView1.Update();
      //  if(this.treeListView1.Columns[e.Column].Tag)
      //  NativeListView.SetColumnImage(this.treeListView1, e.Column, __sortOrder, 1);
      //}
      // NativeListView.SetColumnImage(this.treeListView1, e.Column, __sortOrder, 1);
      sort_column_num = e.Column;


      // // listView.Tag

      //}
      //else if (e.Column == 4)
      //{


      //  ListView listView = (ListView)this.treeListView1;

      //  //listView.Tag

      //}

      //ListView listView = (ListView)this.treeListView1;
      ////listView.Columns[e.Column].t
      //if (e.Column == 0) {
      //  if (__sortOrder == SortOrder.None)
      //    __sortOrder = SortOrder.Ascending;

      //NativeListView.SetColumnImage(this.treeListView1, e.Column, __sortOrder, 0);
      //}
      //this.treeListView1.CustomSorter = delegate (OLVColumn column, SortOrder order) {
      //  int x = 0;
      //  //this.incidentListView.ListViewItemSorter = new ColumnComparer(
      //  //        this.isEmergencyColumn, SortOrder.Descending, column, order);
      //};
      //SortOrder sortOrder = SortOrder.None;
      //if (this.treeListView1.Items.Count == 0)
      //  return;
      //if (this.treeListView1.Columns[e.Column].Tag == null)
      //{
      //  this.treeListView1.Columns[e.Column].Tag = SortOrder.Ascending;
      //  sortOrder = SortOrder.Ascending;
      //  // __sortOrder = SortOrder.Ascending;
      //}
      //else
      //{
      //  sortOrder = (SortOrder)this.treeListView1.Columns[e.Column].Tag;
      //  if (sortOrder == SortOrder.Ascending)
      //  {
      //    this.treeListView1.Columns[e.Column].Tag = SortOrder.Descending;
      //  }
      //  else
      //  {
      //    this.treeListView1.Columns[e.Column].Tag = SortOrder.Ascending;
      //  }
      //}
      //if (e.Column == 0)
      //{
      //  if (this.ctxMenuSortByName.Checked)
      //  {
      //    __treeNodes.Sort((a, b) =>
      //    {
      //      if (sortOrder == SortOrder.Ascending)
      //      {
      //        return a.name.CompareTo(b.name);
      //      }
      //      else
      //      {
      //        return b.name.CompareTo(a.name);
      //      }
      //    });
      //  }
      //  else if (this.ctxMenuSortByNumber.Checked)
      //  {
      //    try
      //    {
      //      __treeNodes.Sort((a, b) =>
      //      {
      //        if (a == null || b == null)
      //          return -1;
      //        Regex reg = new Regex(@"\d+$");
      //        Match match = reg.Match(a.name.TrimEnd());
      //        Match match1 = reg.Match(b.name.TrimEnd());
      //        if (match.Success && match1.Success)
      //        {
      //          int fInt = 0;
      //          int sInt = 0;
      //          bool fb = int.TryParse(match.Value, out fInt);
      //          bool sb = int.TryParse(match1.Value, out sInt);
      //          if (!fb && !sb)
      //          {
      //            return -1;
      //          }

      //          if (sortOrder == SortOrder.Ascending)
      //          {
      //            if (fInt == sInt)
      //              return 0;
      //            if (fInt > sInt)
      //              return 1;
      //            else return -1;

      //          }
      //          else
      //          {
      //            if (fInt == sInt)
      //              return 0;
      //            if (fInt < sInt)
      //              return 1;
      //            else return -1;
      //          }
      //        }
      //        return -1;
      //      });
      //    }
      //    catch { }
      //  }
      //}
      //else if (e.Column == 1)
      //{
      //  sortOrder = (SortOrder)this.treeListView1.Columns[e.Column].Tag;
      //  if (sortOrder == SortOrder.Ascending)
      //  {
      //    try
      //    {
      //      __treeNodes.Sort((a, b) =>
      //  {

      //    if (a.date_time > b.date_time)
      //    {
      //      return 1;
      //    }
      //    else if (a.date_time == b.date_time)
      //      return 0;
      //    else
      //      return -1;
      //  });
      //    }
      //    catch (Exception exx)
      //    {
      //      throw;
      //    }

      //  }
      //  else
      //  {
      //    try
      //    {
      //      __treeNodes.Sort((a, b) =>
      //    {

      //      if (a.date_time < b.date_time)
      //      {
      //        return 1;
      //      }
      //      else if (a.date_time == b.date_time)
      //        return 0;
      //      else
      //        return -1;
      //    });
      //    }
      //    catch (Exception exp)
      //    {
      //    }
      //  }
      //}
      //else if (e.Column == 2)
      //{
      //  try
      //  {
      //    __treeNodes.Sort((a, b) =>
      //    {
      //      if (sortOrder == SortOrder.Ascending)
      //      {
      //        if (a.unit_type_id < b.unit_type_id)
      //        {
      //          return 1;
      //        }
      //        else if (a.unit_type_id == b.unit_type_id)
      //          return 0;
      //        else
      //          return -1;
      //      }
      //      else
      //      {
      //        if (a.unit_type_id > b.unit_type_id)
      //        {
      //          return 1;
      //        }
      //        else if (a.unit_type_id == b.unit_type_id)
      //          return 0;
      //        else
      //          return -1;
      //      }
      //    });
      //  }
      //  catch { }
      //}
      //else if (e.Column == 3)
      //{
      //  __treeNodes.Sort((a, b) =>
      //  {
      //    try
      //    {
      //      if (a != null && b != null)
      //      {

      //        System.Net.IPAddress ipOne = System.Net.IPAddress.Parse(a.ip);
      //        System.Net.IPAddress ipTwo = System.Net.IPAddress.Parse(b.ip);
      //        var int1 = this.ToUint32(ipOne);
      //        var int2 = this.ToUint32(ipTwo);
      //        if (int1 == int2)
      //          return 0;
      //        if (sortOrder == SortOrder.Ascending)
      //        {
      //          if (int1 > int2)
      //            return 1;
      //        }
      //        else if (sortOrder == SortOrder.Descending)
      //        {
      //          if (int2 > int1)
      //            return 1;
      //        }
      //        else
      //          return -1;
      //      }
      //      return -1;
      //    }
      //    catch (Exception)
      //    {
      //      return -1;
      //    }

      //  });
      //}

      ////if (__sortOrder == SortOrder.Ascending)
      ////{
      ////  this.treeListView1.Columns[e.Column].Tag = SortOrder.Descending;
      ////}
      ////else
      ////{
      ////  this.treeListView1.Columns[e.Column].Tag = SortOrder.Ascending;
      ////}

      //this.treeListView1.SetObjects(__treeNodes);
      //if (e.Column == 0 || e.Column == 1 || e.Column == 2 || e.Column == 3)
      //{
      //  NativeListView.SetColumnImage(this.treeListView1, e.Column, sortOrder, 0);

      //}// this.treeListView1.Columns[e.Column].Tag = sortOrder;
    }

    public uint ToUint32(System.Net.IPAddress ipAddress)
    {
      var bytes = ipAddress.GetAddressBytes();

      return ((uint)(bytes[0] << 24)) |
             ((uint)(bytes[1] << 16)) |
             ((uint)(bytes[2] << 8)) |
             ((uint)(bytes[3]));
    }

    private void treeListView1_ColumnRightClick(object sender, ColumnClickEventArgs e)
    {
     // this.ctxMeterMenu.Show(Cursor.Position);
    }

    private void MeterValueChnged(object sender, EventArgs e)
    {
      TreeListView1_SelectionChanged(this.treeListView1, null);
    }

    private void treeListView1_SubItemChecking(object sender, SubItemCheckingEventArgs e)
    {
      DialogResult result = DialogResult.Cancel;
      if (e.NewValue == CheckState.Unchecked)
      {
        result = MessageBox.Show("Не учитывать контроллер в статистике по RS-485?", "Статистика RS-485", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      }
      else {
        result = MessageBox.Show("Учитывать контроллер в статистике по RS-485?", "Статистика RS-485", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      }
      if (result == DialogResult.Yes)
      {
        TreeListNodeModel md = (TreeListNodeModel)e.RowObject;
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          OrmDbInfo ormDbInfo = db.Single<OrmDbInfo>(x => x.ip_address == md.ip);
          if (ormDbInfo != null)
          {
            ormDbInfo.rs_stat = e.NewValue == CheckState.Checked ? 1 : 0;
            db.Update<OrmDbInfo>(ormDbInfo);
          }
          else
          {
            MessageBox.Show("Ошибка сохранения в БД");
          }
        }
      }
      else {
        e.NewValue = e.CurrentValue;
      }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void treeListView1_AfterSorting(object sender, AfterSortingEventArgs e)
    {
      __sortOrder = e.SortOrder;
    }

    

    private void textBox1_TextChanged_1(object sender, EventArgs e)
    {
      
      
        //TreeListNodeModel[] treeListNodeModels = (from TreeListNodeModel item in this.__search_model select (TreeListNodeModel)item).ToArray();
       
      //__treeNodes.AddRange(treeListNodeModels);
      

      TreeListNodeModel[] listViewItem = __search_model.Where(i => string.IsNullOrEmpty(this.textBox1.Text) ||
       i.name.Contains(this.textBox1.Text) ||
       i.ip.Contains(this.textBox1.Text)).Select(c => c).ToArray();
      __treeNodes.Clear();
      __treeNodes.AddRange(listViewItem);
      this.treeListView1.SetObjects(__treeNodes);
       //i.date_time.Value.Contains(this.textBox1.Text)).Select(c => c).ToArray();
      //LstViewItm.Items.AddRange(listViewItem);
      
    }
  }
}

