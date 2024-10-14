using AdBoard.AppServices.Cache;
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
    private readonly ICacheService _cacheService;

    public CategoryService(ICategoryRepository categoryRepository, ICacheService cacheService)
    {
        _categoryRepository = categoryRepository;
        _cacheService = cacheService;
    }
    public async Task<IReadOnlyCollection<CategoryResponse>> GetTreeAsync(CancellationToken cancellationToken)
    {
        return await _cacheService.GetCategoryTreeAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<CategoryResponseLight>> GetBreadcrumbsByIdAsync(long id, CancellationToken cancellationToken)
    {
        var allCategories = await _cacheService.GetAllCategoriesAsync(cancellationToken);
        var breadcrumbs = new List<CategoryEntity>();
        var currentCategory = allCategories.FirstOrDefault(x => x.Id == id);

        while (currentCategory != null)
        {
            breadcrumbs.Insert(0, currentCategory);
            currentCategory = allCategories.FirstOrDefault(x => x.Id == currentCategory.ParentId);
        }

        return breadcrumbs.Select(x => new CategoryResponseLight
        {
            Id = x.Id,
            Name = x.Name,
            IsDeleted = x.IsDeleted,
            ParentId = x.ParentId,
        }).ToList();
    }

    public async Task<long> CreateUnapprovedAsync(CategoryRequestCreate model, CancellationToken cancellationToken)
    {
        var entity = new CategoryEntity
        {
            Name = model.Name,
            ParentId = model.ParentId,
        };

        return await _categoryRepository.InsertAsync(entity, cancellationToken);
    }

    public async Task<bool> UpdateAsync(CategoryRequestUpdate request, CancellationToken cancellationToken)
    {
        var entity = new CategoryEntity
        {
            Id = request.Id,
            Name = request.Name,
            ParentId = request.ParentId,
        };

        var result = await _categoryRepository.UpdateAsync(entity, cancellationToken);
        await _cacheService.UpdateCategoryAsync(entity, cancellationToken);

        return result;
    }

    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken)
    {
        var result = await _categoryRepository.DeleteCategoryAsync(id, cancellationToken);
        if (result)
        {
            await _cacheService.DeleteCategoryAsync(id, cancellationToken);
        }

        return result;
    }

    public async Task<bool> ApproveAsync(long id, CancellationToken cancellationToken)
    {
        var entity = await _categoryRepository.ApproveCategoryAsync(id, cancellationToken);

        if (entity == null)
        {
            return false;
        }
        else
        {
            await _cacheService.AddCategoryAsync(entity, cancellationToken);

            return true;
        }
    }
}
