using AdBoard.Contracts.Models.Entities.User;

namespace AdBoard.AppServices.Contexts.User.Services;

public interface IAccountService
{
    Task<string> RegisterAsync(UserRegisterRequest request); // Регистрация пользователя
    Task<string> LoginAsync(UserLoginRequest request); // Аутентификация пользователя
}
