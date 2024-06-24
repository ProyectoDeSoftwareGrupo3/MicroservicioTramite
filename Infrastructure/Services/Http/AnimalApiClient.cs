using Domain.Models;
using System.Text.Json;

namespace Infrastructure.Services.Http;

public class AnimalApiClient(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<GetAnimalResponse> GetAnimalByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/Animal/{id}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<GetAnimalResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return result;
    }   
}
