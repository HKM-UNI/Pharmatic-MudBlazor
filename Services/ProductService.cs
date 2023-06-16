using Pharmatic.DTOs;
using Pharmatic.Pages;
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
            //var url = "https://localhost:7036/api/Product";
            // ⚠️ Experimental flask API endpoint
            var url = "http://localhost:7035/api/products";
            var result = await _http.GetFromJsonAsync<List<ProductDTO>>(url);
            return result!;
        }

        public async Task<ProductDTO> SearchProduct(string id)
        {
            var url = $"http://localhost:7035/api/products/" + id;
            var result = await _http.GetFromJsonAsync<ProductDTO>(url);
            return result!;
        }
    }
}
