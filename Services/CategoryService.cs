using System.Net.Http.Json;
using Blazored.LocalStorage;
using Pharmatic.DTOs;

namespace Pharmatic.Services;

public class CategoryService
{
    private readonly HttpClient _http;

    public CategoryService(HttpClient http, ILocalStorageService localStorage)
    {
        _http = http;
    }

    public async Task<List<CategoryDTO>> CategoryList()
    {
        var result = await _http.GetFromJsonAsync<List<CategoryDTO>>("categories");
        return result!;
    }

    public async Task<CategoryDTO> CreateCategory(CategoryDTO newCategory)
    {
        var result = await _http.PostAsJsonAsync("categories/create", newCategory);
        var response = await result.Content.ReadFromJsonAsync<CategoryDTO>();
        return response!;
    }

    public async Task<CategoryDTO> EditCategory(int id, CategoryDTO category)
    {
        var result = await _http.PatchAsJsonAsync($"categories/{id}", category);
        var response = await result.Content.ReadFromJsonAsync<CategoryDTO>();
        return response!;
    }

    public async Task<bool> DeleteCategory(int id)
    {
        var response = await _http.DeleteAsync($"categories/{id}");
        return response.IsSuccessStatusCode;
    }
}