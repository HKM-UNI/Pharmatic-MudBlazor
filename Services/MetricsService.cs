using System.Net.Http.Json;
using Pharmatic.DTOs;

namespace Pharmatic.Services;

public class MetricsService
{
    private readonly HttpClient _http;

    public MetricsService(HttpClient http)
    {
        _http = http;
    }

    public async Task<SummaryDTO> GetSummary()
    {
        var result = await _http.GetFromJsonAsync<SummaryDTO>("stats/summary");
        return result!;
    }

    public async Task<List<InvoicingSummaryDTO>> GetInvoicingSummary(string startDate, string endDate)
    {
        var url = $"stats/invoicing?from={startDate}&to={endDate}";
        var result = await _http.GetFromJsonAsync<List<InvoicingSummaryDTO>>(url);
        return result!;
    }
}