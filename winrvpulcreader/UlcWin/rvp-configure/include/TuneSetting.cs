using System;
using QueryBuilder;
using Ztp.IO;

namespace Ztp
{
  public class TuneSetting
  {
    readonly Ztp.IO.FineTune _tune;

    TuneSetting()
    {
      _tune = FineTune.TryLoad("setting");
    }

    private static TuneSetting _default;

    public static TuneSetting Default
    {
      get
      {
        if(_default == null)
          _default = new TuneSetting();
        return _default;
      }
    }

    private DatabaseSetting _databaseSetting;

    public DatabaseSetting DatabaseSetting
    {
      get
      {
        if (_databaseSetting == null)
        {
          _databaseSetting = new DatabaseSetting();
          _databaseSetting.CommandTimeout = _tune.ReadValue("Db.CommandTimeout", (s) => int.Parse(s));
          _databaseSetting.ConnectionString = _tune.ReadValue("Db.ConnectionString", (s) => s);
          _databaseSetting.DatabaseProvider = _tune.ReadValue("Db.DatabaseProvider",
            (s) => (DatabaseProvider)Enum.Parse(typeof(DatabaseProvider), s, true));
        }
        return _databaseSetting;
      }
    }

    int? _maxNodeLevel;

    public int MaxNodeLevel
    {
      get
      {
        if (_maxNodeLevel == null)
          _maxNodeLevel = _tune.ReadValue("Tree.MaxNodeLevel", (s) => int.Parse(s));
        return _maxNodeLevel.Value;
      }
    }

    private const int _concurrentQuerySizeMin = 1;
    private const int _concurrentQuerySizeMax = 60;
    private const int _concurrentQuerySizeDefault = 20;

    private int? _concurrentQuerySize;
    public int ConcurrentQuerySize
    {
      get
      {
        if (_concurrentQuerySize == null)
        {
          _concurrentQuerySize = _tune.ReadValue("DeviceAccessLayer.ConcurrentQuerySize", (s) => int.Parse(s), _concurrentQuerySizeDefault);
          if (!(_concurrentQuerySize >= _concurrentQuerySizeMin && _concurrentQuerySize <= _concurrentQuerySizeMax))
            _concurrentQuerySize = _concurrentQuerySizeDefault;
        }
        return _concurrentQuerySize.Value;
      }
    }
  }

}