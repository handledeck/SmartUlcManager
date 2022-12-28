using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.ui
{
  public partial class AutoCompleteCombobox : ComboBox
  {
    public AutoCompleteCombobox()
    {
      InitializeComponent();
    }
    public IList<object> m_collectionList = null;


    public AutoCompleteCombobox(IContainer container)
    {
      container.Add(this);
    }

    public void ReInit() {
      try
      {
        this.Text = "";
        this.Items.Clear();
        m_collectionList = null;
      }
      catch { }
    }

    protected override void OnTextUpdate(EventArgs e)
    {
      try
      {

      
      if (m_collectionList == null)
      {
        m_collectionList = this.Items.OfType<object>().ToList();
      }
      //else {
      //  //m_collectionList = null;
      // // m_collectionList = this.Items.OfType<object>().ToList();
      //}
      IList<object> values = m_collectionList
          .Where(x => x.ToString().ToLower().Contains(Text.ToLower()))
          .ToList<object>();

      this.Items.Clear();
      this.Items.AddRange(this.Text != string.Empty ? values.ToArray() : m_collectionList.ToArray());

      this.SelectionStart = this.Text.Length;
      this.DroppedDown = true;
      this.Cursor = Cursors.Default;
      }
      catch
      {

       
      }
    }

    protected override void OnTextChanged(EventArgs e)
    {
      if (this.Text != string.Empty) return;
      this.Items.Clear();
      this.Items.AddRange(m_collectionList.ToArray());
    }

  }
}
