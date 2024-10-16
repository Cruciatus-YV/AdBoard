using AdBoard.Contracts.Models.Entities.User;
using AdBoard.Contracts.Models.Entities.User.Requests;
using AdBoard.Contracts.Models.Entities.User.Responses;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.User.Services;

/// <summary>
/// Интерфейс, определяющий операции, связанные с управлением пользователями.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Создаёт нового пользователя на основе предоставленных данных регистрации.
    /// </summary>
    /// <param name="request">Запрос на регистрацию пользователя.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Созданный объект пользователя после успешной регистрации.</returns>
    Task<UserEntity> CreateUserAsync(UserRegisterRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Получает пользователя по его идентификатору.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя, которого нужно получить.</param>
    /// <returns>Информация о пользователе в виде лёгкого объекта ответа или null, если пользователь не найден.</returns>
    Task<UserLigthResponse?> GetUserByIdAsync(string userId);

    /// <summary>
    /// Получает пользователя по его адресу электронной почты.
    /// </summary>
    /// <param name="email">Адрес электронной почты пользователя.</param>
    /// <returns>Объект пользователя, если найден, иначе null.</returns>
    Task<UserEntity?> GetUserByEmailAsync(string email);

    /// <summary>
    /// Обновляет информацию о пользователе.
    /// </summary>
    /// <param name="request">Данные запроса на обновление пользователя.</param>
    /// <param name="userContext">Контекст с лёгкой информацией о пользователе, выполняющем обновление.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>True, если обновление прошло успешно, иначе false.</returns>
    Task<bool> UpdateAsync(UserUpdateRequest request, UserContextLight userContext, CancellationToken cancellationToken);
}

