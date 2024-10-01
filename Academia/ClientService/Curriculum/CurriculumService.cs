using ApplicationCore.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Curriculum
{
	public class CurriculumService : ICurriculumService
	{
		private readonly HttpClient _httpClient;
		private string _apiUrl = "";
		public CurriculumService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettingsClientService.json", optional: true, reloadOnChange: true)
				.Build();
			_apiUrl = configuration["ApiUrl:Base"];
			_apiUrl += "/curriculums/";
		}
		public async Task CreateAsync(ApplicationCore.Model.Curriculum curriculum)
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(curriculum), Encoding.UTF8, "application/json");
				var response = await _httpClient.PostAsync(_apiUrl, jsonContent);
				response.EnsureSuccessStatusCode();
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
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.DeleteAsync(_apiUrl + id.ToString());
				response.EnsureSuccessStatusCode();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<ApplicationCore.Model.Curriculum>> GetAllAsync()
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.GetStringAsync(_apiUrl);
				var curriculums = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Curriculum>>(response);

				return curriculums;
			}
			catch (Exception)
			{

				throw;
			}

		}

		public async Task<IEnumerable<ApplicationCore.Model.Curriculum>> GetAllWithAreaAsync()
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.GetStringAsync(_apiUrl + "?populate=area");
				var curriculums = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Curriculum>>(response);

				return curriculums;
			}
			catch (Exception)
			{

				throw;
			}

		}

		public async Task<IEnumerable<ApplicationCore.Model.Curriculum>> GetAllByAreaId(int areaId)
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.GetStringAsync(_apiUrl + $"?areaId={areaId}");
				var curriculums = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Curriculum>>(response);

				return curriculums;
			}
			catch (Exception)
			{

				throw;
			}

		}

		public async Task UpdateAsync(ApplicationCore.Model.Curriculum curriculum)
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(curriculum), Encoding.UTF8, "application/json");
				var response = await _httpClient.PutAsync(_apiUrl + curriculum.Id.ToString(), jsonContent);
				response.EnsureSuccessStatusCode();
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
