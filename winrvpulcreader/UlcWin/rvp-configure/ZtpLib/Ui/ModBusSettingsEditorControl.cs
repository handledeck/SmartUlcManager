using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Ztp.Utils;


namespace Ztp.Ui
{
  public partial class ModBusSettingsEditorControl : UserControl
  {
    private int TagCount;
    public byte[] dat;
    public ushort dat_size;

    #region Делегаты
    //Управление загрузкой конфигурации на устройство
    public delegate void ModbusUploadHandler();
    public event ModbusUploadHandler Upload;

    //Управление считыванием конфигурации с устройства
    public delegate void ModbusDownloadHandler();
    public event ModbusDownloadHandler Download;

    //Управление видимостью панельки с таблицей тегов модбас
    public delegate void mbChangeVisibleTagTable(bool value);
    public event mbChangeVisibleTagTable TagTableVisible;

    //Управление добавлением тега в таблицу
    public delegate void mbAddItem(byte addr, byte cmd, ushort fieldAddr, ushort iecIndex, byte dbz);
    public event mbAddItem TagTableAddItem;

    //очистка таблицы от тегов
    public delegate void mbClearTable();
    public event mbClearTable clTable;

    //доступ к данных таблицы с форматированием для отправки на устройство
    public delegate byte[] mbGetCollection();
    public event mbGetCollection getCollectionFromTable;

    //вычитка массива строк из другой панели
    public delegate string[] mbGetsStrings();
    public event mbGetsStrings getStringsTable;

    //вычитка строки Gzip base64
    public delegate string mbGetGzipLabel();
    public event mbGetGzipLabel getGzipLabel;

    public delegate void mbSetLabelsFromGzip(string input);
    public event mbSetLabelsFromGzip LoadMBLabels;
    #endregion //Делегаты

    public ModBusSettingsEditorControl()
    {
      InitializeComponent();
      dat = new byte[1024];
      dat_size = 0;
      TagCount = 0;
      cbWorkMode.SelectedIndex = 0;
      Height = 80;
      pModBusitems.Height = 26;
      pModBusitems.Show();
      this.Refresh();
    }

    #region PROPERTIES
    public byte[] Value
    {
      set
      {
        Assign(value);
      }
    }

    /// <summary>
    /// Проверка статуса режима работы с модбас
    /// </summary>
    public bool ModbusDisable
    {
      get
      {
        return cbWorkMode.SelectedIndex == 0 ? true : false;
      }
    }
    #endregion

    

    #region Обработчики событий
    private void cbWorkMode_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (cbWorkMode.SelectedIndex == 0)
      {
        //pModBusitems.Hide();
        pModBusitems.Height = 26;
        ToThCanal();
        this.Height = 80;//107;
      }
      else
      {
        //pModBusitems.Show();
        pModBusitems.Height = 92;
        ToModbusCanal();
        this.Height = 143;
      }
      ViewModbus((cbWorkMode.SelectedIndex == 0) ? false : true);
    }
    public void ViewReset()
    {
      cbWorkMode.SelectedIndex = 0;
      ViewModbus(false);
      this.Hide();
    }

    public void ViewModbus(bool val)
    {
      TagTableVisible?.Invoke(val);
    }

    private void ToThCanal()
    {
      bLoadMB.Location = new System.Drawing.Point(10, 3);
      bLoadMB.Text = "Прочитать конфигурацию";
      bLoadMB.Width = 150;

      bUpload.Location = new System.Drawing.Point(270, 3);
      bUpload.Text = "Записать конфигурацию";
      bUpload.Width = 150;
    }

    private void ToModbusCanal()
    {
      bLoadMB.Location = new System.Drawing.Point(149,3);
      bLoadMB.Text = "Прочитать список тегов с устройства";
      bLoadMB.Width = 275;

      bUpload.Location = new System.Drawing.Point(149,32);
      bUpload.Text = "Загрузить список тегов модбас в устройство";
      bUpload.Width = 275;
    }

    /// <summary>
    /// Обработка нажатия кнопки с записью конфигурации модбас в устройство
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void bUpload_Click(object sender, EventArgs e)
    {
      Collectmodbus();
    }

    /// <summary>
    /// Обработка нажатия кнопки считывания конфига модбас с устройства
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void bLoadMB_Click(object sender, EventArgs e)
    {
      Download?.Invoke();
    }

    /// <summary>
    /// Обработчик кнопки загрузки конфигурации из файла
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void bMBLoad_Click(object sender, EventArgs e)
    {
      ofd.Filter = $"Конфигурация (*.mbcfg)|*.mbcfg";
      ofd.DefaultExt = "mbcfg";
      if (ofd.ShowDialog(this) == DialogResult.OK)
      {
        string path = ofd.FileName;
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
          BinaryReader br = new BinaryReader(fs);
          long numBytes = new FileInfo(path).Length;
          byte[] buff = br.ReadBytes((int)numBytes);
          int phase = Assign(buff);
          Int16 size = BitConverter.ToInt16(buff, phase);
          byte[] lbl = new byte[size];
          Array.Copy(buff, phase + 2, lbl, 0, size);
          string a = Encoding.UTF8.GetString(lbl);
          //Передача на парсинг строки gzip и распихивание по строчкам описания.
          LoadMBLabels?.Invoke(a);
        }
      }
    }

    private void bMBSave_Click(object sender, EventArgs e)
    {
      sfd.FileName = "";
      sfd.Filter = $"Конфигурация (*.mbcfg)|*.mbcfg| Список (*.txt)|*.txt";
      sfd.DefaultExt = "mbcfg";
      if (sfd.ShowDialog(this) == DialogResult.OK)
      {
        string path = sfd.FileName;
        if (path.Contains(".mbcfg"))
        {
          using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
          {
            BinaryWriter bw = new BinaryWriter(fs);
            byte[] buff = getMbMassive();
            int numBytes = buff.Length;
            bw.Write(buff, 0, numBytes);
            //Добавление Gzip - кол-во байт + сам строка base64 от Gzip
            string gzip = getGzipLabel?.Invoke();
            byte[] bufGzip = Encoding.UTF8.GetBytes(gzip);
            bw.Write((short)bufGzip.Length); //спецом чтобы было 2 байта
            bw.Write(bufGzip, 0, bufGzip.Length);
          }
        }
        else //Сохранение таблицы в текстовый файл
        {
          string[] res = getStringsTable?.Invoke();
          var table = new Table
          {
            Padding = 1,
            HeaderTextAlignRight = false,
            RowTextAlignRight = true
          };
          table.AddRow("##", "Адрес", "Команда", "Поле", "iec-index", "зона нечувств.,%","Описание");
          for (byte i = 0; i < res.Length; i++)
          {
            ConvertString(res[i], ref table);
          }
          using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
          {
            using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
            {
              sw.WriteLine(table.ToString());
            }
          }
        }
      }
    }

    #endregion


    /// <summary>
    /// Формирование массива конфигурации тегов модбас
    /// </summary>
    /// <returns></returns>
    private byte[] getMbMassive()
    {
      dat = new byte[1024];
      dat_size = 0;

      //запись статуса работы с протоколом модбас
      dat[dat_size] = (byte)cbWorkMode.SelectedIndex;
      dat_size++;
      
      //запись значения периода опроса
      dat[dat_size] = (byte)idPollPeriod.Value;
      dat_size++;

      //формирование групп тегов в массив, в конец добавляется массив 
      // 2хбайтных значений индексов мэк
      byte[] info = getCollectionFromTable?.Invoke();
      info.CopyTo(dat, dat_size);
      dat_size += (ushort)info.Length;
      //Обрезка до нужных размеров массива
      Array.Resize<byte>(ref dat, dat_size);
      return dat;
    }

    /// <summary>
    /// Инициализация загрузки конфигурации на устройство
    /// </summary>
    public void Collectmodbus()
    {
      getMbMassive();
      Upload?.Invoke();
    }

    /// <summary>
    /// Форматирование строки для добавления в текстовую таблицу
    /// </summary>
    /// <param name="val"></param>
    /// <param name="tb"></param>
    private void ConvertString(string val, ref Table tb)
    {
      string[] tmp = val.Split(new char[] { ':' }, StringSplitOptions.None);
      tmp[3] = tmp[3].Replace('|', '-');
      tb.AddRow(tmp[0], tmp[1], tmp[2], tmp[3], tmp[4], tmp[5], tmp[6]);
    }

    /// <summary>
    /// Отображение конфигурации модбас в формах
    /// </summary>
    /// <param name="buf"></param>
    /// <returns></returns>
    int Assign(byte[] buf)
    {
      int s = 0;
      cbWorkMode.SelectedIndex = buf[s++];
      byte pollPeriod = buf[s++];
      idPollPeriod.Value = (pollPeriod == 0) ? 1 : pollPeriod;
      Int16 count = BitConverter.ToInt16(buf, s);
      s += 2;

      clTable?.Invoke();

      TagCount = 0;
      int pointToIecIndexStart = 4 + count * 4;
      int pointToDbzIndexStart = pointToIecIndexStart + count * 2;

      for (int i = 0; i < count; i++)
      {
        UInt16 val = BitConverter.ToUInt16(buf, s + 2);
        //Проверка если за диапазоном длины то обнуляем значение 
        UInt16 iecIndex = (pointToIecIndexStart + (i * 2) < buf.Length) ?
          BitConverter.ToUInt16(buf, pointToIecIndexStart + i * 2) : (UInt16)0;
        byte dbzVal = ((pointToDbzIndexStart + i) < buf.Length) ?
          buf[pointToDbzIndexStart + i] : (byte)0;
        TagTableAddItem?.Invoke(buf[s], buf[s + 1], val, (ushort)iecIndex, dbzVal);
        s += 4;
        TagCount++;
      }

      if (count > 0)
        s += count * 3 + 1;
      else
        s = -1;

      return s;
    }

    //public override 
  }
}
