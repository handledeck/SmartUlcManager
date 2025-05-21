using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uart.Attributes;

namespace Uart.Enums
{
  [TypeConverter(typeof(EnumTypeConverter))]
  public enum EnumModbusFunction : byte
  {
    [FieldDisplayName("Цифровой выход")]
    [Description("Цифровой выход (ф.1)")]
    DigitalOutput = 1,
    [FieldDisplayName("Цифровой вход")]
    [Description("Цифровой вход (ф.2)")]
    DigitalInput = 2,
    [FieldDisplayName("Выходной регистр")]
    [Description("Выходной регистр (ф.3)")]
    RegisterOutput = 3,
    [FieldDisplayName("Входной регистр")]
    [Description("Входной регистр (ф.4)")]
    RegisterInput = 4
  }

  [TypeConverter(typeof(EnumTypeConverter))]
  public enum GranFunc : byte
  {
    [FieldDisplayName("Чтение фазных напряжений")]
    [Description("Чтение фазных напряжений")]
    ReadPhaseVoltage = 1

  }
  [TypeConverter(typeof(EnumTypeConverter))]
  public enum Mes3Func : byte
  {
    [Description("Управление реле счётчика")]
    ReadPhaseVoltage = 1
  }
  public enum Mes3Choise : byte
  {
    [FieldDisplayName("Не активна")]
    [Description("Не активна")]
    Inactive = 0,
    [FieldDisplayName("Активно")]
    [Description("Активно")]
    Active = 1
  }

  [TypeConverter(typeof(EnumTypeConverter))]
  public enum AistFunc : byte
  {
    //[Description("Управление реле счётчика")]
    [FieldDisplayName("Управление реле счётчика")]
    [Description("Управление реле счётчика")]
    ReadPhaseVoltage = 0
  }


  [TypeConverter(typeof(EnumTypeConverter))]
  public enum AistChoise : byte
  {
    [FieldDisplayName("1")]
    [Description("Первый")]
    First = 0,
    [FieldDisplayName("2")]
    [Description("Второй")]
    Second = 1,
    [FieldDisplayName("3")]
    [Description("Третий")]
    Third = 1
  }

}
