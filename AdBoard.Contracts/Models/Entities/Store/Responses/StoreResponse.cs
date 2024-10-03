using AdBoard.Contracts.Enums;

namespace AdBoard.Contracts.Models.Entities.Store.Responses;

/// <summary>
/// DTO для представления информации о магазине.
/// Используется для отображения основных данных о магазине в различных частях приложения.
/// </summary>
public class StoreResponse
{
    /// <summary>
    /// Идентификатор магазина
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// Название магазина.
    /// Если флаг IsDefault в состоянии true, то ФИО пользователя станет названием магазина.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Идентификатор продавца.
    /// </summary>
    public required string SellerId { get; set; }

    /// <summary>
    /// Описание магазина.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Статус магазина.
    /// </summary>
    public required StoreStatus Status { get; set; }

    /// <summary>
    /// По умолчанию при регистрации пользователя для него создаётся магазин с флагом IsDefault в состоянии true.
    /// Таким образом пользователь сможет продавать товар от своего имени
    /// У одного пользователя только один дефолтный магазин
    /// </summary>
    public bool IsDefault { get; set; }
}
