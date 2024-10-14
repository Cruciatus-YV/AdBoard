using AdBoard.Contracts.Models.Entities.Category.Responses;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Cache;

public interface ICacheService
{
    Task<List<CategoryEntity>> GetAllCategoriesAsync(CancellationToken cancellationToken);

    Task<List<CategoryResponse>> GetCategoryTreeAsync(CancellationToken cancellationToken);

    Task AddCategoryAsync(CategoryEntity entity, CancellationToken cancellationToken);

    Task UpdateCategoryAsync(CategoryEntity entity, CancellationToken cancellationToken);

    Task DeleteCategoryAsync(long id, CancellationToken cancellationToken);

}
