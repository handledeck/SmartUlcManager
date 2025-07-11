using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Uart.Function;
using UlcWin.ui;
using Ztp.Protocol;
using Ztp.Ui;
using static Ztp.IO.FineTune;

namespace UlcWin.Controls.Modules
{
 

 
  public partial class EthernetModule : UserControl
  {

    byte[] __value = null;

    public byte[] Value
    {
      get { return __value; }
      set
      {
        __value = value;
        
      }
    }

    public SettingEditForm ParentsForm { get; set; }

    public EthernetModule()
    {
      InitializeComponent();
      this.toolTip1.SetToolTip(btnAdd, "Добавить");
      this.toolTip1.SetToolTip(btnEdit, "Редактировать");
      this.toolTip1.SetToolTip(btnDelete, "Удалить");

      //this.dataGridView1.DataSource = this.dataSet1;
      DataTable dataTable = CreateDataTableFromObjects<EthernetItem>("Ethernet");
      this.dataSet1.Tables.Add(dataTable);
      this.dataGridView1.DataSource = this.dataSet1.Tables[0];
      for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
      {
        this.dataGridView1.Columns[i].HeaderText = this.dataSet1.Tables[0].Columns[i].Caption;
      }

      this.dataGridView1.CellFormatting += DataGridView1_CellFormatting;

      if (Value != null)
        this.ReadConfigForward();
      Application.Idle += Application_Idle; 
    }

    public DataSet DataSet { get { return this.dataSet1; } }


    public void InitCB()
    {
      if (Value != null)
      {
        this.dataSet1.Tables[0].Rows.Clear();
        ReadConfigForward();
      }
    }

    public static string GetEnumDescription(Enum value)
    {
      FieldInfo fi = value.GetType().GetField(value.ToString());
      if (fi != null)
      {
        DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
        if (attributes != null && attributes.Any())
        {
          return attributes.First().Description;
        }
        return value.ToString();
      }
      else return null;
    }

    private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {

    }



    private void Application_Idle(object sender, EventArgs e)
    {
      if (dataGridView1.Rows.Count == 0)
      {
        btnDelete.Enabled = false;
        btnEdit.Enabled = false;
      }
      else if (dataGridView1.Rows.Count > 0)
      {
        if(dataGridView1.Rows.Count>3)
          btnAdd.Enabled = false;
        else
          btnAdd.Enabled = true;
        btnDelete.Enabled = true;
        btnEdit.Enabled = true;
      }
     
    }


    private DataTable CreateDataTableFromObjects<T>(/*List<T> items,*/ string name = null)
    {
      var myType = typeof(T);
      if (name == null)
      {
        name = myType.Name;
      }
      //int index = 0;
      DataTable dt = new DataTable(name);
      foreach (PropertyInfo info in myType.GetProperties())
      {
        DisplayNamed displayNamed = info.GetCustomAttribute<DisplayNamed>();
        if (displayNamed == null)
          continue;
        string named = displayNamed.StatName;
        DataColumn dataColumn = new DataColumn(info.Name, info.PropertyType);
        dataColumn.Caption = named;
        dt.Columns.Add(dataColumn);
      }

      return dt;
    }

    private void AddDataTableObject<T>(List<T> items, string table_name)
    {
      if (items.Count > 0)
      {
        var myType = items[0].GetType();// typeof(T);
        DataTable dt = this.dataSet1.Tables[table_name];
        foreach (var item in items)
        {

          DataRow dr = dt.NewRow();
          foreach (PropertyInfo info in myType.GetProperties())
          {
            try
            {
              //if (typeof(T) == typeof(EnM318))
              //{
              //  if (info.GetCustomAttribute(typeof(BrowsableAttribute)) != null)
              //  {
              //    BrowsableAttribute readOnly = (BrowsableAttribute)TypeDescriptor.GetProperties(items[0].GetType())[info.Name].Attributes[typeof(BrowsableAttribute)];
              //    bool zz = (bool)readOnly.GetType().GetField(nameof(BrowsableAttribute.Browsable), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase).GetValue(readOnly);//.SetValue(readOnly, !rd);
              //    dataGridView1.Columns[info.Name].Visible = zz;

              //  }
              //}
              if (info.GetCustomAttribute(typeof(DisplayNamed)) != null)
              {
                dr[info.Name] = info.GetValue(item);
              }
            }
            catch
            {

            }
          }
          dt.Rows.Add(dr);
          //this.dataGridView1.Refresh();
        }
      }
    }



    private void btnAdd_Click(object sender, EventArgs e)
    {
      using (AddEthRuleForm frm = new AddEthRuleForm())
      {
        if (frm.ShowDialog() == DialogResult.OK)
        {
          EthernetItem ethernetItem = new EthernetItem()
          {
            IPAddress = frm.ip,
            InPort = frm.srcPort,
            OutPort = frm.destPort,
            Protocol = (EthernetProtocol)((byte)frm.ProtoIndex)
          };
          List<EthernetItem> list = new List<EthernetItem>();
          list.Add(ethernetItem);
          AddDataTableObject<EthernetItem>(list, "Ethernet");
        }
      }
    }

    //private byte[] rulesCollect()
    //{
    //  //int count = dataGridView1.ColumnCount;
    //  //byte[] tmp = new byte[count * 9 + 8];
    //  //byte[] lanIp = IPAddress.Parse(tbLanIP.Text).GetAddressBytes();
    //  //Array.Copy(lanIp, 0, tmp, 0, 4);
    //  //byte[] lanIp1 = IPAddress.Parse(tbGateway.Text).GetAddressBytes();
    //  //Array.Copy(lanIp1, 0, tmp, 4, 4);
    //  //for (int i = 0; i < count; ++i)
    //  //{
    //  //  byte[] ip = IPAddress.Parse(lvRules.Items[i].Text).GetAddressBytes();
    //  //  Array.Copy(ip, 0, tmp, i * 9 + 8, 4);
    //  //  byte[] src = BitConverter.GetBytes(UInt16.Parse(lvRules.Items[i].SubItems[1].Text));
    //  //  Array.Copy(src, 0, tmp, i * 9 + 12, 2);
    //  //  byte[] dest = BitConverter.GetBytes(UInt16.Parse(lvRules.Items[i].SubItems[2].Text));
    //  //  Array.Copy(dest, 0, tmp, i * 9 + 14, 2);
    //  //  byte proto = (byte)(lvRules.Items[i].SubItems[3].Text.Contains("TCP") ? 0 : 1);
    //  //  tmp[i * 9 + 16] = proto;
    //  //}
    //  //return tmp;
    //}

    private void btnEdit_Click(object sender, EventArgs e)
    {
      using (AddEthRuleForm frm = new AddEthRuleForm())
      {
        DataGridViewRow xr = this.dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index];
        
        frm.ip=(string)xr.Cells[0].Value;
        frm.srcPort = (ushort)xr.Cells[2].Value;
        frm.destPort = (ushort)xr.Cells[1].Value;
        frm.ProtoIndex = (int)xr.Cells[3].Value;
        if (frm.ShowDialog() == DialogResult.OK) {
          xr.Cells[0].Value = frm.ip;
          xr.Cells[2].Value = frm.srcPort;
          xr.Cells[1].Value= frm.destPort;
          xr.Cells[3].Value = frm.ProtoIndex;
        }
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);
    }

    public void ReadConfigForward()
    {
      if (this.dataGridView1.Rows.Count > 0)
        this.BeginInvoke(new Action(() => { this.dataGridView1.Rows.Clear(); }));
        
      if (Value != null)
      {
        byte offset = 0;
        int count = 0;
        List<EthernetItem> list = new List<EthernetItem>();
        if (Value.Length % 9 != 0)
        {
          byte[] tmp = new byte[4];
          Array.Copy(Value, 0, tmp, 0, 4);
          Array.Reverse(tmp);
          uint lanIP = BitConverter.ToUInt32(tmp, 0);
          this.ParentsForm.txtIp.Text= IPAddress.Parse(lanIP.ToString()).ToString();
          Array.Copy(Value, 4, tmp, 0, 4);
          Array.Reverse(tmp);
          lanIP = BitConverter.ToUInt32(tmp, 0);
          offset = 12;
          this.ParentsForm.txtGateway.Text = IPAddress.Parse(lanIP.ToString()).ToString();
          Array.Copy(Value, 8, tmp, 0, 4);
          Array.Reverse(tmp);
          lanIP = BitConverter.ToUInt32(tmp, 0);
          this.ParentsForm.txtMask.Text = IPAddress.Parse(lanIP.ToString()).ToString();

          count = (Value.Length - 12) / 9;
        }
        else
        {
          this.ParentsForm.txtIp.Text = "192.168.1.1";
          this.ParentsForm.txtGateway.Text = "192.168.1.1";
          this.ParentsForm.txtMask.Text = "255.255.255.0";
          count = Value.Length / 9;
        }
        for (int i = 0; i < count; ++i)
        {
          byte[] tmp = new byte[4];
          Array.Copy(Value, i * 9 + offset, tmp, 0, 4);
          Array.Reverse(tmp);
          uint ip = BitConverter.ToUInt32(tmp, 0);
          string ips = IPAddress.Parse(ip.ToString()).ToString();
          ushort src = BitConverter.ToUInt16(Value, i * 9 + 4 + offset);
          ushort dest = BitConverter.ToUInt16(Value, i * 9 + 6 + offset);
          int protocol = Value[i * 9 + 8 + offset];
          EthernetItem ethernetItem = new EthernetItem()
          {
            IPAddress = ips,
            InPort = src,
            OutPort = dest,
            Protocol = (EthernetProtocol)protocol
          };
          list.Add(ethernetItem);
          
        }
        AddDataTableObject<EthernetItem>(list, "Ethernet");
      }
    }



    public Exception WriteExpandUart(TcpClient client, string password, int index)
    {

      Exception e = null;

      return e;
    }



    private void dataGridView1_DataMemberChanged(object sender, EventArgs e)
    {
      //if (EventHandlerUartData != null)
      //  EventHandlerUartData(UartEvents.Add, this.cbFunction.SelectedIndex,
      //    this.dataSet1.Tables[this.cbFunction.SelectedIndex].Rows.Count);
    }

  
  }
}
