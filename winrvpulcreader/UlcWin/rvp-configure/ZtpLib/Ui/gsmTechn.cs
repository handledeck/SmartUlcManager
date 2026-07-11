using System;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class GsmTechn : UserControl
  {
    private uint _technology;

    readonly string[] oldULC = { "2G", "3G" };

    readonly string[] simcomULC = {
      "Только 2G",
      "Только 3G",
      "3G/2G, предпочесть 3G",
#if true
      "4G/3G, предпочесть 3G",
      "4G/3G, предпочесть 4G",
      "Только 4G",
      "4G/3G/2G, предпочесть 2G",
      "4G/3G/2G, предпочесть 3G",
      "4G/3G/2G, предпочесть 4G" 
#endif
    };

    public uint Techn
    {
      get
      {
        return _technology; 
      }
      set
      {
        if (value > cbTech.Items.Count)
          value = 1;
        _technology = value;
        cbTech.SelectedIndex = (int)_technology - 1;
      }
    }

    public void ChangeList(bool isNew)
    {
      cbTech.Items.Clear();
      cbTech.Items.AddRange(isNew ? simcomULC : oldULC);
    }

    public GsmTechn()
    {
      InitializeComponent();
      cbTech.SelectedIndex = 0;
    }

    private void CbTech_SelectedIndexChanged(object sender, EventArgs e)
    {
      Techn = (uint)cbTech.SelectedIndex + 1;
    }

    private void GsmTechn_Load(object sender, EventArgs e)
    {
      cbTech.Items.Clear();
      cbTech.Items.AddRange(oldULC);
    }
  }
}
