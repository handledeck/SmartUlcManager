using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Ztp;
using Ztp.Configuration;
using Ztp.IO.Logger;
using Ztp.Port;
using Ztp.Port.TcpPort;
using Ztp.Protocol;
using Ztp.Ui;
using Ztp.Utils;
using ZtpManager.Scope;

namespace ZtpManager.DeviceAccessLayer
{
  public class DevAl
  {
    PortDictionary _ports = new PortDictionary();
    DevAl()
    {
    }

    private static DevAl _default;

    public static DevAl Default
    {
      get
      {
        if (_default == null)
        {
          _default = new DevAl();
        }
        return _default;
      }
    }

    public object GetActionResultForDevice(DeviceActionResult result, int deviceId)
    {
      object retVal = null;
      if (result == null) throw new ArgumentNullException(nameof(result));
      if (result.Values != null)
      {
        foreach (ActionResult res in result.Values)
        {
          if (res.DeviceId == deviceId)
          {
            retVal = res.Value;
            break;
          }
        }
      }
      return retVal;
    }

    string GetCaption(DeviceActionMode mode)
    {
      switch (mode)
      {
        case DeviceActionMode.Read:
          return "Чтение конфигурации";
        case DeviceActionMode.Reboot:
          return "Перезапуск";
        case DeviceActionMode.SetPwd:
          return "Смена пароля";
        case DeviceActionMode.Switch:
          return "Включение/Отключение освещения";
        case DeviceActionMode.Write:
          return "Запись конфигурации";
        case DeviceActionMode.TestCore:
          return "Проверка версий ядра";
        case DeviceActionMode.TestVersion:
          return "Проверка версий ПО";
        default:
          throw new ArgumentException(nameof(mode));
      }
    }
    public void ActionReadConfig(IWin32Window owner, DeviceActionArg arg, Action<DeviceActionResult> actionComplete)
    {

      if (arg.Mode != DeviceActionMode.Read)
        throw new ArgumentException(nameof(arg.Mode));
      ActionAsync(owner, arg, actionComplete);
    }

    public void ActionWriteReboot(IWin32Window owner, DeviceActionArg arg, Action<DeviceActionResult> actionComplete)
    {
      if (arg.Mode != DeviceActionMode.Reboot)
        throw new ArgumentException(nameof(arg.Mode));
      ActionAsync(owner, arg, actionComplete);
    }

    public void ActionWriteSetPassword(IWin32Window owner, DeviceActionArg arg, Action<DeviceActionResult> actionComplete)
    {
      if (arg.Mode != DeviceActionMode.SetPwd)
        throw new ArgumentException(nameof(arg.Mode));
      ActionAsync(owner, arg, actionComplete);
    }

    public void ActionWriteSwitchOnOff(IWin32Window owner, DeviceActionArg arg, Action<DeviceActionResult> actionComplete)
    {
      if (arg.Mode != DeviceActionMode.Switch)
        throw new ArgumentException(nameof(arg.Mode));
      ActionAsync(owner, arg, actionComplete);
    }

    public void ActionWriteConfig(IWin32Window owner, DeviceActionArg arg, Action<DeviceActionResult> actionComplete)
    {
      if (arg.Mode != DeviceActionMode.Write)
        throw new ArgumentException(nameof(arg.Mode));
      ActionAsync(owner, arg, actionComplete);
    }

    public void ActionCheckCore(IWin32Window owner, DeviceActionArg arg, Action<DeviceActionResult> actionComplete)
    {
      if (arg.Mode != DeviceActionMode.TestCore)
        throw new ArgumentException(nameof(arg.Mode));
      ActionAsync(owner, arg, actionComplete);
    }

    public void ActionCheckVersion(IWin32Window owner, DeviceActionArg arg, Action<DeviceActionResult> actionComplete)
    {
      if (arg.Mode != DeviceActionMode.TestVersion)
        throw new ArgumentException(nameof(arg.Mode));
      ActionAsync(owner, arg, actionComplete);
    }

    /// <summary>
    /// Возвращает открытый сохраняемый порт доступа к устройству. При ошибке открытия порта генерируется ошибка.
    /// </summary>
    /// <returns>
    /// Если операция закончилась успешно - возвращается ZtpProtocolDriver, иначе возвращаеься объект ошибки
    /// </returns>
    public object GetOrCreateDriver(string name, IWin32Window owner, ILog log, int driverId, Func<int, TcpPortSettings> readSetingFunc)
    {
      if (readSetingFunc == null) throw new ArgumentNullException(nameof(readSetingFunc));
      object retVal = null;
      WaitForm waitForm = new WaitForm($"Открытие порта {name}",
        (s, a) =>
        {
          List<ZtpProtocolDriver> prepareDrivers = PrepareDrivers(log, new[] { driverId }, readSetingFunc);
          ZtpProtocolDriver driver = prepareDrivers[0];
          driver.Open();
          driver.StartListener();
          a.Result = driver;
        },
        (sender, a) =>
        {
          if (a.Error != null)
          {
            _ports.Remove(driverId);
            retVal = a.Error;
          }
          else
            retVal = (ZtpProtocolDriver)a.Result;
        });
      waitForm.ShowDialog(owner);

      return retVal;
    }

    public void RemoveDriver(int driverId)
    {
      _ports.Remove(driverId);
    }

    #region PRIVATE

    void StartAction(object obj)
    {
      OneActionArg arg = (OneActionArg)obj;
      bool opened = arg.Driver.IsOpen;
      try
      {
        if (!opened)
        {
          arg.Driver.Open();
          arg.Driver.StartListener();
        }
        arg.Driver.SessionPassword = arg.SessionPassword;
        switch (arg.ActionMode)
        {
          case DeviceActionMode.Read:
            ReadConfigAnswer readConfig = arg.Driver.ReadConfig();
            arg.Result.Value = readConfig;
            break;
          case DeviceActionMode.Reboot:
            WritePwdAnswer reboot = arg.Driver.WriteReboot();
            arg.Result.Value = reboot;
            break;
          case DeviceActionMode.SetPwd:
            WritePwdAnswer writePwd = arg.Driver.WriteSetPassword(arg.NewPassword);
            arg.Result.Value = writePwd;
            break;
          case DeviceActionMode.Write:
            WritePwdAnswer writeConfig = arg.Driver.WriteConfig(arg.NewConfig);
            arg.Result.Value = writeConfig;
            break;
          case DeviceActionMode.Switch:
            //SwitchOnOffAnswer writeLightOnOff = arg.Driver.WriteLightOnOff(arg.NewSwitchOn);
            WritePwdAnswer writeLightOnOff = arg.Driver.WriteLightOnOff(arg.NewSwitchOn);
            arg.Result.Value = writeLightOnOff;
            break;
          case DeviceActionMode.TestCore:
            string CoreVer = arg.Driver.GetCoreVersion();
            arg.Result.Value = CoreVer;
            break;
          case DeviceActionMode.TestVersion:
            string Version = arg.Driver.GetVersionPO();
            arg.Result.Value = Version;
            break;
        }
      }
      catch (Exception ex)
      {
        arg.Result.Value = new DeviceUnknownError(ex);
      }
      finally
      {

        if (!opened)
        {
          _ports.Remove(arg.Driver.Tag);
        }
        arg.IncrementProgress();
        arg.Mre.Set();
      }
      if(arg.ActionMode!= DeviceActionMode.Read && arg.Result.Value is Exception)
        ZtpProtocolDriver.Historian?.Write(arg.Driver.Tag, arg.ActionMode.ToOpHistoryCode(), null, null, (arg.Result.Value as Exception).Message, true);

    }


    void ActionAsync(IWin32Window owner, DeviceActionArg arg, Action<DeviceActionResult> actionComplete)
    {
      WaitForm waitForm = new WaitForm(GetCaption(arg.Mode),
        (s, a) =>
        {
          DoWorkEventArgs doWorkEventArgs = new DoWorkEventArgs(arg);
          Action(doWorkEventArgs);
          a.Result = doWorkEventArgs.Result;
        },
        (sender, a) =>
        {

          if (a.Error != null)
            throw a.Error;
          actionComplete((DeviceActionResult)a.Result);

        }, arg.DeviceIds.Length > 1);
      arg.ReportProgress = waitForm.ReportProgress;
      waitForm.ShowDialog(owner);
    }

    void Action(DoWorkEventArgs doWorkEventArgs)
    {
      DeviceActionArg arg = (DeviceActionArg)doWorkEventArgs.Argument;
      int totalStepCount = arg.DeviceIds.Length;
      int currentStepCount = 0;

      List<ZtpProtocolDriver> drivers = PrepareDrivers(arg.Log, arg.DeviceIds, arg.ReadTcpSetingFunc);
      List<ActionResult> resultList = new List<ActionResult>();

      int pageNum = 0;
      bool hasMore = true;
      while (hasMore)
      {
        List<Tuple<Thread, OneActionArg>> threads = new List<Tuple<Thread, OneActionArg>>();
        IList<ZtpProtocolDriver> protocolDrivers = ArrayUtils.ListPaging(drivers, pageNum, TuneSetting.Default.ConcurrentQuerySize, out hasMore);
        pageNum++;
        foreach (ZtpProtocolDriver driver in protocolDrivers)
        {
          Thread thread = new Thread(StartAction);
          OneActionArg a = new OneActionArg(arg.Log, driver, arg.Mode);
          a.IncrementProgress = delegate ()
          {
            currentStepCount = Interlocked.Increment(ref currentStepCount);
            int percent = (100 * currentStepCount) / totalStepCount;
            arg.ReportProgress(percent);
          };
          a.SessionPassword = GetSessionPasswordForDriver(driver.Tag);
          switch (arg.Mode)
          {
            case DeviceActionMode.SetPwd:
              if (arg.GetNewPasswordFunc == null)
                throw new ArgumentNullException(nameof(arg.GetNewPasswordFunc));
              a.NewPassword = arg.GetNewPasswordFunc(driver.Tag);
              break;
            case DeviceActionMode.Write:
              if (arg.GetNewZtpConfigFunc == null)
                throw new ArgumentNullException(nameof(arg.GetNewZtpConfigFunc));
              a.NewConfig = arg.GetNewZtpConfigFunc(driver.Tag);
              break;
            case DeviceActionMode.Switch:
              if (arg.GetNewSwitchOnFunc == null)
                throw new ArgumentNullException(nameof(arg.GetNewSwitchOnFunc));
              a.NewSwitchOn = arg.GetNewSwitchOnFunc(driver.Tag);
              break;
          }
          threads.Add(new Tuple<Thread, OneActionArg>(thread, a));
        }

        List<ManualResetEvent> mreList = new List<ManualResetEvent>();
        foreach (Tuple<Thread, OneActionArg> item in threads)
        {
          mreList.Add(item.Item2.Mre);
          item.Item1.Start(item.Item2);
        }
        WaitHandle.WaitAll(mreList.ToArray());
        foreach (Tuple<Thread, OneActionArg> item in threads)
        {
          ActionResult res = new ActionResult();
          res.DeviceId = item.Item2.Driver.Tag;
          res.Value = item.Item2.Result.Value;
          resultList.Add(res);
        }
      }
      doWorkEventArgs.Result = new DeviceActionResult(arg.Mode);
      ((DeviceActionResult)doWorkEventArgs.Result).Values = resultList.ToArray();
    }



    internal List<ZtpProtocolDriver> PrepareDrivers(ILog log, int[] deviceIds, Func<int, TcpPortSettings> readSetingFunc)
    {
      List<ZtpProtocolDriver> drivers = new List<ZtpProtocolDriver>();
      foreach (int deviceId in deviceIds)
      {
        drivers.Add(_ports.GetOrAdd(deviceId, (id) =>
        {
          TcpPortSettings portSetting = readSetingFunc(id);
          ZtpProtocolDriver ztpProtocolDriver =
            new ZtpProtocolDriver(log, PortKind.Tcp, null, () => portSetting);
          ztpProtocolDriver.Tag = id;
          return ztpProtocolDriver;
        }));
      }
      return drivers;
    }

    public static string GetSessionPasswordForDriver(int driverId)
    {
      ScopeItem item = ScopeArea.Default[driverId];
      if(item == null)
        throw new Exception($"Устройство (ID={driverId}) не найдено");
      return StringUtils.FromBase64String(item.NodeEx.Password);
    }
    #endregion

    #region CLASSES

    class OneActionResult
    {
      public object Value { get; set; }
    }

    class OneActionArg
    {
      public OneActionArg(ILog log, ZtpProtocolDriver driver, DeviceActionMode mode)
      {
        Log = log;
        Driver = driver;
        ActionMode = mode;
      }
      public string SessionPassword { get; set; }
      public ILog Log { get; }
      public ZtpProtocolDriver Driver { get; }
      public OneActionResult Result = new OneActionResult();
      public ManualResetEvent Mre = new ManualResetEvent(false);
      public DeviceActionMode ActionMode { get; }
      public string NewPassword { get; set; }
      public ZtpConfig NewConfig { get; set; }
      public bool NewSwitchOn { get; set; }
      public ZtpScheduler NewScheduler { get; set; }
      public Action IncrementProgress { get; set; }
    }


    #endregion
  }
}
