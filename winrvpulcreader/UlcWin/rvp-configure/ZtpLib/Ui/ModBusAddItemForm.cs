using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class ModBusAddItemForm : Form
  {
    public ModbusTag modbusItem = new ModbusTag();
    public List<ModbusTag> mbList = new List<ModbusTag>();
    public List<ushort> usedIecIndexList = new List<ushort>();

    public ModBusAddItemForm(byte adress, byte cmd, byte tagIndex)
    {
      InitializeComponent();
      idDevAddr.Value = adress;
      cbCmdNum.SelectedIndex = cmd;
      nudTagAddr.Value = tagIndex;
      this.Refresh();
    }

    public ModBusAddItemForm(ModbusTag mb)
    {
      InitializeComponent();
      idDevAddr.Value = mb.DevAddr;
      cbCmdNum.SelectedIndex = mb.CmdNum/2 - 1;
      nudTagAddr.Value = mb.TagAddr;
      this.Refresh();
    }

    public ModBusAddItemForm()//:this(1, 0, 1)
    {
      InitializeComponent();
      idDevAddr.Value = 1;
      cbCmdNum.SelectedIndex = 0;
      nudTagAddr.Value = 1;
    }

    public ModBusAddItemForm(ModbusTag mb, List<ushort> val, List<ModbusTag> mbUsed)
    {
      InitializeComponent();
      idDevAddr.Value = mb.DevAddr;
      cbCmdNum.SelectedIndex = mb.CmdNum/2 - 1;
      nudTagAddr.Value = mb.TagAddr;
      nudIecIndex.Value = mb.IecIndex;
      usedIecIndexList = val;
      nudDBZ.Value = mb.DbzVal;
      mbList = mbUsed;
      //modbusItem.usedIndex = val;
    }

    

    public ModBusAddItemForm(ModbusTag mb, List<ushort> val, List<ModbusTag>mbUsed, ushort index) : this(mb, val, mbUsed)
    {
      idDevAddr.Value = mb.DevAddr;
      cbCmdNum.SelectedIndex = mb.CmdNum / 2 - 1;
      nudTagAddr.Value = mb.TagAddr;
      nudIecIndex.Value = mb.IecIndex;
      Text = $"Изменение тега #{index}";
      bAdd.Text = "Править";
    }

    /// <summary>
    /// проверка на дублирование индекса мэк104
    /// </summary>
    /// <param name="index"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    public bool CheckDuplicateIec(ushort index, List<ushort> val)
    {
      bool isDuplicate = false;

      foreach(ushort v in val)
      {
        if(index == v)
        {
          isDuplicate = true;
          break;
        }
      }

      return isDuplicate;
    }

    private void bAdd_Click(object sender, EventArgs e)
    {
      byte dbz = (cbCmdNum.SelectedIndex == 1) ? (byte)nudDBZ.Value : (byte)0;
      ///ToDO Тут реализуем проверку на дубли и если не соответствует, то возвращаемся к вводу либо отмена
      modbusItem = new ModbusTag((byte)idDevAddr.Value, (byte)((cbCmdNum.SelectedIndex + 1) * 2), 
        (ushort)nudTagAddr.Value, (ushort)nudIecIndex.Value, /*(cbCmdNum.SelectedIndex == 1)?(byte)nudDBZ.Value : (byte)0*/dbz);
      bool isUsedIec = CheckDuplicateIec((ushort)nudIecIndex.Value, usedIecIndexList);
      bool isUsedTag = modbusItem.CheckDuplicateTag(mbList);



      if (isUsedTag)//***/
      {
        MessageBox.Show("Такой тег уже есть в списке", "Внимание!");
        //return;
      }
      else if (isUsedIec)
      {
        MessageBox.Show("Требуется уникальный индекс для мэк104", "Внимание!");
      }
      else
      {
        DialogResult = DialogResult.OK;

        //инфа по конвертации строка hex -> int value
        //https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/types/how-to-convert-between-hexadecimal-strings-and-numeric-types
        this.Close();
      }

    }

    private bool CheckIecDublication(ushort val)
    {
      bool res = false;

      foreach (ushort v in usedIecIndexList)
        if (val == v)
          res = true;
      return res;
    }

    private void nudIecIndex_Validating(object sender, CancelEventArgs e)
    {
      modbusItem.IecIndex = (ushort)((NumericUpDown)sender).Value;

      bool isUsedIec = CheckIecDublication(modbusItem.IecIndex);//modbusItem.CheckDuplicateTag(mbList);
      if (nudIecIndex.Value < 50 || nudIecIndex.Value > 65535)
      {
        e.Cancel = true;
        nudIecIndex.Focus();
        this.errorProvider1.SetError(nudIecIndex, "Значение вне диапазона!");
      }
      else if(isUsedIec)
      {
        e.Cancel = true;
        nudIecIndex.Focus();
        this.errorProvider1.SetError(nudIecIndex, "Данный индекс уже задействован!");
      }
      else
      {
        e.Cancel = false;
        this.errorProvider1.SetError(nudIecIndex, "");
      }
    }

    private void cbCmdNum_SelectedIndexChanged(object sender, EventArgs e)
    {
      ComboBox cb = sender as ComboBox;
      switch(cb.SelectedIndex)
      {
        case 0:
          this.nudDBZ.Minimum = 0;
          
          this.Height = 211;
          this.lblDBZ.Visible = false;
          this.nudDBZ.Visible = false;

          this.nudDBZ.Value = 0;
          break;
        case 1:
          this.Height = 231;
          this.lblDBZ.Visible = true;
          this.nudDBZ.Visible = true;
          this.nudDBZ.Minimum = 1;
          this.nudDBZ.Value = (modbusItem.DbzVal == 0)? 1: modbusItem.DbzVal;
          
          break;
      }
    }

    //Проверка на диапазон ввода
    private void nudDBZ_Validating(object sender, CancelEventArgs e)
    {

    }

    private void nudIecIndex_ValueChanged(object sender, EventArgs e)
    {

    }
  }

  public class ModbusTag
  {
    public byte DevAddr;
    public byte CmdNum;
    public ushort TagAddr;
    public ushort IecIndex;
    public byte DbzVal;


    //public List<ModbusTag> usedMb;
    //public List<ushort> usedIndex = null;//???

    public ModbusTag()
    {
      DevAddr = 1;
      CmdNum = 2;
      TagAddr = 1;
      IecIndex = 50;
      DbzVal = 0;
    }

    public ModbusTag(byte devAddr, byte cmdNum, ushort tagAddr, ushort iecIndex, byte dbzVal)
    {
      DevAddr = devAddr;
      CmdNum = cmdNum;
      TagAddr = tagAddr;
      IecIndex = iecIndex;
      DbzVal = dbzVal;
    }

    /// <summary>
    /// Сравнение тегов на совпадение
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
      ModbusTag mb = obj as ModbusTag;

      if (this.DevAddr == mb.DevAddr && this.CmdNum == mb.CmdNum && this.TagAddr == mb.TagAddr)
        return true;
      else
        return false;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    /// <summary>
    /// Поиск дублей при вводе нового значения тега
    /// </summary>
    /// <param name="mb"></param>
    /// <returns></returns>
    public bool CheckDuplicateTag(List<ModbusTag> mb)
    {
      bool isDuplicate = false;
      foreach (ModbusTag m in mb)
      {
        if (this.Equals(m))
        {
          isDuplicate = true;
          break;
        }
      }
      return isDuplicate;
    }
    
  }
}
