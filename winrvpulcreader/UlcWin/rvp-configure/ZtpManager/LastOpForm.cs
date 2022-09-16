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
using ZtpManager.DataAccessLayer;

namespace ZtpManager
{
  public partial class LastOpForm : Form
  {
    public LastOpForm()
    {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      InitializeListView();
      Fill();
    }

    void Fill()
    {
      flv.ListView.SetObjects(Dal.Default.ReadLastOperations());
    }

    void InitializeListView()
    {
      flv.ListView.SmallImageList = iml;

      flv.ListView.Columns.Add(new OLVColumn("Наименование", NodeFld.DisplayName));
      flv.ListView.Columns[0].Width = 150;
      ((OLVColumn)flv.ListView.Columns[0]).ImageGetter = (o) => Convert.ToInt32(((LastOperation)o).IsError);

      flv.ListView.Columns.Add(new OLVColumn("Дата", OpHistoryFld.OpDate));
      flv.ListView.Columns[1].Width = 100;

      flv.ListView.Columns.Add(new OLVColumn("Операция", OpHistoryFld.OpName));
      flv.ListView.Columns[2].Width = 100;

      flv.ListView.Columns.Add(new OLVColumn("Результат", OpHistoryFld.OpResult));
      flv.ListView.Columns[3].Width = 100;

      flv.ListView.Columns.Add(new OLVColumn("Объект", OpHistoryFld.ObjText));
      flv.ListView.Columns[4].Width = 100;


      flv.ListView.Columns.Add(new OLVColumn("Адрес", NodeFld.IpAddress));
      flv.ListView.Columns[5].Width = 150;

      flv.ListView.Columns.Add(new OLVColumn("Путь", "DisplayPath"));
      flv.ListView.Columns[6].Width = 300;
      flv.RefreshButton.Visible = false;
    }

    private void tsbSaveAsXml_Click(object sender, EventArgs e)
    {
      sfd.DefaultExt = "xml";
      sfd.Filter = "Файлы *.xml|*.xml";
      if (sfd.ShowDialog(this) == DialogResult.OK)
      {
        using (System.IO.StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
        {
          XmlSerializer ser = new XmlSerializer(typeof(List<LastOperation>));
          ser.Serialize(sw, flv.ListView.Objects);
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
            LastOperation obj = item.RowObject as LastOperation;
            sw.WriteLine($"{obj.DisplayName};{obj.IpAddress};{obj.DisplayPath};{obj.IsError};{obj.OpDate};{obj.OpName};{obj.OpResult};{obj.ObjText}");
          }
        }
      }

    }
  }
}
