using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;
using Pharmatic.DTOs;

namespace Pharmatic.Services;

public class UserService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;

    public UserService(HttpClient http, ILocalStorageService localStorage)
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

    public async Task<List<UserDTO>> UserList()
    {
        await SetTokenAsync();
        var result = await _http.GetFromJsonAsync<List<UserDTO>>("users");
        return result!;
    }

    public async Task<UserDTO> CurrentUser()
    {
        await SetTokenAsync();
        var result = await _http.GetFromJsonAsync<UserDTO>("users/me");
        return result!;
    }

    public async Task<UserDTO> GetUser(string id)
    {
        await SetTokenAsync();
        var result = await _http.GetFromJsonAsync<UserDTO>($"users/{id}");
        return result!;
    }

    public async Task<UserDTO> CreateUser(UserDTO newUser)
    {
        await SetTokenAsync();

        var result = await _http.PostAsJsonAsync("users/create", newUser);
        var response = await result.Content.ReadFromJsonAsync<UserDTO>();
        return response!;
    }

    public async Task<UserDTO> EditUser(string username, UserDTO user)
    {
        await SetTokenAsync();

        var result = await _http.PatchAsJsonAsync($"users/{username}", user);
        var response = await result.Content.ReadFromJsonAsync<UserDTO>();
        return response!;
    }

    public async Task<bool> NewPassword(string username, string password)
    {
        await SetTokenAsync();
        var passwordData = new Dictionary<string, string>
        {
            { "newPassword", password }
        };

        var json = new StringContent(JsonSerializer.Serialize(passwordData), Encoding.UTF8, "application/json");

        var result = await _http.PutAsync($"users/{username}/update_password", json);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> SetUserPermissions(string username, List<ScopeDTO> scopes)
    {
        await SetTokenAsync();
        var result = await _http.PatchAsJsonAsync($"users/{username}/permissions", scopes);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> AddPhoto(string username, string fileName, string fileType, string base64Image)
    {
        await SetTokenAsync();
        var imageBytes = Convert.FromBase64String(base64Image);

        using (var content = new MultipartFormDataContent())
        {
            var fileContent = new ByteArrayContent(imageBytes);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(fileType);

            content.Add(fileContent, "image", fileName);

            var result = await _http.PutAsync($"users/{username}/image", content);

            return result.IsSuccessStatusCode;
        }
    }

    public async Task<bool> DeleteUser(string username)
    {
        await SetTokenAsync();
        var response = await _http.DeleteAsync($"users/{username}");
        return response.IsSuccessStatusCode;
    }

    public async Task<List<RoleDTO>> RoleList()
    {
        await SetTokenAsync();
        var result = await _http.GetFromJsonAsync<List<RoleDTO>>("users/roles");
        return result!;
    }
}