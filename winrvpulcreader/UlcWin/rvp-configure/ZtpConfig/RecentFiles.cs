using System.Collections.Generic;
using System.Xml.Serialization;

namespace Ztp
{
  public class RecentFiles
  {
    [XmlIgnore()]
    const int _maxLength = 10;
    public List<string> Files = new List<string>();
    
    public void Add(string path)
    {
      if (Files.Contains(path))
        return;
      Files.Add(path);
      if (Files.Count > _maxLength)
        Files.RemoveAt(0);
      Setting.Default.Save();
    }

    public bool Contains(string fileName)
    {
      return Files.Contains(fileName);
    }

    [XmlIgnore()]
    public int Count
    {
      get
      {
        return Files.Count;
      }
    }

    public string this[int index]
    {
      get
      {
        return Files[index];
      }
      set
      {
        if (value != null)
          Files[index] = value;
      }
    }
  }
}
