using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/users/students")]
	[ApiController]
	public class StudentController : Controller
	{
		private StudentService studentService;
		public StudentController(StudentService studentService) { 
			this.studentService = studentService;
		}
    }
}
