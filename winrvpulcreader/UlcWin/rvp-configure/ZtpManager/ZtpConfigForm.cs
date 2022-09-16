using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Configuration;
using Ztp.IO.Logger;
using Ztp.Model;
using Ztp.Protocol;
using Ztp.Protocol.Event;
using Ztp.Ui;
using Ztp.Utils;
using ZtpManager.DataAccessLayer;
using ZtpManager.DeviceAccessLayer;
using ZtpManager.Scope;

namespace ZtpManager
{
  public enum ActionType
  {
    SeasonAdd = 1,
    SeasonEdit = 2,
    SeasonDelete = 3,
    ScheaduleAdd = 4,
    ScheaduleEdit = 5,
    ScheaduleDelete = 6,
    CopyPlanFromCat = 7,
    RebootDevice = 8,
    ChangePassword = 9,
    ShowScheduler = 10,
    ConfigRead = 11,
    ConfigWrite = 12
  }

  public partial class ZtpConfigForm : Form, IChildForm, ILog
  {
    private ZtpProtocolDriver _driver;
    public ZtpConfigForm(ScopeItem scopeItem, Action beginUserAction, Action endUserAction)
    {
      //if (scopeItem == null) throw new ArgumentNullException(nameof(scopeItem));
      //if (beginUserAction == null) throw new ArgumentNullException(nameof(beginUserAction));
      //if (endUserAction == null) throw new ArgumentNullException(nameof(endUserAction));
      ScopeItem = scopeItem ?? throw new ArgumentNullException(nameof(scopeItem));
      Text = ScopeItem.DeviceName;
      BeginUserAction = beginUserAction ?? throw new ArgumentNullException(nameof(beginUserAction));
      EndUserAction = endUserAction ?? throw new ArgumentNullException(nameof(endUserAction));
      InitializeComponent();
      // тут определение какое устройство подключено и от этого переставляются панельки
      //scopeItem.NodeEx.DevType 
      configEditor._devType = (Ztp.Enums.Device)scopeItem.NodeEx.DevType;
      scDeviceDebug.SplitterDistance = scDeviceDebug.Height - 200;
      scDeviceDebug.SplitterMoved += scDeviceDebug_SplitterMoved;
      ScopeArea.Default.NodeChanged += Default_NodeChanged;
    }

    private void Default_NodeChanged(ScopeArea.NodeChangedEventArg e)
    {
      if (_driver != null)
        _driver.SessionPassword = StringUtils.FromBase64String(ScopeItem.NodeEx.Password);
    }

    private void scDeviceDebug_SplitterMoved(object sender, SplitterEventArgs e)
    {
      AppConfig.Default.SplitterDistance = scDeviceDebug.SplitterDistance;
      AppConfig.Default.Save();
    }

    public ChildFormKind FormKind => ChildFormKind.ZtpConfigPage;

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      UpdateDebugWindow();
      UpdateStateWindow();
    }

    public bool OpenPort()
    {
      try
      {
        object result = DevAl.Default.GetOrCreateDriver($"{ScopeItem.NodeEx.IpAddress}:{AppConfig.Default.TcpPort}", this, this, ScopeItem.NodeEx.Id, Dal.Default.CreateTcpPortSettings);
        if (result is ZtpProtocolDriver)
          _driver = result as ZtpProtocolDriver;
        else
          throw (Exception)result;
        _driver.ChangeState += _driver_ChangeState;
        _driver.DebugReceived += _driver_DebugReceived;
        _driver.Disconnected += _driver_LostConnect;
      }
      catch (Exception exception)
      {
        ShowErrorAsync(exception);
        return false;
      }
      return true;
    }

    private void _driver_LostConnect(object sender, Ztp.Port.LostConnectEventArgs e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action<object, Ztp.Port.LostConnectEventArgs>(_driver_LostConnect), sender, e);
        return;
      }
      Box.Error(this, $"С устройством '{ScopeItem.DeviceName}' потеряно соединение. Окно конфигурации устройства будет закрыто."); 
      Close();
    }

    private void _driver_DebugReceived(object sender, Ztp.Port.MessageReceivedEventArgs e)
    {
      AddDebug(e.Message, e.IsEvent);
    }

    void AddDebug(string message, bool isEvent)
    {
      if (string.IsNullOrEmpty(message)) return;
      message = message.Trim('\r', '\n');
      if (string.IsNullOrEmpty(message)) return;
      this.uiLogConsole.WriteDebug(isEvent, message + Environment.NewLine);
    }

    private void _driver_ChangeState(Ztp.Protocol.Event.ZtpEvent state)
    {
      if (InvokeRequired)
      {
        BeginInvoke(new Action<ZtpEvent>(_driver_ChangeState), state);
        return;
      }
      switch (state.Kind)
      {
        case EventsKind.Ain:
          currentStateView.SetAin(((ZtpEventAin)state).Ord, ((ZtpEventAin)state).Value);
          break;
        case EventsKind.Din:
          currentStateView.SetDin(((ZtpEventDin)state).Ord, ((ZtpEventDin)state).Value);
          break;
        case EventsKind.Dout:
          if (((ZtpEventDout)state).Ord == 0 || ((ZtpEventDout)state).Ord == 1)
          {
            configEditor.Value.SetSwitchOnOff(((ZtpEventDout)state).Value);
            OnNeedEnableUpdate();
          }
          currentStateView.SetDout(((ZtpEventDout)state).Ord, ((ZtpEventDout)state).Value);
          break;
      }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
      if (_driver != null)
        DevAl.Default.RemoveDriver(ScopeItem.NodeEx.Id);
      base.OnFormClosed(e);
    }

    void UpdateDebugWindow()
    {
      scDeviceDebug.Panel2Collapsed = !AppConfig.Default.ShowDebug;
      if (AppConfig.Default.SplitterDistance <= scDeviceDebug.Height)
        AppConfig.Default.SplitterDistance = scDeviceDebug.Height - 150;
      scDeviceDebug.SplitterDistance = AppConfig.Default.SplitterDistance;
    }

    void UpdateStateWindow()
    {
      scCurrentState.Panel2Collapsed = !AppConfig.Default.ShowState;
    }

    public void ShowState(bool show)
    {
      scCurrentState.Panel2Collapsed = !show;
    }

    public void ShowDebug(bool show)
    {
      scDeviceDebug.Panel2Collapsed = !show;
    }

    public Action BeginUserAction { get; }
    public Action EndUserAction { get; }
    public ScopeItem ScopeItem { get; }

    public void SetConfigToControls(ZtpConfig zc)
    {
      configEditor.Value = zc;
      lightPlanEditor.Value = zc.Light;
      currentStateView.Value = zc;
    }

    /*public*/private void DoReadConfig()
    {
      BeginUserAction();
      try
      {
        ZtpConfig zc = ReadNodeZtpConfig(ScopeItem.NodeEx.Id);
        if (zc != null)
        {
          //
          configEditor.RechangeField((Ztp.Enums.Device)ScopeItem.NodeEx.DevType);//заменяем панельку EST tools <=> IEC104
          if (ScopeItem.NodeEx.DevType == DeviceKind.ULC02)
          {
            //modBusEditor.Show();
            configEditor.GsmTechShow(true);
            configEditor.PlanRebootShow(zc.SoftVersion.CompareTo("1.0.3") >= 0);
            /*if (zc.SoftVersion.CompareTo("1.0.4") >= 0)
              modbusItemListControl1.max_mb_Tags = 100;
            else
              modbusItemListControl1.max_mb_Tags = 32;
            */
            configEditor.PingIpShow(zc.SoftVersion.CompareTo("1.7.0") >= 0);
            configEditor.LogsControlShow(zc.SoftVersion.CompareTo("1.7.8") >= 0);
          }
          else
          {
            //modBusEditor.Hide();
            configEditor.GsmTechShow(false);
            if (zc.SoftVersion.CompareTo("1.1.18") >= 0)
              configEditor.PlanRebootShow(true);
            else
              configEditor.PlanRebootShow(false);
          }
          ScopeItem.ZtpConfig = zc;
          ScopeArea.Default.EditDevice(ScopeItem.NodeEx);
        }
      }
      catch (Exception ex)
      {
        ShowErrorAsync(ex);
      }
      finally
      {
        EndUserAction();
      }
    }

    /*public*/private void DoWriteConfig()
    {
      if (!Box.Confirm(this, "При записи конфигурации время устройства будет синхронизировано с временем компьютера.\r\n\r\nЗаписать конфигурацию в устройство?"))
        return;

      Exception e = ZtpScheduler.CheckOverlap(ScopeItem.ZtpConfig.Light.Scheduler, ScopeItem.ZtpConfig.TimeZone, ScopeItem.ZtpConfig.Latitude, ScopeItem.ZtpConfig.Longitude);
      if (e != null)
      {
        Box.Error(this, e);
        return;
      }

      WritePwdAnswer retVal = null;
      BeginUserAction();
      try
      {
        ScopeItem.ZtpConfig = configEditor.Value;
        ScopeItem.ZtpConfig.Light = lightPlanEditor.Value;
        ScopeItem.ZtpConfig.ComPortSetting = comPortEditor.Value;
        if (string.IsNullOrEmpty(_driver.SessionPassword))
          _driver.SessionPassword = StringUtils.FromBase64String(ScopeItem.NodeEx.Password);
        DevAl.Default.ActionWriteConfig(this, new DeviceActionArg(DeviceActionMode.Write)
        {
          Log = this,
          DeviceIds = new[] { ScopeItem.NodeEx.Id },
          ReadTcpSetingFunc = Dal.Default.CreateTcpPortSettings,
          GetNewZtpConfigFunc = (id) => ScopeItem.ZtpConfig
        }, result =>
        {
          object res = DevAl.Default.GetActionResultForDevice(result, ScopeItem.NodeEx.Id);
          if (res != null)
          {
            if (res is DeviceUnknownError)
              ShowErrorAsync(res as DeviceUnknownError);
            retVal = res as WritePwdAnswer;
          }
        });
      }
      catch (Exception ex)
      {
        ShowErrorAsync(ex);
      }
      finally
      {
        EndUserAction();
      }
      if (retVal != null)
      {
        Box.Info(this, retVal.DisplayMessage);
        OnNeedEnableUpdate();
      }
    }

    public void SetCoordForLight()
    {
      lightPlanEditor.ZtpLocation = GetCoordForLight();
    }

    public LocationEditorControl.ZtpLocation GetCoordForLight()
    {
      LocationEditorControl.ZtpLocation loc = new LocationEditorControl.ZtpLocation();
      loc.Latitude = configEditor.Value.Latitude;
      loc.Longitude = configEditor.Value.Longitude;
      loc.TimeZone = configEditor.Value.TimeZone;
      return loc;
    }

    private void DoReboot()
    {
      string msg = "При перезапуске устройства соединение будет разорвано.\r\nПерезапустить устройство?";
      if(!Box.Confirm(this, msg))
        return;
      WritePwdAnswer retVal = null;
      BeginUserAction();
      try
      {
        DevAl.Default.ActionWriteReboot(this, new DeviceActionArg(DeviceActionMode.Reboot)
        {
          Log = this,
          DeviceIds = new[] { ScopeItem.NodeEx.Id },
          ReadTcpSetingFunc = Dal.Default.CreateTcpPortSettings
        }, result =>
        {
          object res = DevAl.Default.GetActionResultForDevice(result, ScopeItem.NodeEx.Id);
          if (res != null)
          {
            if (res is DeviceUnknownError)
              ShowErrorAsync(res as DeviceUnknownError);
            retVal = res as WritePwdAnswer;
          }
        });
      }
      catch (Exception ex)
      {
        ShowErrorAsync(ex);
      }
      finally
      {
        EndUserAction();
      }
      if (retVal != null)
      {
        Box.Info(this, retVal.DisplayMessage);
        if(retVal.IsOk)
          Close();
      }
    }

    private void DoChangePassword()
    {
      string psw;
      using (Ztp.Ui.NewPasswordForm frm = new NewPasswordForm())
      {
        if (frm.ShowDialog(this) != DialogResult.OK)
          return;
        psw = frm.Value;
      }
      WritePwdAnswer retVal = null;
      BeginUserAction();
      try
      {
        DevAl.Default.ActionWriteSetPassword(this, new DeviceActionArg(DeviceActionMode.SetPwd)
        {
          Log = this,
          DeviceIds = new[] { ScopeItem.NodeEx.Id },
          ReadTcpSetingFunc = Dal.Default.CreateTcpPortSettings,
          GetNewPasswordFunc = (id) => psw
        },
          result =>
          {
            object res = DevAl.Default.GetActionResultForDevice(result, ScopeItem.NodeEx.Id);
            if (res != null)
            {
              if (res is DeviceUnknownError)
                ShowErrorAsync(res as DeviceUnknownError);
              retVal = res as WritePwdAnswer;
            }
          });
      }
      catch (Exception ex)
      {
        ShowErrorAsync(ex);
      }
      finally
      {
        EndUserAction();
      }
      if (retVal != null && retVal.IsOk)
      {
        //сохраняем пароль при успехе
        ScopeItem.NodeEx.Password = StringUtils.ToBase64String(psw);
        Dal.Default.EditNode(ScopeItem.NodeEx);
      }
      Box.Info(this, retVal.DisplayMessage);
    }

    public void DoSwitchOnOff(bool isOn)
    {
      string str =
        "При ручном режиме управления освещением расписания освещения будут отключены. Для их повторного включения установите флажок 'Активность расписаний освещения' и запишите конфигурацию в контроллер\r\n";
      str += isOn ? "Включить освещение?" : "Выключить освещение?";
      if (!Box.Confirm(this, str))
        return;
      //SwitchOnOffAnswer retVal = null;
      WritePwdAnswer retVal = null;
      BeginUserAction();
      try
      {
        DevAl.Default.ActionWriteSwitchOnOff(this, new DeviceActionArg(DeviceActionMode.Switch)
        {
          Log = this,
          DeviceIds = new[] { ScopeItem.NodeEx.Id },
          ReadTcpSetingFunc = Dal.Default.CreateTcpPortSettings,
          GetNewSwitchOnFunc = (id) => isOn
        }, result =>
        {
          object res = DevAl.Default.GetActionResultForDevice(result, ScopeItem.NodeEx.Id);
          if (res != null)
          {
            if (res is DeviceUnknownError)
              ShowErrorAsync(res as DeviceUnknownError);
            retVal = res as WritePwdAnswer;//SwitchOnOffAnswer;
          }
        });

      }
      catch (Exception ex)
      {
        ShowErrorAsync(ex);
      }
      finally
      {
        EndUserAction();
      }

      if (retVal != null)
      {
        ScopeArea.Default.EditDevice(ScopeItem.NodeEx);
        if (!retVal.IsOk)
        {
          Box.Info(this, "Доступ запрещен");
          return;
        }
        SetUseScheduler(false);
        //ZtpConfig config = configEditor.Value;
        //config.SetSwitchOnOff(retVal.SwitchOn);
        //config.Light.UseScheduler = false;
        //lightPlanEditor.Value = config.Light;
        Box.Info(this, retVal.DisplayMessage);
        //Box.Info(this, $"Освещение переведено в состояние '{(retVal.SwitchOn ? "Включено" : "Отключено")}'");
      }
    }

    public void SetUseScheduler(bool isUse)
    {
      ZtpConfig config = configEditor.Value;
      config.Light.UseScheduler = isUse;
      lightPlanEditor.Value = config.Light;
    }

    ZtpConfig ReadNodeZtpConfig(int deviceId)
    {
      ZtpConfig retVal = null;
      DevAl.Default.ActionReadConfig(this, new DeviceActionArg(DeviceActionMode.Read)
      {
        Log = this,
        DeviceIds = new[] { deviceId },
        ReadTcpSetingFunc = Dal.Default.CreateTcpPortSettings
      }, result =>
      {
        ReadConfigAnswer res = DevAl.Default.GetActionResultForDevice(result, deviceId) as ReadConfigAnswer;
        if (res != null)
        {
          if (res.Error != null)
            ShowErrorAsync(res.Error);
          else
            retVal = res.Config;
        }
      });
      return retVal;
    }

    void ShowErrorAsync(Exception ex)
    {
      if (InvokeRequired)
      {
        BeginInvoke(new Action<Exception>(ShowErrorAsync), ex);
        return;
      }
      Box.Error(this, ex);
    }

    public void Info(string message, params object[] args)
    {
      uiLogConsole.Info(message, args);
    }

    public void Error(string message, params object[] args)
    {
      uiLogConsole.Error(message, args);
    }

    public void Error(Exception e)
    {
      uiLogConsole.Error(e);
    }

    public bool ReadConfigEnabled => _driver != null;
    public bool WriteConfigEnabled => _driver != null;
    public bool RebootEnabled => _driver != null;
    public bool ChangePasswordEnabled => _driver != null;
    public bool SwitchOnOffEnabled => _driver != null;

    public bool IsSwitchOn => ScopeItem.ZtpConfig.IsSwitchOn;

    public bool CopyLightPlanEnabled => Dal.Default.IsConnected;
    public bool ScheduleAddEnabled
    {
      get
      {
        return lightPlanEditor.ScheduleAddEnabled;
      }
    }

    public bool ScheduleDeleteEnabled
    {
      get
      {
        return lightPlanEditor.ScheduleDeleteEnabled;
      }
    }

    public bool ScheduleEditEnabled
    {
      get
      {
        return lightPlanEditor.ScheduleEditEnabled;
      }
    }

    public bool ScheduleShowEnabled
    {
      get
      {
        return lightPlanEditor.ScheduleShowEnabled;
      }
    }

    public bool SeasonAddEnabled
    {
      get
      {
        return lightPlanEditor.SeasonAddEnabled;
      }
    }

    public bool SeasonDeleteEnabled
    {
      get
      {
        return lightPlanEditor.SeasonDeleteEnabled;
      }
    }

    public bool SeasonEditEnabled
    {
      get
      {
        return lightPlanEditor.SeasonEditEnabled;
      }
    }

    public bool DoAction(ActionType act)
    {
      switch(act)
      {
        case ActionType.SeasonAdd:
          return lightPlanEditor.DoSeasonAdd();
        case ActionType.SeasonEdit:
          return lightPlanEditor.DoSeasonEdit();
        case ActionType.SeasonDelete:
          return lightPlanEditor.DoSeasonDelete();
        case ActionType.ScheaduleAdd:
          return lightPlanEditor.DoScheduleAdd();
        case ActionType.ScheaduleEdit:
          return lightPlanEditor.DoScheduleEdit();
        case ActionType.ScheaduleDelete:
          return lightPlanEditor.DoScheduleDelete();
        case ActionType.CopyPlanFromCat: 
          return DoCopyLightPlan();
        case ActionType.RebootDevice:
          DoReboot();
          return false;
        case ActionType.ChangePassword:
          DoChangePassword();
          return false;
        case ActionType.ShowScheduler:
          lightPlanEditor.ZtpLocation = GetCoordForLight();
          lightPlanEditor.DoScheduleShow();
          return false;
        case ActionType.ConfigRead:
          DoReadConfig();
          return false;
        case ActionType.ConfigWrite:
          DoWriteConfig();
          return false;
        default:
          return false;
      }
    }

    private bool DoCopyLightPlan()
    {
      using (SelectLightPlanForm frm = new SelectLightPlanForm())
      {
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          LightPlan lightPlan = frm.SelectedLightPlan;
          ScopeItem.ZtpConfig.Light.Scheduler = ZtpScheduler.Deserialize(Convert.FromBase64String(lightPlan.Body));
          ScopeArea.Default.EditDevice(ScopeItem.NodeEx);
          return true;
        }
        return false;
      }
    }

    //public void DoScheduleShow()
    //{
    //  lightPlanEditor.DoScheduleShow();
    //}

    public event EventHandler NeedEnableUpdate;
    private void lightPlanEditor_NeedEnableUpdate(object sender, EventArgs e)
    {
      OnNeedEnableUpdate();
    }

    protected virtual void OnNeedEnableUpdate()
    {
      NeedEnableUpdate?.Invoke(this, EventArgs.Empty);
    }
  }
}
