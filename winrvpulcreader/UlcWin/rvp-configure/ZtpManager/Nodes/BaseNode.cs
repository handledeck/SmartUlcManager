using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Ztp.Model;

namespace ZtpManager.Nodes
{
  public class BaseNode : TreeNode
  {
    public BaseNode(Node node, int imageIndex)
      :base(node.DisplayName, imageIndex, imageIndex)
    {
      Nodes.Add(new StubNode());
      Node = node;
    }

    public bool FirstExpand { get; set; } = true;

    protected Node _node;

    public NodeKind Kind { get { return _node.Kind; } }
    public Node Node
    {
      get { return _node; }
      set
      {
        if(value == null)
          throw new ArgumentException(nameof(value));
        _node = value;
        SetDisplayName();
      }
    }

    protected virtual void SetDisplayName()
    {
      Text = _node.DisplayName;
    }

    public new string Text
    {
      get { return base.Text; }
      set { base.Text = value; }
    }

    public string Path
    {
      get
      {
        StringBuilder sb = new StringBuilder(Text);
        while (Parent != null && ((BaseNode)Parent).Kind != NodeKind.None)
        {
          sb.Insert(0, Parent.Text + "\\");
        }
        return sb.ToString();
      }
    }
    public override int GetHashCode()
    {
      return _node.Id;
    }

    public override bool Equals(object obj)
    {
      BaseNode bn = obj as BaseNode;
      return bn?.Node.Id == Node.Id;
    }

    public class BaseNodeComparer: IComparer<BaseNode>
    {
      public int Compare(BaseNode x, BaseNode y)
      {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;
        return string.Compare(x.Node.DisplayName, y.Node.DisplayName, StringComparison.Ordinal);
      }
    }
  }
}