using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading;
using System.Net.Sockets;

namespace Ztp.Protocol
{
  public class ZtpFotaTelit
  {
    public static IOperationHistorian Historian;
    const int _port = 10255;
    const string _end = "_E_N_D";
    static string _mdm = "_TELL";
    const string _hash = "_HASH";

    private ZtpFileInfo _modemFile;
    private int _timeout;

    public ZtpProtocolDriver Driver { get; set; }

    public ZtpFotaTelit(ZtpFileInfo modemFile, int timeout)
    {
      if (modemFile == null) throw new ArgumentNullException(nameof(modemFile));
      _timeout = timeout;
      _modemFile = modemFile;
    }

    public int Tag { get; set; }

    public int PackageSize { get; set; } = 512;

    public string Address { get; set; }

    private static byte[] MD5Hash(byte[] input)
    {
      MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
      byte[] bytes = md5provider.ComputeHash(input);
      return bytes;
    }

    public void Write()
    {
      Thread.Sleep(20000);
      byte[] modemBuff = GetBuffer(_modemFile.FileName);
      // расчет MD5 хеша от файла прошивки
      byte[] hashcode = MD5Hash(modemBuff);
      //byte[] controllerBuff = GetBuffer(_controllerFile.FileName);
      TcpClient client = new TcpClient(Address, _port);
      client.ReceiveTimeout = _timeout;
      client.SendTimeout = _timeout;
      try
      {
        NetworkStream stream = client.GetStream();
        WriteFile(ZtpProtocol.ToBytes(_hash), false, hashcode, stream);
        Thread.Sleep(100);
        WriteFile(ZtpProtocol.ToBytes(_mdm), true, modemBuff, stream);
        //WriteFile(ZtpProtocol.ToBytes(_sam), true, fotaInfo.ControllerFile.ShortFileName, controllerBuff, stream);
        WriteFile(ZtpProtocol.ToBytes(_end), false, null, stream);
        Thread.Sleep(2000);
        /*NetworkStream stream = client.GetStream();
        WriteFile(ZtpProtocol.ToBytes(_mdm), true, modemBuff, stream);
        WriteFile(ZtpProtocol.ToBytes(_sam), true, controllerBuff, stream);
        WriteFile(ZtpProtocol.ToBytes(_end), false, null, stream);
        Thread.Sleep(200);*/
        Historian?.Write(Tag, OpHistoryCode.F, null, null, null, false);
      }
      finally
      {
        client.Close();
      }

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

    void WriteFile(byte[] prefix, bool waitAnswer, byte[] buff, NetworkStream stream)
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
  }
}
