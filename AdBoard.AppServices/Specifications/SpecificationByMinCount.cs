using AdBoard.Domain.Base;
using System.Linq.Expressions;

namespace AdBoard.AppServices.Specifications
{
    /// <summary>
    /// Спецификация для фильтрации товаров по минимальному количеству.
    /// </summary>
    /// <remarks>
    /// Данная спецификация используется для поиска товаров, количество которых больше или равно указанному значению.
    /// </remarks>
    /// <param name="minCount">Минимальное количество для фильтрации.</param>
    public class SpecificationByMinCount<TEntity>(double minCount) : Specification<TEntity>
        where TEntity : IHaveCount
    {
        private readonly double _minCount = minCount;

        /// <summary>
        /// Выражение для фильтрации товаров по количеству.
        /// </summary>
        /// <remarks>
        /// Фильтруются товары, количество которых больше или равно указанному значению.
        /// </remarks>
        public override Expression<Func<TEntity, bool>> PredicateExpression => entity =>
            entity.Count >= _minCount;
    }
}
