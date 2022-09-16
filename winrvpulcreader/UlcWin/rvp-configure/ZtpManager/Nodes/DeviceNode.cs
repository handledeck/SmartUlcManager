using System;
using System.Collections.Generic;
using System.Linq;
using Ztp.Configuration;
using Ztp.Model;
using ZtpManager.Scope;

namespace ZtpManager.Nodes
{
  public class DeviceNode : BaseNode
  {
    public readonly ScopeItem ScopeItem;
    public DeviceNode(ScopeItem scopeItem)
      : base(scopeItem.NodeEx, 2)
    {
      ScopeItem = scopeItem;
      Nodes.Clear();
      SetImage(ScopeItem.NodeEx.IsError);
    }

    public void SetImage(bool isError)
    {
      if (TreeView != null && !TreeView.IsDisposed && TreeView.InvokeRequired)
      {
        TreeView.Invoke(new Action<bool>(SetImage), isError);
        return;
      }
      try
      {
        ImageIndex = StateImageIndex = SelectedImageIndex = isError ? 3 : 2;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    public new string Text
    {
      get { return base.Text; }
      set { base.Text = value; }
    }
    protected override void SetDisplayName()
    {
      Text = $"{_node.DisplayName} [{_node.IpAddress}]";
    }

    public static DeviceNode[] FromScopeItemArray(ScopeItem[] items)
    {
      if (items == null) throw new ArgumentNullException(nameof(items));
      DeviceNode[] retVal = new DeviceNode[items.Length];
      for(int i = 0; i < items.Length; i++)
        retVal[i] = new DeviceNode(items[i]);
      return retVal;
    }
  }
}