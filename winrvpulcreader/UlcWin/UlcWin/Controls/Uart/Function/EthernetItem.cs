using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uart.Attributes;
using UlcWin.Devices;
using Ztp.Ui;

namespace Uart.Function
{



  [TypeConverter(typeof(PropertySorter))]
  internal class EthernetItem : DataGridViewConverter
  {
    private object tbLanIP;

    [Category("Настройки"), PropertyOrder(1)]
    [Description("Ip адрес")]
    [DisplayNamed("Ip адрес")]
    [DisplayName("Ip адрес")]

    public string IPAddress { get; set; }
    [Category("Настройки"), PropertyOrder(2)]
    [Description("Порт подключения")]
    [DisplayNamed("Порт подключения")]
    [DisplayName("Порт подключения")]
    public ushort InPort { get; set; }

    [Category("Настройки"), PropertyOrder(0)]
    [Description("Порт назначения")]
    [DisplayNamed("Порт назначения")]
    [DisplayName("Порт назначения")]
    public ushort OutPort { get; set; }

    [Category("Настройки"), PropertyOrder(0)]
    [Description("Протокол")]
    [DisplayNamed("Протокол")]
    [DisplayName("Протокол")]
    public EthernetProtocol Protocol { get; set; } = EthernetProtocol.TCP;

    public void CellFormatting(DataGridViewCellFormattingEventArgs e)
    {
      throw new NotImplementedException();
    }

    public void GetDataGridView(DataGridViewRow xr)
    {

      IPAddress = (string)xr.Cells["IPAddress"].Value;
      InPort = (ushort)xr.Cells["InPort"].Value;
      OutPort = (ushort)xr.Cells["OutPort"].Value;
      Protocol = (EthernetProtocol)xr.Cells["Protocol"].Value;

    }

    public void SetDataGridView(DataGridViewRow xr)
    {
      xr.Cells["IPAddress"].Value = IPAddress;
      xr.Cells["InPort"].Value = InPort;
      xr.Cells["OutPort"].Value = OutPort;
      xr.Cells["Protocol"].Value = Protocol;
    }

    public static EthernetItem ParseFromArray(byte[] buf, out byte pollPeriod)
    {
      EthernetItem ethernetItem = new EthernetItem();
      MemoryStream stream = new MemoryStream(buf);
      BinaryReader binaryReader = new BinaryReader(stream);
      binaryReader.BaseStream.Position = 1;
      pollPeriod = binaryReader.ReadByte();
      ethernetItem.IPAddress = (string)binaryReader.ReadString();
      ethernetItem.InPort = binaryReader.ReadUInt16();
      ethernetItem.OutPort = binaryReader.ReadUInt16();
      ethernetItem.Protocol = (EthernetProtocol)binaryReader.ReadByte();
      return ethernetItem;
    }

    public static Exception WriteEternetSettings(TcpClient client, string password, string ip_address, string ip_gateway, DataTable dw = null)
    {
      Exception exception = null;
      int count = dw.Rows.Count;
      try
      {
        byte[] tmp = new byte[count * 9 + 8];
        byte[] lanIp = System.Net.IPAddress.Parse(ip_address).GetAddressBytes();
        Array.Copy(lanIp, 0, tmp, 0, 4);
        byte[] lanIp1 = System.Net.IPAddress.Parse(ip_gateway).GetAddressBytes();
        Array.Copy(lanIp1, 0, tmp, 4, 4);
        for (int i = 0; i < count; ++i)
        {
          byte[] ip = System.Net.IPAddress.Parse((string)dw.Rows[i].ItemArray[0]).GetAddressBytes();
          Array.Copy(ip, 0, tmp, i * 9 + 8, 4);
          byte[] src = BitConverter.GetBytes((ushort)dw.Rows[i].ItemArray[1]);
          Array.Copy(src, 0, tmp, i * 9 + 12, 2);
          byte[] dest = BitConverter.GetBytes((ushort)dw.Rows[i].ItemArray[2]);
          Array.Copy(dest, 0, tmp, i * 9 + 14, 2);
          byte proto = (byte)((int)dw.Rows[i].ItemArray[3]);
          tmp[i * 9 + 16] = proto;
        }
        NetworkStream nstream = client.GetStream();
        DevicePackage.EthernetSetRules(nstream, password, tmp);
      }
      catch (Exception exc)
      {

        exception = exc;
      }
      return exception;
    }

    public static Exception WriteUartSettings(TcpClient client, string password, byte pollPeriod, DataTable dw = null)
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
        //DevicePackage.WriteDevicePackage(nstream, password, pkg, enumTypeController);
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
