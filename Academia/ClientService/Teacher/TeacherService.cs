using ApplicationCore.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Teacher
{
	public class TeacherService : ITeacherService
	{
		private readonly HttpClient _httpClient;
		private string _apiUrl = "";
		public TeacherService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			var directory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent + "\\ClientService\\";
			var configuration = new ConfigurationBuilder()
				.SetBasePath(directory)
				.AddJsonFile("appsettingsClientService.json", optional: true, reloadOnChange: true)
				.Build();
			_apiUrl = configuration["ApiUrl:Base"];
			_apiUrl += "/users/teachers/";
		}
		public async Task CreateAsync(ApplicationCore.Model.Teacher teacher)
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(teacher), Encoding.UTF8, "application/json");
				var response = await _httpClient.PostAsync(_apiUrl, jsonContent);
				response.EnsureSuccessStatusCode();
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public async Task<IEnumerable<ApplicationCore.Model.Teacher>> GetAllAsync()
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.GetStringAsync(_apiUrl);
				var teachers = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Teacher>>(response);
				return teachers;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<ApplicationCore.Model.Teacher> GetById(int id)
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.GetStringAsync(_apiUrl + id.ToString());
				var teacher = JsonConvert.DeserializeObject<ApplicationCore.Model.Teacher>(response);
				return teacher;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
