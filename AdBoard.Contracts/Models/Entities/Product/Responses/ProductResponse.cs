using AdBoard.Contracts.Enums;
using AdBoard.Contracts.Models.Entities.Store.Responses;

namespace AdBoard.Contracts.Models.Entities.Product.Responses;


/// <summary>
/// DTO для представления информации о товаре.
/// Используется для отображения основных данных о товаре в различных частях приложения.
/// </summary>
public class ProductResponse
{
    /// <summary>
    /// Идентификатор товара.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Название товара.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Описание товара.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Цена товара.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Количество товара на складе.
    /// </summary>
    public double Count { get; set; }

    /// <summary>
    /// Единица измерения количества товара.
    /// </summary>
    public MeasurementUnit MeasurementUnit { get; set; }

    /// <summary>
    /// Статус товара, указывающий его доступность.
    /// </summary>
    public ProductStatus Status { get; set; }

    public StoreResponse Store { get; set; }

    public List<long> Images { get; set; }
}