using AdBoard.Contracts.Models.Entities.Category.Requests;
using AdBoard.Contracts.Models.Entities.Category.Responses;

namespace AdBoard.AppServices.Contexts.Category.Services;

/// <summary>
/// Интерфейс для сервиса категорий. Предоставляет методы для работы с категориями.
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Получает дерево категорий.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Дерево категорий в виде списка <see cref="CategoryResponse"/>.</returns>
    Task<IReadOnlyCollection<CategoryResponse>> GetTreeAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получает хлебные крошки для категории по её идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор категории.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Список хлебных крошек в виде <see cref="CategoryResponseLight"/> от корневой категории к целевой.</returns>
    Task<IReadOnlyCollection<CategoryResponseLight>> GetBreadcrumbsByIdAsync(long id,
                                                                        CancellationToken cancellationToken);

    /// <summary>
    /// Создает новую категорию.
    /// </summary>
    /// <param name="model">Модель для создания категории.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Идентификатор созданной категории.</returns>
    Task<long> CreateAsync(CategoryRequestCreate model,
                           CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет информацию о категории.
    /// </summary>
    /// <param name="model">Модель для обновления категории.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>True, если категория была обновлена; в противном случае False.</returns>
    Task<bool> UpdateAsync(CategoryRequestUpdate model,
                           CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет категорию по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор категории.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>True, если категория была удалена; в противном случае False.</returns>
    Task<bool> DeleteAsync(long id,
                           CancellationToken cancellationToken);
}
