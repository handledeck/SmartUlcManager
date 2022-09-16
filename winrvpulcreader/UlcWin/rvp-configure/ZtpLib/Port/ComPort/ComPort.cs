using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using Ztp.IO.Logger;

namespace Ztp.Port.ComPort
{
  public class ComPort : IPort
  {
    readonly object _sync = new object();
    private SerialPort _serialPort;
    private readonly ComPortSettings _setting;
    private readonly ILog _log;
    public event MessageReceivedEventHandler MessageReceived;
    public event EventHandler<LostConnectEventArgs> LostConnect;

    public ComPort(IPortSetting setting)
      :this(setting, NullLog.Null)
    {
    }

    public ComPort(IPortSetting setting, ILog log)
    {
      if (log == null) throw new ArgumentNullException(nameof(log));
      _log = log;
      ComPortSettings sett = setting as ComPortSettings;
      if (sett == null) throw new ArgumentNullException(nameof(setting));
      _setting = sett;
    }

    public int Timeout
    {
      get { return _setting.Timeout; }
    }

    public string DisplayName
    {
      get { return _setting.ToDisplay(); }
    }

    public void Write(byte[] buffer, int offset, int count)
    {
      AssertOpen();
      _serialPort.Write(buffer, offset, count);
    }

    public void Close()
    {
      if (_serialPort == null) return;
      lock (_sync)
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


    protected virtual void OnDisconnected(Exception error)
    {
      try
      {
        LostConnect?.Invoke(this, new LostConnectEventArgs() { Error = error });
      }
      catch
      {
      }
    }

    public void DiscardInBuffer()
    {
      AssertOpen();
      _serialPort.DiscardInBuffer();
    }

    public void DiscardOutBuffer()
    {
      AssertOpen();
      _serialPort.DiscardOutBuffer();
    }

    public void Open()
    {
      lock (_sync)
      {
        if (_serialPort != null)
        {
          Close();
        }
        _serialPort = new SerialPort(_setting.PortName, _setting.BaudRate, (System.IO.Ports.Parity)_setting.Parity,
           _setting.DataBits, (System.IO.Ports.StopBits)_setting.StopBits);
        _serialPort.ReadTimeout = _setting.Timeout;
        _serialPort.WriteTimeout = _setting.Timeout;
        _serialPort.DtrEnable = true; //XXX
        _serialPort.Handshake = System.IO.Ports.Handshake.None;
        _serialPort.RtsEnable = true;
        _serialPort.DiscardNull = false;
        _serialPort.WriteBufferSize = 1024;
        _serialPort.ReadBufferSize = 1024;
        //_serialPort.ParityReplace = 0;
        _serialPort.Open();
      }
    }

    public bool IsOpen
    {
      get
      {
        lock (_sync)
        {
          return ((_serialPort != null) && (_serialPort.IsOpen));
        }
      }
    }

    public void StartListener()
    {
      if(!IsOpen)
        throw new InvalidOperationException();
      _serialPort.DataReceived += _serialPort_DataReceived;
    }

    public void StopListener()
    {
      if (!IsOpen)
        throw new InvalidOperationException();
      _serialPort.DataReceived -= _serialPort_DataReceived;
    }

    private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      byte[] buff = new byte[1024];
      int size = ((SerialPort)sender).BytesToRead;
      ((SerialPort)sender).Read(buff, 0, size);
      //Todo Добавить вилку на разбор типа пакета
      string currentLine = System.Text.Encoding.ASCII.GetString(buff, 0, size);
      string[] ll = currentLine.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
      foreach (var item in ll)
      {
        System.Diagnostics.Debug.Print("line::" + item);
        OnMessageReceived(new MessageReceivedEventArgs() { Message = item + "\r\n" });
      }
    }

    protected virtual void OnMessageReceived(MessageReceivedEventArgs e)
    {
      MessageReceived?.Invoke(this, e);
    }

    private void AssertOpen()
    {
      if (!IsOpen) throw new InvalidOperationException("SerialPort закрыт");
    }

  }
}
