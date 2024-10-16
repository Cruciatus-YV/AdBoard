using AdBoard.Contracts.Models.Entities.Store.Requests;
using AdBoard.Contracts.Models.Entities.Store.Responses;
using AdBoard.Contracts.Models.Entities.User;

namespace AdBoard.AppServices.Contexts.Store.Services;

/// <summary>
/// Интерфейс для сервиса работы с магазинами. Предоставляет методы для управления магазинами.
/// </summary>
public interface IStoreService
{
    /// <summary>
    /// Создает новый магазин.
    /// </summary>
    /// <param name="request">Запрос на создание магазина.</param>
    /// <param name="userContextLightDto">Контекст пользователя.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Идентификатор созданного магазина.</returns>
    Task<long> CreateAsync(StoreRequestCreate request, UserContextLight userContextLightDto, CancellationToken cancellationToken);

    /// <summary>
    /// Получает информацию о магазине по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор магазина.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Информация о магазине.</returns>
    Task<StoreResponse?> GetAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет информацию о магазине.
    /// </summary>
    /// <param name="request">Запрос на обновление магазина.</param>
    /// <param name="userContextLightDto">Контекст пользователя.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    Task UpdateAsync(StoreRequestUpdate request, UserContextLight userContextLightDto, CancellationToken cancellationToken);
}
