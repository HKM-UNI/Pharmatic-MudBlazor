using Pharmatic.DTOs;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class TypeDoseService : Global
    {
        private readonly HttpClient _http;
        public TypeDoseService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TypeDoseDTO>> TypeDoseList()
        {
            var url = $"http://localhost:{port}/api/dosage_forms";
            var result = await _http.GetFromJsonAsync<List<TypeDoseDTO>>(url);
            return result!;
        }

        public async Task<TypeDoseDTO> CreateTypeDose(TypeDoseDTO new_dose)
        {
            var result = await _http.PostAsJsonAsync($"http://localhost:{port}/api/dosage_forms/create", new_dose);
            var response = await result.Content.ReadFromJsonAsync<TypeDoseDTO>();
            return response!;
        }

        public async Task<TypeDoseDTO> EditTypeDose(int id, TypeDoseDTO dose)
        {
            var result = await _http.PatchAsJsonAsync($"http://localhost:{port}/api/dosage_forms/{id}", dose);
            var response = await result.Content.ReadFromJsonAsync<TypeDoseDTO>();
            return response!;
        }

        public async Task<bool> DeleteTypeDose(int id)
        {
            var url = $"http://localhost:{port}/api/dosage_forms/{id}";
            var response = await _http.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}
