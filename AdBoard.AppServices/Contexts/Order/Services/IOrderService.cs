using AdBoard.Contracts.Models.Entities.Order.Requests;
using AdBoard.Contracts.Models.Entities.Order.Responses;
using AdBoard.Contracts.Models.Entities.User;

namespace AdBoard.AppServices.Contexts.Order.Services;

/// <summary>
/// Интерфейс для сервиса заказов. Предоставляет методы для управления заказами.
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Добавляет новый заказ.
    /// </summary>
    /// <param name="request">Запрос на создание заказа.</param>
    /// <param name="userContext">Контекст пользователя.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    Task AddAsync(OrderCreateRequest request, UserContextLight userContext, CancellationToken cancellationToken);

    /// <summary>
    /// Покупает товары из списка заказов.
    /// </summary>
    /// <param name="orderIds">Список идентификаторов заказов.</param>
    /// <param name="userContextLight">Контекст пользователя.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Список недействительных элементов заказа.</returns>
    Task<List<OrderInvalidItemResponse>> BuyAsync(List<long> orderIds, UserContextLight userContextLight, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет количество товара в заказе.
    /// </summary>
    /// <param name="id">Идентификатор заказа.</param>
    /// <param name="count">Новое количество.</param>
    /// <param name="userContextLight">Контекст пользователя.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    Task UpdateCountAsync(long id, double count, UserContextLight userContextLight, CancellationToken cancellationToken);
}
