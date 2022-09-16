using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.IO.Logger;

namespace Ztp.Ui
{
  public partial class UiLogConsoleControl : UserControl, ILog
  {
    private const int _maxLineCount = 1000;
    private const int _minLineCount = 500;

    public UiLogConsoleControl()
    {
      InitializeComponent();
    }

    readonly LogFormatter _formatter = new LogFormatter();
    
    private void AddLine(string line, bool newLine)
    {
      if (richTextBox.InvokeRequired)
      {
        richTextBox.BeginInvoke(new Action<string, bool>(AddLine), line, newLine );
        return;
      }
      if(this.IsDisposed)
        return;
      TrimText();
      richTextBox.AppendText(line);
      if(newLine)
        richTextBox.AppendText(Environment.NewLine);
      if (richTextBox.Text.Length > 0)
      {
        richTextBox.Select(richTextBox.Text.Length - 1, 0);
        richTextBox.ScrollToCaret();
      }
    }

    void TrimText()
    {
      int count = richTextBox.Lines.Length;
      if (count >= _maxLineCount)
      {
        string[] lines = new string[_minLineCount];
        int index = 0;
        for (int i = count - _minLineCount; i < count; i++)
        {
          lines[index++] = richTextBox.Lines[i];
        }
        richTextBox.Lines = lines;
      }
    }

    public void Info(string message, params object[] args)
    {
      AddLine(_formatter.FormatInfo(message, args), true);
    }

    public void Error(string message, params object[] args)
    {
      AddLine(_formatter.FormatError(message, args), true);
    }

    public void Error(Exception e)
    {
      AddLine(_formatter.FormatError(e.Message), true);
    }

    public void WriteDebug(bool isEvent, string message, params object[] args)
    {
      if(isEvent)
        AddLine(_formatter.FormatInfo(message, args), false);
      else
        AddLine(string.Format(message, args), false);
    }
  }
}
