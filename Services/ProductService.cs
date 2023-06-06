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

        public async Task<List<ProductMinimalDTO>> ProductList()
        {
            var url = "https://localhost:7036/api/Product";
            // ⚠️ Experimental flask API endpoint
            // var url = "http://localhost:7035/api/products";
            var result = await _http.GetFromJsonAsync<List<ProductMinimalDTO>>(url);
            return result!;
        }
    }
}
