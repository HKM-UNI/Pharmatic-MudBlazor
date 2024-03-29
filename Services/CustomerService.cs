﻿using Pharmatic.DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace Pharmatic.Services
{
    public class CustomerService : Global
    {
        private readonly HttpClient _http;
        public CustomerService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CustomerDTO>> CustomerList()
        {
            var url = $"http://localhost:{port}/api/customers";
            var result = await _http.GetFromJsonAsync<List<CustomerDTO>>(url);
            return result!;
        }

        public async Task<int> CustomersCount()
        {
            var url = $"http://localhost:{port}/api/customers";
            var result = await _http.GetFromJsonAsync<List<CustomerDTO>>(url);
            return result?.Count ?? 0;
        }

        public async Task<CustomerDTO> SearchCustomer(string id)
        {
            var url = $"http://localhost:{port}/api/customers/" + id;
            var result = await _http.GetFromJsonAsync<CustomerDTO>(url);
            return result!;
        }

        public async Task<CustomerDTO> CreateCustomer(CustomerDTO new_customer)
        {
            var result = await _http.PostAsJsonAsync($"http://localhost:{port}/api/customers/create", new_customer);
            var response = await result.Content.ReadFromJsonAsync<CustomerDTO>();
            return response!;
        }

        public async Task<CustomerDTO> EditCustomer(int id, CustomerDTO customer)
        {
            var result = await _http.PatchAsJsonAsync($"http://localhost:{port}/api/customers/{id}", customer);
            var response = await result.Content.ReadFromJsonAsync<CustomerDTO>();
            return response!;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var url = $"http://localhost:{port}/api/customers/{id}";
            var response = await _http.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }

    }
}
