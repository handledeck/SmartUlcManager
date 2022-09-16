using System;
using System.Text;
using System.Text.RegularExpressions;
using Ztp.Protocol;


namespace Ztp.Utils
{
  public static class StringUtils
  {
    public static Exception CheckPasswordString(string psw)
    {
      if (psw.Length == 0)
        return new Exception("Пароль не должен быть пустым");
      if (psw.Length > 29)
        return new Exception($"Длина пароля не должна превышать {ZtpProtocol.MaxStringLength} символов");
      if (Regex.IsMatch(psw, @"\p{IsCyrillic}"))
        return new Exception($"Проверьте расскладку! Пароль не должен содержать символы кирилицы");
      return null;
    }

    public static string ToBase64String(string str)
    {
      if (str == null) throw new ArgumentNullException(nameof(str));
      byte[] ba = ZtpProtocol.ToBytes(str);
      return Convert.ToBase64String(ba);
    }

    public static string FromBase64String(string str)
    {
      if (str == null) throw new ArgumentNullException(nameof(str));
      byte[] base64String = Convert.FromBase64String(str);
      return ZtpProtocol.FromBytes(base64String);
    }

    public static string TrimStringLength(string str, int maxLength)
    {
      if (str == null) return str;
      if (str.Length <= maxLength) return str;
      StringBuilder sb = new StringBuilder(str);
      sb.Length = maxLength;
      return sb.ToString();
    }

    public static string BoolArrayToString(bool[] array)
    {
      if (array == null)
        return "";
      StringBuilder sb = new StringBuilder();
      foreach (bool b in array)
      {
        sb.Append(Convert.ToByte(b));
      }
      return sb.ToString();
    }

  }
}
