using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin.Drivers
{
  public class Mes3
  {
    public static byte CalcBCC(byte[] data)
    {
      byte bcc = 0;
      int start = (data[0] == (byte)'/') ? 7 : 1;
      for (int i = start; i < data.Length - 1; ++i)
      {
        bcc ^= (byte)(data[i] & 0x7f);
      }
      return bcc;
    }

    public static int WriteHead(ref byte[] data, int addr)
    {
      int curIndex = 0;

      string head = $"/?{addr}!";
      byte[] h = Encoding.ASCII.GetBytes(head);
      Array.Copy(h, 0, data, 0, h.Length);
      curIndex += h.Length;

      return curIndex;
    }

    public static int AddCmd(ref byte[] data, string cmd, int curIndex)
    {
      byte[] command = Encoding.ASCII.GetBytes(cmd);

      Array.Copy(command, 0, data, curIndex, command.Length);
      return curIndex + command.Length;
    }

    public static int AddData(ref byte[] data, string value, int curIndex)
    {
      byte[] val = Encoding.ASCII.GetBytes(value);
      data[curIndex] = 0x02;
      curIndex++;
      Array.Copy(val, 0, data, curIndex, val.Length);
      data[curIndex + val.Length] = 0x03;
      curIndex++;
      return curIndex + val.Length;
    }

    public static byte[] GetDayCutRequest(int addr)
    {
      byte[] val = new byte[100];
      int count = Mes3.WriteHead(ref val, addr);
      count = Mes3.AddCmd(ref val, "R1", count);
      count = Mes3.AddData(ref val, "1-1:1.128.0*0(1)", count);
      Array.Resize<byte>(ref val, count + 1);
      val[count] = Mes3.CalcBCC(val);

      return val;
    }

    public static byte[] GetMonthCutRequest(int addr)
    {
      byte[] val = new byte[100];
      int count = Mes3.WriteHead(ref val, addr);
      count = Mes3.AddCmd(ref val, "R1", count);
      count = Mes3.AddData(ref val, "1-1:1.129.0*0(1)", count);
      Array.Resize<byte>(ref val, count + 1);
      val[count] = Mes3.CalcBCC(val);

      return val;
    }

    //Возвращает в ваттах.!! 
    public static int ParseCuts(byte[] data, int len)
    {
      int res = 0;
      Array.Resize<byte>(ref data, len);
      byte bcc = CalcBCC(data);

      if (bcc != data[len - 1])
        return -1;
      data = data.Skip<byte>(1).ToArray<byte>();
      Array.Resize<byte>(ref data, len - 2);
      string s = Encoding.ASCII.GetString(data);
      s = s.Split(new char[] { '(', ')' })[1];
      if (int.TryParse(s, out res))
        return res;
      else
        return -2;
    }

    static bool GetDataFromDevice(TcpClient client, byte[] request,out int value) {
      value = 0;
      try
      {
        client.ReceiveTimeout = 10000;
        client.GetStream().Write(request, 0, request.Length);
        NetworkStream stream = client.GetStream();
        byte[] response = new byte[515];
        int size = stream.Read(response, 0, response.Length);
        value = ParseCuts(response, size);
      }
      catch (Exception e)
      {
        return false;
      }
      return true;
    }

    public static MeterAllValues GetSumAllValue(string meter_factory, TcpClient client)
    {
      MeterAllValues meterAllValues = new MeterAllValues();
      int day = 0;
      int month = 0;
      int address = 0;
      if (!int.TryParse(meter_factory, out address))
        return meterAllValues;
      byte[] val = GetDayCutRequest(address);
      if (GetDataFromDevice(client, val, out day))
        meterAllValues.EnergySumDay = (float)(day / 1000.0);
      else return null;
      val = GetMonthCutRequest(address);
      if (GetDataFromDevice(client, val, out month))
        meterAllValues.EnergySumMonth = (float)(month / 1000.0);
      else return null;
      return meterAllValues;
    }

  }
}
