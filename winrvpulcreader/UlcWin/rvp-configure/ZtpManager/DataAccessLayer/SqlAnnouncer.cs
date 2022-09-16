using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using QueryBuilder.Data.AnyDb;
using Ztp.IO;

namespace ZtpManager.DataAccessLayer
{
  class SqlAnnouncer: IAnyDbAnnouncer, IDisposable
  {
    private StreamWriter _sw;

    public SqlAnnouncer()
    {
      string fileName = Folder.Combine(Folder.UserSettingFolder, AppConfig._appFolder, "announce");
      Folder.CheckDirectory(fileName);
      fileName = Folder.Combine(fileName, "announce_sql.log");
      _sw = new StreamWriter(fileName, false, Encoding.UTF8);
      _sw.AutoFlush = true;
    }

    public void Announce(string message)
    {
      _sw.WriteLine(message);
    }

    public bool Enabled { get; set; } = true;

    public void Dispose()
    {
      _sw?.Dispose();
    }
  }
}
