using System.Net.Http.Json;
using Pharmatic.DTOs;

namespace Pharmatic.Services;

public class ProviderService
{
    private readonly HttpClient _http;

    public ProviderService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<ProviderDTO>> ProviderList()
    {
        var result = await _http.GetFromJsonAsync<List<ProviderDTO>>("providers");
        return result!;
    }

    public async Task<ProviderDTO> SearchProvider(string id)
    {
        var result = await _http.GetFromJsonAsync<ProviderDTO>($"providers/{id}");
        return result!;
    }

    public async Task<ProviderDTO> CreateProvider(ProviderDTO new_provider)
    {
        var result = await _http.PostAsJsonAsync("providers/create", new_provider);
        var response = await result.Content.ReadFromJsonAsync<ProviderDTO>();
        return response!;
    }

    public async Task<ProviderDTO> EditProvider(int id, ProviderDTO provider)
    {
        var result = await _http.PatchAsJsonAsync($"providers/{id}", provider);
        var response = await result.Content.ReadFromJsonAsync<ProviderDTO>();
        return response!;
    }

    public async Task<bool> DeleteProvider(int id)
    {
        var response = await _http.DeleteAsync($"providers/{id}");
        return response.IsSuccessStatusCode;
    }
}