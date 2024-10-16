﻿using ApplicationCore.Model;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ClientService.Area
{
    public class AreaService : IAreaService
    {
        private readonly HttpClient _httpClient;
        private string _apiUrl = "";
        public AreaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
			var directory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent + "\\ClientService\\";
			var configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettingsClientService.json", optional: true, reloadOnChange: true)
                .Build();
            _apiUrl = configuration["ApiUrl:Base"];
            _apiUrl += "/areas/";
        }

        public async Task<IEnumerable<ApplicationCore.Model.Area>> GetAllAsync()
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.GetStringAsync(_apiUrl);
                var areas = JsonConvert.DeserializeObject<List<ApplicationCore.Model.Area>>(response);
                //var areas = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Area>>(response);
                return areas;
            }
            catch (Exception e)
            {
                throw;
                return null;
            }
        }


		public async Task<ApplicationCore.Model.Area> GetById(int id)
		{
			try
			{
				_httpClient.DefaultRequestHeaders.Accept.Clear();
				_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.GetStringAsync(_apiUrl + id.ToString());
				var area = JsonConvert.DeserializeObject<ApplicationCore.Model.Area>(response);
				return area;
			}
			catch (Exception e)
			{
				throw;
				return null;
			}
		}

		public async Task CreateAsync(ApplicationCore.Model.Area area)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(area), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_apiUrl, jsonContent);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task UpdateAsync(ApplicationCore.Model.Area area)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(new { area.Id, area.Description }), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(_apiUrl + area.Id.ToString(), jsonContent);
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
    }
}
