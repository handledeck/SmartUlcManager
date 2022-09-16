using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ztp
{
  public static class Bit
  {
    public static bool[] ToBitArray(ushort value)
    {
      bool[] retVal = new bool[16];
      for (int i = 0; i < 16; i++)
      {
        if ((value & 1 << i) != 0)
        {
          retVal[i] = true;
        }
      }
      return retVal;
    }

    public static bool[] ToBitArray(byte value)
    {
      bool[] retVal = new bool[8];
      for (int i = 0; i < 8; i++)
      {
        if ((value & 1 << i) != 0)
        {
          retVal[i] = true;
        }
      }
      return retVal;
    }

    public static ushort ToUshort(bool[] buff)
    {
      if (buff == null || buff.Length != 16)
        throw new ArgumentException();
      ushort retVal = 0;
      for (int i = 16 - 1; i >= 0; i--)
      {
        ushort b = buff[i] ? (ushort)1 : (ushort)0;
        retVal |= (ushort)(b << i);
      }
      return retVal;
    }

    public static byte ToByte(bool[] buff)
    {
      if (buff == null || buff.Length != 8)
        throw new ArgumentException();
      byte retVal = 0;
      for (int i = 8 - 1; i >= 0; i--)
      {
        byte b = buff[i] ? (byte) 1 : (byte) 0;
        retVal |= (byte) (b << i);
      }
      return retVal;
    }

    public static bool[] ForUshort(bool b0 = false, bool b1 = false, bool b2 = false, bool b3 = false,
      bool b4 = false, bool b5 = false, bool b6 = false, bool b7 = false, bool b8 = false, bool b9 = false,
      bool b10 = false, bool b11 = false, bool b12 = false, bool b13 = false, bool b14 = false, bool b15 = false)
    {
      bool[] retVal = new bool[16];
      retVal[0] = b0;
      retVal[1] = b1;
      retVal[2] = b2;
      retVal[3] = b3;
      retVal[4] = b4;
      retVal[5] = b5;
      retVal[6] = b6;
      retVal[7] = b7;
      retVal[8] = b8;
      retVal[9] = b9;
      retVal[10] = b10;
      retVal[11] = b11;
      retVal[12] = b12;
      retVal[13] = b13;
      retVal[14] = b14;
      retVal[15] = b15;
      return retVal;
    }

    public static bool[] ForByte(bool b0 = false, bool b1 = false, bool b2 = false, bool b3 = false,
      bool b4 = false, bool b5 = false, bool b6 = false, bool b7 = false)
    {
      bool[] retVal = new bool[8];
      retVal[0] = b0;
      retVal[1] = b1;
      retVal[2] = b2;
      retVal[3] = b3;
      retVal[4] = b4;
      retVal[5] = b5;
      retVal[6] = b6;
      retVal[7] = b7;
      return retVal;
    }

    public static bool[] ReDim(bool[] array, int newLength)
    {
      if (array == null) throw new ArgumentNullException(nameof(array));
      if (array.Length == newLength)
        return array;
      List<bool> list =new List<bool>(array);
      if (list.Count < newLength)
      {
        while (list.Count < newLength)
          list.Add(false);
      }
      else
      {
        while (list.Count > 0 && list.Count > newLength)
          list.RemoveAt(list.Count - 1);
      }
      return list.ToArray();
    }
  }
}
