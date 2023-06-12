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
            var url = "https://localhost:7036/api/Provider";
            var result = await _http.GetFromJsonAsync<List<ProviderDTO>>(url);
            return result!;
        }
    }
}
