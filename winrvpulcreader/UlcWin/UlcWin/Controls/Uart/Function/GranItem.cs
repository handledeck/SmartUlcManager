using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using Uart.Attributes;
using Uart.Enums;
using UlcWin.Devices;
using Ztp.Protocol;

namespace Uart.Function
{
  //[TypeConverter(typeof(Attributes.EnumTypeConverter))]
  //public enum GranFunc : byte
  //{
  //  [FieldDisplayName("Чтение фазных напряжений")]
  //  [Description("Чтение фазных напряжений")]
  //  ReadPhaseVoltage = 1
  //}

  [TypeConverter(typeof(PropertySorter))]
  public class GranItem: DataGridViewConverter
  {
    [Category("Настройки"), PropertyOrder(0)]
    [Description("Функция")]
    [DisplayNamed("Функция")]
    [DisplayName("Функция")]
    public GranFunc FunctionIndex { get; set; } = GranFunc.ReadPhaseVoltage;

    [Category("Настройки"), PropertyOrder(1)]
    [Description("Номер счетчика")]
    [DisplayNamed("Номер счетчика")]
    [DisplayName("Номер счетчика")]
    public byte MeterNum { get; set; } = 0;
    [Category("Настройки"), PropertyOrder(2)]
    [Description("Верхняя граница")]
    [DisplayNamed("Верхняя граница")]
    [DisplayName("Верхняя граница")]
    public ushort ControlMaxValue { get; set; } = 241;
    [Category("Настройки"), PropertyOrder(3)]
    [Description("Нижняя граница")]
    [DisplayNamed("Нижняя граница")]
    [DisplayName("Нижняя граница")]
    public ushort ControlMinValue { get; set; } = 190;
    [Category("Настройки"), PropertyOrder(4)]
    [Description("Адрес МЭК-104")]
    [DisplayNamed("Адрес МЭК-104")]
    [DisplayName("Адрес МЭК-104")]
    public ushort IecIndex { get; set; } = 50;

    public void CellFormatting(DataGridViewCellFormattingEventArgs e)
    {
    }

    public void GetDataGridView(DataGridViewRow xr)
    {
      FunctionIndex = (GranFunc)xr.Cells["FunctionIndex"].Value;
      MeterNum = (byte)xr.Cells["MeterNum"].Value;
      ControlMaxValue = (ushort)xr.Cells["ControlMaxValue"].Value;
      ControlMinValue = (ushort)xr.Cells["ControlMinValue"].Value;
      IecIndex = (ushort)xr.Cells["IecIndex"].Value;
    }

    public void SetDataGridView(DataGridViewRow xr)
    {
      xr.Cells["FunctionIndex"].Value= FunctionIndex;
      xr.Cells["MeterNum"].Value= MeterNum;
      xr.Cells["ControlMaxValue"].Value= ControlMaxValue;
      xr.Cells["ControlMinValue"].Value= ControlMinValue;
      xr.Cells["IecIndex"].Value= IecIndex;
    }

    public static GranItem ParseFromArray(byte[] buf, out byte pollPeriod) {
      GranItem granItem = new GranItem();
      MemoryStream stream = new MemoryStream(buf);
      BinaryReader binaryReader = new BinaryReader(stream);
      binaryReader.BaseStream.Position = 1;
      pollPeriod = binaryReader.ReadByte();
      granItem.FunctionIndex = (GranFunc)binaryReader.ReadInt16();
      granItem.MeterNum = binaryReader.ReadByte();
      granItem.ControlMaxValue = binaryReader.ReadUInt16();
      granItem.ControlMinValue = binaryReader.ReadUInt16();
      granItem.IecIndex = binaryReader.ReadUInt16();
      return granItem;
    }

    

    public static Exception WriteUartSettings(TcpClient client, string password, byte pollPeriod, EnumTypeController enumTypeController, DataTable dw = null) {
      Exception e = null;
      try
      {
        byte[] pkg = null;
        if (dw.Rows.Count > 0)
        {
          MemoryStream stream = new MemoryStream();
          BinaryWriter binaryWriter = new BinaryWriter(stream);
          binaryWriter.Write((byte)2);
          binaryWriter.Write((byte)pollPeriod);
          binaryWriter.Write((ushort)((byte)dw.Rows[0].ItemArray[0]));
          binaryWriter.Write((byte)dw.Rows[0].ItemArray[1]);
          binaryWriter.Write((ushort)dw.Rows[0].ItemArray[2]);
          binaryWriter.Write((ushort)dw.Rows[0].ItemArray[3]);
          binaryWriter.Write((ushort)dw.Rows[0].ItemArray[4]);
          binaryWriter.Write((byte)13);
          binaryWriter.Flush();
          pkg = stream.ToArray();
        }
        else {
          pkg = System.Text.ASCIIEncoding.ASCII.GetBytes("AAAAAA==");
        }
        NetworkStream nstream = client.GetStream();
        DevicePackage.WriteDevicePackage(nstream,password, pkg, enumTypeController);

        //byte[] pack = null;
        //if(enumTypeController== EnumTypeController.ULC2)
        //  pack= ZtpProtocol.ModbusSetConfig(password, pkg, (ushort)pkg.Length);
        //else if(enumTypeController == EnumTypeController.ULC2Lite)
        //  pack=DevicePackage.ModbusWriteConfigByPort(password,1, pkg, (ushort)pkg.Length);
        //byte[] rngRead = new byte[128];
        
        //nstream.Write(pack, 0, pack.Length);
        //int len = nstream.Read(rngRead, 0, pack.Length);
        //string sOk = System.Text.ASCIIEncoding.ASCII.GetString(rngRead, 0, len);
        //if (sOk.Contains("PWD:ERROR"))
        //  throw new Exception("Неверный пароль");
      }
      catch (Exception exp)
      {
        e= exp;
      }
      return e;
    }
  }
}

