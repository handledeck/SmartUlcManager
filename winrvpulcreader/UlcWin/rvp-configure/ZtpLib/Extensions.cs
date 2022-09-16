using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable once CheckNamespace
namespace System
{


  public static class Extensions
  {
    public static T GetCustomAttribute<T>(this object obj) where T : class
    {
      return GetCustomAttribute<T>(obj, false);
    }

    public static T GetCustomAttribute<T>(this object obj, bool inherit) where T: class
    {
      if (obj == null) return null;
      Type t = obj.GetType();
      object[] attrs = t.GetCustomAttributes(typeof(T), inherit);
      if (attrs.Length == 0) return null;
      return (T)attrs[0];
    }

    public static string ToBitString(this bool[] array)
    {
      if (array == null) return null;
      StringBuilder sb = new StringBuilder();
      foreach (bool b in array)
      {
        if (b)
          sb.Append("1");
        else
          sb.Append("0");
      }
      return sb.ToString();
    }

    public static string ToValuesString(this ushort[] array)
    {
      if (array == null) return null;
      StringBuilder sb = new StringBuilder();
      bool first = true;
      foreach (ushort u in array)
      {
        if (!first)
          sb.Append(", ");
        sb.Append($"{u}");
        first = false;
      }
      return sb.ToString();
    }
  }
}
