using AdBoard.Domain.Base;
using System.Linq.Expressions;

namespace AdBoard.AppServices.Specifications;

/// <summary>
/// Спецификация для фильтрации товаров по идентификаторам магазинов.
/// </summary>
/// <param name="storeIds">Идентификаторы магазинов, по которым будет производиться фильтрация товаров.</param>
public class SpecificationByStores<TEntity> : Specification<TEntity>
    where TEntity : IHaveStoreId
{
    private readonly List<long> _storeIds;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="ProductSpecificationByStores"/> с указанными идентификаторами магазинов.
    /// </summary>
    /// <param name="storeIds">Идентификаторы магазинов.</param>
    public SpecificationByStores(List<long> storeIds)
    {
        _storeIds = storeIds ?? throw new ArgumentNullException(nameof(storeIds));
    }

    /// <summary>
    /// Лямбда-выражение, которое определяет условие фильтрации товаров по магазинам.
    /// </summary>
    public override Expression<Func<TEntity, bool>> PredicateExpression => entity =>
        _storeIds.Contains(entity.StoreId);
}
