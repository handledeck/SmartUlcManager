using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class FlayoutBitArrayViewControl : UserControl
  {
    public FlayoutBitArrayViewControl()
    {
      InitializeComponent();
    }

    public string Caption
    {
      get { return groupBox.Text; }
      set { groupBox.Text = value; }
    }


    private bool[] _value;
    public bool[] Value
    {
      get
      {
        if (_value == null)
          _value = new bool[16];
        return _value;
      }
      set
      {
        if (value == null)
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
        flowLayoutPanel1.Controls.Clear();
        int max = VisibleCount < _value.Length ? VisibleCount : _value.Length;
        for (int i = 0; i < max; i++)
        {
          BitItem item = new BitItem((i + 1).ToString(), iml, _value[i]);
          flowLayoutPanel1.Controls.Add(item);
        }
        Assign();
      }
    }

    void Assign()
    {
      
      int max = VisibleCount < _value.Length ? VisibleCount : _value.Length;
      for (int i = 0; i < max; i++)
      {
        BitItem item = Find(i);
        if(item == null)
          continue;
        item.Value = _value[i];
      }
    }

    BitItem Find(int index)
    {
      BitItem item = null;
      string text = (index + 1).ToString();
      for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
      {
        BitItem bi = flowLayoutPanel1.Controls[i] as BitItem;
        if (bi == null) continue;
        if (bi.Text == text)
        {
          item = bi;
          break;
        }
      }
      return item;
    }

    class BitItem : Label
    {
      private bool _value;

      public BitItem(string text, ImageList imageList, bool value)
      {
        if (imageList == null) throw new ArgumentNullException(nameof(imageList));
        Value = value;
        ImageList = imageList;
        Text = text;
        AutoSize = false;
        Size = new Size(35, 18);
        ImageAlign = ContentAlignment.MiddleLeft;
        TextAlign = ContentAlignment.MiddleRight;
      }

      public bool Value
      {
        get { return _value; }
        set
        {
          _value = value;
          ImageIndex = Convert.ToInt32(value);
        }
      }
    }
  }
}
