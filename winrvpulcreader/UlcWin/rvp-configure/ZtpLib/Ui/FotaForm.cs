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

namespace Ztp.Ui
{
  public partial class FotaForm : Form
  {
    const int _port = 10255;
    const string _end = "_E_N_D";
    const string _sam = "_SAM_";
    const string _mdm = "_MDM_";


    public FotaForm()
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      btnFota.Enabled = fotaInfo.ModemFile != null && fotaInfo.ControllerFile != null;
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

    public ZtpProtocolDriver Driver { get; set; }
    private void btnFota_Click(object sender, EventArgs e)
    {
      if (!Box.Confirm(this, "Начать передачу прошивки?")) return;
      WritePwdAnswer answer = new WritePwdAnswer();
      try
      {
        answer = Driver.WriteUpgrade();
      }
      catch(Exception ex)
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
        byte[] modemBuff = GetBuffer(fotaInfo.ModemFile.FileName);
        byte[] controllerBuff = GetBuffer(fotaInfo.ControllerFile.FileName);
        pcFota.Minimum = 0;
        pcFota.Maximum = GetStepCount(modemBuff.Length + controllerBuff.Length);
        pcFota.Step = 0;
        TcpClient client = new TcpClient(Address, _port);
        try
        {
          NetworkStream stream = client.GetStream();
          WriteFile(ZtpProtocol.ToBytes(_mdm), true, fotaInfo.ModemFile.ShortFileName, modemBuff, stream);
          WriteFile(ZtpProtocol.ToBytes(_sam), true, fotaInfo.ControllerFile.ShortFileName, controllerBuff, stream);
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

    void WriteFile(byte[] prefix, bool waitAnswer, string text, byte[] buff, NetworkStream stream)
    {
      int len = PackageSize;
      byte[] res = new byte[256];

      if (prefix != null)
      {
        stream.Write(prefix, 0, prefix.Length);
        Thread.CurrentThread.Join(100);
        if (waitAnswer)
        {
          stream.Read(res, 0, 256);
          Thread.CurrentThread.Join(100);
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
          Thread.CurrentThread.Join(100);
          stream.Read(res, 0, 256);
          Thread.CurrentThread.Join(100);
          int count = BitConverter.ToInt32(res, 0);
          if(count != len)
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


    //static void write_mdm(TcpClient client)
    //{
    //  string up_m66 = "APPGS3MDM32A01_Upgrade_Package.bin";
    //  FileInfo fi_m = new FileInfo(up_m66);
    //  byte[] b_m = new byte[fi_m.Length];
    //  int full_len = (int)b_m.Length;
    //  string mdm = "_MDM_";
    //  byte[] b_s = System.Text.ASCIIEncoding.ASCII.GetBytes(mdm);
    //  FileStream fs = new FileStream(up_m66, FileMode.Open);
    //  fs.Read(b_m, 0, b_m.Length);
    //  fs.Close();
    //  int pos = 0;
    //  int slen = 512;
    //  client.GetStream().Write(b_s, 0, b_s.Length);
    //  byte[] b_r = new byte[256];
    //  while (true)
    //  {
    //    if (pos + slen > full_len)
    //    {
    //      slen = (int)full_len - pos;
    //    }
    //    client.GetStream().Write(b_m, pos, slen);
    //    client.GetStream().Read(b_r, 0, 256);
    //    int per = ((pos) * 100) / full_len;
    //    pos += slen;
    //    Console.Write("\r Send MDM: " + per.ToString() + "%");// BitConverter.ToInt32(b_r, 0).ToString());
    //    if (pos == full_len)
    //      break;
    //  }
    //}



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
