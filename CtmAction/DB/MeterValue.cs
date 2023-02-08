using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterUlc.Db
{
  [ServiceStack.DataAnnotations.Alias("meter_value")]
  public class MeterValue
  {
    
    [ServiceStack.DataAnnotations.AutoIncrement]
    public int id { get; set; }
    public int ctrl_id { get; set; }
    public DateTime date_time { get; set; }
    public string ip { get; set; }
    
    public string meter_type { get; set; }
    public string meter_factory { get; set; }
    public double value { get; set; }
    public bool is_true { get; set; }
    [Default(0)]
    public double value_month { get; set; }


    public static string CreateTable()
    {
      return @"CREATE TABLE IF NOT EXISTS meter_value(
        id serial4 NOT NULL,
        ctrl_id int4 NOT NULL,
        date_time timestamp NOT NULL,
        ip text NULL,
        meter_type text NULL,
        meter_factory text NULL,
        value float8 NOT NULL,
        is_true bool NOT NULL,
        value_month float8 NULL DEFAULT 0,
        CONSTRAINT meter_value_pkey PRIMARY KEY(id));";
    }

  }
}

