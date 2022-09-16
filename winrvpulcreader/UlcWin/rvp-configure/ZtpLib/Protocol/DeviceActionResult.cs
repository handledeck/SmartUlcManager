using System.Collections.Generic;

namespace Ztp.Protocol
{
  public class DeviceActionResult
  {
    public ActionResult[] Values { get; set; }
    private DeviceActionMode Mode { get; }
    public DeviceActionResult(DeviceActionMode mode)
    {
      Mode = mode;
    }
  }

  public class ActionResult
  {
    public int DeviceId { get; set; }
    public object Value { get; set; }
  }
}