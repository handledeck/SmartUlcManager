using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Dapper.Contrib.Extensions;


namespace Ztp.Model
{
  [Table("OpHistories")]
  public class OpHistory
  {
    public OpHistory()
    {
      UserName = Environment.UserName;
      OpDate = DateTime.Now;
    }

    public int Id { get; set; }
    public int IdNode { get; set; }
    public DateTime OpDate { get; set; }
    public string UserName { get; set; }
    public string OpCode { get; set; }
    public string OpName { get; set; }
    public string Cmd { get; set; }
    public string ObjText { get; set; }
    public string OpResult { get; set; }
    public bool IsError { get; set; }
  }

  public static class OpHistoryFld
  {
    public const string Id = "Id";
    public const string IdNode = "IdNode";
    public const string OpDate = "OpDate";
    public const string UserName = "UserName";
    public const string OpCode = "OpCode";
    public const string OpName = "OpName";
    public const string Cmd = "Cmd";
    public const string ObjText = "ObjText";
    public const string OpResult = "OpResult";
    public const string IsError = "IsError";
  }
}
