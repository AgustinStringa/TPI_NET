using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
	[Table("administrativos")]
	public class Administrative : User
	{
		[Column("cuit")]
		public string? Cuit { get; set; }
	}
}
