using AdBoard.AppServices.Contexts.OrderItem.Repositories;
using AdBoard.Domain.Entities;

namespace AdBoard.Infrastructure.Repositories;

public class OrderItemRepository(AdBoardDbContext _dbContext) : GenericRepository<OrderItemEntity, long>(_dbContext), IOrderItemRepository
{
}