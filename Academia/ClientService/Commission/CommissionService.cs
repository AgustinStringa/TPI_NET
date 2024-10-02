using ApplicationCore.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Model;
using Newtonsoft.Json;
using Azure;

namespace ClientService.Commission
{
	public class ErrorResponse
	{
		public string Message { get; set; }
	}
	public class CommissionService : ICommissionService
	{

		private readonly HttpClient _httpClient;
		private string _apiUrl = "";
		public CommissionService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettingsClientService.json", optional: true, reloadOnChange: true)
				.Build();
			_apiUrl = configuration["ApiUrl:Base"];
			_apiUrl += "/commissions/";
		}

		public async Task CreateAsync(ApplicationCore.Model.Commission commission)
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(commission), Encoding.UTF8, "application/json");
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
				if (!response.IsSuccessStatusCode)
				{
					var errorContent = await response.Content.ReadAsStringAsync();
					var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorContent);
					throw new Exception(errorResponse.Message);
				}
				response.EnsureSuccessStatusCode();
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public async Task<IEnumerable<ApplicationCore.Model.Commission>> GetAllAsync()
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.GetStringAsync(_apiUrl);
				var commissions = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Commission>>(response);

				return commissions;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<ApplicationCore.Model.Commission>> GetAllByCurriculumIdAndLevel(int curriculumId, int level)
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.GetStringAsync(_apiUrl + $"?curriculumId={curriculumId}&level={level}");
				var commissions = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Commission>>(response);

				return commissions;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<ApplicationCore.Model.Commission>> GetAllWithCurriculum()
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.GetStringAsync(_apiUrl + "?populate=curriculum");
				var commissions = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Commission>>(response);

				return commissions;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<ApplicationCore.Model.Commission> GetById(int id)
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.GetStringAsync(_apiUrl + id.ToString());
				var commission = JsonConvert.DeserializeObject<ApplicationCore.Model.Commission>(response);

				return commission;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task UpdateAsync(ApplicationCore.Model.Commission commission)
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(commission), Encoding.UTF8, "application/json");
				var response = await _httpClient.PutAsync(_apiUrl + commission.Id.ToString(), jsonContent);
				response.EnsureSuccessStatusCode();
			}
			catch (Exception)
			{
				throw;
			}

		}
	}
}
