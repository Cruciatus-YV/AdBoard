using AdBoard.AppServices.Category.Repositories;
using AdBoard.Contracts.Category;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Category.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    /// <summary>
    /// Строит дерево категорий
    /// </summary>
    /// <param name="categories">Список категорий</param>
    /// <param name="parentId">Идентификатор родительской категории</param>
    /// <returns></returns>
    private static List<CategoryDTO> BuildCategoryTree(IEnumerable<CategoryDTO> categories, long? parentId = null)
    {
        List<CategoryDTO> result = [];

        foreach (var category in categories.Where(x => x.ParentId == parentId))
        {
            // Рекурсивно строим поддерево для текущей категории
            category.ChildCategories = BuildCategoryTree(categories, category.Id);
            result.Add(category);
        }

        return result;
    }

    public async Task<IReadOnlyCollection<CategoryDTO>> GetTreeAsync(CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllActiveAsync(cancellationToken);
        var dto = categories.Select(x => new CategoryDTO
        {
            Id = x.Id,
            Name = x.Name,
            ParentId = x.ParentId,
            ChildCategories = []
        }).ToList();

        return BuildCategoryTree(dto);
    }

    public async Task<IReadOnlyCollection<CategoryLightDTO>> GetBreadcrumbsByIdAsync(long id, CancellationToken cancellationToken)
    {
        var breadcrumbs = await _categoryRepository.GetBreadcrumbsByIdAsync(id, cancellationToken);
        return breadcrumbs.Select(x => new CategoryLightDTO
        {
            Id = x.Id,
            Name = x.Name,
            IsDeleted = x.IsDeleted,
            ParentId = x.ParentId,
        }).ToList();
    }

    public async Task<long> CreateAsync(CreateCategoryModel model, CancellationToken cancellationToken)
    {
        var entity = new CategoryEntity
        {
            Name = model.Name,
            ParentId = model.ParentId,
        };

        return await _categoryRepository.InsertAsync(entity, cancellationToken);
    }

    public async Task<bool> UpdateAsync(UpdateCategoryModel model, CancellationToken cancellationToken)
    {
        var entity = new CategoryEntity
        {
            Id = model.Id,
            Name = model.Name,
            ParentId = model.ParentId,
        };

        return await _categoryRepository.UpdateAsync(entity, cancellationToken);
    }

    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken)
    {
        return await _categoryRepository.DeleteCategoryAsync(id, cancellationToken);
    }
}
