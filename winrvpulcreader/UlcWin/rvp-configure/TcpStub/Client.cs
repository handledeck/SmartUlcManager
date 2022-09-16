using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TcpStub
{
  class Client
  {
    static int _counter = 0;
    private readonly int _id;
    private const string _config =
      "CONFIG:APN:vpn2.mts.by USER:vpn PASS:gsd9drekj5 DT:1186136999 DEBOUNCE:500 DEBUG:1 EST:0 IP:172.23.0.9 TCP:10245 TSEND:50 AIN:0 DIN:65535 DOUT:255 DOOR:31 LATIT:55.191 LONGIT:30.201 TZ:3 CDIN:0 CDOUT:0 CAIN:10;18;3258;3470 SRISE:1186102400 SSET:1186142400 SIM:1 GSM:1 GPRS:1 SIGNAL:12 DBZ:1 IPOWN:172.22.32.19 SCHED: RAS:0 VER:I16O2A2-LDC-3-FOTA SERIAL:9600,8,0,1 NUM:1\r";

    private TcpClient _client;
    // Конструктор класса. Ему нужно передавать принятого клиента от TcpListener
    public Client(TcpClient client)
    {
      if (client == null) throw new ArgumentNullException(nameof(client));
      _client = client;
      _id = Interlocked.Increment(ref _counter);
      W($"[+] <{_id}> Create client");
    }

    private Timer timerDin, timerAin;
    object _sync = new object();
    public void Start()
    {
      NetworkStream stream = _client.GetStream();

      timerDin = new Timer(TimerDinTick, stream, 5000, 5000);
      timerAin = new Timer(TimerAinTick, stream, 5000, 5000);
      bool closed = false;
      while (true)
      {
        {
          byte[] data = new byte[1024];
          StringBuilder builder = new StringBuilder();
          do
          {
            int bytes = 0;
            try
            {
              bytes = stream.Read(data, 0, data.Length);
            }
            catch (Exception e)
            {
              closed = true;
              W($"[+] <{_id}> " + e.Message);
              break;
            }
            if (bytes == 0)
            {
              closed = true;
              W($"[!] <{_id}> Close connect");
              break;
            }
            builder.Append(Encoding.ASCII.GetString(data));
          } while (stream.DataAvailable);
          if (closed)
            break;
          Thread.Sleep(200);
          string message = builder.ToString().Trim('\0');
          W($"[+] <{_id}> Read query: {message}");
          List<string> answer = new List<string>();
          if (message == "CONFIG?\r")
            answer.Add(_config);
          else if (message.StartsWith("CONFIG:") || message.StartsWith("UPGRADE:"))
            answer.Add("PWD:OK\r");
          if (message.StartsWith("PWD:") && message.IndexOf("LIGHTS:0") > 0)
          {
            answer.Add("PWD:OK\r");
            answer.Add("EVT:DO:0,0\r");
          }
          else if (message.StartsWith("PWD:") && message.IndexOf("LIGHTS:1") > 0)
          {
            answer.Add("PWD:OK\r");
            answer.Add("EVT:DO:0,1\r");
          }
          else if (
            message.StartsWith("PWD:")
            || message.StartsWith("SPASS:PWD:")
            )
            answer.Add("PWD:OK\r");
          Random r = new Random();
          int next = r.Next(1, 12);
          Thread.Sleep(next * 1000);
          foreach (string s in answer)
          {
            W($"[+] <{_id}> Write answer: {s}");
            data = Encoding.ASCII.GetBytes(s);
            lock (_sync)
            {
              try
              {
                stream.Write(data, 0, data.Length);
              }
              catch (Exception e)
              {
                closed = true;
                W($"[+] <{_id}> " +e.Message);
                break;
              }

            }
          }
          stream.Flush();
        }
      }
      timerDin.Dispose();
      timerAin.Dispose();
    }

    public static void W(string msg, params object[] args)
    {
      Console.WriteLine(msg, args);
    }

    void TimerDinTick(object state)
    {
      NetworkStream stream = (NetworkStream)state;

      Random r = new Random();
      int index = r.Next(0, 16);
      int value = r.Next(0, 2);

      string message = $"EVT:DI:{index},{value}\r";
      //W($"[+] <{_id}> Write event DI: {message}");
      byte[] data = Encoding.ASCII.GetBytes(message);
      lock (_sync)
      {
        try
        {
          stream.Write(data, 0, data.Length);
        }
        catch (Exception e)
        {
          W($"[+] <{_id}> " + e.Message);
          timerDin.Dispose();
        }
      }
    }

    void TimerAinTick(object state)
    {
      NetworkStream stream = (NetworkStream)state;
      Random r = new Random();
      int index = r.Next(0, 2);
      int value = r.Next(0, 2);

      string message = $"EVT:DA:{index},{value}\r";
      //W($"[+] <{_id}> Write event DA: {message}");
      byte[] data = Encoding.ASCII.GetBytes(message);
      lock (_sync)
      {
        try
        {
          stream.Write(data, 0, data.Length);
        }
        catch (Exception e)
        {
          W($"[+] <{_id}> " + e.Message);
          timerAin.Dispose();
        }
      }
    }


  }
}