using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Ztp.Port.TcpPort;
using Ztp.Protocol;

namespace ZtpManager.DeviceAccessLayer
{
  public class PortDictionary
  {
    Dictionary<int, ZtpProtocolDriver> _dic = new Dictionary<int, ZtpProtocolDriver>();

    public PortDictionary()
    {
    }

    public ZtpProtocolDriver this[int key]
    {
      get
      {
        if (_dic.ContainsKey(key))
          return _dic[key];
        return null;
      }
    }
    public ZtpProtocolDriver GetOrAdd(int key, Func<int, ZtpProtocolDriver> valueFactory)
    {
      ZtpProtocolDriver retVal;
      if (!_dic.ContainsKey(key))
      {
        retVal = valueFactory(key);
        _dic[key] = retVal;
      }
      else
      {
        retVal = _dic[key];
      }
      return retVal;
    }

    public bool Remove(int key)
    {
      if (_dic.ContainsKey(key))
      {
        ZtpProtocolDriver driver = _dic[key];
        if (driver.IsOpen)
        {
          driver.StopListener();
          driver.Close();
        }
      }
      return _dic.Remove(key);
    }

    public int Count
    {
      get { return _dic.Count; }
    }

    public Dictionary<int, ZtpProtocolDriver>.Enumerator GetEnumerator()
    {
      return _dic.GetEnumerator();
    }

    public Dictionary<int, ZtpProtocolDriver>.KeyCollection Keys
    {
      get { return _dic.Keys; }
    }

    public bool ContainsKey(int key)
    {
      return _dic.ContainsKey(key);
    }
  }
}