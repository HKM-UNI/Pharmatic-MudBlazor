using Pharmatic.DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace Pharmatic.Services
{
    public class MeasureService : Global
    {
        private readonly HttpClient _http;
        public MeasureService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<MeasureDTO>> MeasureList()
        {
            var url = $"http://localhost:{port}/api/measures";
            var result = await _http.GetFromJsonAsync<List<MeasureDTO>>(url);
            return result!;
        }

        public async Task<MeasureDTO> CreateMeasure(MeasureDTO new_measure)
        {
            var result = await _http.PostAsJsonAsync($"http://localhost:{port}/api/measures/create", new_measure);
            var response = await result.Content.ReadFromJsonAsync<MeasureDTO>();
            return response!;
        }

        public async Task<MeasureDTO> EditMeasure(int id, MeasureDTO measure)
        {
            var result = await _http.PatchAsJsonAsync($"http://localhost:{port}/api/measures/{id}", measure);
            var response = await result.Content.ReadFromJsonAsync<MeasureDTO>();
            return response!;
        }

        public async Task<bool> DeleteMeasure(int id)
        {
            var url = $"http://localhost:{port}/api/measures/{id}";
            var response = await _http.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}
