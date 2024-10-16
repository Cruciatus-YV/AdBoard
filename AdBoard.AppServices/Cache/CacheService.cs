using AdBoard.AppServices.Contexts.Category.Repositories;
using AdBoard.Contracts.Models.Entities.Category.Responses;
using AdBoard.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace AdBoard.AppServices.Cache;

/// <summary>
/// Сервис для работы с кэшем
/// </summary>
public class CacheService(IDistributedCache distributedCache, ICategoryRepository categoryRepository) : ICacheService
{
    private readonly IDistributedCache _distributedCache = distributedCache;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    private const string ALL_CATEGORIES_KEY = "all_categories";
    private const string CATEGORIES_TREE = "categories_tree";


    public async Task<List<CategoryEntity>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        var allCategoriesSerialized = await _distributedCache.GetStringAsync(ALL_CATEGORIES_KEY, cancellationToken);

        var result = string.IsNullOrWhiteSpace(allCategoriesSerialized) ? null : JsonSerializer.Deserialize<List<CategoryEntity>>(allCategoriesSerialized)!;

        if (result == null)
        {
            result = await PutAllCategoriesToCacheAsync(cancellationToken);
        }

        return result;
    }

    public async Task<List<CategoryResponse>> GetCategoryTreeAsync(CancellationToken cancellationToken)
    {
        var allCategoriesSerialized = await _distributedCache.GetStringAsync(CATEGORIES_TREE, cancellationToken);

        var result = string.IsNullOrWhiteSpace(allCategoriesSerialized) ? null : JsonSerializer.Deserialize<List<CategoryResponse>>(allCategoriesSerialized)!;

        if (result == null)
        {
            await PutAllCategoriesToCacheAsync(cancellationToken);
            return await GetCategoryTreeAsync(cancellationToken);
        }

        return result;
    }

    public async Task AddCategoryAsync(CategoryEntity entity, CancellationToken cancellationToken)
    {
        var allCategories = await GetAllCategoriesAsync(cancellationToken);

        allCategories.Add(entity);
        await UpdateCategoriesAsync(allCategories, cancellationToken);
    }

    public async Task UpdateCategoryAsync(CategoryEntity entity, CancellationToken cancellationToken)
    {
        var allCategories = await GetAllCategoriesAsync(cancellationToken);
        allCategories = allCategories.Where(c => c.Id != entity.Id).ToList();
        allCategories.Add(entity);
        await UpdateCategoriesAsync(allCategories, cancellationToken);
    }

    public async Task DeleteCategoryAsync(long id, CancellationToken cancellationToken)
    {
        var allCategories = await GetAllCategoriesAsync(cancellationToken);
        allCategories.First(x => x.Id == id).IsDeleted = true;
        await UpdateCategoriesAsync(allCategories, cancellationToken);
    }

    private async Task<List<CategoryEntity>> PutAllCategoriesToCacheAsync(CancellationToken cancellationToken)
    {
        var categoriesFromDb = await _categoryRepository.GetListByPredicate(x => x.Approved == true, cancellationToken);
        await UpdateCategoriesAsync(categoriesFromDb, cancellationToken);
        return categoriesFromDb;
    }

    private async Task UpdateCategoriesAsync(List<CategoryEntity> categories, CancellationToken cancellationToken)
    {
        categories = categories.DistinctBy(x => x.Id).ToList();
        var serializedCategories = JsonSerializer.Serialize(categories);
        await _distributedCache.SetStringAsync(ALL_CATEGORIES_KEY, serializedCategories, cancellationToken);

        var tree = BuildCategoryTree(categories.Where(x => !x.IsDeleted).Select(x => new CategoryResponse
        {
            Id = x.Id,
            Name = x.Name,
            ParentId = x.ParentId,
            ChildCategories = [],
        }));
        var serializedCategoriesTree = JsonSerializer.Serialize(tree);
        await _distributedCache.SetStringAsync(CATEGORIES_TREE, serializedCategoriesTree, cancellationToken);
    }

    private static List<CategoryResponse> BuildCategoryTree(IEnumerable<CategoryResponse> categories, long? parentId = null)
    {
        List<CategoryResponse> result = new List<CategoryResponse>();

        foreach (var category in categories.Where(x => x.ParentId == parentId))
        {
            category.ChildCategories = BuildCategoryTree(categories, category.Id);
            result.Add(category);
        }

        return result;
    }

}
