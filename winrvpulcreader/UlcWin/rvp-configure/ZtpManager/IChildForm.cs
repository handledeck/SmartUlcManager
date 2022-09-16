using System;
using ZtpManager.Scope;

namespace ZtpManager
{
  public enum ChildFormKind
  {
    StartPage,
    ZtpConfigPage
  }

  public interface IChildForm
  {
    ChildFormKind FormKind { get; }
    void ShowState(bool show);
    void ShowDebug(bool show);
    Action BeginUserAction { get; }
    Action EndUserAction { get; }
    ScopeItem ScopeItem { get; }
  }

}
