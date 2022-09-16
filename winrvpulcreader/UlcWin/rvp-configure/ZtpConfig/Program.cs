using System;
using System.Windows.Forms;
using Ztp.Ui;


namespace Ztp
{
  static class Program
  {
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      try
      {
        Application.Run(new MainForm());
      }
      catch (Exception ex)
      {
        Box.Error(null, ex);
      }
    }
  }
}
