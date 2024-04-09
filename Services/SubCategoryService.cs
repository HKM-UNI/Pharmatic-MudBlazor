using System.Net.Http.Json;
using Pharmatic.DTOs;

namespace Pharmatic.Services;

public class SubCategoryService
{
    private readonly HttpClient _http;

    public SubCategoryService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<SubCategoryDTO>> SubCategoryList()
    {
        var result = await _http.GetFromJsonAsync<List<SubCategoryDTO>>("subcategories");
        return result!;
    }

    public async Task<SubCategoryDTO> CreateSubCategory(SubCategoryDTO newSubcategory)
    {
        var result = await _http.PostAsJsonAsync("subcategories/create", newSubcategory);
        var response = await result.Content.ReadFromJsonAsync<SubCategoryDTO>();
        return response!;
    }

    public async Task<SubCategoryDTO> EditSubCategory(int id, SubCategoryDTO subcategory)
    {
        var result = await _http.PatchAsJsonAsync($"subcategories/{id}", subcategory);
        var response = await result.Content.ReadFromJsonAsync<SubCategoryDTO>();
        return response!;
    }

    public async Task<bool> DeleteSubCategory(int id)
    {
        var response = await _http.DeleteAsync($"subcategories/{id}");
        return response.IsSuccessStatusCode;
    }
}