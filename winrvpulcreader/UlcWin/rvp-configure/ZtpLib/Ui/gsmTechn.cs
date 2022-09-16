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
  public partial class GsmTechn : UserControl
  {
    private uint _technology;

    public uint Techn
    {
      get { return _technology; }
      set
      {
        if (value > 2)
          value = 1;
        _technology = value;
        cbTech.SelectedIndex = (int)_technology - 1;
      }
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

  }
}
