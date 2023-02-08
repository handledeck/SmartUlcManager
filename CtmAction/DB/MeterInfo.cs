using InterUlc.Db;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db
{
  [ServiceStack.DataAnnotations.Alias("meter_info")]
  public class MeterInfo
  {
    [ServiceStack.DataAnnotations.AutoIncrement]
    public int id { get; set; }
    public int ctrl_id { get; set; }
    public int parent_id { get; set; }
    public string ip { get; set; }
    public string meter_type { get; set; }
    public string meter_factory { get; set; }
    [Default(1)]
    public int active { get; set; }



    public static string CreateTable()
    {
      return @"CREATE TABLE meter_info(
	      id serial4 NOT NULL,
	      ctrl_id int4 NOT NULL,
	      parent_id int4 NOT NULL,
	      ip text NULL,
	      meter_type text NULL,
	      meter_factory text NULL,
	      active int4 NOT NULL DEFAULT 1,
	      CONSTRAINT meter_info_pkey PRIMARY KEY (id));";
    }
  }
}
