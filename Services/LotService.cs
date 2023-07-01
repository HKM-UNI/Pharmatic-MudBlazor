using Pharmatic.DTOs;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Pharmatic.Services
{
    public class LotService
    {
        private readonly HttpClient _http;
        public LotService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<LotDTO>> LotList(string? productNo)
        {
            var url = "http://localhost:7035/api/lots?product_no=" + productNo;
            var result = await _http.GetFromJsonAsync<List<LotDTO>>(url);

            return result!;
        }

        public async Task<List<LotDTO>> LotList()
        {
            var url = "http://localhost:7035/api/lots";
            var result = await _http.GetFromJsonAsync<List<LotDTO>>(url);

            return result!;
        }

        public async Task<LotDTO> SearchLot(string lotNo)
        {
            var url = "http://localhost:7035/api/lots/" + lotNo;
            var result = await _http.GetFromJsonAsync<LotDTO>(url);

            return result!;
        }
    }
}
