using Pharmatic.DTOs;
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
            var result = await _http.GetFromJsonAsync<List<TagDTO>>("http://localhost:7035/api/tags");
            return result!;
        }

        public async Task<TagDTO> CreateTag(TagDTO new_tag)
        {
            var result = await _http.PostAsJsonAsync("http://localhost:7035/api/tags/create", new_tag);
            var response = await result.Content.ReadFromJsonAsync<TagDTO>();
            return response!;
        }

        public async Task<TagDTO> EditTag(int id, TagDTO tag)
        {
            var result = await _http.PatchAsJsonAsync($"http://localhost:7035/api/tags/{id}", tag);
            var response = await result.Content.ReadFromJsonAsync<TagDTO>();
            return response!;
        }

        public async Task<bool> DeleteTag(int id)
        {
            var url = $"http://localhost:7035/api/tags/{id}";
            var response = await _http.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}
