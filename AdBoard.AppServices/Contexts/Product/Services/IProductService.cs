using AdBoard.Contracts.Models.Entities.Product;
using AdBoard.Contracts.Models.Entities.Product.Requests;
using AdBoard.Contracts.Models.Entities.Product.Responses;
using AdBoard.Contracts.Models.Entities.User;

namespace AdBoard.AppServices.Contexts.Product.Services;

/// <summary>
/// Интерфейс для сервиса работы с продуктами. Предоставляет методы для управления продуктами.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Получает список продуктов по фильтру.
    /// </summary>
    /// <param name="request">Запрос на поиск продуктов.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Список продуктов.</returns>
    Task<List<ProductPageItemDto>> GetByFilterAsync(ProductRequestSearch request, CancellationToken cancellationToken);

    /// <summary>
    /// Получает полную информацию о продукте по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор продукта.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Полная информация о продукте.</returns>
    Task<ProductResponse?> GetFullInfoAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Создает новый продукт.
    /// </summary>
    /// <param name="request">Запрос на создание продукта.</param>
    /// <param name="userContext">Контекст пользователя.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Идентификатор созданного продукта.</returns>
    Task<long> CreateAsync(ProductRequestCreate request, UserContextLight userContext, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет информацию о продукте.
    /// </summary>
    /// <param name="request">Запрос на обновление продукта.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>True, если продукт был успешно обновлен; в противном случае False.</returns>
    Task<bool> UpdateAsync(ProductRequestUpdate request, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет товар по его идентификатору (флаг IsDeleted = true).
    /// </summary>
    /// <param name="id">Идентификатор продукта.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>True, если продукт был успешно удален; в противном случае False.</returns>
    Task<bool> DeleteAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет количество продуктов.
    /// </summary>
    /// <param name="request">Запрос на обновление количества продуктов.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Кортеж, содержащий статус операции и коллекцию идентификаторов недоступных продуктов.</returns>
    Task<(bool, IReadOnlyCollection<long>?)> UpdateCountAsync(IReadOnlyCollection<ProductRequestBuyable> request, CancellationToken cancellationToken);
}
