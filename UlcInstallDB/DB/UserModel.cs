using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	[ServiceStack.DataAnnotations.Alias("main_usermodel")]
	public class main_usermodel
	{
		[Index]
		[AutoIncrement]
		[ForeignKey(typeof(MainNodes))]
		public Int32 id { get; set; }
		[Required]
		public string password { get; set; }
		public DateTime last_login { get; set; }
		[Required]
		public string username { get; set; }
		[Required]
		public string fullname { get; set; }
		[Required]
		public bool edit_permission { get; set; }
		[Required]
		public bool is_staff { get; set; }
		public Int32 fes_id { get; set; }
		public Int32 res_id { get; set; }

	}
}
