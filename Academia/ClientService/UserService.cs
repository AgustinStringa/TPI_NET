using ApplicationCore.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
	public class UserDTO
	{
		public int Id{ get; set; }
		public string Name { get; set; }
		public string Lastname { get; set; }
		public string Role { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		public DateTime BirthDate { get; set; }
		public string? StudentId { get; set; }
		public string? TeacherId { get; set; }
		public string? Cuit { get; set; }
	}
	public class UserService : IUserService
    {
		private readonly HttpClient _httpClient;
		private string _apiUrl = "";

		public UserService(HttpClient httpClient) {
			_httpClient = httpClient;
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettingsClientService.json", optional: true, reloadOnChange: true)
				.Build();
			_apiUrl = configuration["ApiUrl:Base"];
			_apiUrl += "/users/";
		}

		public async Task<IEnumerable<UserDTO>> GetAllAsync()
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.GetStringAsync(_apiUrl);
				var users = JsonConvert.DeserializeObject<List<UserDTO>>(response);
				return users;
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public async Task CreateAsync(User user)
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
				var response = await _httpClient.PostAsync(_apiUrl, jsonContent);
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
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.DeleteAsync(_apiUrl + id.ToString());
				response.EnsureSuccessStatusCode();
			}
			catch (HttpRequestException e)
			{
				// Manejar el error del servidor o problemas de conexión aquí
				Console.WriteLine($"Error al eliminar el recurso: {e.Message}");
				throw;  // Puedes volver a lanzar la excepción si quieres manejarla en capas superiores
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public async Task<User> GetById(int id)
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.GetStringAsync(_apiUrl + id.ToString());
				var user = JsonConvert.DeserializeObject<User>(response);
				return user;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
