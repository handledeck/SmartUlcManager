using InterUlc.Db;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uart.Function;
using UlcWin.Controls.Modules;
using UlcWin.DB;
using UlcWin.Devices;
using UlcWin.Fota;
using UlcWin.win;
using Ztp.Configuration;
using Ztp.Enums;
using Ztp.Protocol;
using Ztp.Ui;

using static UlcWin.LoadForm;

namespace UlcWin.ui
{
  public partial class SettingEditForm : Form
  {
    //string __default = "APN:vpn2.mts.by USER:vpn PASS:gsd9drekj5 DT:1486391398 DEBOUNCE:110 DEBUG:0 EST:1 IP:15;10;20;1 TCP:3080 TSEND:1 DBZ:1 AIN:1 DIN:15 DOUT:1 DOOR:15 LATIT:55.191 LONGIT:30.125 TZ:3 NUM:1 SERIAL:9600,8,0,1 TMSET:00:30 IPP:255.255.255.255 PERP:1 LOGSLVL:0 RAS:1 SCHED:EQEBDB8BAwAeABQ==";
    string __messgage;
    ZtpConfig __ztpConfig = null;
    DbReader __db = null;
    GetConnectionDelegate __getConnection = null;
    string __name_object = string.Empty;
    List<ListViewItem> __items_checked;
    string __command = string.Empty;
    bool __multiWrite = false;
    Ztp.Enums.Device __device = Ztp.Enums.Device.Unknown;
    public ItemIp __selItem;
    public byte[] __uart_array;
    public List<string> __mbLbl = null;
    LoadForm __loadForm = null;
    byte[] __forwards = null;
    public SettingEditForm(string message, List<ListViewItem> items_checked,
      GetConnectionDelegate getConnection, bool multiWrite, Ztp.Enums.Device device, ItemIp selItem, DbReader db)
      : this(message, getConnection, multiWrite, device, selItem, db,null)
    {
      this.__db = db;
      this.__items_checked = items_checked;
      __multiWrite = multiWrite;
      this.__selItem = selItem;
      this.ethernetModule1.ParentsForm = this;
    }

   

    public void SetUartArray(byte[] vs,List<string> vs1) {
      this.__uart_array = vs;
      this.__mbLbl = vs1;
      this.usrUartModule1.Value = this.__uart_array;
      this.usrUartModule1.ListMBLabel = vs1;  
      
    }

    void SetConfigSettings(Ztp.Enums.Device device)
    {
      __ztpConfig = Ztp.Protocol.ZtpProtocol.DeserializeZtpConfig(__messgage);
      __config._devType = Ztp.Enums.Device.RVP;
      __config.Value = __ztpConfig;

      // __config.Value = __ztpConfig;
      if (__config._devType == Ztp.Enums.Device.RVP)
      {

      }

      __config.Update();
      __planEditor.Value = __ztpConfig.Light;

      __comPortEditor.Value = __ztpConfig.ComPortSetting;
      if (!this.__multiWrite)
        __currentStateViewControl.Value = __ztpConfig;

      this.__planEditor.UseSchedulerVisible = true;

      if (this.__planEditor.UseSchedulerEnable)
      {
        this.__planEditor.UseSchedulerEnable = true;
      }
      else
      {
        this.__planEditor.UseSchedulerEnable = false;
      }
    }

    void SetRVPConfigDevice()
    {
      //__config._devType = __device;
      __config.GsmTechShow(true);
      __config.ShowApnProperty = false;
      __config.PingIpShow(false);
      __config.PlanRebootShow(false);
      __config.LogsControlShow(false);
      __config.RechangeField(Ztp.Enums.Device.RVP);

      //this.__modbusItemList.Enabled = false;
      //this.__modBusSettings.Enabled = false;
      __planEditor.Value = __ztpConfig.Light;
      __planEditor.UseSchedulerVisible = true;
      __comPortEditor.Value = __ztpConfig.ComPortSetting;
    }

    void SetUlcConfigDevice()
    {
      //__config._devType = __device;
      __config.GsmTechShow(true);
      __config.ShowApnProperty = false;
      __config.PingIpShow(true);
      __config.PlanRebootShow(true);
      __config.LogsControlShow(true);
      __config.RechangeField(Ztp.Enums.Device.ULC2);
      //this.__modbusItemList.Enabled = true;
      //this.__modBusSettings.Enabled = true;
      __planEditor.Value = __ztpConfig.Light;
      __planEditor.UseSchedulerVisible = true;
      __comPortEditor.Value = __ztpConfig.ComPortSetting;
      //this.__modBusSettings.TagTableVisible += ModBusSettingsEditorControl1_TagTableVisible;
      //this.__modBusSettings.Download += __modBusSettings_Download;
      //this.__modBusSettings.Upload += __modBusSettings_Upload;
     // this.__modBusSettings.getCollectionFromTable += __modBusSettings_getCollectionFromTable;
     // this.__modBusSettings.getStringsTable += __modBusSettings_getStringsTable;
     // this.__modBusSettings.getGzipLabel += __modBusSettings_getGzipLabel;
      //this.__modBusSettings.LoadMBLabels += __modBusSettings_LoadMBLabels;
    //  this.__modbusItemList.Enabled = false;
    //  this.__modBusSettings.TagTableVisible += __modBusSettings_TagTableVisible;
    }

    void InitConfig()
    {
      __config.Value = __ztpConfig;
      __currentStateViewControl.Value = __ztpConfig;
      ZtpConfig config = __config.Value;
      if (ControllerType.GetControllerType(config.Version) != EnumTypeController.ULC2Lite)
      {
        this.TabsController.TabPages.Remove(this.TabsController.TabPages[3]);
      }
      else {
        ethernetModule1.Value = __forwards;
        ethernetModule1.ParentsForm=this;
      }
      if (config.IsSwitchOn)
      {
        PicLightSwitcher.Image = UlcWin.Properties.Resources.lightbulb;
        btnLightSwitcher.Text = "Отключить освещение";
      }
      else
      {
        PicLightSwitcher.Image = UlcWin.Properties.Resources.lightbulb_off;
        btnLightSwitcher.Text = "Включить освещение";
      }
      switch (__device)
      {
        case Ztp.Enums.Device.Unknown:
          break;
        case Ztp.Enums.Device.RVP:
          SetRVPConfigDevice();
          break;
        case Ztp.Enums.Device.ULC2:
        case Ztp.Enums.Device.ULC2Lite:
          SetUlcConfigDevice();
          break;
        default:
          break;
      }
    }

    protected override void OnShown(EventArgs e)
    {
      //__config.Dock = DockStyle.Fill;
      //__currentStateViewControl.Dock = DockStyle.Fill;
      InitConfig();

      this.tableLayoutPanel2.Controls.Add(__config);
      this.tableLayoutPanel2.Controls.Add(__currentStateViewControl);
      this.TabSerialPort.Controls.Add(__comPortEditor);
      __loadForm = (LoadForm)this.Tag;
      if (this.__selItem.UType == 0)
        this.usrUartModule1.Enabled = false;
      else {
        this.usrUartModule1.Enabled = true;
        this.usrUartModule1.Value = __uart_array;
      }
      this.usrUartModule1.btnBinRead_Click();
      this.usrUartModule1.ParentsForm = this;
      base.OnShown(e);
      this.usrUartModule1.InitCB();
      this.ethernetModule1.InitCB();
    }

    public SettingEditForm(string message, GetConnectionDelegate getConnection, bool multiWrite,
      Ztp.Enums.Device device, ItemIp selItem, DbReader db, byte[] forwards)
    {
      InitializeComponent();
      this.btnSave.Visible = true;
      this.btnFile.Visible = false;
      this.__selItem = selItem;
      this.__name_object = __selItem.Name;
      this.__db = db;
     this.__forwards = forwards;
      this.__messgage = message;
      __ztpConfig = Ztp.Protocol.ZtpProtocol.DeserializeZtpConfig(__messgage);
      device= CtrlType.GetControllerType(__ztpConfig.Version);
      this.__device = device;
      this.__config._devType = device;
      Application.Idle += Application_Idle;
      this.__getConnection = getConnection;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      if (this.__planEditor.SeasonAddEnabled)
        this.btnAddSeason.Enabled = true;
      else
        this.btnAddSeason.Enabled = false;
      if (this.__planEditor.SeasonEditEnabled)
        this.btnChangeSeason.Enabled = true;
      else
        this.btnChangeSeason.Enabled = false;
      if (this.__planEditor.SeasonDeleteEnabled)
        this.btnReamoveSeason.Enabled = true;
      else
        this.btnReamoveSeason.Enabled = false;
      if (this.__planEditor.ScheduleAddEnabled)
        this.btnScheduleAdd.Enabled = true;
      else
        this.btnScheduleAdd.Enabled = false;
      if (this.__planEditor.ScheduleEditEnabled)
        this.btnScheduleEdit.Enabled = true;
      else
        this.btnScheduleEdit.Enabled = false;
      if (this.__planEditor.ScheduleDeleteEnabled)
        this.btnScheduleDelete.Enabled = true;
      else
        this.btnScheduleDelete.Enabled = false;

    }

    private void btnAddSeason_Click(object sender, EventArgs e)
    {
      __planEditor.DoSeasonAdd();


    }

    private void btnReamoveSeason_Click(object sender, EventArgs e)
    {
      __planEditor.DoSeasonDelete();

    }

    private void btnChangeSeason_Click(object sender, EventArgs e)
    {
      __planEditor.DoSeasonEdit();

    }

    private void btnScheduleAdd_Click(object sender, EventArgs e)
    {
      __planEditor.DoScheduleAdd();
    }

    private void btnScheduleEdit_Click(object sender, EventArgs e)
    {
      __planEditor.DoScheduleEdit();
    }

    private void btnScheduleDelete_Click(object sender, EventArgs e)
    {
      __planEditor.DoScheduleDelete();

    }

    private void btnChancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
    string __pwd = string.Empty;
    public bool CheckSessionPassword()
    {

      using (PasswordForm frm = new PasswordForm())
      {
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          this.__pwd = frm.Value;
          return true;

        }
      }
      return false;
    }

    private void btnReboot_Click(object sender, EventArgs e)
    {
      if (CheckSessionPassword())
      {
        string command = ZtpProtocol.RebootCommand(this.__pwd);
        SimpleWaitForm siForm = null;
        TcpClient client = null;
        using (siForm = new SimpleWaitForm(new Action(() =>
        {

          try
          {
            siForm.SetHeaderText("Перрезагрузка контроллера");
            siForm.SetLabelText(string.Format("Соединяюсь с {0}-{1}", __name_object, this.__ztpConfig.IpOwn));
            client = this.__getConnection(this.__ztpConfig.IpOwn, 10251);
            if (client == null)
              throw new Exception("Ошибка соединения...");
            NetworkStream stream = client.GetStream();
            byte[] bCfg = System.Text.ASCIIEncoding.ASCII.GetBytes(command);
            stream.Write(bCfg, 0, bCfg.Length);
            siForm.SetLabelText(string.Format("Запись перезагрузки {0}-{1}", __name_object, this.__ztpConfig.IpOwn));
            int len = stream.Read(bCfg, 0, bCfg.Length);
            if (len > 0)
            {
              string answ = System.Text.ASCIIEncoding.ASCII.GetString(bCfg, 0, len);
              if (answ.Equals("PWD:OK\r\n"))
              {

                siForm.DialogResult = DialogResult.OK;
              }
              else
              {
                throw new Exception("Ошибка записи в устройство");
              }
            }
            else
            {
              throw new Exception("Ошибка чтения...");
            }
          }
          catch 
          {
            siForm.DialogResult = DialogResult.Cancel;
          }
          finally
          {
            if (client != null)
              client.Close();
          }
        })))
        {
          DialogResult res = siForm.ShowDialog();
          if (res == DialogResult.OK)
          {
            MessageBox.Show("Контроллер отправлен на перезагрузку", "Перезагрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
          }
          else
          {
            MessageBox.Show("Ошибка получения ответа на перезагрузку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }

    }

    void SingleSettingWrite()
    {

      if (CheckSessionPassword())
      {
        __ztpConfig = __config.Value;
        __ztpConfig.ComPortSetting = this.__comPortEditor.Value;
        __ztpConfig.Light = this.__planEditor.Value;

        ZtpScheduler sched = __planEditor.Value.Scheduler;
        Exception ex = ZtpScheduler.CheckOverlap(sched, __ztpConfig.TimeZone,
          __ztpConfig.Latitude, __ztpConfig.Longitude);
        if (ex != null)
        {
          MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
        __command = ZtpProtocol.SetConfigCommand(__pwd, __ztpConfig);

        SimpleWaitForm siForm = null;
        TcpClient client = null;
        int cbIndex = this.usrUartModule1.cbFunction.SelectedIndex;
        using (siForm = new SimpleWaitForm(new Action(() =>
        {

          try
          {
            siForm.SetLabelText(string.Format("Соединяюсь с {0}-{1}", __name_object, this.__ztpConfig.IpOwn));
            client = this.__getConnection(this.__ztpConfig.IpOwn, 10251);
            if (client == null)
              throw new Exception("Ошибка соединения...");
            NetworkStream stream = client.GetStream();
            byte[] bCfg = System.Text.ASCIIEncoding.ASCII.GetBytes(__command);
            stream.Write(bCfg, 0, bCfg.Length);
            siForm.SetLabelText(string.Format("Запись конфигурации {0}-{1}", __name_object, this.__ztpConfig.IpOwn));
            int len = stream.Read(bCfg, 0, bCfg.Length);
            if (len > 0)
            {
              string answ = System.Text.ASCIIEncoding.ASCII.GetString(bCfg, 0, len);
              if (answ.Equals("PWD:OK\r\n"))
              {
                siForm.DialogResult = DialogResult.OK;
                DbLogMsg dbLogMsg = new DbLogMsg()
                {
                  id = __selItem.Id,
                  tp = __selItem.Name
                };
                DbLogMsg.ParseNodePath(__selItem.NodeFullPath, ref dbLogMsg);
                string msg = System.Text.Json.JsonSerializer.Serialize(dbLogMsg, typeof(DbLogMsg), DbLogMsg.GetSerializeOption());
                __db.LogsInsertEvent(DB.EnLogEvt.SETTING_CHANGE, msg, __selItem.Id);
              }
              else
              {
                throw new Exception("Ошибка записи конфигурации в устройство");
              }
            }
            else
            {
              throw new Exception("Ошибка записи конфигурации в устройство");
            }
            ///Запись UART настроек
            ///
            Exception e= usrUartModule1.WriteExpandUart(client, __pwd, cbIndex);
            if (ControllerType.GetControllerType(this.__ztpConfig.Version) == EnumTypeController.ULC2Lite) {
              e = EthernetItem.WriteEternetSettings(client, __pwd, this.txtIp.Text,
                    this.txtGateway.Text,this.txtMask.Text, ethernetModule1.DataSet.Tables[0]);
            }
            
            if (e != null)
              throw e;
          }
          catch(Exception exc)
          {
            MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            siForm.DialogResult = DialogResult.Cancel;
          }
          finally
          {
            if (client != null)
              client.Close();
          }
        })))
        {
          DialogResult res = siForm.ShowDialog();
          if (res == DialogResult.OK)
          {
            MessageBox.Show("Конфигурация обновлена", "Запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
    }



    void SetSettingsMultiWrite()
    {

      __ztpConfig = __config.Value;
      __ztpConfig.ComPortSetting = this.__comPortEditor.Value;
      __ztpConfig.Light = this.__planEditor.Value;
      ZtpScheduler sched = __planEditor.Value.Scheduler;
      Exception ex = ZtpScheduler.CheckOverlap(sched, __ztpConfig.TimeZone,
        __ztpConfig.Latitude, __ztpConfig.Longitude);
      if (ex != null)
      {
        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      __command = ZtpProtocol.SetConfigCommand(__pwd, __ztpConfig);
      UlcWin.win.WaitForm wFrm = null;
      using (wFrm = new win.WaitForm(new Action(() =>
      {
        foreach (ListViewItem item in this.__items_checked)
        {
          Task tsk = new Task(new Action<object>((oItem) =>
          {
            ListViewItem itL = (ListViewItem)oItem;
            ItemIp itip = (ItemIp)itL.Tag;
            TcpClient client = null;
            try
            {

              client = this.__getConnection(itip.Ip, 10251);//new TcpClient(item.IP, 10251);
              if (client == null)
                throw new Exception(string.Format("Error connect to:{0}", itip.Ip));
              NetworkStream stream = client.GetStream();
              stream.ReadTimeout = 15000;
              byte[] bCfg = System.Text.ASCIIEncoding.ASCII.GetBytes(__command);
              stream.Write(bCfg, 0, bCfg.Length);
              int len = stream.Read(bCfg, 0, bCfg.Length);
              if (len > 0)
              {
                string answ = System.Text.ASCIIEncoding.ASCII.GetString(bCfg, 0, len);
                if (answ.Equals("PWD:OK\r\n"))
                {
                  wFrm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, true, itip.UType, 0);
                  __db.LogsInsertEvent(DB.EnLogEvt.SETTING_CHANGE, __command, itip.Id);
                }
                else if (answ.Equals("PWD:ERROR\r\n"))
                {
                  wFrm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, itip.UType, 7);
                }
                else
                {
                  wFrm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, itip.UType, 6);
                }
              }
              else
              {
                wFrm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, itip.UType, 6);
              }
            }
            catch
            {
              wFrm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, itip.UType, 1);
            }
            finally
            {
              if (client != null)
              {
                client.Close();
              }
            }
          }), item);
          tsk.Start();
        }

      }), StateWaitForm.StateOverSimple))
      {
        wFrm.ShowDialog();
      }
    }




    private void btnOk_Click(object sender, EventArgs e)
    {
      if (!this.__multiWrite)
      {
        
        this.SingleSettingWrite();
      }
      else
      {
        SetSettingsMultiWrite();
      }

    }

    TcpClient GetTcpConnection(string ip)
    {
      TcpClient client = null;
      for (int i = 0; i < 2; i++)
      {
        try
        {
          client = this.__getConnection(this.__ztpConfig.IpOwn, 10251);
          if (i > 0)
            break;
          if (__device == Ztp.Enums.Device.ULC2)
          {
            break;
          }
          else if (__device == Ztp.Enums.Device.RVP)
          {
            if (client != null)
              client.Close();
            Thread.Sleep(1000);
          }
        }
        catch (Exception)
        {
          break;
        }
      }
      return client;
    }


    void getConfig(bool show_upapdate = true, NetworkStream stream = null)
    {
      SimpleWaitForm siForm = null;
      byte[] buffer = new byte[1024];

      using (siForm = new SimpleWaitForm(new Action(() =>
      {
        byte[] bCfg = System.Text.ASCIIEncoding.ASCII.GetBytes("CONFIG?\r");
        try
        {
          siForm.SetLabelText(string.Format("Соединяюсь с {0}-{1}", __name_object, this.__ztpConfig.IpOwn));
          //client = this.__getConnection(this.__ztpConfig.IpOwn, 10251);
          if (stream == null)
          {
            TcpClient client = GetTcpConnection(this.__ztpConfig.IpOwn);
            if (client == null)
              throw new Exception("Ошибка соединения...");
            stream = client.GetStream();
            stream.ReadTimeout = 10000;
          }
          stream.Write(bCfg, 0, bCfg.Length);
          siForm.SetLabelText(string.Format("Чтение конфигурации {0}-{1}", __name_object, this.__ztpConfig.IpOwn));
          bool read = false;
          for (int i = 0; i < 2; i++)
          {
            int len = stream.Read(buffer, 0, buffer.Length);
            if (len > 0)
            {
              string message = System.Text.ASCIIEncoding.ASCII.GetString(buffer, 0, len);
              if (!string.IsNullOrEmpty(message))
              {
                if (message.StartsWith("CONFIG") && message[message.Length - 1] == '\n')
                {
                  __messgage = message;
                  __ztpConfig = Ztp.Protocol.ZtpProtocol.DeserializeZtpConfig(message);
                  byte[] pack = new byte[1024];
                  string command = ZtpProtocol.GetModbusConfig();
                  byte[] buff = ZtpProtocol.ToBytes(command);
                  stream.Write(buff, 0, buff.Length);
                  len = stream.Read(pack, 0, pack.Length);
                  string msg = System.Text.ASCIIEncoding.ASCII.GetString(pack, 0, len);
                  msg = msg.Trim('\r', '\n');
                  string[] keyValue = msg.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                  buffer = Convert.FromBase64String(keyValue[1]);
                  this.usrUartModule1.SetUartArray(buffer);
                  read = true;
                  //siForm.DialogResult = DialogResult.OK;
                  break;
                }
              }
            }
            else
            {
              throw new Exception("Ошибка чтения...");
            }
          }
          if (!read)
            siForm.DialogResult = DialogResult.Cancel;
          else
            siForm.DialogResult = DialogResult.OK;
        }
        catch
        {
          siForm.DialogResult = DialogResult.Cancel;
        }
        finally
        {
          if (stream != null)
          {
            stream.Close();
          }
          //if (client != null)
          //  client.Close();
        }
      })))
      {
        DialogResult res = siForm.ShowDialog();
        if (res == DialogResult.OK)
        {
          InitConfig();
          if (show_upapdate)
            MessageBox.Show("Конфигурация обновлена", "Запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
          MessageBox.Show("Ошибка чтения конфигурации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }

    }


    private void btnSave_Click(object sender, EventArgs e)
    {
      byte[] buffer = null;
      List<string> lstLbl = null;
      string message=null;
      byte[] forward=null;
      using (SimpleWaitForm sfrm = new SimpleWaitForm())
      {
        sfrm.RunAction(new Action(() =>
        {
          TcpClient client = null;
          try
          {
            sfrm.SetLabelText("Обновление данных...");
            client = __loadForm.GetConnection(__selItem.Ip, 10251);
            if (client != null)
            {
              if (!__loadForm.GetConfigIP(client, out message, out buffer, out lstLbl, out forward)) {
                throw new Exception("Ошибка обновления данных");
              }
            }
            this.usrUartModule1.Value = buffer;
            this.usrUartModule1.ListMBLabel = lstLbl;
            this.usrUartModule1.SetUartArray(buffer, lstLbl);
            this.ethernetModule1.Value = forward;
            this.BeginInvoke(new Action(() => { this.ethernetModule1.InitCB(); }));
            
            //getConfig();
            sfrm.DialogResult = DialogResult.OK;
          }
          catch
          {
            sfrm.DialogResult = DialogResult.Cancel;

          }
          finally
          {
            if (client != null)
              client.Close();
          }
        }));
        DialogResult result = sfrm.ShowDialog();
      }
    }

    private void btnFile_Click(object sender, EventArgs e)
    {
      openFileDialog1.Filter = "Bin files(*.bin)|*.bin";
      string drFileSettings = Application.StartupPath + "\\gnSettings";
      if (!Directory.Exists(drFileSettings))
      {
        Directory.CreateDirectory(drFileSettings);
      }
      saveFileDialog1.InitialDirectory = drFileSettings;

      if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
        return;
      FileStream stream = (FileStream)openFileDialog1.OpenFile();
      byte[] bStream = new byte[stream.Length];
      int len = stream.Read(bStream, 0, bStream.Length);
      this.__messgage = string.Format("CONFIG:{0}", System.Text.ASCIIEncoding.ASCII.GetString(bStream, 0, len));
      stream.Close();
      //SetConfigSettings();
      this.Update();
    }



    private void pictureBox1_Click(object sender, EventArgs e)
    {
      string str =
          "При ручном режиме управления освещением расписания освещения будут отключены. Для их повторного включения установите флажок 'Активность планов освещения' и запишите конфигурацию в контроллер\r\n";
      DialogResult result= MessageBox.Show(str,"Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
      if (result == DialogResult.No)
        return;
      if (string.IsNullOrEmpty(__pwd))
      {
        using (PasswordForm frm = new PasswordForm())
        {
          if (frm.ShowDialog(this) == DialogResult.OK)
          {
            this.__pwd = frm.Value;
          }
          else
          {
            return;
          }
        }
      }
      SimpleWaitForm sf = null;
      using (sf = new SimpleWaitForm(new Action(() =>
    {
      TcpClient client = null;
      string command = ZtpProtocol.LightSwitchOnOffCommand(this.__pwd, !__ztpConfig.IsSwitchOn);
      try
      {
        sf.SetLabelText(string.Format("Запись в контроллер {0}-{1}", __name_object, this.__ztpConfig.IpOwn));
        client = GetTcpConnection(__ztpConfig.IpOwn);
        NetworkStream stream = client.GetStream();
        stream.ReadTimeout = 10000;
        byte[] bSend = System.Text.ASCIIEncoding.ASCII.GetBytes(command);
        byte[] bRead = new byte[1024];
        stream.Write(bSend, 0, bSend.Length);
        int len = stream.Read(bRead, 0, bRead.Length);
        if (len > 0)
        {
          string answer = System.Text.ASCIIEncoding.ASCII.GetString(bRead, 0, len);
          if (!answer.Contains("PWD:OK"))
          {
            __pwd = "";
            throw new Exception("Не верный пароль");
          }
          else
          {
            byte[] bCfg = System.Text.ASCIIEncoding.ASCII.GetBytes("CONFIG?\r");
            sf.SetLabelText(string.Format("Чтение конфигурации {0}-{1}", __name_object, this.__ztpConfig.IpOwn));
            stream.Write(bCfg, 0, bCfg.Length);
            for (int i = 0; i < 2; i++)
            {
              len = stream.Read(bRead, 0, bRead.Length);
              if (len == 0)
                throw new Exception("Ошибка чтения конфигурации");
              string message = System.Text.ASCIIEncoding.ASCII.GetString(bRead, 0, len);
              if (!string.IsNullOrEmpty(message))
              {
                int ind = message.IndexOf("CONFIG");
                if (ind != -1)
                {
                  string msg = message.Substring(ind, message.Length - ind);
                  __messgage = msg;
                  __ztpConfig = Ztp.Protocol.ZtpProtocol.DeserializeZtpConfig(msg);
                  sf.DialogResult = DialogResult.OK;
                  break;
                }
              }
              else
              {
                throw new Exception("Ошибка чтения...");
              }
            }
          }
        }
      }
      catch (Exception exp)
      {
        MessageBox.Show(exp.Message, "Ошибка управления освещением", MessageBoxButtons.OK, MessageBoxIcon.Error);
        sf.DialogResult = DialogResult.Abort;
      }
      finally
      {
        if (client != null)
          client.Close();
      }
    })))
      {
        DialogResult res = sf.ShowDialog();
        if (res == DialogResult.OK)
        {
          InitConfig();
        }
        else
        {
          MessageBox.Show("Ошибка чтения конфигурации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void __modBusSettings_Load(object sender, EventArgs e)
    {

    }

    
    private bool usrUartModule1_EventReadUartData(out byte[] buffer)
    {
      buffer = null;
      TcpClient client = null;
      byte[] pack = new byte[1024];
      string command = ZtpProtocol.GetModbusConfig();
      byte[] buff = ZtpProtocol.ToBytes(command);
      try
      {
        client = this.__getConnection(this.__ztpConfig.IpOwn, 10251);
        if (client == null)
          throw new Exception("Ошибка соединения");
        NetworkStream stream = client.GetStream();
        stream.ReadTimeout = 15000;
        stream.Write(buff, 0, buff.Length);
        int len = stream.Read(pack, 0, pack.Length);
        string msg = System.Text.ASCIIEncoding.ASCII.GetString(pack, 0, len);
        msg = msg.Trim('\r', '\n');
        string[] keyValue = msg.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
        buffer = Convert.FromBase64String(keyValue[1]);
        return true;
      }
      catch
      {
        return false;
        //MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        if (client != null)
          client.Close();
      }
      
    }

    private void usrUartModule1_EventWriteUartData()
    {

    }

    private void usrUartModule1_Load(object sender, EventArgs e)
    {

    }

    private void usrUartModule1_EventHandlerUartData(Uart.UartEvents uartEvents, int index, int rowsCount)
    {
      if (index != 0)
      {
        if (rowsCount == 0)
        {
          this.btnOk.Enabled = false;
        }
        else
        {
          this.btnOk.Enabled = true;
        }
      }
      else {
        this.btnOk.Enabled = true;
      }
    }


    bool IsTextAValidIPAddress(string text) {
      bool result = true;
      string[] values = text.Split(new[] { "." }, StringSplitOptions.None); //keep empty strings when splitting
      result &= values.Length == 4; // aka string has to be like "xx.xx.xx.xx"
      //byte temp;
      if (result)
        for (int i = 0; i < 4; i++)
          result &= byte.TryParse(values[i], out _); //each "xx" must be a byte (0-255)
      return result;
    }

    private void txtIp_Validated(object sender, EventArgs e)
    {
      TextBox textBox = (TextBox)sender;
      bool ipV = IsTextAValidIPAddress(txtIp.Text);
      //IPAddress tmp;
      if (string.IsNullOrEmpty(textBox.Text) || IsTextAValidIPAddress(textBox.Text)/*IPAddress.TryParse(itcIP.Value, out tmp)*/)
      {
        this.errorProvider1.Clear();
        btnOk.Enabled = true;
      }
      else
      {
        textBox.Focus();
        this.errorProvider1.SetError(textBox, "Введите корректный IP адрес или оставте пустую строку если параметр не нужен");
        btnOk.Enabled = false;
      }
    }

    private void txtIp_Validating(object sender, CancelEventArgs e)
    {
      TextBox textBox = (TextBox)sender;
      bool ipV = IsTextAValidIPAddress(txtIp.Text);
      //IPAddress tmp;
      if (string.IsNullOrEmpty(textBox.Text) || IsTextAValidIPAddress(textBox.Text)/*IPAddress.TryParse(itcIP.Value, out tmp)*/)
      {
        this.errorProvider1.Clear();
        btnOk.Enabled = true;
      }
      else
      {
        textBox.Focus();
        this.errorProvider1.SetError(textBox, "Введите корректный IP адрес или оставте пустую строку если параметр не нужен");
        btnOk.Enabled = false;
      }
    }
  }
}
 


  
