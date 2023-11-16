using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace InterUlc.Drivers
{
  public enum EnumComands : byte
  {
    relay_status = 0x10,
    monthCat = 0x24,
    dayCat = 0x25,
    relay_set = 0x3a,

  };



  public enum EnumErrorCode : byte
  {
    OK = 0,
    WriteWithWrongPwd = 1,
    WrongParam = 2,
    ErrorDefParamChange = 3,
    WrongLenght = 4,
    InterfaceBlock = 5,
    EmptyData = 6,
    ReadWithWrongPwd = 7,
    CantRunCmd = 8,
    CantRunCmdRightNow = 9,
    ActionAlreadyComplete = 10,
    WrongCRC = 11,
    PowerLost = 254
  }

  public class Aist3W32Utils
  {
    byte crc8(byte[] data, int len)
    {
      byte crc = 0;
      int i, j = 0;
      while (len-- > 0)
      {
        crc ^= data[j++];

        for (i = 0; i < 8; ++i)
        {
          crc = (byte)(((crc & 0x80) > 0) ? (crc << 1) ^ 0xA9 : crc << 1);
        }
      }
      return crc;
    }

    byte[] byteStaffing(byte[] data, byte len)
    {
      int i = 0, j = 0;
      byte[] tmp = new byte[256];

      while (len-- > 0)
      {
        if (data[i] == 0x55 || data[i] == 0x73)
        {
          tmp[j] = 0x73;
          j++;
          tmp[j] = (byte)((data[i] == 0x55) ? 0x11 : 0x22);
        }
        else
          tmp[j] = data[i];

        j++;
        i++;
      }
      Array.Resize<byte>(ref tmp, j);

      return tmp;
    }

    byte[] byteStaffingReverse(byte[] data, byte len)
    {
      int i = 0, j = 0;
      byte[] tmp = new byte[256];

      while (len-- > 0)
      {
        if (data[i] == 0x73)
        {
          tmp[j] = (byte)((data[i + 1] == 0x11) ? 0x55 : 0x73);
          i++;
          len--;
        }
        else
          tmp[j] = data[i];
        j++;
        i++;
      }
      Array.Resize<byte>(ref tmp, j);
      return tmp;
    }

    byte[] requestPrepare(EnumComands cmd, UInt16 address, byte[] data, byte len)
    {
      int i = 0;
      byte[] tmp = new byte[256];
      byte headSize = (byte)(11 + len); //11 - длина заголовка
      byte[] req = new byte[100];
      req[i++] = (byte)((len & 0x1F) | 0x20);
      req[i++] = 0;
      byte[] addr = BitConverter.GetBytes(address);
      Array.Copy(addr, 0, req, 2, 2);
      i += 2;
      //src_addr
      req[i++] = 0xff;
      req[i++] = 0xff;
      req[i++] = (byte)cmd;
      //password
      req[i++] = 0x00;
      req[i++] = 0x00;
      req[i++] = 0x00;
      req[i++] = 0x00;
      Array.Copy(data, 0, req, 11, len);
      i += len;
      req[i++] = crc8(req, headSize);
      byte[] t = byteStaffing(req, (byte)(headSize + 1));
      tmp[0] = 0x73;
      tmp[1] = 0x55;
      Array.Copy(t, 0, tmp, 2, t.Length);
      tmp[t.Length + 2] = 0x55;
      Array.Resize<byte>(ref tmp, t.Length + 3);

      return tmp;
    }

    public byte[] requestDayCut(UInt16 addr, DateTime dt)
    {
      byte[] data = new byte[4];

      data[0] = 0x00; //type 0 - активная +
      data[1] = (byte)dt.Day;
      data[2] = (byte)dt.Month;
      data[3] = (byte)(dt.Year % 100);

      return requestPrepare(EnumComands.dayCat, addr, data, (byte)data.Length);
    }

    public byte[] requestMonthCut(UInt16 addr, DateTime dt)
    {
      byte[] data = new byte[3];

      data[0] = 0x00; //type 0 - активная +
      data[1] = (byte)dt.Month;
      data[2] = (byte)(dt.Year % 100);

      return requestPrepare(EnumComands.monthCat, addr, data, (byte)data.Length);
    }

    public struct ResponceResult
    {
      public EnumErrorCode err;
      public EnumComands cmd;
      public byte[] answer;
    }

    public ResponceResult ParceResponse(byte[] data, int len)
    {
      byte[] mass = new byte[len - 3];
      //отбрасывание обрамления пакета
      Array.Copy(data, 2, mass, 0, len - 3);
      ResponceResult res = new ResponceResult();
      byte[] tmp = byteStaffingReverse(mass, (byte)mass.Length);

      byte crc = crc8(tmp, tmp.Length - 1);
      if (crc != tmp[tmp.Length - 1])
      {
        res.err = EnumErrorCode.WrongCRC;
        return res;
      }


      res.cmd = (EnumComands)tmp[6];
      res.err = (EnumErrorCode)tmp[10];
      res.answer = tmp.Skip<byte>(11).ToArray<byte>();
      Array.Resize<byte>(ref res.answer, res.answer.Length - 1);
      return res;
    }

    public double GetPowerCut(byte[] data, int len)
    {
      ResponceResult tmp = ParceResponse(data, len);
      if (tmp.err != EnumErrorCode.OK)
      {
        if (tmp.err == EnumErrorCode.EmptyData)
          return 0.0; //ПУстое значение
        throw new Exception("Ошибка обработки");
      }

      byte[] answer = tmp.answer;

      double res = 0.0;

      int _pow = answer[4] & 0x03;
      if (_pow == 0)
        _pow = 4;

      //4 тарифа
      int[] power = new int[4];
      int sum = 0;
      for (int i = 0; i < 4; ++i)
      {
        power[i] = BitConverter.ToInt32(answer, 13 + i * 4);
        sum += power[i];
      }

      res = sum / Math.Pow(10, _pow); //кВт*ч
      return res;
    }

   

  }

  public class Aist2W3
  {

    static bool GetDataFromDevice(Aist3W32Utils aist, TcpClient client, byte[] request, out double value)
    {

      value = 0;
      try
      {
        //Aist3W32Utils aist = new Aist3W32Utils();
        //byte[] req = aist.requestDayCut(9062, DateTime.Now);
        client.ReceiveTimeout = 10000;
        client.GetStream().Write(request, 0, request.Length);
        NetworkStream stream = client.GetStream();
        byte[] response = new byte[515];
        int size = stream.Read(response, 0, response.Length);
        byte[] resp = new byte[size];
        Array.Copy(response, resp, size);
        value = aist.GetPowerCut(resp, size);
      }
      catch (Exception e)
      {
        return false;
      }
      return true;
    }

    public static MeterAllValues GetSumAllValue(string meter_factory, TcpClient client)
    {
      Aist3W32Utils aist = new Aist3W32Utils();
      MeterAllValues meterAllValues = new MeterAllValues();
      double day = 0;
      double month = 0;
      ushort address = 0;
      if (!ushort.TryParse(meter_factory, out address))
        return meterAllValues;
      byte[] val = aist.requestDayCut(address, DateTime.Now);//GetDayCutRequest(address);
      if (GetDataFromDevice(aist, client, val, out day))
        meterAllValues.EnergySumDay = (float)(day);
      else return null;
      val = aist.requestMonthCut(address, DateTime.Now);
      if (GetDataFromDevice(aist, client, val, out month))
        meterAllValues.EnergySumMonth = (float)(month);
      else return null;
      return meterAllValues;
    }
  }
}
