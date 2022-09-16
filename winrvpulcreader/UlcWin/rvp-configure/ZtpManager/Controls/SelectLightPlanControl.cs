using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Ztp.Configuration;
using Ztp.Model;
using Ztp.Utils;
using ZtpManager.DataAccessLayer;

namespace ZtpManager.Controls
{
  public partial class SelectLightPlanControl : UserControl
  {
    public SelectLightPlanControl()
    {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      InitializeListView();
      Fill();
      ShowHtml(GetEmptyHtml());
    }

    void InitializeListView()
    {
      flv.ListView.SmallImageList = iml;
      flv.ListView.MultiSelect = false;
      flv.ListView.Columns.Add(new OLVColumn("Наименование", LightPlanFld.DisplayName));
      flv.ListView.Columns[0].Width = 200;
      ((OLVColumn)flv.ListView.Columns[0]).ImageGetter = (o) => 0;
      flv.ListView.Columns.Add(new OLVColumn("Описание", LightPlanFld.Description));
      flv.ListView.Columns[1].Width = 200;
      flv.RefreshButton.Click += RefreshButton_Click;
      flv.ListView.SelectionChanged += ListView_SelectionChanged;
    }

    public LightPlan SelectedLightPlan
    {
      get
      {
        if (flv.ListView.SelectedObjects.Count == 0)
          return null;
        return (LightPlan) flv.ListView.SelectedObjects[0];
      }
    }
    void ShowHtml(string html)
    {
      webBrowser.DocumentText = html;
    }
    private void ListView_SelectionChanged(object sender, EventArgs e)
    {
      string html;
      if (flv.ListView.SelectedObjects.Count > 0)
      {
        LightPlan plan = (LightPlan) flv.ListView.SelectedObjects[0];
        byte[] buff = Convert.FromBase64String(plan.Body);
        ZtpScheduler scheduler = ZtpScheduler.Deserialize(buff);
        html = scheduler.ToHtml();
      }
      else
      {
        html = GetEmptyHtml();
      }
      ShowHtml(html);
    }

    private void RefreshButton_Click(object sender, EventArgs e)
    {
      Fill();
    }

    void Fill()
    {
      if(Dal.Default.IsConnected)
        flv.ListView.SetObjects(Dal.Default.ReadLightPlans());
    }

    string GetEmptyHtml()
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine("<html>");
      sb.AppendLine("<body>");
      sb.AppendLine("<font size=\"2\" face=\"Microsoft Sans Serif\">Нет информации для отображения</font>");
      sb.AppendLine("</body>");
      sb.AppendLine("</html>");
      return sb.ToString();
    }
  }
}
