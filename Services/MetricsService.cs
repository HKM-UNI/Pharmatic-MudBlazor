using Blazored.LocalStorage;
using Pharmatic.DTOs;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class MetricsService : Global
    {
        private readonly HttpClient _http;
        private string baseUrl => $"http://localhost:{port}/api/stats";

        public MetricsService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
        }

        public async Task<SummaryDTO> GetSummary()
        {
            var result = await _http.GetFromJsonAsync<SummaryDTO>($"{baseUrl}/summary");
            return result!;
        }
    }
}
