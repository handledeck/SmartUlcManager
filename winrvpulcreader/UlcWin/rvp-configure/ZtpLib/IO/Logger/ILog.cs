using System;

namespace Ztp.IO.Logger
{
  public interface ILog
  {
    void Info(string message, params object[] args);
    void Error(string message, params object[] args);
    void Error(Exception e);
  }
}
