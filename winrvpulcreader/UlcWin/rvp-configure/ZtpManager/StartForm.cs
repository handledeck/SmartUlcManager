using System;
using System.Windows.Forms;
using ZtpManager.Scope;

namespace ZtpManager
{
  public partial class StartForm : Form, IChildForm
  {
    /// <summary>
    /// Тип действия
    /// </summary>
    public enum StartFormAction
    {
      MwConfig,
      MwFota,
      MwReboot,
      MwSwitchOnOff,
      MwChangePassword,
      MwPatch
    }

    public class RaiseActionEventArgs: EventArgs
    {
      public StartFormAction Action { get; }
      public RaiseActionEventArgs(StartFormAction action)
      {
        Action = action;
      }
    }

    public event EventHandler<RaiseActionEventArgs> RaiseAction;

    protected virtual void OnRaiseAction(StartFormAction action)
    {
      RaiseAction?.Invoke(this, new RaiseActionEventArgs(action));
    }

    public StartForm()
    {
      InitializeComponent();
    }

    public ChildFormKind FormKind => ChildFormKind.StartPage;

    public void ShowState(bool show)
    {
    }

    public void ShowDebug(bool show)
    {
    }

    public Action BeginUserAction { get; } = delegate () { };
    public Action EndUserAction { get; } = delegate () { };
    public ScopeItem ScopeItem { get; } = null;

    private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      //e.Cancel = true;
      //Hide();
    }

    private void lnkMultiFota_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      OnRaiseAction(StartFormAction.MwFota);
    }

    private void lnkMultiReboot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      OnRaiseAction(StartFormAction.MwReboot);
    }

    private void lnkMultiWriteConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      OnRaiseAction(StartFormAction.MwConfig);
    }

    private void lnkMultiWriteSwitchOnOff_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      OnRaiseAction(StartFormAction.MwSwitchOnOff);
    }

    private void lnkMultiWriteChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      OnRaiseAction(StartFormAction.MwChangePassword);
    }

    private void lnkMultiPatch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      OnRaiseAction(StartFormAction.MwPatch);
    }
  }
}
