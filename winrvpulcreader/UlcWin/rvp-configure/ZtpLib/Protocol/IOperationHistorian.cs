using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ztp.Protocol
{
  public interface IOperationHistorian
  {
    void Write(int deviceId, OpHistoryCode code, string command, string objText, string result, bool isError);
  }
}
