using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using Dapper;
using Dapper.Contrib.Extensions;
using QueryBuilder;
using QueryBuilder.Data.AnyDb;
using Ztp;
using Ztp.Model;
using Ztp.Port;
using Ztp.Port.TcpPort;
using Ztp.Protocol;
using Ztp.Ui;
using ZtpManager.Nodes;
using ZtpManager.Scope;

namespace ZtpManager.DataAccessLayer
{
  public class Dal
  {
    private static readonly NLog.Logger nLogger = NLog.LogManager.GetCurrentClassLogger();
    private AnyDbFactory _factory = null;

    Dal()
    {
    }

    private static Dal _default;
    public static Dal Default
    {
      get
      {
        if (_default == null)
          _default = new Dal();
        return _default;
      }
    }

    public AnyDbFactory Factory
    {
      get { return _factory; }
    }

    public bool IsConnected
    {
      get { return _factory != null; }
    }

    public void Connect()
    {
      _factory = null;
      _factory = new AnyDbFactory(TuneSetting.Default.DatabaseSetting, new SqlAnnouncer());
      try
      {
        using (AnyDbConnection con = _factory.OpenConnection())
        {
          //для поверки соединения
        }
      }
      catch(Exception ex)
      {
        _factory = null;
        throw;
      }
    }

    #region Histories

    public IEnumerable<LastOperation> ReadLastOperations()
    {
      using (AnyDbConnection con = _factory.OpenConnection())
      {
        return con.Query<LastOperation>("usp_GetLastOp", commandTimeout: TuneSetting.Default.DatabaseSetting.CommandTimeout,
          commandType: CommandType.StoredProcedure);
      }
    }

    public IEnumerable<OpHistory> ReadHistory(int deviceId, DateTime from, DateTime to)
    {
      Select sel = QBuilder.Select("*")
        .From(Tables.OpHistories)
        .Where(Logic.And(
          Oper.Equal(OpHistoryFld.IdNode, Expr.Param("idNode")),
          Oper.Between(OpHistoryFld.OpDate, Expr.Param("from"), Expr.Param("to"))
        ))
        .OrderBy(OpHistoryFld.OpDate)
        .Params(
        Param.New("idNode", DbType.Int32, ParameterDirection.Input, deviceId),
        Param.New("from", DbType.DateTime, ParameterDirection.Input, from),
        Param.New("to", DbType.DateTime, ParameterDirection.Input, to)
        );
      using (AnyDbConnection con = _factory.OpenConnection())
      {
        return con.Query<OpHistory>(sel, commandTimeout: TuneSetting.Default.DatabaseSetting.CommandTimeout);
      }
    }

    #endregion

    #region LightPlan

    public IEnumerable<LightPlan> ReadLightPlans()
    {
      Select sel = QBuilder.Select("*")
        .From(Tables.CatLightPlan)
        .OrderBy(LightPlanFld.DisplayName);
      using (AnyDbConnection con = _factory.OpenConnection())
      {
        return con.Query<LightPlan>(sel, commandTimeout: TuneSetting.Default.DatabaseSetting.CommandTimeout);
      }
    }

    public bool EditLightPlan(LightPlan plan)
    {
      if (plan == null) throw new ArgumentNullException(nameof(plan));
      bool retVal;
      using (AnyDbConnection con = _factory.OpenConnection())
      using (DbTransaction tran = con.BeginTransaction())
      {
        try
        {
          retVal = con.Update(plan, tran, commandTimeout: TuneSetting.Default.DatabaseSetting.CommandTimeout);
          tran.Commit();
        }
        catch
        {
          tran.Rollback();
          throw;
        }
      }
      return retVal;
    }

    public bool DeleteLightPlan(LightPlan plan)
    {
      bool retVal;
      using (AnyDbConnection con = _factory.OpenConnection())
      using (DbTransaction tran = con.BeginTransaction())
      {
        try
        {
          retVal = con.Delete(plan, tran, commandTimeout: TuneSetting.Default.DatabaseSetting.CommandTimeout);
          tran.Commit();
        }
        catch (Exception)
        {
          tran.Rollback();
          throw;
        }
      }
      return retVal;
    }

    public void AddLightPlan(LightPlan plan)
    {
      using (AnyDbConnection con = _factory.OpenConnection())
      using (DbTransaction tran = con.BeginTransaction())
      {
        try
        {
          con.Insert(plan, tran, commandTimeout: TuneSetting.Default.DatabaseSetting.CommandTimeout);
          tran.Commit();
        }
        catch (Exception)
        {
          tran.Rollback();
          throw;
        }
      }
    }

    #endregion

    #region OperationHistory

    public void WriteOperationHistory(OpHistory opHistory)
    {
      using (AnyDbConnection con = _factory.OpenConnection())
      using (DbTransaction tran = con.BeginTransaction())
      {
        try
        {
          WriteOperationHistoryPrivate(opHistory, con, tran);
          ScopeItem item = Scope.ScopeArea.Default[opHistory.IdNode];
          item.NodeEx.IsError = opHistory.IsError;
          tran.Commit();
        }
        catch
        {
          tran.Rollback();
          throw;
        }
      }
    }

    void WriteOperationHistoryPrivate(OpHistory opHistory, AnyDbConnection con, IDbTransaction tran)
    {
      long affected = con.Insert(opHistory, tran, TuneSetting.Default.DatabaseSetting.CommandTimeout);
    }

    #endregion
    public IEnumerable<NodeEx> ReadDeviceNodesWithDisplayPath()
    {

      using (AnyDbConnection con = _factory.OpenConnection())
      using (AnyDbCommand cmd = con.CreateCommand())
      {
        cmd.CommandType = CommandType.StoredProcedure;
        return con.Query<NodeEx>("usp_GetDeviceNodeEx", commandTimeout: TuneSetting.Default.DatabaseSetting.CommandTimeout);
      }
    }

    public IEnumerable<int> ReadFlatChildDeviceIds(string parentPath)
    {
      Select sel = QBuilder.Select(NodeFld.Id)
        .From(Tables.Nodes)
        .Where(Logic.And(
          Oper.Like(NodeFld.Path, parentPath + ".%")
        ));
      using (AnyDbConnection con = _factory.OpenConnection())
      {
        return con.Query<int>(sel, commandTimeout: TuneSetting.Default.DatabaseSetting.CommandTimeout);
      }
    }

    public IEnumerable<int> ReadChildDeviceIds(int parentId)
    {
      Select sel = QBuilder.Select(NodeFld.Id)
        .From(Tables.Nodes)
        .Where(Logic.And(
          Oper.Equal(NodeFld.IdOwn, parentId),
          Oper.Equal(NodeFld.Kind, (byte)NodeKind.Device)
        ));
      using (AnyDbConnection con = _factory.OpenConnection())
      {
        return con.Query<int>(sel, commandTimeout: TuneSetting.Default.DatabaseSetting.CommandTimeout);
      }
    }


    public IEnumerable<Node> ReadChildNodes(int parentId)
    {
      Select sel = QBuilder.Select("*")
        .From(Tables.Nodes)
        .Where(Logic.And(
          Oper.Equal(NodeFld.IdOwn, parentId)
        ))
        .OrderBy(NodeFld.DisplayName);
      using (AnyDbConnection con = _factory.OpenConnection())
      {
        return con.Query<Node>(sel, commandTimeout: TuneSetting.Default.DatabaseSetting.CommandTimeout);
      }
    }

    public bool EditNode(Node node)
    {
      if (node == null) throw new ArgumentNullException(nameof(node));
      bool retVal;
      using (AnyDbConnection con = _factory.OpenConnection())
      using (DbTransaction tran = con.BeginTransaction())
      {
        try
        {
          retVal = con.Update(node, tran, commandTimeout: TuneSetting.Default.DatabaseSetting.CommandTimeout);
          WriteOperationHistoryPrivate(
            new OpHistory()
            {
              IdNode = node.Id,
              OpCode = OpHistoryCode.U.ToString(),
              OpName = OpHistoryCode.U.GetDescription(),
            }, con, tran);
          tran.Commit();
        }
        catch
        {
          tran.Rollback();
          throw;
        }
      }
      return retVal;
    }

    public bool DeleteNode(int id)
    {
      bool retVal;
      using (AnyDbConnection con = _factory.OpenConnection())
      using (DbTransaction tran = con.BeginTransaction())
      {
        try
        {
          DynamicParameters p = new DynamicParameters();
          p.Add("id", id);
          retVal = con.Execute("usp_DeleteNode", p, commandType: CommandType.StoredProcedure, transaction: tran, commandTimeout: TuneSetting.Default.DatabaseSetting.CommandTimeout) > 0;
          tran.Commit();
        }
        catch (Exception)
        {
          tran.Rollback();
          throw;
        }
      }
      return retVal;
    }

    public string ReadNodeDisplayPath(int nodeId)
    {
      using (AnyDbConnection con = _factory.OpenConnection())
      {
        DynamicParameters p = new DynamicParameters();
        p.Add("node_id", nodeId);
        string result = con.ExecuteScalar<string>("usp_GetNodeDisplayPath", p, commandType: CommandType.StoredProcedure,
          commandTimeout: TuneSetting.Default.DatabaseSetting.CommandTimeout);
        return result;
      }
    }

    public void AddNodes(params NodeEx[] nodes)
    {
      using (AnyDbConnection con = _factory.OpenConnection())
      using (DbTransaction tran = con.BeginTransaction())
      {
        try
        {
          foreach (NodeEx node in nodes)
          {
            DynamicParameters p = new DynamicParameters();
            p.Add("idown", node.IdOwn);
            p.Add("kind", value: (byte)node.Kind);
            p.Add("displayname", node.DisplayName);
            p.Add("description", node.Description);
            p.Add("ipaddress", node.IpAddress);
            p.Add("password", node.Password);
            p.Add("estcommstateguid", node.EstCommStateGuid);
            p.Add("devtype", value: (byte)node.DevType);
            p.Add("new_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("new_path", dbType: DbType.String, direction: ParameterDirection.Output);
            p.Add("new_display_path", dbType: DbType.String, direction: ParameterDirection.Output);
            con.Execute("usp_AddNode", p, commandType: CommandType.StoredProcedure, transaction: tran, commandTimeout: TuneSetting.Default.DatabaseSetting.CommandTimeout);
            node.Id = p.Get<int>("new_id");
            node.Path = p.Get<string>("new_path");
            node.DisplayPath = p.Get<string>("new_display_path");

            WriteOperationHistoryPrivate(
              new OpHistory()
              {
                IdNode = node.Id,
                OpCode = OpHistoryCode.C.ToString(),
                OpName = OpHistoryCode.C.GetDescription(),
              }, con, tran);
          }

          tran.Commit();
        }
        catch (Exception)
        {
          tran.Rollback();
          throw;
        }
      }
    }

    public IEnumerable<string> GetEstToolsCommStateGuids()
    {
      Select sel = QBuilder.Select(NodeFld.EstCommStateGuid)
        .From(Tables.Nodes)
        .Where(Logic.And(
          Oper.IsNotNull(NodeFld.EstCommStateGuid)
        ));
      using (AnyDbConnection con = _factory.OpenConnection())
      using (IDataReader reader = con.ExecuteReader(sel, commandTimeout: TuneSetting.Default.DatabaseSetting.CommandTimeout))
      {
        while (reader.Read())
        {
          yield return reader.GetString(0);
        }
      }
    }

    /// <summary>
    /// Вычитка IP-адреса с БД и формирование конфига для TCP соединения
    /// </summary>
    /// <param name="nodeId">индекс требуемого узла</param>
    /// <returns>конфиг для подключения TCP</returns>
    public TcpPortSettings CreateTcpPortSettings(int nodeId)
    {
      TcpPortSettings retVal = null;
      Select sel = QBuilder.Select(NodeFld.IpAddress)
        .From(Tables.Nodes)
        .Where(Logic.And(
          Oper.Equal(NodeFld.Id, nodeId)
        ));
      using (AnyDbConnection con = _factory.OpenConnection())
      {
        string ipAddress = con.ExecuteScalar<string>(sel, commandTimeout: TuneSetting.Default.DatabaseSetting.CommandTimeout);
        if (string.IsNullOrEmpty(ipAddress))
          throw new InvalidOperationException("Не указан IP-адрес");
        retVal = new TcpPortSettings()
        {
          IpAddress = ipAddress,
          Kind = PortKind.Tcp,
          Timeout = AppConfig.Default.TcpTimeout,
          Port = AppConfig.Default.TcpPort
        };
      }
      nLogger.Info( $"Чтение IP из узла {nodeId} успешно");
      return retVal;
    }


  }
}
