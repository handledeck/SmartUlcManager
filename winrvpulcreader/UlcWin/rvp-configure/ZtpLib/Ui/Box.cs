using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public static class Box
  {
    public static void Error(IWin32Window owner, Exception ex)
    {
      Error(owner, ex.Message);
    }

    public static void Error(IWin32Window owner, string message)
    {
      MessageBox.Show(owner, message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static bool Confirm(IWin32Window owner, string message)
    {
      return MessageBox.Show(owner, message, "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
    }

    public static void Info(IWin32Window owner, string message)
    {
      MessageBox.Show(owner, message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void Warning(IWin32Window owner, string message)
    {
      MessageBox.Show(owner, message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

  }
}
