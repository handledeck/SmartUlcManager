namespace Ztp.Protocol.Event
{
  public class ZtpEventAin : ZtpEvent
  {
    public override EventsKind Kind
    {
      get
      {
        return EventsKind.Ain;
      }
    }
    public ushort Value { get; set; }
  }
}