using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Ztp.Protocol
{
  public class ZtpPatchTelit
  {
    public static IOperationHistorian Historian;
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

    public int Tag { get; set; }

    private int _timeout;

    public ZtpProtocolDriver Driver { get; set; }

    public ZtpPatchTelit(int timeout)
    {
      _timeout = timeout;
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
          if (pos == fullLen)
            break;
        }

      }
    }

    public void Write(string coreVers)
    {
      string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
      string strWorkPath = Path.GetDirectoryName(strExeFilePath);

      if (coreVers.CompareTo("12.01.830") == 0)
      {
        strWorkPath += $"\\12.01.830\\{_filename}";
      }
      else if (coreVers.CompareTo("12.00.839") == 0)
      {
        strWorkPath += $"\\12.00.839\\{_filename}"; ;
      }
      else
      {
        return;// -2;
      }
        Thread.Sleep(5000);
        byte[] modemBuff = GetBuffer(strWorkPath);
        byte[] hashcode = MD5Hash(modemBuff);
        int Maximum = GetStepCount(modemBuff.Length);
        TcpClient client = new TcpClient(Address, _port);
        client.ReceiveTimeout = _timeout;
        client.SendTimeout = _timeout;
        try
        {
          NetworkStream stream = client.GetStream();
          WriteFile(ZtpProtocol.ToBytes(_hash), false, "MD5-hash", hashcode, stream);
          Thread.Sleep(200);
          WriteFile(ZtpProtocol.ToBytes(_mdm), true, _filename, modemBuff, stream);
          WriteFile(ZtpProtocol.ToBytes(_end), false, null, null, stream);
          Thread.Sleep(2000);
          Historian?.Write(Tag, OpHistoryCode.PA, null, null, null, false);
        }
        finally
        {
          client.Close();
        }
    }
  }
}
