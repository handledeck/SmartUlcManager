using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace Ztp.Model.Migrations
{
  [Migration(20201123200000)]
  public class First_20201123200000 : Migration
  {
    public override void Down()
    {
      throw new NotImplementedException();
    }

    public override void Up()
    {
      Execute.Sql("DROP PROCEDURE IF EXISTS usp_AddNode");
      Execute.EmbeddedScript("mysql_First_20201123200000.sql");
    }
  }
}
