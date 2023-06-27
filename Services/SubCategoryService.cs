using Pharmatic.DTOs;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class SubCategoryService
    {
        private readonly HttpClient _http;
        public SubCategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<SubCategoryDTO>> SubCategoryList()
        {
            var result = await _http.GetFromJsonAsync<List<SubCategoryDTO>>("http://localhost:7035/api/subcategories");
            return result!;
        }
    }
}
