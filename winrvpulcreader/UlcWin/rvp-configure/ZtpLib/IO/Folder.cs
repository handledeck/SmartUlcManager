using System;
using System.IO;

namespace Ztp.IO
{
  public static class Folder
  {
    const string _rootSettingFolder = "ztp";
    static string _userSettingFolder = null;

    public static string UserSettingFolder
    {
      get
      {
        if (string.IsNullOrEmpty(_userSettingFolder))
        {
          _userSettingFolder = Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            _rootSettingFolder);
          CheckDirectory(_userSettingFolder);
        }
        return _userSettingFolder;
      }
    }

    public static string Combine(params string[] paths)
    {
      return Path.Combine(paths);
    }

    public static void CheckDirectory(string path)
    {
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
    }
  }
}
