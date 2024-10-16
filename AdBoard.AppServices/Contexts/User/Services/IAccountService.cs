using AdBoard.Contracts.Models.Entities.User.Requests;

namespace AdBoard.AppServices.Contexts.User.Services;

/// <summary>
/// Интерфейс для сервиса аккаунтов. Предоставляет методы для регистрации и входа пользователей.
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Регистрирует нового пользователя.
    /// </summary>
    /// <param name="request">Запрос на регистрацию пользователя.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Идентификатор зарегистрированного пользователя.</returns>
    Task<string> RegisterAsync(UserRegisterRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Выполняет вход пользователя.
    /// </summary>
    /// <param name="request">Запрос на вход пользователя.</param>
    /// <returns>Идентификатор пользователя, если вход успешен.</returns>
    Task<string> LoginAsync(UserLoginRequest request);
}
