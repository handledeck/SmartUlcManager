using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.Controls.UlcMeterComponet
{
  public class DbUlcShortView
  {
    
    public long id { get; set; }
    [Display(Description ="Имя объекта")]
    [DisplayName("Имя объекта")]
    public string name { get; set; }
    [Display(Description = "IP адрес")]
    [DisplayName("IP адрес")]
    public string ip_address { get; set; }
    [Display(Description = "Активность контроллера")]
    [DisplayName("Активность контроллера")]
    public bool active { get; set; }
    [Display(Description = "Учет RS-485 в статистике")]
    [DisplayName("Учет RS-485 в статистике")]
    public bool rs_stat { get; set; }
    [Display(Description = "Уличное освещение")]
    [DisplayName("Уличное освещение")]
    public bool light { get; set; }
    public int unit_type_id { get; set; }


    public void CreateDataColumns(DataGridView dataGridView1,ImageList imageList) {
      dataGridView1.ColumnCount = 3;
      dataGridView1.Columns[0].Name = "Product ID";
      dataGridView1.Columns[1].Name = "Product Name";
      dataGridView1.Columns[2].Name = "Product Price";

      string[] row = new string[] { "1", "Product 1", "1000" };
      dataGridView1.Rows.Add(row);
      row = new string[] { "2", "Product 2", "2000" };
      dataGridView1.Rows.Add(row);
      row = new string[] { "3", "Product 3", "3000" };
      dataGridView1.Rows.Add(row);
      row = new string[] { "4", "Product 4", "4000" };
      dataGridView1.Rows.Add(row);

      DataGridViewImageColumn img = new DataGridViewImageColumn();
      img.Image = imageList.Images[0];
      Image image = Image.FromFile("Image Path");
      img.Image = image;
      dataGridView1.Columns.Add(img);
      img.HeaderText = "Image";
      img.Name = "img";

    }

  }
}
