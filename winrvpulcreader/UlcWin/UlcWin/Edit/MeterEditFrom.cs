using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.DB;
using UlcWin.ui;

namespace UlcWin.Edit
{
  public partial class MeterEditFrom : Form
  {

    public Meters __meter = null;
    string[] __meters = new string[] { "CC-301(Гранэлектро)", "CC-101(Гранэлектро)", "CE102BY(Энергомера)" };
    public MeterEditFrom(Meters meter)
    {
      __meter = meter;
      InitializeComponent();
      foreach (var item in __meters)
      {
        this.comboBox1.Items.Add(item);
      }
      if (__meter != null)
      {
        if (__meter.meter_type.StartsWith("СС-301"))
        {
          this.comboBox1.SelectedIndex = 0;
        }
        else if (__meter.meter_type.StartsWith("СС-101"))
        {
          this.comboBox1.SelectedIndex = 1;
        }
        else if (__meter.meter_type.StartsWith("СЕ102BY"))
        {
          this.comboBox1.SelectedIndex = 2;
        }
        this.txtBoxPlant.Text = __meter.meter_factory;
      }
      else {
        this.comboBox1.SelectedIndex = 1;
      }
      Application.Idle += Application_Idle;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      txtBoxName_Valid(txtBoxPlant, null);
      if (this.txtBoxPlant.IsValid)
      {
        this.btnOk.Enabled = true;
      }
      else { 
        this.btnOk.Enabled = false;
      }
    }

    public string GetDeviceByIndex() {
      string result = string.Empty;
      switch (this.comboBox1.SelectedIndex)
      {
        case 0:
          result = "СС-301";
          break;
        case 1:
          result = "СС-101";
          break;
        case 2:
          result = "CE102BY";
          break;
        default:
          result = string.Empty;
          break;
      }
      return result;
    }

    public void txtBoxName_Valid(object sender, string error)
    {
      TextBoxPlaceHolder txtName = (TextBoxPlaceHolder)sender;
      if (string.IsNullOrEmpty(txtName.Text))
      {
        this.errorProvider1.SetError(txtName, "Поле обязательное для ввода");
        txtName.IsValid = false;
      }
      else
      {
        this.errorProvider1.SetError(txtName, "");
        txtName.IsValid = true;
      }

    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {

      this.DialogResult = DialogResult.OK;
    }
  }
}
