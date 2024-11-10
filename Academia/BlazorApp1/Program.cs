using UI.Web.Components;
using ClientService.Administrative;
using ClientService;
using ClientService.Area;
using ClientService.Curriculum;
using ClientService.Student;
using ClientService.Teacher;
using UI.Web.Services;
using ClientService.Course;
using ClientService.Commission;
using ClientService.StudentCourse;

namespace UI.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorComponents()
				.AddInteractiveServerComponents();
			builder.Services.AddBlazorBootstrap();


			builder.Services.AddHttpClient();
            builder.Services.AddHttpClient<IStudentService, StudentService>();
            builder.Services.AddScoped<IAreaService, AreaService>();
			builder.Services.AddScoped<ICurriculumService, CurriculumService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<IAdministrativeService, AdministrativeService>();
			builder.Services.AddScoped<ITeacherService, TeacherService>();
			builder.Services.AddScoped<UserStateService>();
			builder.Services.AddScoped<ICourseService, CourseService>();
			builder.Services.AddScoped<ICommissionService,  CommissionService>();
			builder.Services.AddScoped<IStudentCourseService,  StudentCourseService>();



			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();
			app.UseAntiforgery();

			app.MapRazorComponents<App>()
				.AddInteractiveServerRenderMode();

			app.Run();
		}
	}
}
