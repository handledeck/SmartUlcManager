using CommandLine;
using DB;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UlcWin;

namespace UlcDbInstall
{
  public enum EnumRole
  {
    READ = 0,
    READ_WRITE,
    FULL
  }

  //aaaaaaa
  class Options
  {
    [Option('a', "address", Required = true, HelpText = "ip или dns адрес сервера Postgres")]
    public string DbPsgAddress { get; set; }

    [Option('p', "port", Required = true, HelpText = "Порт сервера Postgres")]
    public string PgsPort { get; set; }

    [Option('u', "user", Required = true, HelpText = "Имя суперпользователя Postgres")]
    public string PsgUser { get; set; }
    [Option('w', "pwd", Required = true, HelpText = "Пароль суперпользователя Postgres")]
    public string PsgPwd { get; set; }
    [Option('t', "test", Required = false, HelpText = "Проверка подключения")]
    public string PsgTest { get; set; }
  }

  static class Program
  {
    const string __role_read_only = "CREATE ROLE ulc_read WITH NOSUPERUSER NOCREATEDB NOCREATEROLE " +
                "NOINHERIT NOLOGIN NOREPLICATION NOBYPASSRLS CONNECTION LIMIT -1;";
    const string __role_read_write = "CREATE ROLE ulc_read_write WITH NOSUPERUSER NOCREATEDB NOCREATEROLE " +
                "NOINHERIT NOLOGIN NOREPLICATION NOBYPASSRLS CONNECTION LIMIT -1;";

    const string __read_only = "GRANT SELECT ON ALL TABLES IN SCHEMA public TO ulc_read;" +
      " GRANT UPDATE, INSERT ON TABLE public.main_logs TO ulc_read;" +
      " GRANT ALL ON ALL SEQUENCES IN SCHEMA public TO ulc_read";
    const string __read_write = "GRANT SELECT,INSERT,UPDATE,DELETE ON ALL TABLES IN SCHEMA public TO ulc_read_write;" +
      " GRANT ALL ON ALL SEQUENCES IN SCHEMA public TO ulc_read_write";
    static Options __opts = null;
    static int result = 0;

    public static void RunOptions(Options opts)
    {
      __opts = opts;
    }
    public static void HandleParseError(IEnumerable<Error> errs)
    {

      foreach (var item in errs)
      {
        Console.WriteLine(item.ToString());
      }
    }

    static int Main(string[] args)
    {

      ParserResult<Options> res = CommandLine.Parser.Default.ParseArguments<Options>(args)
          .WithParsed(RunOptions)
          .WithNotParsed(HandleParseError);
      if (res.Tag == ParserResultType.Parsed)
      {
        if (__opts.PsgTest != null)
        {
          return TryConnectDb();
        }
        return CreateDb();
      }
      else
      {
        Console.WriteLine("aaaaaa");
        result = 1;
      }
      return result;
    }

    static int TryConnectDb()
    {
      string connection = string.Format("Host={0};Port={1};Username={2};Password={3};Database=''",
       __opts.DbPsgAddress, __opts.PgsPort, __opts.PsgUser, __opts.PsgPwd);
      var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
    connection, PostgreSqlDialect.Provider);
      try
      {
        using (var db = dbFactory.Open())
        {
          Console.WriteLine("Connection OK");
          return 0;
        }
      }
      catch
      {
        Console.WriteLine("Connection ERROR");
        return 1;
      }
    }

    static int CreateDb()
    {
      string connection = string.Format("Host={0};Port={1};Username={2};Password={3};Database=''",
     __opts.DbPsgAddress, __opts.PgsPort, __opts.PsgUser, __opts.PsgPwd);
      var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
    connection, PostgreSqlDialect.Provider);
      try
      {
        using (var db = dbFactory.Open())
        {
          //WriteStatusInstall("Cotlllllll", Color.Green);
          if (!db.Select<string>("SELECT datname FROM pg_database;").Contains("ctrl_mon_dev"))
          {
            int bCreate = db.ExecuteSql("create database ctrl_mon_dev");
          }
          db.ChangeDatabase("ctrl_mon_dev");
          db.CreateTableIfNotExists(typeof(MainNodes));
          db.CreateTableIfNotExists(typeof(MainInfo));
          db.CreateTableIfNotExists(typeof(MainCurrent));
          db.CreateTableIfNotExists(typeof(MainData));
          db.CreateTableIfNotExists(typeof(MainEvents));
          db.CreateTableIfNotExists(typeof(MainLogs));
          db.CreateTableIfNotExists(typeof(MainStat));
          bool tbl = db.CreateTableIfNotExists(typeof(MainUnitTypes));
          if (tbl)
          {
            List<MainUnitTypes> lstDev = new List<MainUnitTypes>();
            lstDev.Add(new MainUnitTypes() { Id = 1, Name = "ULC 2" });
            lstDev.Add(new MainUnitTypes() { Id = 0, Name = "РВП-18" });
            db.Insert<MainUnitTypes>(lstDev.ToArray());
          }
          db.CreateTableIfNotExists(typeof(MainUser));
          db.CreateTableIfNotExists(typeof(MainArmSoft));
          MainUser mainUser = new MainUser()
          {
            usr = __opts.PsgUser,// this.txtDbSprUser.Text,
            level = -1,
            comment = "общая запись",
            items = "",
            pwd = ""
          };
          string spu = DBAuthUtils.Encrypt(mainUser.level.ToString(), mainUser.usr);
          mainUser.pwd = spu;
          List<MainUser> lst = db.Select<MainUser>(x => x.usr.Equals(__opts.PsgUser));// this.txtDbSprUser.Text); ; ;//);
          if (lst.Count == 0)
            db.Insert<MainUser>(mainUser);
          if (!CheckForRole("ulc_read", EnumRole.READ, db))
          {
            return 1;
          }
          if (!CheckForRole("ulc_read_write", EnumRole.READ_WRITE, db))
          {
            return 1;
          }
          Console.WriteLine("Create DB is OK");
          return 0;
        }
      }
      catch (Exception ec)
      {
        byte[] bb = System.Text.ASCIIEncoding.UTF8.GetBytes(ec.Message);
        string msg = System.Text.ASCIIEncoding.Default.GetString(bb);
        Console.WriteLine("Connection ERROR:{0}", msg);
        return 1;
      }
    }

    static bool CheckForRole(string name, EnumRole role, IDbConnection dbConnection)
    {
      bool result = false;
      using (var cmd = dbConnection.CreateCommand())
      {
        cmd.CommandText = string.Format("SELECT *FROM pg_catalog.pg_roles where rolname = '{0}'", name);
        object xxx = cmd.ExecuteScalar();
        if (xxx == null)
        {
          StringBuilder sqlBndr = new StringBuilder();
          if (role == EnumRole.READ)
          {
            sqlBndr.Append(__role_read_only);
            sqlBndr.Append(__read_only);
          }
          else if (role == EnumRole.READ_WRITE)
          {
            sqlBndr.Append(__role_read_write);
            sqlBndr.Append(__read_write);
          }
          cmd.CommandText = sqlBndr.ToString();
          cmd.ExecuteNonQuery();
          result = true;
        }
      }
      return result;
    }
  }
}
