using System;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace ZtpManager.Controls
{
  public partial class FilteredListViewControl : UserControl
  {
    private readonly ObjectListView listView;
    public FilteredListViewControl()
    {
      InitializeComponent();
      listView = new ObjectListView(); 
      Controls.Add(listView);
      listView.BringToFront();
      listView.FullRowSelect = true;
      listView.ShowGroups = false;
      listView.HideSelection = false;
      listView.MultiSelect = true;
      listView.Dock = DockStyle.Fill;
      listView.SmallImageList = iml;
      listView.View = View.Details;
      listView.UseFiltering = true;
      FilteredListViewControl_SizeChanged(null, null);
    }

    public ObjectListView ListView
    {
      get { return listView; }
    }

    public ToolStripButton RefreshButton
    {
      get { return tsbRefresh; }
    }

    public ToolStripTextBox FilterTextBox
    {
      get { return tstbFilter; }
    }

    private void tstbFilter_TextChanged(object sender, EventArgs e)
    {
      string filter = tstbFilter.Text.Trim();
      listView.AdditionalFilter = TextMatchFilter.Contains(listView, filter);
    }

    private void FilteredListViewControl_SizeChanged(object sender, EventArgs e)
    {
      tstbFilter.Width = toolStrip.ClientSize.Width - toolStripLabel1.Width - tsbRefresh.Width - 20;
    }
  }
}
