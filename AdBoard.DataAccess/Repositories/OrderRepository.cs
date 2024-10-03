using AdBoard.AppServices.Contexts.Order.Repositories;
using AdBoard.Domain.Entities;

namespace AdBoard.Infrastructure.Repositories;

public class OrderRepository(AdBoardDbContext _dbContext) : GenericRepository<OrderEntity, long>(_dbContext), IOrderRepository
{
}