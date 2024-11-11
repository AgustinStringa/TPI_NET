using ApplicationCore.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{

	public class UserService : IUserService
	{
		private readonly HttpClient _httpClient;
		private string _apiUrl = "";

		public class UserLoggedDTO
		{
			public User User { get; set; }

			public string jwt { get; set; }
		}

		public UserService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettingsClientService.json");
			var directory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent + "\\ClientService\\";
			var configuration = new ConfigurationBuilder()
				.SetBasePath(directory)
				.AddJsonFile("appsettingsClientService.json", optional: true, reloadOnChange: true)
				.Build();
			_apiUrl = configuration["ApiUrl:Base"];
			_apiUrl += "/users/";
		}

		public async Task<IEnumerable<ApplicationCore.Services.UserDTO>> GetAll()
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.GetStringAsync(_apiUrl);
				var users = JsonConvert.DeserializeObject<List<ApplicationCore.Services.UserDTO>>(response);
				return users;
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
			catch (HttpRequestException e)
			{
				throw;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<UserLoggedDTO> ValidateCredentials(string username, string password)
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(new ApplicationCore.Services.LoginDto
				{
					Password = password,
					Username = username,
				}), Encoding.UTF8, "application/json");

				var response = await _httpClient.PostAsync(_apiUrl + "auth", jsonContent);
				if (response.IsSuccessStatusCode)
				{
					var responseContent = await response.Content.ReadAsStringAsync();
					var user = JsonConvert.DeserializeObject<UserLoggedDTO>(responseContent);
					return user;
				}
				return null;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
