using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Ztp.Ui;
using Ztp.Utils;
using ZtpManager.DataAccessLayer;
using ZtpManager.Est;

namespace ZtpManager
{
  public partial class EstDevicesForm : Form
  {
    private List<EstAccess.ZtpDeviceInfo> _sourceList;

    public EstDevicesForm()
    {
      InitializeComponent();
      
      flvEst.ListView.Columns.Add(new OLVColumn("Драйвер", "ModuleName"));
      flvEst.ListView.Columns[0].Width = 300;
      ((OLVColumn) flvEst.ListView.Columns[0]).ImageGetter = (o) =>
      {
        EstAccess.ZtpDeviceInfo di = (EstAccess.ZtpDeviceInfo) o;
        return di.IsExists ? 1 : 0;
      };
      flvEst.ListView.Columns.Add(new OLVColumn("Наименование", "Name"));
      flvEst.ListView.Columns[1].Width = 200;
      flvEst.ListView.Columns.Add(new OLVColumn("Адрес", "Address"));
      flvEst.ListView.Columns[2].Width = 100;
      flvEst.ListView.SmallImageList = iml;

      flvEst.RefreshButton.Click += RefreshButton_Click;
      this.Shown += EstDevicesForm_Shown;
    }

    private const string _waitFormCaption = "Чтение устройств EST Tools";
    private void RefreshButton_Click(object sender, EventArgs e)
    {
      using (WaitForm frm = new WaitForm(_waitFormCaption, DoWork, RunWorkerCompleted))
        frm.ShowDialog();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      base.OnClosing(e);
      e.Cancel = true;
      Hide();
    }

    private void EstDevicesForm_Shown(object sender, EventArgs e)
    {
      if (_sourceList == null)
      {
        using (WaitForm frm = new WaitForm(_waitFormCaption, DoWork, RunWorkerCompleted))
          frm.ShowDialog();
      }
      else
      {
        using (WaitForm frm = new WaitForm(_waitFormCaption, SetIsExistsProperty, (s, arg) => { flvEst.ListView.SetObjects(_sourceList); }))
          frm.ShowDialog();
      }
    }

    private void DoWork(object sender, DoWorkEventArgs e)
    {
      List<EstAccess.ZtpDeviceInfo> deviceInfos = Est.EstAccess.GetZtpDiviceInfos();
      e.Result = deviceInfos;
    }

    private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.Enabled = true;
      Cursor = Cursors.Default;
      if (e.Error != null)
      {
        Box.Error(this, e.Error);
        return;
      }
      _sourceList = e.Result as List<EstAccess.ZtpDeviceInfo>;
      SetIsExistsProperty(null, null);
      flvEst.ListView.SetObjects(_sourceList);
    }

    void SetIsExistsProperty(object sender, DoWorkEventArgs e)
    {
      foreach (EstAccess.ZtpDeviceInfo deviceInfo in _sourceList)
        deviceInfo.IsExists = false;

      Dictionary<string, EstAccess.ZtpDeviceInfo> dic = new Dictionary<string, EstAccess.ZtpDeviceInfo>();
      foreach (EstAccess.ZtpDeviceInfo di in _sourceList)
        dic[di.CommStateGuid] = di;

      foreach (string guid in Dal.Default.GetEstToolsCommStateGuids())
      {
        if (dic.ContainsKey(guid))
          dic[guid].IsExists = true;
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      SelectedDevices.Clear();
      foreach (EstAccess.ZtpDeviceInfo di in flvEst.ListView.SelectedObjects)
      {
        if(di.IsExists)
          continue;
        SelectedDevices.Add(di);
      }
      if (SelectedDevices.Count == 0)
      {
        Box.Warning(this, "Не указано ни одного доступного устройства");
        return;
      }

      Exception validatePassword = pswEdit.ValidatePassword();
      if (validatePassword != null)
      {
        Box.Error(this, validatePassword);
        return;
      }
      Password = pswEdit.Value;
      DialogResult = Result = DialogResult.OK;
    }

    public DialogResult Result { get; set; }
    public List<EstAccess.ZtpDeviceInfo> SelectedDevices { get; } = new List<EstAccess.ZtpDeviceInfo>();
    public string Password { get; private set; }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      DialogResult = Result = DialogResult.Cancel;
    }
  }
}
