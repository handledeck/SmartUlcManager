using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	[ServiceStack.DataAnnotations.Alias("main_stat")]
	public class MainStat
	{
		
		[AutoIncrement]
		[PrimaryKey]
		public Int32 id { get; set; }
		[Required]
		[Index]
		public DateTime current_time { get; set; }
		[Required]
		public Int32 all { get; set; }
		[Required]
		public Int32 allrvp { get; set; }
		[Required]
		public Int32 allulc { get; set; }
		[Required]
		public Int32 neterrorall { get; set; }
		[Required]
		public Int32 all_rs_errorrs { get; set; }
		[Required]
		public Int32 allerrorgsm { get; set; }
		[Required]
		public Int32 neterrorulc { get; set; }
		[Required]
		public Int32 ulc_rs_errorrs { get; set; }
		[Required]
		public Int32 ulcerrorgsm { get; set; }
		[Required]
		public Int32 neterrorrvp { get; set; }
		[Required]
		public Int32 rvp_rs_errorrs { get; set; }
		[Required]
		public Int32 rvperrorgsm { get; set; }

		
	}
}
