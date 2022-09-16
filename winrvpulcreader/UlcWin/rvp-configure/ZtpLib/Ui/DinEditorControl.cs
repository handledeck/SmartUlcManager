using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class DinEditorControl : UserControl
  {
    public DinEditorControl()
    {
      InitializeComponent();
    }

    private int _visibleItemCount = 16;
    public int VisibleItemCount
    {
      get { return _visibleItemCount; }
      set
      {
        if (value <= 0 || value > 16) throw new ArgumentOutOfRangeException(nameof(value));
        _visibleItemCount = value;
        ShowItems();
      }
    }

    private bool[] _value = new bool[16];
    public bool[] Value
    {
      get
      {
        bool[] retVal = new bool[16];
        for (int i = 0; i < cblDin.Items.Count; i++)
          retVal[i] = cblDin.GetItemChecked(i);
        return retVal;
      }
      set
      {
        if(value == null || value.Length != 16)
          throw new ArgumentException(nameof(value));
        _value = value;
        ShowItems();
      }
    }

    void ShowItems()
    {
      cblDin.Items.Clear();
      for (int i = 0; i < _value.Length; i++)
      {
        if (i >= _visibleItemCount)
          break;
        cblDin.Items.Add(i + 1);
        cblDin.SetItemChecked(i, _value[i]);
      }
    }


    public bool ReadOnly
    {
      get { return !cblDin.Enabled; }
      set { cblDin.Enabled = !value; }
    }

    public string Caption
    {
      get { return groupBox1.Text; }
      set { groupBox1.Text = value; }
    }
  }
}
