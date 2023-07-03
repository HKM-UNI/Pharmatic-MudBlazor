using Pharmatic.DTOs;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class CategoryService
    {
        private readonly HttpClient _http;
        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CategoryDTO>> CategoryList()
        {
            var url = "http://localhost:7035/api/categories";
            var result = await _http.GetFromJsonAsync<List<CategoryDTO>>(url);
            return result!;
        }

        public async Task<CategoryDTO> CreateCategory(CategoryDTO new_category)
        {
            var result = await _http.PostAsJsonAsync("http://localhost:7035/api/categories/create", new_category);
            var response = await result.Content.ReadFromJsonAsync<CategoryDTO>();
            return response!;
        }

        public async Task<CategoryDTO> EditCategory(int id, CategoryDTO category)
        {
            var result = await _http.PatchAsJsonAsync($"http://localhost:7035/api/categories/{id}", category);
            var response = await result.Content.ReadFromJsonAsync<CategoryDTO>();
            return response!;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var url = $"http://localhost:7035/api/categories/{id}";
            var response = await _http.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}
