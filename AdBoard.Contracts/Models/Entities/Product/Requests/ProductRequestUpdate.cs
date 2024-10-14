using AdBoard.Contracts.Enums;
using Microsoft.AspNetCore.Http;

namespace AdBoard.Contracts.Models.Entities.Product.Requests;

/// <summary>
/// DTO для представления обновлённой информации о товаре.
/// </summary>
public class ProductRequestUpdate
{
    /// <summary>
    /// Идентификатор товара.
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// Наименование товара.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Идентификатор категории товара.
    /// </summary>
    public long CategoryId { get; set; }

    /// <summary>
    /// Описание товара.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Цена товара.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Количество товара в наличии.
    /// </summary>
    public double Count { get; set; }

    /// <summary>
    /// Единица измерения количества товара.
    /// </summary>
    public MeasurementUnit MeasurementUnit { get; set; }

    /// <summary>
    /// Статус товара.
    /// </summary>
    public ProductStatus Status { get; set; }

    public IFormFileCollection Images { get; set; }
}
