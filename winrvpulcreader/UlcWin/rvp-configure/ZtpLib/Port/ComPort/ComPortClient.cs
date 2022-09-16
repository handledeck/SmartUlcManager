
using System;
using System.IO.Ports;
using Ztp.IO.Logger;

namespace Ztp.Port.ComPort
{
  public class ComPortClient : IODriverClient
  {
    private readonly ILog _log;
    private SerialPort _serialPort = null;
    private const int DefaultReadTimeout = 1000;
    private const int DefaultWriteTimeout = 1000;

    private readonly ComPortSettings _settings;

    private object sync = new object();

    public override string DisplayName
    {
      get { return _settings.ToDisplay(); }
    }
    public ComPortClient(ComPortSettings settings)
      : this(settings, NullLog.Null)
    {
    }
    public ComPortClient(ComPortSettings settings, ILog log)
    {
      if (settings == null)
        throw new ArgumentNullException();
      if (log == null) throw new ArgumentNullException(nameof(log));
      _log = log;
      _settings = settings;
    }

    public override void Close()
    {
      if (_serialPort == null) return;
      lock (sync)
      {
        try
        {
          _serialPort.Close();
        }
        catch
        {
        }
        try
        {
          _serialPort.Dispose();
        }
        catch
        {
        }
        finally
        {
          _serialPort = null;
        }
      }
    }

    public override void DiscardInBuffer()
    {
      AssertOpen();
      _serialPort.DiscardInBuffer();
    }

    public override void DiscardOutBuffer()
    {
      AssertOpen();
      _serialPort.DiscardOutBuffer();
    }

    public override bool IsOpen
    {
      get
      {
        bool result = false;
        lock (sync)
        {
          result = ((_serialPort != null) && (_serialPort.IsOpen));
        }
        return result;
      }
    }

    private void AssertOpen()
    {
      if (!IsOpen) throw new InvalidOperationException("SerialPort закрыт");
    }

    public override void Open()
    {
      try
      {
        Open(true);
      }
      catch (Exception e)
      {
        _log.Error(e);
        throw;
      }
    }

    private void Open(bool isThrow)
    {
      try
      {
        lock (sync)
        {
          if (_serialPort != null)
          {
            Close();
          }
          _serialPort = new SerialPort(_settings.PortName, _settings.BaudRate, (System.IO.Ports.Parity)_settings.Parity,
             _settings.DataBits, (System.IO.Ports.StopBits)_settings.StopBits);
          _serialPort.ReadTimeout = readTimeout = _settings.ReadTimeout;
          _serialPort.WriteTimeout = writeTimeout = _settings.WriteTimeout;
          _serialPort.Open();
        }
      }
      catch (Exception e)
      {
        Close();
        if (isThrow) throw new InvalidOperationException(e.Message);
      }
    }

    private void SetHandshake(Handshake val)
    {
      HandshakeWin.SetHandshake(val, _serialPort);
    }

    private int ReadAll(byte[] buffer, int offset, int count)
    {
      int retVal = 0;
      while (true)
      {
        int len = _serialPort.Read(buffer, offset, count);
        retVal += len;
        if (len == 0 || buffer[len - 1] == 13 || buffer[len - 1] == 10)
          break;
      }
      return retVal;
    }

    public override string ReadDebug()
    {
      return _serialPort.ReadLine();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      AssertOpen();
      int result = ReadAll(buffer, offset, count);
      return result;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      AssertOpen();
      _serialPort.Write(buffer, offset, count);
    }

    public override int ReadByte()
    {
      int result = 0;

      try
      {
        AssertOpen();
        result = _serialPort.ReadByte();
      }
      catch (Exception e)
      {
        _log.Error(e);
        throw;
      }

      return result;
    }

    int readTimeout = DefaultReadTimeout;
    public override int ReadTimeout
    {
      get { return readTimeout; }
      set
      {
        try
        {
          if (IsOpen)
          {
            _serialPort.ReadTimeout = value;
          }
          readTimeout = value;
        }
        catch
        {
          throw;
        }
      }
    }

    int writeTimeout = DefaultWriteTimeout;
    public override int WriteTimeout
    {
      get { return writeTimeout; }
      set
      {
        try
        {
          if (IsOpen)
          {
            _serialPort.WriteTimeout = value;
          }
          writeTimeout = value;
        }
        catch
        {
          throw;
        }
      }
    }
  }
}
