using AdBoard.AppServices.Contexts.FavoriteProduct.Repositories;
using AdBoard.Domain.Entities;

namespace AdBoard.Infrastructure.Repositories;

/// <summary>
/// Репозиторий, работающий с избранными товарами.
/// </summary>
public class FavoriteProductRepository(AdBoardDbContext _dbContext) : GenericRepository<FavoriteProductEntity, long>(_dbContext), IFavoriteProductRepository
{
}
