using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//01 52 31 02 45 4E 44 50 45 28 32 32 2E 31 2E 32 33 29 03 1B --real
//81 D2 B1 82 C5 4E 44 50 C5 28 B2 B2 2E B1 2E B2 33 A9 03 1B --7E1_over
//|  `C `D |  |  `data                                ' |  `BCC
//`SOH     |  `                                         `ETX
//         `STX

namespace UlcWin.Drivers
{

  public enum EnMera301Fun
  {
    EnergyEndDay,
    EnergyEndMonth,
    EnergyBothEnd
  }
  public class EnMera301BY
  {
    static bool is7E1_mode = false;
    static readonly byte SOH = 0x01;
    static readonly byte C = (byte)'R'; //команда записи
    static readonly byte D = (byte)'1'; //чтение данных в коде ASCII
    static readonly byte STX = 0x02; //символ начала кадра в блоке с контрольным символом 
    static readonly byte ETX = 0x03;

    // static uint? GetUintFactory(string serial_number) {
    //   uint addr;
    //   uint? result = null;

    //   if (uint.TryParse(serial_number, out addr))
    //     result = addr;
    //   return result;
    // }

    public static MeterAllValues GetSumAllValue(string meter_factory, TcpClient client)
    {
      Exception exc = null;
      MeterAllValues meterAllValues = new MeterAllValues();
      float day = 0;
      float month = 0;
      float[] res = new float[2];
      if (GetValue(EnMera301Fun.EnergyBothEnd, meter_factory, client, 10000, out res, true))
      {
        meterAllValues.EnergySumDay = res[0];
        meterAllValues.EnergySumMonth = res[1];
        return meterAllValues;
      }
      else
        return null;
    }

    public static bool GetValue(EnMera301Fun enMera318Fun, string factory_number, TcpClient tcpClient, int readTimeout, out float[] value, bool is7E1_mode)
    {
      bool result = false;

      if (enMera318Fun == EnMera301Fun.EnergyBothEnd)
        value = new float[2];
      else
        value = new float[1];

      byte[] sessionStart = { 0x2f, 0x3f, 0x37, 0x37, 0x37, 0x37, 0x37, 0x37, 0x21, 0x0d, 0x0a };
      byte[] verifySession = { 0x06, 0x30, 0x35, 0x31, 0x0d, 0x0a };
      byte[] sessionEnd = { 0x01, 0x42, 0x30, 0x03, 0x1B };
      byte[] responseStart = new byte[256];
      byte[] responseVerify = new byte[256];

      if (is7E1_mode)
      {
        ModifyTo7E1(ref sessionStart);
        ModifyTo7E1(ref verifySession);
        ModifyTo7E1(ref sessionEnd);
      }

      try
      {
        //uint? serial_number = GetUintFactory(factory_number);
        //if (!serial_number.HasValue)
        //  return false;
        byte[][] reqPack = new byte[2][];
        reqPack[0] = new byte[2];
        byte[][] response = new byte[2][] { new byte[256], new byte[256] };
        switch (enMera318Fun)
        {
          case EnMera301Fun.EnergyEndDay:
            reqPack[0] = EnergypackPrepare(DateTime.Now, EnMera301Fun.EnergyEndDay);
            break;
          case EnMera301Fun.EnergyEndMonth:
            reqPack[0] = EnergypackPrepare(DateTime.Now, EnMera301Fun.EnergyEndMonth);
            break;
          case EnMera301Fun.EnergyBothEnd:
            reqPack[0] = EnergypackPrepare(DateTime.Now, EnMera301Fun.EnergyEndDay);
            reqPack[1] = EnergypackPrepare(DateTime.Now, EnMera301Fun.EnergyEndMonth);
            break;
          default:
            break;
        }
        if (is7E1_mode)
        {
          ModifyTo7E1(ref reqPack[0]);
          if (reqPack[1] != null)
            ModifyTo7E1(ref reqPack[1]);
        }

        NetworkStream networkStream = tcpClient.GetStream();
        networkStream.ReadTimeout = readTimeout;


        networkStream.Write(sessionStart, 0, sessionStart.Length);
        int len = networkStream.Read(responseStart, 0, responseStart.Length);

        networkStream.Write(verifySession, 0, verifySession.Length);
        len = networkStream.Read(responseVerify, 0, responseVerify.Length);

        networkStream.Write(reqPack[0], 0, reqPack[0].Length);
        Thread.Sleep(1000);
        len = networkStream.Read(response[0], 0, response[0].Length);
        Array.Resize<byte>(ref response[0], len);

        if (reqPack[1] != null)
        {
          networkStream.Write(reqPack[1], 0, reqPack[1].Length);
          Thread.Sleep(2000);
          len = networkStream.Read(response[1], 0, response[1].Length);
          Array.Resize<byte>(ref response[1], len);
        }

        networkStream.Write(sessionEnd, 0, sessionEnd.Length);

        if (is7E1_mode)
        {
          DeModifyFrom7E1(ref response[0]);
          DeModifyFrom7E1(ref response[1]);
        }

        byte[] emptyData = { 0x02, 0x03, 0x03 };

        for (int i = 0; i < value.Length; ++i)
        {
          if (response[i].SequenceEqual(emptyData))
          {
            value[i] = 0;
          }
          else
          {
            string EnergyLastDay = parseEnergy(response[i]);
            value[i] = (float)GetValue(EnergyLastDay);
          }
          result = true;
        }
        return result;
      }
      catch (Exception exp)
      {
        return false;
      }
    }

    #region 8N1 <-> 7E1 convert
    //8N1 -> 7E1 format convert
    static byte EvenModify(byte val)
    {
      byte res = val;
      int ev = 0;
      for (int i = 0; i < 8; ++i)
      {
        if ((val & 1) == 1)
          ev++;
        val >>= 1;
      }

      if (ev % 2 == 1)
      {
        if ((res & 0x80) != 0)
          res &= 0x7F;
        else
          res |= 0x80;
      }
      return res;
    }

    //7E1 -> 8N1
    static byte RestoreEven(byte val)
    {
      return (byte)(val & 0x7F);
    }

    static void ModifyTo7E1(ref byte[] val)
    {
      for (int i = 0; i < val.Length; ++i)
      {
        val[i] = EvenModify(val[i]);
      }
    }

    static void DeModifyFrom7E1(ref byte[] val)
    {
      for (int i = 0; i < val.Length; ++i)
      {
        val[i] = RestoreEven(val[i]);
      }
    }
    #endregion
    //генерация контрольной суммы
    static byte CalcBCC(byte[] data)
    {
      byte bcc = 0;

      for (int i = 1; i < data.Length - 1; ++i)
      {
        bcc += data[i];
      }
      return bcc;
    }

    static byte[] EnergypackPrepare(DateTime dt, EnMera301Fun ReqType)
    {
      byte[] request = new byte[256];
      byte[] reqv = null;
      string format = null;

      request[0] = SOH;
      request[1] = C;
      request[2] = D;
      request[3] = STX;

      switch (ReqType)
      {
        case EnMera301Fun.EnergyEndDay:
          dt = dt.AddDays(-1);
          format = "d.M.yy";
          reqv = Encoding.ASCII.GetBytes($"ENDPE({dt.ToString(format)})");
          break;
        case EnMera301Fun.EnergyEndMonth:
          dt = dt.AddMonths(-1);
          format = "M.yy";
          reqv = Encoding.ASCII.GetBytes($"ENMPE({dt.ToString(format)})");
          break;
      }

      Array.Copy(reqv, 0, request, 4, reqv.Length);
      Array.Resize<byte>(ref request, reqv.Length + 6);
      request[request.Length - 2] = ETX;
      request[request.Length - 1] = CalcBCC(request);
      return request;
    }

    static string parseEnergy(byte[] data)
    {
      byte[] res = new byte[data.Length - 3];
      Array.Copy(data, 1, res, 0, res.Length);
      string val = Encoding.ASCII.GetString(res);
      val = val.Split(new char[] { '\n' })[0];
      return val;
    }

    static double GetValue(string s)
    {
      double res = 0.0;
      s = s.Split(new char[] { '(', ')' })[1];

      if (double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
        return res;
      else
        return 0.0f;
    }
  }
}
