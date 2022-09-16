using QueryBuilder;

namespace Ztp
{
  public class DatabaseSetting: QueryBuilder.Data.AnyDb.IAnyDbSetting
  {
    public DatabaseProvider DatabaseProvider { get; set; }
    public string ConnectionString { get; set; }
    public int CommandTimeout { get; set; }
  }

}