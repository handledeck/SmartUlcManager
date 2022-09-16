using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ztp.IO.Logger
{
  public class СompoundLog: ILog, IList<ILog>
  {
    List<ILog> _list = new List<ILog>();
    object _sync = new object();

    public void Info(string message, params object[] args)
    {
      lock (_sync)
      {
        foreach (ILog log in _list)
        {
          log.Info(message, args);
        }
      }
    }

    public void Error(string message, params object[] args)
    {
      lock (_sync)
      {
        foreach (ILog log in _list)
        {
          log.Error(message, args);
        }
      }
    }

    public void Error(Exception e)
    {
      lock (_sync)
      {
        foreach (ILog log in _list)
        {
          log.Error(e);
        }
      }

    }

    public IEnumerator<ILog> GetEnumerator()
    {
      lock (_sync)
      {
        return _list.GetEnumerator();
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public void Add(ILog item)
    {
      if (item == null) throw new ArgumentNullException(nameof(item));
      lock (_sync)
      {
        _list.Add(item);
      }
    }

    public void Clear()
    {
      lock (_sync)
      {
        _list.Clear();
      }
    }

    public bool Contains(ILog item)
    {
      lock (_sync)
      {
        return _list.Contains(item);
      }
    }

    public void CopyTo(ILog[] array, int arrayIndex)
    {
      lock (_sync)
      {
        _list.CopyTo(array, arrayIndex);
      }
    }

    public bool Remove(ILog item)
    {
      if (item == null) throw new ArgumentNullException(nameof(item));
      lock (_sync)
      {
        return _list.Remove(item);
      }
    }

    public int Count
    {
      get
      {
        lock (_sync)
        {
          return _list.Count;
        }
      }
    }
    public bool IsReadOnly => false;

    public int IndexOf(ILog item)
    {
      lock (_sync)
      {
        return _list.IndexOf(item);
      }
    }

    public void Insert(int index, ILog item)
    {
      lock (_sync)
      {
        _list.Insert(index, item);
      }
    }

    public void RemoveAt(int index)
    {
      lock (_sync)
      {
        _list.RemoveAt(index);
      }
    }

    public ILog this[int index]
    {
      get
      {
        lock (_sync)
        {
          return _list[index];
        }
      }
      set
      {
        lock (_sync)
        {
          _list[index] = value;
        }
      }
    }
  }
}
