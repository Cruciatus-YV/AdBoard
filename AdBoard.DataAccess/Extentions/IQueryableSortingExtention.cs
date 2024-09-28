using System.Linq.Expressions;

namespace AdBoard.DataAccess.Extentions
{
    /// <summary>
    /// Расширения для сортировки объектов по указанному полю.
    /// </summary>
    public static class IQueryableSortingExtention<TEntity>
    {
        /// <summary>
        /// Применяет сортировку к запросу.
        /// </summary>
        /// <param name="query">Запрос для сортировки.</param>
        /// <param name="sortBy">Поле для сортировки (например, "Price", "Name").</param>
        /// <param name="ascending">Флаг, указывающий порядок сортировки. Если true, сортировка по возрастанию, иначе по убыванию.</param>
        /// <returns>Сортированный запрос.</returns>
        public static IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query,
                                                       string sortBy,
                                                       bool ascending)
        {
            return ascending
                ? ApplyAscendingSorting(query, sortBy)
                : ApplyDescendingSorting(query, sortBy);
        }

        private static IQueryable<TEntity> ApplyAscendingSorting(IQueryable<TEntity> query,
                                                                string sortBy)
        {
            var propertyInfo = typeof(TEntity).GetProperty(sortBy);
            if (propertyInfo == null)
                throw new ArgumentException("Невозможно отсортировать по этому полю", nameof(sortBy));

            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var property = Expression.Property(parameter, propertyInfo);
            var lambda = Expression.Lambda<Func<TEntity, object>>(
                Expression.Convert(property, typeof(object)), parameter);

            return query.OrderBy(lambda);
        }

        private static IQueryable<TEntity> ApplyDescendingSorting(IQueryable<TEntity> query,
                                                                  string sortBy)
        {
            var propertyInfo = typeof(TEntity).GetProperty(sortBy);
            if (propertyInfo == null)
                throw new ArgumentException("Невозможно отсортировать по этому полю", nameof(sortBy));

            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var property = Expression.Property(parameter, propertyInfo);
            var lambda = Expression.Lambda<Func<TEntity, object>>(
                Expression.Convert(property, typeof(object)), parameter);

            return query.OrderByDescending(lambda);
        }
    }
}
