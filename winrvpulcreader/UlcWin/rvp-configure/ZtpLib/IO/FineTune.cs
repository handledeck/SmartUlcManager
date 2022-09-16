using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace Ztp.IO
{
  /// <summary>Тонкие настройки компонентов системы/> </summary>
  public partial class FineTune
  {
    static string fullfileName;

    /// <summary>Инициализируется один раз в рантайме</summary>
    internal static void FirstInit()
    {
    }

    /// <summary>
    /// Полное имя файла
    /// </summary>
    public string FileName
    {
      get { return fullfileName; }
    }

    Dictionary<string, Data> keyValue = new Dictionary<string, Data>();

    /// <summary>Загрузить настройку из папки <see cref="Folders.EtcComponentsPath"/></summary>
    /// <param name="fileNameWithoutExtension">Имя загружаемого файла без расширения и пути. Расширение по умолчанию cfg</param>
    /// <returns></returns>
    public static FineTune TryLoad(string fileNameWithoutExtension)
    {
      var result = new FineTune();
      result.Init(true, fileNameWithoutExtension + ".cfg");
      return result;
    }

    internal FineTune() { }

    /// <summary>Загрузить текст</summary>
    internal static FineTune TryLoadBody(string text)
    {
      var result = new FineTune();
      result.Init(false, text);
      return result;
    }

    /// <summary>Формат даты и времени используемый в конфигурациях dd/MM/yyyy HH:mm:ss или "dd/MM/yyyy</summary>
    private static readonly string[] FormatDateTime = new string[] {"dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy"};

    /// <summary>Преобразовать в формат который принят в конфигах</summary>
    public static DateTime ToDateTimeUtc(string val)
    {
      return DateTime.ParseExact(val, FormatDateTime, CultureInfo.InvariantCulture, DateTimeStyles.None);
    }

    internal class KeyValueIndx
    {
      public string Key;
      public string Value;
      public int Line;

      public KeyValueIndx(string key, string value, int line)
      {
        this.Key = key;
        this.Value = value;
        this.Line = line;
      }
    }

    /// <param name="isfileName">true- значит имя файла, false - сам текст</param>
    /// <param name="fileNameOrBody">Имя файла или содержимое файла</param>
    /// <returns></returns>
    private IEnumerable<KeyValueIndx> ReadLine(bool isfileName, string fileNameOrBody)
    {
      int lineCount = 0;

      TextReader reader = null;
      if (isfileName) reader = new StreamReader(fileNameOrBody);
      else reader = new StringReader(fileNameOrBody);
      using (reader)
      {
        while (true)
        {
          lineCount++;
          string line = reader.ReadLine();
          if (line == null) break;
          if (line.StartsWith("#")) continue; //Значит коментарий
          if (line == "") continue;
          var vals = line.Split(new char[] { '=' });
          if (vals.Length < 2)
            continue;
          KeyValueIndx kv;
          if (vals.Length == 2)
            kv = new KeyValueIndx(vals[0].Trim().ToLower(), vals[1].Trim(), lineCount);
          else
          {
            int pos = line.IndexOf("=");
            string key = vals[0].Trim().ToLower();
            string value = line.Remove(0, pos + 1).Trim();
            kv = new KeyValueIndx(key, value, lineCount);
          }
          yield return kv;
        }
      }
    }

    internal void Init(bool isfileName, string fileNameOrBody)
    {
      string fn = fileNameOrBody;
      if (isfileName)
      {
        fullfileName = Path.Combine(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), fileNameOrBody);
        if (!File.Exists(fullfileName))
        {
          //генерация  файла конфигурации как заводская...
          //File.Create(fullfileName);
          StreamWriter fs = new StreamWriter(new FileStream(fullfileName, FileMode.CreateNew), System.Text.Encoding.UTF8);//File.CreateText(fullfileName);
          
          fs.WriteLine(@"# Таймаут (сек) выполнения команды SQL
Db.CommandTimeout = 30
# Идентификатор испульзуемой БД. Допустимые значения: MySql
Db.DatabaseProvider = MySql
# Строка соединения с БД
Db.ConnectionString = server=127.0.0.1;port=3306;database=ztp;uid=root;pwd=root;

# Максимальный уровень вложенности узлов дерева (начиная с 0). На последнем уровне располагаются узлы устройств.
Tree.MaxNodeLevel = 3

# Максимальное количество устройств, которые могут опрашиваться одновременно. 
# Диапазон значений 1-60. Значение по умолчанию: 20
DeviceAccessLayer.ConcurrentQuerySize = 20
");
          fs.Close();
          //наполнение файла
          //return;
        }
        fn = fullfileName;
      }
      else fullfileName = "bodyText";

      try
      {
        foreach (var item in ReadLine(isfileName, fn))
        {
          var key = item.Key;
          if (keyValue.ContainsKey(key))
          {
            continue;
          }
          if (key.EndsWith("]")) //Значит идет привязка к ID
          {
            int index = key.LastIndexOfAny(new char[] { '[' });
            if (index <= 0) continue;
            var newkey = key.Remove(index, key.Length - index);
            var valscob = key.Substring(index + 1, key.Length - index - 2).Trim();
            int id;
            if (!int.TryParse(valscob, out id))
            {
              continue;
            }
            Data data;
            if (!keyValue.TryGetValue(newkey, out data))
            {
              data = new Data(String.Empty, 0, this);
              keyValue.Add(newkey, data);
            }

            data.AddId(id, new Data(item.Value, item.Line, this));
          }
          else keyValue.Add(item.Key, new Data(item.Value, item.Line, this));
        }
      }
      catch (Exception e)
      {
        string str = e.Message;
        throw;
      }
    }

    /// <summary>Прочить значение из файла</summary>
    /// <typeparam name="T">Тип считываемого значения</typeparam>
    /// <param name="keyName">Ключ регистронезависимый</param>
    /// <param name="convert">Функция конвертирования полученного значения</param>
    /// <param name="defaultVal">Значение по умолчанию если оно не найдено в файле</param>
    /// <summary>Прочить значение из файла</summary>
    /// <typeparam name="T">Тип считываемого значения</typeparam>
    /// <param name="keyName">Ключ регистронезависимый</param>
    /// <param name="component">Идентификатор ресурса системы задается в файле как vvv[123]=10. 
    /// При поиске если задан общий идентификатор vvv=20 и запрашивается vvv[1] то вернется 20 т.е. от vvv=20</param>
    /// <param name="convert">Функция конвертирования полученного значения</param>
    /// <param name="defaultVal">Значение по умолчанию если оно не найдено в файле</param>
    public T ReadValue<T>(string keyName, Func<string, T> convert, T defaultVal = default(T))
    {
      keyName = keyName.ToLower();
      T result = default(T);
      Data value;
      if (!keyValue.TryGetValue(keyName, out value))
      {
        result = defaultVal;
      }
      else
      {
        result = convert(value.Value);
      }
      return result;
    }



    /// <summary>Прочить ключ.значение по совпадению от начала строки. Аналог String.StartWith</summary>
    /// <param name="keyWith">Строка поиска регистронезависимая</param>
    public IList<KeyValuePair<string, Data>> ReadStartWith(string keyWith)
    {
      keyWith = keyWith.ToLower();
      var result = new List<KeyValuePair<string, Data>>();
      foreach (var item in keyValue)
      {
        if (item.Key.StartsWith(keyWith)) result.Add(item);
      }
      return result;
    }

    /// <summary>
    /// Сопирование с заменой или добовлением по ключю значения
    /// </summary>
    /// <param name="sourceFileName">Исходный файл</param>
    /// <param name="destFileName">Копируемый файл</param>
    /// <param name="key">Ключ</param>
    /// <param name="val">Значение</param>
    public static void CopyAndChangeOrAddKeyVal(string sourceFileName, string destFileName, string key, string val)
    {
      StreamReader reader = null;
      StreamWriter writer = null;
      try
      {
        bool search = false;
        reader = new StreamReader(sourceFileName);
        writer = new StreamWriter(destFileName, false);
        while (true)
        {
          var line = reader.ReadLine();

          bool laststr = line == null;


          if (!laststr)
          {
            if (line.StartsWith(key))
            {
              writer.WriteLine("{0} = {1}", key, val);
              search = true;
            }
            else writer.WriteLine(line);
          }
          else
          {
            if (!search) writer.WriteLine("{0} = {1}", key, val);
            break;
          }
        }
      }
      finally
      {
        try
        {
          if (reader != null) reader.Close();
        }
        catch
        {
        }
        try
        {
          if (writer != null) writer.Close();
        }
        catch
        {
        }
      }
    }

  }
}
