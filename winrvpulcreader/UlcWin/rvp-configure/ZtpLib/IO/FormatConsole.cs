using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ztp.IO
{
  /// <summary>Форматирование справки</summary>
  public class HelpForm
  {
    /// <summary>Ключ</summary>
    public string Key;
    /// <summary>Описание</summary>
    public string Description;

    /// <summary>Конструктор</summary>
    public HelpForm(string key, string description)
    {
      this.Key = key;
      this.Description = description;
    }
  }

  /// <summary>Форматирует сообщение выводимое на консоль. С учетом переноса слов и т.д.</summary>
  public static class FormatConsole
  {
    static void AppendSpace(StringBuilder sb, int count)
    {
      for (int i = 0; i < count; i++)
      {
        sb.Append(' ');
      }
    }

    /// <summary>Выравнить перенос по слову</summary>
    internal static int ToPositonWrapWord(string s, int offset, int count, int lenwrap = 15)
    {
      if (count < lenwrap) lenwrap = count;
      if (s.Length <= offset + count) return s.Length - offset;
      for (int i = offset + count; i > offset + count - lenwrap; i--)
      {
        if (s[i] == ' ')
        {
          return (i - offset);
        }
      }
      return count;
    }

    /// <summary>Ширина консоли по умолчанию</summary>
    public const int WithDefault = 80;
    /// <summary>Смещение от которого начинается вывод описания</summary>
    public const int OffsetKeyDefault = 36;

    /// <summary>Форматировать подсказку</summary>
    /// <param name="helps">Массив подсказок</param>
    /// <param name="width">Ширина консоли</param>
    /// <param name="offsetKey">Смещение от которого начинается вывод описания</param>
    public static StringBuilder Format(IList<HelpForm> helps, int width = 80, int offsetKey = 36)
    {
      if (width < WithDefault) width = WithDefault;

      StringBuilder sb = new StringBuilder();

      var items_count = helps.Count;
      foreach (var item in helps)
      {
        int saveOffs = sb.Length;

        sb.Append(item.Key);
        int count = offsetKey - (sb.Length - saveOffs);
        AppendSpace(sb, count);

        int curStr = 0;

        while (curStr < item.Description.Length)
        {
          int realWrite = ToPositonWrapWord(item.Description, curStr, width - offsetKey - 1);
          for (int n = 0; n < realWrite; n++)
          {
            sb.Append(item.Description[curStr++]);
          }
          if (curStr < item.Description.Length)
          {
            if (item.Description[curStr] == ' ') curStr++; //Игнорируем пробел если он последний в строке т.к. вместо него будет перевод каретки
            sb.AppendLine();
            AppendSpace(sb, offsetKey);
          }
        }
        items_count--;
        if (items_count != 0) sb.AppendLine();
      }
      return sb;
    }
  }
}
