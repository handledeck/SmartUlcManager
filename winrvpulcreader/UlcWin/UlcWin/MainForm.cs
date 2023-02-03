#define STAT
using BrightIdeasSoftware;
using InterUlc.Db;
using InterUlc.Logs;
using Npgsql;
using PresentationControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.AplSetings;
using UlcWin.Controls.ListViewHeaderMenu;
using UlcWin.Controls.UlcMeterComponet;
using UlcWin.DB;
using UlcWin.Drivers;
using UlcWin.Edit;
using UlcWin.Fota;
using UlcWin.Statistics;
using UlcWin.ui;
using UlcWin.win;
using Ztp.Configuration;
using Ztp.Protocol;
using Ztp.Ui;

namespace UlcWin
{


  public partial class LoadForm : Form
  {

    public DbReader __db;
    UlcWin.win.WaitForm __frm = null;
    List<ItemCallBack> __lip = null;
    UNode __sel_node = null;
    Controls.UlcMeterComponet.EventDateTimePicker __dtp_from = null;
    Controls.UlcMeterComponet.EventDateTimePicker __dtp_to = null;
    List<int> __coluns_width = null;
    List<ListViewItem> __lvItemChecked = null;
    AutoCompleteCombobox __tsAutoCompleteCmb = null;
    List<ListObj> __list_objects = null;
    ASettings __aSettings_old = null;
    ASettings __aSettings_new = null;
    public delegate TcpClient GetConnectionDelegate(string host, int port);
    public delegate void PingDelegate(ItemCallBack pitem, bool result);
    private DateTime __previousValueFrom = DateTime.Now;
    private DateTime __previousValueTo = DateTime.Now;
    public LoadForm()
    {
      InitializeComponent();
      this.tsStsLabelAll.Visible = false;
      this.tsStsLblNotTrue.Visible = false;
      this.tsStsNetBad.Visible = false;
      this.tsStsRssBad.Visible = false;
      this.tsStsIMEI.Visible = false;
      //this.tsLblFind.Visible = false;
      this.LstViewItm.Visible = false;
      this.tsResView.Visible = false;
      this.ulcMeterTreeView.Visible = false;
      __dtp_from = new Controls.UlcMeterComponet.EventDateTimePicker();
      __dtp_from.Name = "from";
      __dtp_from.ValueChanging += __dtp_from_ValueChanging;
      __dtp_from.ValueChanged += __dtp_ValueChanged;
      __dtp_to = new Controls.UlcMeterComponet.EventDateTimePicker();
      __dtp_to.Name = "to";
      __dtp_to.ValueChanging += __dtp_to_ValueChanging;
      __dtp_to.ValueChanged += __dtp_ValueChanged;
      this.checkBoxComboBox1.DropDownHeight = 350;
      __coluns_width = new List<int>();
      __tsAutoCompleteCmb = new AutoCompleteCombobox();
      __tsAutoCompleteCmb.Font = this.checkBoxComboBox1.Font;
      __tsAutoCompleteCmb.Width = 250;
      //__autoCompleteCmb.DropDownWidth = 500;
      __tsAutoCompleteCmb.KeyUp += __autoCompleteCmb_KeyUp;
      __tsAutoCompleteCmb.DropDown += __autoCompleteCmb_DropDown;
      __tsAutoCompleteCmb.SelectionChangeCommitted += __tsAutoCompleteCmb_SelectionChangeCommitted;
      ToolStripControlHost dtCtl__from = new ToolStripControlHost(__dtp_from);
      ToolStripControlHost dtCtl__to = new ToolStripControlHost(__dtp_to);
      this.checkBoxComboBox1.Visible = false;
      //ToolStripControlHost dtCtlCbBox = new ToolStripControlHost(this.checkBoxComboBox1);
      //dtCtlCbBox.Margin = new Padding(0, 0, 10, 0);
      //dtCtlCbBox.Alignment = ToolStripItemAlignment.Right;
      //this.tsResView.Items.Insert(1, dtCtlCbBox);
      //ToolStripControlHost dtCtrlCbFind = new ToolStripControlHost(this.__tsAutoCompleteCmb);
      //ToolStripControlHost dtCtrlCbFind = new ToolStripControlHost(this.textBox1);
      //dtCtrlCbFind.Alignment = ToolStripItemAlignment.Left;
      //dtCtrlCbFind.Margin = new Padding(10, 0, 0, 0);
      //this.tsResView.Items.Insert(8, dtCtrlCbFind);
      //this.__tsAutoCompleteCmb.Visible = false;
      this.tsEvent.Items.Insert(2, dtCtl__from);
      this.tsEvent.Items.Insert(4, dtCtl__to);
      this.tsEvent.Enabled = false;
      this.tsTreePanel.Enabled = false;
      this.__lvItemChecked = new List<ListViewItem>();
      Application.Idle += Application_Idle;
      this.tsComboBoxDev.SelectedIndex = 1;
      this.Shown += StartForm_Shown;
      this.Text = "Обозреватель работы контроллеров";
      panel1.Paint += Panel1_Paint;
      panel2.Paint += Panel1_Paint;
      this.FormClosing += MainForm_FormClosing;
      __list_objects = null;//new List<ListObj>();
      this.tsResView.Enabled = false;
      //this.treeView1.Nodes.Clear();
      this.LstViewItm.ColumnRightClick += LstViewItm_ColumnRightClick;
      this.LstViewItm.ListViewMouseRightClick += LstViewItm_ListViewMouseRightClick;
      this.ulcMeterTreeView.__statusStrip = this.tsStatusLbl;
      
    }

    bool CheckDateTimeEvent()
    {
      DateTime dt_f = new DateTime(__dtp_from.Value.Year, __dtp_from.Value.Month, __dtp_from.Value.Day);
      DateTime dt_t = new DateTime(__dtp_to.Value.Year, __dtp_to.Value.Month, __dtp_to.Value.Day);
      if (dt_f > dt_t || dt_t < dt_f)
      {
        MessageBox.Show("Дата и время начала должна быть больше конечной даты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }
      else
        return true;
    }

    private void __dtp_to_ValueChanging(object sender, CancelEventArgs e)
    {
      if (!CheckDateTimeEvent())
        e.Cancel = true;
      else
        e.Cancel = false;
    }

    private void __dtp_from_ValueChanging(object sender, CancelEventArgs e)
    {
      if (!CheckDateTimeEvent())
        e.Cancel = true;
      else
        e.Cancel = false;
    }

    private void __dtp_ValueChanged(object sender, EventArgs e)
    {
      this.ReadEvent();
      __previousValueFrom = __dtp_from.Value;
      __previousValueTo = __dtp_to.Value;
    }

    private void LstViewItm_ListViewMouseRightClick(object sender)
    {
      this.LvMenu.Show(Cursor.Position);
      
    }
    [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
    const int LVM_FIRST = 0x1000;
    const int LVM_GETHEADER = LVM_FIRST + 31;
    private void LstViewItm_ColumnRightClick(object sender, ColumnHeader e, Point point)
    {
      //IntPtr hHeader = (IntPtr)SendMessage(LstViewItm.Handle, LVM_GETHEADER, (int)IntPtr.Zero, (int)IntPtr.Zero);
      //BrightIdeasSoftware.ToolTipControl toolTipControl = new BrightIdeasSoftware.ToolTipControl();
      //toolTipControl.Create(hHeader);
      //toolTipControl.
      //toolTipControl.AddTool(LstViewItm);
      //this.toolTip1.Active = true;
      //this.toolTip1.Show("aaa",LstViewItm, point, 5000);
      this.ctxMenuHeader.Show(point);
      //if (this.LstViewItm.Items.Count > 0) {
      //  if (e.Index == 1)
      //  {
      //    this.ctxMenuHeader.Show(point);
      //  }
      //}
    }

    //bool __settings_changed = false;
    private void LstViewItm_ColumnReordered(object sender, ColumnReorderedEventArgs e)
    {
      __aSettings_new.Settings_changed = true;
    }

    private void __tsAutoCompleteCmb_SelectionChangeCommitted(object sender, EventArgs e)
    {
      this.__autoCompleteCmb_KeyUp(sender, new KeyEventArgs(Keys.Enter));
    }

    private void __autoCompleteCmb_DropDown(object sender, EventArgs e)
    {
      ComboBox senderComboBox = (ComboBox)sender;
      int width = senderComboBox.DropDownWidth;
      Graphics g = senderComboBox.CreateGraphics();
      Font font = senderComboBox.Font;
      int vertScrollBarWidth =
          (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
          ? SystemInformation.VerticalScrollBarWidth : 0;

      int newWidth;
      foreach (ListObj s in ((ComboBox)sender).Items)
      {
        newWidth = (int)g.MeasureString(s.Name, font).Width
            + vertScrollBarWidth;
        if (width < newWidth)
        {
          width = newWidth;
        }
        if (senderComboBox.Width < newWidth)
        {
          senderComboBox.Width = newWidth + SystemInformation.VerticalScrollBarWidth;
        }
      }
      senderComboBox.DropDownWidth = width;
    }

    private void __autoCompleteCmb_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        ListObj obj = (ListObj)__tsAutoCompleteCmb.SelectedItem;

        if (obj != null)
        {
          ListViewItem itm = this.LstViewItm.Items.Cast<ListViewItem>().
         FirstOrDefault(x => x.SubItems[1].Text == obj.Name);
          if (itm == null)
            return;
          //LstViewItm.Select();
          //LstViewItm.EnsureVisible(obj.Row);
          //LstViewItm.Items[obj.Row].Selected = true;
          int indx = LstViewItm.Items.IndexOf(itm);
          LstViewItm.Items[indx].Focused = true;
          LstViewItm.Items[indx].Selected = true;
          LstViewItm.Items[indx].EnsureVisible();
          LstViewItm.Select();
          LstViewItm.Items[indx].Selected = true;
        }
      }
    }

    
    void LoadSetiings()
    {

      __aSettings_old = ASettings.LoadAppSettings();
      __aSettings_new = new ASettings();
      if (__aSettings_old == null)
      {
        __aSettings_old = new ASettings() { CheckedItemVisible = new List<int>(), WidthColumnsDevice = new List<int>() };
        for (int i = 0; i < LstViewItm.Columns.Count; i++)
        {
          __aSettings_old.WidthColumnsDevice.Add(LstViewItm.Columns[i].Width);
        }
        for (int i = 3; i < LstViewItm.Columns.Count; i++)
        {
          int id = this.checkBoxComboBox1.Items.Add(LstViewItm.Columns[i].Text);
          ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(LstViewItm.Columns[i].Text);
          toolStripMenuItem.Checked = true;
          ctxMenuHeader.Items.Add(toolStripMenuItem);
        }
        for (int i = 0; i < this.checkBoxComboBox1.Items.Count; i++)
        {
          this.checkBoxComboBox1.CheckBoxItems[i].Checked = true;
          this.checkBoxComboBox1.CheckBoxItems[i].Tag = i;
          __aSettings_old.CheckedItemVisible.Add(1);
          //int id = this.checkBoxComboBox1.Items.Add(LstViewItm.Columns[i].Text);
          ((ToolStripMenuItem)ctxMenuHeader.Items[i]).Tag = i;
          ((ToolStripMenuItem)ctxMenuHeader.Items[i]).CheckedChanged += MainForm_CheckedChanged;
          ((ToolStripMenuItem)ctxMenuHeader.Items[i]).CheckOnClick = true;
          this.checkBoxComboBox1.CheckBoxItems[i].CheckedChanged += MainForm_CheckedChanged;
        }
        if (__aSettings_old.DisplayEventChecked == null)
        {
          __aSettings_old.DisplayEventChecked = new List<int>() { 14, 100 };
          __aSettings_old.Settings_changed = true;
        }
      }
      else
      {
        for (int i = 0; i < __aSettings_old.WidthColumnsDevice.Count; i++)
        {
          this.LstViewItm.Columns[i].Width = __aSettings_old.WidthColumnsDevice[i];
          if (i > 2)
          {
            int id = this.checkBoxComboBox1.Items.Add(LstViewItm.Columns[i].Text);
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(LstViewItm.Columns[i].Text);
            toolStripMenuItem.Checked = true;
            ctxMenuHeader.Items.Add(toolStripMenuItem);
            toolStripMenuItem.CheckOnClick = true;
          }
        }
        for (int i = 0; i < __aSettings_old.CheckedItemVisible.Count; i++)
        {
          //int id = this.checkBoxComboBox1.Items.Add(LstViewItm.Columns[i].Text);
          
          if (__aSettings_old.CheckedItemVisible[i] == 0)
          {
            
            this.checkBoxComboBox1.CheckBoxItems[i].Checked = false;
            ((ToolStripMenuItem)ctxMenuHeader.Items[i]).Checked = false;
            this.LstViewItm.Columns[i + 3].Width = 0;
          }
          else
          {
            this.checkBoxComboBox1.CheckBoxItems[i].Checked = true;
            ((ToolStripMenuItem)ctxMenuHeader.Items[i]).Checked = true;
          }
          this.checkBoxComboBox1.CheckBoxItems[i].Tag = i;
          this.checkBoxComboBox1.CheckBoxItems[i].CheckedChanged += MainForm_CheckedChanged;
          ((ToolStripMenuItem)ctxMenuHeader.Items[i]).Tag = i;
          ((ToolStripMenuItem)ctxMenuHeader.Items[i]).CheckedChanged += MainForm_CheckedChanged;
        }
        for (int i = 0; i < this.LstViewItm.Columns.Count; i++)
        {
          this.LstViewItm.Columns[i].DisplayIndex = __aSettings_old.DisplayIndexes[i];

        }

        __aSettings_new = (ASettings)__aSettings_old.Clone();
      }
    }
   

    private void LstViewItm_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
    {
      if (__form_shown)
      {
        if (this.LstViewItm.Columns[e.ColumnIndex].Width != 0)
        {
          this.__aSettings_old.WidthColumnsDevice[e.ColumnIndex] = this.LstViewItm.Columns[e.ColumnIndex].Width;
          __aSettings_new.Settings_changed= true;
        }
      }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      //this.__aSettings_new.DisplayIndexes = null;
      this.__aSettings_new.DisplayIndexes = new List<int>();
      for (int i = 0; i < this.LstViewItm.Columns.Count; i++)
      {
        this.__aSettings_new.DisplayIndexes.Add(this.LstViewItm.Columns[i].DisplayIndex);
      }
      this.__aSettings_new.WidthColumnsDevice = this.__aSettings_old.WidthColumnsDevice;
      this.__aSettings_new.CheckedItemVisible = this.__aSettings_old.CheckedItemVisible;
      DialogResult result = MessageBox.Show("Закрыть приложение", "Закрытие приложения",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (result == DialogResult.Yes)
      {
        this.__db.LogsInsertEvent(EnLogEvt.APP_EXIT,/* string.Format("{0}", this.__db.__DbUserName)*/"",-1);
       
        if (__aSettings_new.Settings_changed)
        {
          result = MessageBox.Show("Сохранить настройки приложения?", "Закрытие приложения",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
          if (result == DialogResult.Yes)
          {
            ASettings.SaveAppSettings(__aSettings_new);
          }
        }
      }
      else {
        e.Cancel=true;
      }
    }
    private void Panel1_Paint(object sender, PaintEventArgs e)
    {
      ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.LightGray, ButtonBorderStyle.Solid);

    }

    bool __form_shown = false;

    private void StartForm_Shown(object sender, EventArgs e)
    {
      this.splitContainer2.Panel2Collapsed = true;
      this.splitContainer2.Panel2.Hide();
      tsBtnEventShowHide.ToolTipText = "Показать панель событий";
      this.tsSelectShow.Enabled = false;
      this.tsUpdate.Enabled = false;
      this.tsSelectedItems.Enabled = false;
      this.tsDwnUpdate.Enabled = false;
      toolStripButton3_Click_1(null, null);
      this.tsStsLabelAll.Margin = new Padding((this.splitContainer1.SplitterDistance), 0, 0, 0);
      LoadSetiings();
     
      this.LstViewItm_ColumnClick(this.LstViewItm, new ColumnClickEventArgs(1));
      //__init_showed = true;
      //this.LstViewItm_ColumnClick()
      this.LstViewItm.ColumnReordered += LstViewItm_ColumnReordered;
      __form_shown = true;
    }

    private void MainForm_CheckedChanged(object sender, EventArgs e)
    {
      int index = 0;
      CheckState checkState;
      if (sender.GetType() == typeof(ToolStripMenuItem))
      {
        ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
        index = (int)toolStripMenuItem.Tag;
        checkState = toolStripMenuItem.CheckState;
      }
      else {
        CheckBoxComboBoxItem item = (CheckBoxComboBoxItem)sender;
        index = (int)item.Tag;
        checkState = item.CheckState;
      }
      

      //int index = (int)item.Tag;
      if (checkState == CheckState.Unchecked)
      {
        this.LstViewItm.Columns[index + 3].Width = 0;
        __aSettings_new.CheckedItemVisible[index] = 0;
      }
      else
      {
        this.LstViewItm.Columns[index + 3].Width = __aSettings_new.WidthColumnsDevice[index + 3];
        __aSettings_new.CheckedItemVisible[index] = 1;
      }
      // this.checkBoxComboBox1.ShowDropDown();
      __aSettings_new.Settings_changed = true;
    }

    void AdminUserAccses(bool isUserEditVisible,bool read_only)
    {
      if (read_only)
      {
        this.ctxMenuItemAdd.Visible = false;
        this.ctxMenuItemChange.Visible = false;
        this.ctxMenuItemDelete.Visible = false;
        this.ctxSeparateEdit.Visible = false;
        this.ctxMenuAtCommand.Visible = false;
      }
      else
      {
        this.ctxMenuItemAdd.Visible = true;
        this.ctxMenuItemChange.Visible = true;
        this.ctxMenuItemDelete.Visible = true;
        this.ctxSeparateEdit.Visible = true;
        this.ctxMenuAtCommand.Visible = true;
      }
      if (this.treeView1.Nodes.Count == 0 || this.treeView1.SelectedNode==null)
      {
        this.tsTreeBtnAdd.Enabled = false;
        this.tsTreeBtnDelete.Enabled = false;
        this.tsTreeBtnEdit.Enabled = false;
        this.tsMnuTreeAddItem.Enabled = false;
        this.tsMnuTreeEdit.Enabled = false;
        this.tsMnuTreeDeleteItem.Enabled = false;
        this.tsTreeBtnEdit.Enabled = false;
        this.tsTreeBtnDelete.Enabled = false;
        this.splitContainer2.Panel2Collapsed = true;
       
      }
      else {
        this.tsTreeBtnEdit.Enabled = true;
        this.tsTreeBtnDelete.Enabled = true;
        this.tsMnuTreeDeleteItem.Enabled = true;
        this.tsMnuTreeEdit.Enabled = true;
      }
      //this.ctxMenuItemAdd.Visible = true;
      //this.ctxMenuItemChange.Visible = true;
      //this.ctxMenuItemDelete.Visible = true;
      //this.ctxSeparateEdit.Visible = true;
      

      this.ctxSeparatePing.Visible = true;
      //this.ctxMenuAtCommand.Visible = true;
     

      UNode uNode = (UNode)treeView1.SelectedNode;
      if (uNode != null)
      {
        if (!uNode.IsView)
        {
          this.LstViewItm.Items.Clear();
          this.tsResView.Enabled = false;
        }
        else
        {
          this.LvMenu.Enabled = true;
          this.tsResView.Enabled = true;
        }
        if (this.__lvItemChecked.Count > 0)
        {
          this.ctxMenuUpdateSelected.Enabled = true;
          this.tsDwnUpdate.Enabled = true;

        }
        else
        {
          this.ctxMenuUpdateSelected.Enabled = false;
          this.tsDwnUpdate.Enabled = false;

        }
        if (this.LstViewItm.Items.Count > 0)
        {
          this.tsSelectedItems.Enabled = true;
          if (this.LstViewItm.SelectedItems.Count != 0)
          {
            ///////////////////this.tsBtnEventShowHide.Enabled = true;
          }
          else
          {
            /////////////////////////////this.tsBtnEventShowHide.Enabled = false;
          }
          
          //this.ctxMenuItemChange.Enabled = true;
          //this.ctxMenuItemDelete.Enabled = true;
          //this.ctxMenuPingCurrentItem.Enabled = true;
          this.ctxMenuUpdateCurrent.Enabled = true;
          this.ctxMenuUpdateSelected.Enabled = true;
          this.ctxMenuReadCurrentLog.Enabled = true;
          this.ctxMenuUpdateCurrent.Enabled = true;
          this.ctxMenuUpdateNotTrue.Enabled = true;
          this.ctxMenuUpdateAll.Enabled = true;
        }
        else
        {
          this.tsSelectedItems.Enabled = false;
          ///////////////////////////////////this.tsBtnEventShowHide.Enabled = false;
          this.LstViewEvent.Visible = false;
          this.ctxMenuItemChange.Enabled = false;
          this.ctxMenuItemDelete.Enabled = false;
          this.ctxMenuPingCurrentItem.Enabled = false;
          this.ctxMenuUpdateCurrent.Enabled = false;
          this.ctxMenuUpdateSelected.Enabled = false;
          this.ctxMenuReadCurrentLog.Enabled = false;
          this.ctxMenuUpdateCurrent.Enabled = false;
          this.ctxMenuUpdateNotTrue.Enabled = false;
          this.ctxMenuUpdateAll.Enabled = false;
          this.ctxMenuAtCommand.Enabled = false;
          this.tsUpdate.Enabled = false;
        }
      }
      else
      {
        this.LvMenu.Visible = false;
      }
      if (!isUserEditVisible)
      {
        this.tsBtnEventLog.Visible = false;
        this.tsBtnUsersEdit.Visible = false;
        this.tsBtnStatistics.Visible = false;
        toolStripSeparator2.Visible = false;
        toolStripSeparator7.Visible = false;
        treeMenu.Enabled = false;
        this.ctxMenuAtCommand.Enabled = false;
        this.tsTreePanel.Visible = false;
        this.treeMenu.Enabled = false;
      }
      else
      {
        this.tsBtnEventLog.Visible = true;
        this.tsBtnUsersEdit.Visible = true;
#if STAT
        this.tsBtnStatistics.Visible = true;
#endif
        toolStripSeparator2.Visible = true;
        toolStripSeparator7.Visible = true;
        treeMenu.Enabled = true;
        this.ctxMenuAtCommand.Visible = true;
        this.treeMenu.Enabled = true;
      }
      if (!read_only)
      {
        this.tsDwnUpdate.Visible = true;

        //this.treeMenu.Visible = false;
      }
      else
      {
        this.tsDwnUpdate.Visible = false;
       
      }
      //if (this.LstViewItm.Items.Count == 0)
      //{
      //  this.splitContainer2.Panel2Collapsed = true;
      //  splitContainer2.Panel2.Hide();
      //  tsBtnEventShowHide.Image = global::UlcWin.Properties.Resources.window_split_ver;
      //}
      //else {
      //  this.splitContainer2.Panel2Collapsed = false;
      //  splitContainer2.Panel2.Show();
      //}
    }

    //void ReadOnlyUserAccses()
    //{
    //  this.ctxMenuItemAdd.Visible = false;
    //  this.ctxMenuItemChange.Visible = false;
    //  this.ctxMenuItemDelete.Visible = false;
    //  this.ctxSeparateEdit.Visible = false;
    //  this.tsDwnUpdate.Visible = false;
    //  this.ctxSeparatePing.Visible = false;
    //  this.ctxMenuAtCommand.Visible = false;
    //  this.treeMenu.Visible = false;
    //  //tsTreeBtnAddRoot.Enabled = false;
    //  //tsTreeAddItem.Enabled = false;
    //  tsTreePanel.Visible = false;
    //  UNode uNode = (UNode)treeView1.SelectedNode;
    //  if (uNode != null)
    //  {

    //    if (!uNode.IsView)
    //    {
    //      this.LvMenu.Visible = false;
    //      this.LstViewItm.Items.Clear();

    //    }
    //    else
    //    {
    //      this.LvMenu.Enabled = true;

    //    }

    //    if (this.LstViewItm.Items.Count > 0)
    //    {
    //      this.ctxMenuItemAdd.Enabled = false;
    //      this.tsDwnUpdate.Enabled = true;
    //      this.tsSelectedItems.Enabled = true;
    //      this.ctxMenuItemChange.Enabled = false;
    //      this.ctxMenuItemDelete.Enabled = false;
    //      this.ctxMenuPingCurrentItem.Enabled = true;
    //      this.ctxMenuUpdateCurrent.Enabled = true;
    //      this.ctxMenuUpdateSelected.Enabled = true;
    //      this.ctxMenuReadCurrentLog.Enabled = true;
    //      this.ctxMenuUpdateCurrent.Enabled = true;
    //      this.ctxMenuUpdateNotTrue.Enabled = true;
    //      this.ctxMenuUpdateAll.Enabled = true;
    //      this.ctxMenuAtCommand.Enabled = true;
    //      this.tsUpdate.Enabled = true;
    //    }
    //    else
    //    {
    //      this.ctxMenuItemAdd.Enabled = false;
    //      this.tsSelectedItems.Enabled = false;
    //      this.tsDwnUpdate.Enabled = false;
    //      //this.LvMenu.Enabled = false;
    //      this.ctxMenuItemChange.Enabled = false;
    //      this.ctxMenuItemDelete.Enabled = false;
    //      this.ctxMenuPingCurrentItem.Enabled = false;
    //      this.ctxMenuUpdateCurrent.Enabled = false;
    //      this.ctxMenuUpdateSelected.Enabled = false;
    //      this.ctxMenuReadCurrentLog.Enabled = false;
    //      this.ctxMenuUpdateCurrent.Enabled = false;
    //      this.ctxMenuUpdateNotTrue.Enabled = false;
    //      this.ctxMenuUpdateAll.Enabled = false;
    //      this.ctxMenuAtCommand.Enabled = false;
    //      this.tsUpdate.Enabled = false;
    //    }
    //  }
    //  else
    //  {
    //    this.LvMenu.Visible = false;
    //  }
    //  this.tsBtnEventLog.Visible = false;
    //  this.tsBtnUsersEdit.Visible = false;
    //  this.tsBtnStatistics.Visible = false;
    //  toolStripSeparator2.Visible = false;
    //  toolStripSeparator7.Visible = false;

    //}


    private void Application_Idle(object sender, EventArgs e)
    {
      if(this.treeView1.Nodes.Count==0)
        this.usrFesStatistics1.Visible = false;
      if (/*this.__db.__ulcUser == null &&*/ this.__db.__super_user)
      {
        AdminUserAccses(true,false);
        
      }
      else if (this.__db.__ulcUser != null)
      {
        if (this.__db.__ulcUser.AccsessLavel == EnumAccsesLevel.ReadWrite)
        {
          AdminUserAccses(false,false);
          
        }
        if (this.__db.__ulcUser.AccsessLavel == EnumAccsesLevel.Full)
        {
          //AdminUserAccses(true);
        }
        else if (this.__db.__ulcUser.AccsessLavel == EnumAccsesLevel.Read)
        {
          //ReadOnlyUserAccses();
          AdminUserAccses(false,true);
        }
      }
      if (this.tsComboBoxDev.SelectedIndex == 0)
      {
        tsMenuItem_Patch.Enabled = false;
        tsMenuItem_Pgrm.Enabled = false;
        //LvMenu.Enabled = false;
        LvMenu.Items["ctxMenuReadCurrentLog"].Enabled = false;
        LvMenu.Items["ctxMenuAtCommand"].Enabled = false;
      }
      else
      {
        tsMenuItem_Pgrm.Enabled = true;
        tsMenuItem_Patch.Enabled = true;
        //LvMenu.Enabled = true;
        LvMenu.Items["ctxMenuReadCurrentLog"].Enabled = true;
        LvMenu.Items["ctxMenuAtCommand"].Enabled = true;
      }
      if (this.LstViewItm.Items.Count > 0)
      {
        this.tsBtnExport.Enabled = true;
      }
      else
      {
        this.tsBtnExport.Enabled = false;

      }
      if (this.LstViewItm.SelectedItems.Count == 0)
      {
        ctxMenuAtCommand.Enabled = false;
        ctxMenuItemChange.Enabled = false;
        ctxMenuItemDelete.Enabled = false;
        ctxMenuPingCurrentItem.Enabled = false;
        ctxMenuReadCurrentLog.Enabled = false;
        ctxMenuUpdateCurrent.Enabled = false;
        //ctxMenuUpdateNotTrue.Enabled = false;
        ctxMenuUpdateSelected.Enabled = false;
        ctxMenuMeter.Enabled = false;
        ctxNotTrueMeter.Enabled = false;
      }
      else
      {
        ctxMenuAtCommand.Enabled = true;
        ctxMenuItemChange.Enabled = true;
        ctxMenuItemDelete.Enabled = true;
        ctxMenuPingCurrentItem.Enabled = true;
        ctxMenuReadCurrentLog.Enabled = true;
        ctxMenuUpdateCurrent.Enabled = true;
        ctxNotTrueMeter.Enabled = true;
        //ctxMenuUpdateNotTrue.Enabled = true;

        ctxMenuMeter.Enabled = true;
      }
      if (this.__lvItemChecked != null && this.__lvItemChecked.Count > 0)
      {
        ctxMenuUpdateSelected.Enabled = true;
      }
      else
      {
        ctxMenuUpdateSelected.Enabled = false;
      }
      //this.LvMenu.Visible = true;
    }

    
   

    public bool InitDB()
    {
      bool bReadDB = false;

      while (true)
      {

        using (ConnectionDBForm dBConnForm = new ConnectionDBForm(this.__db))
        {
          if (__db == null)
            __db = dBConnForm.__db;
          else
          {
            __db = new DbReader(dBConnForm.txtIpOrName.Text, dBConnForm.txtUser.Text,
                  /*"pgp@ssdb"*/dBConnForm.txtPassword.Text);
          }
          DialogResult result = dBConnForm.ShowDialog();
          __db.__dBIpAddress = dBConnForm.txtIpOrName.Text;
          __db.__DbUserName = dBConnForm.txtUser.Text;
          __db.__DbPassword = dBConnForm.txtPassword.Text;
          __db.SetStringConnection();
          if (result == DialogResult.Cancel)
          {
            bReadDB = false;
            break;
          }
          else if (result == DialogResult.OK)
          {

            if (__db.DbTestConnection())
            {
              this.__db.LogsInsertEvent(EnLogEvt.APP_CONNECT,/*string.Format("{0}",this.__db.__DbUserName)*/"0.0.0.0",-1);
              __db.FillTreeByUser(this.treeView1);
              if (this.__sel_node != null)
              {
                if (this.__sel_node.IsView)
                {
                  this.tsSelectShow.Enabled = false;
                  this.tsUpdate.Enabled = false;
                }
                else
                {
                  this.tsSelectShow.Enabled = true;
                  this.tsUpdate.Enabled = true;
                  this.LstViewItm_ColumnClick(this.LstViewItm, new ColumnClickEventArgs(1));
                }
              }
              bReadDB = true;
              break;
            }
            else
            {
              MessageBox.Show("Ошибка соединения", "Соединение с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }
        }
      }

      return bReadDB;
    }

    public string GetFullPathNode() {
      return this.treeView1.SelectedNode.FullPath;
    }
    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
     
      this.LstViewEvent.Items.Clear();
      TreeView tree = (TreeView)sender;
      __sel_node = (UNode)tree.SelectedNode;

      if (__sel_node.IsView)
      {
        this.usrFesStatistics1.Visible = false;
        this.LstViewItm.Visible = true;
        tsResView.Visible = true;
        ulcMeterTreeView.Visible = true;
        this.tsComboBoxDev.Enabled = true;
        //this.tsResView.Visible = false;
        e.Node.SelectedImageIndex = 18;
        if (__lvItemChecked == null)
          __lvItemChecked = new List<ListViewItem>();
        this.__lvItemChecked.Clear();
        this.tsDwnUpdate.Enabled = false;
        this.ctxMenuItemAdd.Enabled = true;
        DateTime dtn = DateTime.Now;
        DateTime dt = new DateTime(dtn.Year, dtn.Month, dtn.Day, 0, 0, 0);
        this.LstViewItm.Visible = false;
        this.LstViewItm.Items.Clear();
        __db.ViewRes(this.LstViewItm, __sel_node.Id, dt, (EnumViewDevType)this.tsComboBoxDev.SelectedIndex,__sel_node.Text);
        this.ulcMeterTreeView.SetValue(__db.__connection, __sel_node.Id);
        __its_parent = (from ListViewItem item in this.LstViewItm.Items select (ListViewItem)item.Clone()).ToArray();
        this.tsFilterText.Text = "";
        this.tsMnuTreeAddItem.Enabled = false;
        this.tsTreeBtnAdd.Enabled = false;
        if (this.LstViewItm.Items.Count == 0)
        {
          //this.tsResView.Visible = false;
          //this.tsLblFind.Visible = false;
          ////this.__tsAutoCompleteCmb.Visible = false;
          //this.tsStsLabelAll.Visible = false;
          //this.tsStsLblNotTrue.Visible = false;
          //this.tsStsNetBad.Visible = false;
          //this.tsStsRssBad.Visible = false;
          //this.tsStsIMEI.Visible = false;
          //this.tsStatusLbl.Visible = false;

        }
        else
        {
          //this.tsResView.Visible = true;
          //this.tsLblFind.Visible = true;
          //this.__tsAutoCompleteCmb.Visible = true;
          this.tsStsLabelAll.Visible = true;
          this.tsStsLblNotTrue.Visible = true;
          this.tsStsNetBad.Visible = true;
          this.tsStsRssBad.Visible = true;
          this.tsStsIMEI.Visible = true;
          this.tsStatusLbl.Visible = true;
          //this.__list_objects.Clear();
          //this.tsResView.Visible = true;
          //__autoCompleteCmb.Items.Clear();
          //this.__autoCompleteCmb.Text = "";
          ReinitFind();

        }

        this.treeMenu.Items[0].Enabled = false;
        this.tsTreeBtnAddRoot.Enabled = false;
        this.tsTreeBtnAdd.Enabled = false;

      }
      else
      {
        this.LstViewItm.Visible = false;
        tsResView.Visible = false;
        ulcMeterTreeView.Visible = false;
        //this.tsLblFind.Visible = false;
       
        //this.__tsAutoCompleteCmb.Visible = false;
        this.treeMenu.Items[0].Enabled = true;
        this.tsTreeBtnAddRoot.Enabled = true;
        this.ctxMenuItemAdd.Enabled = false;
        this.tsSelectShow.Enabled = false;
        this.tsUpdate.Enabled = false;
        this.tsMnuTreeAddItem.Enabled = true;
        e.Node.SelectedImageIndex = 17;
        //this.tsComboBoxDev.Enabled = false;
        this.tsStsLabelAll.Visible = false;
        this.tsStsLblNotTrue.Visible = false;
        this.tsStsNetBad.Visible = false;
        this.tsStsRssBad.Visible = false;
        this.tsStsIMEI.Visible = false;
        this.tsTreeBtnAdd.Enabled = true;
        this.tsStatusLbl.Visible = false;
        //this.tsResView.Visible = false;
        List<StatisticRes> lst = null;
        
        using (SimpleWaitForm swf = new SimpleWaitForm())
        {

          swf.RunAction(new Action(() =>
          {
            try
            {
              swf.SetHeaderText("Запрос данных");
              swf.SetLabelText(__sel_node.Text);
              lst = this.__db.GetStatisticFes(__sel_node);
              swf.DialogResult = DialogResult.OK;
            }
            catch
            {
              lst = null;
              swf.DialogResult = DialogResult.Abort;
            }
          }));

          swf.ShowDialog();
          if (lst.Count > 0)
          {
            this.usrFesStatistics1.Value = lst;
#if STAT
            this.usrFesStatistics1.Visible = true;
#endif
          }
          else {
            this.usrFesStatistics1.Visible = false;
          }
        }

      }

      //this.tsStatusLbl.Visible = true;
      if (this.tabItemsControl.SelectedIndex == 0)
      {
        ReadStatusListView();
      }
      else {
        ulcMeterTreeView.RecalcStatusLebel();
      }

      //this.splitContainer2.Panel2Collapsed = false;
      //splitContainer2.Panel2.Show();
    }

    void ReinitFind()
    {
      __list_objects = new List<ListObj>();
      //if (__list_objects != null)
      //{
        __tsAutoCompleteCmb.ReInit();
        for (int i = 0; i < this.LstViewItm.Items.Count; i++)
        {
          this.__list_objects.Add(new ListObj() { Name = this.LstViewItm.Items[i].SubItems[1].Text, Row = i });
        }
        __list_objects.ForEach(i => { __tsAutoCompleteCmb.Items.Add(i); });
      //}
    }



    public TcpClient GetConnection(string host, int port)
    {
      TcpClient client = new TcpClient();
      IAsyncResult result = client.BeginConnect(host, port, (i) =>
      {
        if (client.Client != null)
        {
          if (!client.Connected)
          {
            client = null;
          }
        }
      }, null);
      bool state = result.AsyncWaitHandle.WaitOne(10000);
      if (!state)
        return null;
      else return client;
    }

    public bool GetConfigIP(TcpClient client, out string message)
    {
      bool isMsg = false;
      message = string.Empty;
      try
      {
        byte[] buffer = new byte[1024];
        NetworkStream stream = client.GetStream();
        stream.ReadTimeout = 10000;
        byte[] bRng = System.Text.ASCIIEncoding.ASCII.GetBytes("CONFIG?\r");

        for (int i = 0; i < 2; i++)
        {
          try
          {
            stream.Write(bRng, 0, bRng.Length);
            Thread.Sleep(10);

            int size = stream.Read(buffer, 0, buffer.Length);

            message = System.Text.ASCIIEncoding.ASCII.GetString(buffer, 0, size);
            if (!string.IsNullOrEmpty(message))
            {
              if (message.StartsWith("CONFIG") && message[message.Length - 1] == '\n')
              {
                isMsg = true;
                break;
              }
            }

          }
          catch
          {
            return false;
          }
        }
        return isMsg;
      }
      catch
      {
        return false;
      }
    }

    public static bool PingHost(string nameOrAddress)
    {
      bool pingable = false;
      Ping pinger = null;

      try
      {
        pinger = new Ping();
        PingReply reply = pinger.Send(nameOrAddress);
        pingable = reply.Status == IPStatus.Success;
      }
      catch (PingException)
      {

      }
      finally
      {
        if (pinger != null)
        {
          pinger.Dispose();
        }
      }
      return pingable;
    }
    void SetPingResult(ItemCallBack pitem, bool result)
    {
      foreach (ListViewItem item in this.LstViewItm.Items)
      {
        ItemIp it = (ItemIp)item.Tag;
        if (it.Id == pitem.ItmIp.Id)
        {
          item.SubItems[10].Text = result == true ? "ok" : "error";
        }
      }
    }
    public void PingAllControllers()
    {
      __lstTaskUpdate = new List<Task>();
      __lstTaskRunner = new List<Task>();

      foreach (ItemCallBack item in __lip)
      {
        Task tsk = new Task(new Action<object>((oItem) =>
        {
          ItemCallBack ositem = (ItemCallBack)oItem;
          ItemIp itip = ositem.ItmIp;
          try
          {
            bool result = PingHost(itip.Ip);
            if (result)
            {
              __frm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, true, itip.UType, 4);


            }
            else
            {
              __frm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, itip.UType, 5);
            }
            this.BeginInvoke(new PingDelegate(SetPingResult), ositem, result);
          }
          catch
          {
            __frm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, itip.UType, 1);
          }
          finally
          {
            ositem.runOff(ositem.TaskOwn);
          }
        }), item);
        item.TaskOwn = tsk;
        item.runOff = this.CallBackTaskEnd;
        __lstTaskUpdate.Add(tsk);
        __count_update = 0;
      }
      var iner = Task.Factory.StartNew(() =>
      {
        for (int i = 0; i < __lstTaskUpdate.Count; i++)
        {
          while (true)
          {
            if (this.__lstTaskRunner.Count < 50)
            {
              this.__lstTaskRunner.Add(__lstTaskUpdate[i]);
              __lstTaskUpdate[i].Start();
              break;
            }
            Thread.Sleep(100);
          }

        }
        while (this.__lstTaskRunner.Count != 0)
        {
          Thread.Sleep(100);
        }
        this.__frm.BeginInvoke(new Action(() =>
        {
          __frm.CompleetWork(true);
        }));
      });
    }

    private void tsPingMenuItem_Click(object sender, EventArgs e)
    {
      if (__lip == null)
        __lip = new List<ItemCallBack>();
      else
        __lip.Clear();
      foreach (ListViewItem item in this.LstViewItm.Items)
      {
        //ItemIp li = (ItemIp)item.Tag;
        ItemCallBack li = new ItemCallBack(item);
        __lip.Add(li);
      }
      DialogResult result = ReadParam(PingAllControllers, StateWaitForm.StateOverSimple);
    }

    List<Task> __lstTaskUpdate;
    List<Task> __lstTaskRunner;
    int __count_update = 0;
    void CallBackTaskEnd(Task task)
    {

      lock (this.__lstTaskRunner)
      {
        bool rm = this.__lstTaskRunner.Remove(task);
        if (__frm != null)
        {
          int ct = __lstTaskUpdate.Count;
          __count_update++;
          double pst = (__count_update * 100) / ct;
          if (pst == 0)
            __frm.ChangePercent(1);
          else
            __frm.ChangePercent(Math.Abs(pst));
        }
      }
    }



    public void ReadStateUlcs(/*List<ItemIp> iptems*/)
    {
      __lstTaskUpdate = new List<Task>();
      __lstTaskRunner = new List<Task>();
      string node_full_path = string.Empty;
      IAsyncResult res = this.BeginInvoke(new Action(() =>
      {
        node_full_path = this.treeView1.SelectedNode.FullPath;
      }));
      res.AsyncWaitHandle.WaitOne();
      foreach (ItemCallBack item in __lip)
      {
        Task tsk = new Task(new Action<object>((oItem) =>
        {
          ItemCallBack ositem = (ItemCallBack)oItem;
          ItemIp itip = ositem.ItmIp;
          TcpClient client = null;
          try
          {

            client = GetTcpConnection(itip.Ip, __selected_device_type);
            //client = this.GetConnection(itip.Ip, 10251);//new TcpClient(item.IP, 10251);
            if (client == null)
              throw new Exception(string.Format("Error connect to:{0}", itip.Ip));
            if (itip.UType == 0)
            {
              client.Close();
              Thread.Sleep(1000);
              client = this.GetConnection(itip.Ip, 10251);
              if (client == null)
                throw new Exception(string.Format("Error connect to:{0}", itip.Ip));
            }
            string msg = string.Empty;
            bool result = false;
            result = this.GetConfigIP(client, out msg);
            if (result)
            {
              itip.MsgConfig = new DataMsg()
              {
                Date = DateTime.Now,
                Message = msg
              };
              itip.IsTrue = true;
              //if (__db.CheckCurrentRecord(itip.Id, DateTime.Now, msg,itip.UType))
              //{
              __frm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, true, itip.UType, 0);
              //}
              //else
              //{
              //__frm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, itip.UType, 3);
              //}
            }
            else
            {
              itip.IsTrue = false;
              __frm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, itip.UType, 2);
            }
            if (client != null)
            {
              client.Close();
            }
          }
          catch
          {
            __frm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, itip.UType, 1);
            //__db.CheckCurrentRecord(itip.Id, DateTime.Now, "");
            itip.IsTrue = false;
          }
          finally
          {
            if (client != null)
              client.Close();
            ositem.runOff(ositem.TaskOwn);
          }
        }), item);
        item.TaskOwn = tsk;
        item.runOff = this.CallBackTaskEnd;
        __lstTaskUpdate.Add(tsk);
        __count_update = 0;
        if (__frm.__complite_work)
          break;
      }
      var iner = Task.Factory.StartNew(() =>
      {
        for (int i = 0; i < __lstTaskUpdate.Count; i++)
        {

          while (true)
          {
            if (this.__lstTaskRunner.Count < 100)
            {
              if (__frm.__complite_work)
                break;
              this.__lstTaskRunner.Add(__lstTaskUpdate[i]);
              __lstTaskUpdate[i].Start();
              break;
            }

            Thread.Sleep(100);
          }
          if (__frm.__complite_work)
            break;
        }
        if (__frm.__complite_work)
          return;
        while (this.__lstTaskRunner.Count != 0)
        {
          Thread.Sleep(100);

        }
        __db.InsertArrayRecordInDb(__lip, node_full_path);
        try
        {
          this.__frm.BeginInvoke(new Action(() =>
          {
            __frm.CompleetWork(true);
          }));
        }
        catch (Exception)
        {
        }
      });
    }

    private DialogResult ReadParam(Action function, StateWaitForm stateWaitForm, string lbtext)
    {

      using (__frm = new UlcWin.win.WaitForm(function, stateWaitForm))
      {
        __frm.WorkText = lbtext;
        if (stateWaitForm == StateWaitForm.StateOverSimple)
          __frm.progressBar.Style = ProgressBarStyle.Continuous;
        else
          __frm.progressBar.Style = ProgressBarStyle.Marquee;
        return __frm.ShowDialog(this);
      }
    }

    private DialogResult ReadParam(Action function, StateWaitForm stateWaitForm)
    {
      using (__frm = new UlcWin.win.WaitForm(function, stateWaitForm))
      {
        if (stateWaitForm == StateWaitForm.StateOverSimple)
          __frm.progressBar.Style = ProgressBarStyle.Continuous;
        else
          __frm.progressBar.Style = ProgressBarStyle.Marquee;
        return __frm.ShowDialog(this);
      }
    }


    public void ReadEvent()
    {
      DateTime dt_from = this.__dtp_from.Value;
      DateTime dt_to = this.__dtp_to.Value.AddDays(1);
      var si = this.LstViewItm.SelectedItems;
      ItemIp iip = (ItemIp)si[0].Tag;
      if (iip.UType == 1)
      {
        this.LstViewEvent.Groups.Clear();
        this.LstViewEvent.Items.Clear();
        Dictionary<DateTime, List<UlcEvent>> lst_ev = null;
        SimpleWaitForm siform = new SimpleWaitForm();
        this.LstViewEvent.Items.Clear();
        siform.RunAction(new Action(() =>
        {
          lst_ev = __db.DbReadEvent(iip.Id, dt_from,dt_to);
          if (lst_ev != null)
          {
            this.BeginInvoke(new Action(() =>
            {
              this.LstViewEvent.Visible = true;
            }));

            List<ListViewItem> lstItems = new List<ListViewItem>();
            List<UlcEvent> ulcEvents = new List<UlcEvent>();
            foreach (var item in lst_ev)
            {
              foreach (var itm in item.Value)
              {
                ulcEvents.Add(itm);
              }
            }
            List<UlcEvent> ulcEvtSort = ulcEvents.OrderBy(x => x.Date).ToList();
            foreach (var it in ulcEvtSort)
            {
              var itev = new ListViewItem(new string[] { it.Date.ToString("dd.MM.yyyy HH:mm:ss"), Log.ParceLevel(it.EventLevel), it.Msg });//, lg);
              switch (it.EventLevel)
              {
                case EnumLogs.LOG_LVL.logDEBUG:
                  itev.ImageIndex = 3;
                  break;
                case EnumLogs.LOG_LVL.logINFO:
                  itev.ImageIndex = 10;
                  break;
                case EnumLogs.LOG_LVL.logWARNING:
                  itev.ImageIndex = 4;
                  break;
                case EnumLogs.LOG_LVL.logERROR:
                  itev.ImageIndex = 6;
                  break;
                case EnumLogs.LOG_LVL.logFATAL:
                  itev.ImageIndex = 5;
                  break;
                default:
                  itev.ImageIndex = 0;
                  break;
              }
              lstItems.Add(itev);
            }
            this.BeginInvoke(new Action(() =>
            {
              this.LstViewEvent.Items.AddRange(lstItems.ToArray());
            }));
          }
          else
          {
            this.BeginInvoke(new Action(() =>
            {
              this.LstViewEvent.Visible = false;
              this.lblNotExist.Text = "Нет сообщений";
            }));
          }
          siform.DialogResult = DialogResult.OK;
        }));
        siform.ShowDialog();
      }
    }

    private void NotTrueMenuClick(object sender, EventArgs e)
    {
      if (__lip == null)
        __lip = new List<ItemCallBack>();
      else
        __lip.Clear();
      foreach (ListViewItem item in this.LstViewItm.Items)
      {
        //ItemCallBack li = (ItemCallBack)item.Tag;
        ItemCallBack li = new ItemCallBack(item);
        if (!li.ItmIp.IsTrue)
        {
          __lip.Add(li);
        }
        //System.Diagnostics.Debug.WriteLine(item.ImageIndex);
      }

      DialogResult result = ReadParam(ReadStateUlcs, StateWaitForm.StateOverSimple);
      this.LstViewItm.Items.Clear();
      __db.ViewRes(this.LstViewItm, __sel_node.Id, DateTime.Now,
        (EnumViewDevType)this.tsComboBoxDev.SelectedIndex, __sel_node.Text);
      //this.tsLblAll.Text = "Всего:" + __db.__num.ToString();
      //this.tsLblNotTrue.Text = "Ошибки:" + __db.__notTrue.ToString();

      //ReadParam(TrySelectedItemUpdate,StateWaitForm.StateOverSimple);
      ReadStatusListView();
    }




    public void TrySelectedItemUpdate()
    {

      //ListView.SelectedListViewItemCollection si = null;
      //ItemIp iip = null;
      //IWin32Window parent = null;
      //this.Invoke(new Action(() =>
      //{
      //  si = this.LstViewItm.SelectedItems;
      //  iip = (ItemIp)si[0].Tag;
      //  //__frm.progressBar.Style = ProgressBarStyle.Blocks;
      //  __frm.ChangeLabelText(string.Format(string.Format("Открытие канала:{0} -{1}",
      //    iip.Name, iip.Ip)));
      //  parent = this;
      //}));
      //TcpClient client = null;
      //try
      //{
      //  client = GetConnection(iip.Ip, 10251);//new TcpClient(iip.Ip, 10251);
      //  if (client == null)
      //  {
      //    throw new Exception("Ошибка открытия соединения");
      //  }
      //  __frm.ChangeLabelText(string.Format("Запрос данных:{0} - {1}", iip.Name, iip.Ip));
      //  string msg;
      //  bool res = GetConfigIP(client, out msg);

      //  if (res)
      //  {
      //    UlcCfg uc = new UlcCfg();
      //    uc.GetExtarctRvpConfig(msg);
      //    this.Invoke(new Action(() =>
      //    {
      //      int signal = ((-113 + (uc.SIGNAL * 2)));
      //      si[0].SubItems[0].Text = DateTime.Now.ToString("dd.MM.yy");
      //      si[0].ImageIndex = signal <= -100 ? 10 : 0;
      //      if (!string.IsNullOrEmpty(uc.SVERS))
      //      {
      //        if (iip.UType == 1)
      //        {
      //          if (!uc.SVERS.StartsWith("1.7.9"))
      //          {
      //            si[0].UseItemStyleForSubItems = false;
      //            si[0].SubItems[5].ForeColor = Color.Red;
      //          }
      //          else
      //          {
      //            si[0].UseItemStyleForSubItems = false;
      //          }
      //        }
      //      }
      //      si[0].SubItems[5].Text = uc.SVERS;
      //      //si[0].SubItems[6].Text = signal.ToString() + " dBm";
      //      ListViewItem.ListViewSubItem sit = si[0].SubItems[6];
      //      sit.Text = signal.ToString() + " dBm";
      //      if (signal <= -100)
      //      {
      //        si[0].UseItemStyleForSubItems = false;
      //        sit.ForeColor = Color.Red;
      //        si[0].ImageIndex = 10;
      //      }
      //      else
      //      {
      //        si[0].UseItemStyleForSubItems = true;
      //      }
      //      DateTime? dtr = ParceLog.rtc_calendar_time_to_register_value(uc.FMW);
      //      si[0].SubItems[7].Text = dtr != null ? ((DateTime)dtr).ToString("dd-MM-yyyy HH:mm:ss") : "----";
      //      string lvl = Log.ParceLevel(uc.LOGSLVL);
      //      if (iip.UType == 1)
      //      {
      //        si[0].SubItems[8].Text = lvl;
      //      }
      //      else
      //      {
      //        si[0].SubItems[8].Text = "нет";
      //      }

      //      string it_core = "----";
      //      if (!string.IsNullOrEmpty(uc.CORV))
      //      {
      //        string core = uc.CORV.Replace("\r\n", string.Empty);

      //        if (!core.Contains("12.01.830-B006"))
      //        {

      //          it_core = "патч";
      //        }
      //        else
      //        {
      //          it_core = "ok";
      //        }
      //      }
      //      si[0].SubItems[9].Text = it_core;
      //      if (!string.IsNullOrEmpty(uc.IMEI))
      //        si[0].SubItems[11].Text = uc.IMEI.Substring(uc.IMEI.Length - 7, uc.IMEI.Length - 8);
      //      else
      //        si[0].SubItems[11].Text = "----";

      //      si[0].SubItems[13].Text = uc.RAS.ToString();
      //      if (iip.UType == 1)
      //      {
      //        si[0].SubItems[13].Text=((uc.CDIN >> 7).ToString());
      //      }
      //      else
      //      {
      //        si[0].SubItems[13].Text="нет";
      //      }
      //    }));
      //    __db.CheckCurrentRecord(iip.Id, DateTime.Now, msg);
      //  }
      //  else
      //  {
      //    __frm.ChangeLabelText(string.Format("Ошибка получения данных {0}", iip.Ip));
      //    throw new Exception(string.Format("Ошибка получения данных {0}", iip.Ip));
      //  }

      //}
      //catch (Exception exp)
      //{
      //  __db.CheckCurrentRecord(iip.Id, DateTime.Now, "");
      //  MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //  this.Invoke(new Action(() => {
      //    //this.tsUpdate_Click(null, null);
      //  }));


      //}
      //finally
      //{
      //  if (client != null)
      //  {
      //    if (client.Connected)
      //      client.Close();
      //  }
      //}
    }

    void UpdateItemRow(ListViewItem selItem, string msg)
    {
      selItem.UseItemStyleForSubItems = true;
      foreach (ListViewItem.ListViewSubItem item in selItem.SubItems)
      {
        item.ForeColor = Color.Black;
      }
      UlcCfg uc = new UlcCfg();
      ItemIp sItem = (ItemIp)selItem.Tag;
      uc.GetExtarctRvpConfig(msg);
      int signal = ((-113 + (uc.SIGNAL * 2)));
      DateTime? ss = ParceLog.rtc_calendar_time_to_register_value(uc.DT);
      selItem.SubItems[0].Text = ss != null ? ss.Value.ToString("dd.MM.yy HH:mm:ss") : DateTime.MinValue.ToString("dd.MM.yy HH:mm:ss");
      selItem.ImageIndex = signal <= -100 ? 10 : 0;
      if (!string.IsNullOrEmpty(uc.SVERS))
      {
        if (sItem.UType == 1)
        {
          if (!uc.SVERS.StartsWith("1.7.9"))
          {
            selItem.UseItemStyleForSubItems = false;
            selItem.SubItems[6].ForeColor = Color.Red;
          }
          else
          {
            //selItem.UseItemStyleForSubItems = true;
          }
        }
      }
      selItem.SubItems[6].Text = uc.SVERS;
      //si[0].SubItems[6].Text = signal.ToString() + " dBm";
      ListViewItem.ListViewSubItem sit = selItem.SubItems[7];
      sit.Text = signal.ToString() + " dBm";
      if (signal <= -100)
      {
        selItem.UseItemStyleForSubItems = false;
        sit.ForeColor = Color.Red;
        selItem.ImageIndex = 10;
      }
      else
      {
        //selItem.UseItemStyleForSubItems = true;
      }
      DateTime? dtr = ParceLog.rtc_calendar_time_to_register_value(uc.FMW);
      selItem.SubItems[8].Text = dtr != null ? ((DateTime)dtr).ToString("dd-MM-yyyy HH:mm:ss") : "----";
      string lvl = Log.ParceLevel(uc.LOGSLVL);
      if (sItem.UType == 1)
      {
        selItem.SubItems[9].Text = lvl;
      }
      else
      {
        selItem.SubItems[9].Text = "нет";
      }

      string it_core = "----";
      if (!string.IsNullOrEmpty(uc.CORV))
      {
        string core = uc.CORV.Replace("\r\n", string.Empty);

        if (!core.Equals("12.01.830-B006"))
        {

          it_core = "патч";
        }
        else
        {
          it_core = "ok";
        }
      }
      selItem.SubItems[10].Text = it_core;
      if (!string.IsNullOrEmpty(uc.IMEI))
        selItem.SubItems[11].Text = uc.IMEI.Substring(uc.IMEI.Length - 7, uc.IMEI.Length - 8);
      else
        selItem.SubItems[11].Text = "----";

      selItem.SubItems[12].Text = uc.RAS.ToString();
      if (sItem.UType == 1)
      {
        selItem.SubItems[13].Text = ((uc.CDIN >> 7).ToString());
      }
      else
      {
        selItem.SubItems[14].Text = "нет";
      }
      selItem.SubItems[14].Text = (((double)(uc.TRAFC / 1024)).ToString() + " KB");
    }

    ListViewItem GetSelectedRow()
    {
      ListViewItem item = null;
      IAsyncResult result = this.LstViewItm.BeginInvoke(new Action(() =>
      {
        if (this.LstViewItm.SelectedItems.Count > 0)
          item = this.LstViewItm.SelectedItems[0];
      }));
      result.AsyncWaitHandle.WaitOne();
      return item;
    }
    public delegate void UpdateItemDelegate(ListViewItem selItem, string message);
    private void CurrentMenuClick(object sender, EventArgs e)
    {
      string node_full_path = this.treeView1.SelectedNode.FullPath;
      //ListViewItem selItem = this.LstViewItm.SelectedItems[0];
      //string message = string.Empty;
      using (SimpleWaitForm sfrm = new SimpleWaitForm())
      {

        sfrm.RunAction(new Action(() =>
        {

          ListViewItem selItem = GetSelectedRow();
          sfrm.SetLabelText(string.Format("Соединяюсь с {0}", selItem.SubItems[1].Text));
          TcpClient client = null;
          try
          {
            ItemIp sItem = (ItemIp)selItem.Tag;

            client = GetConnection(sItem.Ip, 10251);//new TcpClient(iip.Ip, 10251);
            if (client == null)
            {
              throw new Exception("Ошибка открытия соединения");
            }
            sfrm.SetLabelText(string.Format("Запрос данных:{0} - {1}", selItem.Name, sItem.Ip));
            string msg;
            bool res = GetConfigIP(client, out msg);

            if (res)
            {
              IAsyncResult result = null;
              result = this.LstViewItm.BeginInvoke(new UpdateItemDelegate(UpdateItemRow), selItem, msg);
              result.AsyncWaitHandle.WaitOne();

              __db.InsertCurrentRecord(sItem.Id, DateTime.Now, msg, sItem.UType, node_full_path, sItem.Name);
            }
            else
            {
              throw new Exception(string.Format("Ошибка получения данных {0}", sItem.Ip));
            }
            sfrm.SetLabelText("Данные обновлены успешно");
          }
          catch (Exception exp)
          {
            sfrm.SetLabelText("Ошибка обновления данных");
            Thread.Sleep(3000);
            sfrm.DialogResult = DialogResult.None;
          }
          finally
          {
            if (client != null)
            {
              if (client.Connected)
                client.Close();
            }
          }
          Thread.Sleep(200);
          sfrm.DialogResult = DialogResult.Cancel;
        }));
        sfrm.ShowDialog();
        ReadStatusListView();
      }
    }

    void ReadStatusListView()
    {
     
      int all = 0;
      int notTrue = 0;
      int netBad = 0;
      int rsBad = 0;
      int part_OneOrTwo = 0;
      int part_TreeOrFour = 0;
      int part_Five = 0;
      foreach (ListViewItem item in this.LstViewItm.Items)
      {
        ItemIp it = (ItemIp)item.Tag;
        ++all;
        if (item.ImageIndex == 4 || item.ImageIndex == 15 || item.ImageIndex == 21)
        {
          if (it.Active == 1)
            ++notTrue;
        }

        string[] sig = item.SubItems[7].Text.Split(' ');
        if (sig.Length > 0)
        {
          int n = 0;
          bool res = int.TryParse(sig[0], out n);
          if (res)
          {
            if (n < -100)
              ++netBad;
          }
        }
        if (it.UType == 1)
        {
          this.tsStsRssBad.Visible = true;
          this.tsStsIMEI.Visible = true;
          int num;
          bool rs = int.TryParse(item.SubItems[13].Text, out num);
          if (rs)
          {

            if (num == 0)
              if (item.ImageIndex != 21)
              {
                rsBad++;
              }
          }
          string imai = item.SubItems[11].Text;
          if (!string.IsNullOrEmpty(imai))
          {
            long im_num;
            if (long.TryParse(imai, out im_num))
            {
              if (im_num < 1290000)
              {
                part_OneOrTwo++;
              }
              if (im_num > 1290000 && im_num < 2000000)
              {
                part_TreeOrFour++;
              }
              if (im_num > 2000000)
              {
                part_Five++;
              }
            }
          }
        }
        else
        {
          this.tsStsRssBad.Visible = false;
          this.tsStsIMEI.Visible = false;
        }
      }
      this.tsStsLabelAll.Text = "Всего:" + all.ToString();
      this.tsStsLblNotTrue.Text = "Ошибка соединения:" + notTrue.ToString();
      this.tsStsNetBad.Text = "Неусточивая связь:" + netBad.ToString();
      this.tsStsRssBad.Text = "Нет связи по RS-485:" + rsBad;
      this.tsStsIMEI.Text = string.Format("Партия: 1-2({0}), 3-4({1}),5-({2}) ", part_OneOrTwo.ToString(), part_TreeOrFour.ToString(), part_Five.ToString());

    }

    private void toolStripButton2_Click(object sender, EventArgs e)
    {
      ReadEvent();
    }

    private void toolStripUpdate_Click(object sender, EventArgs e)
    {
      this.LstViewItm.Items.Clear();
      __db.ViewRes(this.LstViewItm, __sel_node.Id, DateTime.Now,
        (EnumViewDevType)this.tsComboBoxDev.SelectedIndex,
        __sel_node.Text);
    }

    private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.LstViewItm.Items.Clear();
      __db.ViewRes(this.LstViewItm, __sel_node.Id, DateTime.Now,
        (EnumViewDevType)this.tsComboBoxDev.SelectedIndex,
        __sel_node.Text);
    }

    private void showNotTrueToolStripMenuItem_Click(object sender, EventArgs e)
    {
      List<ListViewItem> lst = new List<ListViewItem>();
      foreach (ListViewItem item in this.LstViewItm.Items)
      {
        ItemIp iip = (ItemIp)item.Tag;
        if (!iip.IsTrue)
        {
          lst.Add(item);
        }
      }
      this.LstViewItm.Items.Clear();
      this.LstViewItm.Items.AddRange(lst.ToArray()); ;
    }

    private void ToolStripMenuItemEvent_Click(object sender, EventArgs e)
    {
      ReadEvent();
    }

    private void toolStripMenuItemNetLow_Click(object sender, EventArgs e)
    {
      List<ListViewItem> lst = new List<ListViewItem>();
      foreach (ListViewItem item in this.LstViewItm.Items)
      {
        //ItemIp iip = (ItemIp)item.Tag;
        if (item.ImageIndex == 15 || item.ImageIndex == 21)
        {
          lst.Add(item);
        }
      }
      this.LstViewItm.Items.Clear();
      this.LstViewItm.Items.AddRange(lst.ToArray()); ;
    }

    int CheckForPresentRecord(string ip, string name)
    {
      int index = -1;
      if (this.LstViewItm.Items.Count > 0)
      {
        foreach (ListViewItem item in this.LstViewItm.Items)
        {
          index++;
          ItemIp itTag = (ItemIp)item.Tag;
          if (itTag.Ip == ip /*&& itTag.Name == name*/)
            return index;
        }
        return -1;
      }
      else
      {
        return -1;
      }
    }

    private void tsMenuItChange_Click(object sender, EventArgs e)
    {
      if (this.LstViewItm.SelectedItems.Count != 0)
      {
        UNode uNode = (UNode)this.treeView1.SelectedNode;
        ItemIp iip = (ItemIp)this.LstViewItm.SelectedItems[0].Tag;
        using (Editor ed = new Editor(this.__db, true, iip))
        {
          ed.Text = "Изменение записи";
          //ed.txtBoxName.Text = iip.Name;
          //ed.txtBoxIp.Text = iip.Ip;
          //ed.txtBoxPhone.Text = iip.Phone;
          ed.cbType.SelectedIndex = iip.UType;
          ed.cbFunction.SelectedIndex = iip.IsLight;
          ed.chBoxActive.Checked = iip.Active == 0 ? false : true;
          ed.chBoxStat.Checked = iip.Rs_Stat == 0 ? false : true;
          ed.txtBoxComment.Text = iip.Comments;
          ed.txtBoxIpAddress.Text = iip.Ip;
          ed.txtBoxPhones.Text = iip.Phone;
          string[] arrName = iip.Name.Split(',');
          if (arrName.Length > 0)
            ed.txtBoxState.Text = arrName[0].Trim();
          if (arrName.Length > 1)
            ed.txtBoxCity.Text = arrName[1].Trim();
          if (arrName.Length > 2)
            ed.txtBoxZtp.Text = arrName[2].Trim();
          DialogResult result = ed.ShowDialog();
          if (result == DialogResult.OK)
          {
            string msgMeter = string.Empty;
            string name = RemChar(ed.txtBoxState.Text) + " ," + RemChar(ed.txtBoxCity.Text) + " ," + RemChar(ed.txtBoxZtp.Text);
            //List<Meters> lmt = new List<Meters>();
            //foreach (ListViewItem eIt in ed.lstMeter.Items)
            //{
            //  lmt.Add(new Meters() { meter_type = eIt.Text, meter_factory = eIt.SubItems[1].Text });
            //}
            //msgMeter = System.Text.Json.JsonSerializer.Serialize(lmt.ToArray(), typeof(Meters[]), DbLogMsg.GetSerializeOption());
            __db.EditResRecord(
              new DbItemEditor()
              {
                Comment = ed.txtBoxComment.Text,
                Id = iip.Id,
                Ip = ed.txtBoxIpAddress.Text,
                Name = name,
                Phone = ed.txtBoxPhones.Text,
                IsActive = ed.chBoxActive.Checked == true ? 1 : 0,
                IsLight = ed.cbFunction.SelectedIndex,
                UType = ed.cbType.SelectedIndex == 0 ? 0 : 1, 
                rs_stat=ed.chBoxStat.Checked==true? 1:0
                 
              }, this.treeView1.SelectedNode.FullPath, msgMeter, ((UNode)this.treeView1.SelectedNode).Id);
            foreach (var item in ed.__meterInfos)
            {
              item.ctrl_id = iip.Id;
              item.parent_id = uNode.Id;
            }
            __db.SetCrudMeterInfo(ed.__meterInfos);
            this.tsUpdate_Click(null, null);
          }
        }
      }
    }

    private void tsUpdate_Click(object sender, EventArgs e)
    {
      this.LstViewItm.Items.Clear();
      __db.ViewRes(this.LstViewItm, __sel_node.Id, DateTime.Now,
        (EnumViewDevType)this.tsComboBoxDev.SelectedIndex,
        __sel_node.Text);
      //this.tsLblAll.Text = "Всего:" + __db.__num.ToString();
      //this.tsLblNotTrue.Text = "Ошибки:" + __db.__notTrue.ToString();
    }

    private void TsMenuItemDelete_Click(object sender, EventArgs e)
    {
      ItemIp itm = (ItemIp)this.LstViewItm.SelectedItems[0].Tag;
      DialogResult result = MessageBox.Show("Удалить контроллер из базы данных?", "Удаление записи",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (result == DialogResult.Yes)
      {
        //string msg=System.Text.Json.JsonSerializer.Serialize(itm, typeof(ItemIp), __db.GetJsonOption());
        int res = __db.DeleteResRecord(itm.Id, itm.Name, EnLogEvt.DELETE_ITEM, this.treeView1.SelectedNode.FullPath);
        if (res == 1)
        {
          this.tsUpdate_Click(null, null);
          MessageBox.Show("Запись удалена успешно", "Удаление записи", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
        }
        else
        {
          MessageBox.Show("Ошибка удаления записи", "Удаление записи", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
        }
      }


    }

    private void tsUpdateItemCurrent_Click(object sender, EventArgs e)
    {
      if (__lip == null)
        __lip = new List<ItemCallBack>();
      else
        __lip.Clear();
      foreach (ListViewItem item in this.LstViewItm.Items)
      {
        //ItemIp li = (ItemIp)item.Tag;
        ItemCallBack li = new ItemCallBack(item);
        __lip.Add(li);
      }
      DialogResult result = ReadParam(ReadStateUlcs, StateWaitForm.StateOverSimple);

      this.LstViewItm.Items.Clear();
      __db.ViewRes(this.LstViewItm, __sel_node.Id, DateTime.Now,
        (EnumViewDevType)this.tsComboBoxDev.SelectedIndex,
        __sel_node.Text);
      ////this.tsLblAll.Text = "Всего:" + __db.__num.ToString();
      // this.tsLblNotTrue.Text = "Ошибки:" + __db.__notTrue.ToString();
      ReadStatusListView();
    }

    bool __panel_event_log = false;
    private void LstViewItm_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.splitContainer2.Panel2Collapsed)
      {
        this.LstViewEvent.Items.Clear();
        if (this.LstViewItm.SelectedItems.Count > 0)
        {
          var itm = this.LstViewItm.SelectedItems[0];
          ItemIp it = (ItemIp)itm.Tag;
          if (it.UType == (byte)UTypeController.RVP)
          {
            //this.LvMenu.Items["ctxMenuEvent"].Enabled = false;
            this.LvMenu.Items["ctxMenuReadCurrentLog"].Enabled = false;
            this.LstViewEvent.Visible = false;
            this.lblNotExist.Text = "Журнал сообщений не поддерживается на этом устройстве";
            it.IsUpdateInable = false;
          }
          else
          {
            //this.LvMenu.Items["tsMenuEvent"].Enabled = true;
            //this.LvMenu.Items["tsMenuReadCurrentLog"].Enabled = true;
            this.tsEvent.Enabled = true;
            this.ReadEvent();
           
            // this.tsLblMsg.Text = it.MsgConfig.Message;
          }
        }
      }
    }

    private void tsMenuReadCurrentLog_Click(object sender, EventArgs e)
    {
      if (this.LstViewItm.SelectedItems[0] != null)
      {
        ListViewItem itm = this.LstViewItm.SelectedItems[0];
        if (itm.SubItems[8].Text == "Отключено")
        {
          MessageBox.Show("Чтение лог файла не возможно. Отключена функция записи лог файла",
            "Ошибка чтения лог файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }
      Dictionary<DateTime, List<Log>> dicEvt = null;
      using (SimpleWaitForm sform = new SimpleWaitForm())
      {
        sform.Text = "Запрос журнала сообщений";
        var itm = this.LstViewItm.SelectedItems[0];
        ItemIp it = (ItemIp)itm.Tag;
        Exception outExp = null;
        List<Log> lstLog = null;

        sform.RunAction(new Action(() =>
        {
          try
          {
            sform.SetLabelText(string.Format("Соединяюсь с {0}...", it.Name));
            TcpClient client = GetConnection(it.Ip, 10251);
            if (client == null)
              throw new Exception(string.Format("Ошибка соединения:{0}-{1}", it.Name, it.Ip));
            lstLog = ParceLog.GetLogIP(client.GetStream(), out outExp);
            if (outExp != null)
            {
              if (client != null)
                client.Close();
              throw new Exception(outExp.Message);
            }
            client.Close();


            if (outExp == null)
            {
              sform.SetLabelText(string.Format("Обработка журнала сообщений:{0}-{1}", it.Name, it.Ip));
              dicEvt = new Dictionary<DateTime, List<Log>>();
              foreach (var item in lstLog)
              {
                var dtg = new DateTime(item.event_time.Year, item.event_time.Month, item.event_time.Day);
                if (!dicEvt.ContainsKey(dtg))
                {
                  dicEvt.Add(dtg, new List<Log>() { item });
                }
                else
                {
                  dicEvt[dtg].Add(item);
                }
              }
              sform.DialogResult = DialogResult.OK;
            }
            else
            {
              sform.SetLabelTextError("Журнал сообщений пуст");
              Thread.Sleep(500);
              sform.DialogResult = DialogResult.Abort;
            }

          }
          catch (Exception exp)
          {

            sform.SetLabelTextError(exp.Message);
            Thread.Sleep(500);
            sform.DialogResult = DialogResult.Abort;
            //sform.Close();
            //MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }));
        DialogResult result = sform.ShowDialog();
        if (result == DialogResult.OK)
        {
          using (EventForm evf = new EventForm())
          {
            evf.listView1.Items.Clear();
            evf.listView1.Groups.Clear();
            string dt_evtLst = "dd.MM.yy HH:mm:ss";
            string dt_evtGrp = "dd.MM.yy";
            foreach (var item in dicEvt)
            {
              var grp = evf.listView1.Groups.Add(item.Key.ToString(dt_evtGrp), item.Key.ToString("dd.MM.yy"));
              foreach (var itdata in item.Value)
              {
                ListViewItem itevt = new ListViewItem(itdata.event_time.ToString(dt_evtLst), grp);

                switch (itdata.event_level)
                {
                  case EnumLogs.LOG_LVL.logDEBUG:
                    itevt.ImageIndex = 2;
                    break;
                  case EnumLogs.LOG_LVL.logINFO:
                    itevt.ImageIndex = 0;
                    break;
                  case EnumLogs.LOG_LVL.logWARNING:
                    itevt.ImageIndex = 1;
                    break;
                  case EnumLogs.LOG_LVL.logERROR:
                    itevt.ImageIndex = 3;
                    break;
                  case EnumLogs.LOG_LVL.logFATAL:
                    itevt.ImageIndex = 3;
                    break;
                  default:
                    itevt.ImageIndex = 0;
                    break;
                }
                itevt.SubItems.Add(Log.ParceLevel((EnumLogs.LOG_LVL)itdata.event_level));
                itevt.SubItems.Add(itdata.event_msg);
                evf.listView1.Items.Add(itevt);
              }
            }
            if (evf.ShowDialog() == DialogResult.OK)
            {
              //using (SimpleWaitForm siForm = new SimpleWaitForm())
              //{
              //  siForm.RunAction(new Action(() =>
              //  {
              //    siForm.SetLabelText("Обновляю базу данных...");
              //    foreach (var item in dicEvt)
              //    {
              //      this.__db.InsertLogMsg(item.Value, it.Id);
              //    }
              //    siForm.DialogResult = DialogResult.OK;
              //  }));
              //  siForm.ShowDialog();
              //}

            }
          }
        }
        else
        {
          MessageBox.Show("Ошибка получения данных ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    string RemChar(string name)
    {

      string str = name;
      string[] charsToRemove = new string[] { "@", ",", ";", "'", "+" };
      foreach (var c in charsToRemove)
      {
        str = str.Replace(c, string.Empty);
      }
      Console.WriteLine(str);
      return str;
    }

    private void TsMenuAdd_Click(object sender, EventArgs e)
    {

      try
      {
        if (this.__sel_node != null)
        {
          if (this.__sel_node.IsView)
          {

            var cc = this.__sel_node;
            Editor ed = new Editor(this.__db, true, null);
            ed.Text = "Новая запись";
            //ed.cbType.SelectedIndex = this.tsComboBoxDev.SelectedIndex;
            DialogResult result = ed.ShowDialog();
            if (result == DialogResult.OK)
            {
              string msgMeter = string.Empty;
              string name = RemChar(ed.txtBoxState.Text) + " ," + RemChar(ed.txtBoxCity.Text) + " ," + RemChar(ed.txtBoxZtp.Text);
              int index = CheckForPresentRecord(ed.txtBoxIpAddress.Text, name);
              if (index == -1)
              {
                //List<Meters> lmt = new List<Meters>();
                //foreach (ListViewItem eIt in ed.lstMeter.Items)
                //{
                //  lmt.Add(new Meters() { meter_type = eIt.Text, meter_factory = eIt.SubItems[1].Text });
                //}
                //msgMeter = System.Text.Json.JsonSerializer.Serialize(lmt.ToArray(), typeof(Meters[]), DbLogMsg.GetSerializeOption());
                int ind = ed.cbType.SelectedIndex;
                int active = ed.chBoxActive.Checked ? 1 : 0;
                int light = ed.cbFunction.SelectedIndex;

                long idRec=__db.AddNewResRecord(name, ed.txtBoxIpAddress.Text, ed.txtBoxPhones.Text,
                  3, this.__sel_node.Id, ind == 1 ? UTypeController.ULC2 : UTypeController.RVP, active, light, ed.txtBoxComment.Text,
                  this.treeView1.SelectedNode.FullPath, msgMeter);
                if (ed.__meterInfos != null)
                {
                  foreach (var item in ed.__meterInfos)
                  {
                    item.parent_id = this.__sel_node.Id;
                    item.ctrl_id = (int)idRec;
                  }
                  __db.SetCrudMeterInfo(ed.__meterInfos);
                }
                this.tsUpdate_Click(null, null);
              }
              else
              {
                throw new Exception();
              }
            }
            else
            {
              return;
            }
          }
        }
        MessageBox.Show("Запись добавлена", "Добавление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception exp)
      {
        MessageBox.Show("Запись с таким именем и ip адресом уже есть", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    TcpClient GetTcpConnection(string ip, int index)
    {
      TcpClient client = null;
      for (int i = 0; i < 2; i++)
      {
        try
        {
          client = this.GetConnection(ip, 10251);
          if (client == null)
            break;
          if (i > 0)
            break;
          if (index == 1)
          {
            break;
          }
          else if (index == 0)
          {
            if (client != null)
              client.Close();
            Thread.Sleep(1000);

          }
        }
        catch (Exception)
        {
          break;
        }
      }
      return client;
    }

    private void LstViewItm_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      this.LstViewItm.SelectedItems[0].Checked = false;
      ItemIp selItem = (ItemIp)this.LstViewItm.SelectedItems[0].Tag;
      selItem.NodeFullPath = this.treeView1.SelectedNode.FullPath;
      string message = string.Empty;
      int index = this.tsComboBoxDev.SelectedIndex;
      using (SimpleWaitForm sfrm = new SimpleWaitForm())
      {

        sfrm.RunAction(new Action(() =>
        {
          TcpClient client = null;
          try
          {
            sfrm.SetLabelText(string.Format("Открываю соединение с {0}", selItem.Name));
            client = GetTcpConnection(selItem.Ip, index);// this.GetConnection(selItem.Ip, 10251);
            if (client == null)
            {
              throw new Exception("Ошибка соединения");
            }
            else
            {
              sfrm.SetLabelText(string.Format("Соединение успешно:{0}", selItem.Name));
            }
            if (!this.GetConfigIP(client, out message))
              throw new Exception("Ошибка получения данных");

            sfrm.DialogResult = DialogResult.OK;
          }
          catch (Exception exp)
          {
            sfrm.DialogResult = DialogResult.Cancel;

          }
          finally
          {
            if (client != null)
              client.Close();
          }
        }));
        DialogResult result = sfrm.ShowDialog();
        //sfrm.Close();
        if (result == DialogResult.OK)
        {
          using (RequestForm rqf = new RequestForm(message, this.GetConnection, false,
            tsComboBoxDev.SelectedIndex == 1 ? Ztp.Enums.Device.ULC2 : Ztp.Enums.Device.RVP,
             /*selItem.Name*/selItem, this.__db))
          {
            rqf.Text = "Настройки " + selItem.Name;
            rqf.ShowDialog();
          }
        }
        else
        {
          MessageBox.Show("Ошибка подключения данных", "Ошибка", MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        }
      }
    }

    private void toolStripButton2_Click_1(object sender, EventArgs e)
    {

      DateTime dt = __dtp_from.Value.AddDays(1);
      //if (dt > DateTime.Now)
      //return;
      this.__dtp_from.Value = dt;
      this.ReadEvent();
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      DateTime dt = __dtp_from.Value.AddDays(-1);
      this.__dtp_from.Value = dt;
      //this.ReadEvent();
    }
    
    private void LstViewItm_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      SortOrder sortOrder = SortOrder.None;
      if (this.LstViewItm.Columns[e.Column].Tag == null)
      {
        this.LstViewItm.Columns[e.Column].Tag = SortOrder.Ascending;
        sortOrder = SortOrder.Ascending;
      }
      else
      {
        sortOrder = (SortOrder)this.LstViewItm.Columns[e.Column].Tag;
        if (sortOrder == SortOrder.Ascending)
          sortOrder = SortOrder.Descending;
        else
          sortOrder = SortOrder.Ascending;
        this.LstViewItm.Columns[e.Column].Tag = sortOrder;
      }
      ListViewExtensions.SetSortIcon(this.LstViewItm, e.Column, sortOrder);
      ItemComparer sorter = this.LstViewItm.ListViewItemSorter as ItemComparer;
      if (sorter == null)
      {
        //if (this.LstViewItm.Columns[selCoumn].ImageIndex == -1)
        //  this.LstViewItm.Columns[selCoumn].ImageIndex = 11;
        sorter = new ItemComparer(e.Column);
        this.LstViewItm.ListViewItemSorter = (ItemComparer)sorter;
        return;
      }
      else
      {
        //if (this.LstViewItm.Columns[e.Column].ImageIndex == 11)
        //{
        //  this.LstViewItm.Columns[e.Column].ImageIndex = 12;
        //  sorter.Order = SortOrder.Descending;
        //}
        //else
        //{
        //  this.LstViewItm.Columns[e.Column].ImageIndex = 11;
        //  sorter.Order = SortOrder.Ascending;
        //}
        sorter.Order = sortOrder;
        sorter.Column = e.Column;
        //}
        
        if (e.Column == 3)
          sorter.UsbSorting = UlcSort.IP;
        else if (e.Column == 0)
          sorter.UsbSorting = UlcSort.DATETIME;
        else if (e.Column == 7)
        {
          sorter.UsbSorting = UlcSort.SIGNAL;
        }
        else if (e.Column == 14) {
          sorter.UsbSorting = UlcSort.TRAFFIC;
        }
        else if (e.Column == 1)
          sorter.UsbSorting = UlcSort.DEFAULT;
        else if (e.Column == 2)
          sorter.UsbSorting = UlcSort.TP;
        else if (e.Column == 13)
          sorter.UsbSorting = UlcSort.RS;
        else
          sorter.UsbSorting = UlcSort.DEFAULT;
        //selCoumn = e.Column;
      }
      this.LstViewItm.Sort();
    }


    private void LstViewItm_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      if (e.NewValue == CheckState.Checked)
        this.__lvItemChecked.Add(this.LstViewItm.Items[e.Index]);////(ItemIp)this.LstViewItm.Items[e.Index].Tag);
      else if (e.NewValue == CheckState.Unchecked)
      {
        this.__lvItemChecked.Remove(this.LstViewItm.Items[e.Index]);//(ItemIp)this.LstViewItm.Items[e.Index].Tag);
      }

    }

    private void tsATCommandMenuItem_Click(object sender, EventArgs e)
    {
      ListViewItem si = this.LstViewItm.SelectedItems[0];

      using (ATCommForm atfrm = new ATCommForm(GetConnection, (ItemIp)si.Tag))
      {

        atfrm.ShowDialog();
      }

    }



    private void tsUpdateSelectedMenuItem_Click(object sender, EventArgs e)
    {
      if (__lip == null)
        __lip = new List<ItemCallBack>();
      else
        __lip.Clear();
      foreach (ListViewItem item in this.__lvItemChecked)
      {
        ItemCallBack li = new ItemCallBack(item);

        __lip.Add(li);

      }

      DialogResult result = ReadParam(ReadStateUlcs, StateWaitForm.StateOverSimple);

      this.LstViewItm.Items.Clear();
      this.__lip.Clear();
      this.__lvItemChecked.Clear();
      __db.ViewRes(this.LstViewItm, __sel_node.Id, DateTime.Now,
        (EnumViewDevType)this.tsComboBoxDev.SelectedIndex,
        __sel_node.Text);

      ReadStatusListView();
    }

    private void tsMenuItem_Pgrm_Click(object sender, EventArgs e)
    {
      using (var fota = new Fota.FotaForm(this.__lvItemChecked, this.GetConnection,
        this.GetConfigIP, false))
      {
        fota.lv.SmallImageList = this.imageList1;
        fota.ShowDialog();
        if (this.__lvItemChecked.Count > 0)
        {
          foreach (ListViewItem item in this.LstViewItm.Items)
          {
            item.Checked = false;
          }
          this.__lvItemChecked.Clear();
        }
      }
    }

    private void tsMenuItem_Patch_Click(object sender, EventArgs e)
    {
      using (var fota = new Fota.FotaForm(this.__lvItemChecked, this.GetConnection,
        this.GetConfigIP, true))
      {
        fota.lv.SmallImageList = this.imageList1;
        fota.ShowDialog();
        if (this.__lvItemChecked.Count > 0)
        {
          foreach (ListViewItem item in this.LstViewItm.Items)
          {
            item.Checked = false;
          }
          this.__lvItemChecked.Clear();
        }
      }
    }

    private void toolStripButton3_Click(object sender, EventArgs e)
    {
      __frm = new UlcWin.win.WaitForm(new Action(() => { }), StateWaitForm.StateSimple);
      __frm.ShowDialog();
    }

    private void tsPingCurrentlStriMenuItem_Click(object sender, EventArgs e)
    {
      if (this.LstViewItm.SelectedItems.Count > 0)
      {
        using (ui.PingForm ping = new PingForm(this.LstViewItm.SelectedItems[0]))
        {
          ping.ShowDialog();
        }
      }

    }

    private void tsAllPingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      tsPingMenuItem_Click(null, null);
    }
    int __selected_device_type = 1;
    private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (__sel_node != null)
      {
        DateTime dtn = DateTime.Now;
        DateTime dt = new DateTime(dtn.Year, dtn.Month, dtn.Day, 0, 0, 0);
        __db.ViewRes(this.LstViewItm, __sel_node.Id, dt,
          (EnumViewDevType)this.tsComboBoxDev.SelectedIndex,
          __sel_node.Text);
      }

      __selected_device_type = this.tsComboBoxDev.SelectedIndex;

      ReadStatusListView();
     
      this.ReinitFind();
    }

    private void LvMenu_Opening(object sender, CancelEventArgs e)
    {

    }

    private void getIdToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ItemIp iIp = (ItemIp)this.LstViewItm.SelectedItems[0].Tag;
      Clipboard.SetText(iIp.Id.ToString());
    }

    //string default_settings = "CONFIG:APN:vpn2.mts.by USER:vpn PASS:gsd9drekj5 DT:1486398097 DEBOUNCE:110 DEBUG:0 EST:1 IP:15;10;20;1 TCP:10245 TSEND:1 AIN:1 DIN:15 DOUT:1 DOOR:15 LATIT:55.191 LONGIT:30.125 TZ:3 CDIN:133 CDOUT:0 CAIN:0;0;0;0 SRISE:1486391121 SSET:1486429905 SIM:1 GSM:1 GPRS:1 SIGNAL:17 DBZ:1 IPOWN:172.22.130.150 SCHED:EQEBDB8BAwAeABQ= RAS:1 VER:I4O1A1-LDC-3-FOTA SERIAL:9600,8,0,1 NUM:1 SVERS:1.7.9 TECHN:2G FMW:1485372201 TMSET:00:30 IPP:255.255.255.255 PERP:1 IMEI:353465071300246 LOGSLVL:0 BRG:0 CORV:12.01.830-B006 TRAFC:1486273";

    private void geniralSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {

      using (MultiSettingsForm mForm = new MultiSettingsForm(this.__lvItemChecked, this.GetConnection,
        this.tsComboBoxDev.SelectedIndex == 0 ? Ztp.Enums.DevType.RVP18 : Ztp.Enums.DevType.ULC02, __db,
        this.treeView1.SelectedNode.FullPath))
      {

        if (mForm.ShowDialog() == DialogResult.OK)
        {
          ZtpConfig cfg = mForm.Value;
        }
        else
        {

        }
      }


    }

    private void tsSelectAll_Click(object sender, EventArgs e)
    {
      if (__lip == null)
        __lip = new List<ItemCallBack>();
      else
        __lip.Clear();
      foreach (ListViewItem item in this.LstViewItm.Items)
      {

        item.Checked = true;

      }
      this.tsSelectedItems.Image = UlcWin.Properties.Resources.btnCheck;
    }

    private void tsDeselectAll_Click(object sender, EventArgs e)
    {
      if (__lip == null)
        __lip = new List<ItemCallBack>();
      else
        __lip.Clear();
      foreach (ListViewItem item in this.LstViewItm.Items)
      {

        item.Checked = false;

      }
      this.tsSelectedItems.Image = UlcWin.Properties.Resources.btnUncheck;
    }

    private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
    {
      if (this.splitContainer1.Panel1.Width > 300 || this.splitContainer1.Panel1.Width < 200)
      {
        this.splitContainer1.SplitterDistance = 300;

      }

      this.tsStsLabelAll.Margin = new Padding((this.splitContainer1.SplitterDistance), 0, 0, 0);

    }

    private void toolStripButton3_Click_1(object sender, EventArgs e)
    {
      this.tsStatusLbl.Visible = false;
      this.tsBtnConnect.Image = UlcWin.Properties.Resources.server_connection;
      this.tsBtnConnect.Text = "Подключение";
      this.treeView1.Nodes.Clear();
      this.LstViewItm.Items.Clear();
      this.LstViewItm.Visible = false;
      this.tsTreePanel.Visible = false;
      //this.tsResView.Visible = false;
      this.tsTreePanel.Enabled = false;
      usrFesStatistics1.Visible = false;
      tsBtnUsersEdit.Enabled = false;
      tsBtnStatistics.Enabled = false;
      toolStripSeparator2.Visible = false;
      toolStripSeparator7.Visible = false;
      this.tsBtnAbout.Visible = false;
      this.tsBtnStatistics.Visible = false;
      this.tsBtnUsersEdit.Visible = false;
      this.tsBtnEventLog.Visible = false;
      this.ulcMeterTreeView.Visible = false;
      bool con_db = InitDB();
      if (con_db)
      {
        this.tsBtnConnect.Image = UlcWin.Properties.Resources.server_ok;
        this.tsBtnConnect.Text = "Подключено";
        tsBtnUsersEdit.Enabled = true;
#if STAT
        tsBtnStatistics.Enabled = true;
#endif
        toolStripSeparator2.Visible = true;
        toolStripSeparator7.Visible = true;
        //this.LstViewItm.Visible = true;
        this.tsTreePanel.Visible = true;
        //this.tsResView.Visible = false;
        this.tsBtnAbout.Visible = true;
#if STAT
        this.tsBtnStatistics.Visible = true;
#endif
        this.tsBtnUsersEdit.Visible = true;
        this.tsBtnEventLog.Visible = true;
        this.tsTreePanel.Enabled = true;
      }
      else
      {
        //this.tsBtnConnect.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnConnect.Image")));
        this.tsBtnConnect.Image = UlcWin.Properties.Resources.server_connection;
        this.tsBtnConnect.Text = "Подключение";
        this.tsTreePanel.Enabled = false;
      }
    }



    private void tsTreeAddItem_Click(object sender, EventArgs e)
    {
      UNode node = (UNode)this.treeView1.SelectedNode;
      using (TreeItemNodeForm edForm = new TreeItemNodeForm())
      {
        DialogResult result = edForm.ShowDialog();
        if (result == DialogResult.OK)
        {
          long? idR= __db.AddTreeItem(node.Id, edForm.txtNodeName.Text, node.Text + "\\" + edForm.txtNodeName.Text,
             DbReader.SqlTreeNodes.SubTree);
          if (idR.HasValue)
          {
            UNode uNode = new UNode();
            uNode.Id = (int)idR.Value;
            uNode.Name = edForm.txtNodeName.Text;
            uNode.Text = edForm.txtNodeName.Text;
            uNode.IsView = true;
            this.treeView1.SelectedNode.Nodes.Add(uNode);
            edForm.Close();
          }
          else {
            edForm.Close();
            MessageBox.Show("Ошибка добавления объекта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        else
        {
          edForm.Close();
        }

      }


    }

    private void tsTreeDeleteItem_Click(object sender, EventArgs e)
    {
      UNode node = (UNode)this.treeView1.SelectedNode;
      DialogResult result = MessageBox.Show("Вы действительно хотите удалить элемент " + node.Name,
        "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (result == DialogResult.Yes)
      {
        if (node.IsView)
        {
          foreach (ListViewItem item in LstViewItm.Items)
          {
            ItemIp iIp = (ItemIp)item.Tag;
            __db.DeleteResRecord(iIp.Id, null, null, null);
          }
        }
        else
        {
          UNode iNnode = (UNode)this.treeView1.SelectedNode;
          foreach (var itNodes in iNnode.Nodes)
          {
            UNode lNnode = (UNode)itNodes;
            List<int> lstNodeId = __db.GetListItemRoot(lNnode.Id, (EnumViewDevType)this.tsComboBoxDev.SelectedIndex);
            if (lstNodeId != null)
            {
              foreach (var item in lstNodeId)
              {
                __db.DeleteResRecord(item, null, null, null);
              }
            }
            __db.DeleteTreeItem(lNnode.Id, null, null, DbReader.SqlTreeNodes.None);
          }
        }

        __db.DeleteTreeItem(node.Id, node.FullPath, EnLogEvt.DELETE_NODE,node.Parent==null ? DbReader.SqlTreeNodes.TopTree: DbReader.SqlTreeNodes.SubTree);
        this.treeView1.Nodes.Remove(this.treeView1.SelectedNode);
        this.LstViewItm.Items.Clear();
      }
    }

    private void tsAddRootItem_Click(object sender, EventArgs e)
    {
      UNode node = (UNode)this.treeView1.SelectedNode;
      using (TreeItemNodeForm edForm = new TreeItemNodeForm())
      {
        DialogResult result = edForm.ShowDialog();
        if (result == DialogResult.OK)
        {
          edForm.Close();
          long? idNew = __db.AddTreeItem(null, edForm.txtNodeName.Text, edForm.txtNodeName.Text,DbReader.SqlTreeNodes.TopTree);
          if (idNew.HasValue)
          {
            UNode uNode = new UNode();
            uNode.Id = (int)idNew.Value;
            uNode.Name = edForm.txtNodeName.Text;
            uNode.Text = edForm.txtNodeName.Text;
            uNode.IsView = false;
            this.treeView1.Nodes.Add(uNode);
          }
          else {
            MessageBox.Show("Ошибка при добавлении объекта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
         
        }
        else
        {
          edForm.Close();
        }
      }
    }

    private void tsTreeEdit_Click(object sender, EventArgs e)
    {
      UNode node = (UNode)this.treeView1.SelectedNode;
      using (TreeItemNodeForm edForm = new TreeItemNodeForm())
      {
        edForm.txtNodeName.Text = node.Text;
        DialogResult result = edForm.ShowDialog();
        if (result == DialogResult.OK)
        {
          __db.UpdateTreeItem(edForm.txtNodeName.Text, node.Id, node.FullPath,node.Parent==null ? DbReader.SqlTreeNodes.TopTree: DbReader.SqlTreeNodes.SubTree);
          UNode uNode = new UNode();
          // uNode.Id = idNew;
          uNode.Name = edForm.txtNodeName.Text;
          uNode.Text = edForm.txtNodeName.Text;
          uNode.IsView = false;
          this.treeView1.SelectedNode.Text = edForm.txtNodeName.Text;
          edForm.Close();
        }
        else
        {
          edForm.Close();
        }
      }
    }

    private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
    {
      TreeNode node = (TreeNode)e.Node;
      foreach (TreeNode item in node.Nodes)
      {
        item.ImageIndex = 18;
      }
      // int x = 0;
    }

    private void tsTreeBtnAddRoot_Click(object sender, EventArgs e)
    {
      UNode node = (UNode)this.treeView1.SelectedNode;
      using (TreeItemNodeForm edForm = new TreeItemNodeForm())
      {
        DialogResult result = edForm.ShowDialog();
        if (result == DialogResult.OK)
        {
          edForm.Close();
          long? idNew = __db.AddTreeItem(null, edForm.txtNodeName.Text, edForm.txtNodeName.Text,
            DbReader.SqlTreeNodes.TopTree);
          if (idNew.HasValue)
          {
            UNode uNode = new UNode();
            uNode.Id = (int)idNew;
            uNode.Name = edForm.txtNodeName.Text;
            uNode.Text = edForm.txtNodeName.Text;
            uNode.IsView = false;
            this.treeView1.Nodes.Add(uNode);
           
          }
          else
          {
            MessageBox.Show("Ошибка при добавлении объекта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        else
        {
          edForm.Close();
        }
      }
    }

    private void tsTreeBtnAdd_Click(object sender, EventArgs e)
    {
      UNode node = (UNode)this.treeView1.SelectedNode;
      using (TreeItemNodeForm edForm = new TreeItemNodeForm())
      {
        DialogResult result = edForm.ShowDialog();
        if (result == DialogResult.OK)
        {
          edForm.Close();
          long? idNew = __db.AddTreeItem(node.Id, edForm.txtNodeName.Text, node.Text + "\\" + edForm.txtNodeName.Text,
            DbReader.SqlTreeNodes.SubTree);
          if (idNew.HasValue)
          {
            UNode uNode = new UNode();
            uNode.Id = (int)idNew;
            uNode.Name = edForm.txtNodeName.Text;
            uNode.Text = edForm.txtNodeName.Text;
            uNode.IsView = true;
            this.treeView1.SelectedNode.Nodes.Add(uNode);
          }
          else {
            MessageBox.Show("Ошибка при добавлении объекта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
         
        }
      }
    }

    private void tsTreeBtnDelete_Click(object sender, EventArgs e)
    {
      DialogResult result = MessageBox.Show("Вы уверены в удалении объекта", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.No)
        return;
      UNode node = (UNode)this.treeView1.SelectedNode;

      if (node.IsView)
      {
        foreach (ListViewItem item in LstViewItm.Items)
        {
          ItemIp iIp = (ItemIp)item.Tag;
          __db.DeleteResRecord(iIp.Id, null, null, null);
        }
      }
      else
      {
        UNode iNnode = (UNode)this.treeView1.SelectedNode;
        foreach (var itNodes in iNnode.Nodes)
        {
          UNode lNnode = (UNode)itNodes;
          List<int> lstNodeId = __db.GetListItemRoot(lNnode.Id, (EnumViewDevType)this.tsComboBoxDev.SelectedIndex);
          if (lstNodeId != null)
          {
            foreach (var item in lstNodeId)
            {
              __db.DeleteResRecord(item, null, null, null);
            }
          }
          __db.DeleteTreeItem(lNnode.Id, null, null, DbReader.SqlTreeNodes.None);
        }
      }
      __db.DeleteTreeItem(node.Id, node.FullPath, EnLogEvt.DELETE_NODE, node.Parent == null ? DbReader.SqlTreeNodes.TopTree : DbReader.SqlTreeNodes.SubTree);
      this.treeView1.Nodes.Remove(this.treeView1.SelectedNode);
      this.LstViewItm.Items.Clear();
    }

    private void tsTreeBtnEdit_Click(object sender, EventArgs e)
    {
      UNode node = (UNode)this.treeView1.SelectedNode;
      using (TreeItemNodeForm edForm = new TreeItemNodeForm())
      {
        edForm.txtNodeName.Text = node.Text;
        DialogResult result = edForm.ShowDialog();
        if (result == DialogResult.OK)
        {
          __db.UpdateTreeItem(edForm.txtNodeName.Text, node.Id, node.FullPath,node.Parent==null? DbReader.SqlTreeNodes.TopTree: DbReader.SqlTreeNodes.SubTree);
          UNode uNode = new UNode();
          // uNode.Id = idNew;
          uNode.Name = edForm.txtNodeName.Text;
          uNode.Text = edForm.txtNodeName.Text;
          uNode.IsView = false;
          this.treeView1.SelectedNode.Text = edForm.txtNodeName.Text;
          edForm.Close();

        }
        else
        {
          edForm.Close();
        }
      }
    }

    private void toolStripButton3_Click_2(object sender, EventArgs e)
    {

      using (UsersEditForm form = new UsersEditForm(this.__db))
      {

        Dictionary<UNode, List<UNode>> dic = new Dictionary<UNode, List<UNode>>();
        foreach (UNode rItem in this.treeView1.Nodes)
        {
          dic.Add(rItem, new List<UNode>());
          foreach (UNode pItem in rItem.Nodes)
          {
            dic[rItem].Add(pItem);
          }
        }
        form.InitTree(this.imageList1, dic);

        form.ShowDialog();
      }
    }



    private void toolStripButton3_Click_3(object sender, EventArgs e)
    {
     
      if (!this.__panel_event_log)
      {

        this.splitContainer2.Panel2Collapsed = false;
        splitContainer2.Panel2.Show();
        tsBtnEventShowHide.Image = global::UlcWin.Properties.Resources.window;
        tsBtnEventShowHide.ToolTipText = "Скрыть панель событий";
        this.LstViewItm_SelectedIndexChanged(null, null);
        this.__panel_event_log = true;
      }
      else
      {

       
        this.splitContainer2.Panel2Collapsed = true;
        splitContainer2.Panel2.Hide();
        tsBtnEventShowHide.Image = global::UlcWin.Properties.Resources.window_split_ver;
        tsBtnEventShowHide.ToolTipText = "Показать панель событий";
        this.__panel_event_log = false;
      }

    }
    string __pwd = string.Empty;
    public bool CheckSessionPassword()
    {

      using (PasswordForm frm = new PasswordForm())
      {
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          this.__pwd = frm.Value;
          return true;

        }
      }
      return false;
    }

    private bool RebootLeter(NetworkStream stream, ItemIp itip)
    {
      bool op = false;
      string at = "###AT#ENHRST=1,0\r";
      byte[] bAt = System.Text.ASCIIEncoding.ASCII.GetBytes(at);
      try
      {
        stream.Write(bAt, 0, bAt.Length);
        int len = stream.Read(bAt, 0, bAt.Length);
        if (len > 0)
        {
          string answ = System.Text.ASCIIEncoding.ASCII.GetString(bAt, 0, len);
          if (answ.Equals("\r\nOK\r\n\r\n"))
          {
            op = true;
          }
        }
        else
        {
          throw new Exception("Ошибка чтения...");
        }
      }
      catch (Exception exp)
      {
      }

      return op;
    }

    private void RebootDevices()
    {

      __lstTaskUpdate = new List<Task>();
      __lstTaskRunner = new List<Task>();
      string command = ZtpProtocol.RebootCommand(this.__pwd);

      foreach (ItemCallBack item in __lip)
      {
        Task tsk = new Task(new Action<object>((oItem) =>
        {
          ItemCallBack ositem = (ItemCallBack)oItem;
          ItemIp itip = ositem.ItmIp;
          TcpClient client = null;
          try
          {
            client = GetConnection(itip.Ip, 10251);
            if (client == null)
              throw new Exception("Ошибка соединения...");
            NetworkStream stream = client.GetStream();
            if (!RebootLeter(stream, itip))
            {
              __frm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, itip.UType, 9);
            }
            else
            {
              __frm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, true, itip.UType, 8);
            }
          }
          catch
          {
            __frm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, itip.UType, 1);
          }
          finally
          {
            ositem.runOff(ositem.TaskOwn);
            if (client != null)
              client.Close();
          }
        }), item);
        item.TaskOwn = tsk;
        item.runOff = this.CallBackTaskEnd;
        __lstTaskUpdate.Add(tsk);
        __count_update = 0;
      }
      var iner = Task.Factory.StartNew(() =>
      {
        for (int i = 0; i < __lstTaskUpdate.Count; i++)
        {
          while (true)
          {
            if (this.__lstTaskRunner.Count < 50)
            {
              this.__lstTaskRunner.Add(__lstTaskUpdate[i]);
              __lstTaskUpdate[i].Start();
              break;
            }
            Thread.Sleep(100);
          }

        }
        while (this.__lstTaskRunner.Count != 0)
        {
          Thread.Sleep(100);
        }
        this.__frm.BeginInvoke(new Action(() =>
        {
          __frm.CompleetWork(true);
        }));
      });
    }

    private void tsMenuItemReboot_Click(object sender, EventArgs e)
    {
      if (CheckSessionPassword())
      {
        if (__lip == null)
          __lip = new List<ItemCallBack>();
        else
          __lip.Clear();
        foreach (ListViewItem item in this.__lvItemChecked)
        {
          ItemCallBack li = new ItemCallBack(item);
          __lip.Add(li);
        }
        DialogResult result = ReadParam(RebootDevices, StateWaitForm.StateOverSimple);
        foreach (ListViewItem item in LstViewItm.Items)
        {
          item.Checked = false;
        }
      }
    }

    private void tsBtnExport_Click(object sender, EventArgs e)
    {
      string fes = this.treeView1.SelectedNode.Parent.Text;
      string res = this.treeView1.SelectedNode.Text;
      object[] cItem = new object[this.LstViewItm.Items.Count];
      this.LstViewItm.Items.CopyTo(cItem, 0);
      ListView listView3 = new ListView();
      listView3.Columns.AddRange((from ColumnHeader Col in LstViewItm.Columns
                                  select (ColumnHeader)Col.Clone()).ToArray());
      listView3.Items.AddRange((from ListViewItem item in LstViewItm.Items
                                select (ListViewItem)item.Clone()
                                ).ToArray());
      using (SimpleWaitForm sfrm = new SimpleWaitForm())
      {
        sfrm.RunAction(new Action(() =>
        {
          sfrm.SetLabelText("Формирую документ");
          Export.ExportExcel exe = new Export.ExportExcel(listView3);// this.LstViewItm);
          bool doc = exe.PrintToExcel(fes, res, sfrm);
          sfrm.DialogResult = DialogResult.OK;
        }));
        sfrm.ShowDialog();
      }
    }

    private void toolStripButton4_Click(object sender, EventArgs e)
    {
      using (AllStatisticsForm t = new AllStatisticsForm(__db))
      {
        t.ShowDialog(this);
      }
    }

    private void checkBoxComboBox1_CheckBoxCheckedChanged(object sender, EventArgs e)
    {
      this.checkBoxComboBox1.Text = "Выбор колонок";
    }

    public static string HttpGet(string uri)
    {
      string content = null;

      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

      using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
      using (Stream stream = response.GetResponseStream())
      using (StreamReader sr = new StreamReader(stream))
      {
        content = sr.ReadToEnd();
      }

      return content;
    }

    public async Task<string> HttpGetAsync(string uri)
    {
      string content = null;

      var client = new System.Net.Http.HttpClient();
      var response = await client.GetAsync(uri);
      if (response.IsSuccessStatusCode)
      {
        content = await response.Content.ReadAsStringAsync();
      }

      return content;
    }

    private void testmeterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ItemIp itemIp = (ItemIp)this.LstViewItm.SelectedItems[0].Tag;
      //if (!string.IsNullOrEmpty(itemIp.Meters) && itemIp.Meters!="Н/Д")
      //{
      List<Controls.UlcMeterComponet.MeterInfo> meterInfos = __db.GetMetrsById(itemIp.Id);
      if (meterInfos.Count > 0)
      {
        using (MeterForm mf = new MeterForm(itemIp, meterInfos, this.GetConnection))
        {
          mf.ShowDialog();
        }
      }
      else
      {
        MessageBox.Show("Счетчиков на данном объекте нет", "Счетчики", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
    }

    private void tsBtnAbout_Click(object sender, EventArgs e)
    {
      AboutForm about = new AboutForm();
      about.ShowDialog();

    }


    private void tsLogShowDialog(object sender, EventArgs e)
    {

      using (LogsViewForm logsViewForm=new LogsViewForm(this.__db,this.__aSettings_new))
      {
       
        logsViewForm.ShowDialog();
      }
    }


   

    string UpdateNotTrueMeters(string ip) {
      string msg = string.Empty;
      TcpClient client = null;
      try
      {
        client = GetConnection(ip, 10251);
        if (client == null)
          throw new Exception(string.Format("Error connect to:{0}", ip));
        bool result = false;
        result = this.GetConfigIP(client, out msg);
        if (client != null)
        {
          client.Close();
        }
        return msg;
      }
      catch
      {
        return msg;
      }
      finally
      {
        if (client != null)
          client.Close();
      }
    }

    public void ReadMeters(/*List<ItemIp> iptems*/)
    {
      __lstTaskUpdate = new List<Task>();
      __lstTaskRunner = new List<Task>();
      string node_full_path = string.Empty;
      IAsyncResult res = this.BeginInvoke(new Action(() =>
      {
        node_full_path = this.treeView1.SelectedNode.FullPath;
      }));
      res.AsyncWaitHandle.WaitOne();
      foreach (ItemCallBack item in __lip)
      {
        Task tsk = new Task(new Action<object>((oItem) =>
        {
          ItemCallBack ositem = (ItemCallBack)oItem;
          ItemIp itip = ositem.ItmIp;
          TcpClient client = null;
          try
          {
            client = this.GetConnection(itip.Ip, 10250);//new TcpClient(item.IP, 10251);
            if (client == null)
              throw new Exception("Ошибка соединения");
            bool request = false;
            Exception exc = null;
            foreach (MeterInfo itM in ositem.meters)
            {
              if (itM.meter_type.Contains("CE102") || itM.meter_type.Contains("СЕ102"))
              {
                string num = itM.meter_factory;
                num = num.Substring(num.Length - 4, 4);
                ushort addr = 0;
                if (ushort.TryParse(num, out addr))
                {
                  byte[] buffer = new byte[128];
                  byte[] buf = EnMera102.packbuf(EnMera102.EnumFunEnMera.ReadTariffSum, new byte[] { 0 }, 1, addr);
                  Exception exp = EnMera102.Read(buf, 128, client, out buffer);
                  if (exp == null)
                  {
                    float ds = (float)BitConverter.ToInt32(buffer, 9);
                    __frm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, true, itM.meter_type, (ds / 100).ToString()+" (обновляю)");
                    item.IsMeterTrue = true;
                    string msg = UpdateNotTrueMeters(itip.Ip);
                    if (!string.IsNullOrEmpty(msg))
                    {
                      itip.MsgConfig = new DataMsg()
                      {
                        Date = DateTime.Now,
                        Message = msg
                      };
                      request = true;
                      break;
                    }
                  }
                  else
                  {
                    item.IsMeterTrue = false;
                    
                    //__frm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, itM.meter_type, exp.Message);
                  }
                }
                //else throw new Exception("ошибка получения данных");
              }
              if (itM.meter_type.Contains("CE318") || itM.meter_type.Contains("СЕ318"))
              {
                string num = itM.meter_factory;
                ushort addr = 0;
                float value = 0;
                if (!ushort.TryParse(num, out addr))
                  throw new Exception("ошибка получения данных");
                if (!EnMera318BY.GetValue(EnMera318Fun.EnergyStartDay, itM.meter_factory, client, 10000, out value))
                {
                  __frm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, true, itM.meter_type, value.ToString() + " (обновляю)");
                  item.IsMeterTrue = true;
                  string msg = UpdateNotTrueMeters(itip.Ip);
                  if (!string.IsNullOrEmpty(msg))
                  {
                    itip.MsgConfig = new DataMsg()
                    {
                      Date = DateTime.Now,
                      Message = msg
                    };
                    request = true;
                    break;
                  }
                }
                else
                {
                  item.IsMeterTrue = false;
                }
              }
              else if (itM.meter_type.Contains("СС") || itM.meter_type.Contains("СС"))
              {
                string num = itM.meter_factory;
                if (client == null)
                  throw new Exception("Ошибка открытия соединения");
                Exception ex = null;
                float? val = Granelectro.GetSumValue(EnGranSys.ACCUMULATED_ENERGY_DAY, num, client, out ex);
                if (ex == null)
                {
                  item.IsMeterTrue = true;
                  __frm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, true, itM.meter_type, val.Value.ToString() + " (обновляю)");
                  string msg = UpdateNotTrueMeters(itip.Ip);
                  if (!string.IsNullOrEmpty(msg))
                  {
                    itip.MsgConfig = new DataMsg()
                    {
                      Date = DateTime.Now,
                      Message = msg
                    };
                    request = true;
                    break;
                  }
                }
                else
                {
                  item.IsMeterTrue = false;
                }
              }
              else
              {
                throw new Exception("Счетчик не поддерживается");
              }
            }
            if(!request)
              __frm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, ositem.ItmIp.UType, 10);
          }
          catch(Exception e)
          {
            __frm.ChangeLabelText(itip.Name, itip.Name, itip.Ip, false, "---", e.Message);
            
            //__db.CheckCurrentRecord(itip.Id, DateTime.Now, "");
            //itip.IsTrue = false;
          }
          finally
          {
            if (client != null)
              client.Close();
            ositem.runOff(ositem.TaskOwn);
          }
        }), item);
        item.TaskOwn = tsk;
        item.runOff = this.CallBackTaskEnd;
        __lstTaskUpdate.Add(tsk);
        __count_update = 0;
        if (__frm.__complite_work)
          break;
      }
      var iner = Task.Factory.StartNew(() =>
      {
        for (int i = 0; i < __lstTaskUpdate.Count; i++)
        {

          while (true)
          {
            if (this.__lstTaskRunner.Count < 100)
            {
              if (__frm.__complite_work)
                break;
              this.__lstTaskRunner.Add(__lstTaskUpdate[i]);
              __lstTaskUpdate[i].Start();
              break;
            }

            Thread.Sleep(100);
          }
          if (__frm.__complite_work)
            break;
        }
        if (__frm.__complite_work)
          return;
        while (this.__lstTaskRunner.Count != 0)
        {
          Thread.Sleep(100);

        }
       
        try
        {
          this.__frm.BeginInvoke(new Action(() =>
          {
            __frm.CompleetWork(false);
          }));
        }
        catch (Exception)
        {
          int x = 0;
        }
        List<ItemCallBack> lstCbk = new List<ItemCallBack>();
        foreach (var item in __lip)
        {
          if (item.IsMeterTrue)
          {
            lstCbk.Add(item);
          }
        }
        __db.InsertArrayRecordInDb(lstCbk, node_full_path);
      });
    }


    private void ctxNotTrueMeter_Click(object sender, EventArgs e)
    {
      //List<Meters[]> mt = new List<Meters[]>();
      if (__lip == null)
        __lip = new List<ItemCallBack>();
      else
        __lip.Clear();
      foreach (ListViewItem item in LstViewItm.Items)
      {
        int res485 = 0;
        ItemIp itemIp = (ItemIp)item.Tag;
        if (itemIp.Active == 1 && itemIp.Rs_Stat==1)
        {
          int.TryParse(item.SubItems[13].Text.Trim(), out res485);
          if (res485 != 1)
          {
            List<MeterInfo> meterInfos= __db.GetMetrsById(itemIp.Id);
            //Meters[] mtr = (Meters[])System.Text.Json.JsonSerializer.Deserialize(itemIp.Meters, typeof(Meters[]));
            ItemCallBack li = new ItemCallBack(item);
            if (li.meters == null)
              li.meters = meterInfos;
            __lip.Add(li);
            //break;
          }
        }
      }
      if (__lip.Count == 0)
        return;
      DialogResult result = ReadParam(ReadMeters, StateWaitForm.StateOverSimple);
      this.LstViewItm.Items.Clear();
      this.__lip.Clear();
      //this.__lvItemChecked.Clear();
      __db.ViewRes(this.LstViewItm, __sel_node.Id, DateTime.Now,
        (EnumViewDevType)this.tsComboBoxDev.SelectedIndex,
        __sel_node.Text);

      ReadStatusListView();
      //this.LstViewItm.Items.Clear();
      //__db.ViewRes(this.LstViewItm, __sel_node.Id, DateTime.Now,
      //  (EnumViewDevType)this.tsComboBoxDev.SelectedIndex, __sel_node.Text);
      //this.tsLblAll.Text = "Всего:" + __db.__num.ToString();
      //this.tsLblNotTrue.Text = "Ошибки:" + __db.__notTrue.ToString();

      //ReadParam(TrySelectedItemUpdate,StateWaitForm.StateOverSimple);
      //ReadStatusListView();

    }

    private void LstViewItm_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        //Control p = this.GetChildAtPoint(e.Location);
        LvMenu.Show(Cursor.Position);
      }
    }

    //private void ctxMenuNumber_Click(object sender, EventArgs e)
    //{
    //  ToolStripMenuItem mItemNum = (ToolStripMenuItem)ctxMenuHeader.Items["ctxMenuNumber"];
    //  ToolStripMenuItem mItemObj = (ToolStripMenuItem)ctxMenuHeader.Items["ctxMenuObject"];
    //  mItemNum.Checked = true;
    //  mItemObj.Checked = false;
    //  this.LstViewItm_ColumnClick(this.LstViewItm, new ColumnClickEventArgs(1));
    //}

    //private void ctxMenuObject_Click(object sender, EventArgs e)
    //{
    //  ToolStripMenuItem mItemNum = (ToolStripMenuItem)ctxMenuHeader.Items["ctxMenuNumber"];
    //  ToolStripMenuItem mItemObj = (ToolStripMenuItem)ctxMenuHeader.Items["ctxMenuObject"];
    //  mItemNum.Checked = false;
    //  mItemObj.Checked = true;
    //  this.LstViewItm_ColumnClick(this.LstViewItm, new ColumnClickEventArgs(1));
    //}

    private void actRs485ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (StatRs485 rsForm =new StatRs485(this.__db, this.__lvItemChecked))
      {
       
        rsForm.ShowDialog();
      }

     
    }

   
    private void tabItemsControl_Selected(object sender, TabControlEventArgs e)
    {
      if (e.TabPageIndex == 1)
      {
        this.LstViewItm_SelectedIndexChanged(null, null);
        this.splitContainer2.Panel2Collapsed = true;
        splitContainer2.Panel2.Hide();
        tsBtnEventShowHide.Image = global::UlcWin.Properties.Resources.window_split_ver;
        this.ulcMeterTreeView.RecalcStatusLebel();
        tsBtnEventShowHide.ToolTipText = "Показать панель событий";
        if (this.LstViewItm.SelectedItems.Count != 0)
        {
          ItemIp zx = (ItemIp)this.LstViewItm.SelectedItems[0].Tag;
          int index = 0;
          foreach (var item in ulcMeterTreeView.treeListView1.Roots)
          {
            Controls.UlcMeterComponet.TreeListNodeModel xx =(Controls.UlcMeterComponet.TreeListNodeModel) item;
            if (zx.Ip == xx.ip) {
              ulcMeterTreeView.treeListView1.Items[index].Selected = true;
              ulcMeterTreeView.treeListView1.Select();
              ulcMeterTreeView.treeListView1.EnsureVisible(index);
              ulcMeterTreeView.treeListView1.Refresh();
              break;
            }
            index++;
          }
         
          //var ret = this.LstViewItm.SelectedItems[0];
          
          
        }
      }
      else if (e.TabPageIndex == 0) {
        if (this.__panel_event_log)
        {
          this.splitContainer2.Panel2Collapsed = false;
          splitContainer2.Panel2.Show();
        }
        if (ulcMeterTreeView.treeListView1.Items.Count != 0)
        {
          tsStatusLbl.Items[2].Visible = true;
          tsStatusLbl.Items[4].Visible = true;
          ReadStatusListView();
          
          if (ulcMeterTreeView.treeListView1.SelectedItem!=null)
          {
            Controls.UlcMeterComponet.TreeListNodeModel xx = (Controls.UlcMeterComponet.TreeListNodeModel)this.ulcMeterTreeView.treeListView1.SelectedItem.RowObject;
            var xxx= this.LstViewItm.FindItemWithText(xx.ip);
            if (xxx != null)
            {
              this.LstViewItm.Select();
              this.LstViewItm.Items[xxx.Index].Selected = true;
              this.LstViewItm.EnsureVisible(xxx.Index);
            }
            //ulcMeterTreeView.treeListView1.EnsureVisible(xxx.Index);
            //foreach (ListViewItem item in this.LstViewItm.Items)
            //{

            //  ItemIp zx = (ItemIp)item.Tag;
            //  if (xx.ip == zx.Ip)
            //  {

            //    this.LstViewItm.Items[index].Selected = true;
            //    this.LstViewItm.Select();
            //    ulcMeterTreeView.treeListView1.EnsureVisible(index);
            //    //ulcMeterTreeView.treeListView1.Refresh();
            //    break;
            //  }
            //  index++;
            //}
          }
        }
      }
      
      //if (this.splitContainer2.Panel2Collapsed)
      //{

      //  this.splitContainer2.Panel2Collapsed = false;
      //  splitContainer2.Panel2.Show();
      //  tsBtnEventShowHide.Image = global::UlcWin.Properties.Resources.window;
      //  tsBtnEventShowHide.ToolTipText = "Скрыть панель событий";
      //}
      //else
      //{

      //  this.LstViewItm_SelectedIndexChanged(null, null);
      //  this.splitContainer2.Panel2Collapsed = true;
      //  splitContainer2.Panel2.Hide();
      //  tsBtnEventShowHide.Image = global::UlcWin.Properties.Resources.window_split_ver;
      //  tsBtnEventShowHide.ToolTipText = "Показать панель событий";
      //}
    }
    ListViewItem[] __its_parent;
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      //if (__its_parent == null)
      //{
      //  __its_parent = (from ListViewItem item in this.LstViewItm.Items select (ListViewItem)item.Clone()).ToArray();
      //}

      ListViewItem[] listViewItem = __its_parent.Where(i => string.IsNullOrEmpty(tsFilterText.Text) ||
       i.SubItems[0].Text.Contains(tsFilterText.Text) ||
       i.SubItems[1].Text.Contains(tsFilterText.Text) ||
        i.SubItems[2].Text.Contains(tsFilterText.Text) ||
        i.SubItems[3].Text.Contains(tsFilterText.Text)).Select(c => c).ToArray();
      LstViewItm.BeginUpdate();
      LstViewItm.Items.Clear();
      LstViewItm.Items.AddRange(listViewItem);
      LstViewItm.EndUpdate();
      //// LstViewItm.Items.AddRange(/*c => new ListViewItem(new string[] { c.SubItems[0].Text,c.SubItems[1].Text}));.ToArray());*/
    }
  }


  public enum UlcSort
  {
    DEFAULT = 0,
    IP = 1,
    DATETIME = 2,
    SIGNAL = 3,
    TRAFFIC = 4,
    NAME = 5,
    TP = 6,
    CONTROLER_TYPE = 7,
    RS = 8
  }

  public enum SortObject { 
    OBJECT,
    NUMBER
  }

  public class ItemComparer : IComparer
  {
    ListView listView;
    LoadForm loadForm;
    public int Column { get; set; }
    public SortOrder Order { get; set; }
    public UlcSort UsbSorting { get; set; }
    //public bool IPAddres { get; set; }
    //public bool CDateTime { get; set; }
    public ItemComparer(int colIndex)//, LoadForm form)
    {
      Column = colIndex;
      Order = SortOrder.None;
      UsbSorting = UlcSort.DEFAULT;
      //this.loadForm = form;
      //this.IPAddres = false;
      //CDateTime = false;
    }

    private static Control findControlParent(Control control)
    {
      Control parent=null;
      while ((control = control.Parent) != null)
      {
        parent = control;
      }
      return parent;
    }

    public int Compare(object a, object b)
    {

      int result=-1;
      ListViewItem itemA = a as ListViewItem;
      ListViewItem itemB = b as ListViewItem;
      this.listView = itemA.ListView;
      this.loadForm=(LoadForm) findControlParent(itemA.ListView.Parent);
      if (itemA == null && itemB == null)
        result = 0;
      else if (itemA == null)
        result = -1;
      else if (itemB == null)
        result = 1;
      if (itemA == itemB)
        result = 0;

      switch (UsbSorting)
      {
        case UlcSort.DEFAULT:
          result = String.Compare(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
          break;
        case UlcSort.IP:
          IPAddress addr1=null;
          IPAddress addr2 = null;
          if (System.Net.IPAddress.TryParse(itemA.SubItems[Column].Text, out addr1) &&
            System.Net.IPAddress.TryParse(itemB.SubItems[Column].Text, out addr2))
          {
            result = this.CompareIpAddresses(addr1, addr2);
          }
          break;
        case UlcSort.DATETIME:
          result = this.CompareDateTime(itemA.SubItems[Column].Text,itemB.SubItems[Column].Text);
          break;
        case UlcSort.SIGNAL:
          result =CompareSignal(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
          break;
        case UlcSort.TRAFFIC:
          result = CompareTraffic(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
          break;
        case UlcSort.NAME:
          {
            //ToolStripMenuItem item = (ToolStripMenuItem)loadForm.ctxMenuHeader.Items["ctxMenuObject"];
            //if (item.Checked) {
            //  result = String.Compare(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
            //}
            //else
            //{
              result = CompareName(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
            //}
            break;
          }
        case UlcSort.TP: {
            result = CompareTp(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
            break;
          }
        case UlcSort.RS:
          result = CompareRS(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
          break;
        default:
          break;
      }
      if (Order == SortOrder.Descending)
        result *= -1;
      return result;
    }


    public int CompareRS(string first, string second) {
      int fInt = 0;
      int sInt = 0;
      bool fb;
      bool sb;
      if (first.Equals("X"))
        first = "2";
      else if (second.Equals("X"))
        second = "2";
      Regex reg = new Regex(@"\d+$");
      Match match = reg.Match(first.TrimEnd());
      Match match1 = reg.Match(second.TrimEnd());
      if (match.Success && match1.Success)
      {
        fb = int.TryParse(match.Value, out fInt);
        sb = int.TryParse(match1.Value, out sInt);
        if (!fb && !sb)
        {
          return -1;
        }

        if (fInt == sInt)
          return 0;
        if (fInt > sInt)
          return 1;

      }
      return -1;
    }

    public int CompareTp(string first, string second)
    {
      Regex reg = new Regex(@"\d+$");
      Match match = reg.Match(first.TrimEnd());
      Match match1 = reg.Match(second.TrimEnd());
      if (match.Success && match1.Success)
      {
        int fInt = 0;
        int sInt = 0;
        bool fb = int.TryParse(match.Value, out fInt);
        bool sb = int.TryParse(match1.Value, out sInt);
        if (!fb && !sb)
        {
          return -1;
        }
        else
        {
          if (fInt == sInt)
            return 0;
          if (fInt > sInt)
            return 1;
        }
      }
      return -1;
    }

    public int CompareName(string first, string second)
    {
      Regex reg = new Regex(@"\d+$");
      Match match = reg.Match(first.TrimEnd());
      Match match1 = reg.Match(second.TrimEnd());
      if (match.Success && match1.Success)
      {
        int fInt = 0;
        int sInt = 0;
        bool fb = int.TryParse(match.Value, out fInt);
        bool sb = int.TryParse(match1.Value, out sInt);
        if (!fb && !sb)
        {
          return -1;
        }
        else
        {
          if (fInt == sInt)
            return 0;
          if (fInt > sInt)
            return 1;
        }
      }
      return -1;
    }


    public int CompareTraffic(string first, string second) {
      Regex reg = new Regex(@".*?\s");
      Match match= reg.Match(first);
      Match match1 = reg.Match(second);
      if (match.Success && match1.Success) {
        int fInt = 0;
        int sInt = 0;
        bool fb = int.TryParse(match.Value, out fInt);
        bool sb = int.TryParse(match1.Value, out sInt);
        if (!fb && !sb)
        {
          return -1;
        }
        else
        {
          if (fInt == sInt)
            return 0;
          if (fInt > sInt)
            return 1;
        }
      }
      return -1;
    }

    public int CompareSignal(string first, string second)
    {

      if (first.Equals("---") || second.Equals("---"))
        return 1;
      else {
        string stF = first.Substring(0, first.Length - 4);
        string stS = second.Substring(0, second.Length - 4);
        int iF;
        int iS;
        bool bF = int.TryParse(stF, out iF);
        bool bS = int.TryParse(stS, out iS);
        if (!bF && !bS)
          return -1;
        else {
          if (iF == iS)
            return 0;
          if (iF > iS)
          return 1;
        }
        //return 1;
      }
      //var int1 = this.ToUint32(first);
      //var int2 = this.ToUint32(second);
      //if (int1 == int2)
      //  return 0;
      //if (int1 > int2)
      //  return 1;
      return -1;
    }

    public int CompareIpAddresses(System.Net.IPAddress first, System.Net.IPAddress second)
    {
      var int1 = this.ToUint32(first);
      var int2 = this.ToUint32(second);
      if (int1 == int2)
        return 0;
      if (int1 > int2)
        return 1;
      return -1;
    }


    public int CompareDateTime(string first, string second)
    {
      DateTime dtF;
      DateTime dtS;
      bool bF=DateTime.TryParse(first, out dtF);
      bool bS=DateTime.TryParse(second, out dtS);
      //DateTime fst = DateTime.Parse(first);
      //DateTime scd = DateTime.Parse(second);
      if (!bF || !bS)
        return 0;
      if (dtF == dtS)
        return 0;
      if (dtF > dtS)
        return 1;
      return -1;
    }

    public uint ToUint32(System.Net.IPAddress ipAddress)
    {
      var bytes = ipAddress.GetAddressBytes();

      return ((uint)(bytes[0] << 24)) |
             ((uint)(bytes[1] << 16)) |
             ((uint)(bytes[2] << 8)) |
             ((uint)(bytes[3]));
    }
  }

  class ListObj
  {
    public int Row { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
      return this.Name;
    }
  }

}


