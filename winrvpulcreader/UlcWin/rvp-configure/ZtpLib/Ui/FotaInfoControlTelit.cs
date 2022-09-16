using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Ztp.Ui
{
  public partial class FotaInfoControlTelit : UserControl
  {
    const string _fotaDir = "fota";
    const string _modemFile = "m2mapz.bin";

    public FotaInfoControlTelit()
    {
      InitializeComponent();
      ModemFile = InitFileInfo(Path.Combine(FotaDirectory, _modemFile));
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      itModem.Value = ModemFile != null ? ModemFile.ToString() : "Файл не найден";
    }

    public Image IconImage
    {
      get { return pictureBox1.Image; }
      set { pictureBox1.Image = value; }
    }

    ZtpFileInfo InitFileInfo(string path)
    {
      if (!File.Exists(path))
        return null;
      return new ZtpFileInfo(path);
    }

    string _fotaDirectory;
    public string FotaDirectory
    {
      get
      {
        if (string.IsNullOrEmpty(_fotaDirectory))
        {
          string dir = Path.GetDirectoryName(Application.ExecutablePath);
          _fotaDirectory = Path.Combine(dir, _fotaDir);
        }
        return _fotaDirectory;
      }
    }

    public ZtpFileInfo ModemFile
    {
      get; private set;
    }

    public string GetVesrion()
    {
      //string res = string.Empty;
      string path = FotaDirectory + "\\" + _modemFile;

      //const int MAX_STR_LENGTH = 500; // Ожидаем что длина искомой строки не больше данного значения
      const int NBYTES = 50 * 1024;
      byte[] bytes = new byte[NBYTES];
      var encoding = Encoding.UTF7;//GetEncoding(1251);
      Regex regex = new Regex(@"[0-9]{1,}\.[0-9]{1,}\.[0-9]{1,}");
      using (var fstream = File.OpenRead(path))
      {
        for (; ; )
        {
          int bytesRead = fstream.Read(bytes, 0, NBYTES);
          if (bytesRead == 0) break;

          while (bytes.Length > 0)
          {
            string text = encoding.GetString(bytes);

            Match m = regex.Match(text);
            if (m.Success)
            {
              return m.Groups[0].Value;
            }

            byte[] st = encoding.GetBytes(text);
            int len = bytes.Length;
            if (len == st.Length)
              break;
            Array.Copy(bytes, bytes.Length, bytes, 0, len - bytes.Length);
            Array.Resize(ref bytes, len - bytes.Length);
          }
          bytes = new byte[NBYTES];
          //fstream.Position -= MAX_STR_LENGTH;
        }
      }
      return null; // Не нашли
    }


    public ZtpFileInfo ControllerFile
    {
      get; private set;
    }
  }
}
