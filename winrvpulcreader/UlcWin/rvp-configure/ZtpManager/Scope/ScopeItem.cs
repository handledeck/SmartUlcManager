using System;
using Ztp.Configuration;
using Ztp.Model;
using ZtpManager.Nodes;

namespace ZtpManager.Scope
{
  public class ScopeItem
  {
    public ScopeItem(NodeEx nodeEx)
    {
      if (nodeEx == null) throw new ArgumentNullException(nameof(nodeEx));
      NodeEx = nodeEx;
    }

    public DeviceNode CreateDeviceNode()
    {
      return new DeviceNode(this);
    }

    public NodeEx NodeEx { get; }

    public override string ToString()
    {
      return $"[{NodeEx.Id}] [{NodeEx.DisplayName}] [{NodeEx.IpAddress}]";
    }

    public string DeviceName
    {
      get { return NodeEx.DisplayName; }
    }

    private ZtpConfig _ztpConfig = ZtpConfig.GetDefault();

    public ZtpConfig ZtpConfig
    {
      get { return _ztpConfig; }
      set { _ztpConfig = value; }
    }

  }
}
