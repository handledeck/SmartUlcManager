using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using Bss.Remoting;
using Bss.Services.SmartDrv;
using Bss.Services.SmartDrv.Common.Device;
using Bss.Sys;
using Bss.Sys.RegSrv;
using Ztp.Utils;
using ZtpManager.Scope;
using MODULE_INFO = Bss.Sys.RegSrv.MODULE_INFO;

namespace ZtpManager.Est
{
  public static class EstAccess
  {
    private const string _serviceType = "SmartDrvSrv";
    private const string _runtimeTypeName = "Bss.Services.SmartDrv.ZtpServerRunTime, SmartZtpServer";

    public static List<ZtpDeviceInfo> GetZtpDiviceInfos()
    {
      //todo set call with try!!!
      RemoteClient remoteClient = new RemoteClient();
      NetworkCredential credential = new NetworkCredential(AppConfig.Default.EstUser, StringUtils.FromBase64String(AppConfig.Default.EstPassword));
      remoteClient.Connect(
        AppConfig.Default.EstIpAddress, AppConfig.Default.EstPort,
        credential, ProtectionLevel.None, Bss.Sys.TypeAuthenticate.System);

      Bss.Sys.IBssToolsRemote remote = remoteClient.GetRemoteObject();
      ISerManCallBack serManCallBack = remote.GetSerMan();

      List<ZtpDeviceInfo> driverInfos = ProcessEstTools(serManCallBack);
      return driverInfos;
    }

    static List<ZtpDeviceInfo> ProcessEstTools(ISerManCallBack serManCallBack)
    {
      IRegService regService = serManCallBack.GetRegService();
      HOST_INFO[] hostList = regService.GetHostList();
      if (hostList == null || hostList.Length == 0)
        throw new Exception($"EST Tools registry is empty");
      SERVICE_INFO[] serviceInfos = regService.GetServiceList(hostList[0].ipAddress);
      SERVICE_INFO firstOrDefault = serviceInfos.FirstOrDefault((si) => si.serviceType == _serviceType);
      if (string.IsNullOrEmpty(firstOrDefault.serviceFullName))
        throw new Exception($"{_serviceType} not found");
      MODULE_INFO[] moduleInfos = regService.GetModuleList(firstOrDefault.serviceFullName);

      List<ZtpDeviceInfo> list = new List<ZtpDeviceInfo>();
      foreach (MODULE_INFO moduleInfo in moduleInfos)
      {
        list.AddRange(ProcessModule(serManCallBack, regService, moduleInfo));
      }
      return list;
    }

    static List<ZtpDeviceInfo> ProcessModule(ISerManCallBack serManCallBack, IRegService regService, MODULE_INFO mi)
    {
      List<ZtpDeviceInfo> list = new List<ZtpDeviceInfo>();
      IReaderService readerService = regService.GetReaderService(mi.moduleFullName);
      ITable table = readerService.GetServiceDataSource().GetTable("DriverInfo");
      int rowCount = table.GetRowCount();
      if (rowCount == 0)
        return list;
      IRow row = table.GetRow(0);
      string rtName = (string)row.GetValue("runtimeTypeName");
      if (rtName != _runtimeTypeName)
        return list;
      IEnterpriseInfo enterpriseInfo = (IEnterpriseInfo)serManCallBack.GetService(mi.moduleFullName, typeof(IEnterpriseInfo).Name);
      if (enterpriseInfo == null)
        return list;
      string[] info = enterpriseInfo.EnterpriseInfo();
      if (info.Length == 0)
        return list;
      byte[] array = Encoding.Default.GetBytes(info[0]);
      using (MemoryStream ms = new MemoryStream(array))
      {
        System.Runtime.Serialization.Json.DataContractJsonSerializer ser = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(PointItems[]));
        PointItems[] items = (PointItems[])ser.ReadObject(ms);

        if (items.Length > 0)
        {
          foreach (PointItems item in items)
          {
            if (!string.IsNullOrEmpty(item.CommState?.GUID))
              list.Add(new ZtpDeviceInfo() { Address = item.IP, Name = item.Name, CommStateGuid = item.CommState.GUID, ModuleName = mi.moduleShortName});
          }
        }
        return list;
      }
    }

    public static List<ScopeItem> SyncFromEst()
    {
      List<ScopeItem> devices = ScopeArea.Default.GetEstDevices();
      List<ZtpDeviceInfo> estDevices = GetZtpDiviceInfos();
      foreach (ScopeItem device in devices)
      {
        ZtpDeviceInfo ztpDeviceInfo = estDevices.FirstOrDefault(o => o.CommStateGuid == device.NodeEx.EstCommStateGuid);
        if(ztpDeviceInfo == null)
          continue;
        device.NodeEx.DisplayName = ztpDeviceInfo.Name;
        device.NodeEx.IpAddress = ztpDeviceInfo.Address;
      }
      return devices;
    }

    public class ZtpDeviceInfo
    {
      public bool IsExists { get; set; }
      public string ModuleName { get; set; }
      public string Address { get; set; }
      public string Name { get; set; }
      public string CommStateGuid { get; set; }
    }

  }
}
