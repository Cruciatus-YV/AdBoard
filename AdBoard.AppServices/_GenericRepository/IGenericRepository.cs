using AdBoard.Domain.Base;
using System.Linq.Expressions;

namespace AdBoard.AppServices.GenericRepository;

/// <summary>
/// Интерфейс для дженерик репозитория. Предоставляет методы для
/// выполнения основных операций CRUD (создание, чтение, обновление, удаление)
/// с сущностями, основанными на обобщенном типе.
/// </summary>
public interface IGenericRepository<TEntity, TId> where TEntity : BaseEntity<TId>
{
    /// <summary>
    /// Получает сущность по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор сущности.</param>
    /// <param name="cancellationToken">Токен отмены для управления отменой асинхронной операции.</param>
    /// <returns>Сущность либо null.</returns>
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken);

    /// <summary>
    /// Получает список сущностей, соответствующих заданному предикату.
    /// </summary>
    /// <param name="predicate">Предикат, определяющий условие для фильтрации сущностей.</param>
    /// <param name="cancellationToken">Токен отмены для управления отменой асинхронной операции.</param>
    /// <returns>Список сущностей, удовлетворяющих условию предиката. Если сущностей не найдено, возвращается пустой список.</returns>
    Task<List<TEntity>> GetListByPredicate(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    /// <summary>
    /// Получает сущность, соответствующую заданному предикату.
    /// </summary>
    /// <param name="predicate">Предикат, определяющий условие для поиска сущности.</param>
    /// <param name="cancellationToken">Токен отмены для управления отменой асинхронной операции.</param>
    /// <returns>Сущность либо null, если не найдена.</returns>
    Task<TEntity?> GetByPredicate(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    /// <summary>
    /// Добавляет сущность.
    /// </summary>
    /// <param name="entity">Сущность, которую нужно добавить.</param>
    /// <param name="cancellationToken">Токен отмены для управления отменой асинхронной операции.</param>
    /// <returns>Идентификатор добавленной сущности.</returns>
    Task<TId> InsertAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Добавляет список сущностей.
    /// </summary>
    /// <param name="entities">Список сущностей, которые нужно добавить.</param>
    /// <param name="cancellationToken">Токен отмены для управления отменой асинхронной операции.</param>
    /// <returns>Список идентификаторов добавленных сущностей.</returns>
    Task<IEnumerable<TEntity>> InsertListAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет сущность.
    /// </summary>
    /// <param name="entity">Сущность, которую нужно обновить.</param>
    /// <param name="cancellationToken">Токен отмены для управления отменой асинхронной операции.</param>
    /// <returns>Истинное значение, если обновление прошло успешно; иначе ложное значение.</returns>
    Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет список сущностей.
    /// </summary>
    /// <param name="entities">Список сущностей, которые нужно обновить.</param>
    /// <param name="cancellationToken">Токен отмены для управления отменой асинхронной операции.</param>
    /// <returns>Истинное значение, если обновление прошло успешно; иначе ложное значение.</returns>
    Task<bool> UpdateListAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет сущность.
    /// </summary>
    /// <param name="id">Идентификатор сущности, которую нужно удалить.</param>
    /// <param name="cancellationToken">Токен отмены для управления отменой асинхронной операции.</param>
    /// <returns>True, если удаление прошло успешно; иначе False.</returns>
    Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет список сущностей по их идентификаторам.
    /// </summary>
    /// <param name="ids">Идентификаторы сущностей, которые нужно удалить.</param>
    /// <param name="cancellationToken">Токен отмены для управления отменой асинхронной операции.</param>
    /// <returns>Истинное значение, если удаление прошло успешно; иначе ложное значение.</returns>
    Task<bool> DeleteListAsync(IReadOnlyCollection<TId> ids, CancellationToken cancellationToken);

    /// <summary>
    /// Получает список сущностей, удовлетворяющих заданному предикату, с учетом пагинации.
    /// </summary>
    /// <param name="predicate">Предикат, определяющий условие для фильтрации сущностей.</param>
    /// <param name="pageNumber">Номер страницы для пагинации. Страницы нумеруются с 1.</param>
    /// <param name="pageSize">Количество сущностей на одной странице.</param>
    /// <param name="cancellationToken">Токен отмены для управления отменой асинхронной операции.</param>
    /// <returns>Список сущностей, удовлетворяющих заданному предикату, и принадлежащих к указанной странице.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Вызывается, если <paramref name="pageNumber"/> или <paramref name="pageSize"/> имеют недопустимые значения.
    /// </exception>
    Task<List<TEntity>> GetByPredicateAndPaginationAsync(Expression<Func<TEntity, bool>> predicate,
                                                         int pageNumber,
                                                         int pageSize,
                                                         CancellationToken cancellationToken);

    /// <summary>
    /// Проверяет, существует ли сущность с указанным идентификатором в базе данных.
    /// </summary>
    /// <param name="id">Идентификатор сущности, для которой нужно проверить существование.</param>
    /// <param name="cancellationToken">Токен отмены асинхронной операции.</param>
    /// <returns>Возвращает <c>true</c>, если сущность с указанным идентификатором существует; иначе <c>false</c>.</returns>
    Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken);
}
