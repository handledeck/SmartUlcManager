using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Configuration;
using Ztp.Port.ComPort;
using Ztp.Ui;
using Ztp.Enums;

namespace ZtpManager.Controls
{
  public partial class PartitionConfigEditorControl : UserControl
  {
    DevType _kind = DevType.Unknown;

    public PartitionConfigEditorControl()
    {
      InitializeComponent();
      _value = ZtpConfig.GetDefault();
      _value.Light = new ZtpLight();
      _value.ComPortSetting = new ComPortSettings();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      InitFlags();
      CollapseAll();
      Subscribe();
      ViewConfigByDevType(_kind);
    }

    void Subscribe()
    {
      foreach (Control control in flp.Controls)
      {
        ExpanderControl exp = control as ExpanderControl;
        if (exp == null) continue;
        exp.ExpandedChanged += Exp_ExpandedChanged;
      }
    }

    /// TODo изменение отображение панелей в зависимости от типа устройства
    public void ViewConfigByDevType(DevType dev)
    {
      _kind = dev;
      switch(_kind)//todo change !!!
      {
        case DevType.RVP18:
          _value.Version = "I16O2A2-LDC-3-FOTA";
          break;
        case DevType.ULC02:
          _value.Version = "I4O1A1-LDC-3-FOTA";
          _value.SoftVersion = "1.7.9";
          break;
        case DevType.ULC2_2:
          _value.Version = "I8O2A2-LEM-4-FOTA-prIM";
            break;
      }
      foreach(Control ctrl in flp.Controls)
      {
        ExpanderControl exp = ctrl as ExpanderControl;
        switch (exp.Tag)
        {
          case ZtpConfig.ConfigFlag.EstActive:
          case ZtpConfig.ConfigFlag.EstParams:
            exp.Visible = (dev == DevType.RVP18) ? true : false;
            exp.IsExpanded = false;
            break;
          case ZtpConfig.ConfigFlag.UseIec:
            exp.Visible = (dev == DevType.RVP18) ? false : true;
            exp.IsExpanded = false;
            break;
          case ZtpConfig.ConfigFlag.Logs:
            exp.Visible = (dev == DevType.RVP18) ? false : true;
            exp.IsExpanded = false;
            break;
        }
      }
    }

    Dictionary<ZtpConfig.ConfigFlag, string> _checkedExpanders = new Dictionary<ZtpConfig.ConfigFlag, string>();
    private void Exp_ExpandedChanged(object sender, EventArgs e)
    {
      ExpanderControl exp = sender as ExpanderControl;
      if(exp == null)
        return;
      ZtpConfig.ConfigFlag flag = (ZtpConfig.ConfigFlag) exp.Tag;
      if (exp.IsExpanded)
        _checkedExpanders[flag] = exp.Header;
      else
        _checkedExpanders.Remove(flag);
    }

    public List<Tuple<ZtpConfig.ConfigFlag, string>> CheckedFlags
    {
      get
      {
        List<Tuple<ZtpConfig.ConfigFlag, string>> retVal = new List<Tuple<ZtpConfig.ConfigFlag, string>>();
        Dictionary<ZtpConfig.ConfigFlag, string>.Enumerator enumerator = _checkedExpanders.GetEnumerator();
        while (enumerator.MoveNext())
        {
          Tuple<ZtpConfig.ConfigFlag, string> tuple = new Tuple<ZtpConfig.ConfigFlag, string>(enumerator.Current.Key, enumerator.Current.Value);
          retVal.Add(tuple);
        }
        return retVal;
      }
    }

    void InitFlags()
    {
      exDin.Tag = ZtpConfig.ConfigFlag.Din;
      exDout.Tag = ZtpConfig.ConfigFlag.Dout;
      exAin.Tag = ZtpConfig.ConfigFlag.Ain;
      exUseSchedule.Tag = ZtpConfig.ConfigFlag.UseScheduler;
      exEstActive.Tag = ZtpConfig.ConfigFlag.EstActive;
      exEstParams.Tag = ZtpConfig.ConfigFlag.EstParams;
      exLocation.Tag = ZtpConfig.ConfigFlag.Location;
      exDbz.Tag = ZtpConfig.ConfigFlag.DbzPercent;
      exDebounce.Tag = ZtpConfig.ConfigFlag.Debounce;
      exDebug.Tag = ZtpConfig.ConfigFlag.Debug;
      exScheduler.Tag = ZtpConfig.ConfigFlag.Scheduler;
      exRs485.Tag = ZtpConfig.ConfigFlag.Rs485;
      exDoor.Tag = ZtpConfig.ConfigFlag.Door;
      exPlanReboot.Tag = ZtpConfig.ConfigFlag.PlanReboot;
      exIec104Control.Tag = ZtpConfig.ConfigFlag.UseIec;
      exLogsControl.Tag = ZtpConfig.ConfigFlag.Logs;
    }

    ZtpConfig CollectZtpConfig()
    {
      _value.Flags = GetFlags();

      _value.Din = dinEditor.Value;
      _value.Dout = doutEditor.Value;
      _value.Ain = ainEditor.Value;
      _value.Door = doorEditor.Value;
      _value.EstActive = cbEstActive.Checked;
      if (_kind == DevType.RVP18)
      {
        _value.EstAddress = itEstAddress.Value;
        _value.EstPort = Convert.ToUInt16(itEstPort.Value);
        _value.EstTsend = Convert.ToUInt32(itEstTsend.Value);
      }
      else
      {
        _value.EstAddress = iec104EditorControl.TimeValue;
        _value.EstPort = iec104EditorControl.qValue;
        _value.logLevel = lscLogs.LogLevel;
      }
      _value.TimeZone = inputTimeZone.Value;
      _value.Latitude = Convert.ToSingle(idLatitude.Value);
      _value.Longitude = Convert.ToSingle(idLongitude.Value);
      _value.Debounce = Convert.ToUInt32(itDebounce.Value);
      _value.Debug = cbDebug.Checked;
      _value.Light.UseScheduler = useSchedulerEditor.UseScheduler;
      _value.DbzPercent = Convert.ToByte(idDbz.Value);
      _value.ComPortSetting = comPortSettingsEditor.Value;
      _value.rebootTime = planResetControl1.Value;
      
      return _value;
    }

    void CollapseAll()
    {
      foreach (Control control in flp.Controls)
      {
        ExpanderControl exp = control as ExpanderControl;
        if (exp == null) continue;
        exp.IsExpanded = false;
      }
    }

    ZtpConfig _value;
    public ZtpConfig Value
    {
      get
      {
        _value = CollectZtpConfig();
        return _value;
      }
      set { _value = value; }
    }

    ZtpConfig.ConfigFlag GetFlags()
    {
      ZtpConfig.ConfigFlag retVal = ZtpConfig.ConfigFlag.None;
      foreach (ZtpConfig.ConfigFlag flag in _checkedExpanders.Keys)
      {
        retVal |= flag;
      }
      return retVal;
    }

    private void btnSelectLightPlan_Click(object sender, EventArgs e)
    {
      using (SelectLightPlanForm frm = new SelectLightPlanForm())
      {
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          _value.Light.Scheduler = ZtpScheduler.Deserialize(Convert.FromBase64String(frm.SelectedLightPlan.Body));
          string html = _value.Light.Scheduler.ToHtml();
          ShowHtml(html);
        }
      }
    }

    void ShowHtml(string html)
    {
      wb.DocumentText = html;
    }
  }


}
