using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	[ServiceStack.DataAnnotations.Alias("main_unittypes")]
	public class MainUnitTypes
	{
		
		[PrimaryKey]
		public Int32 Id { get; set; }
		[Required]
		public string Name { get; set; }

	}
}
