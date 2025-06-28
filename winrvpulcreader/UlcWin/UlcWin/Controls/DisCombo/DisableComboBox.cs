using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.Controls.DisCombo
{
  public partial class DisableComboBox : ComboBox
  {
    //bool __init_cb = false;
    int __old_index = 0;
    public DisableComboBox()
    {
      InitializeComponent();
      this.DrawMode = DrawMode.OwnerDrawFixed;
    }

    public void AddItem(DisItem disItem)
    {
      this.Items.Add(disItem);
    }

    public DisableComboBox(IContainer container)
    {
      container.Add(this);

      InitializeComponent();
    }

   

    private void DisComboBox_DrawItem(object sender, DrawItemEventArgs e)
    {
      if (e.Index != -1)
      {
        DisItem disItem = (DisItem)this.Items[e.Index];
        if (!disItem.Disable)
        {
          e.DrawBackground();
          e.Graphics.DrawString(disItem.Name, this.Font, Brushes.Black, e.Bounds);
          e.DrawFocusRectangle();
        }
        else
        {
          e.DrawBackground();
          e.Graphics.DrawString(disItem.Name, new Font(this.Font.FontFamily,this.Font.Size, FontStyle.Strikeout),
            Brushes.LightGray, e.Bounds);
          e.DrawFocusRectangle();
         
        }
      }
      else
      {
        Font font = this.Font;
        e.Graphics.DrawString("No item select", font, Brushes.LightSlateGray, e.Bounds);
      }

    }

    private void DisComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      
      if (this.SelectedIndex != -1)
      {
        DisItem disItem = (DisItem)this.Items[this.SelectedIndex];
        if (!disItem.Disable)
        {
          __old_index= this.SelectedIndex;

        }
        else {
          this.SelectedIndex=__old_index;
          MessageBox.Show("Данный выбор не поддерживается","Информация",
            MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
      }
    }
  }

  public class DisItem
  {
    public DisItem(string name,bool isEnable=true)
    {
      this.Name = name;
      this.Disable = isEnable;
    }
    public bool Disable { get; set; } = true;
    public string Name { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}
