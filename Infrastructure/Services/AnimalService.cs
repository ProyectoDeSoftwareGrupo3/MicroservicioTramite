using Application.Interfaces.Services;
using Domain.Models;
using Infrastructure.Services.Http;

namespace Infrastructure.Services;

public class AnimalService(AnimalApiClient animalApiClient) : IAnimalService
{
    private readonly AnimalApiClient _animalApiClient = animalApiClient;

    public async Task<GetAnimalResponse> GetAnimalByIdAsync(int id)
    {
        return await _animalApiClient.GetAnimalByIdAsync(id);
    }
}