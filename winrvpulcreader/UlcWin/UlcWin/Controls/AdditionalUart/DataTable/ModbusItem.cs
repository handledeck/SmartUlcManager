using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UlcWin.Controls.AdditionalUart.DataTable;

namespace RepairObjectListView
{
  public class ModbusItem
  {
    [DisplayName("Номер")]
    public int Id { get; set; }
    [DisplayName("Адрес устройства")]
    public string Address { get; set; }
    [DisplayName("Команда")]
    public string Command { get; set; }
    [DisplayName("Адрес поля")]
    public string AddressField { get; set; }
    [DisplayName("ID МЭК-104")]
    public string IdIec { get; set; }
    [DisplayName("Зона н.ч %")]
    public string Univalebele { get; set; }
    [DisplayName("Описание тега")]
    public string Commit { get; set; }
  }
}

