using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ztp.Port;

namespace Ztp.Ui
{
  public partial class SelectPortKindControl : UserControl
  {

    public SelectPortKindControl()
    {
      InitializeComponent();
      FillComboBox();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
    }

    void FillComboBox()
    {
      ComboboxItem<PortKind>[] items = new List<PortKind>((PortKind[])Enum.GetValues(typeof(PortKind))).Select((p) => new ComboboxItem<PortKind>(p)).ToArray();
      // ReSharper disable once CoVariantArrayConversion
      comboBox.Items.AddRange(items);
    }

    private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      OnPortKingChanged();
    }

    public event EventHandler PortKingChanged;

    void OnPortKingChanged()
    {
      PortKingChanged?.Invoke(this, EventArgs.Empty);
    }

    public string Caption
    {
      get { return label1.Text; }
      set { label1.Text = value; }
    }

    public PortKind Value
    {
      get
      {
        if(comboBox.SelectedItem != null)
          return ((ComboboxItem<PortKind>) comboBox.SelectedItem).Value;
        return PortKind.Com;
      }
      set
      {
        ComboboxItem<PortKind> itemP = new ComboboxItem<PortKind>(value);
        if (comboBox.Items.Contains(itemP))
          comboBox.SelectedItem = itemP;
        else if (comboBox.Items.Count > 0)
          comboBox.SelectedIndex = 0;
        OnPortKingChanged();
      }
    }
  }
}
