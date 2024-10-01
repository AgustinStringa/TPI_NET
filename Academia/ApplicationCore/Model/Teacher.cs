using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
	[Table("docentes")]
	public class Teacher : User
	{
		[Column("cuit")]
		public string? Cuit { get; set; }

		[Column("legajo")]
		public string? TeacherId { get; set; }

		public virtual ICollection<Course> TeacherCourses { get; set; } = new List<Course>();
	}
}
