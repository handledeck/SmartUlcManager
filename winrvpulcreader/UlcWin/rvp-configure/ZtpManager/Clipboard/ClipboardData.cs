using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Ztp.Model;

namespace ZtpManager.Clipboard
{
  [Serializable]
  public class ClipboardData
  {
    public const string ClipboardDataFotmat = "ZtpManagerClipboardDataFotmat";
    public Node Node { get; set; }

    public static ClipboardData Deserialize(string body)
    {
      System.Xml.Serialization.XmlSerializer ser = new XmlSerializer(typeof(ClipboardData));
      using (StringReader sr = new StringReader(body))
      {
        return (ClipboardData)ser.Deserialize(sr);
      }
    }

    public string Serialize()
    {
      System.Xml.Serialization.XmlSerializer ser = new XmlSerializer(typeof(ClipboardData));
      using (StringWriter sw = new StringWriter())
      {
        ser.Serialize(sw, this);
        return sw.ToString();
      }
    }
  }
}
