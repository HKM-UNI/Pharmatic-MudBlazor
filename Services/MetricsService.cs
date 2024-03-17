using Pharmatic.DTOs;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class MetricsService : Global
    {
        private readonly HttpClient _http;
        private string BaseUrl => $"http://localhost:{port}/api/stats";

        public MetricsService(HttpClient http)
        {
            _http = http;
        }

        public async Task<SummaryDTO> GetSummary()
        {
            var result = await _http.GetFromJsonAsync<SummaryDTO>($"{BaseUrl}/summary");
            return result!;
        }

        public async Task<List<InvoicingSummaryDTO>> GetInvoicingSummary(string startDate, string endDate)
        {
            var url = $"{BaseUrl}/invoicing?from={startDate}&to={endDate}";
            var result = await _http.GetFromJsonAsync<List<InvoicingSummaryDTO>>(url);
            return result!;
        }
    }
}
