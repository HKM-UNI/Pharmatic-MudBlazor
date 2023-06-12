using Pharmatic.DTOs;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class ProductCompositionService
    {
        private readonly HttpClient _http;
        public ProductCompositionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ProductCompositionDTO>> MeasureList()
        {
            var url = "https://localhost:7036/api/ProductComposition";
            var result = await _http.GetFromJsonAsync<List<ProductCompositionDTO>>(url);
            return result!;
        }
    }
}
