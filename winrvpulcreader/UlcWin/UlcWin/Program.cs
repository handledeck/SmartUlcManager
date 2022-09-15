using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin
{
  /*
   
     select count(*) from( 
SELECT main_nodes."name" , main_ctrlinfo.ip_address, main_nodes.light 
FROM main_nodes ,main_ctrlinfo
WHERE main_nodes.id=main_ctrlinfo.id and main_ctrlinfo.unit_type_id =0 and main_nodes.light =1)foo
     
     */

  /*
   WITH temporaryTable(id) as
  (SELECT *from main_nodes mn where mn.light =1)

  SELECT* FROM temporaryTable,main_ctrlinfo where temporaryTable.id=main_ctrlinfo.id order by temporaryTable.id
 
     */


  /*

   select count(*) from main_nodes mn,main_ctrlinfo mc where mn.id =mc.id and mn.light =1 and mc.unit_type_id =1

   */

  /*
   * поиск несоответсвия в таблицах
   select distinct id from main_nodes mn where mn.node_kind_id =3 and id not in (select id from main_ctrlinfo mc)
   */
  static class Program
  {
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new LoadForm());
    }
  }
}
