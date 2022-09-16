using System;

namespace Ztp.Attributes
{
  [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
  public class DevAttribute : Attribute
  {
    public int NumberOfTypeDev;
    public string DisplayName;

    public DevAttribute(int numberOfTypeDev, string displayName)
    {
      NumberOfTypeDev = numberOfTypeDev;
      DisplayName = displayName;
    }
  }
}
