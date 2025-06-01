using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ztp.Configuration;
using System.ComponentModel;

namespace UlcWin.DB
{

  public class CD
  {
    [Key]
    [System.ComponentModel.Browsable(false)]
    public int id { get; set; }
    [DisplayName("Имя")]
    public string name { get; set; }
    [DisplayName("Ip адрес")]
    public string ip_address { get; set; }
    [System.ComponentModel.Browsable(false)]
    [NotMapped]
    public ZtpConfig ztp { get; set; }

    [DisplayName("Версия")]
    [NotMapped]
    public string Version { get; set; }
    [DisplayName("Прогресс")]
    [NotMapped]
    public string Message { get; set; } 
    [DisplayName("% Исполнения")]
    [NotMapped]
    public int Percent { get; set; }

    [DisplayName("Время прошивки")]
    [NotMapped]
    public string TimeRun { get; set; }

   
  }
}
