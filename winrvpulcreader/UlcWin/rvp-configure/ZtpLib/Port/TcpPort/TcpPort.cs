using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using Ztp.IO.Logger;

namespace Ztp.Port.TcpPort
{
  public class TcpPort : IPort
  {
    private static readonly NLog.Logger nLogger = NLog.LogManager.GetCurrentClassLogger();

    readonly object _sync = new object();
    TcpClient _client;
    private readonly TcpPortSettings _setting;
    private readonly ILog _log;

    public TcpPort(IPortSetting setting)
      : this(setting, NullLog.Null)
    {
    }

    public TcpPort(IPortSetting setting, ILog log)
    {
      if (log == null) throw new ArgumentNullException(nameof(log));
      _log = log;
      TcpPortSettings sett = setting as TcpPortSettings;
      if (sett == null) throw new ArgumentNullException(nameof(setting));
      _setting = sett;
    }

    public void DiscardInBuffer()
    {
      AssertOpen();
      int available = _client.Available;
      if (available > 0)
      {
        byte[] buff = new byte[available];
        try
        {
          NetworkStream stream = GetStream();
          stream.Read(buff, 0, buff.Length);
        }
        catch (Exception exp)
        {
          _log.Error($"TcpChanel.DiscardInBuffer:{exp.Message}");
          throw;
        }
      }
    }

    public void DiscardOutBuffer()
    {
    }

    public string DisplayName
    {
      get { return _setting.ToDisplay(); }
    }

    public void Write(byte[] buffer, int offset, int count)
    {
      AssertOpen();
      DiscardInBuffer();
      NetworkStream stream = GetStream();
      stream.Write(buffer, offset, count);
    }


    public event MessageReceivedEventHandler MessageReceived;
    public void Close()
    {
      lock (_sync)
      {
        if (_client != null)
        {
          try
          {
            _client.Close();
          }
          catch
          {
          }
          finally
          {
            _client = null;
          }
        }
      }
    }

    public void Open()
    {
      try
      {
        lock (_sync)
        {
          if (_client != null)
          {
            Close();
          }

          _client = new TcpClient();
          _client.ReceiveTimeout = _setting.Timeout;
          _client.SendTimeout = _setting.Timeout;
          _client.Connect(_setting.IpAddress, (int)_setting.Port);
          System.Threading.Thread.Sleep(100);
        }
      }
      catch(SocketException sEx)
      {
        Console.WriteLine(sEx);
        nLogger.Warn(sEx, $"Ошибка подключения по TCP: {sEx.SocketErrorCode}");
        throw;
      }
      catch (Exception exp)
      {
        Console.WriteLine(exp);
        throw;
      }
    }

    public int Timeout
    {
      get { return _setting.Timeout; }
    }

    public bool IsOpen
    {
      get
      {
        lock (_sync)
        {
          return ((_client != null) && (_client.Connected));
        }
      }
    }

    private bool _listenerStarted = false;
    public void StartListener()
    {
      if (!IsOpen)
        throw new InvalidOperationException();
      if (_listenerStarted)
        throw new InvalidOperationException();
      NetworkStream stream = GetStream();
      _listenerStarted = true;
      BeginReadLine(stream);
    }

    public void StopListener()
    {
      if (!IsOpen)
        throw new InvalidOperationException();
      if (!_listenerStarted)
        throw new InvalidOperationException();
      _listenerStarted = false;
    }


    void BeginReadLine(NetworkStream stream)
    {
      if (stream == null) throw new ArgumentNullException(nameof(stream));
      byte[] buff = new byte[1024];
      AsyncReadState state = new AsyncReadState() { Buffer = buff, Stream = stream };
      if (!_listenerStarted)
        return;
      try
      {
        stream.BeginRead(buff, 0, buff.Length, EndReadLine, state);
      }
      catch { }
    }

    void EndReadLine(IAsyncResult ar)
    {
      AsyncReadState state = (AsyncReadState)ar.AsyncState;
      NetworkStream networkStream = state.Stream;
      int readed = 0;
      try
      {
        if (!_listenerStarted)
          return;
        readed = networkStream.EndRead(ar);
        if (readed <= 0)
          throw new SocketException(-1);
        byte[] buff = state.Buffer;
        using (MemoryStream ms = new MemoryStream(buff, 0, readed))
        {
          using (StreamReader sr = new StreamReader(ms))
          {
            //string currentLine = System.Text.ASCIIEncoding.ASCII.GetString(buff, 0, readed);// sr.ReadLine();
            //Todo добавить проверку на команду байт массива и из нее делать вилку разбора
            string currentLine = System.Text.Encoding.ASCII.GetString(buff, 0, readed);
            string[] ll = currentLine.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            //System.Diagnostics.Debug.Print("line::"+System.Text.ASCIIEncoding.ASCII.GetString(buff, 0, readed));
            if (!_listenerStarted)
              return;
            foreach (var item in ll)
            {
              /*string[] dd = item.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
              if (dd.Length > 1)
              {
                foreach (var i in dd)
                {
                  OnMessageReceived(new MessageReceivedEventArgs() { Message = i + "\r\n" });
                }
              }*/

              System.Diagnostics.Debug.Print("line::" + item);
              OnMessageReceived(new MessageReceivedEventArgs() { Message = item + "\r\n" });
            }
            
            //OnMessageReceived(new MessageReceivedEventArgs() { Message = currentLine });
          }
        }
      }
      catch (Exception ex)
      {
        string s = ex.Message;
        if (IsSocketException(ex))
        {
          //if (TryRestoreConnect())
          //{
          //  NetworkStream stream = GetStream();
          //  BeginReadLine(stream);
          //  return;
          //}
          OnLostConnect(ex);
          return;
        }
      }
      if (!_listenerStarted)
        return;
      BeginReadLine(networkStream);
    }

    bool TryRestoreConnect()
    {
      const int sleep = 500;
      int count = 0;
      do
      {
        try
        {
          Thread.CurrentThread.Join(sleep);
          Open();
          return true;
        }
        catch
        {
        }
        count++;
      } while (count < 3);
      return false;
    }
    NetworkStream GetStream()
    {
      lock (_sync)
      {
        return _client?.GetStream();
      }
    }

    bool IsSocketException(Exception e)
    {
      bool retVal = false;
      SocketException se = e as SocketException;
      if (se != null)
        return true;
      if (e.InnerException != null)
        retVal = IsSocketException(e.InnerException);
      return retVal;
    }

    class AsyncReadState
    {
      public NetworkStream Stream { get; set; }
      public byte[] Buffer { get; set; }
    }

    protected virtual void OnMessageReceived(MessageReceivedEventArgs e)
    {
      try
      {
        MessageReceived?.Invoke(this, e);
      }
      catch
      {
      }
    }

    private void AssertOpen()
    {
      if (!IsOpen) throw new InvalidOperationException("TCP порт закрыт");
    }



    public object Tag { get; set; }

    public event EventHandler<LostConnectEventArgs> LostConnect;

    protected virtual void OnLostConnect(Exception error)
    {
      try
      {
        LostConnect?.Invoke(this, new LostConnectEventArgs() { Error = error });
      }
      catch
      {
        throw new InvalidOperationException("TCP lost conn error");
      }
    }
  }



}