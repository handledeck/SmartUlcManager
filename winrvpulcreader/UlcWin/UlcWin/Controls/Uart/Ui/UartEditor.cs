using Uart.Delegates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uart
{
 
  public partial class UartEditor : Form
  {
    public event EventCheckItem EventUartEditor = null;
    public UartEditor()
    {
      InitializeComponent();
    }

    public object SetUartProperty { get; set; }

    public DialogResult DoAddShowDialog(string caption, object obj)
    {
      this.labHeader.Text = caption;
      this.SetUartProperty = obj;
      this.propertyGrid1.SelectedObject = SetUartProperty;
      this.propertyGrid1.PropertyValueChanged += PropertyGrid1_PropertyValueChanged;
      this.StartPosition = FormStartPosition.CenterParent;
      return base.ShowDialog();
    }

    private void PropertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
    {
      propertyGrid1.Refresh();
    }

    public DialogResult DoEditShowDialog(string caption, object obj)
    {
      this.labHeader.Text = caption;
      this.SetUartProperty = obj;
      this.propertyGrid1.SelectedObject = SetUartProperty;
      this.StartPosition = FormStartPosition.CenterParent;
      return base.ShowDialog();
    }

    private void btOk_Click(object sender, EventArgs e)
    {
      if (EventUartEditor != null)
      {
        bool isUsedIec = false;
        bool isUsedTag = false;
        string errorMsg=string.Empty;
        EventUartEditor(this.propertyGrid1.SelectedObject, out isUsedIec, out isUsedTag, out errorMsg);
        if (!isUsedIec && !isUsedTag)
          this.DialogResult = DialogResult.OK;
        else
        {
          if (isUsedIec)
          {
            using (ExtDialogMessage centeringService = new ExtDialogMessage(this)) // center message box
            {
              MessageBox.Show(this, "Требуется уникальный индекс для мэк104", "Внимание!");
            }

          }
          //else if (isUsedTag)
          //{
          //  using (ExtDialogMessage centeringService = new ExtDialogMessage(this)) // center message box
          //  {
          //    MessageBox.Show(this, "Такой тег уже есть в списке", "Внимание!");
          //  }
          //}
          else if (errorMsg != string.Empty) {
            using (ExtDialogMessage centeringService = new ExtDialogMessage(this)) // center message box
            {
              MessageBox.Show(this,errorMsg, "Внимание!");
            }
          }

        }
      }
      else {
        this.DialogResult = DialogResult.OK;
      }
    }

    
  }
}
