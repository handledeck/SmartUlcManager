using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Bss.Sys.Parser.Math;
using Ztp.Utils;

namespace ZtpManager
{
  public class AppConfig
  {
    public const string _appFolder = "ZtpManager";
    private const string _appConfigFile = "ZtpManager.cfg";

    private static AppConfig _default = null;

    public static AppConfig Default
    {
      get
      {
        if (_default == null)
        {
          _default = Load();
        }
        return _default;
      }
    }
    public Size MainFormSize { get; set; } = new Size(860, 680);
    public Point MainFormLocation { get; set; } = new Point(0, 0);
    public bool EstEnabled { get; set; }
    public string EstIpAddress { get; set; } = "127.0.0.1";
    public int EstPort { get; set; } = 10812;
    public string EstUser { get; set; }
    public string EstPassword { get; set; } = "";
    public int NodeTreeSplitterDistance { get; set; } = 250;
    public uint TcpPort { get; set; } = 10251;
    public int TcpTimeout { get; set; } = 10000;
    public int SplitterDistance { get; set; }
    public bool ShowDebug { get; set; }
    public bool ShowState { get; set; }
    public int StateSplitterDistance { get; set; }
    public bool AutoReadZtpConfig { get; set; } = true;
    public bool AutoOpenConfigRibbon { get; set; } = true;
    public string LastIpAddress { get; set; } = "127.0.0.1";

    static string GetFileName()
    {
      string dir = Path.Combine(Ztp.IO.Folder.UserSettingFolder, _appFolder);
      Ztp.IO.Folder.CheckDirectory(dir);
      return Path.Combine(dir, _appConfigFile);
    }

    public Exception Save()
    {
      Exception retVal = null;
      try
      {
        System.Xml.Serialization.XmlSerializer xs = new XmlSerializer(typeof(AppConfig));
        using (FileStream fs = new FileStream(GetFileName(), FileMode.Create, FileAccess.Write))
        {
          xs.Serialize(fs, this);
        }
      }
      catch (Exception e)
      {
        retVal = e;
      }
      return retVal;
    }

    static AppConfig Load()
    {
      string fileName = GetFileName();
      if (File.Exists(fileName))
      {
        System.Xml.Serialization.XmlSerializer xs = new XmlSerializer(typeof(AppConfig));
        using (FileStream fs = new FileStream(GetFileName(), FileMode.Open, FileAccess.Read))
        {
          AppConfig ac = (AppConfig)xs.Deserialize(fs);
          return ac;
        }
      }
      return new AppConfig();
    }
  }
}
