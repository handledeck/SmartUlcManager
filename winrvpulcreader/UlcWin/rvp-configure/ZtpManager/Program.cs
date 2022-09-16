﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ztp.Model;
using Ztp.Ui;

namespace ZtpManager
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
