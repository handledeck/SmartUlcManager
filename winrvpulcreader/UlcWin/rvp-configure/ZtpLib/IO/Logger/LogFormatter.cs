using System;
using System.Text;

namespace Ztp.IO.Logger
{
  public class LogFormatter
  {

    public string FormatInfo(string message, params object[] args)
    {
      return Format("Info:  ", message, args);
    }

    public string FormatError(string message, params object[] args)
    {
      return Format("Error: ", message, args);
    }

    string Format(string prefix, string message, params object[] args)
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendFormat("{0} | {1}", DateTime.Now.ToString("HH:mm:ss"), prefix);
      sb.AppendFormat(message, args);
      return sb.ToString();
    }
  }
}