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
    [FieldDisplayName("Чтение фазных напряжений")]
    [Description("Управление реле счётчика")]
    ReadPhaseVoltage = 1
  }
  [TypeConverter(typeof(EnumTypeConverter))]
  public enum Mes3Choise : byte
  {
    [FieldDisplayName("Не активнo")]
    [Description("Не активнo")]
    Inactive = 1,
    [FieldDisplayName("Активно")]
    [Description("Активно")]
    Active = 2
  }

  [TypeConverter(typeof(EnumTypeConverter))]
  public enum AistFunc : byte
  {
    
    [FieldDisplayName("Управление реле счётчика")]
    [Description("Управление реле счётчика")]
    ReadPhaseVoltage = 1
  }

  [TypeConverter(typeof(EnumTypeConverter))]
  public enum EnM318Func : byte
  {
    
    [FieldDisplayName("Чтение фазных напряжений")]
    [Description("Чтение фазных напряжений")]
    ReadPhaseVoltage = 1,
    [FieldDisplayName("Чтение мгновенной мощности")]
    [Description("Чтение мгновенной мощности")]
    ReadWingValue = 2

  }


  [TypeConverter(typeof(EnumTypeConverter))]
  public enum AistChoise : byte
  {
    [FieldDisplayName("Первый")]
    [Description("Первый")]
    First = 1,
    [FieldDisplayName("Второй")]
    [Description("Второй")]
    Second = 2,
    [FieldDisplayName("Третий")]
    [Description("Третий")]
    Third = 3
  }

}
