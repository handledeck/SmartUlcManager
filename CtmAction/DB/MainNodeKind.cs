using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	[ServiceStack.DataAnnotations.Alias("main_nodekind")]
	public class main_nodekind
	{
		[PrimaryKey]
		public Int32 id { get; set; }
		public string name { get; set; }

	
	}
}
