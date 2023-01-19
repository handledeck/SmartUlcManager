using InterUlc.Db;
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
using UlcWin.DB;
using UlcWin.Fota;
using UlcWin.ui;
using UlcWin.win;
using Ztp.Configuration;
using Ztp.Protocol;
using Ztp.Ui;
using static UlcWin.LoadForm;

namespace UlcWin
{
  public partial class RequestForm : Form
  {
    //string __default = "APN:vpn2.mts.by USER:vpn PASS:gsd9drekj5 DT:1486391398 DEBOUNCE:110 DEBUG:0 EST:1 IP:15;10;20;1 TCP:3080 TSEND:1 DBZ:1 AIN:1 DIN:15 DOUT:1 DOOR:15 LATIT:55.191 LONGIT:30.125 TZ:3 NUM:1 SERIAL:9600,8,0,1 TMSET:00:30 IPP:255.255.255.255 PERP:1 LOGSLVL:0 RAS:1 SCHED:EQEBDB8BAwAeABQ==";
    string __messgage;
    ZtpConfig __ztpConfig = null;
    DbReader __db = null;
    GetConnectionDelegate __getConnection = null;
    int __tagCount = 0;
    List<ListViewItem> __items_checked;
    string __command = string.Empty;
    byte[] __pkg = null;
    bool __multiWrite = false;
    Ztp.Enums.Device __device = Ztp.Enums.Device.Unknown;
    ItemIp __selItem;
    public RequestForm(string message, List<ListViewItem> items_checked,
      GetConnectionDelegate getConnection, bool multiWrite, Ztp.Enums.Device device, ItemIp selItem, DbReader db) 
      : this(message, getConnection, multiWrite,device, selItem,db)
    {
      this.__db = db;
      this.__items_checked = items_checked;
      __multiWrite = multiWrite;
      this.__selItem = selItem;

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

    void SetRVPConfigDevice() {
      //__config._devType = __device;
      __config.GsmTechShow(true);
      __config.ShowApnProperty = false;
      __config.PingIpShow(false);
      __config.PlanRebootShow(false);
      __config.LogsControlShow(false);
      __config.RechangeField(Ztp.Enums.Device.RVP);

      this.__modbusItemList.Enabled = false;
      this.__modBusSettings.Enabled = false;
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
      this.__modbusItemList.Enabled = true;
      this.__modBusSettings.Enabled = true;
      __planEditor.Value = __ztpConfig.Light;
      __planEditor.UseSchedulerVisible = true;
      __comPortEditor.Value = __ztpConfig.ComPortSetting;
      this.__modBusSettings.TagTableVisible += ModBusSettingsEditorControl1_TagTableVisible;
      this.__modBusSettings.Download += __modBusSettings_Download;
      this.__modBusSettings.Upload += __modBusSettings_Upload;
      this.__modBusSettings.getCollectionFromTable += __modBusSettings_getCollectionFromTable;
      this.__modBusSettings.getStringsTable += __modBusSettings_getStringsTable;
      this.__modBusSettings.getGzipLabel += __modBusSettings_getGzipLabel;
      //this.__modBusSettings.LoadMBLabels += __modBusSettings_LoadMBLabels;
      this.__modbusItemList.Enabled = false;
      this.__modBusSettings.TagTableVisible += __modBusSettings_TagTableVisible;
    }

    void InitConfig() {
      __config.Value = __ztpConfig;
      __currentStateViewControl.Value = __ztpConfig;
      
      switch (__device)
      {
        case Ztp.Enums.Device.Unknown:
          break;
        case Ztp.Enums.Device.RVP:
          SetRVPConfigDevice();
          break;
        case Ztp.Enums.Device.ULC2:
          SetUlcConfigDevice();
          break;
        case Ztp.Enums.Device.ULC2_2:
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
      this.tabPage3.Controls.Add(__comPortEditor);
      base.OnShown(e);
    }

    string __name_object = string.Empty;

    public RequestForm(string message, GetConnectionDelegate getConnection, bool multiWrite,
      Ztp.Enums.Device device, ItemIp selItem , DbReader db)
    {
      InitializeComponent();
      this.btnSave.Visible = true;
      this.btnFile.Visible = false;
      this.__selItem = selItem;
      this.__name_object = __selItem.Name;
      this.__db = db;
      //if (multiWrite)
      //{
      //  this.__currentStateViewControl.Enabled = false;
      //  this.__modbusItemList.Enabled = false;
      //  this.__modBusSettings.Enabled = false;
      //  this.__multiWrite = multiWrite;
      //}
      //else
      //{
      //  this.btnSave.Visible = false;
      //  this.btnFile.Visible = false;
      //}
      this.__messgage = message;
      __ztpConfig = Ztp.Protocol.ZtpProtocol.DeserializeZtpConfig(__messgage);
      this.__device=device;
      this.__config._devType = device;
      //__config._devType = Ztp.Enums.Device.ULC2_2;

      //__config.Value = __ztpConfig;
      //__config._devType = device;
      //__planEditor.Value = __ztpConfig.Light;
      //__comPortEditor.Value = __ztpConfig.ComPortSetting;
      //__currentStateViewControl.Value = __ztpConfig;

      //SetConfigSettings(device);

      Application.Idle += Application_Idle;
      this.__getConnection = getConnection;
      
    }

    private void __modBusSettings_TagTableVisible(bool value)
    {
      //this.__modbusItemList.ClearTable();
    }

    private void __modBusSettings_LoadMBLabels(string input)
    {

    }

    private string __modBusSettings_getGzipLabel()
    {
      return this.__modbusItemList.GetGzip();
    }

    private string[] __modBusSettings_getStringsTable()
    {
      return this.__modbusItemList.GetTableAsStrings();
    }

    private void __modBusSettings_Upload()
    {

      if (CheckSessionPassword())
      {


        SimpleWaitForm siForm = null;
        getMbMassive();
        using (siForm = new SimpleWaitForm(new Action(() =>
        {

          byte[] pack = ZtpProtocol.ModbusSetConfig(__pwd, __pkg, (ushort)__pkg.Length);
          try
          {
            siForm.SetLabelText(string.Format("Соединяюсь с {0}-{1}",this.__name_object, this.__ztpConfig.IpOwn));
            TcpClient client = this.__getConnection(this.__ztpConfig.IpOwn, 10251);
            if (client == null)
              throw new Exception("Ошибка соединения...");
            NetworkStream stream = client.GetStream();
            //byte[] bCfg = System.Text.ASCIIEncoding.ASCII.GetBytes(__command);
            stream.Write(pack, 0, pack.Length);
            siForm.SetLabelText(string.Format("Запись конфигурации {0}-{1}", __name_object, this.__ztpConfig.IpOwn));
            int len = stream.Read(pack, 0, pack.Length);
            if (len > 0)
            {
              string answ = System.Text.ASCIIEncoding.ASCII.GetString(pack, 0, len);
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

        })))
        {
          DialogResult res = siForm.ShowDialog();
          if (res == DialogResult.OK)
          {
            MessageBox.Show("Конфигурация обновлена", "Запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("О", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          //this.Close();

        }
      }


    }



    private byte[] getMbMassive()
    {
      __pkg = new byte[1024];
      ushort dat_size = 0;

      //запись статуса работы с протоколом модбас
      __pkg[dat_size] = (byte)this.__modBusSettings.cbWorkMode.SelectedIndex;
      dat_size++;

      //запись значения периода опроса
      __pkg[dat_size] = (byte)this.__modBusSettings.idPollPeriod.Value;
      dat_size++;

      //формирование групп тегов в массив, в конец добавляется массив 
      // 2хбайтных значений индексов мэк
      byte[] info = __modBusSettings_getCollectionFromTable();// getCollectionFromTable?.Invoke();
      info.CopyTo(__pkg, dat_size);
      dat_size += (ushort)info.Length;
      //Обрезка до нужных размеров массива
      Array.Resize<byte>(ref __pkg, dat_size);
      return __pkg;
    }

    private byte[] __modBusSettings_getCollectionFromTable()
    {
      return this.__modbusItemList.GetTagMassive();
    }

    int InsertListViewTag(byte[] buf)
    {
      int s = 1;
      //buf[s++];
      byte pollPeriod = buf[s++];
      //idPollPeriod.Value = (pollPeriod == 0) ? 1 : pollPeriod;
      Int16 count = BitConverter.ToInt16(buf, s);
      s += 2;
      this.__tagCount = 0;
      int pointToIecIndexStart = 4 + count * 4;
      int pointToDbzIndexStart = pointToIecIndexStart + count * 2;

      for (int i = 0; i < count; i++)
      {
        UInt16 val = BitConverter.ToUInt16(buf, s + 2);
        UInt16 iecIndex = (pointToIecIndexStart + (i * 2) < buf.Length) ?
          BitConverter.ToUInt16(buf, pointToIecIndexStart + i * 2) : (UInt16)0;
        byte dbzVal = ((pointToDbzIndexStart + i) < buf.Length) ?
          buf[pointToDbzIndexStart + i] : (byte)0;
        this.__modbusItemList.addTag(buf[s], buf[s + 1], val, (ushort)iecIndex, dbzVal);
        s += 4;
        this.__tagCount++;
      }

      if (count > 0)
        s += count * 3 + 1;
      else
        s = -1;

      return s;
    }

    private void __modBusSettings_Download()
    {
      this.__modbusItemList.ClearTable();
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
        byte[] buf = Convert.FromBase64String(keyValue[1]);
        this.__modBusSettings.Value = buf;
        if (this.__modBusSettings.cbWorkMode.SelectedIndex != 0)
          this.InsertListViewTag(buf);
      }
      catch (Exception exp)
      {
        MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        if (client != null)
          client.Close();
      }
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

    private void ModBusSettingsEditorControl1_TagTableVisible(bool value)
    {
      if (value)
      {
        this.__modbusItemList.Enabled = true;

      }
      else
      {
        this.__modbusItemList.Enabled = false;
      }
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
          catch(Exception ex)
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
                  Id = __selItem.Id,
                  Tp = __selItem.Name
                };
                DbLogMsg.ParseNodePath(__selItem.NodeFullPath, ref dbLogMsg);
                string msg = System.Text.Json.JsonSerializer.Serialize(dbLogMsg, typeof(DbLogMsg), DbLogMsg.GetSerializeOption());
                __db.LogsInsertEvent(DB.EnLogEvt.SETTING_CHANGE,msg, __selItem.Id);
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
            MessageBox.Show("Конфигурация обновлена", "Запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Ошибка записи конфигурации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    TcpClient GetTcpConnection(string ip) {
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
          else if(__device == Ztp.Enums.Device.RVP)
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

    private void btnSave_Click(object sender, EventArgs e)
    {
      SimpleWaitForm siForm = null;
      byte[] buffer = new byte[1024];
    
      using (siForm = new SimpleWaitForm(new Action(() =>
      {
        TcpClient client = null;
        byte[] bCfg = System.Text.ASCIIEncoding.ASCII.GetBytes("CONFIG?\r");
        try
        {
          siForm.SetLabelText(string.Format("Соединяюсь с {0}-{1}", __name_object, this.__ztpConfig.IpOwn));
          //client = this.__getConnection(this.__ztpConfig.IpOwn, 10251);
          client=GetTcpConnection(this.__ztpConfig.IpOwn);
          if (client == null)
            throw new Exception("Ошибка соединения...");
          NetworkStream stream = client.GetStream();
          stream.ReadTimeout = 10000;
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
          if (client != null)
            client.Close();
        }
      })))
      {
        DialogResult res = siForm.ShowDialog();
        if (res == DialogResult.OK)
        {
          InitConfig();
          MessageBox.Show("Конфигурация обновлена", "Запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
          MessageBox.Show("Ошибка чтения конфигурации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      //saveFileDialog1.Filter = "Bin files(*.bin)|*.bin";
      //string drFileSettings = Application.StartupPath + "\\gnSettings";
      //if (!Directory.Exists(drFileSettings))
      //{
      //  Directory.CreateDirectory(drFileSettings);
      //}
      //saveFileDialog1.InitialDirectory = drFileSettings;

      //if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
      //  return;
      //string filename = saveFileDialog1.FileName;
      //__ztpConfig = __config.Value;
      //__ztpConfig.ComPortSetting = this.__comPortEditor.Value;
      //__ztpConfig.Light = this.__planEditor.Value;
      //ZtpScheduler sched = __planEditor.Value.Scheduler;
      //Exception ex = ZtpScheduler.CheckOverlap(sched, __ztpConfig.TimeZone,
      //  __ztpConfig.Latitude, __ztpConfig.Longitude);
      //if (ex != null)
      //{
      //  MessageBox.Show(ex.Message, "Ошибка расписания", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //  return;
      //}
      //string ztp = ZtpProtocol.SerializeZtpConfig(__ztpConfig);
      //byte[] bSetiings = System.Text.ASCIIEncoding.ASCII.GetBytes(ztp);
      //FileStream wr = new FileStream(filename, FileMode.OpenOrCreate);
      //wr.Write(bSetiings, 0, bSetiings.Length);
      //wr.Flush();
      //wr.Close();
      //MessageBox.Show("Файл сохранен", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

   
  }
}

  
