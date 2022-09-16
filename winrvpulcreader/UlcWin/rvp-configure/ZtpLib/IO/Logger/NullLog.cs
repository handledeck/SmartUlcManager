using System;

namespace Ztp.IO.Logger
{
  public class NullLog : ILog
  {
    NullLog()
    {
    }
    // ReSharper disable once InconsistentNaming
    public static ILog Null { get; } = new NullLog();

    public void Info(string message, params object[] args)
    {
    }

    public void Error(string message, params object[] args)
    {
    }

    public void Error(Exception e)
    {
    }
  }
}