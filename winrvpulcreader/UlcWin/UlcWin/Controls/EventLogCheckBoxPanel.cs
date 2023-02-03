using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.ui;

namespace UlcWin.Controls
{
  public delegate void EventItemChecked(CbsEvents sender, ItemCheckEventArgs e);
  public delegate void EventCheckBoxSelected();
  public partial class EventLogCheckBoxPanel : UserControl
  {
    public event EventItemChecked ItemEventChecked;
    bool __loaded = false;
    public event EventCheckBoxSelected EventCheckBoxSelected;
    public EventLogCheckBoxPanel()
    {
      InitializeComponent();

    }

    public void AddCbsEvent(List<CbsEvents> cbsEvents)
    {

      foreach (var item in cbsEvents)
      {
        int index = this.checkedListBox1.Items.Add(item);
        this.checkedListBox1.SetItemChecked(index, item.Checked);
      }
      __loaded = true;
    }

    private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {

      if (__loaded)
      {
        CbsEvents cbsEvents = (CbsEvents)this.checkedListBox1.Items[e.Index];
        if (ItemEventChecked != null)
          ItemEventChecked(cbsEvents, e);
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (EventCheckBoxSelected != null) {
        EventCheckBoxSelected();
      }
      

    }
  }
 
}
