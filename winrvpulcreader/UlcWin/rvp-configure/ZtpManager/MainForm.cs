using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bss.Windows.Forms.Mstv;
using QueryBuilder.SqlOm;
using Ztp;
using Ztp.Configuration;
using Ztp.IO.Logger;
using Ztp.Model;
using Ztp.Port;
using Ztp.Port.TcpPort;
using Ztp.Protocol;
using Ztp.Ui;
using Ztp.Utils;
using ZtpManager.Clipboard;
using ZtpManager.DataAccessLayer;
using ZtpManager.DeviceAccessLayer;
using ZtpManager.Est;
using ZtpManager.Nodes;
using ZtpManager.Scope;
using TabControl = MdiTabControl.TabControl;
using TabPage = MdiTabControl.TabPage;

namespace ZtpManager
{
  public partial class MainForm : Form, IChildFormControlOwner
  {
    Dictionary<object, ActionType> _buttons;
    private ILog _tempLog = NullLog.Null;
    //private static string _sessionPassword = null;
    private ChildFormControl _childFormControl;
    private EstDevicesForm _frmEst;
    public MainForm()
    {
      InitializeComponent();
      _childFormControl = new ChildFormControl(this);
      _childFormControl.NeedEnableUpdate += (s, a) => { SetControlsEnabled(); };
      _childFormControl.RaiseStartFormAction += _childFormControl_RaiseStartFormAction;
    }

    /// <summary>
    /// Изменение вывода добавления устройств, в зависимости от галочки использования EST-tools
    /// </summary>
    void InitContextMenu()
    {
      cmiAddDevice.Visible = !(cmiDropDownAddDevice.Visible = AppConfig.Default.EstEnabled);
    }

    /// <summary>
    /// инициализция работы кнопок 
    /// </summary>
    void InitRibbon()
    {
      rbViewState.Checked = AppConfig.Default.ShowState; //изъятие значения отображения статуса из настроек
      rbViewDebug.Checked = AppConfig.Default.ShowDebug; // изъятие значения вывода панели отладки из настроек


      //0- на удаление, 1-ый добавляется
      RibbonButton[] DevVar = (AppConfig.Default.EstEnabled) ? new RibbonButton[]{ rbAddDevice, rbDropDownAddDevice } : new RibbonButton[] { rbDropDownAddDevice, rbAddDevice };
      //Заменяем панельки в случае выставления галочки использования Est
      int index = rpEditDevice.Items.FindIndex((b) => b == DevVar[0]);
      if (index > -1)
        rpEditDevice.Items.RemoveAt(index);
      index = rpEditDevice.Items.FindIndex((b) => b == DevVar[1]);
      if (index == -1)
        rpEditDevice.Items.Insert(0, DevVar[1]);
    }

    /// <summary>
    /// Закрытие окна с сохранением размеров и позиции
    /// </summary>
    /// <param name="e"></param>
    protected override void OnClosing(CancelEventArgs e)
    {
      base.OnClosing(e);
      AppConfig.Default.MainFormSize = Size;
      AppConfig.Default.MainFormLocation = Location;

      AppConfig.Default.Save();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      //Настройка окна
      Size = AppConfig.Default.MainFormSize;
      Location = AppConfig.Default.MainFormLocation;
      scMain.SplitterDistance = AppConfig.Default.NodeTreeSplitterDistance;
      scMain.SplitterMoved += ScMain_SplitterMoved;

      Connect(); //подключение к БД
      tv.Initialize(); //Визуальное перестроение дерева устройств
      if (Dal.Default.IsConnected)
        ScopeArea.Default.Fill();

      InitRibbon(); //инициализация кнопок
      InitContextMenu();
      _childFormControl.ShowStartForm();
      _childFormControl.ActiveFormChanged += _childFormControl_ActiveFormChanged;
      SetControlsEnabled();

      //Список кнопок для передачи команд 
      _buttons = new Dictionary<object, ActionType>()
      {
        { rbSeasonAdd, ActionType.SeasonAdd },
        { rbSeasonEdit, ActionType.SeasonEdit },
        { rbSeasonDelete, ActionType.SeasonDelete },
        { rbScheduleAdd, ActionType.ScheaduleAdd },
        { rbScheduleEdit, ActionType.ScheaduleEdit  },
        { rbScheduleDelete, ActionType.ScheaduleDelete },
        { rbCopyPlanFromCat, ActionType.CopyPlanFromCat },
        { rbReboot, ActionType.RebootDevice },
        { rbChangePassword, ActionType.ChangePassword},
        { rbShowScheduler, ActionType.ShowScheduler },
        { rbDeviceRead, ActionType.ConfigRead },
        { rbDeviceWrite, ActionType.ConfigWrite }
      };
    }

    private void _childFormControl_RaiseStartFormAction(object sender, StartForm.RaiseActionEventArgs e)
    {
      switch (e.Action)
      {
        case StartForm.StartFormAction.MwConfig:
          rbMultiWriteLightPlan_Click(null, null);
          break;
        case StartForm.StartFormAction.MwFota:
          rbMultiWriteFota_Click(null, null);
          break;
        case StartForm.StartFormAction.MwReboot:
          rbMultiReboot_Click(null, null);
          break;
        case StartForm.StartFormAction.MwChangePassword:
          rbMultiChangePassword_Click(null, null);
          break;
        case StartForm.StartFormAction.MwSwitchOnOff:
          rbMultiSwitchOnOff_Click(null, null);
          break;
        case StartForm.StartFormAction.MwPatch:
          rbMultiWritePatch_Click(null, null);
          break;
      }
    }


    #region SetControlsEnabled


#pragma warning disable 414
    private bool _doUserAction = false;
#pragma warning restore 414
    void SetControlsEnabled()
    {
      _childFormControl.SetControlsEnabled();

      BaseNode currentNode = GetCurrentNode();

      rbAddFolder.Enabled = cmiAddFolder.Enabled =
        Dal.Default.IsConnected && currentNode != null && currentNode.Level + 2 <= TuneSetting.Default.MaxNodeLevel;
      rbEditFolder.Enabled = rbDeleteFolder.Enabled = cmiEditFolder.Enabled = cmiDeleteFolder.Enabled =
        Dal.Default.IsConnected && currentNode != null && currentNode.Kind == NodeKind.Folder;

      FolderNode currentFolderNode = GetCurrentFolderNode();
      rbAddDevice.Enabled = rbAddDeviceEstTools.Enabled = rbAddDeviceManual.Enabled = rbDropDownAddDevice.Enabled =
        cmiAddDevice.Enabled = cmiAddDeviceEstTools.Enabled = cmiAddDeviceManual.Enabled = cmiDropDownAddDevice.Enabled =
        Dal.Default.IsConnected && currentFolderNode != null && currentFolderNode.Level + 1 == TuneSetting.Default.MaxNodeLevel;

      rbDeleteDevice.Enabled = rbEditDevice.Enabled = cmiDeleteDevice.Enabled = cmiEditDevice.Enabled =
        rbAudit.Enabled = Dal.Default.IsConnected && currentNode != null && currentNode.Kind == NodeKind.Device;

      rbSyncEst.Enabled = Dal.Default.IsConnected && AppConfig.Default.EstEnabled;

      rbCopyNode.Enabled = cmiCopyNode.Enabled = Dal.Default.IsConnected && currentNode != null && currentNode.Kind != NodeKind.None;


      ClipboardData clipData = GetFromClipboard();

      if (clipData != null)
      {
        if (clipData.Node.Kind == NodeKind.Device)
          rbPasteNode.Enabled = cmiPasteNode.Enabled = rbAddDevice.Enabled;
        else if (clipData.Node.Kind == NodeKind.Folder)
          rbPasteNode.Enabled = cmiPasteNode.Enabled = rbAddFolder.Enabled;
        else
          rbPasteNode.Enabled = cmiPasteNode.Enabled = false;
      }
      else
        rbPasteNode.Enabled = cmiPasteNode.Enabled = false;

      rbObjectList.Enabled = rbLastOp.Enabled = rbCatalogs.Enabled = Dal.Default.IsConnected;



      rbDeviceOpen.Enabled = cmiDeviceOpen.Enabled = Dal.Default.IsConnected && currentNode != null && currentNode.Kind == NodeKind.Device;

      ZtpConfigForm configForm = _childFormControl.CurrentZtpConfigForm;

      rbSeasonAdd.Enabled = configForm != null && configForm.SeasonAddEnabled;
      rbSeasonDelete.Enabled = configForm != null && configForm.SeasonDeleteEnabled;
      rbSeasonEdit.Enabled = configForm != null && configForm.SeasonEditEnabled;

      rbScheduleAdd.Enabled = configForm != null && configForm.ScheduleAddEnabled;
      rbScheduleDelete.Enabled = configForm != null && configForm.ScheduleDeleteEnabled;
      rbScheduleEdit.Enabled = configForm != null && configForm.ScheduleEditEnabled;
      rbDeviceRead.Enabled = configForm != null && configForm.ReadConfigEnabled;
      rbDeviceWrite.Enabled = configForm != null && configForm.WriteConfigEnabled;
      rbReboot.Enabled = configForm != null && configForm.RebootEnabled;
      rbChangePassword.Enabled = configForm != null && configForm.ChangePasswordEnabled;
      rbSwitchOnOff.Enabled = configForm != null && configForm.SwitchOnOffEnabled;
      rbShowScheduler.Enabled = configForm != null && configForm.ScheduleShowEnabled;
      rbCopyPlanFromCat.Enabled = Dal.Default.IsConnected && configForm != null;
      rbCopyPlanFromCat.Enabled = Dal.Default.IsConnected && configForm != null;

      if (configForm != null)
      {
        if (configForm.IsSwitchOn)
        {
          rbSwitchOnOff.Text = "Выключить освещение";
          rbSwitchOnOff.SmallImage = Properties.Resources.lightbulb_off;
          rbSwitchOnOff.Tag = false;
        }
        else
        {
          rbSwitchOnOff.Text = "Включить освещение";
          rbSwitchOnOff.SmallImage = Properties.Resources.lightbulb;
          rbSwitchOnOff.Tag = true;
        }
      }

      rbMultiWriteFota.Enabled = rbMultiWriteConfig.Enabled = rbMultiChangePassword.Enabled = rbMultiReboot.Enabled = rbMultiSwitchOnOff.Enabled = Dal.Default.IsConnected;
    }

    #endregion SetControlsEnabled

    //функция работы с буффером обмена - небось для копирования узлов
    ClipboardData GetFromClipboard()
    {
      if (!System.Windows.Forms.Clipboard.ContainsData(ClipboardData.ClipboardDataFotmat))
        return null;
      return (ClipboardData)System.Windows.Forms.Clipboard.GetData(ClipboardData.ClipboardDataFotmat);
    }

    // Получение узла директории 
    FolderNode GetCurrentFolderNode()
    {
      BaseNode currentNode = GetCurrentNode();
      if (currentNode == null)
        return null;
      FolderNode folderNode = currentNode as FolderNode;
      if (folderNode != null)
        return folderNode;
      DeviceNode deviceNode = currentNode as DeviceNode;
      if (deviceNode != null)
        return deviceNode.Parent as FolderNode;
      return null;
    }

    #region Events
    //изменение вертикальной разделительной черты
    private void ScMain_SplitterMoved(object sender, SplitterEventArgs e)
    {
      AppConfig.Default.NodeTreeSplitterDistance = scMain.SplitterDistance;
      SaveAppConfig();
    }
    //при переключении вкладок
    private void _childFormControl_ActiveFormChanged(object sender, EventArgs e)
    {
      SetControlsEnabled();
    }
    #endregion //Events


    void SetOperationHistorian()
    {
      Ztp.Protocol.ZtpFota.Historian = OperationHistorian.Default;
      ZtpProtocolDriver.Historian = OperationHistorian.Default;
    }

    /// <summary>
    /// Подключение к базе данных MySQL 5.5
    /// </summary>
    void Connect()
    {
      try
      {
        Dal.Default.Connect();
        SetOperationHistorian();
      }
      catch (Exception ex)
      {
        Box.Error(this, ex);
      }
    }

    // получение текущего узла (значения)
    BaseNode GetCurrentNode()
    {
      return tv.SelectedNode as BaseNode;
    }

    #region Работа с папками в дереве устройств
    private void rbEditFolder_Click(object sender, EventArgs e)
    {
      BaseNode current = GetCurrentNode();
      if (current == null || current.Kind != NodeKind.Folder) return;

      using (EditFolderForm frm = new EditFolderForm(current.Node))
      {
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          try
          {
            Node node = frm.GetChangedNode();
            if (Dal.Default.EditNode(node))//запись данных в базу
            {
              current.Node = node;
              ScopeArea.Default.EditDevicesForFolder(node.Path);//изменение пути в дочерних узлах
            }
          }
          catch (Exception ex)
          {
            Box.Error(this, ex);
          }
        }
      }
    }

    private void rbDeleteFolder_Click(object sender, EventArgs e)
    {
      BaseNode current = GetCurrentNode();
      if (current == null || current.Kind != NodeKind.Folder) return;

      if (!Box.Confirm(this, $"Удалить папку '{current.Node.DisplayName}' и все ее содержимое?")) return;
      tv.BeginUpdate();
      try
      {
        IEnumerable<int> deviceIds = Dal.Default.ReadChildDeviceIds(current.Node.Id);
        Dal.Default.DeleteNode(current.Node.Id);
        ScopeArea.Default.RemoveRange(deviceIds);
        current.Remove();
      }
      catch (Exception ex)
      {
        Box.Error(this, ex);
      }
      finally
      {
        tv.EndUpdate();
      }
    }

    private void rbAddFolder_Click(object sender, EventArgs e)
    {
      BaseNode parent = GetCurrentNode();
      if (parent == null) return;
      try
      {
        if (!parent.IsExpanded)
          parent.Expand();
        using (EditFolderForm frm = new EditFolderForm())
        {
          if (frm.ShowDialog(this) == DialogResult.OK)
          {
            NodeEx node = NodeEx.FromNode(frm.GetChangedNode());
            node.IdOwn = parent.Node.Id;
            Dal.Default.AddNodes(node);
            BaseNode baseNode = AddBaseNodeAndRefreshChild(parent, new FolderNode(node));
            tv.SelectedNode = baseNode;
          }
        }
      }
      catch (Exception ex)
      {
        Box.Error(this, ex);
      }
    }
    #endregion //Работа с папками в дереве устройств

    BaseNode AddBaseNodeAndRefreshChild(BaseNode parent, params BaseNode[] nodes)
    {
      if (nodes.Length == 0)
        throw new ArgumentException(nameof(nodes));
      List<BaseNode> list = new List<BaseNode>();
      tv.BeginUpdate();
      try
      {
        foreach (BaseNode node in nodes)
        {
          parent.Nodes.Add(node);
        }
        list.AddRange(parent.Nodes.OfType<BaseNode>());
        list.Sort(new BaseNode.BaseNodeComparer());
        parent.Nodes.Clear();
        parent.Nodes.AddRange(list.OfType<TreeNode>().ToArray());
        return nodes[0];
      }
      finally
      {
        tv.EndUpdate();
      }
    }

    private void rbSetting_Click(object sender, EventArgs e)
    {
      using (AppConfigForm frm = new AppConfigForm())
      {
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          InitRibbon();
          InitContextMenu();
          SetControlsEnabled();
          SaveAppConfig();
        }
      }
    }

    
    //Импорт списка устройств из EstTools
    private void rbAddDeviceEstTools_Click(object sender, EventArgs e)
    {
      FolderNode current = GetCurrentFolderNode();
      if (current == null) return;

      if (_frmEst == null)
      {
        _frmEst = new EstDevicesForm();
      }
      _frmEst.DialogResult = DialogResult.None;
      _frmEst.ShowDialog(this);
      try
      {
        if (_frmEst.Result == DialogResult.OK)
        {
          List<NodeEx> list = new List<NodeEx>();
          string psw = StringUtils.ToBase64String(_frmEst.Password);
          foreach (EstAccess.ZtpDeviceInfo device in _frmEst.SelectedDevices)
          {
            NodeEx node = new NodeEx()
            {
              IpAddress = device.Address,
              EstCommStateGuid = device.CommStateGuid,
              DisplayName = device.Name,
              Kind = NodeKind.Device,
              DevType = DeviceKind.RVP18,
              Password = psw,
              Description = "Импортировано из EST Tools",
              IdOwn = current.Node.Id
            };
            list.Add(node);
          }
          if (list.Count > 0)
          {
            Dal.Default.AddNodes(list.ToArray());
            ScopeItem[] items = ScopeArea.Default.AddRange(list);
            BaseNode baseNode = AddBaseNodeAndRefreshChild(current, DeviceNode.FromScopeItemArray(items));
            tv.SelectedNode = baseNode;
          }
        }
      }
      catch (Exception exception)
      {
        Box.Error(this, exception);
      }
    }

    private void rbAddDevice_Click(object sender, EventArgs e)
    {
      FolderNode current = GetCurrentFolderNode();
      if (current == null) return;
      using (EditDeviceForm frm = new EditDeviceForm())
      {
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          try
          {
            NodeEx node = new NodeEx()
            {
              Description = frm.ValueDescription,
              DisplayName = frm.ValueName,
              IdOwn = current.Node.Id,
              IpAddress = frm.ValueIpAddress,
              Kind = NodeKind.Device,
              DevType = (DeviceKind)frm.ValueDevType,
              Password = StringUtils.ToBase64String(frm.ValuePasswordDecrypt)
            };
            Dal.Default.AddNodes(node);
            ScopeItem item = ScopeArea.Default.Add(node);

            BaseNode baseNode = AddBaseNodeAndRefreshChild(current, item.CreateDeviceNode());
            tv.SelectedNode = baseNode;
          }
          catch (Exception exception)
          {
            Box.Error(this, exception);
          }
        }
      }
    }

    private void rbDeleteDevice_Click(object sender, EventArgs e)
    {
      BaseNode current = GetCurrentNode();
      if (current == null || current.Kind != NodeKind.Device) return;
      if (!Box.Confirm(this, $"Удалить устройство '{current.Node.DisplayName}'?")) return;
      tv.BeginUpdate();
      try
      {
        Dal.Default.DeleteNode(current.Node.Id);
        ScopeArea.Default.Remove(current.Node.Id);
        current.Remove();
      }
      catch (Exception ex)
      {
        Box.Error(this, ex);
      }
      finally
      {
        tv.EndUpdate();
      }
    }

    private void rbEditDevice_Click(object sender, EventArgs e)
    {
      BaseNode current = GetCurrentNode();
      if (current == null || current.Kind != NodeKind.Device) return;
      using (EditDeviceForm frm = new EditDeviceForm())
      {
        frm.ValueName = current.Node.DisplayName;
        frm.ValueDescription = current.Node.Description;
        frm.ValueIpAddress = current.Node.IpAddress;
        frm.ValueDevType = (Ztp.Enums.DevType)current.Node.DevType;
        frm.ValuePasswordDecrypt = current.Node.Password == null ? "" : StringUtils.FromBase64String(current.Node.Password);

        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          try
          {
            ScopeItem item = ScopeArea.Default[current.Node.Id];

            NodeEx node = (NodeEx)item.NodeEx.Clone();
            node.DisplayName = frm.ValueName;
            node.Description = frm.ValueDescription;
            node.IpAddress = frm.ValueIpAddress;
            node.DevType = (DeviceKind)frm.ValueDevType;
            node.Password = StringUtils.ToBase64String(frm.ValuePasswordDecrypt);
            current.Node = node;
            if (Dal.Default.EditNode(current.Node))
            {
              item.NodeEx.DisplayName = node.DisplayName;
              item.NodeEx.Description = node.Description;
              item.NodeEx.IpAddress = node.IpAddress;
              item.NodeEx.Password = node.Password;
              item.NodeEx.DevType = node.DevType;
              ScopeArea.Default.EditDevice((NodeEx)current.Node);
            }
          }
          catch (Exception ex)
          {
            Box.Error(this, ex);
          }
        }
      }
    }

    private void rbCopyNode_Click(object sender, EventArgs e)
    {
      BaseNode currentNode = GetCurrentNode();
      if (currentNode.Kind == NodeKind.None)
        return;
      ClipboardData clipData = new ClipboardData();
      clipData.Node = currentNode.Node;
      System.Windows.Forms.Clipboard.SetData(ClipboardData.ClipboardDataFotmat, clipData);
      SetControlsEnabled();
    }

    private void rbPasteNode_Click(object sender, EventArgs e)
    {
      if (!System.Windows.Forms.Clipboard.ContainsData(ClipboardData.ClipboardDataFotmat))
        return;
      ClipboardData clipData =
        (ClipboardData)System.Windows.Forms.Clipboard.GetData(ClipboardData.ClipboardDataFotmat);
      if (clipData == null)
        return;
      BaseNode currentNode = GetCurrentNode();
      if (currentNode == null)
        return;
      if (currentNode.Kind == NodeKind.Device)
        currentNode = (BaseNode)currentNode.Parent;
      try
      {
        NodeEx node = NodeEx.FromNode(clipData.Node);
        node.IdOwn = currentNode.Node.Id;
        node.Id = 0;
        node.Path = null;
        node.EstCommStateGuid = null;
        node.IsError = false;
        Dal.Default.AddNodes(node);
        BaseNode baseNode;
        if (node.Kind == NodeKind.Device)
        {
          ScopeItem item = ScopeArea.Default.Add(node);//добавление в список устройств для отображения
          baseNode = AddBaseNodeAndRefreshChild(currentNode, (BaseNode) new DeviceNode(item));
        }
        else
        {
          baseNode = AddBaseNodeAndRefreshChild(currentNode, (BaseNode) new FolderNode(node));
        }
        tv.SelectedNode = baseNode;

      }
      catch (Exception exception)
      {
        Box.Error(this, exception);
      }

      SetControlsEnabled();
    }

    private void rbCatScheduler_Click(object sender, EventArgs e)
    {
      using (CatLightPlanForm frm = new CatLightPlanForm())
        frm.ShowDialog(this);
    }

    void SaveAppConfig()
    {
      Exception exception = AppConfig.Default.Save();
      if (exception != null)
        Box.Error(this, exception);
    }

    private void rbAbout_Click(object sender, EventArgs e)
    {
      using (AboutForm frm = new AboutForm())
        frm.ShowDialog(this);
    }

    BaseNode FindNode(NodeKind kind, int id, TreeNodeCollection collection)
    {
      BaseNode retVal = null;
      foreach (TreeNode node in collection)
      {
        BaseNode bn = node as BaseNode;
        if (bn == null) continue;
        if (bn.Kind != kind) continue;
        if (bn.Node.Id == id)
          return bn;
        retVal = FindNode(kind, id, bn.Nodes);
        if (retVal != null)
          break;
      }
      return retVal;
    }

    //FolderNode FindFolderNode(int id)
    //{
    //  return (FolderNode)FindNode(NodeKind.Folder, id, tv.Nodes);
    //}

    //DeviceNode FindDeviceNode(int id)
    //{
    //  return (DeviceNode)FindNode(NodeKind.Device, id, tv.Nodes);
    //}

    object GetActionResultForDevice(DeviceActionResult result, int deviceId)
    {
      object retVal = null;
      if (result == null) throw new ArgumentNullException(nameof(result));
      if (result.Values != null)
      {
        foreach (ActionResult res in result.Values)
        {
          if (res.DeviceId == deviceId)
          {
            retVal = res.Value;
            break;
          }
        }
      }
      return retVal;
    }

    public void BeginUserAction()
    {
      _doUserAction = true;
      Cursor = Cursors.WaitCursor;
      SetControlsEnabled();
      Application.DoEvents();
    }

    public TabControl TabControl
    {
      get { return tcZtpConfig; }
    }

    public void EndUserAction()
    {
      _doUserAction = false;
      Cursor = Cursors.Default;
      SetControlsEnabled();
      Application.DoEvents();
    }

    private void tv_AfterSelect(object sender, TreeViewEventArgs e)
    {
      //ShowCurrentZtpConfig();
      SetControlsEnabled();
    }

    ZtpConfig ReadNodeZtpConfig(Node node)
    {
      ZtpConfig retVal = null;
      DevAl.Default.ActionReadConfig(this, new DeviceActionArg(DeviceActionMode.Read)
      {
        Log = _tempLog,
        DeviceIds = new[] { node.Id },
        ReadTcpSetingFunc = Dal.Default.CreateTcpPortSettings
      }, result =>
      {
        object res = GetActionResultForDevice(result, node.Id);
        if (res != null)
        {
          if (res is DeviceUnknownError)
            ShowErrorAsync(res as DeviceUnknownError);
          retVal = res as ZtpConfig;
        }
      });
      return retVal;
    }

    

    void ShowErrorAsync(Exception ex)
    {
      if (InvokeRequired)
      {
        BeginInvoke(new Action<Exception>(ShowErrorAsync), ex);
        return;
      }
      Box.Error(this, ex);
    }

    public void ShowState(bool show)
    {
      foreach (TabPage page in tcZtpConfig.TabPages)
      {
        IChildForm frm = page.Form as IChildForm;
        frm?.ShowState(show);
      }
    }

    public void ShowDebug(bool show)
    {
      foreach (TabPage page in tcZtpConfig.TabPages)
      {
        IChildForm frm = page.Form as IChildForm;
        frm?.ShowDebug(show);
      }
    }


    private void rbViewDebug_Click(object sender, EventArgs e)
    {
      rbViewDebug.Checked = !rbViewDebug.Checked;
      AppConfig.Default.ShowDebug = rbViewDebug.Checked;
      AppConfig.Default.Save();
      ShowDebug(AppConfig.Default.ShowDebug);
    }

    private void rbViewState_Click(object sender, EventArgs e)
    {
      rbViewState.Checked = !rbViewState.Checked;
      AppConfig.Default.ShowState = rbViewState.Checked;
      AppConfig.Default.Save();
      ShowState(AppConfig.Default.ShowState);
    }

    private void tv_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      TreeViewHitTestInfo hitTest = tv.HitTest(e.X, e.Y);
      DeviceNode deviceNode = hitTest.Node as DeviceNode;
      if (deviceNode == null)
        return;
      rbDeviceOpen_Click(null, null);
    }

    private void rbDeviceOpen_Click(object sender, EventArgs e)
    {
      BaseNode baseNode = GetCurrentNode();
      DeviceNode deviceNode = baseNode as DeviceNode;
      if (deviceNode == null) return;
      ScopeItem item = ScopeArea.Default[deviceNode.Node.Id];
      if (item == null) return;
      _childFormControl.OpenConfigForm(item);
      ActivateConfigRibbon();
    }

    void ActivateConfigRibbon()
    {
      if (AppConfig.Default.AutoOpenConfigRibbon)
      {
        if (ribbon.ActiveTab != rtConfig)
          ribbon.ActiveTab = rtConfig;
      }
    }

    private void tv_KeyDown(object sender, KeyEventArgs e)
    {
      BaseNode baseNode = GetCurrentNode();
      if (baseNode == null)
        return;
      if (e.KeyCode == Keys.Delete)
      {
        if (baseNode.Kind == NodeKind.Folder)
          rbDeleteFolder_Click(null, null);
        else if (baseNode.Kind == NodeKind.Device)
          rbDeleteDevice_Click(null, null);
      }
    }

    private void ribbonButton_Click(object sender, EventArgs e)
    {
      ZtpConfigForm frm = _childFormControl.CurrentZtpConfigForm;
      if (frm == null) return;
      bool isSuccess = false;

      isSuccess = frm.DoAction(_buttons[sender]);

      if (isSuccess)
        SetControlsEnabled();
    }

    //private void rbSeasonAdd_Click(object sender, EventArgs e)
    //{
    //  ZtpConfigForm frm = _childFormControl.CurrentZtpConfigForm;
    //  if (frm == null) return;
    //  if (frm.DoSeasonAdd())
    //    SetControlsEnabled();
    //}

    //private void rbSeasonDelete_Click(object sender, EventArgs e)
    //{
    //  ZtpConfigForm frm = _childFormControl.CurrentZtpConfigForm;
    //  if (frm == null) return;
    //  if (frm.DoSeasonDelete())
    //    SetControlsEnabled();
    //}

    //private void rbSeasonEdit_Click(object sender, EventArgs e)
    //{
    //  ZtpConfigForm frm = _childFormControl.CurrentZtpConfigForm;
    //  if (frm == null) return;
    //  if (frm.DoSeasonEdit())
    //    SetControlsEnabled();
    //}

    //private void rbScheduleEdit_Click(object sender, EventArgs e)
    //{
    //  ZtpConfigForm frm = _childFormControl.CurrentZtpConfigForm;
    //  if (frm == null) return;
    //  if (frm.DoScheduleEdit())
    //    SetControlsEnabled();
    //}

    //private void rbScheduleDelete_Click(object sender, EventArgs e)
    //{
    //  ZtpConfigForm frm = _childFormControl.CurrentZtpConfigForm;
    //  if (frm == null) return;
    //  if (frm.DoScheduleDelete())
    //    SetControlsEnabled();
    //}
    //private void rbScheduleAdd_Click(object sender, EventArgs e)
    //{
    //  ZtpConfigForm frm = _childFormControl.CurrentZtpConfigForm;
    //  if (frm == null) return;
    //  if (frm.DoScheduleAdd())
    //    SetControlsEnabled();
    //}

    //private void rbReboot_Click(object sender, EventArgs e)
    //{
    //  ZtpConfigForm frm = _childFormControl.CurrentZtpConfigForm;
    //  if (frm == null) return;
    //  frm.DoReboot();
    //}

    //private void rbChangePassword_Click(object sender, EventArgs e)
    //{

    //}

    private void rbSwitchOnOff_Click(object sender, EventArgs e)
    {
      ZtpConfigForm frm = _childFormControl.CurrentZtpConfigForm;
      if (frm == null) return;
      bool isOn = Convert.ToBoolean(rbSwitchOnOff.Tag);
      frm.DoSwitchOnOff(isOn);
      SetControlsEnabled();
    }

    //private void rbCopyPlanFromCat_Click(object sender, EventArgs e)
    //{
    //  ZtpConfigForm frm = _childFormControl.CurrentZtpConfigForm;
    //  if (frm == null) return;
    //  if (frm.DoCopyLightPlan())
    //    SetControlsEnabled();
    //}

    //private void rbShowScheduler_Click(object sender, EventArgs e)
    //{
    //  ZtpConfigForm frm = _childFormControl.CurrentZtpConfigForm;
    //  if (frm == null) return;
    //  frm.SetCoordForLight();
    //  //frm.DoScheduleShow();
    //}

    private void rbMultiWriteLightPlan_Click(object sender, EventArgs e)
    {
      using (MultiConfigForm frm = new MultiConfigForm())
      {
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          ZtpConfig ztpConfig = frm.Value;
          _childFormControl.CloseZtpConfigForms(frm.SelectedDevices.ToArrayOfIds());
          MultiWriteConfig(frm.SelectedDevices, ztpConfig);
        }
      }
    }

    private void rbMultiSwitchOnOff_Click(object sender, EventArgs e)
    {
      using (MultiSwitchOnOffForm frm = new MultiSwitchOnOffForm())
      {
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          bool isOn = frm.SwitchOn;
          List<NodeEx> devices = frm.SelectedDevices;
          MultiSwitchOnOff(devices, isOn);
        }
      }
    }

    private void rbMultiChangePassword_Click(object sender, EventArgs e)
    {
      using (MultiChangePasswordForm frm = new MultiChangePasswordForm())
      {
        if (frm.ShowDialog() == DialogResult.OK)
        {
          string psw = frm.ValuePassword;
          List<NodeEx> devices = frm.SelectedDevices;
          MultiChangePassword(devices, psw);
        }
      }
    }

    /// <summary>
    /// Запись прошивки скопом
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void rbMultiWriteFota_Click(object sender, EventArgs e)
    {
      using (MultiFotaForm frm = new MultiFotaForm())
      {
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          List<NodeEx> devices = frm.SelectedDevices;
          _childFormControl.CloseZtpConfigForms(devices.ToArrayOfIds());
          //тут добавить вилку на тип устройств
          MultiWriteFota(frm.SelectedDevices, frm.ModemFile, frm.ControllerFile);
        }
      }
    }

    private void rbMultiReboot_Click(object sender, EventArgs e)
    {
      using (MultiRebootForm frm = new MultiRebootForm())
      {
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          List<NodeEx> devices = frm.SelectedDevices;
          _childFormControl.CloseZtpConfigForms(devices.ToArrayOfIds());
          MultiWriteReboot(devices);
        }
      }
    }

    private void rbMultiWritePatch_Click(object sender, EventArgs e)
    {
      using (MultiPatchForm frm = new MultiPatchForm())
      {
        if(frm.ShowDialog(this) == DialogResult.OK)
        {
          //List<NodeEx> devices = frm.Select
          List<NodeEx> devices = frm.SelectedDevices;
          _childFormControl.CloseZtpConfigForms(devices.ToArrayOfIds());
          //тут добавить вилку на тип устройств
          //MultiWriteFota(frm.SelectedDevices, frm.ModemFile, frm.ControllerFile);
          MultiWritePatch(frm.SelectedDevices);
        }
      }
    }



    private void rbObjectList_Click(object sender, EventArgs e)
    {
      using (ObjectListForm frm = new ObjectListForm())
      {
        frm.ShowDialog(this);
      }
    }

    private void rbLastOp_Click(object sender, EventArgs e)
    {
      using (LastOpForm frm = new LastOpForm())
      {
        frm.ShowDialog(this);
      }
    }

    private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {
      e.Cancel = tv.SelectedNode == null;
    }

    private void tv_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      TreeNode tn = tv.GetNodeAt(e.X, e.Y);
      BaseNode baseNode = tn as BaseNode;
      tv.SelectedNode = tn;
      if (baseNode == null)
        return;
      contextMenu.Show(tv, new Point(e.X, e.Y));
    }

    private void rbAudit_Click(object sender, EventArgs e)
    {
      DeviceNode deviceNode = GetCurrentNode() as DeviceNode;
      if (deviceNode == null)
        return;
      HistoryForm frm = new HistoryForm();
      ScopeItem scopeItem = ScopeArea.Default[deviceNode.Node.Id];
      frm.DeviceId = deviceNode.Node.Id;
      frm.ShowData(this, scopeItem.NodeEx.DisplayPath);
    }

    private void rbSyncEst_Click(object sender, EventArgs e)
    {
      string message = $"Вы действительно хотите обновить наименования и адреса устройств из настроек EST Tools?";
      if (!Box.Confirm(this, message))
        return;
      SyncFromEst();
    }

  }
}
