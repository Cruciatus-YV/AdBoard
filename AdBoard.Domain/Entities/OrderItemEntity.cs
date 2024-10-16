using AdBoard.Contracts.Enums;
using AdBoard.Domain.Base;

namespace AdBoard.Domain.Entities;

/// <summary>
/// Сущность единицы товара из заказа.
/// </summary>
public class OrderItemEntity : MutableEntity<long>
{
    /// <summary>
    /// Идентификатор товара.
    /// </summary>
    public required long ProductId { get; set; }

    /// <summary>
    /// Идентификатор заказа.
    /// </summary>
    public required long OrderId { get; set; }

    /// <summary>
    /// Цена на момент покупки.
    /// </summary>
    public decimal? OrderPrice { get; set; }

    /// <summary>
    /// Количество товара в заказе.
    /// </summary>
    public required double Count { get; set; }

    /// <summary>
    /// Единица измерения количества товара.
    /// </summary>
    public required MeasurementUnit MeasurementUnit { get; set; }

    /// <summary>
    /// Форс-мажорные обстоятельства с товаром.
    /// </summary>
    public OrderItemStatus? Status { get; set; }

    /// <summary>
    /// Флаг удаления из заказа.
    /// </summary>
    public required bool IsDeleted { get; set; }

    /// <summary>
    /// Заказ.
    /// </summary>
    public virtual OrderEntity Order { get; set; }

    /// <summary>
    /// Товар.
    /// </summary>
    public virtual ProductEntity Product { get; set; }
}
