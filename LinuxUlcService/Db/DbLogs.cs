using System;
using System.Collections.Generic;
using System.Text;

namespace InterUlc.Db
{
  public class DbLogs
  {
    public int Id { get; set; }
    public string tp { get; set; }
    public string res { get; set; }
    public string fes { get; set; }
    public string ip { get; set; }
    public ImeiStatAndRs feature { get; set; }
  }

  public class ImeiStatAndRs {
    public string old_imei { get; set; }
    public string new_imei { get; set; }
    public string rs_status { get; set; }
    public string rs_last_request { get; set; }
  }
}
