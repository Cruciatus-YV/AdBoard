using AdBoard.Contracts.Enums;

namespace AdBoard.Contracts.Models.Entities.OrderItem;

public class OrderItemEntityDto
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
}
