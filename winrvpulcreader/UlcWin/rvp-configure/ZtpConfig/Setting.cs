using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Ztp.IO;
using Ztp.Port;
using Ztp.Port.ComPort;
using Ztp.Port.TcpPort;

namespace Ztp
{
  public class Setting
  {
    const string _appFolder = "ZtpConfig";
    const string _appSettingFile = "ZtpConfig.cfg";
    private static string _fileName;

    private static Setting _default = null;
    public static Setting Default
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

    #region PROPERTIES

    int _fotaPackageSize = 512;
    public int FotaPackageSize
    {
      get { return _fotaPackageSize; }
      set { _fotaPackageSize = value; }
    }

    ComPortSettings _comPortSettings = new ComPortSettings();
    public ComPortSettings ComPortSettings
    {
      get
      {
        return _comPortSettings;
      }
      set
      {
        if (value != null)
          _comPortSettings = value;
      }
    }

    TcpPortSettings _tcpPortSettings = new TcpPortSettings();
    public TcpPortSettings TcpPortSettings
    {
      get
      {
        return _tcpPortSettings;
      }
      set
      {
        if (value != null)
          _tcpPortSettings = value;
      }
    }

    RecentFiles _recentFiles = new RecentFiles();
    public RecentFiles RecentFiles
    {
      get
      {
        return _recentFiles;
      }
      set
      {
        if (value != null)
          _recentFiles = value;
      }
    }

    public bool ShowDebug { get; set; }

    public bool ShowState { get; set; }

    public int StateSplitterDistance { get; set; }

    public int SplitterDistance { get; set; }

    public PortKind LastPortKind { get; set; }
    #endregion PROPERTIES

    static Setting()
    {
      string dir = Folder.Combine(Folder.UserSettingFolder, _appFolder);
      Folder.CheckDirectory(dir);
      _fileName = Folder.Combine(dir, _appSettingFile);
    }
    
    internal void Save()
    {
      XmlSerializer serializer = new XmlSerializer(typeof(Setting));
      using (FileStream fs = new FileStream(_fileName, FileMode.Create, FileAccess.ReadWrite))
      {
        serializer.Serialize(fs, this);
      }
    }

    static Setting Load()
    {
      if(!File.Exists(_fileName))
        return new Setting();
      Setting retVal = null;
      XmlSerializer serializer = new XmlSerializer(typeof(Setting));
      using (FileStream fs = new FileStream(_fileName, FileMode.Open, FileAccess.ReadWrite))
      {
        retVal = serializer.Deserialize(fs) as Setting;
      }
      return retVal;
    }

  }
}
