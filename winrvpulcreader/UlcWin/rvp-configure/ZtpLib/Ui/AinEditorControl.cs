using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class AinEditorControl : UserControl
  {
    public AinEditorControl()
    {
      InitializeComponent();
    }

    private int _visibleItemCount = 4;
    public int VisibleItemCount
    {
      get { return _visibleItemCount; }
      set
      {
        if (value < 0 || value > 16) throw new ArgumentOutOfRangeException(nameof(value)); //XXX: У нас в ULC нету аналогов 
        _visibleItemCount = value;
        ShowItems();
      }
    }

    private bool[] _value = new bool[4];
    public bool[] Value
    {
      get
      {
        bool[] retVal = new bool[4];
        for (int i = 0; i < cblAin.Items.Count; i++)
          retVal[i] = cblAin.GetItemChecked(i);
        return retVal;
      }
      set
      {
        if (value.Length != 4)
          throw new ArgumentException(nameof(value));
        _value = value;
        ShowItems();
      }
    }

    void ShowItems()
    {
      cblAin.Items.Clear();
      for (int i = 0; i < _value.Length; i++)
      {
        if (i >= _visibleItemCount)
          break;
        cblAin.Items.Add(i + 1);
        cblAin.SetItemChecked(i, _value[i]);
      }
    }

    public bool ReadOnly
    {
      get { return !cblAin.Enabled; }
      set { cblAin.Enabled = !value; }
    }

    public string Caption
    {
      get { return groupBox1.Text; }
      set { groupBox1.Text = value; }
    }
  }
}
