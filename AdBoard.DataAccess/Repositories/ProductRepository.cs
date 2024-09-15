using AdBoard.AppServices.Product.Repositories;
using AdBoard.Domain.Entities;

namespace AdBoard.DataAccess.Repositories;

public class ProductRepository(AdBoardDbContext _dbContext) : GenericRepository<ProductEntity, long>(_dbContext), IProductRepository
{
}