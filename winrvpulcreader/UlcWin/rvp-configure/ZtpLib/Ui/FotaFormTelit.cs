using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Ztp.Protocol;
using System.Security.Cryptography;

namespace Ztp.Ui
{
  public partial class FotaFormTelit : Form
  {
    const int _port = 10255;
    const string _end = "_E_N_D";
    static string _mdm = "_TELL";
    const string _hash = "_HASH";
    private string _versionPO = String.Empty;
    private string _dataCompile = String.Empty;

    public FotaFormTelit()
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
    }

    public FotaFormTelit(string version, string dateCompile)
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
      _versionPO = version;
      _dataCompile = dateCompile;
    }


    private void Application_Idle(object sender, EventArgs e)
    {
      btnFota.Enabled = fotaInfo.ModemFile != null;
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

    public ZtpProtocolDriver Driver { get; set; }

    private void btnFota_Click(object sender, EventArgs e)
    {
      if (!Box.Confirm(this, "Начать передачу прошивки?")) return;

      DateTime dateRelease1_7_7 = new DateTime(2021, 08, 01);
      //очистка логов при прошивке с версий 1.7.7+ на версию более раннюю чем 1.7.7
      if(_versionPO.CompareTo("1.7.7") >= 0 && fotaInfo.ModemFile.CreateAt < dateRelease1_7_7)
      {
        if (!Box.Confirm(this, "Обнаружена попытка откатить прошивку до более старой версии? Все хранящиеся логи при этом будут стерты! Желаете продолжить?"))
          return;
        WritePwdAnswer check = new WritePwdAnswer();
        try
        {
          check = Driver.DropLogs();
        }
        catch (Exception ex)
        {
          Box.Error(this, ex.Message);
          return;
        }
        if (!check.IsOk)
          return;
      }
      WritePwdAnswer answer = new WritePwdAnswer();

      try
      {
        answer = Driver.WriteUpgrade();
      }
      catch (Exception ex)
      {
        Box.Error(this, ex.Message);
        return;
      }
      if (!answer.IsOk)
      {
        Box.Error(this, answer.DisplayMessage);
        return;
      }
      OnFotaStarted();
      btnFota.Enabled = btnCancel.Enabled = false;
      try
      {
        Thread.Sleep(20000);
        byte[] modemBuff = GetBuffer(fotaInfo.ModemFile.FileName);
        // расчет MD5 хеша от файла прошивки
        byte[] hashcode = MD5Hash(modemBuff);
        pcFota.Minimum = 0;
        pcFota.Maximum = GetStepCount(modemBuff.Length);
        pcFota.Step = 0;
        TcpClient client = new TcpClient(Address, _port);
        try
        {
          NetworkStream stream = client.GetStream();
          WriteFile(ZtpProtocol.ToBytes(_hash), false, "MD5-hash", hashcode, stream);
          Thread.Sleep(500);
          WriteFile(ZtpProtocol.ToBytes(_mdm), true, fotaInfo.ModemFile.ShortFileName, modemBuff, stream);
          //WriteFile(ZtpProtocol.ToBytes(_sam), true, fotaInfo.ControllerFile.ShortFileName, controllerBuff, stream);
          Thread.Sleep(500);
          WriteFile(ZtpProtocol.ToBytes(_end), (_versionPO.CompareTo("1.7.9") >= 0 && _dataCompile.CompareTo("20.12.2021 08:10:00") >= 0) ? true : false, null, null, stream);
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
          pcFota.Caption = string.IsNullOrEmpty(text) ? "" : $"Передача {text} [{pos + len}/{fullLen}]";

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
          pcFota.Step++;
          pcFota.Increment(1);

          pcFota.Invalidate();
          Application.DoEvents();
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
  }
}
