using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Ztp.Protocol;
using System.Security.Cryptography;

namespace Ztp.Ui
{
  public partial class FileUploadForm : Form
  {
    const int _port = 10121;

    const string _end = "_ENDUPF";
    static string _mdm = "_UPF";
    const string _hash = "_HASH";

    private string _filename = "Delta.bin.env";

    public int PackageSize
    {
      get; set;
    } = 512;

    public string Address
    {
      get; set;
    }

    public ZtpProtocolDriver Driver { get; set; }

    public FileUploadForm()
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
      labUpFilename.Text = _filename;
      bSearch.Visible = false;
      tbPath.Visible = false;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      bUpload.Enabled = !string.IsNullOrEmpty(_filename);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
      Application.Idle -= Application_Idle;
    }

    private static byte[] MD5Hash(byte[] input)
    {
      MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
      byte[] bytes = md5provider.ComputeHash(input);
      return bytes;
    }

    int GetStepCount(int byteCount)
    {
      return (byteCount / PackageSize) + 1;
    }

    byte[] GetBuffer(string path)
    {
      byte[] buff;
      System.Diagnostics.Debug.Print("file path::" + path);
      using (FileStream fs = new FileStream(path, FileMode.Open))
      {
        buff = new byte[fs.Length];
        fs.Read(buff, 0, (int)fs.Length);
      }
      return buff;
    }

    void WriteFile(byte[] prefix, bool waitAnswer, string text, byte[] buff, NetworkStream stream)
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
        while (true)
        {
          if (pos + len > fullLen)
          {
            len = fullLen - pos;
          }
          labStatusProcess.Text = string.IsNullOrEmpty(text) ? "" : $"Передача {text} [{pos + len}/{fullLen}]";

          stream.Write(buff, pos, len);
          Thread.CurrentThread.Join(300);
          stream.Read(res, 0, 256);
          Thread.CurrentThread.Join(300);
          int count = BitConverter.ToInt32(res, 0);
          if (count != len)
          {
            throw new Exception($"Ошибка передачи данных. Передано {len} байт. Получено устройством {count} байт");
          }
          pos += len;
          //pcFota.Step++;
          //pcFota.Increment(1);

          //pcFota.Invalidate();
          Application.DoEvents();
          if (pos == fullLen)
            break;
        }

      }
    }

    private void bUpload_Click(object sender, EventArgs e)
    {
      bUpload.Enabled = false;
      bCancel.Enabled = false;
      //string path = Path.
      labStatusProcess.Text = "Проверка версии ядра";
      string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
      string strWorkPath = Path.GetDirectoryName(strExeFilePath);

      string getVers = string.Empty;

      try
      {
        getVers = Driver.GetCoreVersion();
      }
      catch(Exception ex)
      {
        Box.Error(this, ex.Message);
        return;
      }

      labStatusProcess.Text = $"Текущая версия ядра: {getVers}";

      if (getVers.CompareTo("12.01.830") == 0)
      {
        strWorkPath += $"\\12.01.830\\{_filename}";
      }
      else if(getVers.CompareTo("12.00.839") == 0)
      {
        strWorkPath += $"\\12.00.839\\{_filename}"; ;
      }
      else
      {
        DialogResult = DialogResult.Abort;
        Box.Error(this, "Подходящий патч отсутствует");
        return;
      }
      labUpFilename.Text = strWorkPath;
      labStatusProcess.Text = $"Подготовка к загрузке файла";
      WritePwdAnswer runUploadTask = new WritePwdAnswer();
      try
      {
        runUploadTask = Driver.StartUploadService();
      }
      catch (Exception ex)
      {
        Box.Error(this, ex.Message);
        return;
      }
      if (!runUploadTask.IsOk)
        return;

      try
      {
        runUploadTask = Driver.SendFilename(_filename);
      }
      catch (Exception ex)
      {
        Box.Error(this, ex.Message);
        return;
      }
      OnUploadStarted();
      try
      {
        Thread.Sleep(5000);
        labStatusProcess.Text = $"Рассчет хеша файла по MD5";
        byte[] modemBuff = GetBuffer(strWorkPath/*tbPath.Text*/);
        //расчет MD5 хеша от файла прошивки
        byte[] hashcode = MD5Hash(modemBuff);
        int Minimum = 0;
        int Maximum = GetStepCount(modemBuff.Length);
        int Step = 0;
        TcpClient client = new TcpClient(Address, _port);
        try
        {
          NetworkStream stream = client.GetStream();
          labStatusProcess.Text = $"Отправка значения хеша";
          WriteFile(ZtpProtocol.ToBytes(_hash), false, "MD5-hash", hashcode, stream);
          Thread.Sleep(200);
          WriteFile(ZtpProtocol.ToBytes(_mdm), true, _filename, modemBuff, stream);
          labStatusProcess.Text = $"Идет проверка целостности файла";
          WriteFile(ZtpProtocol.ToBytes(_end), false, null, null, stream);
          Thread.Sleep(2000);
        }
        finally
        {
          client.Close();
        }
        DialogResult = DialogResult.OK;
      }
      catch (Exception ex)
      {
        Box.Error(this, ex);
        DialogResult = DialogResult.Abort;
      }
    }

    private void bSearch_Click(object sender, EventArgs e)
    {
      ofd.Filter = $"Any File (*.*)|*.*";
      ofd.DefaultExt = "*.*";
      if (ofd.ShowDialog(this) == DialogResult.OK)
      {
        tbPath.Text = ofd.FileName;

        _filename = ofd.SafeFileName;
        labUpFilename.Text = _filename;
      }
    }

    public event EventHandler UploadStarted;
    void OnUploadStarted()
    {
      UploadStarted?.Invoke(this, EventArgs.Empty);
    }
  }
}
