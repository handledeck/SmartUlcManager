using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UlcWin.Controls.AdditionalUart.DataTable;

namespace RepairObjectListView
{
  public class AistItem
  {
    [DisplayName("Функция")]
    public int Function { get; set; }
    [DisplayName("Номер счетчика")]
    public string Address { get; set; }
    [DisplayName("Пароль")]
    public string Password { get; set; }
    [DisplayName("Активность")]
    public string Active { get; set; }
    [DisplayName("Индекс МЭК-104")]
    public string IDIec { get; set; }
  }
}
