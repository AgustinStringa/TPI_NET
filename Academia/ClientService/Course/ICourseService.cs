using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Course
{
	public interface ICourseService
	{
		Task<IEnumerable<ApplicationCore.Model.Course>> GetAll();
        Task<IEnumerable<ApplicationCore.Model.Course>> GetAllWithTeachers();
        Task<IEnumerable<ApplicationCore.Model.Course>> GetAvailableCourses(ApplicationCore.Model.Student student);
		Task Create(ApplicationCore.Model.Course course);
		Task Update(ApplicationCore.Model.Course course);
		Task Delete(int id);
	}
}
