using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Ztp.Utils
{
  public static class IpAddressValidator
  {
    public static Exception Validate(string ipAddress)
    {
      if (String.IsNullOrWhiteSpace(ipAddress))
      {
        return new Exception("Строка не может быть пустой");
      }

      byte tempForParsing;
      string[] splitValues = ipAddress.Split('.');
      if (splitValues.Length != 4 || !splitValues.All(r => byte.TryParse(r, out tempForParsing)))
      {
        return new Exception("Не корректный формат строки");
      }
      return null;
    }
  }
}
