using Pharmatic.DTOs;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class CustomerService
    {
        private readonly HttpClient _http;
        public CustomerService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CustomerDTO>> CustomerList()
        {
            var url = "https://localhost:7036/api/Customer";
            var result = await _http.GetFromJsonAsync<List<CustomerDTO>>(url);
            return result!;
        }
    }
}
