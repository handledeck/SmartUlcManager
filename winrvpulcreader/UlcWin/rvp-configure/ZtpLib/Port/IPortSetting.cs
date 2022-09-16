namespace Ztp.Port
{
  public interface IPortSetting
  {
    PortKind Kind { get; }
    int Timeout { get; }
  }
}