using System;
using System.IO;
using System.Text;

namespace Ztp.IO.Logger
{
  public class FileLog : ILog
  {
    private string _filePath;
    private bool _append;
    readonly LogFormatter _formatter = new LogFormatter();

    public FileLog(string filePath, bool append)
    {
      if (string.IsNullOrEmpty(filePath))
        throw new ArgumentException("Value cannot be null or empty.", nameof(filePath));
      _filePath = filePath;
      _append = append;
    }

    public void Info(string message, params object[] args)
    {
      Write(_formatter.FormatInfo(message, args));
    }

    public void Error(string message, params object[] args)
    {
      Write(_formatter.FormatError(message, args));
    }

    public void Error(Exception e)
    {
      if(e != null)
        Write(_formatter.FormatError(e.Message));
    }

    private void Write(string message)
    {
      using (StreamWriter sw = new StreamWriter(_filePath, _append, Encoding.UTF8))
      {
        sw.WriteLine(message);
      }
    }

  }
}