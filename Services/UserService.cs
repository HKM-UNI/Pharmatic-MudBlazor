using Blazored.LocalStorage;
using Pharmatic.DTOs;
using Pharmatic.Pages;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pharmatic.Services
{
    public class UserService : Global
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
            string token = await _localStorage.GetItemAsStringAsync("token");
            if (token != null)
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim('"'));
        }

        public async Task<List<UserDTO>> UserList()
        {
            var url = $"http://localhost:{port}/api/users";
            await SetTokenAsync();
            var result = await _http.GetFromJsonAsync<List<UserDTO>>(url);
            return result!;
        }

        public async Task<UserDTO> CurrentUser()
        {
            var url = $"http://localhost:{port}/api/users/me";
            await SetTokenAsync();
            var result = await _http.GetFromJsonAsync<UserDTO>(url);
            return result!;
        }

        public async Task<UserDTO> GetUser(string id)
        {
            var url = $"http://localhost:{port}/api/users/" + id;
            await SetTokenAsync();
            var result = await _http.GetFromJsonAsync<UserDTO>(url);
            return result!;
        }

        public async Task<UserDTO> CreateUser(UserDTO new_user)
        {
            await SetTokenAsync();

            var result = await _http.PostAsJsonAsync($"http://localhost:{port}/api/users/create", new_user);
            var response = await result.Content.ReadFromJsonAsync<UserDTO>();
            return response!;
        }

        public async Task<UserDTO> EditUser(string username, UserDTO user)
        {
            await SetTokenAsync();

            var result = await _http.PatchAsJsonAsync($"http://localhost:{port}/api/users/{username}", user);
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

            var result = await _http.PutAsync($"http://localhost:{port}/api/users/{username}/update_password", json);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> SetUserPermissions(string username, List<ScopeDTO> scopes)
        {
            await SetTokenAsync();
            var result = await _http.PatchAsJsonAsync($"http://localhost:{port}/api/users/{username}/permissions", scopes);
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

                var result = await _http.PutAsync($"http://localhost:{port}/api/users/{username}/image", content);

                return result.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteUser(string username)
        {
            await SetTokenAsync();
            var url = $"http://localhost:{port}/api/users/{username}";
            var response = await _http.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<RoleDTO>> RoleList()
        {
            var url = $"http://localhost:{port}/api/users/roles";
            await SetTokenAsync();
            var result = await _http.GetFromJsonAsync<List<RoleDTO>>(url);
            return result!;
        }
    }
}
