using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace UlcWin.DB
{


  public class ImeiStatAndRs
  {
    public string old_imei { get; set; }
    public string new_imei { get; set; }
    public string rs_status { get; set; }
  }

  public class DbLogMsg
  {
    public int id { get; set; }
    public string fes { get; set; }
    public string res { get; set; }
    public string tp { get; set; }
    public string ip { get; set; }
   
    public ImeiStatAndRs feature { get; set; }

    public static JsonSerializerOptions GetSerializeOption() {
      JsonSerializerOptions options = new JsonSerializerOptions
      {
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin,
         UnicodeRanges.Cyrillic),
        WriteIndented = true,
        
      };
     
      return options;
    }


    public static void ParseNodePath(string msg, ref DbLogMsg dbLogMsg) {
      string[] aMsg = msg.Split('\\');
      if (aMsg.Length == 2)
      {
        dbLogMsg.fes = aMsg[0];
        dbLogMsg.res = aMsg[1];
      }
      else if(aMsg.Length == 1)
      {
        dbLogMsg.fes = aMsg[0];
        //dbLogMsg.Res = "";
      }

    }

    
  }



}
