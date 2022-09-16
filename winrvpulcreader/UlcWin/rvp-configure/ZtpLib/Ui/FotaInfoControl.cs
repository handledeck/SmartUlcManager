using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class FotaInfoControl : UserControl
  {
    const string _fotaDir = "fota";
    const string _modemFile = "APPGS3MDM32A01_Upgrade_Package.bin";
    const string _controllerFile = "sam-mdm-dev.bin";

    public FotaInfoControl()
    {
      InitializeComponent();
      ModemFile = InitFileInfo(Path.Combine(FotaDirectory, _modemFile));
      ControllerFile = InitFileInfo(Path.Combine(FotaDirectory, _controllerFile));
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      itController.Value = ControllerFile != null ? ControllerFile.ToString() : "Файл не найден";
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


    public ZtpFileInfo ControllerFile
    {
      get; private set;
    }

  }
}
