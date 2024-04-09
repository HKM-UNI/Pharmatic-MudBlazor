using System.Net.Http.Json;
using Pharmatic.DTOs;

namespace Pharmatic.Services;

public class RouteOfAdministrationService
{
    private readonly HttpClient _http;

    public RouteOfAdministrationService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<RouteOfAdmDTO>> RoutesOfAdmList()
    {
        var result = await _http.GetFromJsonAsync<List<RouteOfAdmDTO>>("admin_routes");
        return result!;
    }

    public async Task<RouteOfAdmDTO> CreateRoa(RouteOfAdmDTO newRoa)
    {
        var result = await _http.PostAsJsonAsync("admin_routes/create", newRoa);
        var response = await result.Content.ReadFromJsonAsync<RouteOfAdmDTO>();
        return response!;
    }

    public async Task<RouteOfAdmDTO> EditRoa(int id, RouteOfAdmDTO roa)
    {
        var result = await _http.PatchAsJsonAsync($"admin_routes/{id}", roa);
        var response = await result.Content.ReadFromJsonAsync<RouteOfAdmDTO>();
        return response!;
    }

    public async Task<bool> DeleteRoa(int id)
    {
        var response = await _http.DeleteAsync($"admin_routes/{id}");
        return response.IsSuccessStatusCode;
    }
}