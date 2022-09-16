using System;
using System.Linq;
using System.Windows.Forms;
using Bss.Sys.IO;
using ZtpManager.DataAccessLayer;
using ZtpManager.Scope;
using TabControl = MdiTabControl.TabControl;
using TabPage = MdiTabControl.TabPage;

namespace ZtpManager
{

  public interface IChildFormControlOwner
  {
    void BeginUserAction();
    void EndUserAction();
    MdiTabControl.TabControl TabControl { get; }
  }

  public class ChildFormControl
  {
    public event EventHandler<StartForm.RaiseActionEventArgs> RaiseStartFormAction;
    private readonly IChildFormControlOwner _owner;
    public ChildFormControl(IChildFormControlOwner owner)
    {
      if (owner == null) throw new ArgumentNullException(nameof(owner));
      _owner = owner;
      ScopeArea.Default.NodeRemoved += ScopeArea_NodeRemoved;
      ScopeArea.Default.NodeChanged += ScopeArea_NodeChanged;
    }

    public event EventHandler NeedEnableUpdate;
    protected virtual void OnNeedEnableUpdate()
    {
      NeedEnableUpdate?.Invoke(this, EventArgs.Empty);
    }

    public ZtpConfigForm FindZtpConfigForm(int deviceId)
    {
      int index = FindIndexFromById(deviceId);
      if (index == -1)
        return null;
      return _owner.TabControl.TabPages[index].Form as ZtpConfigForm;
    }

    StartForm FindStartForm()
    {
      StartForm retVal = null;
      foreach (TabPage page in _owner.TabControl.TabPages)
      {
        retVal = page.Form as StartForm;
        if (retVal != null)
          break;
      }
      return retVal;
    }

    public void SetControlsEnabled()
    {
      StartForm frm = FindStartForm();
      if(frm == null)
        return;
      frm.lnkMultiFota.Enabled = 
        frm.lnkMultiWriteConfig.Enabled = 
        frm.lnkMultiReboot.Enabled =
        frm.lnkMultiWriteChangePassword.Enabled =
        frm.lnkMultiWriteSwitchOnOff.Enabled = Dal.Default.IsConnected;
    }

    public void CloseZtpConfigForms(int[] deviceIds)
    {
      for (int i = _owner.TabControl.TabPages.Count - 1; i > -1; i--)
      {
        ZtpConfigForm frm = _owner.TabControl.TabPages[i].Form as ZtpConfigForm;
        if (frm==null)
          continue;
        if (deviceIds.Where((v) => v == frm.ScopeItem.NodeEx.Id).Any())
          frm.Close();
      }
    }

    private void ScopeArea_NodeChanged(Scope.ScopeArea.NodeChangedEventArg e)
    {
      int deviceId = e.ChangedNode.Id;
      int index = FindIndexFromById(deviceId);
      if (index > -1)
      {
        ZtpConfigForm form = _owner.TabControl.TabPages[index].Form as ZtpConfigForm;
        if(form == null)
          return;
        form.Text = e.ChangedNode.DisplayName;
        ScopeItem item = ScopeArea.Default[deviceId];
        form.SetConfigToControls(item.ZtpConfig);
      }
    }

    private void ScopeArea_NodeRemoved(Scope.ScopeArea.NodeRemovedEventArg e)
    {
      int deviceId = e.RemovedNode.Id;
      int index = FindIndexFromById(deviceId);
      if(index > -1)
        _owner.TabControl.TabPages.RemoveAt(index);
    }

    public void ShowStartForm()
    {
      StartForm frm = FindStartForm();
      if(frm != null)
        return;
      frm = new StartForm();
      frm.RaiseAction += (s, a) => { OnRaiseStartFormAction(a); };
      TabPage page = _owner.TabControl.TabPages.Add(frm);
      page.Click += Page_Click;
    }

    public void OpenConfigForm(Scope.ScopeItem item)
    {
      if (item == null) throw new ArgumentNullException(nameof(item));
      int index = FindIndexFromById(item.NodeEx.Id);
      if (index > -1)
      {
        _owner.TabControl.TabPages[index].Select();
        return;
      }
      ZtpConfigForm frm = new ZtpConfigForm(item, _owner.BeginUserAction, _owner.EndUserAction);
      TabPage page = _owner.TabControl.TabPages.Add(frm);
      frm.NeedEnableUpdate += (s, a) =>
      {
        OnNeedEnableUpdate(); 
      };
      page.Click += Page_Click;

      if (frm.OpenPort())
        frm.DoAction(ActionType.ConfigRead);//DoReadConfig();
      else
        _owner.TabControl.TabPages.Remove(page);
    }

    public event EventHandler ActiveFormChanged; 
    private void Page_Click(object sender, EventArgs e)
    {
      OnActiveFormChanged();
    }
    protected virtual void OnActiveFormChanged()
    {
      ActiveFormChanged?.Invoke(this, EventArgs.Empty);
    }

    int FindIndexFromById(int deviceId)
    {
      int retVal = -1;
      for(int i = 0; i < _owner.TabControl.TabPages.Count; i++)
      {
        ZtpConfigForm frm = _owner.TabControl.TabPages[i].Form as ZtpConfigForm;
        if(frm == null) continue;
        if (frm.ScopeItem.NodeEx.Id == deviceId)
        {
          retVal = i;
          break;
        }
      }
      return retVal;
    }

    public ZtpConfigForm CurrentZtpConfigForm
    {
      get
      {
        ZtpConfigForm frm = _owner.TabControl.SelectedForm as ZtpConfigForm;
        return frm;
      }
    }

    protected virtual void OnRaiseStartFormAction(StartForm.RaiseActionEventArgs e)
    {
      RaiseStartFormAction?.Invoke(this, e);
    }
  }
}