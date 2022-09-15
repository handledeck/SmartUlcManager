using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{

	[ServiceStack.DataAnnotations.Alias("main_ctrlinfo")]
	public class MainArmSoft
	{
		[ServiceStack.DataAnnotations.AutoIncrement]
		[ServiceStack.DataAnnotations.PrimaryKey]
		[ServiceStack.DataAnnotations.Required]
		public Int32 id { get; set; }
		[ServiceStack.DataAnnotations.Required]
		public string name { get; set; }

	}

	
}
