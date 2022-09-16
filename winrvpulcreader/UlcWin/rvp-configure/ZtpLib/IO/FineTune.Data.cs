using System;
using System.Collections.Generic;
using GIDI = System.Int32;

namespace Ztp.IO
{
  /// <summary>Тонкие настройки компонентов системы. Находятся в <see cref="Folders.EtcComponentsPath"/> </summary>
  public partial class FineTune
  {
    /// <summary>Строка настроек</summary>
    public class Data
    {
      string val;
      int line;
      FineTune parent;

      internal Data(string val, int line, FineTune parent)
      {
        this.val = val;
        this.line = line;
        this.parent = parent;
      }

      /// <summary>Получить строковое представление</summary>
      public string Value
      {
        get { return val; }
      }
      /// <summary>Является значение пустым</summary>
      public bool IsEmpty
      {
        get { return String.IsNullOrEmpty(val); }
      }

      /// <summary>Прочить массив значений</summary>
      public Data[] ReadArray()
      {
        if (IsEmpty) return new Data[0];
        var spl = val.Split('|');
        Data[] result = new Data[spl.Length];

        for (int i = 0; i < result.Length; i++)
        {
          result[i] = new Data(spl[i].Trim(), line, parent);
        }

        return result;
      }


      /// <summary>Прочить значение</summary>
      /// <typeparam name="T">Тип считываемого значения</typeparam>
      /// <param name="convert">Функция конвертирования полученного значения</param>
      /// <param name="defaultVal">Значение по умолчанию если оно не найдено в файле</param>
      public T ReadValue<T>(Func<string, T> convert, T defaultVal = default(T))
      {
        T result;
        if (String.IsNullOrEmpty(val))
        {
          result = defaultVal;
        }
        else
        {
          try
          {
            result = convert(val);
          }
          catch
          {
            result = defaultVal;
          }
        }

        return result;
      }

      /// <summary>
      /// Данный механизм ddd[12]=2 сделан именно так для того чтобы в последствии можно было добавить 
      /// поиск по префексу ddd['val*']=2
      /// </summary>
      Dictionary<GIDI, Data> ids = new Dictionary<GIDI, Data>();
      internal void AddId(GIDI id, Data data)
      {
        if (ids.ContainsKey(id)) return;
        ids.Add(id, data);
      }
    }
  }
}
