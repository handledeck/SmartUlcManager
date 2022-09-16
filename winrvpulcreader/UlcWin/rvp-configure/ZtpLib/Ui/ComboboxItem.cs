using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Ztp.Ui
{
  internal class ComboboxItem<T> where T: struct  
  {
    readonly Type _type = typeof(T);
    public T Value;
    public ComboboxItem(T value)
    {
      Type type = typeof(T);
      if(!type.IsEnum)
        throw new ArgumentException("Тип <T> должен быть Enum");
      Value = value;
    }

    public override string ToString()
    {
      FieldInfo fi = _type.GetField(Value.ToString());
      DescriptionAttribute attr = fi.GetCustomAttributes(typeof(DescriptionAttribute), false).Select((a) => (DescriptionAttribute)a).First();
      return attr.Description;
    }

    public override bool Equals(object obj)
    {
      if (obj == null) return false;
      if (obj.GetType() != typeof(ComboboxItem<T>)) return false;
      return Value.Equals(((ComboboxItem<T>)obj).Value);
    }

    public override int GetHashCode()
    {
      return Value.GetHashCode();
    }
  }
}