using System;
using System.ComponentModel;
using System.Reflection;

namespace Ztp.Protocol
{
  public enum OpHistoryCode
  {
    [Description("Создание узла")]
    C,
    [Description("Изменение узла")]
    U,
    [Description("Запись конфигурации")]
    W,
    [Description("Вкл/Откл освещения")]
    L,
    [Description("Перезапуск")]
    R,
    [Description("Смена пароля")]
    P,
    [Description("Запись ПО")]
    F,
    [Description("Инициализация обновления ПО")]
    // ReSharper disable once InconsistentNaming
    IF,
    [Description("Чтение версии ядра на узле")]
    V,
    [Description("Загрузка патча")]
    PA,
    [Description("Чтение версии ПО")]
    VPO
  }
}

namespace System.Reflection
{
  public static class EnumEx
  {
    public static string GetDescription(this Enum value)
    {
      Type type = value.GetType();
      FieldInfo fieldInfo = type.GetField(value.ToString());
      DescriptionAttribute[] attrs = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
      if (attrs.Length == 0)
        return null;
      return attrs[0].Description;
    }
  }
}