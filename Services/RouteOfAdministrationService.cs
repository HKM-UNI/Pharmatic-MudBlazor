using Pharmatic.DTOs;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class RouteOfAdministrationService
    {
        private readonly HttpClient _http;
        public RouteOfAdministrationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<RouteOfAdmDTO>> RoutesOfAdmList()
        {
            var url = "https://localhost:7036/api/AdministrationRoute";
            var result = await _http.GetFromJsonAsync<List<RouteOfAdmDTO>>(url);
            return result!;
        }
    }
}
