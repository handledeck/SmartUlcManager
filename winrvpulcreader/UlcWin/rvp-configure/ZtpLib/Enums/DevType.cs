using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Ztp.Enums
{
  public enum DevType: byte
  {
    [Description("Неизвестно")]
    Unknown = 0,
    [Description("РВП-18")]
    RVP18 = 1,
    [Description("ULC 02")]
    ULC02 = 2,
    [Description("ULC 02 (ver.2)")]
    ULC2_2 = 3
  }
}
