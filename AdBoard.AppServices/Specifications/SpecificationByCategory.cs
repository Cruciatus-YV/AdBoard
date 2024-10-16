using AdBoard.Domain.Base;
using System.Linq.Expressions;

namespace AdBoard.AppServices.Specifications;

/// <summary>
/// Спецификация для фильтрации товаров по идентификатору категории.
/// </summary>
/// <param name="categoryId">Идентификатор категории, по которому будет производиться фильтрация товаров.</param>
public class SpecificationByCategory<TEntity>(long categoryId) : Specification<TEntity>
    where TEntity : IHaveCategoryId
{
    /// <summary>
    /// Лямбда-выражение, которое определяет условие фильтрации товаров по категории.
    /// </summary>
    public override Expression<Func<TEntity, bool>> PredicateExpression => entity =>
        entity.CategoryId == categoryId;
}
