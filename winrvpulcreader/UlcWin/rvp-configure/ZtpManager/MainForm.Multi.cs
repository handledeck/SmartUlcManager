using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ztp;
using Ztp.Configuration;
using Ztp.IO.Logger;
using Ztp.Model;
using Ztp.Protocol;
using Ztp.Ui;
using Ztp.Utils;
using ZtpManager.DataAccessLayer;
using ZtpManager.DeviceAccessLayer;
using ZtpManager.Scope;

namespace ZtpManager
{
  partial class MainForm
  {
    void MultiSwitchOnOff(List<NodeEx> devices, bool isOn)
    {
      DeviceActionResult deviceActionResult = null;
      int[] deviceIds = devices.ToArrayOfIds();
      DevAl.Default.ActionWriteSwitchOnOff(this,
        new DeviceActionArg(DeviceActionMode.Switch)
        {
          Log = NullLog.Null,
          DeviceIds = deviceIds,
          GetNewSwitchOnFunc = (id) => isOn,
          ReadTcpSetingFunc = Dal.Default.CreateTcpPortSettings
        },
        result =>
        {
          deviceActionResult = result;
        });
      ShowMultiResult(DeviceActionMode.Switch, deviceActionResult);
    }

    void MultiChangePassword(List<NodeEx> devices, string newPassword)
    {
      DeviceActionResult deviceActionResult = null;
      int[] deviceIds = devices.ToArrayOfIds();
      DevAl.Default.ActionWriteSetPassword(this,
        new DeviceActionArg(DeviceActionMode.SetPwd)
        {
          Log = NullLog.Null,
          DeviceIds = deviceIds,
          GetNewPasswordFunc = (id) => newPassword,
          ReadTcpSetingFunc = Dal.Default.CreateTcpPortSettings
        },
        result =>
        {
          deviceActionResult = result;
        });
      foreach (ActionResult actionResult in deviceActionResult.Values)
      {
        ScopeItem item = Scope.ScopeArea.Default[actionResult.DeviceId];
        if (item == null)
          continue;
        if (!item.NodeEx.IsError)
        {
          item.NodeEx.Password = StringUtils.ToBase64String(newPassword);
        }
        Scope.ScopeArea.Default.EditDevice(item.NodeEx);
      }

      ShowMultiResult(DeviceActionMode.SetPwd, deviceActionResult);
    }

    void MultiWriteConfig(List<NodeEx> devices, ZtpConfig zc)
    {
      DeviceActionResult deviceActionResult = null;
      int[] deviceIds = devices.ToArrayOfIds();
      DevAl.Default.ActionWriteConfig(this,
        new DeviceActionArg(DeviceActionMode.Write)
        {
          Log = NullLog.Null,
          DeviceIds = deviceIds,
          GetNewZtpConfigFunc = (id) => zc,
          ReadTcpSetingFunc = Dal.Default.CreateTcpPortSettings
        },
        result =>
        {
          deviceActionResult = result;
        });
        ShowMultiResult(DeviceActionMode.Write, deviceActionResult);
    }

    void MultiWriteReboot(List<NodeEx> devices)
    {
      DeviceActionResult deviceActionResult = null;
      int[] deviceIds = devices.ToArrayOfIds();
      DevAl.Default.ActionWriteReboot(this, new DeviceActionArg(DeviceActionMode.Reboot)
      {
        Log = NullLog.Null,
        DeviceIds = deviceIds,
        ReadTcpSetingFunc = Dal.Default.CreateTcpPortSettings
      },
      result =>
      {
        deviceActionResult = result;
      });
      ShowMultiResult(DeviceActionMode.Reboot, deviceActionResult);
    }

    void ShowMultiResult(DeviceActionMode mode, DeviceActionResult result)
    {
      if(result == null || result.Values == null) return;
      //для изменения значка устройства в зависимости от успешности последней операции
      foreach (ActionResult actionResult in result.Values)
      {
        if (mode == DeviceActionMode.Switch)
        {
          ZtpConfigForm configForm = _childFormControl.FindZtpConfigForm(actionResult.DeviceId);
          if(configForm != null)
            configForm.SetUseScheduler(false);
        }
        ScopeItem item = Scope.ScopeArea.Default[actionResult.DeviceId];
        if(item == null)
          continue;
        Scope.ScopeArea.Default.EditDevice(item.NodeEx);
      }

      using (MultiResultForm frm = new MultiResultForm(mode, result))
      {
        frm.ShowDialog(this);
      }
    }
    //XXX
    void MultiWriteFota(List<NodeEx> devices, ZtpFileInfo modemFile, ZtpFileInfo controllerFile)
    {
      DeviceActionResult deviceActionResult = null;
      int[] deviceIds = devices.ToArrayOfIds();
      if(devices[0].DevType == DeviceKind.RVP18)
      {
        Fal.Default.ActionWriteFota(this, new Fal.FotaArg()
        {
          ControllerFile = controllerFile,
          ModemFile = modemFile,
          DeviceIds = deviceIds,
          ReadTcpSetingFunc = Dal.Default.CreateTcpPortSettings
        }, (result) =>
        {
          deviceActionResult = result;
        });
      }
      else if(devices[0].DevType == DeviceKind.ULC02)
      {
        Fal.Default.ActionWriteFotaTelit(this, new Fal.FotaArg()
        {
          ModemFile = modemFile,
          DeviceIds = deviceIds,
          ReadTcpSetingFunc = Dal.Default.CreateTcpPortSettings
        }, (result) =>
        {
          deviceActionResult = result;
        });
      }
      ShowMultiResult(DeviceActionMode.Fota, deviceActionResult);
    }

    void MultiWritePatch(List<NodeEx> devices)
    {
      DeviceActionResult deviceActionResult = null;
      int[] deviceIds = devices.ToArrayOfIds();
      Fal.Default.ActionWritePatch(this, new Fal.PatchArg()
      {
        DeviceIds = deviceIds,
        ReadTcpSetingFunc = Dal.Default.CreateTcpPortSettings
      }, (result) =>
      {
        deviceActionResult = result;
      });
      ShowMultiResult(DeviceActionMode.Patch, deviceActionResult);
    }


    void SyncFromEst()
    {
      WaitForm wait = new WaitForm("Обновление описаний", (s, a) =>
      {
        List<ScopeItem> items = Est.EstAccess.SyncFromEst();
        a.Result = items;
        foreach (ScopeItem item in items)
        {
          Dal.Default.EditNode(item.NodeEx);
        }
      }, (s, a) =>
      {
        if (a.Error != null)
        {
          ShowErrorAsync(a.Error);
          return;
        }
        try
        {
          tv.BeginUpdate();
          List<ScopeItem> items = (List<ScopeItem>) a.Result;
          foreach (ScopeItem item in items)
          {
            ScopeArea.Default.EditDevice(item.NodeEx);
          }
        }
        catch (Exception e)
        {
          ShowErrorAsync(e);
        }
        finally
        {
          tv.EndUpdate();
        }
      });
      wait.ShowDialog(this);
    }
  }
}
