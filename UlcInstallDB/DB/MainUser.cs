using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	[ServiceStack.DataAnnotations.Alias("main_user")]
	public class MainUser
	{
		[Index]
		[AutoIncrement]
		[PrimaryKey]
		public Int32 id { get; set; }
		[Required]
		public string usr { get; set; }
		[Required]
		public string pwd { get; set; }
		[Required]
		public string items { get; set; }
		public string comment { get; set; }
		[Required]
		public Int16 level { get; set; }

		
	}
}
