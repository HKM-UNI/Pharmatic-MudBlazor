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
            var url = "http://localhost:7035/api/customers";
            var result = await _http.GetFromJsonAsync<List<CustomerDTO>>(url);
            return result!;
        }

        public async Task<CustomerDTO> SearchCustomer(string id)
        {
            var url = "http://localhost:7035/api/customers/" + id;
            var result = await _http.GetFromJsonAsync<CustomerDTO>(url);
            return result!;
        }
    }
}
