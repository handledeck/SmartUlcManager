using System;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Ztp.Ui
{
  public partial class PingEditorControl : UserControl
  {
    public delegate void GetPingResultHandler(string s);
    public event GetPingResultHandler PingRes;

    public delegate void TestPinghandler();
    public event TestPinghandler TestPing;

    private string _ip = "";
    private byte _period = 1;

    public PingEditorControl()
    {
      InitializeComponent();
      _ip = itcIP.Value;
      idcPeriod.Enabled = itcIP.Enabled = bPingTest.Enabled = cbActivePing.Checked;
    }

    public string Ip
    {
      get
      {
        //if (string.CompareOrdinal(_ip, itcIP.Value) != 0)
          itcIP_Validated(this, EventArgs.Empty);
        if (this.errorProvider.GetError(itcIP) != string.Empty)
          throw new FormatException("Некорректный IP для пинга");
        return _ip;
      }
      set
      {
        cbActivePing.Checked = value.Contains("255.255.255.255") == false;
        itcIP.Value = _ip = value;
      }
    }

    public byte Period
    {
      get
      {
        return _period;
      }
      set
      {
        if (value < idcPeriod.Minimum)
          _period = (byte)idcPeriod.Minimum;
        else if (value > idcPeriod.Maximum)
          _period = (byte)idcPeriod.Maximum;
        else
          _period = value;
        idcPeriod.Value = _period;
      }
    }

    private void itcIP_Validated(object sender, EventArgs e)
    {
      bool ipV = IsTextAValidIPAddress(itcIP.Value);
      if(string.IsNullOrEmpty(itcIP.Value) || ipV)
      {
        _ip = itcIP.Value;
        this.errorProvider.SetError(itcIP, "");
      }
      else
      {
        itcIP.Focus();
        this.errorProvider.SetError(itcIP, "Введите корректный IP адрес или оставте пустую строку если параметр не нужен");
      }
    }

    bool IsTextAValidIPAddress(string text)
    {
      bool result = true;
      string[] values = text.Split(new[] { "." }, StringSplitOptions.None); //keep empty strings when splitting
      result &= values.Length == 4; // aka string has to be like "xx.xx.xx.xx"
      byte temp;
      if (result)
        for (int i = 0; i < 4; i++)
          result &= byte.TryParse(values[i], out temp); //each "xx" must be a byte (0-255)
      return result;
    }

    private void idcPeriod_ValueChanged(object sender, EventArgs e)
    {
      _period = (byte)idcPeriod.Value;
    }

    private void bPingTest_Click(object sender, EventArgs e)
    {
      TestPing?.Invoke();
    }

    private void cbActivePing_CheckedChanged(object sender, EventArgs e)
    {
      if(cbActivePing.Checked == false)
      {
        Ip = "255.255.255.255";
      }
      idcPeriod.Enabled = itcIP.Enabled = bPingTest.Enabled = cbActivePing.Checked;
    }

    private void itcIP_Validated(object sender, MouseEventArgs e)
    {
      itcIP_Validated(sender, e);
    }
  }
}
