using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uart.Delegates
{
  public delegate void EventCheckItem(object tag, out bool isUsedIec, out bool isUsedTag);
}
