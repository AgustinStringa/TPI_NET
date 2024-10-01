using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Course
{
	public interface ICourseService
	{
		Task CreateAsync(ApplicationCore.Model.Course course);
		Task<IEnumerable<ApplicationCore.Model.Course>> GetAllAsync();
        Task<IEnumerable<ApplicationCore.Model.Course>> GetAllWithTeachers();
        Task<IEnumerable<ApplicationCore.Model.Course>> GetAvailableCourses(ApplicationCore.Model.Student student);
		Task UpdateAsync(ApplicationCore.Model.Course course);
		Task DeleteAsync(int id);
	}
}
