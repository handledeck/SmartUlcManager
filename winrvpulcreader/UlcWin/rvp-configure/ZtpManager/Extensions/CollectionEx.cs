using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ztp.Model;

// ReSharper disable once CheckNamespace
namespace System.Collections.Generic
{
  public static class CollectionEx
  {
    public static int[] ToArrayOfIds(this List<NodeEx> nodes)
    {
      int[] retVal = new int[nodes.Count];
      for (int i = 0; i < nodes.Count; i++)
        retVal[i] = nodes[i].Id;
      return retVal;
    }
  }
}
