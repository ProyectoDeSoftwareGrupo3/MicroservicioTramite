using Domain.Models;

namespace Application.Interfaces.Services;

public interface IAnimalService
{
    Task<GetAnimalResponse> GetAnimalByIdAsync(int id);
}
