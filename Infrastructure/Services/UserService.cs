using Application.Interfaces.Services;
using Domain.Models;
using Infrastructure.Services.Http;

namespace Infrastructure.Services;

public class UserService(UserApiClient userApiClient) : IUserService
{
    private readonly UserApiClient _userApiClient = userApiClient;

    public async Task<GetUserResponse> GetUserByIdAsync(Guid id)
    {
        return await _userApiClient.GetUserByIdAsync(id);
    }
}
