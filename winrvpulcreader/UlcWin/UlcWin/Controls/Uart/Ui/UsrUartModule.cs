using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Uart.Enums;
using Uart.Function;
using UlcWin.Controls.DisCombo;
using UlcWin.Controls.Uart.Function;
using UlcWin.Controls.UlcMeterComponet;
using UlcWin.ui;
using Ztp.Protocol;

namespace Uart
{
  public enum UartEvents{ 
    Add,
    Edit,
    Delete
  }

  public delegate void DataRowSelectionChange(object obj);
  public delegate bool ReadUartData(out byte[] buffer);
  public delegate void WriteUartData();
  public delegate void HendlerUartData(UartEvents uartEvents,int index,int rowsCount);
  public interface DataGridViewConverter {
    void GetDataGridView(DataGridViewRow xr);
    void SetDataGridView(DataGridViewRow xr);
    void CellFormatting(DataGridViewCellFormattingEventArgs e);
  }
  public partial class UsrUartModule : UserControl
  {
    //Ztp.Ui.ModBusAddItemForm __modBusAddItemForm = null;
    //public event DataRowSelectionChange EventDataRowSelectionChange;
    [Category("Uart")]
    public event ReadUartData EventReadUartData;
    [Category("Uart")]
    public event WriteUartData EventWriteUartData;
    [Category("Uart")]
    public event HendlerUartData EventHandlerUartData;


    byte[] __value = null;
    
    public byte[] Value
    {
      get { return __value; }
      set
      {
        __value=value;
        
      }
    }

    public List<string> ListMBLabel { get; set; } = null;
    public UlcWin.RequestForm ParentsForm { get; set; }

    public UsrUartModule()
    {
      InitializeComponent();
      this.toolTip1.SetToolTip(btnAdd, "Добавить");
      this.toolTip1.SetToolTip(btnEdit, "Редактировать");
      this.toolTip1.SetToolTip(btnDelete, "Удалить");

      this.dataGridView1.DataSource = this.dataSet1;
      DataTable dataTable = CreateDataTableFromObjects<int>("th");
      this.dataSet1.Tables.Add(dataTable);
       dataTable = CreateDataTableFromObjects<ModbusItem>("Modbus");
     
      this.dataSet1.Tables.Add(dataTable);
      dataTable = CreateDataTableFromObjects<AistItem>("Aist");
      this.dataSet1.Tables.Add(dataTable);
      dataTable = CreateDataTableFromObjects<MesItem>("Mes-3");
      this.dataSet1.Tables.Add(dataTable);
      dataTable = CreateDataTableFromObjects<GranItem>("Granelectro");
      this.dataSet1.Tables.Add(dataTable);
      
      this.dataGridView1.DataMember = this.dataSet1.Tables[0].TableName;
      //this.comboBox1.Items.AddRange(new string[] {
      //  "Сквозной канал",
      //  "Modbus RTU",
      //  "Aист(упр.реле)",
      //  "МЭС(упр.реле)",
      //  "Гранэлектро"
      //});
      this.cbFunction.AddItem(new UlcWin.Controls.DisCombo.DisItem("Сквозной канал",false));
      this.cbFunction.AddItem(new UlcWin.Controls.DisCombo.DisItem("Modbus RTU", false));
      this.cbFunction.AddItem(new UlcWin.Controls.DisCombo.DisItem("Aист(упр.реле)", false));
      this.cbFunction.AddItem(new UlcWin.Controls.DisCombo.DisItem("МЭС(упр.реле)", false));
      this.cbFunction.AddItem(new UlcWin.Controls.DisCombo.DisItem("Гранэлектро", false));
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.cbFunction.SelectedIndex = 0;
      this.cbFunction.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
      Application.Idle += Application_Idle;
      for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
      {
        this.dataGridView1.Columns[i].HeaderText = this.dataSet1.Tables[this.cbFunction.SelectedIndex].Columns[i].Caption;
      }

      
      this.dataGridView1.CellFormatting += DataGridView1_CellFormatting;
      
      if (Value != null)
        this.btnBinRead_Click();
     
    }

    public void InitCB()
    {
      string ver = this.ParentsForm.__selItem.UlcConfig.SVERS;
      if (ver == "1.7.9" || ver == "1.7.10")
      {
        ((DisItem)this.cbFunction.Items[2]).Disable = true;
        ((DisItem)this.cbFunction.Items[3]).Disable = true;
      }
    }

    public static string GetEnumDescription(Enum value)
    {
      FieldInfo fi = value.GetType().GetField(value.ToString());
      DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
      if (attributes != null && attributes.Any())
      {
        return attributes.First().Description;
      }
      return value.ToString();
    }

    private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if (this.dataGridView1.DataMember == this.dataSet1.Tables[1].TableName)
      {
        if (e.ColumnIndex == 1)
        {
          EnumModbusFunction enumModbusFunction = (EnumModbusFunction)((byte)e.Value);
          string val = GetEnumDescription(enumModbusFunction);
          e.Value = val;
        }
      }
      else if (this.dataGridView1.DataMember == this.dataSet1.Tables[2].TableName || this.dataGridView1.DataMember == this.dataSet1.Tables[3].TableName)
      {
        if (e.ColumnIndex == 3)
        {
          AistChoise aistChoise = (AistChoise)((byte)e.Value);
          string val = GetEnumDescription(aistChoise);
          e.Value = val;
        }
        else if (e.ColumnIndex == 0)
        {
          AistFunc FunctionIndex = (AistFunc)((byte)e.Value);
          string val = GetEnumDescription(FunctionIndex);
          e.Value = val;
        }
      }
      else if (this.dataGridView1.DataMember == this.dataSet1.Tables[4].TableName)
      {
        if (e.ColumnIndex == 0)
        {
          GranFunc FunctionIndex = (GranFunc)((byte)e.Value);
          string val = GetEnumDescription(FunctionIndex);
          e.Value = val;
        }
      }
    }

    private void modBusAddItemForm_ItemCheced(object tag, out bool isUsedIec,out bool isUsedTag)
    {
      isUsedIec = false;
      isUsedTag = false;
      ModbusItem modbusTag = (ModbusItem)tag;
      if (dataGridView1.Rows.Count > 0)
      {
        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        {
          DataGridViewRow rw = (DataGridViewRow)dataGridView1.Rows[i];
          if (rw.Tag!=null)
            continue;
          if ((ushort)(rw.Cells["IecIndex"].Value) == modbusTag.IecIndex)
          {
            isUsedIec = true;
            return;
          }
        }
      }
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      if (this.dataGridView1.DataMember == this.dataSet1.Tables[0].TableName)
      {
        this.btnDelete.Enabled = false;
        this.btnEdit.Enabled = false;
        this.btnAdd.Enabled = false;
        this.numUpDwn.Enabled = false;
        return;
      }

      if (this.dataGridView1.DataMember == this.dataSet1.Tables[1].TableName)
      {
        if (this.dataSet1.Tables[1].Rows.Count == 0)
        {
          this.btnDelete.Enabled = false;
          this.btnEdit.Enabled = false;
          this.btnAdd.Enabled = true;
        }
        else
        {
          this.btnDelete.Enabled = true;
          this.btnEdit.Enabled = true;
          this.btnAdd.Enabled = true;
          //this.btnBinDownLoad.Enabled = true;
        }
      }
      else //if (this.dataGridView1.DataMember == this.dataSet1.Tables[1].TableName)// &&
           //this.dataGridView1.DataMember == this.dataSet1.Tables[2].TableName &&
           //this.dataGridView1.DataMember == this.dataSet1.Tables[3].TableName) {
      if (this.dataSet1.Tables[this.cbFunction.SelectedIndex].Rows.Count == 0)// &&
                                                                               //this.dataSet1.Tables[2].Rows.Count==0 &&
                                                                               //this.dataSet1.Tables[3].Rows.Count==0)
      {
        this.btnDelete.Enabled = false;
        this.btnEdit.Enabled = false;
        this.btnAdd.Enabled = true;
      }
      else
      {
        this.btnDelete.Enabled = true;
        this.btnEdit.Enabled = true;
        this.btnAdd.Enabled = false;
      }
      if (this.dataGridView1.Rows.Count > 0)
      {
        //this.btnBinDownLoad.Enabled = true;
        this.numUpDwn.Enabled = true;
      }
      else
      {
        //this.btnBinDownLoad.Enabled = false;
        this.numUpDwn.Enabled = false;
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

    private void AddDataTableObject<T>(List<T> items, string table_name) {
      var myType = typeof(T);
      DataTable dt = this.dataSet1.Tables[table_name];
      foreach (var item in items)
      {
        //int index = 0;
        DataRow dr = dt.NewRow();
        foreach (PropertyInfo info in myType.GetProperties())
        {
          try
          {
            if (info.GetCustomAttribute(typeof(DisplayNamed)) != null) {
              dr[info.Name] = info.GetValue(item);
            }
          }
          catch { 
          
          }
        }
        dt.Rows.Add(dr);
      }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cbFunction.SelectedIndex != -1)
      {
        this.dataGridView1.DataMember = this.dataSet1.Tables[this.cbFunction.SelectedIndex].TableName;
        for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
        {
          this.dataGridView1.Columns[i].HeaderText = this.dataSet1.Tables[this.cbFunction.SelectedIndex].Columns[i].Caption;
        }
      }
      else {
        this.cbFunction.SelectedIndex = 0;
      }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (this.cbFunction.SelectedIndex == 1)
      {
        UartEditor uartEditor = new UartEditor();
        ModbusItem modbusItem = new ModbusItem();
        uartEditor.EventUartEditor += modBusAddItemForm_ItemCheced;
        if (uartEditor.DoAddShowDialog("Modbus RTU", modbusItem) == DialogResult.OK)
        {
          List<ModbusItem> lst = new List<ModbusItem>() { modbusItem };
          AddDataTableObject<ModbusItem>(lst, this.dataSet1.Tables[this.cbFunction.SelectedIndex].TableName);
        }
      }
      if (this.cbFunction.SelectedIndex == 2)
      {
        UartEditor uartEditor = new UartEditor();
        AistItem aistItem = new AistItem();
        //uartEditor.EventUartEditor += modBusAddItemForm_ItemCheced;
        if (uartEditor.DoAddShowDialog("Аист", aistItem) == DialogResult.OK)
        {
          List<AistItem> lst = new List<AistItem>() { aistItem };
          AddDataTableObject<AistItem>(lst, this.dataSet1.Tables[this.cbFunction.SelectedIndex].TableName);
        }
      }

      if (this.cbFunction.SelectedIndex == 3)
      {
        UartEditor uartEditor = new UartEditor();
        MesItem mesItem = new MesItem();
        //uartEditor.EventUartEditor += modBusAddItemForm_ItemCheced;
        if (uartEditor.DoAddShowDialog("МЭС-3", mesItem) == DialogResult.OK)
        {
          List<MesItem> lst = new List<MesItem>() { mesItem };
          AddDataTableObject<MesItem>(lst, this.dataSet1.Tables[this.cbFunction.SelectedIndex].TableName);
        }
      }

      else if (this.cbFunction.SelectedIndex == 4)
      {
        UartEditor uartEditor = new UartEditor();
        GranItem granItem = new GranItem();
        if (uartEditor.DoAddShowDialog("Гранэлектро", granItem) == DialogResult.OK)
        {
          List<GranItem> lst = new List<GranItem>() { granItem };
          AddDataTableObject<GranItem>(lst, this.dataSet1.Tables[this.cbFunction.SelectedIndex].TableName);
        }
      }
      if (EventHandlerUartData != null)
        EventHandlerUartData(UartEvents.Add, this.cbFunction.SelectedIndex, this.dataGridView1.Rows.Count);
    }

    private void btnDelete_click(object sender, EventArgs e)
    {
      dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);
      if (EventHandlerUartData != null)
        EventHandlerUartData( UartEvents.Delete,this.cbFunction.SelectedIndex,this.dataGridView1.Rows.Count);
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      DataGridViewRow xr = this.dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index];
      DataRowView x = (DataRowView)xr.DataBoundItem;

      int index = this.dataGridView1.SelectedRows[0].Index;
      object[] iArray = x.Row.ItemArray;
      if (this.cbFunction.SelectedIndex == 1)
      {
        ModbusItem modbusItem = new ModbusItem();
        modbusItem.GetDataGridView(xr);
        xr.Tag = 1;
        UartEditor uartEditor = new UartEditor();
        uartEditor.EventUartEditor += modBusAddItemForm_ItemCheced;

        DialogResult result = uartEditor.DoEditShowDialog("Modbus RTU", modbusItem);
        if (result == DialogResult.OK)
        {
          modbusItem.SetDataGridView(xr);
          xr.Tag = null;
        }
      }
      else if (this.cbFunction.SelectedIndex == 2)
      {
        UartEditor uartEditor = new UartEditor();
        AistItem aistItem = new AistItem();
        aistItem.GetDataGridView(xr);
        DialogResult result = uartEditor.DoEditShowDialog("Аист", aistItem);
        if (result == DialogResult.OK)
        {
          aistItem.SetDataGridView(xr);
        }
      }
      else if (this.cbFunction.SelectedIndex == 3)
      {
        UartEditor uartEditor = new UartEditor();
        MesItem mesItem = new MesItem();
        mesItem.GetDataGridView(xr);
        DialogResult result = uartEditor.DoEditShowDialog("МЭС-3", mesItem);
        if (result == DialogResult.OK)
        {
          mesItem.SetDataGridView(xr);
        }
      }
      else if (this.cbFunction.SelectedIndex == 4)
      {
        UartEditor uartEditor = new UartEditor();
        GranItem granItem = new GranItem();
        granItem.GetDataGridView(xr);
        DialogResult result = uartEditor.DoEditShowDialog("Гранэлектро", granItem);
        if (result == DialogResult.OK)
        {
          granItem.SetDataGridView(xr);
        }
      }
    }
    public void SetComboboxItem(int index)
    {
      this.Invoke(new Action(() =>
      {
        this.cbFunction.SelectedIndex = index;
      }));
    }

    public void SetUartArray(byte[] array,List<string> lstLbl=null)
    {
      if (array != null)
      {
        this.Value = array;
        this.ListMBLabel = lstLbl;
        try
        {
          this.Invoke(new Action(() =>
          {
            for (int i = 0; i < this.dataSet1.Tables.Count; i++)
            {
              this.dataSet1.Tables[i].Rows.Clear();
            }
            this.btnBinRead_Click();
          }));
        }
        catch { }
      }
    }

    public void btnBinRead_Click()
    {
      if (Value != null)
      {
        byte pollPeriod = 0;
        switch (Value[0])
        {
          case 0:
            SetComboboxItem(0);
            //SetEnableControl(this.numUpDwn, false);
            break;
          case 1:
            {
              List<ModbusItem> modbusItems = ModbusItem.ParseFromArray(Value, out pollPeriod);
              for (int i = 0; i < modbusItems.Count; i++)
              {
                modbusItems[i].Coment = ListMBLabel[i];
              }
              this.AddDataTableObject<ModbusItem>(modbusItems, "Modbus");
              this.numUpDwn.Value = pollPeriod;
              SetComboboxItem(1);
              break;
            }
          case 2:
            {
              GranItem granItem= GranItem.ParseFromArray(Value, out pollPeriod);
              List<GranItem> lst = new List<GranItem>();
              lst.Add(granItem);
              this.AddDataTableObject<GranItem>(lst, "Granelectro");
              this.numUpDwn.Value = pollPeriod;
              SetComboboxItem(4);
              break;
            }
          default:
            break;
        }
      }
    }

   

    public Exception WriteExpandUart(TcpClient client, string password,int index) {

      Exception e = null;
      switch (index)
      {
        case 0:
          e = ThrItem.WriteUartSettings(client, password, (byte)this.numUpDwn.Value);
          break;
        case 1:
          e=ModbusItem.WriteUartSettings(client, password, (byte)this.numUpDwn.Value, this.dataSet1.Tables[1]);
          break;
        case 4:
          e=GranItem.WriteUartSettings(client, password, (byte)this.numUpDwn.Value, this.dataSet1.Tables[4]);
          break;
      }
      return e;
    }

   

    private void btnBinDownLoad_Click(object sender, EventArgs e)
    {

      //byte[] vs= ModbusItem.GetArrayFromDataGrid((byte)this.numUpDwn.Value,this.dataSet1.Tables[1]);
    }

    private void cbFunction_SelectedIndexChanged(object sender, EventArgs e)
    {

      //if (EventHandlerUartData != null)
      //  EventHandlerUartData(UartEvents.Add, this.cbFunction.SelectedIndex, 
      //    this.dataSet1.Tables[this.cbFunction.SelectedIndex].Rows.Count);
    }

    private void dataGridView1_DataMemberChanged(object sender, EventArgs e)
    {
      if (EventHandlerUartData != null)
        EventHandlerUartData(UartEvents.Add, this.cbFunction.SelectedIndex,
          this.dataSet1.Tables[this.cbFunction.SelectedIndex].Rows.Count);
    }
  }
}
