using System;

namespace Ztp.Utils
{
  public static class IntValidator
  {
    public static Exception Validate(string value)
    {
      try
      {
        int.Parse(value);
      }
      catch (Exception e)
      {
        return e;
      }
      return null;
    }
  }
}