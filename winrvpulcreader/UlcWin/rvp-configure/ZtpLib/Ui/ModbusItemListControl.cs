using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Ztp.Ui;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Ztp.Ui
{
  public partial class ModbusItemListControl : UserControl
  {
    private int TagCount;
    private const byte startIecIndex = 50;
    private Int16 MAX_MB_ITEMS = 100;
    private ModbusTag mbTag = null;

    public Int16 max_mb_Tags
    {
      get { return MAX_MB_ITEMS; }
      set { MAX_MB_ITEMS = value; }
    }

    public ModbusItemListControl()
    {
      InitializeComponent();
      TagCount = 0;
    }

    #region Рабочие методы
    /// <summary>
    /// Зачистка таблицы
    /// </summary>
    public void ClearTable()
    {
      listView1.Items.Clear();
    }

    /// <summary>
    /// Добавление тега в таблицу
    /// </summary>
    /// <param name="addr"></param>
    /// <param name="cmd"></param>
    /// <param name="fieldAddr"></param>
    /// <param name="iecIndex"></param>
    public void addTag(byte addr, byte cmd, ushort fieldAddr, UInt16 iecIndex, byte dbz)
    {
      string[] arr = new string[]{
        (listView1.Items.Count + 1).ToString(),
        addr.ToString(),
        cmd.ToString(),
        fieldAddr.ToString() + "  |  [0x" + Convert.ToString(fieldAddr, 16).ToUpper() + "]",
        ((iecIndex == 0) ? SearchFreeIecIndex(addr, cmd, fieldAddr) : iecIndex).ToString(),
        dbz.ToString(),""
      };

      listView1.Items.Add(new ListViewItem(arr));
      if (!bDeleteTag.Enabled)
        bDeleteTag.Enabled = true;
      if (!bCorrectTag.Enabled)
        bCorrectTag.Enabled = true;

      TagCount = listView1.Items.Count;
    }

    /// <summary>
    /// Удаление выделенного тега из списка таблицы
    /// </summary>
    /// <returns>Кол-во текущих тегов</returns>
    public int DeleteTag()
    {
      try
      {
        if (listView1.Items.Count > 0)
        {
          int i = listView1.FocusedItem.Index;
          string message = $"Будет удален тег из позиции {listView1.Items[i].Text}:\r\n " +
            $"Адрес устройства:\t{listView1.Items[i].SubItems[1].Text}\r\n " +
            $"Команда:\t\t{listView1.Items[i].SubItems[2].Text}\r\n " +
            $"Адрес поля:\t\t{listView1.Items[i].SubItems[3].Text}";
          if (MessageBox.Show(message, $"Удаление тега #{listView1.Items[i].Text}", MessageBoxButtons.OKCancel) == DialogResult.OK)
          {
            listView1.Items.RemoveAt(i);
            RenumberItems();
          }
        }
      }
      catch
      {
        MessageBox.Show("Не выделен тег для удаления", "Внимание");
      }
      return listView1.Items.Count;
    }

    //передача массива со всеми тегами
    /// <summary>
    /// Сборка данных по тегам и упаковка в массив
    /// </summary>
    /// <returns>конфигурированный массив из списка тегов модбас</returns>
    public byte[] GetTagMassive()
    {
      byte[] data = new byte[1024];
      ushort dat_size = 0;

      //вычисляем количество тегов и записываем его в начало
      BitConverter.GetBytes(listView1.Items.Count).CopyTo(data, dat_size);
      dat_size += 2;
      //дальше массив записывается упакованными данными из тегов (адрес, команда, поле)
      for (int i = 0; i < listView1.Items.Count; i++)
      {
        data[dat_size] = byte.Parse(listView1.Items[i].SubItems[1].Text.ToString());
        dat_size++;
        data[dat_size] = byte.Parse(listView1.Items[i].SubItems[2].Text.ToString());
        dat_size++;
        string[] a = listView1.Items[i].SubItems[3].Text.Split(new[] { ' ' }, 2);
        BitConverter.GetBytes(UInt16.Parse(a[0].ToString())).CopyTo(data, dat_size);
        dat_size += 2;
      }
      //Добавление в конец массива индексов мэк104 для тегов
      for (int i = 0; i < listView1.Items.Count; i++)
      {
        BitConverter.GetBytes(UInt16.Parse(listView1.Items[i].SubItems[4].Text.ToString())).CopyTo(data, dat_size);
        dat_size += 2;
      }
      for (int i = 0; i < listView1.Items.Count; i++)
        data[dat_size++] = byte.Parse(listView1.Items[i].SubItems[5].Text.ToString());
      //Доавляем в конец массива символ возврата каретки для ULC02 
      data[dat_size] = 13; //'\r'
      dat_size++;
      // обрезания до действительного размера массива, отрубаем пустой хвост
      Array.Resize<byte>(ref data, dat_size);
      return data;
    }
    #endregion //Рабочие методы

    #region Вспомогательные методы
    /// <summary>
    /// Поиск свободного индекса для мэк104
    /// </summary>
    /// <param name="addr"></param>
    /// <param name="cmd"></param>
    /// <param name="fieldAddr"></param>
    /// <returns></returns>
    private UInt16 SearchFreeIecIndex(byte addr, byte cmd, ushort fieldAddr)
    {
      UInt16 res = (UInt16)(startIecIndex + listView1.Items.Count);//(byte)(startIecIndex + listView1.Items.Count);
      UInt16 max = (UInt16)(startIecIndex + listView1.Items.Count - 1);

      List<UInt16> FreeIndex = new List<UInt16>();

      for (UInt16 i = 0; i < listView1.Items.Count; i++)
      {
        FreeIndex.Add((UInt16)(startIecIndex + i));
      }

      for (UInt16 i = 0; i < listView1.Items.Count; i++)
      {
        try
        {
          int index = FreeIndex.IndexOf((UInt16.Parse(listView1.Items[i].SubItems[4].Text.ToString())));
          if (index >= 0)
            FreeIndex.RemoveAt(index);
        }
        catch
        {
          ;
        }
      }

      if (FreeIndex.Count > 0)
      {
        FreeIndex.Sort();
        res = FreeIndex[0];
      }
      else
      {
        max++;
        res = max;
      }
      return res;
    }

    /// <summary>
    /// Собирает все задействованные индексы мэк104 до кучи и выводит списком
    /// </summary>
    /// <returns>список всех задействованных индексов мэк104 </returns>
    private List<UInt16> GetListIecIndex()
    {
      List<UInt16> res = new List<ushort>();

      foreach (ListViewItem item in this.listView1.Items)
      {
        try
        {
          res.Add(ushort.Parse(item.SubItems[4].Text));
        }
        catch
        {
          ;
        }
      }
      return res;
    }

    /// <summary>
    /// Сбор информации об всех задействованных тегах модбас
    /// </summary>
    /// <returns></returns>
    private List<ModbusTag> GetListUsedTags()
    {
      List<ModbusTag> mbList = new List<ModbusTag>();

      foreach(ListViewItem item in this.listView1.Items)
      {
        try
        {
          ModbusTag mb = new ModbusTag();
          string[] a = item.SubItems[3].Text.Split(new[] { ' ' }, 2);
          mb.DevAddr = byte.Parse(item.SubItems[1].Text);
          mb.CmdNum = byte.Parse(item.SubItems[2].Text);
          mb.TagAddr = ushort.Parse(a[0].ToString());
          mb.IecIndex = ushort.Parse(item.SubItems[4].Text);
          mb.DbzVal = byte.Parse(item.SubItems[5].Text);
          mbList.Add(mb);
        }
        catch { }
      }
      return mbList;
    }

    /// <summary>
    /// Перенумерация в списке тегов в случае изменения
    /// </summary>
    private void RenumberItems()
    {
      for (ushort i = 0; i < listView1.Items.Count; i++)
      {
        listView1.Items[i].Text = (i + 1).ToString();
      }
    }

    /// <summary>
    /// Сортировка тегов модбас
    /// </summary>
    private void TagsSort()
    {
      listView1.ListViewItemSorter = new ListViewItemTagComparer();
      listView1.Sort();
      RenumberItems();
    }
    #endregion //Вспомогательные методы


    #region Обработка кнопок собственных
    /// <summary>
    /// Добавление нового тега модбас
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void bAddTag_Click(object sender, EventArgs e)
    {
      if (TagCount < MAX_MB_ITEMS)
      {
        List<ushort> UsedIndex = this.GetListIecIndex();
        List<ModbusTag> mbUsed = this.GetListUsedTags();
        
        //ModbusTag mb = new ModbusTag();//последний добавленный тег 
        if (mbTag == null)
          mbTag = new ModbusTag(1, 2, 1, 50, 0);
        ushort indexFree = SearchFreeIecIndex(mbTag.DevAddr, mbTag.CmdNum, mbTag.TagAddr);
        mbTag.IecIndex = indexFree;
        using (ModBusAddItemForm frm = new ModBusAddItemForm(mbTag, UsedIndex, mbUsed))
        {
          if (frm.ShowDialog(this) == DialogResult.OK)
          {
            addTag((byte)frm.modbusItem.DevAddr, (byte)frm.modbusItem.CmdNum, 
              (ushort)frm.modbusItem.TagAddr, (ushort)frm.modbusItem.IecIndex, (byte)frm.modbusItem.DbzVal);
            //TagCount++;
            mbTag.DevAddr = (byte)frm.modbusItem.DevAddr;
            mbTag.CmdNum = (byte)frm.modbusItem.CmdNum;
            mbTag.TagAddr = (ushort)frm.modbusItem.TagAddr;
            mbTag.IecIndex = (ushort)frm.modbusItem.IecIndex;
            mbTag.DbzVal = (byte)frm.modbusItem.DbzVal;
            bDeleteTag.Enabled = true;
            bCorrectTag.Enabled = true;
            TagsSort();
          }
        }
      }
      else
        MessageBox.Show("Достигнуто максимальное количество тегов для устройства");
    }

    private void bDeleteTag_Click(object sender, EventArgs e)
    {
      TagCount = DeleteTag();
      if (TagCount == 0)
      {
        bDeleteTag.Enabled = 
        bCorrectTag.Enabled = false;
      }
    }

    private void bCorrectTag_Click(object sender, EventArgs e)
    {
      try
      {
        List<ushort> UsedIndex = this.GetListIecIndex();
        List<ModbusTag> mbUsed = this.GetListUsedTags();
        
        int i = listView1.FocusedItem.Index;
        string[] a = listView1.Items[i].SubItems[3].Text.Split(new[] { ' ' }, 2);
        ModbusTag mb = new ModbusTag(byte.Parse(listView1.Items[i].SubItems[1].Text.ToString()),
          byte.Parse(listView1.Items[i].SubItems[2].Text.ToString()),
          UInt16.Parse(a[0].ToString()),
          ushort.Parse(listView1.Items[i].SubItems[4].Text.ToString()),
          byte.Parse(listView1.Items[i].SubItems[5].Text.ToString()));///XXX
        mbUsed.Remove(mb);
        UsedIndex.Remove(mb.IecIndex);
        try
        {
          using (ModBusAddItemForm frm = new ModBusAddItemForm(mb, UsedIndex, mbUsed,(ushort)(i + 1)))
          {
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
              int devAddr = frm.modbusItem.DevAddr;
              int cmdNum = frm.modbusItem.CmdNum;
              int TagAddr = frm.modbusItem.TagAddr;
              int IecIndex = frm.modbusItem.IecIndex;
              int dbz = frm.modbusItem.DbzVal;

              listView1.Items[i].SubItems[1].Text = devAddr.ToString();
              listView1.Items[i].SubItems[2].Text = cmdNum.ToString();
              listView1.Items[i].SubItems[3].Text = TagAddr.ToString() + 
                "  |  [0x" + Convert.ToString(frm.modbusItem.TagAddr, 16).ToUpper() + "]";
              listView1.Items[i].SubItems[4].Text = IecIndex.ToString();
              listView1.Items[i].SubItems[5].Text = dbz.ToString();
              TagsSort();
            }
          }
        }
        catch { }
      }
      catch
      {
        MessageBox.Show("Не выделен тег для исправления", "Внимание");
      }
    }

    private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      using (ModbusLabelForm mlf = new ModbusLabelForm(listView1.SelectedItems[0].SubItems[6].Text))
      {
        if (mlf.ShowDialog(this) == DialogResult.OK)
        {
          listView1.SelectedItems[0].SubItems[6].Text = mlf.labelModbus;
        }
      }
    }

    private void bAddLabel_Click(object sender, EventArgs e)
    {
      if (listView1.SelectedItems.Count < 1)
      {
        MessageBox.Show("Не выделен тег для редактирования тега", "Внимание");
        return;
      }
      this.listView1_MouseDoubleClick(this, (MouseEventArgs)e);
    }
#endregion //Обработка кнопок

    
    /// <summary>
    /// Объединение всех строк таблицы в единую текстовую строку для сохранения в текстовый файл
    /// </summary>
    /// <returns></returns>
    public string[] GetTableAsStrings()
    {
      string[] res = new string[listView1.Items.Count];

      for (byte i = 0; i < listView1.Items.Count; i++)
        res[i] = $"{listView1.Items[i].Text}:{listView1.Items[i].SubItems[1].Text}:{listView1.Items[i].SubItems[2].Text}:" +
           $"{listView1.Items[i].SubItems[3].Text}:{listView1.Items[i].SubItems[4].Text}:" +
           $"{listView1.Items[i].SubItems[5].Text}:{listView1.Items[i].SubItems[6].Text}";
      return res;
    }

    public string GetGzip()
    {
      string res = "";
      if(listView1.Items.Count == 0)
      {
        res = "AAAAAA==";
      }
      else
      {
         StringBuilder sb = new StringBuilder();
        for (int i = 0; i < listView1.Items.Count; i++)
        {
          sb.Append(listView1.Items[i].SubItems[6].Text);
          sb.Append(";");
        }
        sb.Remove(sb.Length - 1, 1);
        res = Compress(sb.ToString());
      }
      
      return res;
    }
    
    /// <summary>
    /// Вывод списка меток тегов модбас после чтения из Gzip
    /// </summary>
    /// <param name="input"></param>
    public void AssetGzip(string input)
    {
      // Распаковка из Gzip
      string lbl = Decompress(input);
      if (string.IsNullOrEmpty(lbl))
        return;
      //Разбивка на строки
      string[] res = lbl.Split(new char[] { ';' }, StringSplitOptions.None);
      for(int i = 0; i < res.Length; i++)//Запись соотствующих строк в таблицу
        listView1.Items[i].SubItems[6].Text = res[i];
    }

    //Обработка Gzip
    #region Gzip 
    private static string Decompress(string input)
    {
      try
      {
        byte[] compressed = Convert.FromBase64String(input);
        byte[] decompressed = Decompress(compressed);
        return Encoding.UTF8.GetString(decompressed);
      }
      catch(FormatException)
      {
        throw new ArgumentException("Некорректная сигнатура массива описания тегов модбас");
      }
      catch(Exception ex)
      {
        throw ex;
      }
    }

    private static string Compress(string input)
    {
      byte[] encoded = Encoding.UTF8.GetBytes(input);
      byte[] compressed = Compress(encoded);
      return Convert.ToBase64String(compressed);
    }

    private static byte[] Decompress(byte[] input)
    {
      using (var source = new MemoryStream(input))
      {
        byte[] lengthBytes = new byte[4];
        source.Read(lengthBytes, 0, 4);

        var length = BitConverter.ToInt32(lengthBytes, 0);
        using (var decompressionStream = new GZipStream(source,
            CompressionMode.Decompress))
        {
          var result = new byte[length];
          decompressionStream.Read(result, 0, length);
          return result;
        }
      }
    }

    private static byte[] Compress(byte[] input)
    {
      using (var result = new MemoryStream())
      {
        var lengthBytes = BitConverter.GetBytes(input.Length);
        result.Write(lengthBytes, 0, 4);

        using (var compressionStream = new GZipStream(result,
            CompressionMode.Compress))
        {
          compressionStream.Write(input, 0, input.Length);
          compressionStream.Flush();

        }
        return result.ToArray();
      }
    }
    #endregion //Gzip
  }

  /// <summary>
  /// Класс сравнения полей тегов модбас для сортировки
  /// </summary>
  class ListViewItemTagComparer : IComparer
  {
    /// <summary>
    /// Направление сортировки
    /// </summary>
    private SortOrder order;

    public ListViewItemTagComparer()
    {
      order = SortOrder.Ascending;
    }

    public int Compare(object x, object y)
    {
      int returnVal;
      int firstVal;
      int secondVal;
      firstVal = Int32.Parse(((ListViewItem)x).SubItems[2].Text);
      secondVal = Int32.Parse(((ListViewItem)y).SubItems[2].Text);

      if (firstVal > secondVal)
        returnVal = 1;
      else if (firstVal < secondVal)
        returnVal = -1;
      else
      {
        firstVal = Int32.Parse(((ListViewItem)x).SubItems[1].Text);
        secondVal = Int32.Parse(((ListViewItem)y).SubItems[1].Text);
        if (firstVal > secondVal)
          returnVal = 1;
        else if (firstVal < secondVal)
          returnVal = -1;
        else
        {
          string[] a = ((ListViewItem)x).SubItems[3].Text.Split(new[] { ' ' }, 2);
          firstVal = Int32.Parse(a[0].ToString());
          string[] b = ((ListViewItem)y).SubItems[3].Text.Split(new[] { ' ' }, 2);
          secondVal = Int32.Parse(b[0].ToString());
          if (firstVal > secondVal)
            returnVal = 1;
          else if (firstVal < secondVal)
            returnVal = -1;
          else
            returnVal = 0;
        }
      }

      if (order == SortOrder.Descending)
        returnVal *= -1;
      return returnVal;
    }
  }
}
