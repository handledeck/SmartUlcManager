using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Uart.Attributes;
using Uart.Enums;
using UlcWin.Controls.Uart.Interfaces;
using UlcWin.Devices;
using Ztp.Protocol;

namespace Uart.Function

{


  [TypeConverter(typeof(PropertySorter))]
  public class ModbusItem : DataGridViewConverter
  {

    public ModbusItem()
    {
    }



    [RefreshProperties(RefreshProperties.All)]
    [Category("Настройки"), PropertyOrder(0)]
    [Description("Адрес опроса устройства. Макс.255")]
    [DisplayNamed("Адрес устройства")]
    [DisplayName("Адрес устройства")]

    public byte DevAddr { get; set; }

    [Category("Настройки"), PropertyOrder(1)]
    [Description("This is the description that shows up")]
    [DisplayNamed("Команда")]
    [DisplayName("Команда")]
    public EnumModbusFunction CmdNum { get; set; } = EnumModbusFunction.DigitalInput;
    [Category("Настройки"), PropertyOrder(2)]
    [Description("Стартовый адрес опроса")]
    [DisplayNamed("Адрес поля")]
    [DisplayName("Адрес поля")]

    public ushort TagAddr { get; set; } = 1;
    [Category("Настройки"), PropertyOrder(3)]
    [Description("Адрес в контроллере")]
    [DisplayNamed("ID МЭК-104")]
    [DisplayName("ID МЭК-104")]
    [RefreshProperties(RefreshProperties.All)]
    public ushort IecIndex { get; set; } = 50;
    [Category("Настройки"), PropertyOrder(4)]
    [Description("Зона не чуствительности в процентах")]
    [DisplayNamed("Зона н.ч %")]
    [DisplayName("Зона н.ч %")]
    [RefreshProperties(RefreshProperties.All)]
    public byte DbzVal { get; set; } = 50;

    [Category("Настройки"), PropertyOrder(5)]
    [Description("Коментарий (макс. 20 символов)")]
    [DisplayNamed("Описание тега")]
    [DisplayName("Описание тега")]
    [RefreshProperties(RefreshProperties.All)]
    public string Comment { get; set; } = "";

    public void CellFormatting(DataGridViewCellFormattingEventArgs e)
    {
      
    }

    public void GetDataGridView(DataGridViewRow xr)
    {
      DevAddr = (byte)xr.Cells["DevAddr"].Value;
      CmdNum = (EnumModbusFunction)xr.Cells["CmdNum"].Value;
      TagAddr = (ushort)xr.Cells["TagAddr"].Value;
      IecIndex = (ushort)xr.Cells["IecIndex"].Value;
      DbzVal = (byte)xr.Cells["DbzVal"].Value;
      Comment = (string)xr.Cells["Comment"].Value;
    }

    public void SetDataGridView(DataGridViewRow xr)
    {
      xr.Cells["DevAddr"].Value = DevAddr;
      xr.Cells["CmdNum"].Value = CmdNum;
      xr.Cells["TagAddr"].Value = TagAddr;
      xr.Cells["IecIndex"].Value = IecIndex;
      xr.Cells["DbzVal"].Value = DbzVal;
      xr.Cells["Comment"].Value = Comment;
    }

    public static List<ModbusItem> ParseFromArray(byte[] buf, out byte pollPeriod)
    {
      List<ModbusItem> modbus = null;
      int s = 1;
      //buf[s++];
      pollPeriod = buf[s++];
      //idPollPeriod.Value = (pollPeriod == 0) ? 1 : pollPeriod;
      Int16 count = BitConverter.ToInt16(buf, s);
      s += 2;
      //this.__tagCount = 0;
      int pointToIecIndexStart = 4 + count * 4;
      int pointToDbzIndexStart = pointToIecIndexStart + count * 2;
      modbus = new List<ModbusItem>();
      for (int i = 0; i < count; i++)
      {

        UInt16 val = BitConverter.ToUInt16(buf, s + 2);
        UInt16 iecIndex = (pointToIecIndexStart + (i * 2) < buf.Length) ?
          BitConverter.ToUInt16(buf, pointToIecIndexStart + i * 2) : (UInt16)0;
        byte dbzVal = ((pointToDbzIndexStart + i) < buf.Length) ?
          buf[pointToDbzIndexStart + i] : (byte)0;
        ModbusItem modbusItem = new ModbusItem()
        {
          DevAddr = buf[s],
          CmdNum = (EnumModbusFunction)buf[s + 1],
          TagAddr = val,
          IecIndex = iecIndex,
          DbzVal = dbzVal
        };
        modbus.Add(modbusItem);
        //this.__modbusItemList.addTag(buf[s], buf[s + 1], val, (ushort)iecIndex, dbzVal);
        s += 4;
        //this.__tagCount++;
      }

      if (count > 0)
        s += count * 3 + 1;
      else
        s = -1;

      return modbus;
    }

    public static Exception WriteUartSettings(TcpClient client, string password, byte pollPeriod, EnumTypeController enumTypeController, DataTable dw=null)
    {
      
      try
      {
        NetworkStream stream = client.GetStream();
        byte[] rngRead = new byte[512];
        byte[] data = ModbusItem.GetArrayFromDataGrid(password, pollPeriod, enumTypeController, dw);
        stream.Write(data, 0, data.Length);
        int len=stream.Read(rngRead, 0, rngRead.Length);
        string sOk = System.Text.ASCIIEncoding.ASCII.GetString(rngRead, 0, len);
        if (!sOk.Contains("PWD:OK"))
          throw new Exception(sOk);
        string msg = GetLebelGzip(dw);
        string pMsg = DevicePackage.ModbusSetLBL(1, password, msg);// ZtpProtocol.ModbusSetLBL(password, msg);
        byte[] rngData = Encoding.UTF8.GetBytes(pMsg);
        stream.Write(rngData, 0, rngData.Length);
        len = stream.Read(rngRead, 0, rngRead.Length);
        sOk = System.Text.ASCIIEncoding.ASCII.GetString(rngRead, 0, len);
        if (!sOk.Contains("PWD:OK"))
          throw new Exception(sOk);
        
      }
      catch (Exception exp)
      {
        return exp;
      }
      return null;
    }


    static string GetLebelGzip(DataTable dw)
    {
      string res = "";
     
        if (dw.Rows.Count== 0)
        {
          res = "AAAAAA==";
        }
        else
        {
          StringBuilder sb = new StringBuilder();
          for (int i = 0; i < dw.Rows.Count; i++)
          {

            sb.Append((string)dw.Rows[i][5]);
            sb.Append(";");
          }
          sb.Remove(sb.Length - 1, 1);
          res = Compress(sb.ToString());
        }
      
      return res;
    }

    static byte[] Compress(byte[] input)
    {
      using (var result = new MemoryStream())
      {
        var lengthBytes = BitConverter.GetBytes(input.Length);
        result.Write(lengthBytes, 0, 4);

        using (var compressionStream = new GZipStream(result,
            CompressionMode.Compress))
        {
          compressionStream.Write(input, 0, input.Length);
          compressionStream.Flush();

        }
        return result.ToArray();
      }
    }

    static string Compress(string input)
    {
      byte[] encoded = Encoding.UTF8.GetBytes(input);
      byte[] compressed = Compress(encoded);
      return Convert.ToBase64String(compressed);
    }

    static byte[] GetArrayFromDataGrid(string password, byte pollPeriod, EnumTypeController enumTypeController, DataTable dw)
    {
      MemoryStream stream = new MemoryStream();
      BinaryWriter bstream = new BinaryWriter(stream);
      bstream.Write((byte)1);
      bstream.Write((byte)pollPeriod);
      bstream.Write((ushort)dw.Rows.Count);
      
      for (int i = 0; i < dw.Rows.Count; i++)
      {
        bstream.Write((byte)dw.Rows[i].ItemArray[0]);
        bstream.Write((byte)dw.Rows[i].ItemArray[1]);
        bstream.Write((ushort)dw.Rows[i].ItemArray[2]);
      }
      //Добавление в конец массива индексов мэк104 для тегов
      for (int i = 0; i < dw.Rows.Count; i++)
      {
        bstream.Write((ushort)dw.Rows[i].ItemArray[3]);
      }
      for (int i = 0; i < dw.Rows.Count; i++)
        bstream.Write((byte)dw.Rows[i].ItemArray[4]);
      bstream.Write((byte)13);
      bstream.Flush();
      byte[] pkg = stream.ToArray();
      byte[] pack;
      if (enumTypeController == EnumTypeController.RVP || enumTypeController == EnumTypeController.ULC2)
        pack = ZtpProtocol.ModbusSetConfig(password, pkg, (ushort)pkg.Length);
      else {
        pack=DevicePackage.ModbusWriteConfigByPort(password,1,pkg, (ushort)pkg.Length);
        
      }
      return pack;
    }
  }
}

