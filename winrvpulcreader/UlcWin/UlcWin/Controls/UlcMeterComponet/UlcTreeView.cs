using BrightIdeasSoftware;
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
using UlcWin.Controls.UlcMeterComponet;
using UlcWin.Drivers;
using UlcWin.ui;

namespace GettingStartedTree
{
  public partial class UlcTreeView : UserControl
  {
    string __connection = string.Empty;
    int __parent_id = -1;
    List<TreeListNodeModel> __treeNodes = new List<TreeListNodeModel>();
    List<ValueDateTime> __valueDateTimes = new List<ValueDateTime>();
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
      this.objectListView1.EmptyListMsg = "This database has no rows";
      this.objectListView1.EmptyListMsgFont = new Font("Tahoma", 10);
      this.treeListView1.EmptyListMsg = "This database has no rows";
      this.treeListView1.EmptyListMsgFont = new Font("Tahoma", 10);
     
      this.treeListView1.SelectionChanged += TreeListView1_SelectionChanged;
    }
    
    public void SetValue(string connection,int parent_id)
    {
      this.__connection = connection;
      this.__parent_id = parent_id;
      FillTreeList();
      ResetDelegate();
      this.treeListView1.FormatRow += TreeListView1_FormatRow;
    }

    private void FillTreeList()
    {
      Dictionary<int, TreeListNodeModel> dic = new Dictionary<int, TreeListNodeModel>();
      MeterValue.CheckTableDb(__connection);
      List<MeterValue> mv = new List<MeterValue>();
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
                                    "from meter_info mi "+
                                    "left join meter_value mv on mi.id = mv.ctrl_id and mv.date_time > '{0}' "+
                                    "left join main_nodes mn on mn.id = mi.ctrl_id "+
                                    "left join main_ctrlinfo mc on mc.id = mi.ctrl_id "+
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
            int id_home= (int)reader[9];
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
              value = value,
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
                dic[id_home].is_true = false;
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
          __treeNodes.Add(item.Value);
        }
        this.treeListView1.SetObjects(__treeNodes);
        ResetDelegate();
      }
      catch (Exception ex)
      {
        int xx = 0;
      }
    }

    private void TreeListView1_FormatRow(object sender, FormatRowEventArgs e)
    {

      TreeListNodeModel vv = (TreeListNodeModel)e.Model;
      if (vv.Nodes == null)
      {
        //e.ListView.FullRowSelect = true;
        //TreeListView1_SelectionChanged(this.treeListView1, null);
        if (!vv.is_true)
          e.Item.ForeColor = Color.Gray;
        e.Item.Font = new Font("Tahoma", e.Item.Font.Size);

      }
      else
      {
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
        return true;//(x is ArtistExample) || (x is AlbumExample);
      };

      // What objects should belong underneath the given model object?
      this.treeListView1.ChildrenGetter = delegate (Object x)
      {
        TreeListNodeModel vv = (TreeListNodeModel)x;
        //List<MeterValue> l = (List<MeterValue>)x;
        return vv.Nodes;
        //throw new ArgumentException("Should be Artist or Album");
      };

      this.olvName.ImageGetter = delegate (Object x)
      {
        TreeListNodeModel vv = (TreeListNodeModel)x;
        if (vv.Nodes != null)
        {
          if (!vv.is_true)
            return "error";
          else
            return "ok";
        }

        else
        {
          if (!vv.is_true)
            return "err";
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
        if (treeListNodeModel.Nodes == null)
        {
          DateTime dtend = DateTime.Now.AddDays(1);
          DateTime dtstart = new DateTime(dtend.Year, dtend.Month, 1);
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
                    value = value,
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
      else {
        e.Item.ForeColor = Color.Black;
      }

      int x = 0;
    }

    private void treeListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
      TreeListView treeListView = (TreeListView)sender;
      
      TreeListNodeModel vv = (TreeListNodeModel)treeListView.SelectedObject;
      int x = 0;
      //TreeListNodeModel vv = (TreeListNodeModel)e.Model;
      if (vv.Nodes == null)
      {
        treeListView.FullRowSelect = true;
       
        //ll.SubItems[5].BackColor = Color.Red;
        //TreeListView1_SelectionChanged(this.treeListView1, null);
        //if (!vv.is_true)
        //  e.Item.ForeColor = Color.Gray;
        //e.Item.Font = new Font("Courier New", e.Item.Font.Size);

      }
      else
      {
        treeListView.FullRowSelect = false;

        //if (!vv.is_true)
        //  e.Item.ForeColor = Color.Gray;
        //e.ListView.FullRowSelect = true;
        //if (!vv.is_true)
        //  e.Item.ForeColor = Color.Red;
        //e.Item.Font = new Font("Tahoma", e.Item.Font.Size);
      }
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

      foreach (var item in this.treeListView1.Roots)
      {
        TreeListNodeModel model = (TreeListNodeModel)item;

        model.Validated();

      }
      if (lstMv.Count > 0)
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          db.Insert<MeterValue>(lstMv.ToArray());
        }
      }
    }

    public void ReadMetersValue(List<TreeListNodeModel> tLst,int count) {
      CancellationTokenSource tokenSource=new CancellationTokenSource();
      CancellationToken token= tokenSource.Token;
      long prog_value = 0;
      List<Task> tasks = new List<Task>();
      using (MeterProgress mp=new MeterProgress())
      {
        mp.SetTasksToken(tokenSource, count);
        for (int i = 0; i < tLst.Count; i++)
        {
          Task tsk = new Task(new Action<object>((obj) => {
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
              mp.SetLabelText(string.Format("{1}:{0}", item.ip, item.name));
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
                  string num = item.meter_factory;

                  num = num.Substring(num.Length - 4, 4);
                  ushort addr = 0;
                  if (ushort.TryParse(num, out addr))
                  {
                    byte[] buffer = new byte[128];
                    byte[] buf = EnMera102.packbuf(EnMera102.EnumFunEnMera.ReadTariffSumOfDay, new byte[] { 1 }, 1, addr);
                    Exception exp = EnMera102.Read(buf, 128, client, out buffer);
                    if (exp == null)
                    {
                      float ds = (float)BitConverter.ToInt32(buffer, 9);
                      item.value = (ds / 100);
                      item.is_true = true;
                      item.updated = true;
                      item.date_time = DateTime.Now;
                    }
                    else throw exp;
                  }
                  else throw new Exception("ошибка получения данных");
                }
                else if (item.meter_type.Contains("СС") || item.meter_type.Contains("СС"))
                {
                  string num = item.meter_factory;

                  byte addr = 0;
                  if (!string.IsNullOrEmpty(num))
                  {
                    if (char.IsDigit(num, 0))
                    {
                      try
                      {
                        num = num.Substring(num.Length - 2, 2);
                        if (!byte.TryParse(num, out addr))
                        {
                          addr = 0;
                        }
                      }
                      catch { addr = 0; }
                    }
                  }
                  if (client == null)
                    throw new Exception("Ошибка открытия соединения");
                  Exception ex = null;
                  var xx = Granelectro.ReadData(item.ip, client, addr, out ex);
                  if (xx != null)
                  {
                    item.is_true = true;
                    item.value = Math.Round((float)xx[0], 3);
                    item.updated = true;
                    item.date_time = DateTime.Now;
                  }
                }
                else
                {
                  throw new Exception("Счетчик не поддерживается");
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

    void ReadValueFromMeter(List<TreeListNodeModel> tLst)
    {
      //using (SimpleWaitForm si = new SimpleWaitForm())
      //{
      //  si.RunAction(new Action(() =>
      //  {
      //    string ip_loc = string.Empty;
      //    TcpClient client = null;
      //    foreach (var item in tLst)
      //    {
      //      si.SetLabelText(string.Format("Опрос счетчика {0} ip:{1}", item.name, item.ip));
      //      try
      //      {
      //        if (client != null && ip_loc.Equals(item.ip))
      //        {

      //        }
      //        else
      //        {
      //          if (client != null)
      //          {
      //            client.Close();
      //            client = null;
      //          }
      //          client = GetConnection(item.ip, 10250);
      //          if (client == null)
      //            throw new Exception();
      //        }
      //        ip_loc = item.ip;
      //        if (item.meter_type.Contains("СЕ102") || item.meter_type.Contains("CE102"))
      //        {
      //          string num = item.meter_factory;

      //          num = num.Substring(num.Length - 4, 4);
      //          ushort addr = 0;
      //          if (ushort.TryParse(num, out addr))
      //          {
      //            byte[] buffer = new byte[128];
      //            byte[] buf = EnMera102.packbuf(EnMera102.EnumFunEnMera.ReadTariffSumOfDay, new byte[] { 1 }, 1, addr);
      //            Exception exp = EnMera102.Read(buf, 128, client, out buffer);
      //            if (exp == null)
      //            {
      //              float ds = (float)BitConverter.ToInt32(buffer, 9);
      //              item.value = (ds / 100);
      //              item.is_true = true;
      //            }
      //            else throw exp;
      //          }
      //          else throw new Exception("ошибка получения данных");

      //        }
      //        else if (item.meter_type.Contains("СС") || item.meter_type.Contains("СС"))
      //        {
      //          string num = item.meter_factory;

      //          byte addr = 0;
      //          if (!string.IsNullOrEmpty(num))
      //          {
      //            if (char.IsDigit(num, 0))
      //            {
      //              try
      //              {
      //                num = num.Substring(num.Length - 2, 2);
      //                if (!byte.TryParse(num, out addr))
      //                {
      //                  addr = 0;
      //                }
      //              }
      //              catch { addr = 0; }
      //            }
      //          }
      //          if (client == null)
      //            throw new Exception("Ошибка открытия соединения");
      //          Exception ex = null;
      //          var xx = Granelectro.ReadData(item.ip, client, addr, out ex);
      //          if (xx != null)
      //          {
      //            item.is_true = true;
      //            item.value = Math.Round((float)xx[0],3);
      //          }
      //        }
      //        else
      //        {
      //          throw new Exception("Счетчик не поддерживается");
      //        }
      //      }
      //      catch (Exception ex)
      //      {
      //      }
      //    }
      //    si.DialogResult = DialogResult.OK;
      //  }));
      //  si.ShowDialog();
      //}
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
  }
}
