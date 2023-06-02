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
            var result = await _http.GetFromJsonAsync<List<CategoryDTO>>("https://localhost:7036/api/Category");
            return result!;
        }
    }
}
