using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using BrightIdeasSoftware;
using Ztp.Model;

namespace ZtpManager
{
  public partial class ObjectListForm : Form
  {
    public ObjectListForm()
    {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      InitializeListView();
      Fill();
    }

    void InitializeListView()
    {
      flv.ListView.SmallImageList = iml;

      flv.ListView.Columns.Add(new OLVColumn("Наименование", NodeFld.DisplayName));
      flv.ListView.Columns[0].Width = 150;
      ((OLVColumn)flv.ListView.Columns[0]).ImageGetter = (o) => 0;

      flv.ListView.Columns.Add(new OLVColumn("Адрес", NodeFld.IpAddress));
      flv.ListView.Columns[1].Width = 150;


      flv.ListView.Columns.Add(new OLVColumn("Путь", "DisplayPath"));
      flv.ListView.Columns[2].Width = 300;

      flv.ListView.Columns.Add(new OLVColumn("Описание", NodeFld.Description));
      flv.ListView.Columns[3].Width = 300;

      flv.RefreshButton.Visible = false;
    }


    void Fill()
    {
      flv.ListView.SetObjects(Scope.ScopeArea.Default.GetDeviceNodes());
    }

    private void tsbSaveAsXml_Click(object sender, EventArgs e)
    {
      sfd.DefaultExt = "xml";
      sfd.Filter = "Файлы *.xml|*.xml";
      if (sfd.ShowDialog(this) == DialogResult.OK)
      {
        List<XmlItem> list = new List<XmlItem>();
        foreach (OLVListItem item in flv.ListView.Items)
        {
          NodeEx node = item.RowObject as NodeEx;
          list.Add(new XmlItem(){DisplayName = node.DisplayName, DisplayPath = node.DisplayPath, IpAddress = node.IpAddress, Description = node.Description});
        }
        using (System.IO.StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
        {
          System.Xml.Serialization.XmlSerializer ser = new XmlSerializer(typeof(XmlItem[]));
          ser.Serialize(sw, list.ToArray());
        }
      }
    }


    private void tsbSaveAsCsv_Click(object sender, EventArgs e)
    {
      sfd.DefaultExt = "csv";
      sfd.Filter = "Файлы *.csv|*.csv";
      if (sfd.ShowDialog(this) == DialogResult.OK)
      {
        using (System.IO.StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
        {
          foreach (OLVListItem item in flv.ListView.Items)
          {
            NodeEx node = item.RowObject as NodeEx;
            sw.WriteLine($"{node.DisplayName};{node.IpAddress};{node.DisplayPath};{node.Description}");
          }
        }
      }
    }

    [Serializable]
    public class XmlItem
    {
      public string DisplayName { get; set; }
      public string DisplayPath { get; set; }
      public string Description { get; set; }
      public string IpAddress { get; set; }
    }
  }
}
