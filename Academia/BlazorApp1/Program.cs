using BlazorApp1.Components;
using ClientService.Area;
using ClientService.Curriculum;
using ClientService.Student;
using Microsoft.AspNetCore.Identity;

namespace BlazorApp1
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

			builder.Services.AddIdentityApiEndpoints<IdentityUser>()


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
