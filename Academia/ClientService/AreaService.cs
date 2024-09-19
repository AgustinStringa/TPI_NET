using Domain.Model;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace ClientService
{
    public static class AreaService
    {
        public static async Task<List<Area>> GetAll()
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var _apiUrl = configuration["ApiUrl:Base"];
                _apiUrl += "/areas/";
                var response = _httpClient.GetStringAsync(_apiUrl);
                var areas = JsonConvert.DeserializeObject<List<Area>>(response.Result);
                return areas;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static async Task Create(Area area)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var _apiUrl = configuration["ApiUrl:Base"];
                _apiUrl += "/areas/";
                using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(area), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_apiUrl, jsonContent);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task Update(Area area)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var _apiUrl = configuration["ApiUrl:Base"];
                _apiUrl += "/areas/" + area.Id.ToString();
                using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(area), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(_apiUrl, jsonContent);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task Delete(int id)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var _apiUrl = configuration["ApiUrl:Base"];
                _apiUrl += "/areas/" + id.ToString();
                var response = await _httpClient.DeleteAsync(_apiUrl);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
