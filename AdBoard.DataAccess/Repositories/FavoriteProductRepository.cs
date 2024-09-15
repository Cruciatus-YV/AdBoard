using AdBoard.AppServices.FavoriteProduct.Repositories;
using AdBoard.Domain.Entities;

namespace AdBoard.DataAccess.Repositories;

public class FavoriteProductRepository(AdBoardDbContext _dbContext) : GenericRepository<FavoriteProductEntity, long>(_dbContext), IFavoriteProductRepository
{
}
