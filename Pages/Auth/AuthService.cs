using System.Net.Http.Json;

namespace Pharmatic.Pages.Auth
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            var url = "http://127.0.0.1:7035/api/users/login";

            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, loginRequest);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<LoginResponse>();
                }
                else
                {
                    // Maneja el caso de error de autenticación aquí si es necesario.
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Maneja las excepciones aquí si es necesario.
                return null;
            }
        }
    }
}
