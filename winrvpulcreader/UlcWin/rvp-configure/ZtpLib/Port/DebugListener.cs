using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Ztp.Protocol;

namespace Ztp.Port
{
  public class DebugListener
  {
    private readonly object _syncObject;
    private IODriverClient _port;
    private Action<string> _addMessage;
    private bool _running = false;
    public DebugListener(object syncObject)
    {
      if (syncObject == null) throw new ArgumentNullException(nameof(syncObject));
      _syncObject = syncObject;
    }

    public void Start(IODriverClient port, Action<string> addMessage)
    {
      if (port == null) throw new ArgumentNullException(nameof(port));
      if (addMessage == null) throw new ArgumentNullException(nameof(addMessage));
      _port = port;
      _addMessage = addMessage;
      _running = true;
      Thread t = new Thread(RunThread);
      t.Start();
    }

    public void Stop()
    {
      _running = false;
    }

    public static string NormalizeString(string text)
    {
      if(text == null)
        return text;
      return text.Replace(" \b", "");
    }
    void RunThread()
    {
      while (true)
      {
        lock (_syncObject)
        {
          try
          {
            string line = _port.ReadDebug();
            line = NormalizeString(line);
            //line = line.TrimStart(' ', '\b');
            _addMessage(line);
            //byte[] buff = new byte[1024*3];
            //int readed = _port.Read(buff, 0, buff.Length);
            //using (MemoryStream ms = new MemoryStream())
            //{
            //  ms.Write(buff, 0, readed);
            //  string str = ZtpProtocol.FromBytes(ms.ToArray());
            //  string[] lines = str.Split(new []{'\b'}, StringSplitOptions.RemoveEmptyEntries);

            //  for (int i = 0; i < lines.Length; i++)
            //  {

            //    string tmp = lines[i].Trim(' ');
            //    tmp = tmp.Replace("\0", "");
            //    if (tmp.Length > 0)
            //    {
            //      _addMessage(tmp);
            //    }
            //  }
            //}
          }
          catch(Exception e)
          {
            Thread.Sleep(20);
            string s = e.ToString();
          }
          if (!_running)
            break;
        }
      }
    }
  }
}
