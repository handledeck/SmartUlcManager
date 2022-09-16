using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZtpManager.Scope
{
  public class SelectedList
  {
    List<ScopeItem> _list = new List<ScopeItem>();
    Dictionary<int, int> _dic = new Dictionary<int, int>();//key(NodeEx.Id)=>value(_list.Index)

    public void Add(ScopeItem item)
    {
      if (item == null) throw new ArgumentNullException(nameof(item));
      _list.Add(item);
      _dic[item.NodeEx.Id] = _list.Count - 1;
    }

    public ScopeItem First()
    {
      if (_list.Count == 0)
        return null;
      return _list[0];
    }
    public void Clear()
    {
      _list.Clear();
      _dic.Clear();
    }

    public void RemoveByKey(int key)
    {
      if (_dic.ContainsKey(key))
      {
        int index = _dic[key];
        _dic.Remove(key);
        _list.RemoveAt(index);
      }
    }

    public ScopeItem GetByKey(int key)
    {
      ScopeItem retVal = null;
      if (_dic.ContainsKey(key))
      {
        int index = _dic[key];
        retVal = _list[index];
      }
      return retVal;
    }

    public ScopeItem GetByIndex(int index)
    {
      return _list[index];
    }

    public int Count
    {
      get { return _list.Count; }
    }

  }

}
