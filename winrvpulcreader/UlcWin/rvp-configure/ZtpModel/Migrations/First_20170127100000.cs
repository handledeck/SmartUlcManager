//#define TEST
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using FluentMigrator;
using Dapper.Contrib.Extensions;

namespace Ztp.Model.Migrations
{
  [Migration(20170127100000)]
  // ReSharper disable once InconsistentNaming
  public class First_20170127100000 : Migration
  {
    public override void Up()
    {
      Create.Table("Nodes")                                               /*таблица узлов дерева устройств*/
        .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
        .WithColumn("IdOwn").AsInt32().NotNullable()
        .WithColumn("Kind").AsByte()                                      /*тип в дереве - папка или устройство*/
        .WithColumn("Path").AsString(100)
        .WithColumn("DisplayName").AsString(100).NotNullable()
        .WithColumn("Description").AsString(1024).Nullable()
        .WithColumn("IpAddress").AsString(15).Nullable()
        .WithColumn("Password").AsString(30).Nullable()
        .WithColumn("EstCommStateGuid").AsString(80).Nullable();
      Create.Index("IX_Nodes_IdOwn")
        .OnTable("Nodes")
        .OnColumn("IdOwn");
      Create.Index("UIX_Nodes_Path")
        .OnTable("Nodes")
        .OnColumn("Path")
        .Unique();
      Create.Index("UIX_Nodes_EstCommStateGuid")
        .OnTable("Nodes")
        .OnColumn("EstCommStateGuid")
        .Unique();

      Create.Table("CatLightPlan")
        .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
        .WithColumn("DisplayName").AsString(100).NotNullable()
        .WithColumn("Description").AsString(1024).Nullable()
        .WithColumn("Body").AsString(1024);

      IfDatabase(DatabaseType.MySql)
        .Execute.EmbeddedScript("mysql_First_20170127100000.sql");

      Create.Table("OpHistories")
        .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
        .WithColumn("IdNode").AsInt32().NotNullable()
        .WithColumn("UserName").AsString(50).NotNullable()
        .WithColumn("OpDate").AsDateTime().NotNullable()
        .WithColumn("OpCode").AsString(5).NotNullable()
        .WithColumn("OpName").AsString(100).NotNullable()
        .WithColumn("Cmd").AsString(512).Nullable()
        .WithColumn("ObjText").AsString(2048).Nullable()
        .WithColumn("OpResult").AsString(2048).Nullable()
        .WithColumn("IsError").AsBoolean().NotNullable();
      Create.Index("IX_OpHistories_IdNode")
        .OnTable("OpHistories")
        .OnColumn("IdNode");
      Create.Index("IX_OpHistories_Id_OpDate")
        .OnTable("OpHistories")
        .OnColumn("Id").Ascending()
        .OnColumn("OpDate").Ascending();
      Create.ForeignKey("FK_OpHistories_Nodes")
        .FromTable("OpHistories")
        .ForeignColumn("IdNode")
        .ToTable("Nodes")
        .PrimaryColumn("Id")
        .OnDelete(Rule.Cascade);
#if TEST
      Seed();
#endif
    }

    public override void Down()
    {

    }

    void Seed()
    {
      this.Execute.WithConnection((c, t) =>
      {
        Node n0 = AddNode(c, new Node() { DisplayName = "Сельский совет", IdOwn = 0, Kind = NodeKind.Folder });
        Node n1 = AddNode(c, new Node() { DisplayName = "Подстанция", IdOwn = n0.Id, Kind = NodeKind.Folder });

        for (int i = 0; i < 30; i++)
        {
          AddNode(c, new Node() { DisplayName = $"Устройство {i + 1}", IdOwn = n1.Id, DevType = (i%2 == 0)?DeviceKind.ULC02: DeviceKind.RVP18, Kind = NodeKind.Device });
        }
      });
    }

    Node AddNode(IDbConnection con, Node node)
    {
      DynamicParameters p = new DynamicParameters();
      p.Add("idown", node.IdOwn);
      p.Add("kind", value: (byte)node.Kind);
      p.Add("devtype", dbType: DbType.Byte, value: (byte)node.DevType);
      p.Add("displayname", node.DisplayName);
      p.Add("description", node.Description);
      p.Add("new_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
      p.Add("new_path", dbType: DbType.String, direction: ParameterDirection.Output);
      p.Add("new_display_path", dbType: DbType.String, direction: ParameterDirection.Output);
      p.Add("ipaddress", dbType: DbType.String, value: "127.0.0.1");
      p.Add("password", dbType: DbType.String, value: "YWRtaW4=");
      p.Add("estcommstateguid", dbType: DbType.String, value: null);
      
      con.Execute("usp_AddNode", p, commandType: CommandType.StoredProcedure);
      node.Id = p.Get<int>("new_id");
      node.Path = p.Get<string>("new_path");
      return node;
    }
  }
}
