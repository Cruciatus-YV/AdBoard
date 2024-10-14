using AdBoard.Contracts.Models.Entities.User;
using AdBoard.Contracts.Models.Entities.User.Requests;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.User.Services;

public interface IUserService
{
    Task<UserEntity> CreateUserAsync(UserRegisterRequest request, CancellationToken cancellationToken);

    Task<UserEntity?> GetUserByIdAsync(string userId);

    Task<bool> UpdateAsync(UserUpdateRequest request, UserContextLight userContext, CancellationToken cancellationToken);
}
