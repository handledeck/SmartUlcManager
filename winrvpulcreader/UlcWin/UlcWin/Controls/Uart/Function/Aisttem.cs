using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Windows.Forms;
using Uart.Attributes;
using Uart.Enums;
using UlcWin.Devices;
using Ztp.Protocol;

namespace Uart.Function
{

  [AttributeUsage(AttributeTargets.Property)]
  public class DisplayNamed : Attribute
  {
    public readonly string StatName;

    public DisplayNamed(string statName)
    {
      StatName = statName;
    }

    public static List<string> GetDescrptions(Type enumerator)
    {
      FieldInfo[] fi = enumerator.GetFields();
      List<string> attributes = new List<string>();
      foreach (var i in fi)
      {
        try
        {
          DescriptionAttribute zz =(DescriptionAttribute)i.GetCustomAttribute(typeof(DescriptionAttribute));
          if (zz != null)
            attributes.Add(zz.Description);
        }
        catch { }
      }
      return attributes;
    }
  }

  [TypeConverter(typeof(PropertySorter))]
  public class AistItem: DataGridViewConverter
  {

    [Category("Настройки"), PropertyOrder(0)]
    [Description("Адрес опроса устройства")]
    [DisplayNamed("Функция")]
    [DisplayName("Функция")]
    public AistFunc FunctionIndex { get; set; } = AistFunc.ReadPhaseVoltage;
    [Category("Настройки"), PropertyOrder(1)]
    [Description("Адрес опроса устройства")]
    [DisplayNamed("Номер счетчика")]
    [DisplayName("Номер счетчика")]
    
    public ushort MeterNum { get; set; }
    [Category("Настройки"), PropertyOrder(2)]
    [Description("Пароль")]
    [DisplayNamed("Пароль")]
    [DisplayName("Пароль")]
    public UInt32 Password { get; set; }

    [Category("Настройки"), PropertyOrder(3)]
    [Description("Индекс реле")]
    [DisplayNamed("Индекс реле")]
    [DisplayName("Индекс реле")]
    public AistChoise Activity { get; set; } = AistChoise.First;
    
    
    [Category("МЭК"), PropertyOrder(4)]
    [Description("Индекс МЭК-104")]
    [DisplayNamed("Индекс МЭК-104")]
    [DisplayName("Индекс МЭК-104")]

    public ushort IecIndex { get; set; } = 50;

    public void CellFormatting(DataGridViewCellFormattingEventArgs e)
    {
      throw new NotImplementedException();
    }

    public void GetDataGridView(DataGridViewRow xr) {

      FunctionIndex = (AistFunc)xr.Cells["FunctionIndex"].Value;
       MeterNum = (ushort)xr.Cells["MeterNum"].Value;
      Password = (UInt32)xr.Cells["Password"].Value;
      IecIndex = (ushort)xr.Cells["IecIndex"].Value;
      Activity = (AistChoise)xr.Cells["Activity"].Value;
    }

    public void SetDataGridView(DataGridViewRow xr)
    {
      xr.Cells["FunctionIndex"].Value = FunctionIndex;
      xr.Cells["MeterNum"].Value= MeterNum;
      xr.Cells["Password"].Value= Password;
      xr.Cells["IecIndex"].Value= IecIndex;
      xr.Cells["Activity"].Value= Activity;
    }

    public static AistItem ParseFromArray(byte[] buf, out byte pollPeriod)
    {
      AistItem aistItem = new AistItem();
      MemoryStream stream = new MemoryStream(buf);
      BinaryReader binaryReader = new BinaryReader(stream);
      binaryReader.BaseStream.Position = 1;
      pollPeriod = binaryReader.ReadByte();
      aistItem.FunctionIndex = (AistFunc)binaryReader.ReadByte();
      aistItem.MeterNum= binaryReader.ReadUInt16();
      aistItem.Password = binaryReader.ReadUInt32();
      aistItem.Activity = (AistChoise)binaryReader.ReadByte();
      aistItem.IecIndex = binaryReader.ReadUInt16();
      return aistItem;
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
          //function
          binaryWriter.Write((byte)4);
          //time request
          binaryWriter.Write((byte)pollPeriod);
          //AistFunc
          binaryWriter.Write((byte)1);// ((byte)dw.Rows[0].ItemArray[0]));
          //meter number
          binaryWriter.Write((ushort)dw.Rows[0].ItemArray[1]);
          //password
          binaryWriter.Write((UInt32)dw.Rows[0].ItemArray[2]);
          //AistChoise
          binaryWriter.Write((byte)dw.Rows[0].ItemArray[3]);
          //iec 104 address
          binaryWriter.Write((ushort)dw.Rows[0].ItemArray[4]);
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
        //byte[] pack = ZtpProtocol.ModbusSetConfig(password, pkg, (ushort)pkg.Length);
        //byte[] rngRead = new byte[128];
        //NetworkStream nstream = client.GetStream();
        //nstream.Write(pack, 0, pack.Length);
        //int len = nstream.Read(rngRead, 0, pack.Length);
        //string sOk = System.Text.ASCIIEncoding.ASCII.GetString(rngRead, 0, len);
        //if (!sOk.Contains("PWD:OK"))
        //  throw new Exception(sOk);
      }
      catch (Exception exp)
      {
        e = exp;
      }
      return e;
    }
  }
}
