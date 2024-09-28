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
    /// Получает хлебные крошки для категории по её идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор категории, для которой нужно получить хлебные крошки.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Список хлебных крошек в виде <see cref="CategoryEntity"/> от корневой категории к целевой.</returns>
    Task<List<CategoryEntity>> GetBreadcrumbsByIdAsync(long id,
                                                       CancellationToken cancellationToken);

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
    Task<bool> DeleteCategoryAsync(long id,
                                   CancellationToken cancellationToken);
}
