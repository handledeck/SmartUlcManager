using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin.Controls.Uart.Interfaces
{
  public abstract class UartInterface
  {
    public abstract List<T> ParseFromArray<T>(byte[] buf);
  }
}
