using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UlcWin.DB
{
  public enum EnLogEvt {
    [Description("Добавлен контроллер")]
    ADD_ITEM =0,
    [Description("Изм. имени контроллера")]
    EDIT_ITEM=2,
    [Description("Удален контроллер")]
    DELETE_ITEM = 3,
    [Description("Добавлен объект")]
    ADD_NODE = 4,
    [Description("Изм. имя объекта")]
    EDIT_NODE = 6,
    [Description("Удален объект")]
    DELETE_NODE =7,
    [Description("Изм. настроек контроллера")]
    SETTING_CHANGE =8,
    [Description("Вход пользователя")]
    APP_CONNECT = 9,
    [Description("Выход пользователя")]
    APP_EXIT = 10,
    [Description("Регистрация пользователя")]
    APP_NEW_USER = 11,
    [Description("Редактирование пользователя")]
    APP_EDIT_USER = 12,
    [Description("Удаление пользователя")]
    APP_DEL_USER = 13,
    [Description("Выход на связь(более суток простой)")]
    CHANGE_NET_STATE =14,
    [Description("Замена контроллера")]
    CHANGE_IMEI = 100
  }

  public class EvtDescription {
    public static string  GetDesc(EnLogEvt enLogEvt) {
      return GetDescription((EnLogEvt)enLogEvt);
    }

    private static object GetCustomAtribute(Type srcField, string nameField, Type findAttr)
    {
      object result = null;
      foreach (FieldInfo fi in srcField.GetFields())
      {
        if (fi.Name.Equals(nameField))
        {
          foreach (Attribute atr in fi.GetCustomAttributes(findAttr, false))
          {
            return atr;
          }
          break;
        }
      }
      return result;
    }

    static string GetDescription(Enum e)
    {
      string desc = ((DescriptionAttribute)(GetCustomAtribute(e.GetType(), e.ToString(), typeof(DescriptionAttribute)))).Description;
      return desc;
    }
  }


  [ServiceStack.DataAnnotations.Alias("main_logs")]
  public class OrmDbLogs
  {
    [ServiceStack.DataAnnotations.AutoIncrement]
    [ServiceStack.DataAnnotations.PrimaryKey]
    public int id { get; set; }

    [ServiceStack.DataAnnotations.Required]
    [ServiceStack.DataAnnotations.Index]
    public DateTime current_time { get; set; }

    [ServiceStack.DataAnnotations.Required]
    public int id_user { get; set; }

    [ServiceStack.DataAnnotations.Required]
    public string usr_name { get; set; }

    public string message { get; set; }
    public int log_event { get; set; }
    public string host_from { get; set; }

    public int ctrl_id { get; set; }

    [ServiceStack.DataAnnotations.Ignore]
    public DbLogMsg dbLogMsg { get; set; }
    //[ServiceStack.DataAnnotations.Required]
    //[ServiceStack.DataAnnotations.Default(0)]
    //public long msg_all { get; set; }
  }

}
