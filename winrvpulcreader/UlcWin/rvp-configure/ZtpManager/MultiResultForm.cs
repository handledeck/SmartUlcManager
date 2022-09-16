using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Ztp.Protocol;
using ZtpManager.Scope;

namespace ZtpManager
{
  public partial class MultiResultForm : Form
  {
    private DeviceActionResult _result;
    private DeviceActionMode _mode;
    public MultiResultForm(DeviceActionMode mode, DeviceActionResult result)
    {
      if (result == null) throw new ArgumentNullException(nameof(result));
      _result = result;
      _mode = mode;
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
      lv.Columns.Add(new OLVColumn("Наименование", "DeviceName"));
      lv.Columns[0].Width = 150;
      ((OLVColumn)lv.Columns[0]).ImageGetter = (o) => ((ResultItem)o).IsError ? 1 : 0;

      lv.Columns.Add(new OLVColumn("Сообщение", "Message"));
      lv.Columns[1].Width = 400;
    }

    void Fill()
    {
      List<ResultItem> list = new List<ResultItem>();
      foreach (ActionResult res in _result.Values)
      {
        ResultItem item = new ResultItem()
        {
          DeviceName = GetDeviceName(res.DeviceId)
        };
        list.Add(item);
        Exception e = res.Value as Exception;
        if (e != null)
        {
          item.Message = e.Message;
          item.IsError = true;
          continue;
        }
        switch (_mode)
        {
          case DeviceActionMode.Reboot:
          case DeviceActionMode.SetPwd:
          case DeviceActionMode.Switch:
          case DeviceActionMode.Fota:
          case DeviceActionMode.Write:
          case DeviceActionMode.Patch:
            WritePwdAnswer r = (WritePwdAnswer)res.Value;
            item.Message = r.DisplayMessage;
            item.IsError = !r.IsOk;
            break;
        }
      }
      lv.SetObjects(list);
    }

    string GetDeviceName(int deviceId)
    {
      ScopeItem item = ScopeArea.Default[deviceId];
      if (item == null)
        return "";
      return item.DeviceName;
    }
    class ResultItem
    {
      public string DeviceName { get; set; }
      public string Message { get; set; }
      public bool IsError { get; set; }
    }
  }
}
