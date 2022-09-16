using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Ztp.Model;
using Ztp.Protocol;
using Ztp.IO.Logger;
using ZtpManager.DeviceAccessLayer;
using ZtpManager.DataAccessLayer;
using System.Windows.Forms;
using Ztp.Ui;

namespace ZtpManager
{
  public partial class MultiPatchForm : Form
  {
    public MultiPatchForm()
    {
      InitializeComponent();
      this.selectDeviceControl.SetActiveDevice(DeviceKind.ULC02);
      Application.Idle += Application_Idle;
      UpdateStatusText();
    }

    private void selectDeviceControl_SelectionChanged(object sender, EventArgs e)
    {
      UpdateStatusText();
    }

    void UpdateStatusText()
    {
      int count = selectDeviceControl.SelectedDevices.Count;
      label1.Text = $"Выбрано для записи {count} устройств";
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      btnStartWrite.Enabled = selectDeviceControl.SelectedDevices.Count > 0;
      if (btnStartWrite.Enabled)
      {
        btnCheckVersion.Text = "Проверить версии ядра";
      }
      else
      {
        btnCheckVersion.Text = "Поиск устройств с устаревшей версией ядра";
      }
    }

    public List<NodeEx> SelectedDevices
    {
      get { return selectDeviceControl.SelectedDevices; }
    }

    void MultiCheckCoreVer(List<NodeEx> devices)
    {
      DeviceActionResult deviceActionResult = null;
      int[] deviceIds = devices.ToArrayOfIds();
      DevAl.Default.ActionCheckCore(this, new DeviceActionArg(DeviceActionMode.TestCore)
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
      //возврат списка MyList.First(item => item.name == "foo").value;
      foreach (ActionResult res in deviceActionResult.Values)
      {
        string status = string.Empty;
        if(res.Value is string)
        {
          if (((string)res.Value).CompareTo("12.01.830-B006") == 0)
          {
            status = "Обновление не требуется";
            //uncheck node
            selectDeviceControl.UnselectDevice(devices.First<NodeEx>(item => item.Id == res.DeviceId));
          }
          else if (((string)res.Value).CompareTo("12.00.839") == 0)
          {
            status = "Необходим патч ядра";
          }
          else if (((string)res.Value).CompareTo("12.01.830") == 0)
          {
            status = "Необходим патч ядра";
          }
        }
        else
        {
          if(((Exception)res.Value).Message.Contains("Превышение "))
          {
            res.Value = "???";
            status = "Устройство с устаревшей версией прошивки";
          }
          else if(((Exception)res.Value).Message.Contains("Попытка") || ((Exception)res.Value).Message.Contains("Подключение"))
          {
            res.Value = "---";
            status = "Устройство не отвечает";
          }
          else if(((Exception)res.Value).Message.Contains("отверг запрос"))
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

    private void btnCheckVersion_Click(object sender, EventArgs e)
    {
      listView1.Items.Clear();
      selectDeviceControl.CheckAllNodes(true);
      MultiCheckCoreVer(selectDeviceControl.SelectedDevices);
      btnCheckVersion.Enabled = false;
    }

    private void btnStartWrite_Click(object sender, EventArgs e)
    {
      int count = selectDeviceControl.SelectedDevices.Count;
      if (count == 0)
        return;
      string msg = $"Вы уверены что хотите записать патч ядра контроллера в указанные устройства (устройств: {count})?";
      if (!Box.Confirm(this, msg))
        return;
      DialogResult = DialogResult.OK;
    }
  }
}
