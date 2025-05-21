using System;
using System.ComponentModel;
using System.Windows.Forms;
using Uart.Attributes;
using Uart.Enums;

namespace Uart.Function
{
  [TypeConverter(typeof(PropertySorter))]
  public class MesItem : DataGridViewConverter
  {

    [Category("Настройки"), PropertyOrder(0)]
    [Description("Адрес опроса устройства")]
    [DisplayNamed("Функция")]
    [DisplayName("Функция")]
    public AistFunc FunctionIndex { get; set; }
    [Category("Настройки"), PropertyOrder(1)]
    [Description("Адрес опроса устройства")]
    [DisplayNamed("Номер счетчика")]
    [DisplayName("Номер счетчика")]

    public ushort MeterNum { get; set; }
    
    [Category("Настройки"), PropertyOrder(2)]
    [Description("Пароль")]
    [DisplayNamed("Пароль")]
    [DisplayName("Пароль")]
    public string Password { get; set; } = "";

    [Category("Настройки"), PropertyOrder(3)]
    [Description("Активность")]
    [DisplayNamed("Активность")]
    [DisplayName("Активность")]

    public AistChoise Activity { get; set; } = AistChoise.Second;
    [Category("Настройки"), PropertyOrder(4)]
    [Description("Индекс МЭК-104")]
    [DisplayNamed("Индекс МЭК-104")]
    [DisplayName("Индекс МЭК-104")]

    public ushort IecIndex { get; set; } = 50;

    public void CellFormatting(DataGridViewCellFormattingEventArgs e)
    {
      throw new NotImplementedException();
    }

    public void GetDataGridView(DataGridViewRow xr)
    {

      FunctionIndex = (AistFunc)xr.Cells["FunctionIndex"].Value;
      MeterNum = (ushort)xr.Cells["MeterNum"].Value;
      Password = (string)xr.Cells["Password"].Value;
      IecIndex = (ushort)xr.Cells["IecIndex"].Value;
      Activity = (AistChoise)xr.Cells["Activity"].Value;

    }

    public void SetDataGridView(DataGridViewRow xr)
    {
      xr.Cells["FunctionIndex"].Value = FunctionIndex;
      xr.Cells["MeterNum"].Value = MeterNum;
      xr.Cells["Password"].Value = Password;
      xr.Cells["IecIndex"].Value = IecIndex;
      xr.Cells["Activity"].Value = Activity;

    }
  }
}
