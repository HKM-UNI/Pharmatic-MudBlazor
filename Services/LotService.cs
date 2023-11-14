using Blazored.LocalStorage;
using Pharmatic.DTOs;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Pharmatic.Services
{
    public class LotService : Global
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        public LotService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }

        private async Task SetTokenAsync()
        {
            string token = await _localStorage.GetItemAsStringAsync("token");
            if (token != null)
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim('"'));
        }

        public async Task<List<LotDTO>> LotList(string? productNo)
        {
            var url = $"http://localhost:{port}/api/lots?product_no=" + productNo;
            await SetTokenAsync();
            var result = await _http.GetFromJsonAsync<List<LotDTO>>(url);

            return result!;
        }

        public async Task<List<LotDTO>> LotList()
        {
            var url = $"http://localhost:{port}/api/lots";
            await SetTokenAsync();
            var result = await _http.GetFromJsonAsync<List<LotDTO>>(url);

            return result!;
        }

        public async Task<LotDTO> SearchLot(string lotNo)
        {
            var url = $"http://localhost:{port}/api/lots/" + lotNo;
            await SetTokenAsync();
            var result = await _http.GetFromJsonAsync<LotDTO>(url);

            return result!;
        }

        public async Task<(LotDTO? lot, bool statusCode)> CreateLot(LotDTO new_lot)
        {
            string json = JsonSerializer.Serialize(new_lot);
            Console.WriteLine(json);

            await SetTokenAsync();
            var result = await _http.PostAsJsonAsync($"http://localhost:{port}/api/lots/create", new_lot);
            var statusCode = result.IsSuccessStatusCode;
            var lot = await result.Content.ReadFromJsonAsync<LotDTO>();

            return (lot, statusCode);
        }

    }
}
