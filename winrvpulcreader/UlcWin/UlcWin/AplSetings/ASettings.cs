using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.AplSetings
{
  [Serializable]
  public class ASettings
  {
    public List<int> CheckedItemVisible { get; set; }
    public List<int> WidthColumnsDevice { get; set; }
    public List<int> DisplayIndexes { get; set; }
    static string __connect_file = "appdevice.bin";

    public object Clone()
    {
      return this.MemberwiseClone();
    }

    static string GetPathSetting()
    {
      string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
      string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
      string wpth = strWorkPath + "\\" + __connect_file;
      return wpth;
    }

    public static void SaveAppSettings(ASettings appSettings)
    {
      BinaryFormatter formatter = new BinaryFormatter();
      try
      {
        string wpth = GetPathSetting();
        StreamWriter wr = new StreamWriter(wpth);
        formatter.Serialize(wr.BaseStream, appSettings);
        wr.Close();
      }
      catch (Exception exp)
      {
        MessageBox.Show("Ошибка сохранения соединения с базой данных", "Ошибка соединения с базой",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

    }

    public static ASettings LoadAppSettings() {
      ASettings aSettings = null;
      BinaryFormatter formatter = new BinaryFormatter();
      try
      {
        StreamReader reader = new StreamReader(GetPathSetting());
        aSettings = (ASettings)formatter.Deserialize(reader.BaseStream);
        reader.Close();
      }
      catch
      {
      }
      return aSettings;
    }
  }
}

