using Abp.Timing;
using AdBoard.Domain.Base;
using System.Linq.Expressions;

namespace AdBoard.AppServices.Specifications;


/// <summary>
/// Спецификация для фильтрации товаров по дате создания.
/// </summary>
/// <remarks>
/// Данная спецификация используется для поиска товаров, созданных в указанном диапазоне дат.
/// </remarks>
/// <param name="fromDate">Дата начала диапазона.</param>
/// <param name="toDate">Дата окончания диапазона.</param>
public class SpecificationByDateOfCreating<TEntity>(DateTimeRange dateRange) : Specification<TEntity>
    where TEntity : CreatableEntity<long>
{
    private readonly DateTimeRange _dateRange = dateRange;

    /// <summary>
    /// Выражение для фильтрации товаров по дате создания.
    /// </summary>
    public override Expression<Func<TEntity, bool>> PredicateExpression => entity =>
        entity.CreatedAt >= _dateRange.StartTime && entity.CreatedAt <= _dateRange.EndTime;
}