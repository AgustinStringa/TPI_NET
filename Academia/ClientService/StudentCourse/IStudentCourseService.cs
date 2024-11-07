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
		public Task<IEnumerable<ApplicationCore.Model.StudentCourse>> GetByUserId(int id, bool actives = false);
		public Task QualifyCourse(int studentCourseId, CalificationCourse calification);
		public Task CreateAsync(ApplicationCore.Model.StudentCourse studentCourse);
		public Task<IEnumerable<AcademicStatusItem>> GetAcademicStatus(int userId);
		public Task DeleteAsync(int id);
	}
}