using System.Net.Http.Headers;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using Pharmatic.DTOs;

namespace Pharmatic.Services;

public class ScopeService
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
        var token = await _localStorage.GetItemAsStringAsync("token");
        if (token != null)
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim('"'));
    }

    public async Task<List<PermissionCategoryDTO>> GetPermissionCategories()
    {
        await SetTokenAsync();
        var result = await _http.GetFromJsonAsync<List<PermissionCategoryDTO>>("users/permission_categories");
        return result!;
    }

    public async Task<List<ScopeDTO>> GetScopes()
    {
        await SetTokenAsync();
        var result = await _http.GetFromJsonAsync<List<ScopeDTO>>("users/permissions");
        return result!;
    }

    public async Task<List<ScopeDTO>> GetUserScopes(string username)
    {
        await SetTokenAsync();
        var url = $"users/permissions?username={username}";
        var result = await _http.GetFromJsonAsync<List<ScopeDTO>>(url);
        return result!;
    }

    public async Task<List<ScopeDTO>> GetRoleScopes(string role)
    {
        var url = $"users/permissions?role_name={role}";
        await SetTokenAsync();
        var result = await _http.GetFromJsonAsync<List<ScopeDTO>>(url);
        return result!;
    }

    public async Task<bool> SetUserScopes(string username, List<ScopeDTO> scopes)
    {
        await SetTokenAsync();
        var url = $"users/{username}/permissions";
        var result = await _http.PatchAsJsonAsync(url, scopes);
        return result.IsSuccessStatusCode;
    }
}