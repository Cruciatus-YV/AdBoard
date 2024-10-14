using AdBoard.AppServices.Contexts.Order.Repositories;
using AdBoard.Domain.Entities;
using AdBoard.Infrastructure.Repositories;
using AdBoard.Infrastructure;
using AdBoard.AppServices.Contexts.ProductImage.Repositories;

namespace AdBoard.DataAccess.Repositories;

public class ProductImageRepository(AdBoardDbContext _dbContext) : GenericRepository<ProductImageEntity, long>(_dbContext), IProductImageRepository
{
}