using System.Net.Http.Headers;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using Pharmatic.DTOs;

namespace Pharmatic.Services;

public class ProductService
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
        var token = await _localStorage.GetItemAsStringAsync("token");
        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim('"'));
    }

    public async Task<List<ProductDTO>> ProductList()
    {
        await SetTokenAsync();
        var result = await _http.GetFromJsonAsync<List<ProductDTO>>("products");
        return result!;
    }

    public async Task<List<ProductOverviewDto>> ProductsOverview()
    {
        await SetTokenAsync();
        var result = await _http.GetFromJsonAsync<List<ProductOverviewDto>>("products/overview");
        return result!;
    }

    public async Task<ProductDTO> SearchProduct(string id)
    {
        await SetTokenAsync();
        var result = await _http.GetFromJsonAsync<ProductDTO>($"products/{id}");
        return result!;
    }

    public async Task<ProductDTO> CreateProduct(ProductDTO newProduct)
    {
        await SetTokenAsync();
        var result = await _http.PostAsJsonAsync("products/create", newProduct);
        var response = await result.Content.ReadFromJsonAsync<ProductDTO>();
        return response!;
    }

    public async Task<ProductDTO> EditProduct(int id, ProductDTO product)
    {
        await SetTokenAsync();
        var result = await _http.PatchAsJsonAsync($"products/{id}", product);
        var response = await result.Content.ReadFromJsonAsync<ProductDTO>();
        return response!;
    }

    public async Task<bool> AddPhoto(string id, string fileName, string fileType, string base64Image)
    {
        await SetTokenAsync();
        var imageBytes = Convert.FromBase64String(base64Image);

        using (var content = new MultipartFormDataContent())
        {
            var fileContent = new ByteArrayContent(imageBytes);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(fileType);

            content.Add(fileContent, "image", fileName);

            var result = await _http.PutAsync($"products/{id}/image", content);

            return result.IsSuccessStatusCode;
        }
    }

    public async Task<bool> DeleteProduct(int id)
    {
        await SetTokenAsync();
        var response = await _http.DeleteAsync($"products/{id}");
        return response.IsSuccessStatusCode;
    }
}