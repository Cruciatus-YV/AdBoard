using AdBoard.AppServices.GenericRepository;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.Category.Repositories;

/// <summary>
/// Интерфейс для репозитория категорий, предоставляющий методы для работы с данными категорий.
/// Наследует от <see cref="IGenericRepository{TEntity, TKey}"/> и включает методы для получения, удаления и работы с категориями.
/// </summary>
public interface ICategoryRepository : IGenericRepository<CategoryEntity, long>
{
    /// <summary>
    /// Получает все активные категории.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Список всех активных категорий.</returns>
    Task<List<CategoryEntity>> GetAllActiveAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет категорию по её идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор категории, которую нужно удалить.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>True, если категория была успешно удалена; в противном случае False.</returns>
    Task<bool> DeleteCategoryAsync(long id, CancellationToken cancellationToken);

    Task<CategoryEntity> ApproveCategoryAsync(long id, CancellationToken cancellationToken);
}
