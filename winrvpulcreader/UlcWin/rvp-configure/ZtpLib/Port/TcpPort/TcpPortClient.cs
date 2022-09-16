using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using Ztp.IO;
using Ztp.IO.Logger;
using Ztp.Protocol;

namespace Ztp.Port.TcpPort
{
  public class TcpPortClient : IODriverClient
  {
    private Socket socket;
    private const int DefaultReadTimeout = 5000;
    private const int DefaultWriteTimeout = 5000;

    private TcpPortSettings _setting;
    private ILog _log;
    private static int AfterOpen = 0;

    static TcpPortClient()
    {
      var fineTune = FineTune.TryLoad("tcpport");
      AfterOpen = fineTune.ReadValue("afteropen", (v) => Int32.Parse(v), 0);
    }

    public TcpPortClient(IPortSetting setting)
      : this(setting, NullLog.Null)
    {
    }

    public TcpPortClient(IPortSetting setting, ILog log)
    {
      if (log == null) throw new ArgumentNullException(nameof(log));
      _log = log;
      TcpPortSettings s = setting as TcpPortSettings;
      if (s == null)
        throw new ArgumentException(nameof(setting));
      this._setting = s;
    }

    private object sync = new object();

    public override void Close()
    {
      lock (sync)
      {
        if (socket != null)
        {
          try
          {
            socket.Close();
          }
          catch
          {
          }
          finally
          {
            socket = null;
          }
        }
      }
    }

    private uint CountReadBuffer
    {
      get
      {
        AssertOpen();
        uint bytesAvailable = 0;
        try
        {
          bytesAvailable = (uint)socket.Available;
        }
        catch (Exception exp)
        {
          _log.Error($"TcpChanel.CountReadBuffer:{exp.Message}");
          bytesAvailable = 0;
        }
        return bytesAvailable;
      }
    }

    public override void DiscardInBuffer()
    {
      AssertOpen();
      uint countReadBuffer = CountReadBuffer;
      if (countReadBuffer != 0)
      {
        byte[] outValue = new byte[countReadBuffer];
        try
        {
          Read(outValue, 0, outValue.Length);
        }
        catch (Exception exp)
        {
          _log.Error($"TcpChanel.DiscardInBuffer:{exp.Message}");
          throw;
        }
      }
    }

    public override void DiscardOutBuffer()
    {
    }

    public override bool IsOpen
    {
      get
      {
        bool result = false;
        lock (sync)
        {
          result = ((socket != null) && (socket.Connected));
        }
        return result;
      }
    }

    private void AssertOpen()
    {
      if (!IsOpen) throw new InvalidOperationException($"Ошибка открытия TCP порта {_setting.ToDisplay()}");
    }

    public override void Open()
    {
      Open(true);
    }

    private void Open(bool isThrow)
    {
      try
      {
        lock (sync)
        {
          if (socket != null)
          {
            Close();
          }

          TcpClient tcp = new TcpClient();
          tcp.ReceiveTimeout = _setting.ReadTimeout;
          tcp.SendTimeout = _setting.WriteTimeout;
          tcp.Connect(_setting.IpAddress, (int)_setting.Port);
          if (AfterOpen != 0) Thread.Sleep(AfterOpen);
          socket = tcp.Client;
        }
      }
      catch (Exception exp)
      {
        _log.Error($"TcpChanel.ErrorOpen:{exp.Message}");
        Close();
        if (isThrow) throw new InvalidOperationException($"Ошибка открытия TCP порта {_setting.ToDisplay()}", exp);
      }
    }

    public override string ReadDebug()
    {
      byte[] buff = new byte[512];
      int readed = Read(buff, 0, buff.Length);
      using (MemoryStream ms = new MemoryStream(readed))
      {
        ms.Write(buff, 0, buff.Length);
        return ZtpProtocol.FromBytes(ms.ToArray());
      }
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      int retVal = 0;
      try
      {
        AssertOpen();
        while (true)
        {
          var result = socket.Receive(buffer, offset, count, SocketFlags.None);
          retVal += result;
          if (result == 0 || buffer[result - 1] == 13 || buffer[result - 1] == 10)
            break;
        }
      }
      catch (SocketException se)
      {
        if (se.SocketErrorCode == SocketError.TimedOut) throw new TimeoutException();
        throw;
      }
      return retVal;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      AssertOpen();
      int realWrite = 0;
      while (count > realWrite)
      {
        realWrite += socket.Send(buffer, realWrite + offset, count - realWrite, SocketFlags.None);
        if (count > realWrite) System.Threading.Thread.Sleep(0);
      }
    }

    /// <summary>
    /// Из за того что очень медленно работает таймаут сокета при чтении приходится придумывать механизмы
    /// </summary>
    private void WaitingReadBytes(int count)
    {
      var s = SpanSnapshot.Now;
      while (true)
      {
        if (s.DiffNowMsec() < this.ReadTimeout)
        {
          if (socket.Available < count) Thread.Sleep(20);
          else break;
        }
        else throw new TimeoutException();
      }
    }

    public override int ReadByte()
    {
      int result;
      try
      {
        AssertOpen();
        WaitingReadBytes(1);
        byte[] buf = new byte[1];
        result = Read(buf, 0, 1);
        if (result == 0) result = -1;
        else result = buf[0];
      }
      catch (SocketException se)
      {
        if (se.SocketErrorCode == SocketError.TimedOut) throw new TimeoutException();
        throw;
      }
      return result;
    }

    public override int ReadTimeout
    {
      get
      {
        AssertOpen();
        return socket.ReceiveTimeout;
      }
      set
      {
        if (IsOpen)
        {
          socket.ReceiveTimeout = value;
        }
      }
    }

    public override int WriteTimeout
    {
      get
      {
        AssertOpen();
        return socket.SendTimeout;
      }
      set
      {
        if (IsOpen)
        {
          socket.SendTimeout = value;
        }
      }
    }

    public override string DisplayName
    {
      get { return _setting.ToDisplay(); }
    }

  }
}
