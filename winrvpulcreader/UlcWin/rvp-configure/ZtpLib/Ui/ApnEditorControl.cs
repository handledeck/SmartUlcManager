using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ztp.Protocol;

namespace Ztp.Ui
{
  public partial class ApnEditorControl : UserControl
  {
    public string ApnAddress
    {
      get { return itcApnAddress.Value; }
      set { itcApnAddress.Value = value; }
    }

    public string ApnUser
    {
      get { return itcApnUser.Value; }
      set { itcApnUser.Value = value; }
    }

    public string ApnPassword
    {
      get { return itcApnPassword.Value; }
      set { itcApnPassword.Value = value; }
    }

    public Exception CheckFieldValidation()
    {
      List<InputTextControl> list = new List<InputTextControl>()
      {
        itcApnAddress,
        itcApnPassword,
        itcApnUser
      };
      foreach (InputTextControl inputText in list)
      {
        if (string.IsNullOrEmpty(inputText.Value))
          return new Exception($"Не указан параметр '{inputText.Caption}'");
        if (inputText.Value.Length > ZtpProtocol.MaxStringLength)
          return new Exception($"Значение параметра '{inputText.Caption}' не должно превышать {ZtpProtocol.MaxStringLength} символов");
        if (inputText.Value.IndexOfAny(new char[] { ' ' }) > -1)
          return new Exception($"Параметр '{inputText.Caption}' не может содержать символ пробела");
      }
      return null;
    }

    public ApnEditorControl()
    {
      InitializeComponent();
    }
  }
}
