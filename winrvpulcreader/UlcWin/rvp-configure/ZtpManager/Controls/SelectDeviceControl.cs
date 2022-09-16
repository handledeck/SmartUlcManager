using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Ztp.Model;
using ZtpManager.Scope;

namespace ZtpManager.Controls
{
  public partial class SelectDeviceControl : UserControl
  {

    public DeviceKind _kind = DeviceKind.Unknown;
    public SelectDeviceControl()
    {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      InitializeListView();
      InitializeTreeView();
      Fill();

    }


    void InitializeListView()
    {
      flv.ListView.SmallImageList = iml;

      flv.ListView.Columns.Add(new OLVColumn("Устройство", "DisplayName"));
      flv.ListView.Columns[0].Width = 150;
      ((OLVColumn)flv.ListView.Columns[0]).ImageGetter = (o) => ((NodeEx)o).IsError ? 3 : 0;

      flv.ListView.Columns.Add(new OLVColumn("Путь", "DisplayPath"));
      flv.ListView.Columns[1].Width = 300;


      flv.RefreshButton.Click += RefreshButton_Click;
      flv.ListView.SelectionChanged += ListView_SelectionChanged;
    }

    private void ListView_SelectionChanged(object sender, EventArgs e)
    {
      OnSelectionChanged();
    }

    void InitializeTreeView()
    {
      tv.Initialize();
      tv.AfterCheck += Tv_AfterCheck;
    }

    public event EventHandler SelectionChanged;
    private void Tv_AfterCheck(object sender, TreeViewEventArgs e)
    {
      OnSelectionChanged();
    }

    public void RefreshObj()
    {
      ScopeArea.Default.Fill();
      //flv.ListView.SetObjects(ScopeArea.Default.GetDeviceNodes());
      flv.ListView.SetObjects(ScopeArea.Default.GetDeviceNodes(_kind));
    }

    private void RefreshButton_Click(object sender, EventArgs e)
    {
      ScopeArea.Default.Fill();
      //flv.ListView.SetObjects(ScopeArea.Default.GetDeviceNodes());
      flv.ListView.SetObjects(ScopeArea.Default.GetDeviceNodes(_kind));
    }

    void Fill()
    {
      //flv.ListView.SetObjects(ScopeArea.Default.GetDeviceNodes());
      flv.ListView.SetObjects(ScopeArea.Default.GetDeviceNodes(_kind));
    }

    public List<NodeEx> SelectedDevices
    {
      get
      {
        List < NodeEx > retVal = new List<NodeEx>();
        if (tabControl.SelectedTab == tpList)
        {
          foreach (NodeEx nodeEx in flv.ListView.SelectedObjects)
          {
            retVal.Add(nodeEx);
          }
        }
        else if (tabControl.SelectedTab == tpTree)
        {
          return tv.SelectedDevices;
        }
        return retVal;
      }
    }

    public void UnselectDevice(NodeEx node)
    {
      if(tabControl.SelectedTab == tpList)
      {
        
      }
      else if(tabControl.SelectedTab == tpTree)
      {
        tv.Uncheck(node);
      }
    }

    public void CheckAllNodes(bool nodeChecked)
    {
      if (tabControl.SelectedTab == tpList)
      {
        //todo выделение всех 
        foreach(ListViewItem d in flv.ListView.Items)
        {
          d.Selected = true;
        }
      }
      else if (tabControl.SelectedTab == tpTree)
      {
        tv.CheckAllNodes(nodeChecked);
      }
    }

    public List<NodeEx> GetSelectedDeviceByType(DeviceKind kind)
    {
      List<NodeEx> retVal = new List<NodeEx>();
      if (tabControl.SelectedTab == tpList)
      {
        foreach (NodeEx nodeEx in flv.ListView.SelectedObjects)
        {
          if (nodeEx.DevType != kind)
            continue;
          retVal.Add(nodeEx);
        }
      }
      else if (tabControl.SelectedTab == tpTree)
      {
        retVal = tv.SelectedDevices;
        foreach(NodeEx nodeEx in retVal)
        {
          if (nodeEx.DevType != kind)
            retVal.Remove(nodeEx);
        }
      }
      return retVal;
    }

    public void SetActiveDevice(DeviceKind kind)
    {
      //tv.ShowDevicesByType(kind);
      tv.DevKind = kind;
      tv.Initialize();
    }

    protected virtual void OnSelectionChanged()
    {
      SelectionChanged?.Invoke(this, EventArgs.Empty);
    }

    private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
      OnSelectionChanged();
    }

    //private void dd()
    //{
    //  tv.Nodes.
    //}

  }
}
