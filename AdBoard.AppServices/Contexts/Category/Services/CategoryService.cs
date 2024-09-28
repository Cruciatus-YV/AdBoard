using AdBoard.AppServices.Contexts.Category.Repositories;
using AdBoard.Contracts.Models.Entities.Category.Requests;
using AdBoard.Contracts.Models.Entities.Category.Responses;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.Category.Services;

/// <summary>
/// Сервис для работы с категориями.
/// Предоставляет методы для получения дерева категорий, хлебных крошек, а также для создания, обновления и удаления категорий.
/// </summary>
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    /// <summary>
    /// Строит дерево категорий.
    /// </summary>
    /// <param name="categories">Список категорий.</param>
    /// <param name="parentId">Идентификатор родительской категории. Если null, строится дерево для корневых категорий.</param>
    /// <returns>Список категорий с подкатегориями.</returns>
    private static List<CategoryResponse> BuildCategoryTree(IEnumerable<CategoryResponse> categories,
                                                       long? parentId = null)
    {
        List<CategoryResponse> result = new List<CategoryResponse>();

        foreach (var category in categories.Where(x => x.ParentId == parentId))
        {
            // Рекурсивно строим поддерево для текущей категории
            category.ChildCategories = BuildCategoryTree(categories, category.Id);
            result.Add(category);
        }

        return result;
    }

    public async Task<IReadOnlyCollection<CategoryResponse>> GetTreeAsync(CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllActiveAsync(cancellationToken);
        var dto = categories.Select(x => new CategoryResponse
        {
            Id = x.Id,
            Name = x.Name,
            ParentId = x.ParentId,
            ChildCategories = new List<CategoryResponse>()
        }).ToList();

        return BuildCategoryTree(dto);
    }

    public async Task<IReadOnlyCollection<CategoryResponseLight>> GetBreadcrumbsByIdAsync(long id,
                                                                                     CancellationToken cancellationToken)
    {
        var breadcrumbs = await _categoryRepository.GetBreadcrumbsByIdAsync(id, cancellationToken);
        return breadcrumbs.Select(x => new CategoryResponseLight
        {
            Id = x.Id,
            Name = x.Name,
            IsDeleted = x.IsDeleted,
            ParentId = x.ParentId,
        }).ToList();
    }

    public async Task<long> CreateAsync(CategoryRequestCreate model,
                                        CancellationToken cancellationToken)
    {
        var entity = new CategoryEntity
        {
            Name = model.Name,
            ParentId = model.ParentId,
        };

        return await _categoryRepository.InsertAsync(entity, cancellationToken);
    }

    public async Task<bool> UpdateAsync(CategoryRequestUpdate request,
                                        CancellationToken cancellationToken)
    {
        var entity = new CategoryEntity
        {
            Id = request.Id,
            Name = request.Name,
            ParentId = request.ParentId,
        };

        return await _categoryRepository.UpdateAsync(entity, cancellationToken);
    }

    public async Task<bool> DeleteAsync(long id,
                                        CancellationToken cancellationToken)
    {
        return await _categoryRepository.DeleteCategoryAsync(id, cancellationToken);
    }
}
