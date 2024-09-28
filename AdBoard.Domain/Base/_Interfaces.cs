using AdBoard.Contracts.Enums;

namespace AdBoard.Domain.Base;

public interface IHaveCategoryId
{
    long CategoryId { get; set; }
}

public interface IHaveName
{
    string Name { get; set; }
}

public interface IHaveDescription
{
    string Description { get; set; }
}

public interface IHaveMeasurementUnit
{
    MeasurementUnit MeasurementUnit { get; set; }
}

public interface IHaveCount
{
    double Count { get; set; }
}

public interface IHaveStoreId
{
    long StoreId { get; set; }
}

public interface IHaveStatus
{
    ProductStatus Status { get; set; }
}

public interface IHavePrice
{
    decimal Price { get; set; }
    MeasurementUnit MeasurementUnit { get; set; }
}