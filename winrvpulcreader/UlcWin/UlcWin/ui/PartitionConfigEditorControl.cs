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

namespace UlcWin.ui
{
  public partial class PartitionConfigEditorControl : UserControl
  {
    DevType _kind = DevType.Unknown;
    public ZtpConfig __ztpConfig = null;
    public PartitionConfigEditorControl()
    {
      InitializeComponent();
      __ztpConfig = ZtpConfig.GetDefault();
      __ztpConfig.Light = new ZtpLight();
      inputTimeZone.Value = 3;
      __ztpConfig.ComPortSetting = new ComPortSettings();
     // __ztpConfig.logLevel = 5;
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
          __ztpConfig.Version = "I16O2A2-LDC-3-FOTA";
          break;
        case DevType.ULC02:
          __ztpConfig.Version = "I4O1A1-LDC-3-FOTA";
          __ztpConfig.SoftVersion = "1.7.9";
          break;
        case DevType.ULC2_2:
          __ztpConfig.Version = "I8O2A2-LEM-4-FOTA-prIM";
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
          case ZtpConfig.ConfigFlag.PlanReboot:
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
      __ztpConfig.Flags = GetFlags();

      __ztpConfig.Din = dinEditor.Value;
      __ztpConfig.Dout = doutEditor.Value;
      __ztpConfig.Ain = ainEditor.Value;
      __ztpConfig.Door = doorEditor.Value;
      __ztpConfig.EstActive = cbEstActive.Checked;
      if (_kind == DevType.RVP18)
      {
        __ztpConfig.EstAddress = itEstAddress.Value;
        __ztpConfig.EstPort = Convert.ToUInt16(itEstPort.Value);
        __ztpConfig.EstTsend = Convert.ToUInt32(itEstTsend.Value);
      }
      else
      {
        __ztpConfig.EstAddress = iec104EditorControl.TimeValue;
        __ztpConfig.EstPort = iec104EditorControl.qValue;
        __ztpConfig.logLevel = lscLogs.LogLevel;
      }
      __ztpConfig.TimeZone = inputTimeZone.Value;
      __ztpConfig.Latitude = Convert.ToSingle(idLatitude.Value);
      __ztpConfig.Longitude = Convert.ToSingle(idLongitude.Value);
      __ztpConfig.Debounce = Convert.ToUInt32(itDebounce.Value);
      __ztpConfig.Debug = cbDebug.Checked;
      __ztpConfig.Light.UseScheduler = useSchedulerEditor.UseScheduler;
      __ztpConfig.DbzPercent = Convert.ToByte(idDbz.Value);
      __ztpConfig.ComPortSetting = comPortSettingsEditor.Value;
      __ztpConfig.rebootTime = planResetControl1.Value;
      __ztpConfig.logLevel = lscLogs.LogLevel;
      return __ztpConfig;
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

   
    public ZtpConfig Value
    {
      get
      {
        
        __ztpConfig = CollectZtpConfig();
        return __ztpConfig;
      }
      set { __ztpConfig = value; }
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
     
      using (ScheduleForm shForm=new ScheduleForm(ref this.__ztpConfig))
      {

        if (shForm.ShowDialog() == DialogResult.OK) {
          this.__ztpConfig = shForm.__ztpConfig; 
          this.ShowHtml(shForm.__html);
        }
      }
      //using (SelectLightPlanForm frm = new SelectLightPlanForm())
      //{
      //  if (frm.ShowDialog(this) == DialogResult.OK)
      //  {
      //    __ztpConfig.Light.Scheduler = ZtpScheduler.Deserialize(Convert.FromBase64String(frm.SelectedLightPlan.Body));
      //    string html = __ztpConfig.Light.Scheduler.ToHtml();
      //    ShowHtml(html);
      //  }
      //}
    }

    void ShowHtml(string html)
    {
      wb.DocumentText = html;
    }
  }


}
