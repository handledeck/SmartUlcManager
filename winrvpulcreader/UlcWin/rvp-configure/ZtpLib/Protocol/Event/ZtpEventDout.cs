namespace Ztp.Protocol.Event
{
  public class ZtpEventDout : ZtpEvent
  {
    public override EventsKind Kind
    {
      get
      {
        return EventsKind.Dout;
      }
    }
    public bool Value { get; set; }
  }


}