using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ztp.Protocol
{
  public class DeviceUnknownError: Exception
  {
    public DeviceUnknownError(string message)
      :base(message)
    {
    }
    public DeviceUnknownError(Exception innerException)
      :base(innerException.Message, innerException)
    {
    }
  }
}
