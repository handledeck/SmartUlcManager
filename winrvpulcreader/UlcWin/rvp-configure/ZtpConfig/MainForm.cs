using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Ztp.Configuration;
using Ztp.Enums;
using Ztp.Port;
using Ztp.Protocol;
using Ztp.Protocol.Event;
using Ztp.Ui;


namespace Ztp
{
  public partial class MainForm : Form
  {
    private string _fileName;
    private string _devName;
    public static Device _devType;//XXX

    private bool _doAction = false;
    private bool _isReaden = false;

    private Dictionary<string, Device> DevType = new Dictionary<string, Device>()
    {
      { "I16O2A2-LDC-3-FOTA", Device.RVP},
      { "I16O2A2-LDC-3-FOTA-BT", Device.RVP},
      { "I4O1A1-LDC-3-FOTA", Device.ULC2 },
      { "I4O1A1-LDC-3-FOTA-DM", Device.ULC2},
      { "I8O2A2-LEM-4-FOTA-prIM", Device.ULC2_2}
    };

    private static readonly NLog.Logger nLogger = NLog.LogManager.GetCurrentClassLogger();

    public MainForm()
    {
      InitializeComponent();
      #region Кроссработа с панелью модбас
      modBusEditor.Upload += () => Action(DeviceActionMode.Write_ModBus); 
      modBusEditor.Download += () => Action(DeviceActionMode.Read_ModBus); 
      modBusEditor.TagTableVisible += (res) => modbusItemListControl1.Visible = res;
      modBusEditor.TagTableAddItem += (addr, cmd, field, iecIndex, dbz) => modbusItemListControl1.addTag(addr, cmd, field, iecIndex, dbz);
      modBusEditor.clTable += () => modbusItemListControl1.ClearTable(); 
      modBusEditor.getCollectionFromTable += () => modbusItemListControl1.GetTagMassive(); //GetDataFromTableMB;

      modBusEditor.getStringsTable += () => modbusItemListControl1.GetTableAsStrings(); //GetStringsTableMB;

      modBusEditor.getGzipLabel += () => modbusItemListControl1.GetGzip(); 
      modBusEditor.LoadMBLabels += (input) => modbusItemListControl1.AssetGzip(input); //LoadLabelsGzip;
      #endregion

      configEditor.TestPing += () => Action(DeviceActionMode.TestPing);//TestPing;

      splitContainer.SplitterDistance = splitContainer.Height - 200;
      splitContainer.SplitterMoved += splitContainer_SplitterMoved;

      ZtpConfig config = ZtpConfig.GetDefault();
      configEditor.Value = config;
      currentStateView.Value = config;
      planEditor.Value = config.Light;
      modBusEditor.Height = 80;

      //костыль по сути, ибо почему-то эти флаги норовят сброситься в false
      configEditor.ShowApnProperty = true;
      planEditor.UseSchedulerVisible = true;
      this.Show();
    }


    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      ShowCaption();
      SetControlsEnabled();
      FillRecentFiles();
      planEditor.NeedEnableUpdate += PlanEditor_NeedEnableUpdate;
      UpdateDebugWindow();
      UpdateStateWindow();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      CloseConnect();
    }

    void UpdateDebugWindow()
    {
      rbViewDebug.Checked = Setting.Default.ShowDebug;
      splitContainer.Panel2Collapsed = !Setting.Default.ShowDebug;
      if (Setting.Default.SplitterDistance <= splitContainer.Height)
        Setting.Default.SplitterDistance = splitContainer.Height - 150;
      splitContainer.SplitterDistance = Setting.Default.SplitterDistance;
    }

    void UpdateStateWindow()
    {
      rbViewState.Checked = Setting.Default.ShowState;
      splitContainerState.Panel2Collapsed = !Setting.Default.ShowState;
      if (Setting.Default.StateSplitterDistance <= splitContainerState.Width)
        Setting.Default.StateSplitterDistance = splitContainerState.Width - 350;
      splitContainerState.SplitterDistance = Setting.Default.StateSplitterDistance;
    }

    private void PlanEditor_NeedEnableUpdate(object sender, EventArgs e)
    {
      SetControlsEnabled();
    }

    void FillRecentFiles()
    {
      ribbon.OrbDropDown.RecentItems.Clear();

      for (int i = 0; i < Setting.Default.RecentFiles.Count; i++)
      {
        string fileName = Setting.Default.RecentFiles[i];
        RibbonDescriptionMenuItem item = new RibbonDescriptionMenuItem();
        item.Image = Properties.Resources.document;
        item.Text = Path.GetFileNameWithoutExtension(fileName);
        item.ToolTip = fileName;
        item.Click += RecentItem_Click;
        ribbon.OrbDropDown.RecentItems.Add(item);
      }
    }

    /// <summary>
    /// Изменение заголовка окна
    /// </summary>
    void ShowCaption()
    {
      StringBuilder sb = new StringBuilder("Конфигурация устройства");
      if (!string.IsNullOrEmpty(_devName))
        sb.Append($" {_devName}");
      if (!string.IsNullOrEmpty(_fileName))
        sb.Append($" [{_fileName}]");
      Text = sb.ToString();
    }

    #region Обработчики кнопок
    /// <summary>
    /// Открытие файла конфигурации
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RecentItem_Click(object sender, EventArgs e)
    {
      RibbonDescriptionMenuItem item = sender as RibbonDescriptionMenuItem;
      if (item == null) return;
      string fileName = item.ToolTip;
      OpenFile(fileName);
    }

    /// <summary>
    /// Обработка кнопки открытия сохраненной конфигурации
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void rmiOpenFile_Click(object sender, EventArgs e)
    {
      ofd.Filter = $"Конфигурация (*{ZtpConfig.ZtpConfigFileExtantion})|*{ZtpConfig.ZtpConfigFileExtantion}";
      ofd.DefaultExt = ZtpConfig.ZtpConfigFileExtantion;
      if (ofd.ShowDialog(this) == DialogResult.OK)
      {
        string path = ofd.FileName;
        OpenFile(path);
        if (!Setting.Default.RecentFiles.Contains(path))
        {
          Setting.Default.RecentFiles.Add(path);
          FillRecentFiles();
        }
        SetControlsEnabled();
      }
    }

    /// <summary>
    /// Обработчик кнопки сохранения конфигурации в файл
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void rmiFileSave_Click(object sender, EventArgs e)
    {
      sfd.Filter = $"Конфигурация (*{ZtpConfig.ZtpConfigFileExtantion})|*{ZtpConfig.ZtpConfigFileExtantion}";
      sfd.DefaultExt = ZtpConfig.ZtpConfigFileExtantion;
      if (sfd.ShowDialog(this) == DialogResult.OK)
      {
        string path = sfd.FileName;
        try
        {
          ZtpConfig config = configEditor.Value;
          config.Light = planEditor.Value;
          ZtpConfig.SaveToFile(path, config);
          _fileName = path;
          ShowCaption();
          if (!Setting.Default.RecentFiles.Contains(path))
          {
            Setting.Default.RecentFiles.Add(path);
            FillRecentFiles();
          }
          SetControlsEnabled();
        }
        catch (Exception ex)
        {
          Box.Error(this, ex);
        }
      }
    }

    /// <summary>
    /// Считывание конфигурации с устройства
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void rbRead_Click(object sender, EventArgs e)
    {
      if (Box.Confirm(this, "Прочитать конфигурацию с устройства?"))
        Action(DeviceActionMode.Read);
    }

    /// <summary>
    /// Кнопка подключения/отключения с устройством
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void rbOpenClose_Click(object sender, EventArgs e)
    {
      bool ok = true;
      if (_driver == null)
      {
        ok = false;
        using (SettingForm frm = new SettingForm())
        {
          frm.ValueTcpPortSettings = Setting.Default.TcpPortSettings;
          frm.ValueComPortSettings = Setting.Default.ComPortSettings;
          frm.ValuePortKind = Setting.Default.LastPortKind;
          if (frm.ShowDialog(this) == DialogResult.OK)
          {
            Setting.Default.TcpPortSettings = frm.ValueTcpPortSettings;
            Setting.Default.ComPortSettings = frm.ValueComPortSettings;
            Setting.Default.LastPortKind = frm.ValuePortKind;
            Setting.Default.Save();
            ok = true;
          }
        }
      }
      if (!ok)
        return;
      Cursor = Cursors.WaitCursor;
      try
      {
        nLogger.Info("Подключение к устройству ");
        if (_driver == null)
        {
          OpenConnect();
          //_devType = Device.ULC2;
        }
        else
        {
          _isReaden = false;
          CloseConnect();
        }
        SetControlsEnabled();
      }
      finally
      {
        Cursor = Cursors.Default;
      }
    }

    private void rbWrite_Click(object sender, EventArgs e)
    {
      if (Box.Confirm(this, "При записи конфигурации время устройства будет синхронизировано с временем компьютера.\r\n\r\nЗаписать конфигурацию в устройство?"))
        Action(DeviceActionMode.Write);
    }

    private void rbReboot_Click(object sender, EventArgs e)
    {
      string msg = "При перезапуске устройства соединение будет разорвано.\r\nПерезапустить устройство?";
      if (Box.Confirm(this, msg))
        Action(DeviceActionMode.Reboot);
    }

    private void rbChangePwd_Click(object sender, EventArgs e)
    {
      using (NewPasswordForm frm = new NewPasswordForm())
      {
        if (frm.ShowDialog(this) == DialogResult.OK)
          Action(DeviceActionMode.SetPwd, newPwd: frm.Value);
      }
    }

    private void rbLight_Click(object sender, EventArgs e)
    {
      string str =
          "При ручном режиме управления освещением расписания освещения будут отключены. Для их повторного включения установите флажок 'Активность расписаний освещения' и запишите конфигурацию в контроллер\r\n";
      bool switchOn = Convert.ToBoolean(rbLight.Tag);
      str += switchOn ? "Включить освещение?" : "Выключить освещение?";
      if (Box.Confirm(this, str))
      {
        Action(DeviceActionMode.Switch, switchOn);
        planEditor.UseSchedulerEnable = false;
      }
    }

    private void rmiFileExit_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void rbAddSeason_Click(object sender, EventArgs e)
    {
      planEditor.DoSeasonAdd();
      SetControlsEnabled();
    }

    private void rbDeleteSeason_Click(object sender, EventArgs e)
    {
      planEditor.DoSeasonDelete();
      SetControlsEnabled();
    }

    private void rbEditSeason_Click(object sender, EventArgs e)
    {
      planEditor.DoSeasonEdit();
      SetControlsEnabled();
    }

    private void rbAddSchedule_Click(object sender, EventArgs e)
    {
      planEditor.DoScheduleAdd();
      SetControlsEnabled();
    }

    private void rbDeleteSchedule_Click(object sender, EventArgs e)
    {
      planEditor.DoScheduleDelete();
      SetControlsEnabled();
    }

    private void rbEditSchedule_Click(object sender, EventArgs e)
    {
      planEditor.DoScheduleEdit();
      SetControlsEnabled();
    }

    private void rbShowSched_Click(object sender, EventArgs e)
    {
      ZtpConfig config = configEditor.Value;

      planEditor.ZtpLocation = new LocationEditorControl.ZtpLocation()
      {
        Latitude = config.Latitude,
        Longitude = config.Longitude,
        TimeZone = config.TimeZone
      };
      planEditor.DoScheduleShow();
      SetControlsEnabled();
    }


    private void rbViewDebug_Click(object sender, EventArgs e)
    {
      rbViewDebug.Checked = !rbViewDebug.Checked;
      Setting.Default.ShowDebug = rbViewDebug.Checked;
      Setting.Default.Save();
      ShowDebug(Setting.Default.ShowDebug);
    }

    private void rbViewState_Click(object sender, EventArgs e)
    {
      rbViewState.Checked = !rbViewState.Checked;
      Setting.Default.ShowState = rbViewState.Checked;
      Setting.Default.Save();
      ShowState(Setting.Default.ShowState);
    }

    private void rmiAbout_Click(object sender, EventArgs e)
    {
      using (AboutForm frm = new AboutForm())
      {
        frm.ShowDialog(this);
      }
    }

    private void rbFota_Click(object sender, EventArgs e)
    {
      if (!CheckSessionPassword())
        return;
      switch (_devType)
      {
        case Device.RVP:
          using (FotaForm frm = new FotaForm())
          {
            frm.Address = Setting.Default.TcpPortSettings.IpAddress;
            frm.PackageSize = Setting.Default.FotaPackageSize;
            frm.Driver = this._driver;
            frm.FotaStarted += Frm_FotaStarted;
            if (frm.ShowDialog(this) == DialogResult.OK)
              Box.Info(this, "Прошивка устройства успешно завершена");
            frm.FotaStarted -= Frm_FotaStarted;
          }
          break;
        case Device.ULC2:
          using (FotaFormTelit frm = new FotaFormTelit(configEditor.Value.SoftVersion, configEditor.Value.DateTimeFirmware.ToString("dd.MM.yyyy HH:mm:ss")))
          {
            frm.Address = Setting.Default.TcpPortSettings.IpAddress;
            frm.PackageSize = Setting.Default.FotaPackageSize;
            frm.Driver = this._driver;
            frm.FotaStarted += Frm_FotaStarted;
            if (frm.ShowDialog(this) == DialogResult.OK)
              Box.Info(this, "Прошивка устройства успешно завершена");
            frm.FotaStarted -= Frm_FotaStarted;
          }
          break;
        case Device.Unknown:
          MessageBox.Show("Устройство системой не опознано. Процедура прошивки отклонена", "Прошивка невозможна");
          break;
      }
    }
    #endregion //Обработка кнопок

    void OpenFile(string fileName)
    {
      try
      {
        ZtpConfig config = ZtpConfig.LoadFromFile(fileName);
        config.IsReadedFromDevice = true;
        configEditor.Value = config;
        currentStateView.Value = config;
        planEditor.Value = config.Light;
        planEditor.Value.Scheduler.Set();
        _fileName = fileName;
        ShowCaption();
      }
      catch (Exception ex)
      {
        Box.Error(this, ex);
      }
      SetControlsEnabled();
    }

    ZtpProtocolDriver _driver = null;

    private void _port_DebugReceived(object sender, MessageReceivedEventArgs e)
    {
      AddDebug(e.Message, e.IsEvent);
    }

    /// <summary>
    /// Вывод отладочной информации
    /// </summary>
    /// <param name="message"></param>
    /// <param name="isEvent"></param>
    void AddDebug(string message, bool isEvent)
    {
      if (message.Contains("dbg_off"))
      {
        CloseConnect();
        SetControlsDisabled();
        MessageBox.Show("Клиент был принудительно отключен за бездействие", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      if (string.IsNullOrEmpty(message))
        return;
      message = message.Trim('\r', '\n');
      if (string.IsNullOrEmpty(message))
        return;
      logConsole.WriteDebug(isEvent, message + Environment.NewLine);
    }

    /// <summary>
    /// проверка сессионного пароля
    /// </summary>
    /// <returns></returns>
    bool CheckSessionPassword()
    {
      if (!string.IsNullOrEmpty(_driver.SessionPassword))
        return true;
      using (PasswordForm frm = new PasswordForm())
      {
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          _driver.SessionPassword = frm.Value;
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Вывод информации об успешной записи конфигурации
    /// </summary>
    /// <param name="answer"></param>
    void WriteSuccess(WritePwdAnswer answer)
    {
      logConsole.Info(answer.DisplayMessage);
    }

    void SetConfig(ZtpConfig config)
    {
      config.IsReadedFromDevice = true;
      configEditor.Value = config;
      planEditor.Value = config.Light;
      comPortEditor.Value = config.ComPortSetting;
      currentStateView.Value = config;
    }

    #region Работа с BW
    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      try
      {
        BwResult result = (BwResult)e.Result;
        UnknownError unknown = result.Result as UnknownError;
        if (unknown != null)
          return;

        WritePwdAnswer pwd = result.Result as WritePwdAnswer;
        if (pwd != null && pwd.PwdResult != ZtpProtocol.Ok)
        {
          string errMessage = "Не верный пароль";
          logConsole.Error(errMessage);
          Box.Error(this, errMessage);
          if (_driver != null)
            _driver.SessionPassword = null;
          return;
        }

        switch (result.Action)
        {
          case DeviceActionMode.Read:
            ZtpConfig config;
            ReadConfigAnswer readConfigAnswer = result.Result as ReadConfigAnswer;

            if (readConfigAnswer == null)
              return;

            //if (readConfigAnswer != null)
            //{
            if (readConfigAnswer.Error != null)
              throw readConfigAnswer.Error;
            config = readConfigAnswer.Config;
            //тут мы должны взять данные по нашему устрйоству и определить тип контроллера
            _devType = DevType[config.Version];//GetDeviceType(config);
            configEditor._devType = _devType;
            _devName = _devType.GetFieldAttribute().DisplayName;

            configEditor.RechangeField(_devType);//заменяем панельку EST tools <=> IEC104

            switch(_devType)
            {
              case Device.RVP:
                modBusEditor.Hide();
                configEditor.GsmTechShow(false);
                configEditor.PlanRebootShow(config.SoftVersion.CompareTo("1.1.18") >= 0);
                configEditor.PingIpShow(false);
                break;
              case Device.ULC2:
                modBusEditor.Show();
                configEditor.GsmTechShow(true);
                configEditor.PlanRebootShow(config.SoftVersion.CompareTo("1.0.3") >= 0);
                modbusItemListControl1.max_mb_Tags = (short)((config.SoftVersion.CompareTo("1.0.4") >= 0) ? 100 : 32);
                configEditor.PingIpShow(config.SoftVersion.CompareTo("1.7.0") >= 0);
                configEditor.LogsControlShow(config.SoftVersion.CompareTo("1.7.8") >= 0);
                break;
              case Device.ULC2_2:
                configEditor.GsmTechShow(true);
                configEditor.PlanRebootShow(true);
                configEditor.PingIpShow(true);
                configEditor.LogsControlShow(true);
                break;
            }

            rbBrightToggle.Visible = config.Version.Contains("-DM");

            SetConfig(config);
            ShowCaption();

            _isReaden = true;
            WriteSuccess(WritePwdAnswer.OK);
            if(config.SoftVersion.CompareTo("1.7.9") == 0 && config.DateTimeFirmware.ToString("dd.MM.yyyy HH:mm:ss").CompareTo("17.12.2021 13:50:57") < 0)
            {
              Action(DeviceActionMode.GetCurTraf);
            }
            //}
            break;
          case DeviceActionMode.Write:
            WriteSuccess((WritePwdAnswer)result.Result);
            break;
          case DeviceActionMode.Reboot:
            CloseConnect();
            WriteSuccess((WritePwdAnswer)result.Result);
            break;
          case DeviceActionMode.SetPwd:
            WriteSuccess((WritePwdAnswer)result.Result);
            break;
          case DeviceActionMode.Switch:
            //SwitchOnOffAnswer switchOnOffAnswer = result.Result as SwitchOnOffAnswer;
            WritePwdAnswer switchOnOffAnswer = result.Result as WritePwdAnswer;
            if (switchOnOffAnswer != null)
            {
              //config = configEditor.Value;
              //config.SetSwitchOnOff(switchOnOffAnswer.SwitchOn);
              //config.Light.UseScheduler = false;
              //configEditor.Value = config;
              WriteSuccess(switchOnOffAnswer);
            }
            break;
          case DeviceActionMode.Read_ModBus:
            byte[] data = result.Result as byte[];
            modBusEditor.Value = data;
            WriteSuccess(WritePwdAnswer.OK);
            Action(DeviceActionMode.Read_MB_lbl);
            break;
          case DeviceActionMode.Read_MB_lbl:
            string val = result.Result as string;
            modbusItemListControl1.AssetGzip(val.Trim('\r', '\n'));
            break;
          case DeviceActionMode.Write_ModBus:
            WriteSuccess(WritePwdAnswer.OK);
            Thread.Sleep(2000);
            Action(DeviceActionMode.Write_MB_lbl);
            break;
          case DeviceActionMode.Write_MB_lbl:
            WriteSuccess(WritePwdAnswer.OK);
            break;
          case DeviceActionMode.TestPing:
            string res = result.Result as string;
            if (res.Contains(":OK"))
              MessageBox.Show($"Проверка отклика >> ОК \nАдрес >> {configEditor.GetIpPing} \nIP доступен для устройства", "Ping OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
              MessageBox.Show($"Проверка отклика >> Таймаут \nАдрес >> {configEditor.GetIpPing} \nНет ответа", "Ping FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            break;
          case DeviceActionMode.GetCurTraf:
            string traf = result.Result as string;
            string[] numbers = Regex.Split(traf, @"\D+");
            UInt32 sum = 0;
            foreach(string s in numbers)
            {
              UInt32 num = 0;
              if(UInt32.TryParse(s, out num))
              {
                sum += num;
              }
            }
            currentStateView.ChangeTrafic(sum);
            break;
        }
      }
      catch (Exception ex)
      {
        Box.Error(this, ex);
      }
      finally
      {
        _doAction = false;
        Cursor = Cursors.Default;
        SetControlsEnabled();
      }
    }

    public class BwArg
    {
      public DeviceActionMode Action;
      public ZtpConfig Config;
      public bool SwitchOn;
      public string NewPwd;
      public string LabelListMB;
    }
    public class BwResult
    {
      public DeviceActionMode Action;
      public object Result;
      public BwResult(DeviceActionMode action)
      {
        Action = action;
      }
    }

    public void Action(DeviceActionMode mode, bool switchOn = false, string newPwd = "")
    {
      if (mode == DeviceActionMode.Write || mode == DeviceActionMode.Switch || mode == DeviceActionMode.Reboot || mode == DeviceActionMode.SetPwd
          || mode == DeviceActionMode.Write_ModBus || mode == DeviceActionMode.Write_MB_lbl)
      {
        if (!CheckSessionPassword())
          return;
      }
      try
      {
        BwArg arg = new BwArg()
        {
          Action = mode,
          Config = configEditor.Value,
          SwitchOn = switchOn,
          NewPwd = newPwd
        };

        arg.Config.ComPortSetting = comPortEditor.Value;
        if (mode == DeviceActionMode.Write_MB_lbl)
          arg.LabelListMB = modbusItemListControl1.GetGzip();
        if (planEditor.Value != null)
        {
          ZtpScheduler sched = planEditor.Value.Scheduler;
          if (mode == DeviceActionMode.Write)
          {
            Exception e = ZtpScheduler.CheckOverlap(sched, arg.Config.TimeZone, arg.Config.Latitude, arg.Config.Longitude);
            if (e != null)
            {
              Box.Error(this, e);
              return;
            }
          }
          arg.Config.Light = planEditor.Value;
        }
        _doAction = true;
        Cursor = Cursors.WaitCursor;
        bw.RunWorkerAsync(arg);
      }
      catch(FormatException fEx)
      {
        Box.Error(this, fEx);
      }
    }

    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
      BwArg arg = (BwArg)e.Argument;
      BwResult result = new BwResult(arg.Action);
      e.Result = result;
      try
      {
        switch (arg.Action)
        {
          case DeviceActionMode.Write:
            result.Result = _driver.WriteConfig(arg.Config);
            break;
          case DeviceActionMode.Reboot:
            result.Result = _driver.WriteReboot();
            break;
          case DeviceActionMode.Read:
            result.Result = _driver.ReadConfig();
            break;
          case DeviceActionMode.Switch:
            result.Result = _driver.WriteLightOnOff(arg.SwitchOn);
            break;
          case DeviceActionMode.SetPwd:
            result.Result = _driver.WriteSetPassword(arg.NewPwd);
            break;
          case DeviceActionMode.Write_ModBus:
            _driver.WriteModbusConfig(modBusEditor.dat, modBusEditor.dat_size);
            break;
          case DeviceActionMode.Read_ModBus:
            result.Result = _driver.ReadModbusConfig();
            break;
          case DeviceActionMode.Write_MB_lbl:
            result.Result = _driver.WriteMBLabels(arg.LabelListMB);
            break;
          case DeviceActionMode.Read_MB_lbl:
            result.Result = _driver.ReadMBLabels();
            break;
          case DeviceActionMode.TestPing:
            result.Result = _driver.TestPing(configEditor.GetIpPing);
            break;
          case DeviceActionMode.BrightToggle:
            result.Result = _driver.BrightToggle();
            break;
          case DeviceActionMode.GetCurTraf:
            result.Result = _driver.GetCurTrafic();
            break;
        }
      }
      catch (Exception ex)
      {
        result.Result = new UnknownError() { Message = ex.Message };
        logConsole.Error(ex);
        AsyncError(ex.Message);
      }
    }

    class UnknownError
    {
      public string Message { get; set; }
    }

    void AsyncError(string message)
    {
      if (InvokeRequired)
      {
        BeginInvoke(new Action<string>(AsyncError), message);
        return;
      }
      Box.Error(this, message);
    }
    #endregion

    #region Управление соединением с устройством
    /// <summary>
    /// Открытие соединения с устройством
    /// </summary>
    void OpenConnect()
    {
      logConsole.Info("Открытие порта");
      Application.DoEvents();
      _driver?.Close();
      try
      {
        _driver = new ZtpProtocolDriver(logConsole,
          Setting.Default.LastPortKind,
          () => Setting.Default.ComPortSettings,
          () => Setting.Default.TcpPortSettings);

        _driver.Open();
        _driver.DebugReceived += _port_DebugReceived;
        _driver.StartListener();
        _driver.ChangeState += _driver_ChangeState;
        _driver.Disconnected += _driver_Disconnected;
        ZtpConfig config = configEditor.Value;
        config.IsReadedFromDevice = false;
        configEditor.Value = config;
        logConsole.Info("Порт открыт");
      }
      catch (Exception ex)
      {

        //nLogger.Error(ex, $"Ошибка подключения");
        _driver = null;
        Box.Error(this, ex);
      }
    }

    /// <summary>
    /// Событие закрытия соединения
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void _driver_Disconnected(object sender, LostConnectEventArgs e)
    {
      CloseConnect();
      BeginInvoke(new Action(SetControlsEnabled));
      AsyncError("Сервер закрыл подключение");
    }

    /// <summary>
    /// Команда закрыть текущее соединение
    /// </summary>
    void CloseConnect()
    {
      logConsole.Info("Закрытие порта");
      Application.DoEvents();
      if (_driver != null)
      {
        _driver.ChangeState -= _driver_ChangeState;
        if (_driver.IsOpen)
        {
          _driver?.StopListener();
        }
        _driver.DebugReceived -= _port_DebugReceived;
      }

      _driver?.Close();
      _driver = null;
      logConsole.Info("Порт закрыт");
      _devType = Device.Unknown;
      configEditor._devType = _devType;
      modBusEditor.ViewReset();
      modBusEditor.Hide();
      rbBrightToggle.Visible = false;
      try
      {
        if (!configEditor.InvokeRequired)
        {
          configEditor.PlanRebootShow(false);
          configEditor.PingIpShow(false);
          configEditor.GsmTechShow(false);
          configEditor.LogsControlShow(false);
        }
        else
        {
          configEditor.Invoke(new Action(() => configEditor.PlanRebootShow(false)));
          configEditor.Invoke(new Action(() => configEditor.PingIpShow(false)));
          configEditor.Invoke(new Action(() => configEditor.GsmTechShow(false)));
          configEditor.Invoke(new Action(() => configEditor.LogsControlShow(false)));
        }
      }
      catch (Exception e)
      {
        //MessageBox.Show("хм");
      }
      //_driver.Disconnected
    }
    #endregion


    private void _driver_ChangeState(Protocol.Event.ZtpEvent state)
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
            SetControlsEnabled();
          }
          if(((ZtpEventDout)state).Ord == 10)
          {
            configEditor.Value.IsHalfBright = !configEditor.Value.IsHalfBright;
            SetControlsEnabled();
          }
          currentStateView.SetDout(((ZtpEventDout)state).Ord, ((ZtpEventDout)state).Value);
          break;
      }
    }

    void SetControlsEnabled()
    {
      rbOpenClose.Enabled = !_doAction;
      rbRead.Enabled = rbReboot.Enabled = rbChangePwd.Enabled = _driver != null && !_doAction;

      ZtpConfig config = configEditor.Value;

      rbWrite.Enabled = rbLight.Enabled = rbBrightToggle.Enabled = _driver != null && config.IsReadedFromDevice && !_doAction;
      rbFota.Enabled = _driver != null && _isReaden && !_doAction && _driver.Kind == PortKind.Tcp;

      rbUpFile.Enabled = _driver != null && _isReaden && _driver.Kind == PortKind.Tcp && _devType == Device.ULC2;

      if (config.IsSwitchOn)
      {
        rbLight.Text = "Выключить освещение";
        rbLight.SmallImage = Ztp.Properties.Resources.lightbulb_off;
        rbLight.Tag = false;
      }
      else
      {
        rbLight.Text = "Включить освещение";
        rbLight.SmallImage = Ztp.Properties.Resources.lightbulb;
        rbLight.Tag = true;
      }


      if (rbBrightToggle.Enabled && config.Version.Contains("-DM"))
      {
        rbBrightToggle.Enabled = config.IsSwitchOn;

        rbBrightToggle.Image = (config.IsSwitchOn == false && !config.IsHalfBright) 
          ? Ztp.Properties.Resources.bright_50 
          : Ztp.Properties.Resources.bright_100;
      }

      rbOpenClose.Text = (_driver == null) ? "Открыть порт" : "Закрыть порт";
      rbOpenClose.Image = (_driver == null)
        ? Ztp.Properties.Resources.gear_connection
        : Ztp.Properties.Resources.gear_error;

      sslPort.Text = (_driver == null) ? "Порт закрыт" : $"Порт открыт: {_driver.DisplayName}";

      bool showSchedule = tcConfig.SelectedTab == tpConfigSched;
      rbAddSeason.Enabled = showSchedule && planEditor.SeasonAddEnabled;
      rbDeleteSeason.Enabled = showSchedule && planEditor.SeasonDeleteEnabled;
      rbEditSeason.Enabled = showSchedule && planEditor.SeasonEditEnabled;
      rbAddSchedule.Enabled = showSchedule && planEditor.ScheduleAddEnabled;
      rbDeleteSchedule.Enabled = showSchedule && planEditor.ScheduleDeleteEnabled;
      rbEditSchedule.Enabled = showSchedule && planEditor.ScheduleEditEnabled;
      rbShowSched.Enabled = showSchedule && planEditor.ScheduleShowEnabled;
    }

    /// <summary>
    /// Функция закрытия соединения при бездействии (для ULC)
    /// </summary>
    void SetControlsDisabled()
    {
      rbRead.Enabled = rbReboot.Enabled = rbChangePwd.Enabled = false;
      rbWrite.Enabled = rbLight.Enabled = false;
      rbFota.Enabled = false;
      rbOpenClose.Text = (_driver == null) ? "Открыть порт" : "Закрыть порт";
      rbOpenClose.Image = (_driver == null)
        ? Ztp.Properties.Resources.gear_connection
        : Ztp.Properties.Resources.gear_error;

      sslPort.Text = (_driver == null) ? "Порт закрыт" : $"Порт открыт: {_driver.DisplayName}";

      bool showSchedule =
      rbAddSeason.Enabled =
      rbDeleteSeason.Enabled =
      rbEditSeason.Enabled =
      rbAddSchedule.Enabled =
      rbDeleteSchedule.Enabled =
      rbEditSchedule.Enabled = rbShowSched.Enabled = false;
    }

    private void tcConfig_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetControlsEnabled();
    }

    void ShowState(bool show)
    {
      splitContainerState.Panel2Collapsed = !show;
    }

    void ShowDebug(bool show)
    {
      splitContainer.Panel2Collapsed = !show;
    }

    private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
    {
      Setting.Default.SplitterDistance = splitContainer.SplitterDistance;
      Setting.Default.Save();
    }

    private void splitContainerState_SplitterMoving(object sender, SplitterCancelEventArgs e)
    {
      Setting.Default.StateSplitterDistance = splitContainerState.SplitterDistance;
      Setting.Default.Save();
    }

    private void Frm_FotaStarted(object sender, EventArgs e)
    {
      CloseConnect();
      Application.DoEvents();
      SetControlsEnabled();
    }

    private void rbUpFile_Click(object sender, EventArgs e)
    {
      if (!CheckSessionPassword())
        return;
      using (FileUploadForm frm = new FileUploadForm())
      {
        frm.Address = Setting.Default.TcpPortSettings.IpAddress;
        frm.PackageSize = Setting.Default.FotaPackageSize;
        frm.Driver = _driver;
        frm.UploadStarted += Frm_FotaStarted;
        DialogResult dr = DialogResult.None;
        if ((dr = frm.ShowDialog(this)) == DialogResult.OK)
          Box.Info(this, "Файл успешно загружен в память устройства");
        else if(dr == DialogResult.Cancel)
          Box.Info(this, "Отменено пользователем");
        frm.UploadStarted -= Frm_FotaStarted;
      }
    }

    private void rbBrightToggle_Click(object sender, EventArgs e)
    {
      Action(DeviceActionMode.BrightToggle);
    }
  }
}
