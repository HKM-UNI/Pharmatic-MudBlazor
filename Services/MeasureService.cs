using System.Net.Http.Json;
using Pharmatic.DTOs;

namespace Pharmatic.Services;

public class MeasureService
{
    private readonly HttpClient _http;

    public MeasureService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<MeasureDTO>> MeasureList()
    {
        var result = await _http.GetFromJsonAsync<List<MeasureDTO>>("measures");
        return result!;
    }

    public async Task<MeasureDTO> CreateMeasure(MeasureDTO newMeasure)
    {
        var result = await _http.PostAsJsonAsync("measures/create", newMeasure);
        var response = await result.Content.ReadFromJsonAsync<MeasureDTO>();
        return response!;
    }

    public async Task<MeasureDTO> EditMeasure(int id, MeasureDTO measure)
    {
        var result = await _http.PatchAsJsonAsync($"measures/{id}", measure);
        var response = await result.Content.ReadFromJsonAsync<MeasureDTO>();
        return response!;
    }

    public async Task<bool> DeleteMeasure(int id)
    {
        var response = await _http.DeleteAsync($"measures/{id}");
        return response.IsSuccessStatusCode;
    }
}