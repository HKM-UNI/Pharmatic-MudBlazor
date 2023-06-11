using Pharmatic.DTOs;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class MeasureService
    {
        private readonly HttpClient _http;
        public MeasureService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<MeasureDTO>> MeasureList()
        {
            var url = "https://localhost:7036/api/Measure";
            var result = await _http.GetFromJsonAsync<List<MeasureDTO>>(url);
            return result!;
        }
    }
}
