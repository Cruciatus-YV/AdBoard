using Abp.Linq.Expressions;
using AdBoard.AppServices.Specifications;
using AdBoard.Contracts.Enums;
using AdBoard.Domain.Base;
using System.Linq.Expressions;

namespace AdBoard.AppServices.Specifications;

/// <summary>
/// Спецификация для фильтрации продуктов по максимальной цене при указанной единице измерения.
/// Возвращает товары, которые соответствуют заданной единице измерения 
/// и имеют цену, не превышающую указанную максимальную цену.
/// </summary>
public class SpecificationByPrice<TEntity> : Specification<TEntity>
    where TEntity : IHavePrice
{
    private readonly decimal? _minPrice;
    private readonly decimal? _maxPrice;
    private readonly MeasurementUnit? _measurementUnit;

    public SpecificationByPrice(decimal? minPrice,
                                decimal? maxPrice,
                                MeasurementUnit? measurementUnit)
    {
        _minPrice = minPrice;
        _maxPrice = maxPrice;
        _measurementUnit = measurementUnit;
    }

    /// <summary>
    /// Выражение для фильтрации продуктов по единице измерения количества и цене товара.
    /// </summary>
    public override Expression<Func<TEntity, bool>> PredicateExpression
    {
        get
        {
            Expression<Func<TEntity, bool>> expr = entity => _measurementUnit.HasValue 
                ? entity.MeasurementUnit == _measurementUnit.Value 
                : true;

            if (_minPrice.HasValue)
            {
                expr = expr.And(entity => entity.Price >= _minPrice.Value);
            }

            if (_maxPrice.HasValue)
            {
                expr = expr.And(entity => entity.Price <= _maxPrice.Value);
            }

            return expr;
        }
    }
}