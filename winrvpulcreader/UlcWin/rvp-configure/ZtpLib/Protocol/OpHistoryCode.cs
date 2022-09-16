using System;
using System.ComponentModel;
using System.Reflection;

namespace Ztp.Protocol
{
  public enum OpHistoryCode
  {
    [Description("�������� ����")]
    C,
    [Description("��������� ����")]
    U,
    [Description("������ ������������")]
    W,
    [Description("���/���� ���������")]
    L,
    [Description("����������")]
    R,
    [Description("����� ������")]
    P,
    [Description("������ ��")]
    F,
    [Description("������������� ���������� ��")]
    // ReSharper disable once InconsistentNaming
    IF,
    [Description("������ ������ ���� �� ����")]
    V,
    [Description("�������� �����")]
    PA,
    [Description("������ ������ ��")]
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