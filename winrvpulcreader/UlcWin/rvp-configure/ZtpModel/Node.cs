using System;
using System.Linq;
using System.Reflection;
using Dapper.Contrib.Extensions;

namespace Ztp.Model
{
  [Serializable]
  [Table("Nodes")]
  public class Node
  {
    public int Id { get; set; }
    public int IdOwn { get; set; }
    public string Path { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public NodeKind Kind { get; set; }
    public string IpAddress { get; set; }
    public string Password { get; set; }
    public string EstCommStateGuid { get; set; }
    public DeviceKind DevType { get; set; }

    public Node Clone()
    {
      return (Node)this.MemberwiseClone();
    }

    public override int GetHashCode()
    {
      return Id;
    }

    public override bool Equals(object obj)
    {
      Node n = obj as Node;
      if (n == null) return false;
      return Id == n.Id;
    }

  }

  public static class NodeFld
  {
    public const string Id = "Id";
    public const string IdOwn = "IdOwn";
    public const string Path = "Path";
    public const string DisplayName = "DisplayName";
    public const string Description = "Description";
    public const string Kind = "Kind";
    public const string IpAddress = "IpAddress";
    public const string Password = "Password";
    public const string EstCommStateGuid = "EstCommStateGuid";
    public const string DevType = "DevType";
  }

  [Serializable]
  public class NodeEx: Node
  {
    public string DisplayPath { get; set; }
    public bool IsError { get; set; }

    public static NodeEx FromNode(Node node)
    {
      if (node == null) throw new ArgumentNullException(nameof(node));
      NodeEx retVal = new NodeEx();
      Type typeTo = typeof(NodeEx);
      Type typeFrom = typeof(Node);

      PropertyInfo[] propertiesTo = typeTo.GetProperties();
      PropertyInfo[] propertiesFrom = typeFrom.GetProperties();
      foreach (PropertyInfo property in propertiesFrom)
      {
        PropertyInfo info = propertiesTo.FirstOrDefault(p => p.Name == property.Name);
        if(info == null)
          continue;
        info.SetValue(retVal, property.GetValue(node, new object[0]), new object[0]);
      }
      return retVal;
    }
  }

}
