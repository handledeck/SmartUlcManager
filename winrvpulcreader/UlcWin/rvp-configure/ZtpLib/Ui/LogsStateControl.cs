using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class LogsStateControl : UserControl
  {
    public byte LogLevel
    {
      get { return (byte)cbLogLevel.SelectedIndex; }
      set { cbLogLevel.SelectedIndex = value; }
    } 
    public LogsStateControl()
    {
      InitializeComponent();
      cbLogLevel.SelectedIndex = cbLogLevel.Items.Count-1;
      cbLogLevel_SelectedIndexChanged(cbLogLevel, EventArgs.Empty);
      LogLevel = (byte)(cbLogLevel.Items.Count - 1);
    }

    private void cbLogLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
      string helpMark = string.Empty;
      string logsStatus = string.Empty;
      //LogLevel = (byte)((ComboBox)sender).SelectedIndex;
      switch (((ComboBox)sender).SelectedIndex)
      {
        case 0: //DEBUG
          logsStatus = "D + I + W + E + F (ВСЕ)";
          helpMark = "записываются логи уровня (ВСЕ+):\r\n\t- DEBUG (Для разработки) + \r\n\t- INFO (штатные события) + \r\n\t- WARNING (события требующие внимания) + \r\n\t- ERROR (ошибки) + \r\n\t- FATAL (критические ошибки)";
          break;
        case 1: //INFO
          logsStatus = "I + W + E + F";
          helpMark = "записываются логи уровня (ВСЕ):\r\n\t- INFO (штатные события) + \r\n\t- WARNING (события требующие внимания) + \r\n\t- ERROR (ошибки) + \r\n\t- FATAL (критические ошибки)";
          break;
        case 2: //WARNING
          logsStatus = "W + E + F";
          helpMark = "записываются логи уровня:\r\n\t- WARNING (события требующие внимания) + \r\n\t- ERROR (ошибки) + \r\n\t- FATAL (критические ошибки)";
          break;
        case 3: //ERROR
          logsStatus = "ошибки (+ фатальные)";
          helpMark = "записываются логи уровня:\r\n\t- ERROR (ошибки) + \r\n\t- FATAL (критические ошибки)";
          break;
        case 4: //FATAL
          logsStatus = "только фатальные";
          helpMark = "записываются логи уровня:\r\n\t- FATAL (критические ошибки)";
          break;
        case 5: //LOGS OFF
          logsStatus = "";
          helpMark = "Логирование отключено";
          break;
      }
      toolTip.SetToolTip(cbLogLevel, helpMark);
      lab_logs.Text = logsStatus;
      toolTip.SetToolTip(lab_logs, helpMark);
      this.LogLevel = (byte)((ComboBox)sender).SelectedIndex;
    }
  }
}
