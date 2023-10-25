using Pharmatic.DTOs;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class RouteOfAdministrationService : Global
    {
        private readonly HttpClient _http;
        public RouteOfAdministrationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<RouteOfAdmDTO>> RoutesOfAdmList()
        {
            var url = $"http://localhost:{port}/api/admin_routes";
            var result = await _http.GetFromJsonAsync<List<RouteOfAdmDTO>>(url);
            return result!;
        }

        public async Task<RouteOfAdmDTO> CreateRoa(RouteOfAdmDTO new_roa)
        {
            var result = await _http.PostAsJsonAsync($"http://localhost:{port}/api/admin_routes/create", new_roa);
            var response = await result.Content.ReadFromJsonAsync<RouteOfAdmDTO>();
            return response!;
        }

        public async Task<RouteOfAdmDTO> EditRoa(int id, RouteOfAdmDTO roa)
        {
            var result = await _http.PatchAsJsonAsync($"http://localhost:{port}/api/admin_routes/{id}", roa);
            var response = await result.Content.ReadFromJsonAsync<RouteOfAdmDTO>();
            return response!;
        }

        public async Task<bool> DeleteRoa(int id)
        {
            var url = $"http://localhost:{port}/api/admin_routes/{id}";
            var response = await _http.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}
