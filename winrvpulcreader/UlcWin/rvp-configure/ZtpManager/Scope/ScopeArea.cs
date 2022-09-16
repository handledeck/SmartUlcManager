using System;
using System.Collections.Generic;
using System.Linq;
using Ztp.Model;
using ZtpManager.DataAccessLayer;

namespace ZtpManager.Scope
{
  public class ScopeArea
  {
    private static ScopeArea _default;

    public static ScopeArea Default
    {
      get
      {
        if(_default == null)
          _default = new ScopeArea();
        return _default;
      }
    }

    ScopeArea()
    {
    }

    public class NodeRemovedEventArg
    {
      public NodeRemovedEventArg(NodeEx node)
      {
        RemovedNode = node;
      }
      public NodeEx RemovedNode { get; }
    }

    public class NodeAddedEventArg
    {
      public NodeAddedEventArg(NodeEx node)
      {
        AddedNode = node;
      }
      public NodeEx AddedNode { get; }
    }

    public class NodeChangedEventArg
    {
      public NodeChangedEventArg(NodeEx node)
      {
        ChangedNode = node;
      }
      public NodeEx ChangedNode { get; }
    }

    public delegate void NodeRemovedEventHandler(NodeRemovedEventArg e);
    public delegate void NodeAddedEventHandler(NodeAddedEventArg e);
    public delegate void NodeChangedEventHandler(NodeChangedEventArg e);

    public event NodeAddedEventHandler NodeAdded;
    public event NodeRemovedEventHandler NodeRemoved;
    public event NodeChangedEventHandler NodeChanged;

    Dictionary<int, ScopeItem> _dic = new Dictionary<int, ScopeItem>();
    public SelectedList Selected { get; } = new SelectedList();


    public void Fill()
    {
      _dic.Clear();
      IEnumerable<NodeEx> nodes = Dal.Default.ReadDeviceNodesWithDisplayPath();
      foreach (NodeEx node in nodes)
      {
        ScopeItem item = new ScopeItem(node);
        _dic[node.Id] = item;
      }
    }

    public IEnumerable<NodeEx> GetDeviceNodes()
    {
      Dictionary<int, ScopeItem>.ValueCollection.Enumerator enumerator = _dic.Values.GetEnumerator();
      while (enumerator.MoveNext())
      {
        yield return enumerator.Current.NodeEx;
      }
    }

    //Изъятие перечня узлов с устройствами с определенным типом
    public IEnumerable<NodeEx> GetDeviceNodes(DeviceKind kind)
    {
      Dictionary<int, ScopeItem>.ValueCollection.Enumerator enumerator = _dic.Values.GetEnumerator();
      while (enumerator.MoveNext())
      {
        if(enumerator.Current.NodeEx.DevType == kind || kind == DeviceKind.Unknown)
          yield return enumerator.Current.NodeEx;
      }
    }

    public List<ScopeItem> GetEstDevices()
    {
      List<ScopeItem> retVal = new List<ScopeItem>();
      Dictionary<int, ScopeItem>.ValueCollection.Enumerator enumerator = _dic.Values.GetEnumerator();
      while (enumerator.MoveNext())
      {
        if(string.IsNullOrEmpty(enumerator.Current.NodeEx.EstCommStateGuid))
          continue;
        retVal.Add(enumerator.Current);
      }
      return retVal;
    }

    public void EditDevice(NodeEx deviceNode)
    {
      OnNodeChanged(deviceNode);
    }

    public void EditDevicesForFolder(string forderPath)
    {
      IEnumerable<int> childDeviceIds = Dal.Default.ReadFlatChildDeviceIds(forderPath);
      foreach (int id in childDeviceIds)
      {
        if (_dic.ContainsKey(id))
        {
          NodeEx node = _dic[id].NodeEx;
          string displayPath = Dal.Default.ReadNodeDisplayPath(id);
          node.DisplayPath = displayPath;
          OnNodeChanged(node);
        }
      }
    }
    public ScopeItem this[int deviceId]
    {
      get
      {
        if (_dic.ContainsKey(deviceId))
          return _dic[deviceId];
        return null;
      }
    }

    public bool Contains(int deviceId)
    {
      return _dic.ContainsKey(deviceId);
    }

    public ScopeItem Add(NodeEx nodes)
    {
      ScopeItem item = new ScopeItem(nodes);
      _dic[item.NodeEx.Id] = item;
      OnCollectionChanged(item.NodeEx);
      return item;
    }

    public ScopeItem[] AddRange(IEnumerable<NodeEx> nodes)
    {
      if (nodes == null) throw new ArgumentNullException(nameof(nodes));
      ScopeItem[] retVal = new ScopeItem[nodes.Count()];
      int index = 0;
      foreach (NodeEx node in nodes)
      {
        retVal[index] = Add(node);
        index++;
      }
      return retVal;
    }

    public bool Remove(int deviceId)
    {
      NodeEx node = null;
      if (_dic.ContainsKey(deviceId))
        node = _dic[deviceId].NodeEx;
      bool retVal = _dic.Remove(deviceId);
      if(retVal)
        OnRemovedNode(node);
      return retVal;
    }

    public void RemoveRange(IEnumerable<int> nodeIds)
    {
      foreach (int id in nodeIds)
      {
        Remove(id);
      }
    }

    protected virtual void OnCollectionChanged(NodeEx node)
    {
      NodeAdded?.Invoke(new NodeAddedEventArg(node));
    }

    protected virtual void OnRemovedNode(NodeEx node)
    {
      NodeRemoved?.Invoke(new NodeRemovedEventArg(node));
    }

    protected virtual void OnNodeChanged(NodeEx node)
    {
      NodeChanged?.Invoke(new NodeChangedEventArg(node));
    }
  }
}