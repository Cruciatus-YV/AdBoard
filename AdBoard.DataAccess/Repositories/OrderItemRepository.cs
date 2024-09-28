using AdBoard.AppServices.Contexts.OrderItem.Repositories;
using AdBoard.Domain.Entities;

namespace AdBoard.DataAccess.Repositories;

public class OrderItemRepository(AdBoardDbContext _dbContext) : GenericRepository<OrderItemEntity, long>(_dbContext), IOrderItemRepository
{
}