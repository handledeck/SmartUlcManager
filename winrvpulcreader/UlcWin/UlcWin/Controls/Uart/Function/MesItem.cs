using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Uart.Attributes;
using Uart.Enums;
using UlcWin.Controls.DisCombo;
using UlcWin.Devices;
using Ztp.Protocol;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Uart.Function
{
  [TypeConverter(typeof(PropertySorter))]
  public class MesItem : DataGridViewConverter
  {

    [Category("Настройки"), PropertyOrder(0)]
    [Description("Функция")]
    [DisplayNamed("Функция")]
    [DisplayName("Функция")]
    public Mes3Func FunctionIndex { get; set; }=Mes3Func.ReadPhaseVoltage;
    [Category("Настройки"), PropertyOrder(1)]
    [Description("Номер счетчика")]
    [DisplayNamed("Номер счетчика")]
    [DisplayName("Номер счетчика")]

    public UInt16 MeterNum { get; set; }
    
    [Category("Настройки"), PropertyOrder(2)]
    [Description("Пароль")]
    [DisplayNamed("Пароль")]
    [DisplayName("Пароль")]
    public string Password { get; set; } = "";

    [Category("Настройки"), PropertyOrder(3)]
    [Description("Активность")]
    [DisplayNamed("Активность")]
    [DisplayName("Активность")]

    public Mes3Choise Activity { get; set; } = Mes3Choise.Active;

    [Category("Настройки"), PropertyOrder(4)]
    [Description("Индекс МЭК-104")]
    [DisplayNamed("Индекс МЭК-104")]
    [DisplayName("Индекс МЭК-104")]

    public ushort IecIndex { get; set; } = 50;

    public void CellFormatting(DataGridViewCellFormattingEventArgs e)
    {
      throw new NotImplementedException();
    }

    public static MesItem ParseFromArray(byte[] buf, out byte pollPeriod)
    {
      MesItem mesItem = new MesItem();
      MemoryStream stream = new MemoryStream(buf);
      BinaryReader binaryReader = new BinaryReader(stream);
      binaryReader.BaseStream.Position = 1;
      pollPeriod = binaryReader.ReadByte();
      mesItem.FunctionIndex = (Mes3Func)binaryReader.ReadByte();
      mesItem.MeterNum = binaryReader.ReadUInt16();
      byte[] pwd = new byte[10];
      binaryReader.Read(pwd, 0, pwd.Length);
      mesItem.Password=System.Text.ASCIIEncoding.UTF8.GetString(pwd);
      mesItem.Activity=(Mes3Choise)binaryReader.ReadByte();
      mesItem.IecIndex = binaryReader.ReadUInt16();
      return mesItem;
    }

    public void GetDataGridView(DataGridViewRow xr)
    {

      FunctionIndex = (Mes3Func)xr.Cells["FunctionIndex"].Value;
      MeterNum = (UInt16)xr.Cells["MeterNum"].Value;
      Password = (string)xr.Cells["Password"].Value;
      IecIndex = (ushort)xr.Cells["IecIndex"].Value;
      Activity = (Mes3Choise)xr.Cells["Activity"].Value;

    }

    public void SetDataGridView(DataGridViewRow xr)
    {
      xr.Cells["FunctionIndex"].Value = FunctionIndex;
      xr.Cells["MeterNum"].Value = MeterNum;
      xr.Cells["Password"].Value = Password;
      xr.Cells["IecIndex"].Value = IecIndex;
      xr.Cells["Activity"].Value = Activity;

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
          binaryWriter.Write((byte)5);
          binaryWriter.Write((byte)pollPeriod);
          //function
          binaryWriter.Write((byte)1);
          //serial number
          binaryWriter.Write((ushort)dw.Rows[0].ItemArray[1]);
          //password
          byte[] pwdStr = Encoding.UTF8.GetBytes(dw.Rows[0].ItemArray[2].ToString());
          byte[] pwd_wr = new byte[10];
          Array.Copy(pwdStr,pwd_wr, pwdStr.Length);
          binaryWriter.Write(pwd_wr);
          //active
          binaryWriter.Write((byte)((byte)dw.Rows[0].ItemArray[3]));

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
      }
      catch (Exception exp)
      {
        e = exp;
      }
      return e;
    }
  }

}

