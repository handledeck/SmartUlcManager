using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Ztp.Ui
{
  [Designer(typeof(ExpanderControlDesigner))]

  public partial class ExpanderControl : UserControl
  {
    private int _headerHeight;
    private int _originalHeight;
    public ExpanderControl()
    {
      InitializeComponent();

      cbHeader.CheckStateChanged += CbHeader_CheckStateChanged;
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      _headerHeight = pnlHeader.Height;
      _originalHeight = Height;
      Size s = Size;
    }

    private void CbHeader_CheckStateChanged(object sender, EventArgs e)
    {
      ChangeHeight();
      OnExpandedChanged();
    }

    public event EventHandler ExpandedChanged;
    public bool IsExpanded
    {
      get { return cbHeader.Checked; }
      set { cbHeader.Checked = value; }
    }


    [Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Panel Content => pnlContent;

    public string Header
    {
      get { return cbHeader.Text; }
      set { cbHeader.Text = value; }
    }

    public Color HeaderBackColor
    {
      get { return pnlHeader.BackColor; }
      set { pnlHeader.BackColor = value; }
    }

    public Color HeaderForeColor
    {
      get { return cbHeader.ForeColor; }
      set { cbHeader.ForeColor = value; }
    }


    void ChangeHeight()
    {
      Height = IsExpanded ? _originalHeight : _headerHeight;
    }

    protected virtual void OnExpandedChanged()
    {
      ExpandedChanged?.Invoke(this, EventArgs.Empty);
    }
  }

  public class ExpanderControlDesigner : ParentControlDesigner
  {
    private ExpanderControl _expander;

    public override void Initialize(IComponent component)
    {
      base.Initialize(component);

      _expander = (ExpanderControl)Control;
      EnableDesignMode(_expander.Content, "Content");
    }
  }

}
