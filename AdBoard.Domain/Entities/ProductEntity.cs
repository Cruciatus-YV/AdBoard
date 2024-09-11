using AdBoard.Contracts.Enums;
using AdBoard.Domain.Base;

namespace AdBoard.Domain.Entities;

/// <summary>
/// Сущность единицы товара из определённого магазина
/// </summary>
public class ProductEntity : MutableEntity<long>
{
    /// <summary>
    /// Наименование товара
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Название магазина
    /// </summary>
    public required long StoreId { get; set; }

    /// <summary>
    /// Название категории товара
    /// </summary>
    public required long CategoryId { get; set; }

    /// <summary>
    /// Описание товара
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Цена товара
    /// </summary>
    public required decimal Price { get; set; }

    /// <summary>
    /// Количество товара на складе
    /// </summary>
    public required uint Count { get; set; }

    /// <summary>
    /// Статус товара
    /// </summary>
    public ProductStatus Status { get; set; }


    /// <summary>
    /// Магазин, которому принадлежит товар
    /// </summary>
    public virtual StoreEntity Store { get; set; }
}
