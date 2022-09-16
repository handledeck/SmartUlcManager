using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ztp
{
  public class ZtpFileInfo
  {
    public long Size;
    public DateTime CreateAt;
    public string FileName;
    public string ShortFileName;

    public ZtpFileInfo(string path)
    {
      FileName = path;
      ShortFileName = Path.GetFileName(path);
      FileInfo fi = new FileInfo(path);
      Size = fi.Length;
      CreateAt = fi.LastWriteTime;//CreationTime;
    }

    public override string ToString()
    {
      return $"{ShortFileName} [{CreateAt}, {Size} байт]";
    }
  }
}
