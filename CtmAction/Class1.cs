using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtmAction
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Exception exception;
      CustomActions.TryCreateDb(out exception);
      int x = 0;
    }
  }
}
