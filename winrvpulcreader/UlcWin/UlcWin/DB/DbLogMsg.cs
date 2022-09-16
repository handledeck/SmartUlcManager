using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace UlcWin.DB
{
  public class DbLogMsg
  {
    public int Id { get; set; }
    public string Tp { get; set; }
    public string Res { get; set; }
    public string Fes { get; set; }

    public static JsonSerializerOptions GetSerializeOption() {
      JsonSerializerOptions options = new JsonSerializerOptions
      {
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin,
         UnicodeRanges.Cyrillic),
        WriteIndented = true
      };
      return options;
    }

    public static void ParseNodePath(string msg, ref DbLogMsg dbLogMsg) {
      string[] aMsg = msg.Split('\\');
      if (aMsg.Length == 2)
      {
        dbLogMsg.Fes = aMsg[0];
        dbLogMsg.Res = aMsg[1];
      }
      else if(aMsg.Length == 1)
      {
        dbLogMsg.Fes = aMsg[0];
        //dbLogMsg.Res = "";
      }

    }

    
  }

  
}
