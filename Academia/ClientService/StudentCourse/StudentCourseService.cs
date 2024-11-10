using ApplicationCore.Model;
using ApplicationCore.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.StudentCourse
{
	public class StudentCourseService : IStudentCourseService
	{
		private HttpClient httpClient;
		private string _apiUrl = "";

		public StudentCourseService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
            var directory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent + "\\ClientService\\";
            var configuration = new ConfigurationBuilder()
				.SetBasePath(directory)
				.AddJsonFile("appsettingsClientService.json", optional: true, reloadOnChange: true)
				.Build();
			_apiUrl = configuration["ApiUrl:Base"];
			_apiUrl += "/student-courses/";
		}

		public async Task CreateAsync(ApplicationCore.Model.StudentCourse studentCourse)
		{
			try
			{
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(studentCourse), Encoding.UTF8, "application/json");
				var response = await httpClient.PostAsync(_apiUrl, jsonContent);
				response.EnsureSuccessStatusCode();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<IEnumerable<ApplicationCore.Model.StudentCourse>> GetByUserId(int userId)
		{
			try
			{
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await httpClient.GetStringAsync(_apiUrl + $"?userId={userId}");
				var courses = JsonConvert.DeserializeObject<List<ApplicationCore.Model.StudentCourse>>(response);
				return courses;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task QualifyCourse(int studentCourseId, CalificationCourse calification)
		{
			try
			{
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(calification), Encoding.UTF8, "application/json");
				var response = await httpClient.PatchAsync(_apiUrl + $"+{studentCourseId}", jsonContent);
				response.EnsureSuccessStatusCode();
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
