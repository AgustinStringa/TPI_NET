using Domain.Model;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace ClientService
{
    public class AreaService : IAreaService
    {
        private readonly HttpClient _httpClient;
        private string _apiUrl = "";
        public AreaService()
        {
            _httpClient = new HttpClient();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettingsClientService.json", optional: true, reloadOnChange: true)
                .Build();
            _apiUrl = configuration["ApiUrl:Base"];
            _apiUrl += "/areas/";
        }
        public async Task<IEnumerable<Area>> GetAllAsync()
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await _httpClient.GetStringAsync(_apiUrl);
                var areas = JsonConvert.DeserializeObject<List<Area>>(response);
                return areas;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task CreateAsync(Area area)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(area), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_apiUrl, jsonContent);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateAsync(Area area)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(area), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(_apiUrl + area.Id.ToString(), jsonContent);
            }
            catch (Exception e)
            {
                throw e;
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
                throw e;
            }
        }
    }
}
