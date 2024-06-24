using System.Text.Json;
using Domain.Models;

namespace Infrastructure.Services.Http;

public class UserApiClient(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

        public async Task<GetUserResponse> GetUserByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/User/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<GetUserResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result;
        }
}
