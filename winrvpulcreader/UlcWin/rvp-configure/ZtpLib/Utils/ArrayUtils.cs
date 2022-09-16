using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ztp.Utils
{
  public static class ArrayUtils
  {
    /// <summary>
    /// Создает постраничную неполную копию диапазона элементов исходного списка
    /// </summary>
    /// <typeparam name="T">Тип элементов списка</typeparam>
    /// <param name="sourceArray">Исходный список</param>
    /// <param name="pageNum">Отсчитываемый от нуля номер страницы</param>
    /// <param name="pageSize">Размер страницы</param>
    /// <param name="hasMoreData">Признак возможности чтения следующей страницы</param>
    /// <returns>Неполная копия диапазона элементов исходного списка</returns>
    /// <remarks>
    /// Неполная копия коллекции ссылочных типов или подмножества такой коллекции содержит 
    /// только ссылки на элементы коллекции. Сами объекты не копируются. Ссылки в новом 
    /// списке указывают на те же объекты, что и ссылки в исходном списке.Неполная копия 
    /// коллекции типов значений или подмножества такой коллекции содержит элементы 
    /// коллекции. Однако если элементы коллекции содержат ссылки на другие объекты, эти 
    /// объекты не копируются. Ссылки в элементах новой коллекции указывают на те же объекты, 
    /// что и ссылки в элементах исходной коллекции.
    /// </remarks>
    public static IList<T> ListPaging<T>(IList<T> sourceArray, int pageNum, int pageSize, out bool hasMoreData)
    {
      hasMoreData = false;
      int startIndex, endIndex;
      bool ok = TryPagingIndexesOfArray(sourceArray.Count, pageNum, pageSize, out startIndex, out endIndex, out hasMoreData);
      if (!ok) return new List<T>();
      IList<T> retVal = new T[endIndex - startIndex + 1];
      int index = 0;
      for (int i = startIndex; i <= endIndex; i++)
        retVal[index++] = sourceArray[i];
      return retVal;
    }

    /// <summary>
    /// Получить индексы элементов массива при постраничном доступе
    /// </summary>
    /// <param name="sourceArrayLength">Длина исходного массива</param>
    /// <param name="pageNum">Отсчитываемый от нуля номер страницы</param>
    /// <param name="pageSize">Размер страницы</param>
    /// <param name="startIndex">Номер элемента массива с которого начинается указанная страница</param>
    /// <param name="endIndex">Номер элемента массива которым заканчивается указанная страница</param>
    /// <param name="hasMoreData">Признак возможности чтения следующей страницы</param>
    /// <returns>
    /// Значение true, если указанную страницу можно прочитать из массива; 
    /// в противном случае — значение false.
    /// </returns>
    static bool TryPagingIndexesOfArray(int sourceArrayLength, int pageNum, int pageSize, out int startIndex, out int endIndex, out bool hasMoreData)
    {
      if (pageNum < 0) throw new IndexOutOfRangeException("pageNum");
      if (pageSize < 1) throw new ArgumentException("pageSize");
      hasMoreData = false;
      startIndex = pageNum * pageSize;
      endIndex = startIndex + pageSize - 1;
      if (startIndex > sourceArrayLength - 1) return false;
      if (endIndex > sourceArrayLength - 1) endIndex = sourceArrayLength - 1;
      hasMoreData = endIndex < sourceArrayLength - 1;
      return true;
    }

  }
}
