using ApplicationCore.Model;
namespace BlazorApp1.Services
{
	public class UserStateService
	{

		public Student User = new Student();

		public string UserRole = "";

		public bool isUserLoggedIn = false;
	}
}
