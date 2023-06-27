using Pharmatic.DTOs;
using Pharmatic.Pages;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

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
            var url = "http://localhost:7035/api/products/" + id;
            var result = await _http.GetFromJsonAsync<ProductDTO>(url);
            return result!;
        }

        public async Task<ProductDTO> CreateProduct(ProductDTO new_product)
        {
            var result = await _http.PostAsJsonAsync("http://localhost:7035/api/products/create", new_product);
            var response = await result.Content.ReadFromJsonAsync<ProductDTO>();
            return response!;
        }

        public async Task<ProductDTO> EditProduct(int id, ProductPATCHDTO product)
        {
            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var result = await _http.PatchAsync($"http://localhost:7035/api/products/{id}", content);
            var response = await result.Content.ReadFromJsonAsync<ProductDTO>();
            return response!;
        }

        public async Task<bool> AddPhoto(string id, string fileName, string fileType, string base64Image)
        {
            var imageBytes = Convert.FromBase64String(base64Image);

            using (var content = new MultipartFormDataContent())
            {
                var fileContent = new ByteArrayContent(imageBytes);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(fileType);

                content.Add(fileContent, "image", fileName);

                var result = await _http.PutAsync($"http://localhost:7035/api/products/{id}/image", content);
                result.EnsureSuccessStatusCode();

                return true;
            }
        }


    }
}
