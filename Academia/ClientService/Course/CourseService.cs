﻿using ApplicationCore.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Course
{
	public class CourseService : ICourseService
	{
		private HttpClient httpClient;
		private string _apiUrl = "";

		public CourseService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettingsClientService.json", optional: true, reloadOnChange: true)
				.Build();
			_apiUrl = configuration["ApiUrl:Base"];
			_apiUrl += "/courses/";
		}

		public async Task CreateAsync(ApplicationCore.Model.Course course)
		{
			try
			{
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(course), Encoding.UTF8, "application/json");
				var response = await httpClient.PostAsync(_apiUrl, jsonContent);
				response.EnsureSuccessStatusCode();
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public async Task DeleteAsync(int id)
		{
			try
			{
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await httpClient.DeleteAsync(_apiUrl + id.ToString());
				response.EnsureSuccessStatusCode();
			}
			catch (HttpRequestException e)
			{
				Console.WriteLine($"Error al eliminar el recurso: {e.Message}");
				throw;
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public async Task<IEnumerable<ApplicationCore.Model.Course>> GetAllAsync()
		{
			try
			{
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await httpClient.GetStringAsync(_apiUrl + "?populate=commission,subject,teachers");
				var courses = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Course>>(response);
				return courses;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public IEnumerable<ApplicationCore.Model.Course> GetAllSync()
		{
			try
			{
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = httpClient.GetAsync(_apiUrl + "?populate=commission,subject,teachers").Result;
				var courses = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Course>>(response.Content.ReadAsStringAsync().Result);
				return courses;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<IEnumerable<ApplicationCore.Model.Course>> GetAllWithTeachers()
		{
			try
			{
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await httpClient.GetStringAsync(_apiUrl + "?populate=subject,commission,teachers");
				var courses = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Course>>(response);
				return courses;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<ApplicationCore.Model.Course>> GetAvailableCourses(ApplicationCore.Model.Student student)
		{
			try
			{
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await httpClient.GetStringAsync(_apiUrl + $"availablecourses?studentId={student.Id}");
				var courses = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Course>>(response);
				return courses;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task UpdateAsync(ApplicationCore.Model.Course course)
		{
			try
			{
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(course), Encoding.UTF8, "application/json");
				var response = await httpClient.PutAsync(_apiUrl + course.Id.ToString(), jsonContent);
				response.EnsureSuccessStatusCode();
			}
			catch (Exception e)
			{
				throw;
			}
		}
	}
}
