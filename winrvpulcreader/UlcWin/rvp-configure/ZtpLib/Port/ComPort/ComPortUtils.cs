using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace Ztp.Port.ComPort
{
  public class ComPortUtils
  {
    static readonly Comparer comparer = new Comparer();

    class Comparer : IComparer<string>
    {
      int GetInt(string x)
      {
        int ind = -1;
        for (int i = 0; i < x.Length; i++)
        {
          if (Char.IsDigit(x[i]))
          {
            ind = i;
            break;
          }
        }
        if (ind > 0)
        {
          Int32.TryParse(x.Remove(0, ind), out ind);
        }
        return ind;
      }

      public int Compare(string x, string y)
      {
        var xInt = GetInt(x);
        var yInt = GetInt(y);
        if ((xInt < 0) && (yInt < 0)) return String.Compare(x, y);
        if (xInt < 0) return 1;
        if (yInt < 0) return -1;

        return xInt - yInt;
      }
    }

    public static string[] GetPortNames()
    {
      string[] names = SerialPort.GetPortNames();
      if ((names != null) && (names.Length > 1)) Array.Sort(names, comparer);
      return names;
    }
  }
}
