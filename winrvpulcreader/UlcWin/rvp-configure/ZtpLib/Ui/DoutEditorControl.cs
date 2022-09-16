using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class DoutEditorControl : UserControl
  {
    public DoutEditorControl()
    {
      InitializeComponent();
    }

    private int _visibleItemCount = 8;
    public int VisibleItemCount
    {
      get { return _visibleItemCount; }
      set
      {
        if (value <= 0 || value > 8) throw new ArgumentOutOfRangeException(nameof(value));
        _visibleItemCount = value;
        ShowItems();
      }
    }

    private bool[] _value = new bool[8];
    public bool[] Value
    {
      get
      {
        bool[] retVal = new bool[8];
        for (int i = 0; i < cblDout.Items.Count; i++)
          retVal[i] = cblDout.GetItemChecked(i);
        return retVal;
      }
      set
      {
        if (value.Length != 8)
          throw new ArgumentException(nameof(value));
        _value = value;
        ShowItems();
      }
    }

    void ShowItems()
    {
      cblDout.Items.Clear();
      for (int i = 0; i < _value.Length; i++)
      {
        if (i >= _visibleItemCount)
          break;
        cblDout.Items.Add(i + 1);
        cblDout.SetItemChecked(i, _value[i]);
      }
    }

    public bool ReadOnly
    {
      get { return !cblDout.Enabled; }
      set { cblDout.Enabled = !value; }
    }

    public string Caption
    {
      get { return groupBox1.Text; }
      set { groupBox1.Text = value; }
    }

  }
}
