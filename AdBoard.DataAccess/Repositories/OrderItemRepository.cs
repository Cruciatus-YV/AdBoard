using AdBoard.AppServices.Contexts.OrderItem.Repositories;
using AdBoard.Domain.Entities;

namespace AdBoard.Infrastructure.Repositories;

/// <summary>
/// Репозиторий, работающий с товарами из заказа.
/// </summary>
public class OrderItemRepository(AdBoardDbContext _dbContext) : GenericRepository<OrderItemEntity, long>(_dbContext), IOrderItemRepository
{
}