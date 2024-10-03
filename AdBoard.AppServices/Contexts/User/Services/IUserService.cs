using AdBoard.Contracts.Models.Entities.User;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.User.Services;

public interface IUserService
{
    Task<UserEntity?> CreateUserAsync(UserRegisterRequest request);
    Task<UserEntity?> GetUserByIdAsync(string userId);
}
