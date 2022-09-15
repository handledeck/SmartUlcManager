using InterUlc.Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.DB;
using Ztp.Protocol;

namespace UlcWin.Fota
{
  public delegate TcpClient GetConnection(string host, int port);
  public delegate bool GetConfigIP(TcpClient client, out string message);

  public enum EnumCommandUpdate { 
    ProgrammUpdate,
    CoreUpdate
  }

  public partial class FotaForm : Form
  {
    const int _port_prgm = 10255;
    const int _port_patch = 10121;
    const string _end_prgm = "_E_N_D";
    static string _mdm_prgm = "_TELL";
    const string _hash_prgm = "_HASH";
    const string _end_core = "_ENDUPF";
    static string _mdm_core = "_UPF";
    const string _hash_core = "_HASH";
    private string _versionPO = String.Empty;
    private string _dataCompile = String.Empty;
    List<ListViewItem> __list_update;
    GetConnection __getConnection = null;
    GetConfigIP __getConfigIP;
    string __strFlieUpdate = "m2mapz.bin";
    string __strFilePatch = "Delta.bin.env";
    string __strWorkPath = string.Empty;
    //bool __startUpdate = false;
    DateTime __lastModified;
    List<Task> __lstTaskUpdate;
    List<Task> __lstTaskRunner;
    bool __avalbebe_update = false;
    bool __patch = false;
    float __progress_width = 0;
    bool __complite_work = false;
    public FotaForm()
    {
      InitializeComponent();
    

    }

    bool checkCore(ItemIp itemIp)
    {
      if (itemIp.UlcConfig == null)
        return false;
      if (itemIp.UlcConfig.CORV.Equals("12.01.830"))
      {
        return true;
        //fileUpdate = __strWorkPath + "\\12.01.830\\" + __strFilePatch;
      }
      else if (itemIp.UlcConfig.CORV.Equals("12.00.839"))
      {
        return true;
        //fileUpdate = __strWorkPath + "\\12.00.839\\" + __strFilePatch;
      }
      else
      {
        return false;
      }
    }

    void SetInvalidteItem(ListViewItem lsItem,int subItem, string text,Color color) {
      lsItem.UseItemStyleForSubItems = false;
      lsItem.SubItems[subItem].ForeColor = color;
      lsItem.SubItems[subItem].Text = text;
    }

    private void FotaForm_Shown(object sender, EventArgs e)
    {

      string path = Application.ExecutablePath;
      __strWorkPath = System.IO.Path.GetDirectoryName(path);
      this.__strFlieUpdate = __strWorkPath + "\\fota\\" + this.__strFlieUpdate;
      __lastModified = System.IO.File.GetLastWriteTime(__strFlieUpdate);
      foreach (var item in this.__list_update)
      {
        ItemIp itemIp = (ItemIp)item.Tag;
        FileInfo fi = new FileInfo(__strFlieUpdate);
        ListViewItem lvit = this.lv.Items.Add(itemIp.Name);
        lvit.Tag = itemIp;
        lvit.Name = itemIp.Ip;
        lvit.SubItems.Add(itemIp.Ip);
        lvit.SubItems.Add("[0/0]");
        lvit.SubItems.Add("0%");
        lvit.SubItems.Add("0(сек.)");
        lvit.UseItemStyleForSubItems = false;
        this.lblVersion.Text = "Текущая версия прошивки:" + __lastModified.ToString("dd.MM.yy HH:mm:ss");
        if (itemIp.UType == 0)
        {
          SetInvalidteItem(lvit, 2, "Обновление не возможно", Color.Gray);
          SetInvalidteItem(lvit, 3, "Обновление не возможно", Color.Gray);
          SetInvalidteItem(lvit, 4, "Обновление не возможно", Color.Gray);
          itemIp.IsUpdateInable = false;
        }
        else
        {
            if (!__patch)
            {
            
            if (itemIp.UlcConfig == null || itemIp.UlcConfig.FMW== 0)
            {
              itemIp.IsUpdateInable = false;
              continue;
            }
            DateTime? ss = (DateTime)ParceLog.rtc_calendar_time_to_register_value(itemIp.UlcConfig.FMW);

            if (ss.Value.ToString("dd.MM,yyyy") == __lastModified.ToString("dd.MM,yyyy"))
              {
                //SetInvalidteItem(lvit, 2, "Обновление не нужно", Color.Gray);
                //SetInvalidteItem(lvit, 3, "Обновление не нужно", Color.Gray);
                //SetInvalidteItem(lvit, 4, "Обновление не нужно", Color.Gray);
               itemIp.IsUpdateInable = true;
              this.__avalbebe_update = true;
            }
              else
              {
                itemIp.IsUpdateInable = true;
                this.__avalbebe_update = true;
              }
            }
            else
            {
              if (checkCore(itemIp))
              {
                __avalbebe_update = true;
              itemIp.IsUpdateInable = true;
            }
              else
              {
                __avalbebe_update = false;
                SetInvalidteItem(lvit, 2, "Обновление не нужно", Color.Gray);
                SetInvalidteItem(lvit, 3, "Обновление не нужно", Color.Gray);
                SetInvalidteItem(lvit, 4, "Обновление не нужно", Color.Gray);
              itemIp.IsUpdateInable = false;
            }

              this.lblVersion.Text = "Установка патча";
            }
          }
        
        
      }
      this.__progress_width = this.tableLayoutPanel2.ColumnStyles[0].Width;
    }

  

    public FotaForm(List<ListViewItem> list_update, GetConnection getConnection,
      GetConfigIP getConfigIP, bool patch) {
      InitializeComponent();
      this.Shown += FotaForm_Shown;

      this.__patch = patch;
      this.__list_update = list_update;
      this.__getConnection = getConnection;
      this.__getConfigIP = getConfigIP;
      Application.Idle += Application_Idle;
      this.pictureBox1.Visible = false;
      
    }

    private void Application_Idle(object sender, EventArgs e)
    {


      if (!this.__avalbebe_update)
      {
        
        this.btnStart.Enabled = false;
        this.pictureBox1.Visible = false;
        //this.tableLayoutPanel2.Controls[0].Visible = false;
      }
      else {
        if (this.btnStart.Visible)
        {
          //this.pictureBox1.Visible = false;
          this.tableLayoutPanel2.ColumnStyles[0].Width = 0;
        }
        else {
          //this.btnStart.Visible = false;
          this.pictureBox1.Visible = true;
          if (this.btnChancel.Text == "Выход") {
            this.tableLayoutPanel2.ColumnStyles[0].Width = 0;
          }
          else
            this.tableLayoutPanel2.ColumnStyles[0].Width = this.__progress_width; 
        }
      }
      
        
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
      //Application.Idle -= Application_Idle;
    }

    public int PackageSize
    {
      get; set;
    } = 512;

    public string Address
    {
      get; set;
    }

    private static byte[] MD5Hash(byte[] input)
    {
      MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
      byte[] bytes = md5provider.ComputeHash(input);
      return bytes;
    }


    bool getRequestUpdate(string ip, EnumCommandUpdate enumCommandUpdate)
    {//NetworkStream stream) {
      TcpClient client = null;
      try
      {
        client = this.__getConnection(ip, 10251);
        if (client == null)
          return false;
        NetworkStream stream = client.GetStream();
        stream.ReadTimeout = 20000;
        byte[] rbuff = new byte[128];
        string rupd = string.Empty;
        if (enumCommandUpdate == EnumCommandUpdate.ProgrammUpdate)
          rupd = "UPGRADE:PWD:YWRtaW4=\r";
        else if (enumCommandUpdate == EnumCommandUpdate.CoreUpdate)
          rupd = "RUNUPF:PWD:YWRtaW4=\r";
        else return false;
        byte[] bupd = System.Text.ASCIIEncoding.ASCII.GetBytes(rupd);
        stream.Write(bupd, 0, bupd.Length);
        int len = stream.Read(rbuff, 0, 128);
        if (len == 0) return false;
        string result = System.Text.ASCIIEncoding.ASCII.GetString(rbuff, 0, len);
        if (enumCommandUpdate == EnumCommandUpdate.CoreUpdate) {
          byte[] b_upfread = new byte[128];
          byte[] b_upfile = System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("UPFILE: {0}\r", __strFilePatch));////Delta.bin.env\r");
          stream.Write(b_upfile, 0, b_upfile.Length);
          len = stream.Read(b_upfread, 0, b_upfread.Length);
          result = System.Text.ASCIIEncoding.ASCII.GetString(b_upfread, 0, len);
          if (len == 0) return false;
        }
        if (len != 0)
          return true;
        else
          return false;
      }
      catch (Exception exp)
      {
        
        return false;
      }
      finally
      {
        if (client != null)
          client.Close();
      }
    }

    private void SetAction(ListViewItem item,int subItem, string text)
    {
      try
      {
        IAsyncResult res = lv.BeginInvoke(new Action(() => {
          item.SubItems[subItem].Text = text;
        }));
      }
      catch
      {
      }
      
    }
    enum EnumActIcon
    {
      update=0,
      start =14,
      noupdate=15

    }
    private void SetActionIcon(ListViewItem item,EnumActIcon icon,int subItem)
    {
      IAsyncResult res = lv.BeginInvoke(new Action(() => {
        item.ImageIndex = (int)icon;
        switch (icon)
        {
          case EnumActIcon.update:
            item.SubItems[subItem].ForeColor = Color.Green;
            break;
          case EnumActIcon.start:
            item.SubItems[subItem].ForeColor = Color.DarkBlue;
            break;
          case EnumActIcon.noupdate:
            item.SubItems[subItem].ForeColor = Color.Red;
            break;
          default:
            break;
        }
      }));
    }


    void CallBackTaskEnd(Task task) {
      lock (this.__lstTaskRunner)
      {
        
        bool rm=this.__lstTaskRunner.Remove(task);
      }
    }

    void RunUpdateFota(int port, EnumCommandUpdate enumCommandUpdate) {
      __lstTaskUpdate = new List<Task>();
      __lstTaskRunner = new List<Task>();

      foreach (ListViewItem item in this.lv.Items)
      {
        ItemCallBack itcb = new ItemCallBack(item);
        if (itcb.ItmIp.IsUpdateInable)
        {
          Task tsk = new Task(new Action<object>((oItem) =>
          {
            ItemCallBack ositem = (ItemCallBack)oItem;

            ItemIp itemIp = (ItemIp)ositem.Item.Tag;
            try
            {
              SetAction(ositem.Item, 2, "Запрос на обновление...");
              SetActionIcon(ositem.Item, EnumActIcon.start, 2);
              if (getRequestUpdate(itemIp.Ip, enumCommandUpdate))//CheckForUpdate(itemIp.Ip))
              {
                SetAction(ositem.Item, 2, "Закрытие задач на контроллере");
              }
              else
              {
                SetAction(ositem.Item, 3, "Ошибка запроса на обновление");
                SetActionIcon(ositem.Item, EnumActIcon.noupdate, 2);
                return;
              }
              if (!upgradeFota(ositem.Item, port, enumCommandUpdate))
              {
                SetAction(ositem.Item, 3, "Ошибка обновления");
                SetActionIcon(ositem.Item, EnumActIcon.noupdate, 2);
              }
              else
              {
                SetActionIcon(ositem.Item, EnumActIcon.update, 2);
              }
            }
            catch (Exception exp)
            {
              SetAction(ositem.Item, 3, exp.Message);
            }
            finally
            {
              ositem.runOff(ositem.TaskOwn);
            }
          }), itcb);
          itcb.TaskOwn = tsk;
          itcb.runOff = this.CallBackTaskEnd;
          __lstTaskUpdate.Add(tsk);
        }
        if (this.__complite_work) {
          break;
        }
      }
      var iner = Task.Factory.StartNew(() =>
      {
        for (int i = 0; i < __lstTaskUpdate.Count; i++)
        {
          while (true)
          {
            if (this.__lstTaskRunner.Count < 100)
            {
              if (this.__complite_work)
                break;
              this.__lstTaskRunner.Add(__lstTaskUpdate[i]);
              __lstTaskUpdate[i].Start();
              break;
            }
            Thread.Sleep(10);
          }
          if (this.__complite_work)
            break;
        }
        if (this.__complite_work)
        {
          return;
        }
        while (this.__lstTaskRunner.Count != 0)
        {
          Thread.Sleep(100);
        }
        try
        {
          this.BeginInvoke(new Action(() => {
            this.pictureBox1.Visible = false;
            this.btnChancel.Text = "Выход";
          }));
        }
        catch{}
        
      });
    }

    private void btnFota_Click(object sender, EventArgs e)
    {
      if (this.__patch)
      {
        RunUpdateFota(_port_patch, EnumCommandUpdate.CoreUpdate);
      }
      else {
        RunUpdateFota(_port_prgm, EnumCommandUpdate.ProgrammUpdate);
      }
      this.btnStart.Visible = false;
    }
     bool upgradeFota(ListViewItem item,int port, EnumCommandUpdate enumCommandUpdate)
    {
      int sleep = -1;
      try
      {
        ItemIp itemIp = (ItemIp)item.Tag;
        string fileUpdate = string.Empty;
        if (__patch)
        {
          sleep = 15000;
          if (itemIp.UlcConfig.CORV.Equals("12.01.830"))
          {
            fileUpdate = __strWorkPath+"\\12.01.830\\" +__strFilePatch;
          }
          else if (itemIp.UlcConfig.CORV.Equals("12.00.839"))
          {
            fileUpdate = __strWorkPath + "\\12.00.839\\" + __strFilePatch;
          }
          else
          {
            return false;
          }
        }
        else
        {
          sleep = 15000;
          fileUpdate = __strFlieUpdate;
        }

        Thread.Sleep(sleep);
        TcpClient client = this.__getConnection(itemIp.Ip, port);//new TcpClient(this.__list_update[0].Ip, _port);
        if (client == null)
          return false;
       
        byte[] modemBuff = GetBuffer(fileUpdate);// @"D:\ztp\ztpConfig_v1_1_12_X\fota\m2mapz.bin");
        // расчет MD5 хеша от файла прошивки
        byte[] hashcode = MD5Hash(modemBuff);
        try
        {
          NetworkStream stream = client.GetStream();
          stream.ReadTimeout = 40000;
          if (enumCommandUpdate == EnumCommandUpdate.CoreUpdate)
          {
           
          }
          if (this.__complite_work)
            return false;
          WriteFile(ZtpProtocol.ToBytes(enumCommandUpdate== EnumCommandUpdate.ProgrammUpdate ? _hash_prgm : _hash_core),
            false, "MD5-hash", hashcode, stream,item,false);
          Thread.Sleep(1500);
          if (this.__complite_work)
            return false;
          WriteFile(ZtpProtocol.ToBytes(enumCommandUpdate == EnumCommandUpdate.ProgrammUpdate? _mdm_prgm:_mdm_core),
            true, fileUpdate, modemBuff, stream,item,true);
          Thread.Sleep(1500);
          if (this.__complite_work)
            return false;
          WriteFile(ZtpProtocol.ToBytes(enumCommandUpdate == EnumCommandUpdate.ProgrammUpdate ? _end_prgm: _end_core),
            (_versionPO.CompareTo("1.7.9") >= 0 && _dataCompile.CompareTo("20.12.2021 08:10:00") >= 0) ? true : false,
            null, null, stream,item,false);
          if (this.__complite_work)
            return false;
          Thread.Sleep(5000);
        }
        finally
        {
          client.Close();
        }
      }
      catch (Exception ex)
      {
        return false;
      }
      return true;
    }

    void WriteFile(byte[] prefix, bool waitAnswer, string text, byte[] buff, NetworkStream stream,
      ListViewItem item,bool isTime)
    {
      int len = PackageSize;
      byte[] res = new byte[256];

      if (prefix != null)
      {
        stream.Write(prefix, 0, prefix.Length);
        Thread.CurrentThread.Join(300);
        if (waitAnswer)
        {
          stream.Read(res, 0, 256);
          Thread.CurrentThread.Join(300);
        }
      }
      if (buff != null)
      {
        int pos = 0;
        int fullLen = buff.Length;
        DateTime dtn = DateTime.Now;
        string tm = string.Empty;
        while (true)
        {
          if(this.__complite_work)
            break;
          if (pos + len > fullLen)
          {
            len = fullLen - pos;
          }
          /*this.Text*/ string txt = string.IsNullOrEmpty(text) ? "" : $"Передача [{pos + len}/{fullLen}]";
          stream.Write(buff, pos, len);
          Thread.CurrentThread.Join(300);
          stream.Read(res, 0, 256);
          Thread.CurrentThread.Join(300);
          int count = BitConverter.ToInt32(res, 0);
          if (count != len)
          {
            SetAction(item, 3, "Ошибка передачи данных");
            throw new Exception($"Ошибка передачи данных. Передано {len} байт. Получено устройством {count} байт");
          }
          pos += len;
          //pcFota.Step++;
          lv.BeginInvoke(new Action( ()=> {
            SetAction(item,2,txt);//$"[{pos + len}/{fullLen}]";// (((pos + len) * 100) / fullLen).ToString();
            if (isTime)
            {
              //string dts = ((int)(DateTime.Now - dtn).TotalSeconds).ToString();  
              SetAction(item, 3, (((pos + len) * 100) / fullLen).ToString() + "%");
              TimeSpan dur = DateTime.Now - dtn;
             
              if (dur.Minutes == 0)
              {
                tm = string.Format("{0}сек.", dur.Seconds);
              }
              else
              {
                tm = string.Format("{0}мин. {1}сек.", dur.Minutes, dur.Seconds);
              }
              SetAction(item, 4, tm);
            }
            else {
              SetAction(item, 3,"Ожидание передачи");
            }
            //SetAction(item,3,text);
          }));
         // item.SubItems[2].Text = $"[{pos + len}/{fullLen}]";// (((pos + len) * 100) / fullLen).ToString();
          //pcFota.Increment(1);
          //this.richTextBox1.AppendText(string.Format("{0}\r\n",pos));
          //pcFota.Invalidate();
          //Application.DoEvents();
          if (pos == fullLen)
            break;
        }

      }
    }

    int GetStepCount(int byteCount)
    {
      return (byteCount / PackageSize) + 1;
    }

    public event EventHandler FotaStarted;
    void OnFotaStarted()
    {
      FotaStarted?.Invoke(this, EventArgs.Empty);
    }

    byte[] GetBuffer(string path)
    {
      byte[] buff;
      using (FileStream fs = new FileStream(path, FileMode.Open))
      {
        buff = new byte[fs.Length];
        fs.Read(buff, 0, (int)fs.Length);
      }
      return buff;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      while (this.__complite_work)
      {

      }
     

      this.Close();
    }
  }
  public delegate void TaskRunOff(Task task);
  public class ItemCallBack{
    public ListViewItem Item { get; set; }
    public TaskRunOff runOff { get; set; }
    public Task TaskOwn { get; set; }
    public ItemIp ItmIp { get; set; }
    public List<Meters> meters { get; set; }
    public bool IsUpdateAvalabe { get; set; }
    public bool IsMeterTrue { get; set; }

    public ItemCallBack(ListViewItem item)
    {
      this.Item = item;
      this.ItmIp = (ItemIp)item.Tag;
    }
  } 

  public class ZtpFileInfo
  {
    public long Size;
    public DateTime CreateAt;
    public string FileName;
    public string ShortFileName;

    public ZtpFileInfo(string path)
    {
      FileName = path;
      ShortFileName = Path.GetFileName(path);
      FileInfo fi = new FileInfo(path);
      Size = fi.Length;
      CreateAt = fi.LastWriteTime;//CreationTime;
    }

    public override string ToString()
    {
      return $"{ShortFileName} [{CreateAt}, {Size} байт]";
    }
  }

}

