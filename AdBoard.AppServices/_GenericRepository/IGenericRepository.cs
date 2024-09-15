using AdBoard.Domain.Base;
using System.Linq.Expressions;

namespace AdBoard.AppServices.GenericRepository;

public interface IGenericRepository<TEntity, TId> where TEntity : BaseEntity<TId>
{
    /// <summary>
    /// Получает сущность по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Сущность либо null</returns>
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken);

    /// <summary>
    /// Получает список сущностей, соответствующих заданному предикату.
    /// </summary>
    /// <param name="predicate">Предикат, определяющий условие для фильтрации сущностей.</param>
    /// <param name="cancellationToken">Токен отмены для управления отменой асинхронной операции.</param>
    /// <returns>Список сущностей, удовлетворяющих условию предиката. Если сущностей не найдено, возвращается пустой список.</returns>
    Task<List<TEntity>> GetByPredicate(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);


    /// <summary>
    /// Добавляет сущность
    /// </summary>
    /// <param name="model">Сущность</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    Task<TId> InsertAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет сущность
    /// </summary>
    /// <param name="model">Сущность</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет сущность
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken);

}
