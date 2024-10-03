using AdBoard.AppServices.Contexts.FavoriteProduct.Repositories;
using AdBoard.Domain.Entities;

namespace AdBoard.Infrastructure.Repositories;

public class FavoriteProductRepository(AdBoardDbContext _dbContext) : GenericRepository<FavoriteProductEntity, long>(_dbContext), IFavoriteProductRepository
{
}
