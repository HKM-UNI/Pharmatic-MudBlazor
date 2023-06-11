﻿using Pharmatic.DTOs;
using System.Net.Http.Json;

namespace Pharmatic.Services
{
    public class TagService
    {
        private readonly HttpClient _http;
        public TagService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TagDTO>> TagList()
        {
            var result = await _http.GetFromJsonAsync<List<TagDTO>>("https://localhost:7036/api/Tag");
            return result!;
        }
    }
}
