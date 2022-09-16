using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp;
using Ztp.IO.Logger;
using Ztp.Model;
using Ztp.Protocol;
using Ztp.Ui;
using ZtpManager.DataAccessLayer;
using ZtpManager.DeviceAccessLayer;

namespace ZtpManager
{
  public partial class MultiFotaForm : Form
  {
    DeviceKind _kind = DeviceKind.Unknown;

    public MultiFotaForm()
    {
      InitializeComponent();
      //Application.Idle += Application_Idle;
      fotaInfoTelit.Height += 30;
      //if (rbRVP18.Checked)
      //{
      //  fotaInfo.Show();
      //  fotaInfoTelit.Hide();
      //  _kind = DeviceKind.RVP18;
      //}
      //else
      //{
      //  fotaInfo.Hide();
      //  fotaInfoTelit.Show();
      //  _kind = DeviceKind.ULC02;
      //}
      //selectDeviceControl.SetActiveDevice(_kind);
      //selectDeviceControl._kind = _kind;

      selectDevTypeControl.SelectedItemChanged += DeviceTypeChange;
      Application.Idle += Application_Idle;
      _kind = (DeviceKind)(selectDevTypeControl.Value);
      btnCheckVersion.Visible = (_kind == DeviceKind.RVP18) ? false : true;
      if (_kind == DeviceKind.RVP18)
      {
        fotaInfo.Show();
        fotaInfoTelit.Hide();
      }
      else
      {
        fotaInfo.Hide();
        fotaInfoTelit.Show();
      }
      this.selectDeviceControl.SetActiveDevice(_kind);
      this.selectDeviceControl._kind = _kind;
      this.selectDeviceControl.RefreshObj();
      //partitionConfigEditor.ViewConfigByDevType((Ztp.Enums.DevType)_kind);
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
      Application.Idle += Application_Idle;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      btnOk.Enabled = selectDeviceControl.SelectedDevices.Count > 0 &&
        ((_kind == DeviceKind.ULC02) ? fotaInfoTelit.ModemFile != null : 
        (fotaInfo.ModemFile != null && fotaInfo.ControllerFile != null));
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      UpdateStatusText();
      selectDeviceControl.SelectionChanged += ListView_SelectionChanged;
    }

    private void DeviceTypeChange(object sender, EventArgs e)
    {
      DeviceKind kind = (DeviceKind)(((ComboBox)sender).SelectedIndex + 1); //((ComboBox)sender).SelectedIndex == 0 ? DeviceKind.RVP18 : DeviceKind.ULC02;
      btnCheckVersion.Visible = (kind == DeviceKind.RVP18) ? false : true;
      if(kind == DeviceKind.RVP18)
      {
        fotaInfo.Show();
        fotaInfoTelit.Hide();
      }
      else if(kind == DeviceKind.ULC02)
      {
        fotaInfo.Hide();
        fotaInfoTelit.Show();
      }
      else
      {
        fotaInfo.Hide();
        fotaInfoTelit.Hide();
      }
      this.selectDeviceControl.SetActiveDevice(kind);
      this.selectDeviceControl._kind = kind;
      this.selectDeviceControl.RefreshObj();
      //partitionConfigEditor.ViewConfigByDevType((Ztp.Enums.DevType)kind);
    }

    private void ListView_SelectionChanged(object sender, EventArgs e)
    {
      UpdateStatusText();
    }

    void UpdateStatusText()
    {
      int count = selectDeviceControl.SelectedDevices.Count;
      label1.Text = $"Выбрано для записи {count} устройств";
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      int count = selectDeviceControl.SelectedDevices.Count;
      if (count == 0)
        return;
      string msg = $"Вы уверены что хотите записать ПО контроллера в указанные устройства (устройств: {count})?";
      if (!Box.Confirm(this, msg))
        return;
      DialogResult = DialogResult.OK;
    }

    public List<NodeEx> SelectedDevices
    {
      get { return selectDeviceControl.SelectedDevices; }
    }

    public ZtpFileInfo ModemFile
    {
      get
      {
        if (_kind == DeviceKind.RVP18/*rbRVP18.Checked*/)
          return fotaInfo.ModemFile;
        else if (_kind == DeviceKind.ULC02)
          return fotaInfoTelit.ModemFile;
        else return null;
      }
    }

    public ZtpFileInfo ControllerFile
    {
      get { return fotaInfo.ControllerFile; }
    }

    private void btnCheckVersion_Click(object sender, EventArgs e)
    {
      string version = fotaInfoTelit.GetVesrion();
      listView1.Items.Clear();
      selectDeviceControl.CheckAllNodes(true);
      MultiCheckVersion(selectDeviceControl.SelectedDevices, version);
    }

    private void MultiCheckVersion(List<NodeEx> devices, string vers)
    {
      DeviceActionResult deviceActionResult = null;
      int[] deviceIds = devices.ToArrayOfIds();
      DevAl.Default.ActionCheckVersion(this, new DeviceActionArg(DeviceActionMode.TestVersion)
      {
        Log = NullLog.Null,
        DeviceIds = deviceIds,
        ReadTcpSetingFunc = Dal.Default.CreateTcpPortSettings
      },
      result =>
      {
        deviceActionResult = result;
      });
      //todo вывод полученных данных и обработка
      foreach(ActionResult res in deviceActionResult.Values)
      {
        string status = string.Empty;
        //регулярка, с поиском версии устрйоства!!!
        if (res.Value is string)
        {
          int reas = ((string)res.Value).CompareTo(vers);
          if (((string)res.Value).CompareTo(vers) >= 0)
          {
            status = "Обновление не требуется";
            //uncheck node
            selectDeviceControl.UnselectDevice(devices.First<NodeEx>(item => item.Id == res.DeviceId));
          }
          else 
          {
            status = "Прошивка устарела, рекомендуется обновление";
          }
        }
        else
        {
          if (((Exception)res.Value).Message.Contains("Попытка") || ((Exception)res.Value).Message.Contains("Подключение"))
          {
            res.Value = "---";
            status = "Устройство не отвечает";
          }
          else if (((Exception)res.Value).Message.Contains("отверг запрос"))
          {
            res.Value = "XXX";
            status = "Устройство занято другим клиентом";
          }
          selectDeviceControl.UnselectDevice(devices.First<NodeEx>(item => item.Id == res.DeviceId));
        }
        string[] arr = new string[]
        {
          res.DeviceId.ToString(),
          devices.First<NodeEx>(item => item.Id == res.DeviceId).IpAddress, //изъятие IP из пула
          res.Value.ToString(),
          status
        };

        listView1.Items.Add(new ListViewItem(arr));
      }
    }
  }
}
