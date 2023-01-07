﻿using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using static InterUlc.Logs.EnumLogs;

namespace InterUlc.Logs
{
  public class ParceLog
  {
    public static List<Log> GetLogIP(NetworkStream stream, out Exception exception)
    {
      exception = null;
      const int fullPackSize = 512;
      List<Log> l = null;
      List<byte[]> totalRawLogs = new List<byte[]>();
      byte[] x3 = new byte[515];
      string str = "GETLOGF\r";
      byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(str);
      stream.Write(b, 0, b.Length);
      ushort packSize;
      int size = 0;
      do
      {
        try
        {
          stream.ReadTimeout = 10000;
          size = stream.Read(x3, 0, x3.Length);
        }
        catch (Exception exp)
        {
          exception = exp;
          return l;
        }
        
        packSize = BitConverter.ToUInt16(x3, 1);
        byte[] pack = new byte[packSize];
        Array.Copy(x3, 3, pack, 0, packSize);
        if (packSize <= 4 || x3[0] != 255)
        {
          return l;
        }
        totalRawLogs.Add(pack);
      } while (packSize == fullPackSize);
      try
      {
        foreach (byte[] pack in totalRawLogs)
        {
          int length = 0;
          while (length < pack.Length)
          {
            var log = new Log();
            uint inDateTime = BitConverter.ToUInt32(pack, length);
            DateTime? dtr = rtc_calendar_time_to_register_value(BitConverter.ToUInt32(pack, length));
            if (dtr != null)
              log.event_time = (DateTime)dtr;

            length += 4;
            log.event_level = (LOG_LVL)pack[length++];
            log.event_type = pack[length++];
            log.event_value = BitConverter.ToUInt16(pack, length);
            length += 2;
            log.event_msg = Log.ConvertToString(log);
            if (l == null)
              l = new List<Log>();
            l.Add(log);
            if (l.Count == 241)
            {
              int x = 0;
            }
          }
        
        }
      }
      catch(Exception exp) {
        exception = exp;
        l = null;
      }
      return l;
    }

    public static DateTime? rtc_calendar_time_to_register_value(uint register_value)
    {
      try
      {
        //UInt32 register_value = Convert.ToUInt32(dt);
        int year = (int)((register_value & (0x3Ful << 26)) >> 26) + 2000;
        int mo = (int)((register_value & (0xFul << 22)) >> 22);
        int day = (int)((register_value & (0x1Ful << 17)) >> 17);
        int ho = (int)((register_value & (0x1Ful << 12)) >> 12);
        int mi = (int)((register_value & (0x3Ful << 6)) >> 6);
        int sec = (int)(register_value & 0x3Ful);
        return new DateTime(year, mo, day, ho, mi, sec);
      }
      catch (Exception)
      {
        return null;
      }
      

    }
  }
}
