using System.Net.Http.Json;
using Pharmatic.DTOs;

namespace Pharmatic.Services;

public class TypeDoseService
{
    private readonly HttpClient _http;

    public TypeDoseService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<TypeDoseDTO>> TypeDoseList()
    {
        var result = await _http.GetFromJsonAsync<List<TypeDoseDTO>>("dosage_forms");
        return result!;
    }

    public async Task<TypeDoseDTO> CreateTypeDose(TypeDoseDTO newDose)
    {
        var result = await _http.PostAsJsonAsync("dosage_forms/create", newDose);
        var response = await result.Content.ReadFromJsonAsync<TypeDoseDTO>();
        return response!;
    }

    public async Task<TypeDoseDTO> EditTypeDose(int id, TypeDoseDTO dose)
    {
        var result = await _http.PatchAsJsonAsync($"dosage_forms/{id}", dose);
        var response = await result.Content.ReadFromJsonAsync<TypeDoseDTO>();
        return response!;
    }

    public async Task<bool> DeleteTypeDose(int id)
    {
        var response = await _http.DeleteAsync($"dosage_forms/{id}");
        return response.IsSuccessStatusCode;
    }
}