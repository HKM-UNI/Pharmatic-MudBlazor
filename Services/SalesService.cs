using Pharmatic.DTOs;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class SalesService : Global
    {
        private readonly HttpClient _http;
        public SalesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<SalesInvoiceDTO>> SalesList()
        {
            var url = $"http://localhost:{port}/api/sales";
            var result = await _http.GetFromJsonAsync<List<SalesInvoiceDTO>>(url);

            return result!;
        }

        public async Task<SalesInvoiceDTO> CreateInvoice(SalesInvoiceDTO new_invoice)
        {
            var result = await _http.PostAsJsonAsync($"http://localhost:{port}/api/sales/create", new_invoice);
            var response = await result.Content.ReadFromJsonAsync<SalesInvoiceDTO>();
            return response!;
        }

        public async Task<SalesInvoiceDTO> EditInvoice(int id, SalesInvoiceDTO invoice)
        {
            var result = await _http.PatchAsJsonAsync($"http://localhost:{port}/api/sales/{id}", invoice);
            var response = await result.Content.ReadFromJsonAsync<SalesInvoiceDTO>();
            return response!;
        }
    }
}
