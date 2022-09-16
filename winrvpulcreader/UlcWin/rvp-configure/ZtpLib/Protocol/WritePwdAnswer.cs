using System;
using Ztp.Configuration;

namespace Ztp.Protocol
{
  public class WritePwdAnswer
  {
    private string _pwdResult = ZtpProtocol.Error;
    public string PwdResult
    {
      get { return _pwdResult; }
      set
      {
        _pwdResult = value;
      }
    }

    public bool IsOk
    {
      get
      {
        return string.Equals(PwdResult, ZtpProtocol.Ok);
      }
    }

    public string DisplayMessage
    {
      get { return IsOk ? "Операция успешно завершена" : "Доступ запрещен"; }
    }

    public static WritePwdAnswer OK
    {
      get { return new WritePwdAnswer() { PwdResult = ZtpProtocol.Ok }; }
    }
  }

  public class ReadConfigAnswer
  {
    public Exception Error { get; set; }
    public ZtpConfig Config { get; set; }
  }

  public class ReadAnyAnswer
  {
    public string answer;

  }
}