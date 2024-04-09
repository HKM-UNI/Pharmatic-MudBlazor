using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Blazored.LocalStorage;
using Pharmatic.DTOs;

namespace Pharmatic.Services;

public class LotService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;

    public LotService(HttpClient http, ILocalStorageService localStorage)
    {
        _http = http;
        _localStorage = localStorage;
    }

    private async Task SetTokenAsync()
    {
        var token = await _localStorage.GetItemAsStringAsync("token");
        if (token != null)
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim('"'));
    }

    public async Task<List<LotDTO>> LotList(string? productNo)
    {
        var url = $"lots?product_no={productNo}";
        await SetTokenAsync();
        var result = await _http.GetFromJsonAsync<List<LotDTO>>(url);

        return result!;
    }

    public async Task<(LotDTO? lot, bool statusCode)> CreateLot(LotDTO newLot)
    {
        var json = JsonSerializer.Serialize(newLot);
        Console.WriteLine(json);

        await SetTokenAsync();
        var result = await _http.PostAsJsonAsync("lots/create", newLot);
        var statusCode = result.IsSuccessStatusCode;
        var lot = await result.Content.ReadFromJsonAsync<LotDTO>();

        return (lot, statusCode);
    }

    public async Task<List<ExpiredDTO>> ExpirationReport()
    {
        await SetTokenAsync();
        var jsonResponse = await _http.GetStringAsync("lots/expiration_report");
        Console.WriteLine($"Expiration Report JSON Response: {jsonResponse}");

        // Deserializar el JSON a la lista de ExpiredDTO
        var result = JsonSerializer.Deserialize<List<ExpiredDTO>>(jsonResponse);

        return result ?? new List<ExpiredDTO>();
    }

    public async Task<List<RecentLotDTO>> RecentlyAdded()
    {
        await SetTokenAsync();
        var result = await _http.GetFromJsonAsync<List<RecentLotDTO>>("lots/recent_updates");

        return result!;
    }
}