using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Ztp;
using Ztp.IO.Logger;
using Ztp.Port.TcpPort;
using Ztp.Protocol;
using Ztp.Ui;
using Ztp.Utils;

namespace ZtpManager.DeviceAccessLayer
{
  public class Fal
  {
    public class FotaArg
    {
      public int[] DeviceIds { get; set; }
      public ZtpFileInfo ModemFile { get; set; }
      public ZtpFileInfo ControllerFile { get; set; }
      public Func<int, TcpPortSettings> ReadTcpSetingFunc { get; set; }
    }

    public class PatchArg
    {
      public int[] DeviceIds { get; set; }
      public  Func<int, TcpPortSettings> ReadTcpSetingFunc { get; set; }
    }

    private static Fal _default;

    private Object form;

    public static Fal Default
    {
      get
      {
        if (_default == null)
          _default = new Fal();
        return _default;
      }
    }

    public void ActionWriteFotaTelit(IWin32Window owner, FotaArg arg, Action<DeviceActionResult> actionComplete)
    {
      WaitForm waitForm = new WaitForm("Запись ПО контроллера",
        (s, a) =>
        {
          DoWorkEventArgs doWorkEventArgs = new DoWorkEventArgs(arg);
          ActionTelit(doWorkEventArgs);
          a.Result = doWorkEventArgs.Result;
        },
        (sender, a) =>
        {
          if (a.Error != null)
            throw a.Error;
          actionComplete((DeviceActionResult)a.Result);
        });
      form = waitForm;
      waitForm.ShowDialog(owner);
    }

    public void ActionWriteFota(IWin32Window owner, FotaArg arg, Action<DeviceActionResult> actionComplete)
    {
      WaitForm waitForm = new WaitForm("Запись ПО контроллера",
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
        });
      waitForm.ShowDialog(owner);
    }

    public void ActionWritePatch(IWin32Window owner, PatchArg arg, Action<DeviceActionResult> actionComplete)
    {
      WaitForm waitForm = new WaitForm("Загрузка патча в контроллер ULC02",
        (s, a) =>
        {
          DoWorkEventArgs doWorkEventArgs = new DoWorkEventArgs(arg);
          ActionPatch(doWorkEventArgs);
          a.Result = doWorkEventArgs.Result;
        },
        (sender, a) =>
        {
          if(a.Error != null)
            throw a.Error;
          actionComplete((DeviceActionResult)a.Result);
        });
      waitForm.ShowDialog(owner);
    }

    //public void ActionCheckCore(IWin32Window owner, )

    void ActionTelit(DoWorkEventArgs doWorkEventArgs)
    {
      FotaArg arg = (FotaArg)doWorkEventArgs.Argument;

      List<ZtpFotaTelit> drivers = PrepareFotaTelit(arg);
      Control[] panelsCtrl = new Label[drivers.Count];

      List<ActionResult> resultList = new List<ActionResult>();

      int pageNum = 0;
      bool hasMore = true;

      int index = 0;

      while(hasMore)
      {
        List<Tuple<Thread, ForaOneTelitArg>> threads = new List<Tuple<Thread, ForaOneTelitArg>>();
        IList<ZtpFotaTelit> fotaDrivers = ArrayUtils.ListPaging(drivers, pageNum, TuneSetting.Default.ConcurrentQuerySize, out hasMore);
        pageNum++;
        

        foreach (ZtpFotaTelit fota in fotaDrivers)
        {
          Thread thread = new Thread(StartActionTelit);
          ForaOneTelitArg a = new ForaOneTelitArg()
          {
            DriverId = fota.Tag,
            Fota = fota
          };
          threads.Add(new Tuple<Thread, ForaOneTelitArg>(thread, a));
          //(WaitForm)form.
        }
        List<ManualResetEvent> mreList = new List<ManualResetEvent>();
        foreach(Tuple<Thread, ForaOneTelitArg> item in threads)
        {
          mreList.Add(item.Item2.Mre);
          item.Item1.Start(item.Item2);
        }
        WaitHandle.WaitAll(mreList.ToArray());
        foreach(Tuple<Thread, ForaOneTelitArg> item in threads)
        {
          ActionResult res = new ActionResult()
          {
            DeviceId = item.Item2.Fota.Tag,
            Value = item.Item2.ActionResult
          };
          resultList.Add(res);
        }
        doWorkEventArgs.Result = new DeviceActionResult(DeviceActionMode.Fota);
        ((DeviceActionResult)doWorkEventArgs.Result).Values = resultList.ToArray();
      }
    }

    void Action(DoWorkEventArgs doWorkEventArgs)
    {
      FotaArg arg = (FotaArg)doWorkEventArgs.Argument;

      List<ZtpFota> drivers = PrepareFota(arg);


      List<ActionResult> resultList = new List<ActionResult>();
      int pageNum = 0;
      bool hasMore = true;
      while (hasMore)
      {
        List<Tuple<Thread, ForaOneArg>> threads = new List<Tuple<Thread, ForaOneArg>>();
        IList<ZtpFota> fotaDrivers = ArrayUtils.ListPaging(drivers, pageNum, TuneSetting.Default.ConcurrentQuerySize, out hasMore);
        pageNum++;
        foreach (ZtpFota fota in fotaDrivers)
        {
          Thread thread = new Thread(StartAction);
          ForaOneArg a = new ForaOneArg()
          {
            DriverId = fota.Tag,
            Fota = fota
          };
          threads.Add(new Tuple<Thread, ForaOneArg>(thread, a));
        }
        List<ManualResetEvent> mreList = new List<ManualResetEvent>();
        foreach (Tuple<Thread, ForaOneArg> item in threads)
        {
          mreList.Add(item.Item2.Mre);
          item.Item1.Start(item.Item2);
        }
        WaitHandle.WaitAll(mreList.ToArray());
        foreach (Tuple<Thread, ForaOneArg> item in threads)
        {
          ActionResult res = new ActionResult()
          {
            DeviceId = item.Item2.Fota.Tag,
            Value = item.Item2.ActionResult
          };
          //res.DeviceId = item.Item2.Fota.Tag;
          //res.Value = item.Item2.ActionResult;
          resultList.Add(res);
        }
        doWorkEventArgs.Result = new DeviceActionResult(DeviceActionMode.Fota);
        ((DeviceActionResult)doWorkEventArgs.Result).Values = resultList.ToArray();
      }
    }

    void ActionPatch(DoWorkEventArgs doWorkEventArgs)
    {
      PatchArg arg = doWorkEventArgs.Argument as PatchArg;
      List<ZtpPatchTelit> drivers = PreparePatch(arg);
      List<ActionResult> resultList = new List<ActionResult>();
      int pagenum = 0;
      bool hasMore = true;
      while(hasMore)
      {
        List<Tuple<Thread, PatchOneArg>> threads = new List<Tuple<Thread, PatchOneArg>>();
        IList<ZtpPatchTelit> patchDrivers = ArrayUtils.ListPaging(drivers, pagenum, TuneSetting.Default.ConcurrentQuerySize, out hasMore);
        pagenum++;
        foreach(ZtpPatchTelit patch in patchDrivers)
        {
          Thread thread = new Thread(StartPatchAction);
          PatchOneArg a = new PatchOneArg()
          {
            DriverId = patch.Tag,
            Patch = patch
          };
          threads.Add(new Tuple<Thread, PatchOneArg>(thread, a));
        }
        List<ManualResetEvent> mreList = new List<ManualResetEvent>();
        foreach (Tuple<Thread, PatchOneArg> item in threads)
        {
          mreList.Add(item.Item2.Mre);
          item.Item1.Start(item.Item2);
        }
        WaitHandle.WaitAll(mreList.ToArray());
        foreach (Tuple<Thread, PatchOneArg> item in threads)
        {
          ActionResult res = new ActionResult()
          {
            DeviceId = item.Item2.Patch.Tag,
            Value = item.Item2.ActionResult
          };
          //res.DeviceId = item.Item2.Fota.Tag;
          //res.Value = item.Item2.ActionResult;
          resultList.Add(res);
        }
        doWorkEventArgs.Result = new DeviceActionResult(DeviceActionMode.Patch);
        ((DeviceActionResult)doWorkEventArgs.Result).Values = resultList.ToArray();
      }
    }

    void StartActionTelit(object obj)
    {
      ForaOneTelitArg arg = (ForaOneTelitArg)obj;
      try
      {
        arg.Fota.Driver.Open();
        arg.Fota.Driver.StartListener();
        arg.Fota.Driver.SessionPassword = DevAl.GetSessionPasswordForDriver(arg.DriverId);

        WritePwdAnswer answer = arg.Fota.Driver.WriteUpgrade();
        if (answer.IsOk)
        {
          arg.Fota.Write();
          arg.ActionResult = WritePwdAnswer.OK;
          ZtpFotaTelit.Historian?.Write(arg.DriverId, OpHistoryCode.F, null, null, WritePwdAnswer.OK.DisplayMessage, false);
        }
        else
          throw new DeviceUnknownError(answer.DisplayMessage);
      }
      catch(Exception e)
      {
        arg.ActionResult = new DeviceUnknownError(e);
        ZtpFotaTelit.Historian?.Write(arg.DriverId, OpHistoryCode.F, null, null, e.Message, true);
      }
      finally
      {
        if(arg.Fota.Driver.IsOpen)
        {
          DevAl.Default.RemoveDriver(arg.DriverId);
        }
        arg.Mre.Set();
      }
    }

    void StartAction(object obj)
    {
      ForaOneArg arg = (ForaOneArg)obj;
      try
      {
        arg.Fota.Driver.Open();
        arg.Fota.Driver.StartListener();
        arg.Fota.Driver.SessionPassword = DevAl.GetSessionPasswordForDriver(arg.DriverId);
        WritePwdAnswer answer = arg.Fota.Driver.WriteUpgrade();
        if (answer.IsOk)
        {
          arg.Fota.Write();
          arg.ActionResult = WritePwdAnswer.OK;
          ZtpFota.Historian?.Write(arg.DriverId, OpHistoryCode.F, null, null, WritePwdAnswer.OK.DisplayMessage, false);
        }
        else
          throw new DeviceUnknownError(answer.DisplayMessage);

      }
      catch (Exception e)
      {
        arg.ActionResult = new DeviceUnknownError(e);
        ZtpFota.Historian?.Write(arg.DriverId, OpHistoryCode.F, null, null, e.Message, true);
      }
      finally
      {
        if (arg.Fota.Driver.IsOpen)
        {
          DevAl.Default.RemoveDriver(arg.DriverId);
        }
        arg.Mre.Set();
      }
    }

    void StartPatchAction(object obj)
    {
      PatchOneArg arg = obj as PatchOneArg;
      try
      {
        arg.Patch.Driver.Open();
        arg.Patch.Driver.StartListener();
        arg.Patch.Driver.SessionPassword = DevAl.GetSessionPasswordForDriver(arg.DriverId);
        string getVers = arg.Patch.Driver.GetCoreVersion();
        if (getVers.CompareTo("12.01.830-B006") == 0)
        {
          throw new Exception("Обновление ядра уже произведено");
        }
        if (!(getVers.CompareTo("12.01.830") == 0 || getVers.CompareTo("12.00.839") == 0))
        {
          throw new Exception("Отсутствует подходящий патч ядра");
        }
        
        WritePwdAnswer answer = arg.Patch.Driver.StartUploadService();
        if(answer.IsOk)
        {
          answer = arg.Patch.Driver.SendFilename("Delta.bin.env");
        }
        if(answer.IsOk)
        {
          arg.Patch.Write(getVers);
          arg.ActionResult = WritePwdAnswer.OK;
          ZtpFota.Historian?.Write(arg.DriverId, OpHistoryCode.F, null, null, WritePwdAnswer.OK.DisplayMessage, false);
        }
      }
      catch(Exception e)
      {
        arg.ActionResult = new DeviceUnknownError(e);
        ZtpPatchTelit.Historian?.Write(arg.DriverId, OpHistoryCode.P, null, null, e.Message, true);
      }
      finally
      {
        if (arg.Patch.Driver.IsOpen)
          DevAl.Default.RemoveDriver(arg.DriverId);
        arg.Mre.Set();
      }
    }

    /// <summary>
    /// Создание списка для прошивки Telit (ULC 02)
    /// </summary>
    /// <param name="arg"></param>
    /// <returns></returns>
    List<ZtpFotaTelit> PrepareFotaTelit(FotaArg arg)
    {
      List<ZtpFotaTelit> retVal = new List<ZtpFotaTelit>();
      List<ZtpProtocolDriver> ztpProtocolDrivers = DevAl.Default.PrepareDrivers(NullLog.Null, arg.DeviceIds, arg.ReadTcpSetingFunc);
      foreach(int id in arg.DeviceIds)
      {
        TcpPortSettings TcpPortSettings = arg.ReadTcpSetingFunc(id);
        ZtpFotaTelit fota = new ZtpFotaTelit(arg.ModemFile, AppConfig.Default.TcpTimeout);
        fota.Address = TcpPortSettings.IpAddress;
        fota.Tag = id;
        fota.Driver = ztpProtocolDrivers.FirstOrDefault((ztpDriver) => ztpDriver.Tag == id);
        retVal.Add(fota);
      }
      return retVal;
    }

    List<ZtpFota> PrepareFota(FotaArg arg)
    {
      List<ZtpFota> retVal = new List<ZtpFota>();
      List<ZtpProtocolDriver> ztpProtocolDrivers = DevAl.Default.PrepareDrivers(NullLog.Null, arg.DeviceIds, arg.ReadTcpSetingFunc);
      foreach (int id in arg.DeviceIds)
      {
        TcpPortSettings tcpPortSettings = arg.ReadTcpSetingFunc(id);
        ZtpFota fota = new ZtpFota(arg.ModemFile, arg.ControllerFile, AppConfig.Default.TcpTimeout);
        fota.Address = tcpPortSettings.IpAddress;
        fota.Tag = id;
        fota.Driver = ztpProtocolDrivers.FirstOrDefault((ztpDriver) => ztpDriver.Tag == id);
        retVal.Add(fota);
      }
      return retVal;
    }

    List<ZtpPatchTelit> PreparePatch(PatchArg arg)
    {
      List<ZtpPatchTelit> retVal = new List<ZtpPatchTelit>();
      List<ZtpProtocolDriver> ztpProtocolDrivers = DevAl.Default.PrepareDrivers(NullLog.Null, arg.DeviceIds, arg.ReadTcpSetingFunc);
      foreach(int id in arg.DeviceIds)
      {
        TcpPortSettings tcpPortSettings = arg.ReadTcpSetingFunc(id);
        ZtpPatchTelit patch = new ZtpPatchTelit(AppConfig.Default.TcpTimeout);
        patch.Address = tcpPortSettings.IpAddress;
        patch.Tag = id;
        patch.Driver = ztpProtocolDrivers.FirstOrDefault((ztpDriver) => ztpDriver.Tag == id);
        retVal.Add(patch);
      }
      return retVal;
    }

    class ForaOneArg
    {
      public object ActionResult { get; set; }
      public ManualResetEvent Mre = new ManualResetEvent(false);
      public int DriverId { get; set; }
      public ZtpFota Fota { get; set; }
    }

    class ForaOneTelitArg
    {
      public object ActionResult { get; set; }
      public ManualResetEvent Mre = new ManualResetEvent(false);
      public int DriverId { get; set; }
      public ZtpFotaTelit Fota { get; set; }
    }

    class PatchOneArg
    {
      public object ActionResult { get; set; }
      public ManualResetEvent Mre = new ManualResetEvent(false);
      public int DriverId { get; set; }
      public ZtpPatchTelit Patch {get;set;}
    }
  }
}
