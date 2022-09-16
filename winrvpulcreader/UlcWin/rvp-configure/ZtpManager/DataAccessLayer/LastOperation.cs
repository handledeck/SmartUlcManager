using System;

namespace ZtpManager.DataAccessLayer
{
  public class LastOperation
  {
    public string DisplayName { get; set; }
    public string IpAddress { get; set; }
    public string DisplayPath { get; set; }
    public bool IsError { get; set; }
    public string OpName { get; set; }
    public DateTime OpDate { get; set; }
    public string OpResult { get; set; }
    public string ObjText { get; set; }

  }
}