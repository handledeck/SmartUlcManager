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
  public partial class CurrentAinViewControl : UserControl
  {
    public CurrentAinViewControl()
    {
      InitializeComponent();
    }

    private ushort[] _value = new ushort[1];
    public ushort[] Value
    {
      get { return _value; }
      set
      {
        if(value == null)
          return;
        _value = value;
        Assign();
      }
    }

    private int _visibleCount = 1;
    public int VisibleCount
    {
      get { return _visibleCount; }
      set
      {
        _visibleCount = value;
        Assign();
      }
    }

    void Assign()
    {
      lbValues.Items.Clear();
      int max = Math.Min(_value.Length, _visibleCount);
      for (int i = 0; i < max; i++)
      {
        lbValues.Items.Add($"{i + 1}. {_value[i]}");
      }
    }
  }
}
