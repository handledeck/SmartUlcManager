using System.ComponentModel;
namespace Ztp.Model
{
  /// <summary>
  /// Типы устройств обслуживаемых приложением
  /// </summary>
  public enum DeviceKind
  {
    [Description("Неизвестно")]
    Unknown = 0,
    [Description("РВП-18")]
    RVP18 = 1,
    [Description("ULC 02")]
    ULC02 = 2
  }
}
