using System.Net.Http.Json;
using Pharmatic.DTOs;

namespace Pharmatic.Services;

public class CustomerService
{
    private readonly HttpClient _http;

    public CustomerService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<CustomerDTO>> CustomerList()
    {
        var result = await _http.GetFromJsonAsync<List<CustomerDTO>>("customers");
        return result!;
    }

    public async Task<CustomerDTO> SearchCustomer(string id)
    {
        var result = await _http.GetFromJsonAsync<CustomerDTO>($"customers/{id}");
        return result!;
    }

    public async Task<CustomerDTO> CreateCustomer(CustomerDTO newCustomer)
    {
        var result = await _http.PostAsJsonAsync("customers/create", newCustomer);
        var response = await result.Content.ReadFromJsonAsync<CustomerDTO>();
        return response!;
    }

    public async Task<CustomerDTO> EditCustomer(int id, CustomerDTO customer)
    {
        var result = await _http.PatchAsJsonAsync($"customers/{id}", customer);
        var response = await result.Content.ReadFromJsonAsync<CustomerDTO>();
        return response!;
    }

    public async Task<bool> DeleteCustomer(int id)
    {
        var response = await _http.DeleteAsync($"customers/{id}");
        return response.IsSuccessStatusCode;
    }
}