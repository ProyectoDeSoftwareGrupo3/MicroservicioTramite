using Domain.Models;

namespace Application.Interfaces.Services;

public interface IUserService
{
    Task<GetUserResponse> GetUserByIdAsync(Guid id);
}
