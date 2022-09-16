using Ztp.Model;

namespace ZtpManager.Nodes
{
  public class RootNode : BaseNode
  {
    public RootNode()
      : base(new Node() {DisplayName = "Список устройств", Id = 0}, 0)
    {
    }
  }
}