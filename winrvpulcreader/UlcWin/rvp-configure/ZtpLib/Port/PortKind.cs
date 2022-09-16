using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Ztp.Port
{
  public enum PortKind
  {
    [Description("COM порт")]
    Com,
    [Description("TCP порт")]
    Tcp
  }
}
