using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpStub
{
  public enum ConfigFlag
  {
    EstActive = 1,
    Din = 2,
    Dout = 4,
    Ain = 8,
    Latitude = 16,
    All = Ain | Din | Dout | Latitude | EstActive,
  }

  class Program
  {




    private const string _config =
        "CONFIG:APN:vpn2.mts.by USER:vpn PASS:gsd9drekj5 DT:1186136999 DEBOUNCE:500 DEBUG:1 EST:0 IP:172.23.0.9 TCP:10245 TSEND:50 AIN:0 DIN:65535 DOUT:255 DOOR:31 LATIT:55.191 LONGIT:30.201 TZ:3 CDIN:0 CDOUT:0 CAIN:10;18;3258;3470 SRISE:1186102400 SSET:1186142400 SIM:1 GSM:1 GPRS:1 SIGNAL:12 DBZ:1 IPOWN:172.22.32.19 SCHED: RAS:0 VER:I16O2A2-LDC-3-FOTA SERIAL:9600,8,0,1 NUM:1\r";
    //static private TcpListener _listener;
    static void Main(string[] args)
    {
      ConfigFlag f = ConfigFlag.Ain | ConfigFlag.EstActive;
      bool b = f.HasFlag(ConfigFlag.Latitude);
      ConfigFlag r = f & ConfigFlag.EstActive;

      new Server(10251);
    }
  }
}
