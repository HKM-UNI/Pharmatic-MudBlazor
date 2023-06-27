using Pharmatic.DTOs;
using System.Net.Http.Json;

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
    }
}
