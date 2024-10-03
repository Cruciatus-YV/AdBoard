using AdBoard.Contracts.Enums;
using AdBoard.Domain.Base;

namespace AdBoard.Domain.Entities;

/// <summary>
/// Сущность единицы товара из определённого магазина.
/// </summary>
public class ProductEntity : MutableEntity<long>, IHaveCategoryId, 
                                                  IHaveDescription, 
                                                  IHaveName, 
                                                  IHaveStoreId,
                                                  IHaveCount, 
                                                  IHaveStatus,
                                                  IHaveMeasurementUnit,
                                                  IHavePrice
{
    /// <summary>
    /// Наименование товара.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Идентификатор магазина.
    /// </summary>
    public long StoreId { get; set; }

    /// <summary>
    /// Идентификатор категории товара.
    /// </summary>
    public required long CategoryId { get; set; }

    /// <summary>
    /// Описание товара.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Цена товара.
    /// </summary>
    public required decimal Price { get; set; }

    /// <summary>
    /// Количество товара в наличии.
    /// </summary>
    public required double Count { get; set; }

    /// <summary>
    /// Единица измерения количества товара.
    /// </summary>
    public required MeasurementUnit MeasurementUnit { get; set; }

    /// <summary>
    /// Статус товара.
    /// </summary>
    public ProductStatus Status { get; set; }

    /// <summary>
    /// Категория товара.
    /// </summary>
    public virtual CategoryEntity Category { get; set; }

    /// <summary>
    /// Магазин, которому принадлежит товар.
    /// </summary>
    public virtual StoreEntity Store { get; set; }

    public virtual List<FeedbackEntity> Feedback {  get; set; }
}
