using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public enum EthernetProtocol{
    TCP,
    UDP
  }
  public partial class AddEthRuleForm : Form
  {
    private string _ip;

    public string ip
    {
      get {
        itcIP_Validated(this, EventArgs.Empty);
        if (this.errorProvider.GetError(itcIP) != string.Empty)
          throw new FormatException("Некорректный IP для пинга");
        return _ip; 
      }
      set { 
        _ip = value;
        itcIP.Value = _ip;
      }
    }
    public ushort srcPort
    {
      get { return (ushort)idcSrcPort.Value; }
      set { idcSrcPort.Value = value; }
    }

    public ushort destPort
    {
      get { return (ushort)idcDestPort.Value; }
      set { idcDestPort.Value = value; }
    }

    public string caption
    {
      get { return this.Text; }
      set { this.Text = value; }
    }

    public int ProtoIndex
    {
      get { return cbProtocol.SelectedIndex; }
      set { cbProtocol.SelectedIndex = value; }
    }

    public AddEthRuleForm()
    {
      InitializeComponent();
      cbProtocol.SelectedIndex = 0;
    }

    public AddEthRuleForm(string caption, string ip, ushort src, ushort dest, int ProtocolNum)
    {
      InitializeComponent();
      this.ip = ip;
      srcPort = src;
      destPort = dest;
      this.caption = caption;
      cbProtocol.SelectedIndex = ProtocolNum;
    }

    private void itcIP_Validated(object sender, EventArgs e)
    {
      bool ipV = IsTextAValidIPAddress(itcIP.Value);
      //IPAddress tmp;
      if (string.IsNullOrEmpty(itcIP.Value) || IsTextAValidIPAddress(itcIP.Value)/*IPAddress.TryParse(itcIP.Value, out tmp)*/)
      {
        _ip = itcIP.Value;
        this.errorProvider.Clear();//SetError(itcIP, "");
        btnOK.Enabled = true;
      }
      else
      {
        itcIP.Focus();
        this.errorProvider.SetError(itcIP, "Введите корректный IP адрес или оставте пустую строку если параметр не нужен");
        btnOK.Enabled = false;
      }
    }

    bool IsTextAValidIPAddress(string text)
    {
      bool result = true;
      string[] values = text.Split(new[] { "." }, StringSplitOptions.None); //keep empty strings when splitting
      result &= values.Length == 4; // aka string has to be like "xx.xx.xx.xx"
      //byte temp;
      if (result)
        for (int i = 0; i < 4; i++)
          result &= byte.TryParse(values[i], out _); //each "xx" must be a byte (0-255)
      return result;
    }

    private void itcIP_Validated(object sender, MouseEventArgs e)
    {
      itcIP_Validated(sender, e);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {

    }
  }
}
