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
      this.StartPosition = FormStartPosition.CenterParent;
      return base.ShowDialog();
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
        EventUartEditor(this.SetUartProperty, out isUsedIec, out isUsedTag);
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
          else if (isUsedTag)
          {
            using (ExtDialogMessage centeringService = new ExtDialogMessage(this)) // center message box
            {
              MessageBox.Show(this, "Такой тег уже есть в списке", "Внимание!");
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
