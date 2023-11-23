using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.Controls.AdditionalUart.DataTable;

namespace RepairObjectListView
{
  public partial class UsrUartModule : UserControl
  {
    public UsrUartModule()
    {
      
      InitializeComponent();
     
      this.dataGridView1.DataSource = this.dataSet1;
      DataTable dataTable = CreateDataTableFromObjects<ModbusItem>("Modbus");
      this.dataSet1.Tables.Add(dataTable);
      dataTable = CreateDataTableFromObjects<AistItem>("Aist");
      this.dataSet1.Tables.Add(dataTable);
      dataTable = CreateDataTableFromObjects<AistItem>("Mes-3");
      this.dataSet1.Tables.Add(dataTable);
      dataTable = CreateDataTableFromObjects<GranItem>("Granelectro");
      this.dataSet1.Tables.Add(dataTable);
      this.dataGridView1.DataMember = this.dataSet1.Tables[0].TableName;
      this.comboBox1.Items.AddRange(new string[] {
        "Modbus RTU",
        "Aist",
        "Mes-3",
        "Granelectro"
      });
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.comboBox1.SelectedIndex = 0;
      this.comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
    }


    private DataTable CreateDataTableFromObjects<T>(/*List<T> items,*/ string name = null)
    {
      var myType = typeof(T);
      if (name == null)
      {
        name = myType.Name;
      }
      DataTable dt = new DataTable(name);
      foreach (PropertyInfo info in myType.GetProperties())
      {
        string named = info.GetCustomAttribute<DisplayName>().Name;
        dt.Columns.Add(new DataColumn(named, info.PropertyType));
      }
      //foreach (var item in items)
      //{
      //  DataRow dr = dt.NewRow();
      //  foreach (PropertyInfo info in myType.GetProperties())
      //  {
      //    dr[info.Name] = info.GetValue(item);
      //  }
      //  dt.Rows.Add(dr);
      //}
      return dt;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.dataGridView1.DataMember = this.dataSet1.Tables[this.comboBox1.SelectedIndex].TableName;
    }
  }
}
