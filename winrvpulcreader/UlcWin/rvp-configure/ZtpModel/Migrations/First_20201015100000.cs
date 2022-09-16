//#define TEST
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using FluentMigrator;
using Dapper.Contrib.Extensions;

namespace Ztp.Model.Migrations
{
  [Migration(20201015100000)]
  // ReSharper disable once InconsistentNaming
  public class First_20201015100000 : Migration
  {
    public override void Up()
    {
      
      Alter.Table("Nodes").AddColumn("DevType").AsByte().Nullable();
      Update.Table("Nodes")
        .Set(new { DevType = 1 }).Where(new { Kind = 2 });

      
      //Execute.EmbeddedScript("mysql_First_20201015100000.sql");
    }

    public override void Down()
    {
      //Execute.Sql("DROP PROCEDURE IF EXISTS usp_AddNode");
    }
  }
}
