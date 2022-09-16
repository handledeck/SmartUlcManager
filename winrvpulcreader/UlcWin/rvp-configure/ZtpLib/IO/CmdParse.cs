using System;
using System.Collections.Generic;
using System.Text;

namespace Ztp.IO
{
  /// <summary>Класс элемента коммандной строки</summary>
  public class CmdParseItem
  {
    /// <summary>может быть несколько ключей</summary>
    public bool MultiCmd;
    /// <summary>
    /// идентификатор для поиска через <see cref="CmdParse.Contains"/>
    /// </summary>
    public string Id;
    /// <summary>
    /// ключи коммандной строки
    /// </summary>
    public string[] Keys;
    internal int CountVal;
    /// <summary>Описание значения для Help</summary>
    public string ValDesc;
    /// <summary>Описание ключей</summary>
    public string Desc;
    /// <summary>Обработчик при считывании необходимого ключа</summary>
    public Action<string, string> HandlerRead;
    /// <summary>
    /// Видимость ключа в справке
    /// </summary>
    public bool HideHelp;

    /// <summary>Конструктор для типа коммандной строки key:value с обрабочиком при считывании</summary>
    public CmdParseItem(string id, string key, string valDesc, string desc, System.Action<string, string> handlerRead, bool multiCmd = false)
    {
      this.Id = id;
      this.MultiCmd = multiCmd;
      this.Keys = key.Split('|');
      this.CountVal = 1;
      this.ValDesc = valDesc;
      this.Desc = desc;
      this.HandlerRead = handlerRead;
      this.HideHelp = false;
    }

    /// <summary>Конструктор для типа коммандной строки key</summary>
    public CmdParseItem(string id, string key, string desc, System.Action<string, string> handlerRead)
      : this(id, key, "", desc, handlerRead)
    {
      CountVal = 0;
    }
  }

  /// <summary>Класс разбора коммандной строки</summary>
  public class CmdParse
  {
    private readonly Dictionary<string, List<string>> ParamCmd = new Dictionary<string, List<string>>();
    private Dictionary<string, CmdParseItem> itemCmd;
    private CmdParseItem[] items;

    /// <summary>Разбить по коммандным аргументам строку аналог Environment.GetCommandLineArgs() только с входной строкой</summary>
    /// <param name="cLine">Входная строка аналогичная как при запуске исполняемых файлов</param>
    public static string[] ParseCommandLineInArgs(string cLine)
    {
      
      List<string> result = new List<string>();
      var length = cLine.Length;
      bool body = false;
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < length; i++)
      {
        if (cLine[i] == '"')
        {
          body = !body;
          continue;
        }
        else if ((cLine[i] == ' ') && (!body))
        {
          result.Add(sb.ToString());
          sb.Clear();
          continue;
        }
        sb.Append(cLine[i]);
      }
      if (sb.Length != 0) result.Add(sb.ToString());
      return result.ToArray();
    }

    /// <summary>Получить справку исходя из коммандной строки в конструкторе</summary>
    /// <param name="headerMsg">Заголовок сообщения для справки</param>
    public string Help(params string[] headerMsg)
    {
      return Help(FormatConsole.WithDefault, headerMsg);
    }

    /// <summary>Получить справку исходя из коммандной строки в конструкторе</summary>
    /// <param name="headerMsg">Заголовок сообщения для справки</param>
    /// <param name="width">Ширина консоли</param>
    public string Help(int width, params string[] headerMsg)
    {
      StringBuilder sb = new StringBuilder();

      if (headerMsg != null)
      {
        foreach (var item in headerMsg)
          sb.AppendLine(item);
      }

      List<HelpForm> helps = new List<HelpForm>();

      sb.AppendLine();
      foreach (var item in items)
      {
        StringBuilder sbKey = new StringBuilder();

        if (item.HideHelp) continue;
        var length = item.Keys.Length;
        for (int i = 0; i < length; i++)
        {
          if (item.Keys[i].Length == 1)
            sbKey.Append("-");
          else
            sbKey.Append("--");
          sbKey.Append(item.Keys[i]);
          if (i + 1 < length)
            sbKey.Append(", ");
        }
        if (item.CountVal > 0)
        {
          sbKey.Append(":");
          sbKey.Append(item.ValDesc);
        }

        helps.Add(new HelpForm(sbKey.ToString(), item.Desc));
      }
      sb.Append(FormatConsole.Format(helps, width: width));

      return sb.ToString();
    }

    /// <summary>Разобрать коммандную строку</summary>
    /// <param name="args">Аргументы коммандной строки</param>
    public void Parse(string[] args)
    {
      ParseImp(args);
    }

    /// <summary>Конструктор</summary>
    /// <param name="items">Параметры коммандной строки</param>
    public CmdParse(params CmdParseItem[] items)
    {
      this.items = items;
      itemCmd = new Dictionary<string, CmdParseItem>(items.Length);
      for (int i = 0; i < items.Length; i++)
      {
        foreach (var it in items[i].Keys)
        {
          System.Diagnostics.Debug.Assert(!itemCmd.ContainsKey(it), "CmdParse key add, id: " + items[i].Id);
          itemCmd.Add(it, items[i]);
        }
      }
    }

    /// <summary>Получить значение по ключу</summary>
    /// <param name="id">Идентификатор ключа заданный <see cref="CmdParseItem.Id"/></param>
    /// <param name="defaultVal">Значение по умолчанию</param>
    public string GetValue(string id, string defaultVal)
    {
      string result = defaultVal;

      List<string> list;
      if (ParamCmd.TryGetValue(id, out list))
      {
        result = String.Join("|", list);
      }
      return result;
    }

    /// <summary>Задан ли в коммандной строке ключ</summary>
    /// <param name="id">Идентификатор ключа заданный <see cref="CmdParseItem.Id"/></param>
    public bool Contains(string id)
    {
      return ParamCmd.ContainsKey(id);
    }

    /// <summary>Разобрана ли строка</summary>
    public bool IsEmpty
    {
      get { return (ParamCmd.Count == 0); }
    }

    /// <summary>
    /// Очистить
    /// </summary>
    private void Clear()
    {
      ParamCmd.Clear();
    }

    private void ParseImp(string[] args)
    {
      Clear();
      for (int i = 0; i < args.Length; i++)
      {
        if (args[i].Length < 2) continue;
        string arg;
        if (args[i].StartsWith("--")) arg = args[i].Remove(0, 2);
        else arg = args[i].Remove(0, 1);
        CmdParseItem item;

        string[] keyval;
        var indx = arg.IndexOf(':');
        if (indx < 0)
        {
          keyval = new string[] { arg };
        }
        else
        {
          keyval = new string[] 
          { 
            arg.Remove(indx, arg.Length - indx), 
            arg.Remove(0, indx + 1) 
          };
        }
        if (keyval.Length < 1) continue;
        if (!itemCmd.TryGetValue(keyval[0], out item)) continue;
        if (item.CountVal == 0)
        {
          if (item.HandlerRead != null)
            item.HandlerRead(item.Id, "");
          if (!ParamCmd.ContainsKey(item.Id))
          {
            ParamCmd.Add(item.Id, new List<string>());
          }
        }
        else if (item.CountVal == 1)
        {
          if (keyval.Length != 2) continue;
          bool contains = ParamCmd.ContainsKey(item.Id);

          if ((!contains) || ((contains) && (item.MultiCmd)))
          {
            if (item.HandlerRead != null) item.HandlerRead(item.Id, keyval[1]);
            if (!contains) ParamCmd.Add(item.Id, new List<string>());
            ParamCmd[item.Id].Add(keyval[1]);
          }
        }
      }
    }
  }
}
