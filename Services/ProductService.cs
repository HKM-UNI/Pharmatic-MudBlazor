using Pharmatic.DTOs;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class ProductService
    {
        private readonly HttpClient _http;
        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ProductDTO>> ProductList()
        {
            var result = await _http.GetFromJsonAsync<List<ProductDTO>>("https://localhost:7036/api/Product");
            return result!;
        }
    }
}
