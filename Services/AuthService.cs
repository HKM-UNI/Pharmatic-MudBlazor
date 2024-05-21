using System.Net.Http.Json;
using Pharmatic.Authorization;

namespace Pharmatic.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string?> LoginAsync(LoginRequest loginRequest)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("users/login", loginRequest);

            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadFromJsonAsync<AuthResult>();
            if (result != null && !string.IsNullOrEmpty(result.Token))
            {
                return result.Token;
            }

            return null;
        }
        catch (Exception)
        {
            return null;
        }
    }
}