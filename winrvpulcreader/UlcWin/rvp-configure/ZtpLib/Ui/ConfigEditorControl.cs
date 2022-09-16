using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using Ztp.Configuration;
using Ztp.Protocol;
using Ztp.Enums;

namespace Ztp.Ui
{
  public partial class ConfigEditorControl : UserControl
  {
    public Device _devType;//XXX

    public delegate void TestPingOwnHandler();
    public event TestPingOwnHandler TestPing; 

    public ConfigEditorControl()
    {
      InitializeComponent();
      _devType = Device.Unknown;
      Application.Idle += Application_Idle;
      pingEditorControl.TestPing += Ping;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      itEstAddress.Enabled = itEstPort.Enabled = itEstTsend.Enabled = cbEstActive.Checked;
    }

    private ZtpConfig _ztpConfig;
    public ZtpConfig Value
    {
      get { return CollectZtpConfig(); }
      set
      {
        _ztpConfig = value;
        Assign(value);
      }
    }

    void Assign(ZtpConfig zc)
    {
      if (zc == null)
      {
        _devType = Device.Unknown;
        zc = ZtpConfig.GetDefault();
      }
        
      ZtpVersion version = new ZtpVersion(zc.Version);


      apnEditorControl.ApnAddress = zc.Apn;
      apnEditorControl.ApnUser = zc.ApnUser;
      apnEditorControl.ApnPassword = zc.ApnPassword;
      dinEditor.Value = zc.Din;
      dinEditor.VisibleItemCount = version.Din;
      doutEditor.Value = zc.Dout;
      doutEditor.VisibleItemCount = version.Dout;
      ainEditor.Value = zc.Ain;
      ainEditor.VisibleItemCount = version.Ain;
      doorEditor.Value = zc.Door;
      if(_devType == Device.ULC2 || _devType == Device.ULC2_2)
      {
        iec104EditorControl.TimeValue = zc.EstAddress;
        iec104EditorControl.qValue = zc.EstPort;
        gsmTechn.Techn = zc.EstTsend;
        logsStateControl.LogLevel = zc.logLevel;
      }
      else if(_devType == Device.RVP)
      {
        cbEstActive.Checked = zc.EstActive;
        itEstAddress.Value = zc.EstAddress;
        itEstPort.Value = zc.EstPort;
        itEstTsend.Value = zc.EstTsend;
      }
      inputTimeZone.Value = zc.TimeZone;
      idLatitude.Value = (decimal)zc.Latitude;
      idLongitude.Value = (decimal)zc.Longitude;
      itDebounce.Value = zc.Debounce;
      cbDebug.Checked = zc.Debug;
      idDbz.Value = zc.DbzPercent;

      idNumber.Value = zc.Number;

      if (string.IsNullOrEmpty(zc.rebootTime))
      {
        planResetControl.Active = false;
        planResetControl.Value = "00:00";
      }
      else
      {
        planResetControl.Active = true;
        planResetControl.Value = zc.rebootTime;
      }
      pingEditorControl.Period = zc.PingPeriod;
      pingEditorControl.Ip = zc.IpPing;
    }

    public bool ShowApnProperty
    {
      get { return apnEditorControl.Visible; }
      set
      {
        apnEditorControl.Visible = value;
      }
    }

    ZtpConfig CollectZtpConfig()
    {
      if (_ztpConfig == null)
        _ztpConfig = ZtpConfig.GetDefault();
      _ztpConfig.IsReadedFromDevice = _ztpConfig.IsReadedFromDevice;
      _ztpConfig.Sunrise = _ztpConfig.Sunrise;
      _ztpConfig.Sunset = _ztpConfig.Sunset;
      _ztpConfig.Gsm = _ztpConfig.Gsm;
      _ztpConfig.Gprs = _ztpConfig.Gprs;
      _ztpConfig.Sim = _ztpConfig.Sim;
      _ztpConfig.Signal = _ztpConfig.Signal;
      _ztpConfig.Cdout = _ztpConfig.Cdout;
      _ztpConfig.Cain = _ztpConfig.Cain;
      _ztpConfig.Cdin = _ztpConfig.Cdin;
      _ztpConfig.Apn = apnEditorControl.ApnAddress;
      _ztpConfig.ApnUser = apnEditorControl.ApnUser;
      _ztpConfig.ApnPassword = apnEditorControl.ApnPassword;
      _ztpConfig.Din = dinEditor.Value;
      _ztpConfig.Dout = doutEditor.Value;
      _ztpConfig.Ain = ainEditor.Value;
      _ztpConfig.Door = doorEditor.Value;
      if (_devType == Device.ULC2 || _devType == Device.ULC2_2)
      {
        _ztpConfig.EstActive = true;
        _ztpConfig.EstAddress = iec104EditorControl.TimeValue;
        _ztpConfig.EstPort = iec104EditorControl.qValue;
        _ztpConfig.EstTsend = gsmTechn.Techn;
      }
      else
      {
        _ztpConfig.EstActive = cbEstActive.Checked;
        _ztpConfig.EstAddress = itEstAddress.Value;
        _ztpConfig.EstPort = Convert.ToUInt16(itEstPort.Value);
        _ztpConfig.EstTsend = Convert.ToUInt32(itEstTsend.Value);
      }
      

      _ztpConfig.TimeZone = inputTimeZone.Value;
      _ztpConfig.Latitude = Convert.ToSingle(idLatitude.Value);
      _ztpConfig.Longitude = Convert.ToSingle(idLongitude.Value);
      _ztpConfig.Debounce = Convert.ToUInt32(itDebounce.Value);
      _ztpConfig.Debug = cbDebug.Checked;
      _ztpConfig.DbzPercent = Convert.ToByte(idDbz.Value);
      _ztpConfig.Number = Convert.ToInt32(idNumber.Value);
      if (planResetControl.Visible)
        _ztpConfig.rebootTime = planResetControl.Value;
      if(pingEditorControl.Visible)
      {
        _ztpConfig.IpPing = pingEditorControl.Ip;
        _ztpConfig.PingPeriod = pingEditorControl.Period;
      }
      if(logsStateControl.Visible)
      {
        _ztpConfig.logLevel = logsStateControl.LogLevel;
      }
      return _ztpConfig;
    }

    protected virtual void OnPasswordChanged(PasswordChangedEventArgs e)
    {
      PasswordChanged?.Invoke(this, e);
    }

    private void itApnPassword_Leave(object sender, EventArgs e)
    {
      if (_ztpConfig == null)
        return;
      if (_ztpConfig.ApnPassword != apnEditorControl.ApnPassword)
        OnPasswordChanged(new PasswordChangedEventArgs() { NewPassword = apnEditorControl.ApnPassword });
    }

    public class PasswordChangedEventArgs : EventArgs
    {
      public string NewPassword { get; set; }
    }

    public event EventHandler<PasswordChangedEventArgs> PasswordChanged;
    public Exception ValidateZtpConfig()
    {
      List<InputTextControl> list = new List<InputTextControl>()
      {
        //itApnAddress,
        //itApnPassword,
        //itApnUser
      };
      if (cbEstActive.Checked)
        list.Add(itEstAddress);
      Exception excep = apnEditorControl.CheckFieldValidation();
      if (excep != null)
        return excep;
      foreach (InputTextControl inputText in list)
      {
        if (string.IsNullOrEmpty(inputText.Value))
          return new Exception($"Не указан параметр '{inputText.Caption}'");
        if (inputText.Value.Length > ZtpProtocol.MaxStringLength)
          return new Exception($"Значение параметра '{inputText.Caption}' не должно превышать {ZtpProtocol.MaxStringLength} символов");
        if (inputText.Value.IndexOfAny(new char[] { ' ' }) > -1)
          return new Exception($"Параметр '{inputText.Caption}' не может содержать символ пробела");
      }
      if (cbEstActive.Checked)
        try
        {
          IPAddress.Parse(itEstAddress.Value);
        }
        catch (Exception ex)
        {
          return ex;
        }
      return null;
    }

    public void RechangeField(Device type)
    {
      switch (type)
      {
        case Device.Unknown:
        case Device.RVP:
          gbEst.Invoke((Action)(() => { gbEst.Show(); }));
          gbIec104.Invoke((Action)(() => { gbIec104.Hide(); }));
          break;
        case Device.ULC2:
        case Device.ULC2_2:
          gbEst.Invoke((Action)(() => { gbEst.Hide(); }));
          gbIec104.Invoke((Action)(() => { gbIec104.Show(); }));
          break;
      }

    }

    public void PlanRebootShow(bool value)
    {
      planResetControl.Visible = value;
    }

    public void GsmTechShow(bool value)
    {
      gsmTechn.Visible = value;
    }

    public void PingIpShow(bool value)
    {
      pingEditorControl.Visible = value;
    }

    public void LogsControlShow(bool value)
    {
      logsStateControl.Visible = value;
    }

    public string GetIpPing { get { return pingEditorControl.Ip; } }

    void Ping()
    {
      TestPing?.Invoke();
    }

  }
}