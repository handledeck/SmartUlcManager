using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uart.Attributes;
using Uart.Enums;
using Uart.Function;
using Uart;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Net.Sockets;
using UlcWin.Devices;
using System.Data;

namespace UlcWin.Controls.Uart.Function
{
  [TypeConverter(typeof(PropertySorter))]
  public class EnM318Item : DataGridViewConverter
  {
    EnM318Func __functionIndex= EnM318Func.ReadWingValue;
     bool __enable = true;
    [Category("Настройки"), PropertyOrder(0)]
    [Description("Адрес опроса устройства")]
    [DisplayNamed("Функция")]
    [DisplayName("Функция")]
    public EnM318Func FunctionIndex
    {
      get { return __functionIndex; }
      set
      {
        __functionIndex = value;
        SetReadonly(this, !__enable);
        __enable = !__enable;
       
      } 
    }

    [Category("Настройки"), PropertyOrder(1)]
    [Description("Адрес опроса устройства")]
    [DisplayNamed("Номер счетчика")]
    [DisplayName("Номер счетчика")]

    public uint MeterNum { get; set; }

    [Category("Настройки"), PropertyOrder(2)]
    [Description("Допуск")]
    [DisplayNamed("Допуск")]
    [DisplayName("Допуск")]
    [Browsable(true)]
    public Int16 ControlAdmission { get; set; }

    [Category("Настройки"), PropertyOrder(3)]
    [Description("Зона чуствительности")]
    [DisplayNamed("Зона чуствительности")]
    [DisplayName("Зона чуствительности")]
    [Browsable(true)]
    public Int16 ControlDeadband { get; set; }

    [Category("Настройки"), PropertyOrder(4)]
    [Description("Мощность для 50%")]
    [DisplayNamed("Мощность для 50%")]
    [DisplayName("Мощность для 50%")]
    [Browsable(true)]
    public Int16 ControlMinValue { get; set; }

    [Category("Настройки"), PropertyOrder(5)]
    [Description("Мощность для 100%")]
    [DisplayNamed("Мощность для 100%")]
    [DisplayName("Мощность для 100%")]
    [Browsable(true)]
    public Int16 ControlMaxValue { get; set; }

    [Category("Настройки"), PropertyOrder(6)]
    [Description("Верхняя граница")]
    [DisplayNamed("Верхняя граница")]
    [DisplayName("Верхняя граница")]
    [Browsable(false)]
    public Int16 HighValue { get; set; }

    [Category("Настройки"), PropertyOrder(7)]
    [Description("Нижняя граница")]
    [DisplayNamed("Нижняя граница")]
    [DisplayName("Нижняя граница")]
    [Browsable(false)]
    public Int16 LowValue { get; set; }

    [Category("МЭК"), PropertyOrder(6)]
    [Description("Индекс МЭК-104")]
    [DisplayNamed("Индекс МЭК-104")]
    [DisplayName("Индекс МЭК-104")]

    public ushort IecIndex { get; set; } = 50;



    private void SetReadonly(object o, bool value)
    {
      foreach (PropertyInfo property in o.GetType().GetProperties())
        if (property.GetCustomAttribute<BrowsableAttribute>() != null)
        {
          BrowsableAttribute readOnly = (BrowsableAttribute)TypeDescriptor.GetProperties(o.GetType())[property.Name].Attributes[typeof(BrowsableAttribute)];
          bool rd= readOnly.Browsable;
          readOnly.GetType().GetField(nameof(BrowsableAttribute.Browsable), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase).SetValue(readOnly, !rd);
        }
    }

    public static List<EnM318Item> ParseFromArray(byte[] buf, out byte pollPeriod)
    {
      //EnM318Item enMeraItem = new EnM318Item();
      List<EnM318Item> enM318Items = new List<EnM318Item>();
      MemoryStream stream = new MemoryStream(buf);
      BinaryReader binaryReader = new BinaryReader(stream);
      binaryReader.BaseStream.Position = 1;
      pollPeriod = binaryReader.ReadByte();
      byte funCount= binaryReader.ReadByte();
      UInt32 meterNum= binaryReader.ReadUInt32();
      
      //enMeraItem.FunctionIndex = func;
      for (int i = 0; i < funCount; i++) {
        EnM318Item enM = new EnM318Item();
        enM.MeterNum = meterNum;
        EnM318Func func = (EnM318Func)binaryReader.ReadByte();
        enM.FunctionIndex = func;
        switch (func)
        {
          case EnM318Func.ReadPhaseVoltage:
            enM.LowValue = binaryReader.ReadInt16();
            enM.HighValue = binaryReader.ReadInt16();
            enM.IecIndex= binaryReader.ReadUInt16();
            break;
          case EnM318Func.ReadWingValue:
            enM.ControlAdmission = binaryReader.ReadInt16();
            enM.ControlDeadband = binaryReader.ReadInt16();
            enM.ControlMinValue = binaryReader.ReadInt16();
            enM.ControlMaxValue = binaryReader.ReadInt16();
            enM.IecIndex = binaryReader.ReadUInt16();
            break;
          default:
            break;
        }
        enM318Items.Add(enM); 
      }
    
      return enM318Items;
    }

    public void CellFormatting(DataGridViewCellFormattingEventArgs e)
    {
      throw new NotImplementedException();
    }

    public void GetDataGridView(DataGridViewRow xr)
    {
      FunctionIndex = (EnM318Func)xr.Cells["FunctionIndex"].Value;
      MeterNum = (UInt32)xr.Cells["MeterNum"].Value;
      ControlAdmission = (Int16)xr.Cells["ControlAdmission"].Value;
      ControlDeadband = (Int16)xr.Cells["ControlDeadband"].Value;
      ControlMinValue = (Int16)xr.Cells["ControlMinValue"].Value;
      ControlMaxValue = (Int16)xr.Cells["ControlMaxValue"].Value;
      HighValue = (Int16)xr.Cells["HighValue"].Value;
      LowValue = (Int16)xr.Cells["LowValue"].Value;
      IecIndex = (ushort)xr.Cells["IecIndex"].Value;
    }

    public void SetDataGridView(DataGridViewRow xr)
    {
      xr.Cells["FunctionIndex"].Value = FunctionIndex;
      xr.Cells["MeterNum"].Value = MeterNum;
      xr.Cells["ControlAdmission"].Value = ControlAdmission;
      xr.Cells["ControlDeadband"].Value = ControlDeadband;
      xr.Cells["ControlMinValue"].Value = ControlMinValue;
      xr.Cells["ControlMaxValue"].Value = ControlMaxValue;
      xr.Cells["HighValue"].Value = HighValue;
      xr.Cells["LowValue"].Value = LowValue;
      xr.Cells["IecIndex"].Value = IecIndex;
    }

    

    public static Exception WriteUartSettings(TcpClient client, string password, byte pollPeriod, EnumTypeController enumTypeController, DataTable dw = null)
    {
      Exception e = null;
      try
      {
        byte[] pkg = null;
        if (dw.Rows.Count > 0)
        {
          MemoryStream stream = new MemoryStream();
          BinaryWriter binaryWriter = new BinaryWriter(stream);
          binaryWriter.Write((byte)3);
          binaryWriter.Write((byte)pollPeriod);
          binaryWriter.Write((byte)dw.Rows.Count);
          binaryWriter.Write((uint)dw.Rows[0].ItemArray[1]);
          for (int i = 0; i < dw.Rows.Count; i++)
          {
            EnM318Func enM318Func = (EnM318Func)dw.Rows[i].ItemArray[0];
            binaryWriter.Write((byte)enM318Func);
            //binaryWriter.Write((uint)dw.Rows[i].ItemArray[1]);
            switch (enM318Func)
            {
              case EnM318Func.ReadPhaseVoltage:
                binaryWriter.Write((Int16)dw.Rows[i].ItemArray[6]);
                binaryWriter.Write((Int16)dw.Rows[i].ItemArray[7]);
                break;
              case EnM318Func.ReadWingValue:
                binaryWriter.Write((Int16)dw.Rows[i].ItemArray[2]);
                binaryWriter.Write((Int16)dw.Rows[i].ItemArray[3]);
                binaryWriter.Write((Int16)dw.Rows[i].ItemArray[4]);
                binaryWriter.Write((Int16)dw.Rows[i].ItemArray[5]);
                break;
              default:
                break;
            }

            binaryWriter.Write((ushort)dw.Rows[i].ItemArray[8]);
          } 
            binaryWriter.Write((byte)13);
            binaryWriter.Flush();
            pkg = stream.ToArray();
          
        }
        else
        {
          pkg = System.Text.ASCIIEncoding.ASCII.GetBytes("AAAAAA==");
        }
        NetworkStream nstream = client.GetStream();
        DevicePackage.WriteDevicePackage(nstream, password, pkg, enumTypeController);
      }
      catch (Exception exp)
      {
        e = exp;
      }
      return e;
    }
  }
}

