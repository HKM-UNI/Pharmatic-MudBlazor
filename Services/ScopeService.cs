using Blazored.LocalStorage;
using Pharmatic.DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class ScopeService : Global
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        public ScopeService(HttpClient http, ILocalStorageService localStorage)
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

        public async Task<List<PermissionCategoryDTO>> GetPermissionCategories()
        {
            var url = $"http://localhost:{port}/api/users/permission_categories";
            await SetTokenAsync();
            var result = await _http.GetFromJsonAsync<List<PermissionCategoryDTO>>(url);
            return result!;
        }

        public async Task<List<ScopeDTO>> GetScopes()
        {
            var url = $"http://localhost:{port}/api/users/permissions";
            await SetTokenAsync();
            var result = await _http.GetFromJsonAsync<List<ScopeDTO>>(url);
            return result!;
        }

        public async Task<List<ScopeDTO>> GetUserScopes(string username)
        {
            var url = $"http://localhost:{port}/api/users/permissions?username={username}";
            await SetTokenAsync();
            var result = await _http.GetFromJsonAsync<List<ScopeDTO>>(url);
            return result!;
        }

        public async Task<List<ScopeDTO>> GetRoleScopes(string role)
        {
            var url = $"http://localhost:{port}/api/users/permissions?role_name={role}";
            await SetTokenAsync();
            var result = await _http.GetFromJsonAsync<List<ScopeDTO>>(url);
            return result!;
        }

        public async Task<List<ScopeDTO>> GetUserPermissions(string username)
        {
            var url = $"http://localhost:{port}/api/users/permissions?username={username}";
            await SetTokenAsync();
            var result = await _http.GetFromJsonAsync<List<ScopeDTO>>(url);
            return result!;
        }

        public async Task<bool> SetUserScopes(string username, List<ScopeDTO> scopes)
        {
            await SetTokenAsync();

            var result = await _http.PatchAsJsonAsync($"http://localhost:{port}/api/users/{username}/permissions", scopes);
            return result.IsSuccessStatusCode;
        }
    }
}
