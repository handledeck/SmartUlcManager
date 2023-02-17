using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Db;
using DB;
using InterUlc.Db;
using Microsoft.Deployment.WindowsInstaller;
using ServiceStack.OrmLite;
using UlcWin;

namespace CtmAction
{
  public enum EnumRole
  {
    READ = 0,
    READ_WRITE,
    FULL
  }

  public class PSql
  {
    public string db_address { get; set; }
    public int db_port { get; set; }
    public string db_user { get; set; }
    public string db_pwd { get; set; }
  }

  public class CustomActions
  {
    const string __role_read_only = "CREATE ROLE ulc_read WITH NOSUPERUSER NOCREATEDB NOCREATEROLE " +
                "NOINHERIT NOLOGIN NOREPLICATION NOBYPASSRLS CONNECTION LIMIT -1;";
    const string __role_read_write = "CREATE ROLE ulc_read_write WITH NOSUPERUSER NOCREATEDB NOCREATEROLE " +
                "NOINHERIT NOLOGIN NOREPLICATION NOBYPASSRLS CONNECTION LIMIT -1;";

    //const string __read_only = "GRANT SELECT ON ALL TABLES IN SCHEMA public TO ulc_read;" +
    //" GRANT UPDATE, INSERT ON TABLE public.main_logs TO ulc_read;";

    const string __read_only = "GRANT SELECT,INSERT,UPDATE,DELETE ON ALL TABLES IN SCHEMA public TO ulc_read;" +
    " GRANT ALL ON ALL SEQUENCES IN SCHEMA public TO ulc_read";
    const string __read_write = "GRANT SELECT,INSERT,UPDATE,DELETE ON ALL TABLES IN SCHEMA public TO ulc_read_write;" +
      " GRANT ALL ON ALL SEQUENCES IN SCHEMA public TO ulc_read_write";
    static int result = 0;
    public static PSql __pSql = new PSql();

    public static object MessageBox { get; private set; }

    [CustomAction]
    public static ActionResult ActionInstallDB(Session session)
    {
      try
      {
        //System.Windows.Forms.MessageBox.Show();
        session.Log("Begin CustomAction1");
        __pSql = new PSql();
        int port = 0;
        if (!int.TryParse(session["DB_PORT"], out port))
        {
          throw new Exception("Неправильный номер порта");
        }
        __pSql.db_address = session["DB_ADDRESS"];
        __pSql.db_user = session["DB_USER"];
        __pSql.db_port = port;
        __pSql.db_pwd = session["DB_PWD"];
        //System.Windows.Forms.MessageBox.Show(session["DB_TEST"]);
        
        Exception exp = null;
        if (!string.IsNullOrEmpty(session["DB_TEST"])) {
          if (session["DB_TEST"] == "1")
          {
            if (CheckDb(out exp) == 1)
            {
              throw exp;
            }
            else
            {
              System.Windows.Forms.MessageBox.Show("Соединение с БД успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          }
          else if (session["DB_TEST"] == "0")
          {
            if (CreateDb(out exp) == 1)
            {
              throw exp;
            }
            else
            {
              System.Windows.Forms.MessageBox.Show("БД успешно создана", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
              session["DB_RESULT"] = "1";
            }
          }
        }
      }
      catch (Exception exp)
      {
        System.Windows.Forms.MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        session["DB_RESULT"] = "0";
        return ActionResult.Failure;
      }

      return ActionResult.Success;
    }

    static int CheckDb(out Exception e)
    {
      e = null;
      return TryConnectDb(out e);
    }

    static int CreateDb(out Exception e)
    {
      e = null;
      return TryCreateDb(out e);
    }

    static int TryConnectDb(out Exception exception)
    {
      exception = null;
      string connection = string.Format("Host={0};Port={1};Username={2};Password={3};Database=''",
       __pSql.db_address, __pSql.db_port, __pSql.db_user, __pSql.db_pwd);
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
      catch (Exception exp)
      {
        exception = exp;
       // Console.WriteLine("Connection ERROR");
        return 1;
      }
    }

    public static int TryCreateDb(out Exception exception)
    {
      exception = null;
      string connection = string.Format("Host={0};Port={1};Username={2};Password={3};Database=''",
      __pSql.db_address, __pSql.db_port, __pSql.db_user, __pSql.db_pwd);
      //string connection = string.Format("Host={0};Port={1};Username={2};Password={3};Database=''",
     //"localhost", 5432, "postgres", "root");
      var dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(
    connection, PostgreSqlDialect.Provider);
      try
      {
        using (var db = dbFactory.Open())
        {
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
          db.CreateTableIfNotExists(typeof(MeterValue));
          db.CreateTableIfNotExists(typeof(MeterInfo));
          //bool tbl = db.CreateTableIfNotExists(typeof(MainUnitTypes));

          //if (tbl)
          //{
          //  List<MainUnitTypes> lstDev = new List<MainUnitTypes>();
          //  lstDev.Add(new MainUnitTypes() { Id = 1, Name = "ULC 2" });
          //  lstDev.Add(new MainUnitTypes() { Id = 0, Name = "РВП-18" });
          //  db.Insert<MainUnitTypes>(lstDev.ToArray());
          //}
          db.CreateTableIfNotExists(typeof(MainUser));
          //db.CreateTableIfNotExists(typeof(MainArmSoft));
          MainUser mainUser = new MainUser()
          {
            usr = "postgres",//__pSql.db_user,// this.txtDbSprUser.Text,
            level = -1,
            comment = "общая запись",
            items = "",
            pwd = ""
          };
          string spu = DBAuthUtils.Encrypt(mainUser.level.ToString(), mainUser.usr);
          mainUser.pwd = spu;
          List<MainUser> lst = db.Select<MainUser>(x => x.usr==__pSql.db_user);// this.txtDbSprUser.Text); ; ;//);
          if (lst.Count == 0)
            db.Insert<MainUser>(mainUser);
          if (!CheckForRole("ulc_read", EnumRole.READ, db))
          {
            return 0;
          }
          if (!CheckForRole("ulc_read_write", EnumRole.READ_WRITE, db))
          {
            return 0;
          }
          Console.WriteLine("Create DB is OK");
          return 1;
        }
      }
      catch (Exception ec)
      {
        //byte[] bb = System.Text.ASCIIEncoding.UTF8.GetBytes(ec.Message);
        //string msg = System.Text.ASCIIEncoding.Default.GetString(bb);
        exception = ec;
        //Console.WriteLine("Connection ERROR:{0}", msg);
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
