using AdBoard.Contracts.Models.Entities.User.Requests;

namespace AdBoard.AppServices.Contexts.User.Services;

public interface IAccountService
{
    Task<string> RegisterAsync(UserRegisterRequest request, CancellationToken cancellationToken);
    Task<string> LoginAsync(UserLoginRequest request);
}
