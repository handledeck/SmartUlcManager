namespace Ztp.Protocol.Event
{
  public class ZtpEventDin : ZtpEvent
  {
    public override EventsKind Kind
    {
      get
      {
        return EventsKind.Din;
      }
    }

    public bool Value { get; set; }
  }
}