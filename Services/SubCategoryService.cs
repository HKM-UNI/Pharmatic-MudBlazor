using Pharmatic.DTOs;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class SubCategoryService : Global
    {
        private readonly HttpClient _http;
        public SubCategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<SubCategoryDTO>> SubCategoryList()
        {
            var result = await _http.GetFromJsonAsync<List<SubCategoryDTO>>($"http://localhost:{port}/api/subcategories");
            return result!;
        }

        public async Task<SubCategoryDTO> CreateSubCategory(SubCategoryDTO new_subcategory)
        {
            var result = await _http.PostAsJsonAsync($"http://localhost:{port}/api/subcategories/create", new_subcategory);
            var response = await result.Content.ReadFromJsonAsync<SubCategoryDTO>();
            return response!;
        }

        public async Task<SubCategoryDTO> EditSubCategory(int id, SubCategoryDTO subcategory)
        {
            var result = await _http.PatchAsJsonAsync($"http://localhost:{port}/api/subcategories/{id}", subcategory);
            var response = await result.Content.ReadFromJsonAsync<SubCategoryDTO>();
            return response!;
        }

        public async Task<bool> DeleteSubCategory(int id)
        {
            var url = $"http://localhost:{port}/api/subcategories/{id}";
            var response = await _http.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}
