//#define TEST

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using Ztp.Configuration;
using Ztp.IO.Logger;
using Ztp.Port;
using Ztp.Port.ComPort;
using Ztp.Port.TcpPort;
using Ztp.Protocol.Event;

namespace Ztp.Protocol
{
  public class ZtpProtocolDriver
  {
    public static IOperationHistorian Historian;

    private readonly IPort _port;
    private ILog _log;
    public readonly PortKind Kind;

    public ZtpProtocolDriver(ILog log, PortKind kind, Func<ComPortSettings> comPortSettings, Func<TcpPortSettings> tcpPortSettings)
    {
      if (log == null) throw new ArgumentNullException(nameof(log));
      _log = log;
      _port = PortManager.GetPort(log, kind, comPortSettings, tcpPortSettings);
      _port.MessageReceived += _port_MessageReceived;
      Kind = kind;
#if TEST
      string fileName = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
      fileName = Path.Combine(fileName, "_ztpProtocolDriver.log");
      _fileLog = new FileLog(fileName, true);
#endif
    }

#if TEST
    private FileLog _fileLog;
#endif

#if TEST
    void Trace(string message, params object[] args)
    {
      _fileLog.Info(message, args);
  }
#endif

    public event MessageReceivedEventHandler DebugReceived;
    internal event MessageReceivedEventHandler AnswerReceived;

    public string SessionPassword { get; set; }

    public void Close()
    {
      _port.Close();
      _port.LostConnect -= _port_Disconnected;
    }

    public void Open()
    {
      _port.Open();
      _port.LostConnect += _port_Disconnected;
      SessionPassword = null;
    }

    private void _port_Disconnected(object sender, LostConnectEventArgs e)
    {
      OnDisconnected(e);
    }

    public event EventHandler<LostConnectEventArgs> Disconnected;
    protected virtual void OnDisconnected(LostConnectEventArgs e)
    {
      Disconnected?.Invoke(this, e);
    }

    public bool IsOpen
    {
      get { return _port.IsOpen; }
    }

    public void DiscardInBuffer()
    {
      _port.DiscardInBuffer();
    }

    public void DiscardOutBuffer()
    {
      _port.DiscardOutBuffer();
    }

    public void StartListener()
    {
      _port.StartListener();
    }

    public void StopListener()
    {
      _port.StopListener();
    }

    public string DisplayName
    {
      get { return _port.DisplayName; }
    }

    public WritePwdAnswer WriteUpgrade()
    {
      _log.Info("Инициализация обновления ПО");
      string command = ZtpProtocol.SetUpgradeCommand(SessionPassword);
      string answer = WriteWaitMessage(Action.Upgrade, command);
      WritePwdAnswer retVal = ZtpProtocol.DeserializePwdAnswer(answer);
      Historian?.Write(Tag, OpHistoryCode.IF, command, null, retVal.DisplayMessage, !retVal.IsOk);
      return retVal;
    }

    public WritePwdAnswer DropLogs()
    {
      _log.Info("Откат к старой версии [удаление логов]");
      string command = ZtpProtocol.DropLogsCommand();
      string answer = WriteWaitMessage(Action.Upgrade, command);
      WritePwdAnswer retVal = ZtpProtocol.DeserializePwdAnswer(answer);
      Historian?.Write(Tag, OpHistoryCode.IF, command, null, retVal.DisplayMessage, !retVal.IsOk);
      return retVal;
    }

    public WritePwdAnswer StartUploadService()
    {
      _log.Info("Запуск службы загрузки файлов на устройстве");
      string command = ZtpProtocol.StartUpServCommand(SessionPassword);
      string answer = WriteWaitMessage(Action.Upgrade, command);
      WritePwdAnswer retVal = ZtpProtocol.DeserializePwdAnswer(answer);
      return retVal;
    }

    public string GetCoreVersion()
    {
      _log.Info("Проверка версии ядра устройства");
      string command = ZtpProtocol.GetCoreVerCmd();
      string answer = WriteWaitMessage(Action.Upgrade, command);
      WritePwdAnswer retVal = ZtpProtocol.DeserializePwdAnswer(answer);
      return retVal.PwdResult;
    }

    public string GetVersionPO()
    {
      _log.Info("Проверка версии ПО устройства");
      string command = ZtpProtocol.GetVersionCmd();
      string answer = WriteWaitMessage(Action.TestVersion, command);
      WritePwdAnswer retVal = ZtpProtocol.DeserializeVersionAnswer(answer);
      return retVal.PwdResult;
    }

    public WritePwdAnswer SendFilename(string filename)
    {
      _log.Info("Передача названия файла");
      string command = ZtpProtocol.SendFilenameCommand(filename);
      string answer = WriteWaitMessage(Action.Upgrade, command);
      WritePwdAnswer retVal = ZtpProtocol.DeserializePwdAnswer(answer);
      return retVal;
    }

    public WritePwdAnswer WriteReboot()
    {
      _log.Info("Перезапуск устройства");
      string command = ZtpProtocol.RebootCommand(SessionPassword);
      string answer = WriteWaitMessage(Action.Reboot, command);
      WritePwdAnswer retVal = ZtpProtocol.DeserializePwdAnswer(answer);
      Historian?.Write(Tag, OpHistoryCode.R, command, null, retVal.DisplayMessage, !retVal.IsOk);
      return retVal;
    }

    public WritePwdAnswer WriteSetPassword(string newPwd)
    {
      _log.Info("Установка пароля");
      string command = ZtpProtocol.SetPasswordCommand(SessionPassword, newPwd);
      string answer = WriteWaitMessage(Action.SetPassword, command);

      WritePwdAnswer retVal = ZtpProtocol.DeserializePwdAnswer(answer);
      Historian?.Write(Tag, OpHistoryCode.P, command, null, retVal.DisplayMessage, !retVal.IsOk);
      return retVal;
    }

    //------------ Запись конфигурации модбас
    public string WriteModbusConfig(byte[] dat, ushort size)
    {
      _log.Info("Запись конфигурации модбас");
      string retVal = string.Empty;
      byte[] pack = ZtpProtocol.ModbusSetConfig(SessionPassword, dat, size);
      MessageReceivedEventHandler onMessage = (s, m) =>
      {
        Debug($"Result={TrimNewLine(m.Message)}");
        retVal = m.Message;
      };
      AnswerReceived += onMessage;
      try
      {
        WriteWaitAnswer(Action.WriteModbusConfig, pack);
      }
      finally
      {
        AnswerReceived -= onMessage;
      }
      return retVal;
    }

    public byte[] ReadModbusConfig()
    {
      byte[] pack = null;
      _log.Info("Чтение конфигурации модбас");
#if TEST
      Trace("============================================");
      Trace("Чтение конфигурации");
      Trace("============================================");
#endif
      string command = ZtpProtocol.GetModbusConfig();
      Debug($"Command={TrimNewLine(command)}");
      byte[] buff = ZtpProtocol.ToBytes(command);
      ReadConfigAnswer retVal = new ReadConfigAnswer();
      MessageReceivedEventHandler onMessage = (s, m) =>
      {
        Debug($"Result={TrimNewLine(m.Message)}");
        try
        {
          string[] keyValue = m.Message.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

          byte[] buf = Convert.FromBase64String(keyValue[1]);
          pack = buf;
        }
        catch (Exception e)
        {
          retVal.Error = e;
        }
      };
      AnswerReceived += onMessage;
      try
      {
        WriteWaitAnswer(Action.ReadModbusConfig, buff);
      }
      catch (Exception e)
      {
        retVal.Error = e;
      }
      finally
      {
        AnswerReceived -= onMessage;
      }
      return pack;
    }

    public string WriteMBLabels(string input)
    {
      _log.Info("Запись списка описаний тегов");
      string retVal = string.Empty;

      string command = ZtpProtocol.ModbusSetLBL(SessionPassword, input);
      string answer = WriteWaitMessage(Action.WriteModbusLabels, command);
      return retVal;
    }

    public string ReadMBLabels()
    {
      _log.Info("Чтение списка меток модбас");
      string result = string.Empty;
      string command = ZtpProtocol.ModbusGetLBL();

      ReadConfigAnswer retVal = new ReadConfigAnswer();
      try
      {
        string[] keyValue = WriteWaitMessage(Action.ReadModbusLabels, command).Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

        result = keyValue[keyValue.Length-1];
      }
      catch(Exception ex)
      {
        throw ex;
      }

      return result;
    }

      //---------------------
    public WritePwdAnswer WriteConfig(ZtpConfig config)
    {
      if (config == null) throw new ArgumentNullException(nameof(config));
      WriteConfigLogPrivate();
      string command = ZtpProtocol.SetConfigCommand(SessionPassword, config);

      WritePwdAnswer retVal = WriteConfigPrivate(command);
      Historian?.Write(Tag, OpHistoryCode.W, command, config.ToText(), retVal.DisplayMessage, !retVal.IsOk);
      return retVal;
    }

    void WriteConfigLogPrivate()
    {
      _log.Info("Запись конфигурации");
#if TEST
      Trace("============================================");
      Trace("Запись конфигурации");
      Trace("============================================");
#endif
    }

    WritePwdAnswer WriteConfigPrivate(string command)
    {
      string answer = WriteWaitMessage(Action.WriteConfig, command);
#if TEST
      Trace(answer);
#endif
      return ZtpProtocol.DeserializePwdAnswer(answer);
    }


    string WriteWaitMessage(Action action, string command)
    {
      Debug($"Command={TrimNewLine(command)}");
      byte[] buff = ZtpProtocol.ToBytes(command);
      string retVal = string.Empty;
      MessageReceivedEventHandler onMessage = (s, m) =>
      {
        Debug($"Result={TrimNewLine(m.Message)}");
        retVal = m.Message;
      };
      AnswerReceived += onMessage;
      try
      {
        WriteWaitAnswer(action, buff);
      }
      finally
      {
        AnswerReceived -= onMessage;
      }
      return retVal;
    }

    public WritePwdAnswer WriteLightOnOff(bool switchOn)
    {
      _log.Info(switchOn ? "Включение освещения" : "Выключение освещения");
#if TEST
      Trace("============================================");
      Trace(switchOn ? "Включение освещения" : "Выключение освещения");
      Trace("============================================");
#endif

      string command = ZtpProtocol.LightSwitchOnOffCommand(SessionPassword, switchOn);
      Debug($"Command={TrimNewLine(command)}");
      byte[] buff = ZtpProtocol.ToBytes(command);
      WritePwdAnswer retVal = new WritePwdAnswer();
      MessageReceivedEventHandler onMessage = (s, m) =>
      {
        Debug($"Result={TrimNewLine(m.Message)}");
        retVal = ZtpProtocol.DeserializePwdAnswer(m.Message);
      };
      AnswerReceived += onMessage;
      try
      {
        WriteWaitAnswer(Action.SwitchOnOff, buff);
      }
      finally
      {
        AnswerReceived -= onMessage;
      }
      Historian?.Write(Tag, OpHistoryCode.L, command, null, retVal.DisplayMessage, !retVal.IsOk);
      return retVal;
    }


    public ReadConfigAnswer ReadConfig()
    {
      _log.Info("Чтение конфигурации");
#if TEST
      Trace("============================================");
      Trace("Чтение конфигурации");
      Trace("============================================");
#endif
      string command = ZtpProtocol.GetConfigCommand();
      Debug($"Command={TrimNewLine(command)}");
      byte[] buff = ZtpProtocol.ToBytes(command);
      ReadConfigAnswer retVal = new ReadConfigAnswer();
      MessageReceivedEventHandler onMessage = (s, m) =>
      {
        Debug($"Result={TrimNewLine(m.Message)}");
        try
        {
          retVal.Config = ZtpProtocol.DeserializeZtpConfig(m.Message);
        }
        catch (Exception e)
        {
          retVal.Error = e;
        }
      };
      AnswerReceived += onMessage;
      try
      {
        WriteWaitAnswer(Action.ReadConfig, buff);
      }
      catch (Exception e)
      {
        retVal.Error = e;
      }
      finally
      {
        AnswerReceived -= onMessage;
      }
      return retVal;
    }

    public string TestPing(string ip)
    {
      _log.Info($"Тест связи устройством с IP {ip}");
      //string result = string.Empty;
      string command = ZtpProtocol.CheckPingIp(ip);

      string answer = WriteWaitMessage(Action.TestPing, command);
      return answer;
    }

    public string BrightToggle()
    {
      _log.Info($"Изменение яркости");
      //string result = string.Empty;
      string command = ZtpProtocol.BrightToggle();

      string answer = WriteWaitMessage(Action.BrightToggle, command);
      return answer;
    }

    public string GetCurTrafic()
    {
      _log.Info($"Чтение общего трафика");
      string command = ZtpProtocol.GetCurTrafic();

      string answer = WriteWaitMessage(Action.GetTraffic, command);
      return answer;
    }

    public void Write(byte[] buffer, int offset, int count)
    {
      _port.Write(buffer, offset, count);
    }

    public void WriteWaitAnswer(Action action, byte[] buffer)
    {
      if (buffer == null) throw new ArgumentNullException(nameof(buffer));
      _portAnswer?.Dispose();
      _portAnswer = new PortAnswer(action);
#if TEST
      Debug("Write to port: {0}", BytesToString(buffer));
#endif
      _port.Write(buffer, 0, buffer.Length);
      try
      {
        if (!_portAnswer.Mre.Wait(_port.Timeout))
        {
          throw new TimeoutException($"Превышение времени ожидания ответа ({_port.Timeout} мсек.)");
        }
      }
      finally 
      {
        _portAnswer?.Dispose();
        _portAnswer = null;
      }
    }

    public event ChangeStateEventHandler ChangeState;

    protected virtual void OnChangeState(string str)
    {
      if(string.IsNullOrEmpty(str))
        return;
      ZtpEvent evt = ZtpEvent.Parse(str);
      if(evt == null)
        return;
      ChangeState?.Invoke(evt);
    }


    private void _port_MessageReceived(object sender, MessageReceivedEventArgs e)
    {
      string answer = e.Message;
#if TEST
      Debug($"MESSAGE: {answer}");
#endif
      string suffix;
      switch (_portAnswer?.Action)
      {
        case Action.WriteConfig:
        case Action.WriteModbusConfig:
        case Action.Reboot:
        case Action.Upgrade:
        case Action.SetPassword:
        case Action.SwitchOnOff:
        case Action.WriteModbusLabels:
          suffix = $"{ZtpProtocol.Password}{ZtpProtocol.Sep}";
          break;
        case Action.ReadConfig:
          suffix = $"{ZtpProtocol.Config}{ZtpProtocol.Sep}";
          break;
        case Action.ReadModbusConfig:
          suffix = $"{ZtpProtocol.MBConfig}{ZtpProtocol.Sep}";
          break;
        case Action.ReadModbusLabels:
          suffix = $"{ZtpProtocol.MBLbl}{ZtpProtocol.Sep}";
          break;
        case Action.TestPing:
          suffix = $"{ZtpProtocol.TestPingIp}{ZtpProtocol.Sep}";
          break;
        case Action.BrightToggle:
          suffix = $"{ZtpProtocol.Light}{ZtpProtocol.Sep}";
          break;
        case Action.GetTraffic:
          suffix = $"TR{ZtpProtocol.Sep}";
          break;
        case Action.TestVersion:
          suffix = $"CURRENT";
          break;
        default:
          suffix = $"{ZtpProtocol.Event}{ZtpProtocol.Sep}";
          break;
      }
#if TEST
      Trace("_port_MessageReceived");
      Trace($"{nameof(answer)}={answer}, {nameof(suffix)}={suffix}");
#endif
      int pos = answer.IndexOf("\r" + suffix, StringComparison.Ordinal);
      if (pos == -1)
        pos = answer.IndexOf("\n" + suffix, StringComparison.Ordinal);
      if (pos != -1)
      {
        if (pos == 0)
          goto returnAnswer;

        OnDebugReceived(new MessageReceivedEventArgs() { Message = ZtpProtocol.NormalizeDebugString(answer.Substring(0, pos + 1)) });
        answer = answer.Remove(0, pos + 1);
      }
      else
      {
        pos = answer.IndexOf(suffix, StringComparison.Ordinal);
        if (pos < 0)
        {
          OnDebugReceived(new MessageReceivedEventArgs() { Message = ZtpProtocol.NormalizeDebugString(answer) });
          answer = "";
        }
      }

      returnAnswer:
      if (suffix == $"{ZtpProtocol.Event}{ZtpProtocol.Sep}")
      {
        OnDebugReceived(new MessageReceivedEventArgs() { Message = ZtpProtocol.NormalizeDebugString(answer), IsEvent = true });
        OnChangeState(answer);
      }
      else
      if (!_portAnswer?.Mre?.IsSet ?? true)
      {
        if (!string.IsNullOrEmpty(answer))
        {
          OnMessageReceived(new MessageReceivedEventArgs() { Message = ZtpProtocol.NormalizeDebugString(answer) });
          _portAnswer?.Mre?.Set();
        }
      }
    }

    protected virtual void OnMessageReceived(MessageReceivedEventArgs e)
    {
      AnswerReceived?.Invoke(this, e);
    }

    protected virtual void OnDebugReceived(MessageReceivedEventArgs e)
    {
      DebugReceived?.Invoke(this, e);
    }

    static string TrimNewLine(string text)
    {
      return text?.Trim('\r', '\n');
    }
    
    private PortAnswer _portAnswer;
    class PortAnswer : IDisposable
    {
      public readonly ManualResetEventSlim Mre = new ManualResetEventSlim(false);
      public readonly Action Action;

      public PortAnswer(Action action)
      {
        Action = action;
      }

      public void Dispose()
      {
        Mre?.Dispose();
      }
    }

    public enum Action
    {
      ReadConfig,
      WriteConfig,
      Reboot,
      SwitchOnOff,
      SetPassword,
      Upgrade,
      WriteModbusConfig,
      ReadModbusConfig,
      WriteModbusLabels,
      ReadModbusLabels,
      TestPing,
      BrightToggle,
      GetTraffic,
      TestVersion
    }

#if TEST
    string BytesToString(byte[] buff)
    {
      StringBuilder sb = new StringBuilder();
      if (buff != null)
      {
        for (int i = 0; i < buff.Length; i++)
        {
          if (i > 0)
            sb.Append(",");
          sb.Append(buff[i]);
        }
      }
      return sb.ToString();
    }
#endif
    void Debug(string format, params object[] arg)
    {
#if TEST
      Trace(_port.DisplayName + $" [{(_port.IsOpen ? "Open" : "Close")}] " + format, arg);
#endif
      System.Diagnostics.Debug.WriteLine(format, arg);
      _log.Info(format, arg);
    }

    public int Tag { get; set; }

  }
}
