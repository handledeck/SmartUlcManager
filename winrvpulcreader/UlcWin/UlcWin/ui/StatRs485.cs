using InterUlc.Db;
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
  public partial class StatRs485 : Form
  {
    DbReader __dbReader;
    List<ListViewItem> __listViewItems;
    public StatRs485(DbReader dbReader,List<ListViewItem> listViewItems)
    {
      this.__dbReader = dbReader;
      this.__listViewItems = listViewItems;
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      List<OrmDbInfo> lstInfo=new List<OrmDbInfo>();
      foreach (var item in __listViewItems)
      {
        UlcWin.ItemIp itemIp = (UlcWin.ItemIp)item.Tag;
        lstInfo.Add(new OrmDbInfo()
        {
          id = itemIp.Id,
          arm_id = 0,
          ip_address = itemIp.Ip,
          meters = itemIp.Meters,
          phone_num = itemIp.Phone,
          unit_type_id = itemIp.UType,
          rs_stat = this.checkBox1.Checked ? 1 : 0
        });
      }
      if (lstInfo != null)
      {
        var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(this.__dbReader.__connection, PostgreSqlDialect.Provider);
        using (var db = dbFactory.Open())
        {
          
          int xxxx=db.Save<OrmDbInfo>(lstInfo.ToArray());
        }
      }
    }
  }
}
