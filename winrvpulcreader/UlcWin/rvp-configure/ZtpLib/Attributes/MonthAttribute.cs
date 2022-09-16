using System;

namespace Ztp.Attributes
{
  [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
  public class MonthAttribute : Attribute
  {
    public int CountOfDay;
    public string DisplayName;
    public string Word;

    public MonthAttribute(int countOfDay, string displayName, string word)
    {
      CountOfDay = countOfDay;
      DisplayName = displayName;
      Word = word;
    }
  }
}