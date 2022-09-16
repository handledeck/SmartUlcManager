using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class Iec104EditorControl : UserControl
  {

    public Iec104EditorControl()
    {
      InitializeComponent();
    }

    public string TimeValue
    {
      get
      {
        return AssignTime();
      }
      set
      {
        ConfirmTime(value);
      }
    }

    string AssignTime()
    {
      string res = $"{(byte)idT1.Value};{(byte)idT2.Value};{(byte)idT3.Value};1";

      return res;
    }

    void ConfirmTime(string val)
    {
      string[] values = val.Split(new[] { ';' });
      idT1.Value = byte.Parse(values[0]);
      idT2.Value = byte.Parse(values[1]);
      idT3.Value = byte.Parse(values[2]);
    }

    public ushort qValue
    {
      get
      {
        return AssignQ();
      }
      set
      {
        ConfirmQ(value);
      }
    }

    private void ConfirmQ(ushort value)
    {
      byte _w = (byte)(value & 0xff);
      if (_w == 0)
        _w = 8;
      idW.Value = _w;// (byte)(value & 0xff);
      byte _k = (byte)((value >> 8) & 0xff);
      if (_k == 0)
        _k = 12;
      idK.Value = _k;//(byte)((value >> 8) & 0xff);
    }

    private ushort AssignQ()
    {
      ushort val;
      val = (ushort)(((ushort)idK.Value << 8) | ((byte)idW.Value));
      return val;
    }


  }
}
