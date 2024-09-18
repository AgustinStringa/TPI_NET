using Domain.Model;
using Newtonsoft.Json;

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
                var _apiUrl = "https://localhost:7255/api/areas";
                var response = _httpClient.GetStringAsync(_apiUrl);
                var areas = JsonConvert.DeserializeObject<List<Area>>(response.Result);
                return areas;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
