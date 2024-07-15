using CustomerApp.UI.Models;
using System.Text;
using System.Text.Json;

namespace CustomerApp.UI.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetApiDataAsync<T>(string apiUrl)
        {
            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                //using var jsonResponse = await response.Content.ReadAsStreamAsync();
                //return await JsonSerializer.DeserializeAsync<T>(jsonResponse);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(jsonResponse);
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task PostAsync<T>(string uri, T item)
        {
            var jsonContent = JsonSerializer.Serialize(item);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task PutAsync<T>(string uri, T item)
        {
            var jsonContent = JsonSerializer.Serialize(item);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(string uri)
        {
            var response = await _httpClient.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();
        }
    }
}
