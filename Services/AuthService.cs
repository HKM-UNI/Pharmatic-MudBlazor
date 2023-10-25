using Pharmatic.Authorization;
using Pharmatic.Services;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class AuthService : Global
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> LoginAsync(LoginRequest loginRequest)
    {
        var url = $"http://127.0.0.1:{port}/api/users/login";

        try
        {
            var response = await _httpClient.PostAsJsonAsync(url, loginRequest);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AuthResult>();
                if (result != null && !string.IsNullOrEmpty(result.Token))
                {
                    Console.WriteLine(result.Token);
                    return result.Token;
                }
            }

            // Maneja el caso de error de autenticación aquí si es necesario.
            return null;
        }
        catch (Exception ex)
        {
            // Maneja las excepciones aquí si es necesario.
            return null;
        }
    }
}
