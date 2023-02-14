using InterUlc.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.Controls.UlcMeterComponet;
using UlcWin.DB;
using UlcWin.ui;

namespace UlcWin.Edit
{

  public enum UTypeController:byte{ 
    RVP=0,
    ULC2=1
  }
  public enum UTypeFunction : byte
  {
    Unknown = 0,
    Street = 1
  }
  public partial class Editor : Form
  {

    Dictionary<int, string> __utype;
    bool __addNew = false;
    ItemIp __itemIp = null;
    DbReader __db;
    public List<MeterInfo> __meterInfos =null;
    public Editor()
    {
      InitializeComponent();
    }
    
    public Editor(DbReader db,bool addNew, ItemIp itemIp) {
      InitializeComponent();
      this.__db = db;
      __utype =this.GetTypeConntroller(db);
      __itemIp = itemIp;
      this.__addNew = addNew;
      foreach (var item in __utype)
      {
        this.cbType.Items.Add(item.Value);
      }
      this.cbFunction.Items.Add("Контроль доступа");
      this.cbFunction.Items.Add("Уличное освещение");
      this.cbFunction.Items.Add("Реклоузер");
      this.cbType.SelectedIndex = 1;
      this.cbFunction.SelectedIndex = 1;
      this.Shown += Editor_Shown;
    }

    //string isNeed = "Поле обязательное для запонения";

    //List<TextBoxPlaceHolder> __ctrl_insert=null;
    private void Editor_Shown(object sender, EventArgs e)
    {
      if (__itemIp != null)
      {
        __meterInfos= __db.GetUlcMeters(__itemIp.Id);
        foreach (var item in __meterInfos)
        {
          ListViewItem it = this.lstMeter.Items.Add(item.meter_type);
          it.SubItems.Add(item.meter_factory);
          it.Tag = item;
        }
        //if (!string.IsNullOrEmpty(__itemIp.Meters) && !__itemIp.Meters.Equals("Н/Д"))
        //{
        //  Meters[] arMetr = (Meters[])System.Text.Json.JsonSerializer.Deserialize(__itemIp.Meters, typeof(Meters[]));
        //  if (arMetr != null)
        //  {
        //    foreach (var item in arMetr)
        //    {
        //      ListViewItem it = this.lstMeter.Items.Add(item.meter_type);
        //        it.SubItems.Add(item.meter_factory);
        //      it.Tag = item;

        //    }
        //  }
        //}
      }
      Application.Idle += Application_Idle;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      
      this.txtBoxName_Valid(this.txtBoxState,"Обязательный ввод(макс 30 симв");
      this.txtBoxName_Valid(this.txtBoxCity, "Обязательный ввод(макс 30 симв");
      this.txtBoxIp_Valid(this.txtBoxIpAddress);
      this.txtBoxName_Valid(this.txtBoxZtp, "Обязательный ввод(макс 30 симв");
    
      if (this.lstMeter.SelectedItems.Count == 0 ||
        this.lstMeter.Items.Count == 0)
      {
        this.BtnEdit.Enabled = false;
        this.BtnDelete.Enabled = false;
      }
      else
      {
        this.BtnEdit.Enabled = true;
        this.BtnDelete.Enabled = true;
      }
      if (this.txtBoxState.IsValid &&
        this.txtBoxCity.IsValid &&
        this.txtBoxIpAddress.IsValid &&
        this.txtBoxZtp.IsValid)
      {
        this.btnOk.Enabled = true;
      }
      else {
        this.btnOk.Enabled =false;
      }

    }

    public Dictionary<int, string> GetTypeConntroller(DbReader db) {
      this.__utype = db.GetTypeController();
      return this.__utype;
      
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }
    
    private void txtBoxIp_Valid(object sender)
    {
      bool isMatch = Regex.IsMatch(txtBoxIpAddress.Text, "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
      //Match match = Regex.Match(txtBoxIpAddress.Text, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
      TextBoxPlaceHolder txtip = (TextBoxPlaceHolder)sender;
      if (string.IsNullOrEmpty(txtip.Text))
      {
        this.errorProvider1.SetError(txtip, "Проверте IP адрес");
        txtip.IsValid = false;
      }
      else if (!isMatch)
      {
        this.errorProvider1.SetError(txtip, "Проверте IP адрес");
        txtip.IsValid = false;
      }
      else
      {
        this.errorProvider1.SetError(txtip, "");
        txtip.IsValid = true;
      }
    }

    //bool __isValid = false;

    public void txtBoxName_Valid(object sender,string error)
    {
      TextBoxPlaceHolder txtName = (TextBoxPlaceHolder)sender;
      if (string.IsNullOrEmpty(txtName.Text))
      {
        //e.Cancel = true;
        this.errorProvider1.SetError(txtName, error);
        txtName.IsValid= false;
      }
      else {
        this.errorProvider1.SetError(txtName, "");
        txtName.IsValid = true;
      }
     
    }

    private void txtBoxPhone_Validating(object sender, CancelEventArgs e)
    {
      TextBox txtPhone = (TextBox)sender;
      if (string.IsNullOrEmpty(txtPhone.Text))
      {
        e.Cancel = true;
        this.errorProvider1.SetError(txtPhone, "Значение не может быть пустым");
      }
      else if (txtPhone.Text.Length > 255)
      {
        e.Cancel = true;
        this.errorProvider1.SetError(txtPhone, "Не более 255 символов");
      }
      //else if(!int.TryParse(txtPhone.Text, out phone)){
      //  e.Cancel = true;
      //  this.errorProvider1.SetError(txtPhone, "Ввод только цифры");
      //}

      else
      {
        e.Cancel = false;
        this.errorProvider1.Clear();
      }
    }



    private void BtnDelete_Click(object sender, EventArgs e)
    {
      ((MeterInfo)this.lstMeter.SelectedItems[0].Tag).crud_record= CrudRecord.Delete;
      if (this.lstMeter.SelectedItems.Count != 0) {
        this.lstMeter.SelectedItems[0].Remove();
      }
    }

    

    private void BtnEdit_Click(object sender, EventArgs e)
    {
      using (MeterEditFrom mMrom = new MeterEditFrom((Controls.UlcMeterComponet.MeterInfo)this.lstMeter.SelectedItems[0].Tag))
      {
        if (mMrom.ShowDialog() == DialogResult.OK) {
          ((MeterInfo)this.lstMeter.SelectedItems[0].Tag).ip = this.txtBoxIpAddress.Text;
          ((MeterInfo)this.lstMeter.SelectedItems[0].Tag).meter_factory = mMrom.txtBoxPlant.Text;
           ((MeterInfo)this.lstMeter.SelectedItems[0].Tag).meter_type = mMrom.GetDeviceByIndex();
          ((MeterInfo)this.lstMeter.SelectedItems[0].Tag).crud_record = CrudRecord.Edit;
          ListViewItem li = this.lstMeter.SelectedItems[0];
          li.Text = mMrom.GetDeviceByIndex();
          li.SubItems[1].Text = mMrom.txtBoxPlant.Text;
        }
      }
    }

    

    private void BtnAdd_Click(object sender, EventArgs e)
    {
      using (MeterEditFrom mMrom =new MeterEditFrom(null))
      {
        if (mMrom.ShowDialog() == DialogResult.OK) {
          if (this.__meterInfos == null) {
            this.__meterInfos = new List<MeterInfo>();
          }
          this.__meterInfos.Add(new MeterInfo()
          {
            crud_record = CrudRecord.Add,
            ip = this.txtBoxIpAddress.Text,
            meter_factory = mMrom.txtBoxPlant.Text,
            meter_type = mMrom.GetDeviceByIndex(),
            
          });
          this.lstMeter.Items.Add(mMrom.GetDeviceByIndex()).SubItems.Add(mMrom.txtBoxPlant.Text);
        }
      }

    }
  }
  public class DbItemEditor
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Ip { get; set; }
    public string Phone { get; set; }
    public int UType { get; set; }
    public int IsActive { get; set; }
    public int IsLight { get; set; }
    public string Comment { get; set; }
    public int rs_stat { get; set; }
  }
}
