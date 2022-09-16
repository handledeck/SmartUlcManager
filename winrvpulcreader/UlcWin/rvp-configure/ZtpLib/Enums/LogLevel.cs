using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Ztp.Enums
{
  public enum LogLevel : byte
  {
    [Description("Debug")]
    Debug = 0,
    [Description("Info")]
    Info = 1,
    [Description("Warning")]
    Warning = 2,
    [Description("Error")]
    Error = 3,
    [Description("Fatal")]
    Fatal = 4,
    [Description("Отключено")]
    Disabled = 5
  }
}
