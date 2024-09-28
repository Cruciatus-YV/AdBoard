using AdBoard.Contracts.Enums;
using AdBoard.Domain.Base;
using System.Linq.Expressions;

namespace AdBoard.AppServices.Specifications;

/// <summary>
/// Спецификация для фильтрации сущностей по статусу.
/// </summary>
/// <typeparam name="TEntity">Тип сущности, содержащей статус.</typeparam>
/// <param name="status">Статус для фильтрации.</param>
public class SpecificationByStatus<TEntity>(ProductStatus? status) : Specification<TEntity>
    where TEntity : IHaveStatus
{
    private readonly ProductStatus? _status = status;

    /// <summary>
    /// Выражение для фильтрации сущностей по статусу.
    /// </summary>
    public override Expression<Func<TEntity, bool>> PredicateExpression => entity =>
        _status.HasValue ? entity.Status == _status.Value : true;
}
