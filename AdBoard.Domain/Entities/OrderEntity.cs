using AdBoard.Contracts.Enums;
using AdBoard.Domain.Base;

namespace AdBoard.Domain.Entities;

/// <summary>
/// Сущность заказа в определённом магазине.
/// </summary>
public class OrderEntity : MutableEntity<long>
{
    /// <summary>
    /// Идентификатор покупателя.
    /// </summary>
    public required string ConsumerId { get; set; }

    /// <summary>
    /// Идентификатор магазина.
    /// </summary>
    public required long StoreId { get; set; }

    /// <summary>
    /// Статус заказа.
    /// </summary>
    public OrderStatus Status { get; set; }

    /// <summary>
    /// Покупатель.
    /// </summary>
    public virtual UserEntity Consumer { get; set; }

    /// <summary>
    /// Магазин.
    /// </summary>
    public virtual StoreEntity Store { get; set; }

    /// <summary>
    /// Позиции в заказе.
    /// </summary>
    public virtual List<OrderItemEntity> OrderItems { get; set; } = [];
}
