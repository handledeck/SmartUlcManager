using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ztp.Enums;
using System.Reflection;

namespace Ztp.Ui
{
  public partial class SelectDevTypeControl : UserControl
  {
    public EventHandler SelectedItemChanged;
    public SelectDevTypeControl()
    {
      InitializeComponent();
      FillComboBox();
      comboBox.SelectedIndexChanged += DevTypeChanged;
      //comboBox.SelectedIndexChanged += 
    }

    private void DevTypeChanged(object sender, EventArgs e)
    {
      //throw new NotImplementedException();
      if(SelectedItemChanged != null)
        SelectedItemChanged(sender, e);
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
    }



    void FillComboBox()
    {
      ComboboxItem<DevType>[] items = new List<DevType>((DevType[])Enum.GetValues(typeof(DevType))).Select((p) => new ComboboxItem<DevType>(p)).ToArray();
      comboBox.Items.AddRange(items);
      comboBox.Items.RemoveAt(0);
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

    public DevType Value
    {
      get
      {
        if (comboBox.SelectedItem != null)
          return ((ComboboxItem<DevType>)comboBox.SelectedItem).Value;
        return DevType.RVP18;
      }
      set
      {
        ComboboxItem<DevType> itemP = new ComboboxItem<DevType>(value);
        if (comboBox.Items.Contains(itemP))
          comboBox.SelectedItem = itemP;
        else if (comboBox.Items.Count > 0)
          comboBox.SelectedIndex = 0;
        OnPortKingChanged();
      }
    }
  }
}
