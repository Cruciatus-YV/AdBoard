using AdBoard.AppServices.FavoriteProduct.Repositories;
using AdBoard.AppServices.Order.Repositories;
using AdBoard.Domain.Entities;

namespace AdBoard.DataAccess.Repositories;

public class OrderRepository(AdBoardDbContext _dbContext) : GenericRepository<OrderEntity, long>(_dbContext), IOrderRepository
{
}