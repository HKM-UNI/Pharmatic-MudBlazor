using System.Net.Http.Json;
using Pharmatic.DTOs;

namespace Pharmatic.Services;

public class TagService
{
    private readonly HttpClient _http;

    public TagService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<TagDTO>> TagList()
    {
        var result = await _http.GetFromJsonAsync<List<TagDTO>>("tags");
        return result!;
    }

    public async Task<TagDTO> CreateTag(TagDTO newTag)
    {
        var result = await _http.PostAsJsonAsync("tags/create", newTag);
        var response = await result.Content.ReadFromJsonAsync<TagDTO>();
        return response!;
    }

    public async Task<TagDTO> EditTag(int id, TagDTO tag)
    {
        var result = await _http.PatchAsJsonAsync($"tags/{id}", tag);
        var response = await result.Content.ReadFromJsonAsync<TagDTO>();
        return response!;
    }

    public async Task<bool> DeleteTag(int id)
    {
        var response = await _http.DeleteAsync($"tags/{id}");
        return response.IsSuccessStatusCode;
    }
}