﻿using Pharmatic.DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace Pharmatic.Services
{
    public class ProviderService : Global
    {
        private readonly HttpClient _http;
        public ProviderService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ProviderDTO>> ProviderList()
        {
            var url = $"http://localhost:{port}/api/providers";
            var result = await _http.GetFromJsonAsync<List<ProviderDTO>>(url);
            return result!;
        }

        public async Task<int> ProvidersCount()
        {
            var url = $"http://localhost:{port}/api/providers";
            var result = await _http.GetFromJsonAsync<List<ProviderDTO>>(url);
            return result?.Count ?? 0;
        }

        public async Task<ProviderDTO> SearchProvider(string id)
        {
            var url = $"http://localhost:{port}/api/providers/" + id;
            var result = await _http.GetFromJsonAsync<ProviderDTO>(url);
            return result!;
        }

        public async Task<ProviderDTO> CreateProvider(ProviderDTO new_provider)
        {
            var result = await _http.PostAsJsonAsync($"http://localhost:{port}/api/providers/create", new_provider);
            var response = await result.Content.ReadFromJsonAsync<ProviderDTO>();
            return response!;
        }

        public async Task<ProviderDTO> EditProvider(int id, ProviderDTO provider)
        {
            var result = await _http.PatchAsJsonAsync($"http://localhost:{port}/api/providers/{id}", provider);
            var response = await result.Content.ReadFromJsonAsync<ProviderDTO>();
            return response!;
        }

        public async Task<bool> DeleteProvider(int id)
        {
            var url = $"http://localhost:{port}/api/providers/{id}";
            var response = await _http.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}
