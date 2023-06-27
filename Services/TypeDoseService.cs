using Pharmatic.DTOs;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class TypeDoseService
    {
        private readonly HttpClient _http;
        public TypeDoseService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TypeDoseDTO>> TypeDoseList()
        {
            var url = "http://localhost:7035/api/dosage_forms";
            var result = await _http.GetFromJsonAsync<List<TypeDoseDTO>>(url);
            return result!;
        }
    }
}
