using Blazored.LocalStorage;
using Pharmatic.DTOs;
using Pharmatic.Pages;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Pharmatic.Services
{
    public class ProductService : Global
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        public ProductService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }

        private async Task SetTokenAsync()
        {
            string token = await _localStorage.GetItemAsStringAsync("token");
            Console.WriteLine(token);
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<ProductDTO>> ProductList()
        {
            var url = $"http://localhost:{port}/api/products";
            await SetTokenAsync();
            var result = await _http.GetFromJsonAsync<List<ProductDTO>>(url);
            return result!;
        }

        public async Task<ProductDTO> SearchProduct(string id)
        {
            var url = $"http://localhost:{port}/api/products/" + id;
            await SetTokenAsync();
            var result = await _http.GetFromJsonAsync<ProductDTO>(url);
            return result!;
        }

        public async Task<ProductDTO> CreateProduct(ProductDTO new_product)
        {
            var result = await _http.PostAsJsonAsync($"http://localhost:{port}/api/products/create", new_product);
            var response = await result.Content.ReadFromJsonAsync<ProductDTO>();
            return response!;
        }

        public async Task<ProductDTO> EditProduct(int id, ProductDTO product)
        {
            var result = await _http.PatchAsJsonAsync($"http://localhost:{port}/api/products/{id}", product);
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

                var result = await _http.PutAsync($"http://localhost:{port}/api/products/{id}/image", content);

                return result.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var url = $"http://localhost:{port}/api/products/{id}";
            var response = await _http.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }

    }
}
