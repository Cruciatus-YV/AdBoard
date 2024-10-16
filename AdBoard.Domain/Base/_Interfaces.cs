using AdBoard.Contracts.Enums;

namespace AdBoard.Domain.Base;

/// <summary>
/// Интерфейс для сущностей, которые имеют идентификатор категории.
/// </summary>
public interface IHaveCategoryId
{
    long CategoryId { get; set; }
}

/// <summary>
/// Интерфейс для сущностей, которые имеют название.
/// </summary>
public interface IHaveName
{
    string Name { get; set; }
}

/// <summary>
/// Интерфейс для сущностей, которые имеют описание.
/// </summary>
public interface IHaveDescription
{
    string Description { get; set; }
}

/// <summary>
/// Интерфейс для сущностей, которые имеют единицу измерения.
/// </summary>
public interface IHaveMeasurementUnit
{
    MeasurementUnit MeasurementUnit { get; set; }
}

/// <summary>
/// Интерфейс для сущностей, которые имеют количество.
/// </summary>
public interface IHaveCount
{
    double Count { get; set; }
}

/// <summary>
/// Интерфейс для сущностей, которые имеют идентификатор магазина.
/// </summary>
public interface IHaveStoreId
{
    long StoreId { get; set; }
}

/// <summary>
/// Интерфейс для сущностей, которые имеют статус.
/// </summary>
public interface IHaveStatus
{
    ProductStatus Status { get; set; }
}

/// <summary>
/// Интерфейс для сущностей, которые имеют цену и единицу измерения.
/// </summary>
public interface IHavePrice
{
    decimal Price { get; set; }
    MeasurementUnit MeasurementUnit { get; set; }
}
