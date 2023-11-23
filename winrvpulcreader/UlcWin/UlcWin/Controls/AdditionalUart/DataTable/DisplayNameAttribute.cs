using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin.Controls.AdditionalUart.DataTable
{
  [AttributeUsage(AttributeTargets.Property)]
  public class DisplayName : Attribute
  {
    public readonly string Name;

    public DisplayName(string statName)
    {
      Name = statName;
    }
  }
}
