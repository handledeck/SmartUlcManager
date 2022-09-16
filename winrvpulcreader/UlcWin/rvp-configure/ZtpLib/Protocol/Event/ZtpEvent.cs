using System;

namespace Ztp.Protocol.Event
{
  public enum EventsKind
  {
    Din,
    Dout,
    Ain
  }

  public class ZtpEvent
  {
    public virtual EventsKind Kind { get; }
    public byte Ord { get; set; }

    public static ZtpEvent Parse(string str)
    {
      str = str.Trim();
      if (str.StartsWith($"{ZtpProtocol.Event}{ZtpProtocol.Sep}{ZtpProtocol.EventDa}{ZtpProtocol.Sep}"))
      {
        str = str.Remove(0, $"{ZtpProtocol.Event}{ZtpProtocol.Sep}{ZtpProtocol.EventDa}{ZtpProtocol.Sep}".Length);
        string[] parts = str.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 2)
        {
          ZtpEventAin e = new ZtpEventAin();
          e.Ord = Convert.ToByte(parts[0]);
          e.Value = Convert.ToUInt16(parts[1]);
          return e;
        }
      }
      else if (str.StartsWith($"{ZtpProtocol.Event}{ZtpProtocol.Sep}{ZtpProtocol.EventDi}{ZtpProtocol.Sep}"))
      {
        str = str.Remove(0, $"{ZtpProtocol.Event}{ZtpProtocol.Sep}{ZtpProtocol.EventDi}{ZtpProtocol.Sep}".Length);
        string[] parts = str.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 2)
        {
          ZtpEventDin e = new ZtpEventDin();
          e.Ord = Convert.ToByte(parts[0]);
          e.Value = Convert.ToBoolean(Convert.ToInt32(parts[1]));
          return e;
        }
      }
      else if (str.StartsWith($"{ZtpProtocol.Event}{ZtpProtocol.Sep}{ZtpProtocol.EventDo}{ZtpProtocol.Sep}"))
      {
        str = str.Remove(0, $"{ZtpProtocol.Event}{ZtpProtocol.Sep}{ZtpProtocol.EventDo}{ZtpProtocol.Sep}".Length);
        string[] parts = str.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 2)
        {
          ZtpEventDout e = new ZtpEventDout();
          e.Ord = Convert.ToByte(parts[0]);
          e.Value = Convert.ToBoolean(Convert.ToInt32(parts[1]));
          return e;
        }
      }
      return null;
    }
  }

  public delegate void ChangeStateEventHandler(ZtpEvent state);
}
