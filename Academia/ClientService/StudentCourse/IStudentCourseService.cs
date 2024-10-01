using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.StudentCourse
{
	public interface IStudentCourseService
	{
		public Task<IEnumerable<ApplicationCore.Model.StudentCourse>> GetByUserId(int id);
		public Task QualifyCourse(int studentCourseId, CalificationCourse calification);
	}
}
