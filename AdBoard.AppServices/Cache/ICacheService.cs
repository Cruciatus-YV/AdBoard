using AdBoard.Contracts.Models.Entities.Category.Responses;

using AdBoard.Domain.Entities;

/// <summary>
/// Интерфейс для операций с кэшированием категорий.
/// Предоставляет методы для получения, добавления, обновления и удаления категорий в кэше.
/// </summary>
public interface ICacheService
{
    /// <summary>
    /// Возвращает список всех категорий из кэша.
    /// </summary>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Список всех категорий.</returns>
    Task<List<CategoryEntity>> GetAllCategoriesAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает иерархическую структуру категорий в виде дерева.
    /// </summary>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Список категорий в формате дерева.</returns>
    Task<List<CategoryResponse>> GetCategoryTreeAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Добавляет новую категорию в кэш.
    /// </summary>
    /// <param name="entity">Экземпляр категории, которую нужно добавить.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task AddCategoryAsync(CategoryEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет существующую категорию в кэше.
    /// </summary>
    /// <param name="entity">Экземпляр категории, которую нужно обновить.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task UpdateCategoryAsync(CategoryEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет категорию по её идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор категории, которую нужно удалить.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task DeleteCategoryAsync(long id, CancellationToken cancellationToken);
}
