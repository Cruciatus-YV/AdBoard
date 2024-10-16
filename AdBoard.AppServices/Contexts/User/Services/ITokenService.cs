using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.User.Services;

/// <summary>
/// Интерфейс для сервиса работы с токенами. Предоставляет методы для генерации токенов.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Генерирует JWT-токен для пользователя.
    /// </summary>
    /// <param name="user">Пользователь, для которого будет сгенерирован токен.</param>
    /// <returns>JWT-токен в виде строки.</returns>
    Task<string> GenerateJwtToken(UserEntity user);
}
