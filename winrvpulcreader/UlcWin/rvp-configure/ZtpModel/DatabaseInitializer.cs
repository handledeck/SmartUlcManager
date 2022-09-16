using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ztp.Model
{
  /// <summary>
  /// инициализация БД (XXX судя по всему нигде не используется)
  /// </summary>
  public static class DatabaseInitializer
  {
    public static void CreateIfNotExists(QueryBuilder.Data.AnyDb.AnyDbFactory factory)
    {
      if (factory == null) throw new ArgumentNullException(nameof(factory));
      if (!factory.ExistsDatabase())
        factory.CreateDatabase();
    }

    public static void CreateNewAllways(QueryBuilder.Data.AnyDb.AnyDbFactory factory)
    {
      if (factory == null) throw new ArgumentNullException(nameof(factory));
      if (factory.ExistsDatabase())
        factory.DropDatabase();
      factory.CreateDatabase();
    }

  }
}
