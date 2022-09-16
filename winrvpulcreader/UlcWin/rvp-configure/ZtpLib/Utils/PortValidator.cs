using System;

namespace Ztp.Utils
{
  public static class PortValidator
  {
    private const int _min = 1024;
    private const int _max = 65536;
    public static Exception Validate(string port)
    {
      Exception e = IntValidator.Validate(port);
      if (e != null)
        return e;
      int value = int.Parse(port);
      if (value <= _min || value >= _max)
        return new Exception($"Значение должно находиться в диапазоне от {_min} до {_max}");
      return null;
    }
  }
}