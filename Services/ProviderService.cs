using Pharmatic.DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace Pharmatic.Services
{
    public class ProviderService
    {
        private readonly HttpClient _http;
        public ProviderService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ProviderDTO>> ProviderList()
        {
            var url = "http://localhost:7035/api/providers";
            var result = await _http.GetFromJsonAsync<List<ProviderDTO>>(url);
            return result!;
        }

        public async Task<ProviderDTO> SearchProvider(string id)
        {
            var url = "http://localhost:7035/api/providers/" + id;
            var result = await _http.GetFromJsonAsync<ProviderDTO>(url);
            return result!;
        }

        public async Task<ProviderDTO> CreateProvider(ProviderDTO new_provider)
        {
            string json = JsonSerializer.Serialize(new_provider);
            Console.WriteLine(json);

            var result = await _http.PostAsJsonAsync("http://localhost:7035/api/providers/create", new_provider);
            var response = await result.Content.ReadFromJsonAsync<ProviderDTO>();
            return response!;
        }

        public async Task<ProviderDTO> EditProvider(int id, ProviderDTO provider)
        {
            string json = JsonSerializer.Serialize(provider);
            Console.WriteLine(json);

            var result = await _http.PatchAsJsonAsync($"http://localhost:7035/api/providers/{id}", provider);
            var response = await result.Content.ReadFromJsonAsync<ProviderDTO>();
            return response!;
        }
    }
}
