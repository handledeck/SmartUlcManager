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
  public delegate void EventItemChecked(CbsEvents sender,ItemCheckEventArgs e);
  public partial class EventLogCheckBoxPanel : UserControl
  {
    public event EventItemChecked ItemEventChecked;  
    public EventLogCheckBoxPanel()
    {
      InitializeComponent();
    }

    public void AddCbsEvent(CbsEvents cbsEvents) {
      this.checkedListBox1.Items.Add(cbsEvents);
    }

    private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      CbsEvents cbsEvents=(CbsEvents)this.checkedListBox1.Items[e.Index];
      if (ItemEventChecked != null)
        ItemEventChecked(cbsEvents,e);
    }
  }
}
