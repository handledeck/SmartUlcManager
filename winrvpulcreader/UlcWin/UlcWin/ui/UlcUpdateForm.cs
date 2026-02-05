using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.DB;
using Ztp.Configuration;
using Ztp.Enums;
using Ztp.Protocol;
using Ztp.Utils;

namespace UlcWin.ui
{
  public partial class UlcUpdateForm : Form
  {
    List<CD> cDs = null;
    string __path = $"{Application.StartupPath}\\fota\\";
    const int _port = 10255;
    const string _end = "_E_N_D";
    static string _mdm = "_TELL";
    const string _hash = "_HASH";
    public int __percent = 0;
    bool __run = false;
    public UlcUpdateForm()
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      if (__percent == 100) {
        __percent = 0;
        MessageBox.Show("Операция прошивки завершена", "Обновление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.Close();
      }
      if (__run) {
        this.btnRun.Enabled = false;
        this.btnRun.Text = "Обновление";
      }
    }

    public List<CD> UpdateObject
    {
      get
      {
        return cDs;
      }
      set
      {
        cDs = value;
        this.dataGridView1.DataSource = value;
      }
    }
    public int PackageSize
    {
      get; set;
    } = 512;

    public Stream GetTcpConnection(string host, int port, int timeout)
    {
      Stream stream = null;
      TcpClient __tcpClient = new TcpClient();
      IAsyncResult result = __tcpClient.BeginConnect(host, port, (i) =>
      {
      }, __tcpClient);
      bool state = result.AsyncWaitHandle.WaitOne(timeout);
      if (__tcpClient == null)
        return null;
      if (!__tcpClient.Connected)
        return null;
      else
      {
        stream = __tcpClient.GetStream();
        stream.ReadTimeout = 10000;
        return stream;
      }
    }
    CancellationTokenSource __cancelTokenSource;
    CancellationToken __token;
    private void btnStart_Click(object sender, EventArgs e)
    {
      __cancelTokenSource = new CancellationTokenSource();
      __token = __cancelTokenSource.Token;
      int count = 0;
      int count_all = cDs.Count;
      List<Task> tasks = new List<Task>();
      
      for (int i = 0; i < cDs.Count; i++)
      {
        string p_path = __path;
        Task tsk = new Task(new Action<object>((iObj) =>
        {
          int row = 0;
          Stream stream = null;
          try
          {
            //DataAsync dataAsync = (DataAsync)iObj;
            object[] obj = iObj as object[];
            row = (int)obj[0];
            CD cD = (CD)obj[1];
            CancellationToken tkn=(CancellationToken)obj[2];
            stream = GetTcpConnection(cD.ip_address, 10251, 5000);

            if (stream != null)
            {
              //stream.ReadTimeout = 5000;
              byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(ZtpProtocol.GetConfigCommand());
              byte[] bread = new byte[1024];
              stream.Write(bytes, 0, bytes.Length);
              int len = stream.Read(bread, 0, bread.Length);
              if (len == 0)
                throw new Exception();
              else
              {
                ZtpConfig config = ZtpProtocol.DeserializeZtpConfig(System.Text.ASCIIEncoding.ASCII.GetString(bread, 0, len));
                cD.ztp = config;
                string version = string.IsNullOrEmpty(config.SoftVersion) ? "без версии" : config.SoftVersion;
                //int file = 0;
                if (string.IsNullOrEmpty(config.Version) || config.Version == "I16O2A2-LDC-3-FOTA" || config.Version == "I16O2A2-LDC-3-FOTA-BT")
                {
                  SayMessage(row, 2, $"РВП-18({version})", Color.Gray);
                  SayMessage(row, 3, "Обновление невозможно", Color.Gray);
                  SetNotEditController(row);
                  //SayMessage(row, 4, 0, Color.Gray);
                  return;
                }
                else if (config.Version == "I4O1A1-LDC-3-FOTA-DM" ||
                          config.Version == "I4O1A1-LDC-3-FOTA" )
                {
                  SayMessage(row, 2, $"ULC-2({version})", Color.Gray);
                  SayMessage(row, 3, "Обновление невозможно", Color.Gray);
                  SetNotEditController(row);
                  return;
                }

                //SayMessage(row, 2, $"ULC-2({config.SoftVersion})", Color.Brown);
                else if (config.Version == "I3O2A1-LEM-4-FOTA-prIM" ||
                          config.Version == "I1O1A1-LEM-4-FOTA")
                {
                  Version v = new Version(version);
                  Version v1 = new Version("1.2.0");
                  if (v < v1)
                  {
                    p_path += "firmware_lite-2-1.tgz";
                  }
                  else {
                    p_path += "firmware_lite-3-1.tgz";
                  }
                    SayMessage(row, 2, $"ULC-2-Lite({config.SoftVersion})", Color.Green);
                }
                else
                {
                  SayMessage(row, 2, config.Version, Color.LightGray);
                  return;
                }

                SayMessage(row, 3, "Запрос на обновление", Color.Blue);

                Thread.Sleep(3000);
                string cmd_update = ZtpProtocol.SetUpgradeCommand("admin");
                byte[] brnge = System.Text.ASCIIEncoding.UTF8.GetBytes(cmd_update);
                stream.Write(brnge, 0, brnge.Length);
                byte[] b_read = new byte[128];
                len = stream.Read(b_read, 0, 128);
                if (len <= 0)
                  throw new Exception("Ошибка запроса на обновление");
                string retVal = System.Text.ASCIIEncoding.UTF8.GetString(b_read, 0, len);
                //WritePwdAnswer retVal = ZtpProtocol.DeserializePwdAnswer();
                SayMessage(row, 3, "Закрытие задач на контроллере", Color.Blue);
                stream.Close();
                Thread.Sleep(5000);
                stream = GetTcpConnection(cD.ip_address, 10255, 5000);
                if (stream == null)
                {
                  throw new Exception("Ошибка окрытия порта прошивки");
                }
                byte[] modemBuff = GetBuffer(p_path);
                // расчет MD5 хеша от файла прошивки
                byte[] hashcode = MD5Hash(modemBuff);
               
                WriteFile(ZtpProtocol.ToBytes(_hash), false, "MD5-hash", hashcode, (NetworkStream)stream, false, -1);
                Thread.Sleep(500);
               
                WriteFile(ZtpProtocol.ToBytes(_mdm), true, "", modemBuff, (NetworkStream)stream, true, row);
                Thread.Sleep(500);
               
                //bool waitEndAnswer = (_deviceType == Device.ULC2_3 || _deviceType == Device.ULC2_3_lite || _deviceType == Device.TNC02 ||
                // _versionPO.CompareTo("1.7.9") >= 0 && _dataCompile.CompareTo("20.12.2021 08:10:00") >= 0) ? true : false;
                WriteFile(ZtpProtocol.ToBytes(_end), true, null, null, (NetworkStream)stream, false, -1);
                Thread.Sleep(2000);
              }
            }
            else
            {
              throw new Exception("Ошибка подключения");
            }
          }
          catch (Exception exc)
          {
            SetNotEditController(row);
            SayMessage(row, 2, exc.Message, Color.Red);
            SayMessage(row, 3, exc.Message, Color.Gray);

          }
          finally
          {
            if (stream != null)
            {
              stream.Close();
              stream = null;
              
            }
            Interlocked.Decrement(ref count_all);
            Interlocked.Decrement(ref count);
            this.BeginInvoke(new Action(() =>
            {
              __percent = ((cDs.Count - count_all) * 100) / cDs.Count;

              this.customProgressBar1.Value = __percent;
            }));

          }
        }), new object[] { i, cDs[i],__token });
        tasks.Add(tsk);
      }
      __run = true;
      var iner = Task.Factory.StartNew(() =>
       {
         for (int i = 0; i < tasks.Count; i++)
         {
           while (true)
           {
             if (count < 100)
             {
               tasks[i].Start();
               Interlocked.Increment(ref count);
               break;
             }
           }
         }
        
         __cancelTokenSource.Dispose();
       });
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

    private static byte[] MD5Hash(byte[] input)
    {
      MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
      byte[] bytes = md5provider.ComputeHash(input);
      return bytes;
    }

    void SetNotEditController(int row)
    {
      try
      {
        dataGridView1.Rows[row].DefaultCellStyle.ForeColor = Color.Gray;
      }
      catch { }
    }

    public void SayMessage(int row, int column, object text, Color color)
    {
      IAsyncResult result = dataGridView1.BeginInvoke(new Action(() =>
      {
        this.dataGridView1.Rows[row].Cells[column].Value = text;
        this.dataGridView1.Rows[row].Cells[column].Style.ForeColor = color == null ? Color.Black : color;
      }));
      result.AsyncWaitHandle.WaitOne();
    }

    void WriteFile(byte[] prefix, bool waitAnswer, string text, byte[] buff, NetworkStream stream, bool showMsg, int row)
    {
      int len = PackageSize;
      byte[] res = new byte[256];
      DateTime dateTime = DateTime.Now;
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
          if (__token.IsCancellationRequested)
            __token.ThrowIfCancellationRequested();
          if (pos + len > fullLen)
          {
            len = fullLen - pos;
          }
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
          if (showMsg)
          {
            SayMessage(row, 3, $"[{pos}/{fullLen}]", Color.Black);
            SayMessage(row, 4, (pos * 100) / fullLen, Color.Black);
            SayMessage(row, 5, $"{Math.Round((DateTime.Now - dateTime).TotalSeconds, 2).ToString()}сек.", Color.Green);
          }
          Application.DoEvents();
          if (pos == fullLen)
            break;
        }
      }
    }

    private void UlcUpdateForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      try
      {
        if (this.__cancelTokenSource != null)
        {
          if (this.__cancelTokenSource.Token != null)

            this.__cancelTokenSource.Cancel();
        }
      }
      catch { }
      
    }
  }
}




