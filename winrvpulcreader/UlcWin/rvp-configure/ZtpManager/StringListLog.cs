using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ztp.IO.Logger;

namespace ZtpManager
{
  class StringListLog : ILog
  {
    LogFormatter _formatter = new LogFormatter();
    public List<string> Messages { get; } = new List<string>();
    public void Info(string message, params object[] args)
    {
      Messages.Add(_formatter.FormatInfo(message, args));
    }

    public void Error(string message, params object[] args)
    {
      Messages.Add(_formatter.FormatError(message, args));
    }

    public void Error(Exception e)
    {
      Error(e.Message);
    }
  }
}
