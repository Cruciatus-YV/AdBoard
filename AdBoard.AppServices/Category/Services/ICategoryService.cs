using AdBoard.Contracts.Category;

namespace AdBoard.AppServices.Category.Services;

public interface ICategoryService
{
    /// <summary>
    /// Получает дерево категорий
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Дерево категорий в виде списка CategoryDTO</returns>
    Task<IReadOnlyCollection<CategoryDTO>> GetTreeAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получает хлебные крошки для категории по её идентификатору
    /// </summary>
    /// <param name="id">Идентификатор категории</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список хлебных крошек в виде СategoryLightDTO от корневой категории к целевой</returns>
    Task<IReadOnlyCollection<CategoryLightDTO>> GetBreadcrumbsByIdAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Создает новую категорию
    /// </summary>
    /// <param name="model">Модель для создания категории</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор созданной категории</returns>
    Task<long> CreateAsync(CreateCategoryModel model, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет информацию о категории
    /// </summary>
    /// <param name="model">Модель для обновления категории</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>True, если категория была обновлена, иначе False</returns>
    Task<bool> UpdateAsync(UpdateCategoryModel model, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет категорию по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор категории</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>True, если категория была удалена, иначе False</returns>
    Task<bool> DeleteAsync(long id, CancellationToken cancellationToken);
}
