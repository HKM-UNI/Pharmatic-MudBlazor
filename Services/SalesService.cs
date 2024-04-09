using System.Net.Http.Json;
using Pharmatic.DTOs;

namespace Pharmatic.Services;

public class SalesService
{
    private readonly HttpClient _http;

    public SalesService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<SalesHistoryDto>> SalesHistory()
    {
        var result = await _http.GetFromJsonAsync<List<SalesHistoryDto>>("sales/history");

        return result!;
    }

    public async Task<SalesInvoiceDTO> CreateInvoice(SalesInvoiceDTO newInvoice)
    {
        var result = await _http.PostAsJsonAsync("sales/create", newInvoice);
        var response = await result.Content.ReadFromJsonAsync<SalesInvoiceDTO>();
        return response!;
    }
}