using Blazored.LocalStorage;
using Pharmatic.DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class CategoryService : Global
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
        }

        public async Task<List<CategoryDTO>> CategoryList()
        {
            var url = $"http://localhost:{port}/api/categories";
            var result = await _http.GetFromJsonAsync<List<CategoryDTO>>(url);
            return result!;
        }

        public async Task<CategoryDTO> CreateCategory(CategoryDTO new_category)
        {
            var result = await _http.PostAsJsonAsync($"http://localhost:{port}/api/categories/create", new_category);
            var response = await result.Content.ReadFromJsonAsync<CategoryDTO>();
            return response!;
        }

        public async Task<CategoryDTO> EditCategory(int id, CategoryDTO category)
        {
            var result = await _http.PatchAsJsonAsync($"http://localhost:{port}/api/categories/{id}", category);
            var response = await result.Content.ReadFromJsonAsync<CategoryDTO>();
            return response!;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var url = $"http://localhost:{port}/api/categories/{id}";
            var response = await _http.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}
