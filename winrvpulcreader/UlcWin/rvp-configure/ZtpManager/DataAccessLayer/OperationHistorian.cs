using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Ztp.Model;
using Ztp.Protocol;
using OpHistoryCode = Ztp.Protocol.OpHistoryCode;

namespace ZtpManager.DataAccessLayer
{
  class OperationHistorian: IOperationHistorian
  {
    OperationHistorian()
    {
    }

    private static OperationHistorian _default;

    public static OperationHistorian Default
    {
      get
      {
        if(_default == null)
          _default = new OperationHistorian();
        return _default;
      }
    }
    public void Write(int deviceId, OpHistoryCode code, string command, string objText, string result, bool isError)
    {
      OpHistory oh = new OpHistory()
      {
        IdNode = deviceId,
        Cmd = command,
        OpCode = code.ToString(),
        OpName = code.GetDescription(),
        ObjText = objText,
        OpResult = result,
        IsError = isError
      };
      Dal.Default.WriteOperationHistory(oh);
    }
  }
}
