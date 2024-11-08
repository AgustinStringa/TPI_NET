using ApplicationCore.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Student
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;
        private string _apiUrl = "";
        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettingsClientService.json", optional: true, reloadOnChange: true)
                .Build();
            _apiUrl = configuration["ApiUrl:Base"];
            _apiUrl += "/users/students/";
        }

        public async Task CreateAsync(ApplicationCore.Model.Student student)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_apiUrl, jsonContent);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw;
            }
        }

		public async Task<IEnumerable<ApplicationCore.Model.Student>> GetAllAsync()
		{
            try
            {
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.GetStringAsync(_apiUrl);
				var students = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Student>>(response);
				return students;
			}
            catch (Exception)
            {
                throw;
            }
		}

		public async Task<ApplicationCore.Model.Student> GetById(int id)
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.GetStringAsync(_apiUrl + id.ToString());
				var student = JsonConvert.DeserializeObject<ApplicationCore.Model.Student>(response);
				return student;
			}
			catch (Exception)
			{
				throw;
			}
		}

        public async Task DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(_apiUrl + id.ToString());
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(ApplicationCore.Model.Student student)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(_apiUrl + student.Id.ToString(), jsonContent);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
