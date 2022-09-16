using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using QueryBuilder.Data.AnyDb;
using Ztp.IO;

namespace Ztp.Model.Creator
{
  class Arguments
  {
    public bool CreateForce = false;
    public bool ShowHelp = false;
    public bool NeedDownGrade = false;
  }
  class Program
  {
    static ConsoleAnnouncer announcer = new ConsoleAnnouncer();
    static void Main(string[] args)
    {
      announcer.Heading("Update database");
      Arguments arguments = new Arguments();
      try
      {
        CmdParse cmdParse = new CmdParse(
          new CmdParseItem("help", "?|h|help", "Вывод настоящей справки",
            (key, val) =>
            {
              arguments.ShowHelp = true;
            }),
          new CmdParseItem("forceCreate", "f", "Принудительное создание базы данных. Если она существует, то будет удалена.",
            (key, val) =>
            {
              arguments.CreateForce = true;
            }),
          new CmdParseItem("downgrade", "d", "Откат БД",
            (key, val) =>
            {
              arguments.NeedDownGrade = true;
            })
          );

        cmdParse.Parse(args);

        if (arguments.ShowHelp)
        {
          announcer.Write("Using: ZtpModel.Creator.exe [argument]");
          announcer.Write("Arguments:");
          announcer.Write(cmdParse.Help());
          goto exit;
        }
        if (arguments.NeedDownGrade)
          DownGrade();
        else
          Run(arguments.CreateForce);
        exit:
          return;
      }
      catch (Exception ex)
      {
        announcer.Error(ex);
      }
    }

    static void DownGrade()
    {
      AnyDbFactory factory = new AnyDbFactory(TuneSetting.Default.DatabaseSetting);

      if (!factory.ExistsDatabase())
      {
        announcer.Emphasize("Create database");
        factory.CreateDatabase();
      }

      RunnerContext context = new RunnerContext(announcer)
      {
        Database = TuneSetting.Default.DatabaseSetting.DatabaseProvider.ToString(),
        Connection = TuneSetting.Default.DatabaseSetting.ConnectionString,
        Targets = new[] { "ZtpModel" },
        Task = "rollback:toversion",
        Version = 20170127100000,
        Steps = -1
      };

      //RunnerContext context = new RunnerContext(announcer);
      //context.Database = TuneSetting.Default.DatabaseSetting.DatabaseProvider.ToString();
      //context.Connection = TuneSetting.Default.DatabaseSetting.ConnectionString;
      //context.Targets = new[] {"ZtpModel"};
      //context.Task = "migrate";

      TaskExecutor executor = new TaskExecutor(context);
      executor.Execute();
    }

    static void Run(bool createForce)
    {
      AnyDbFactory factory = new AnyDbFactory(TuneSetting.Default.DatabaseSetting);

      if (createForce) 
      {
        if (factory.ExistsDatabase())
        {
          announcer.Emphasize("Delete database");
          factory.DropDatabase();
        }
      }

      if (!factory.ExistsDatabase())
      {
        announcer.Emphasize("Create database");
        factory.CreateDatabase();
      }

      RunnerContext context = new RunnerContext(announcer)
      {
        Database = TuneSetting.Default.DatabaseSetting.DatabaseProvider.ToString(),
        Connection = TuneSetting.Default.DatabaseSetting.ConnectionString,
        Targets = new[] { "ZtpModel" },
        Task = "migrate"
      };

      //RunnerContext context = new RunnerContext(announcer);
      //context.Database = TuneSetting.Default.DatabaseSetting.DatabaseProvider.ToString();
      //context.Connection = TuneSetting.Default.DatabaseSetting.ConnectionString;
      //context.Targets = new[] {"ZtpModel"};
      //context.Task = "migrate";

      TaskExecutor executor = new TaskExecutor(context);
      executor.Execute();
    }
  }
}
