using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UlcWin.Controls.AdditionalUart.DataTable;

namespace RepairObjectListView
{
  class GranItem
  {
    [DisplayName("Функция")]
    public int Id { get; set; }
    [DisplayName("Номер счетчика")]
    public string Address { get; set; }
    [DisplayName("Нижняя граница")]
    public string Command { get; set; }
    [DisplayName("Верхняя граница")]
    public string AddressField { get; set; }
    [DisplayName("Адрес МЭК-104")]
    public string IdIec { get; set; }
  }
}

