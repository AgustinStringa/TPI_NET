using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
	[Table("estudiantes")]

	public class Student : User
	{
		[Column("legajo")]
		public string? StudentId { get; set; }

		[Column("id_plan")]
		public int? CurriculumId { get; set; }
		public Curriculum? Curriculum { get; set; }

		public ICollection<UserCourse> StudentCourses { get; set; } = new List<UserCourse>();
	}
}
