using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Model;
using Ztp.Ui;
using ZtpManager.DataAccessLayer;
using ZtpManager.Nodes;
using ZtpManager.Scope;

namespace ZtpManager.Controls
{
  public class DeviceTreeView : Bss.Windows.Forms.Mstv.MWTreeView
  {

    DeviceKind _devKind = DeviceKind.Unknown;
    protected override void Dispose(bool disposing)
    {
      ScopeArea.Default.NodeChanged -= Default_NodeChanged;
      base.Dispose(disposing);
    }
    
    public DeviceTreeView()
    {
      ScopeArea.Default.NodeChanged += Default_NodeChanged;
    }

    public DeviceKind DevKind
    {
      get
      {
        return _devKind;
      }
      set
      {
        _devKind = value;
      }
    }

    private void Default_NodeChanged(ScopeArea.NodeChangedEventArg e)
    {
      if (this.InvokeRequired)
      {
        Invoke(new Action<ScopeArea.NodeChangedEventArg>(Default_NodeChanged), e);
        return;
      }
      BaseNode baseNode = FindNodeById(e.ChangedNode.Id, Nodes);
      if(baseNode == null)
        return;
      baseNode.Node = baseNode.Node;
      if (baseNode.Kind == NodeKind.Device)
      {
        DeviceNode dn = (DeviceNode) baseNode;
        dn.SetImage(dn.ScopeItem.NodeEx.IsError);
      }
    }

    public void Initialize()
    {
      if (Nodes.Count > 0)
        Nodes.Clear();
      CreateRootNode();
      if(Nodes.Count > 0)
        BuildTreeRecursive(Nodes[0]);
      CollapseAll();
    }
    private bool _autoCreateTree = false;

    public bool AutoCreateTree
    {
      get { return _autoCreateTree; }
      set
      {
        if (_autoCreateTree != value)
        {
          _autoCreateTree = value;
          if(Nodes.Count > 0)
            BuildTreeRecursive(Nodes[0]);
        }
      }
    }

    void CreateRootNode()
    {
      if (!Dal.Default.IsConnected)
        return;
      Nodes.Add(new RootNode());
    }

    protected override void OnAfterExpand(TreeViewEventArgs e)
    {
      if (!Dal.Default.IsConnected) return;
      BaseNode parent = e.Node as BaseNode;
      if (parent == null) return;
      if (!parent.FirstExpand) return;
      if (parent.Kind == NodeKind.Device) return;
      try
      {
        BuildTree(parent);
      }
      catch (Exception ex)
      {
        parent.Collapse();
        Box.Error(this, ex);
      }
    }
    
    void BuildTreeRecursive(TreeNode parent)
    {
      if (!AutoCreateTree)
        return;
      if (parent == null)
        return;
      parent.Expand();
      for (int i = 0; i < parent.Nodes.Count; i++)
      {
        BuildTreeRecursive(parent.Nodes[i]);
      }
    }

    void BuildTree(BaseNode parent)
    {
      int id = parent.Kind == NodeKind.Folder ? parent.Node.Id : 0;
      BeginUpdate();
      try
      {
        parent.Nodes.Clear();
        IEnumerable<int> deviceIds = Dal.Default.ReadChildDeviceIds(id);
        int deviceCount = deviceIds.Count();
        if (deviceCount == 0) //узел содержит вложенные папки
        {
          IEnumerable<Node> nodes = Dal.Default.ReadChildNodes(id);
          foreach (Node node in nodes)
          {
            parent.Nodes.Add(new FolderNode(node));
          }
        }
        else//узел содержит вложенные устройства
        {
          //все существующие устройства уже находятся в ScopeArea
          foreach (int deviceId in deviceIds)
          {
            ScopeItem item = ScopeArea.Default[deviceId];
            if(item.NodeEx.DevType == _devKind || _devKind == DeviceKind.Unknown)
              parent.Nodes.Add(item.CreateDeviceNode());
          }
        }
        parent.FirstExpand = false;
      }
      finally
      {
        EndUpdate();
      }
    }

    //public void ShowDevicesByType(DeviceKind kind, TreeNodeCollection tn)
    //{
    //  foreach(BaseNode node in tn)
    //  {
    //    if(node.Kind == NodeKind.Device)
    //    {
    //      NodeEx ne = ScopeArea.Default[node.Node.Id].NodeEx;
    //      if (ne.DevType != kind)
    //      {
    //        node.EnsureVisible();
    //      }
    //    }
    //    else
    //    {
    //      this.ShowDevicesByType(kind, tn.Nodes);
    //    }
    //  }
    //}

    private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
    {
      foreach (TreeNode node in treeNode.Nodes)
      {
        node.Checked = nodeChecked;
        if (node.Nodes.Count > 0)
        {
          this.CheckAllChildNodes(node, nodeChecked);
        }
      }
    }

    void UncheckAllParentNode(TreeNode treeNode)
    {
      if(treeNode.Parent == null)
        return;
      treeNode.Parent.Checked = false;
      UncheckAllParentNode(treeNode.Parent);
    }

    protected override void OnAfterCheck(TreeViewEventArgs e)
    {
      if (e.Action != TreeViewAction.Unknown)
      {
        if (e.Node.Nodes.Count > 0)
        {
          this.CheckAllChildNodes(e.Node, e.Node.Checked);
        }
        if (!e.Node.Checked)
        {
          UncheckAllParentNode(e.Node);
        }
      }
      base.OnAfterCheck(e);
    }

    public List<NodeEx> SelectedDevices
    {
      get { return GetCheckedDevices(Nodes); }
    }
    private List<NodeEx> GetCheckedDevices(TreeNodeCollection collection)
    {
      List<NodeEx> list = new List<NodeEx>();
      foreach (TreeNode tn in collection)
      {
        BaseNode node = tn as BaseNode;
        if (node != null && node.Checked && node.Kind == NodeKind.Device)
          list.Add(ScopeArea.Default[node.Node.Id].NodeEx);
        list.AddRange(GetCheckedDevices(tn.Nodes));
      }
      return list;
    }

    public void Uncheck(NodeEx node)
    {
      BaseNode bn = FindNodeById(node.Id, Nodes);
      bn.Checked = false;
      //проверка родительских директорий надо ли снимать галочку
    }

    public void CheckAllNodes( bool nodeChecked)
    {
      foreach (TreeNode node in Nodes)
      {
        node.Checked = nodeChecked;
        if (node.Nodes.Count > 0)
        {
          this.CheckAllChildNodes(node, nodeChecked);
        }
      }
    }

    BaseNode FindNodeById(int id, TreeNodeCollection collection)
    {
      BaseNode retVal = null;
      foreach (TreeNode node in collection)
      {
        BaseNode bn = node as BaseNode;
        if(bn == null)
          continue;
        if (bn.Node.Id == id)
          return bn;
          retVal = FindNodeById(id, bn.Nodes);
        if(retVal != null)
          break;
      }
      return retVal;
    }
  }
}
