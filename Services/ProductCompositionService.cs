using Pharmatic.DTOs;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class ProductCompositionService
    {
        private readonly HttpClient _http;
        public ProductCompositionService(HttpClient http)
        {
            _http = http;
        }
    }
}
