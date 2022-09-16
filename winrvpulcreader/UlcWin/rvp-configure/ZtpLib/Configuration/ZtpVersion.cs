using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ztp.Configuration
{
  //I16O2A2-LDC-3

    //todo!!!
  //I6O2A1-LEM-FOTA-prIM
  // L - ligth
  // E - elecrtometers 
  // M - as modbus master
  // -pr
  // I - IEC104
  // M - modbus tcp
  public class ZtpVersion
  {
    public bool Light { get; set; }
    public bool Door { get; set; } 
    public bool Counter { get; set; }
    public bool Fota { get; set; } = false;

    public byte Din { get; set; }
    public byte Dout { get; set; }
    public byte Ain { get; set; }

    public int NumVersion { get; set; }

    public ZtpVersion(string version)
    {
      if (string.IsNullOrEmpty(version)) throw new ArgumentException("Value cannot be null or empty.", nameof(version));
      string[] parts = version.Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries);
      if(parts.Length < 3)
        throw new FormatException("Строка имеет не верный формат");

      Light = parts[1].IndexOf("L", StringComparison.Ordinal) > -1;
      Door = parts[1].IndexOf("D", StringComparison.Ordinal) > -1;
      Counter = parts[1].IndexOf("C", StringComparison.Ordinal) > -1;

      NumVersion = Convert.ToInt32(parts[2]);

      Din = GetValue(parts[0], 'I');
      Dout = GetValue(parts[0], 'O');
      Ain = GetValue(parts[0], 'A');

      Fota = parts.Where<string>((s) => s == "FOTA").Any();
    }

    byte GetValue(string str, char name)
    {
      int pos = str.IndexOf(name);
      if (pos < 0)
        return 0;
      str = str.Remove(0, pos + 1);
      string value = string.Empty;
      for (int i = 0; i < str.Length; i++)
      {
        if (!char.IsDigit(str[i]))
          break;
        value += str[i];
      }
      return Convert.ToByte(value);
    }
  }
}
